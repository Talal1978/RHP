/* Module transverse du domaine Sante (cloisonnement des donnees medicales).
   Homogene au socle : controle dans les controleurs, base sur les tables
   d'habilitation existantes (Controle_Menu_Functions / Controle_Droit_Functions). */
import { Request, Response } from "express";
import { lireSql } from "./module_sqlRW";
import { Int, NVarChar, DateTime } from "mssql";

export type DomaineSante = "CLINIQUE" | "ADMIN" | "AUDIT";

/* Recupere l'agent connecte (injecte par le middleware validate) */
export function getAgent(req: Request) {
  const { processId, ...theAgent } = req.params as any;
  const idSocNum = Number(theAgent?.id_Societe || 0);
  return { theAgent, idSocNum };
}

/* Id societe valide ou reponse d'erreur (pattern des controleurs existants) */
export function idSocInvalide(res: Response) {
  return res.send({ result: false, message: "id_Societe invalide" });
}

/* Headers interdisant la mise en cache des donnees de sante */
export function setNoStore(res: Response) {
  res.setHeader("Cache-Control", "no-store");
  res.setHeader("Pragma", "no-cache");
}

/* Journal d'acces medical (append-only). Ne bloque jamais la reponse. */
export async function santeAudit(args: {
  req: Request;
  action: "LECT" | "CREA" | "MODI" | "SUPP" | "IMPR" | "EXPO" | "TELE" | "AUTH_KO";
  objet: string;
  valeurIndex?: string;
  matriculeConcerne?: string;
  succes: boolean;
  motif?: string;
}) {
  try {
    const { theAgent, idSocNum } = getAgent(args.req);
    const ip =
      (args.req.headers["x-forwarded-for"] as string)?.split(",")[0]?.trim() ||
      args.req.socket?.remoteAddress ||
      "";
    await lireSql(
      `insert into RH_Sante_Audit_Acces
        (id_Societe, Login_User, id_User, Cod_Profile, Typ_Role, Action, Objet, Valeur_Index,
         Matricule_Concerne, Poste, IP, Succes, Motif)
       values (@p_idSoc, @p_Login, @p_idUser, @p_CodProfile, @p_TypRole, @p_Action, @p_Objet, @p_ValeurIndex,
         @p_Matricule, 'web', @p_IP, @p_Succes, @p_Motif)`,
      [
        { param: "p_idSoc", sqlType: Int, valeur: idSocNum > 0 ? idSocNum : null },
        { param: "p_Login", sqlType: NVarChar, valeur: theAgent?.Login || "" },
        { param: "p_idUser", sqlType: Int, valeur: Number(theAgent?.id_User || -1) },
        { param: "p_CodProfile", sqlType: NVarChar, valeur: String(theAgent?.codProfile ?? "") },
        { param: "p_TypRole", sqlType: NVarChar, valeur: theAgent?.Typ_Role || "" },
        { param: "p_Action", sqlType: NVarChar, valeur: args.action },
        { param: "p_Objet", sqlType: NVarChar, valeur: args.objet },
        { param: "p_ValeurIndex", sqlType: NVarChar, valeur: args.valeurIndex || "" },
        { param: "p_Matricule", sqlType: NVarChar, valeur: args.matriculeConcerne || "" },
        { param: "p_IP", sqlType: NVarChar, valeur: ip.substring(0, 50) },
        { param: "p_Succes", sqlType: NVarChar, valeur: args.succes ? "1" : "0" },
        { param: "p_Motif", sqlType: NVarChar, valeur: (args.motif || "").substring(0, 250) },
      ]
    );
  } catch (e) {
    console.error("[Sante] audit error:", e);
  }
}

/* Controle d'habilitation par domaine, homogene au cloisonnement TeamLeader :
   - CLINIQUE : fonction SANTE_CLINIQUE active pour le profil de l'utilisateur
   - ADMIN    : SANTE_ADMIN ou SANTE_CLINIQUE
   - AUDIT    : SANTE_AUDIT
   Le codProfile vient du JWT (profil Controle_Users rattache par Mail au login). */
export async function checkSanteAccess(
  theAgent: any,
  domaine: DomaineSante
): Promise<{ ok: boolean; motif: string }> {
  const codProfile = String(theAgent?.codProfile ?? "-1");
  if (codProfile === "" || codProfile === "-1" || codProfile === "undefined") {
    return { ok: false, motif: "Profil non rattaché" };
  }
  const fonctions =
    domaine === "CLINIQUE"
      ? "('SANTE_CLINIQUE')"
      : domaine === "ADMIN"
      ? "('SANTE_ADMIN','SANTE_CLINIQUE')"
      : "('SANTE_AUDIT')";
  const rsl = await lireSql(
    `select count(*) as nb from Controle_Droit_Functions
     where Cod_Profile = @profil and Function_Sec in ${fonctions} and isnull(Actif,'false') = 'true'`,
    [{ param: "profil", sqlType: NVarChar, valeur: codProfile }]
  );
  const ok = rsl.result && rsl.data.length > 0 && Number(rsl.data[0].nb) > 0;
  return { ok, motif: ok ? "" : "Fonction " + domaine + " non accordée" };
}

/* Verrou de mise en production CNDP (donnees sensibles de sante) :
   si BLOCAGE_PROD_SANS_CNDP='O' et aucune autorisation renseignee, les ecritures
   cliniques sont bloquees. */
export async function verrouCndpActif(idSocNum: number): Promise<boolean> {
  const rsl = await lireSql(
    `select dbo.Sys_Sante_Param('BLOCAGE_PROD_SANS_CNDP', @idSoc) as blocage,
            isnull(dbo.Sys_Sante_Param('CNDP_NUM_AUTORISATION', @idSoc),'') as autorisation`,
    [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
  );
  if (!rsl.result || rsl.data.length === 0) return false;
  return rsl.data[0].blocage === "O" && String(rsl.data[0].autorisation).trim() === "";
}

/* Wrapper standard d'un endpoint sante : agent -> idSoc -> habilitation -> audit.
   fn recoit (req, res, idSocNum) et ecrit la reponse. */
export async function santeEndpoint(
  req: Request,
  res: Response,
  domaine: DomaineSante,
  objet: string,
  fn: (req: Request, res: Response, idSocNum: number) => Promise<any>
) {
  setNoStore(res);
  const { theAgent, idSocNum } = getAgent(req);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    idSocInvalide(res);
    return;
  }
  const acces = await checkSanteAccess(theAgent, domaine);
  if (!acces.ok) {
    await santeAudit({
      req,
      action: "AUTH_KO",
      objet,
      succes: false,
      motif: acces.motif,
    });
    res.send({ result: false, message: "Accès non autorisé" });
    return;
  }
  try {
    await fn(req, res, idSocNum);
  } catch (e) {
    console.error("[Sante] endpoint error:", e);
    res.send({ result: false, message: "Erreur interne du serveur" });
  }
}

/* Generation d'un numero de document : <PREFIXE><idSoc>-<annee><seq 6> (pattern socle) */
export async function nouveauNumero(
  prefixe: string,
  tableName: string,
  colNum: string,
  colDate: string,
  idSocNum: number
): Promise<string> {
  const rsl = await lireSql(
    `select '${prefixe}'+convert(nvarchar(10),@idSoc)+'-'+convert(nvarchar(4),year(getdate()))
       +right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as num
     from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end) as racine
           from ${tableName} outer apply(select RIGHT(${colNum},6) as racine)n
           where id_Societe=@idSoc and year(${colDate})=year(getdate()))f`,
    [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
  );
  return rsl?.data?.[0]?.num || "";
}

/* Conversion date entree (string ISO ou dd/MM/yyyy) -> objet Date (SmallDateTime) */
export function toDate(v: any): Date | null {
  if (!v) return null;
  if (v instanceof Date) return isNaN(v.getTime()) ? null : v;
  const s = String(v);
  if (/^\d{2}\/\d{2}\/\d{4}/.test(s)) {
    const [d, m, y] = s.split("/");
    const dt = new Date(Number(y), Number(m) - 1, Number(d));
    return isNaN(dt.getTime()) ? null : dt;
  }
  const dt = new Date(s);
  return isNaN(dt.getTime()) ? null : dt;
}
