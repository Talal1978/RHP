/* Module Sante - Generation PDF des editions + archivage GED cloisonne.
   Reutilise la mecanique du socle (crexport.exe) puis rattache le PDF produit
   a l'objet metier dans Param_GED avec droits restreints au service medical. */
import { Response, Request } from "express";
import { exec } from "node:child_process";
import path from "node:path";
import fs from "fs";
import { Int, NVarChar } from "mssql";
import { lireSql } from "../modules/module_sqlRW";
import { VGLOBALES } from "../modules/module_initialisation";
import { makeid } from "../modules/module_general";
import {
  getAgent, DomaineSante, santeEndpoint, santeAudit, setNoStore,
} from "../modules/module_sante";

const getOdbcInfo = async () => {
  const rsl = await lireSql(
    `select * from (select Valeur as 'odbc' from Param_General where Cod_Param ='ODBC_RHP') o,
     (select Valeur as 'path' from Param_General where Cod_Param ='Lecteur_Digital_Mod_Edition')p`,
    []
  );
  return rsl.result && rsl.data.length > 0
    ? { path: rsl.data[0].path as string, odbc: rsl.data[0].odbc as string }
    : { path: "", odbc: "" };
};

/* Liste des id_User du service medical (profils disposant de la fonction). */
async function utilisateursDomaine(fonction: string): Promise<string> {
  const rsl = await lireSql(
    `select string_agg(convert(nvarchar(10),u.id_User),';') as ids
     from Controle_Users u
     where isnull(u.Actif,'false')='true' and exists (
       select 1 from Controle_Droit_Functions f
       where f.Cod_Profile=convert(nvarchar(10),u.Cod_Profile) and f.Function_Sec=@fonc and isnull(f.Actif,'false')='true')`,
    [{ param: "fonc", sqlType: NVarChar, valeur: fonction }]
  );
  const ids = rsl?.data?.[0]?.ids;
  return ids ? ids : "";
}

/* Generation du PDF + archivage GED + mise a jour de la reference sur l'objet. */
async function genererEtArchiver(args: {
  req: Request;
  codReport: string;
  params: { [k: string]: string };
  nameEcran: string;
  valeurIndex: string;
  alias: string;
  tableMaj?: string;
  colMaj?: string;
  colFd?: string;
  clinique?: boolean;
}): Promise<{ result: boolean; fd_id?: number; message?: string }> {
  const { theAgent, idSocNum } = getAgent(args.req);
  const { SQL_USER, SQL_PASSWORD, SQL_DB } = VGLOBALES;
  const { path: PATH_REPORT, odbc: ODBC_SERVEUR } = await getOdbcInfo();
  if (!PATH_REPORT) return { result: false, message: "Chemin des éditions non paramétré" };

  const filename = `${args.codReport}_${makeid(6)}.pdf`;
  const fileTmp = path.resolve(process.cwd(), "tmp", filename);
  const crystalExe = path.resolve(process.cwd(), "tools/CRExport/crexport.exe");
  const keys = Object.keys(args.params);
  const values = keys.map((k) => args.params[k]);
  const cmdString = ` ${crystalExe} -r "${PATH_REPORT}/${args.codReport}.rpt" -u "${SQL_USER}" -pw "${SQL_PASSWORD}" -o "${ODBC_SERVEUR}" -db "${SQL_DB}" -f "${fileTmp}" -p "${keys}" -v "${values}"`;

  const execRes: string | null = await new Promise((resolve) => {
    exec(cmdString, (err) => resolve(err ? err.message : null));
  });
  if (execRes) return { result: false, message: "Génération PDF impossible (le modèle .rpt est-il déposé ?)" };
  if (!fs.existsSync(fileTmp)) return { result: false, message: "PDF non produit" };

  // Deplacement vers le stockage GED
  const uploadDir = path.resolve(VGLOBALES.UPLOADS_PATH);
  if (!fs.existsSync(uploadDir)) fs.mkdirSync(uploadDir, { recursive: true });
  const finalName = `${Date.now()}_${filename}`;
  const finalPath = path.join(uploadDir, finalName);
  fs.renameSync(fileTmp, finalPath);
  const taille = fs.statSync(finalPath).size;

  // Droits : documents cliniques reserves au service medical
  let droits = "*";
  if (args.clinique) {
    const ids = await utilisateursDomaine("SANTE_CLINIQUE");
    droits = ids || "*";
  }
  const ins = await lireSql(
    `insert into Param_GED (id_Societe, Name_Ecran, Typ, Index_Ecran, Value_Index, FD_Alias, File_Path,
       Parent_Dir, Lecture, Ecriture, Cacher, Zone_Index, Taille, Created_By, Dat_Crea)
     values (@idSoc, @ecran, 'F', @index, @valIndex, @alias, @path, 0, @droits, @droits, '', 'MEDICAL', @taille, @login, getdate());
     select scope_identity() as fd`,
    [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
      { param: "ecran", sqlType: NVarChar, valeur: args.nameEcran },
      { param: "index", sqlType: NVarChar, valeur: args.valeurIndex },
      { param: "valIndex", sqlType: NVarChar, valeur: args.valeurIndex },
      { param: "alias", sqlType: NVarChar, valeur: args.alias },
      { param: "path", sqlType: NVarChar, valeur: finalPath },
      { param: "droits", sqlType: NVarChar, valeur: droits },
      { param: "taille", sqlType: Int, valeur: taille },
      { param: "login", sqlType: NVarChar, valeur: theAgent?.Matricule || theAgent?.Login || "" },
    ]
  );
  const fdId = Number(ins?.data?.[0]?.fd || 0);

  // Reference sur l'objet metier
  if (fdId > 0 && args.tableMaj && args.colMaj && args.colFd) {
    await lireSql(
      `update ${args.tableMaj} set ${args.colFd}=@fd where ${args.colMaj}=@val and id_Societe=@idSoc`,
      [
        { param: "fd", sqlType: Int, valeur: fdId },
        { param: "val", sqlType: NVarChar, valeur: args.valeurIndex },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
  }
  return { result: true, fd_id: fdId };
}

/* Fiche d'aptitude -> PDF archive (domaine CLINIQUE) */
export async function sante_aptitude_pdf(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Aptitude", async (req2, res2, idSocNum) => {
    const { Num_Aptitude } = req.body;
    if (!Num_Aptitude) return res2.send({ result: false, message: "Fiche non identifiée" });
    const r = await genererEtArchiver({
      req,
      codReport: "Sante_Fiche_Aptitude",
      params: { Num_Aptitude: Num_Aptitude, IDSOC: String(idSocNum) },
      nameEcran: "RH_Sante_Aptitude",
      valeurIndex: Num_Aptitude,
      alias: "Fiche d'aptitude " + Num_Aptitude + ".pdf",
      tableMaj: "RH_Sante_Aptitude",
      colMaj: "Num_Aptitude",
      colFd: "FD_PDF",
      clinique: true,
    });
    await santeAudit({ req, action: "IMPR", objet: "RH_Sante_Aptitude", valeurIndex: Num_Aptitude, succes: r.result, motif: r.result ? "PDF archivé GED" : (r.message || "") });
    res2.send(r);
  });
}

/* Rapport d'incident AT -> PDF archive (domaine ADMIN) */
export async function sante_incident_at_pdf(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Declaration_AT", async (req2, res2, idSocNum) => {
    const { Num_Declaration } = req.body;
    if (!Num_Declaration) return res2.send({ result: false, message: "Déclaration non identifiée" });
    const r = await genererEtArchiver({
      req,
      codReport: "Sante_Rapport_Incident_AT",
      params: { Num_Declaration: Num_Declaration, IDSOC: String(idSocNum) },
      nameEcran: "RH_Declaration_AT",
      valeurIndex: Num_Declaration,
      alias: "Rapport incident " + Num_Declaration + ".pdf",
      clinique: false,
    });
    await santeAudit({ req, action: "IMPR", objet: "RH_Declaration_AT", valeurIndex: Num_Declaration, succes: r.result });
    res2.send(r);
  });
}

/* Rapport annuel -> PDF archive par societe/exercice/version (domaine ADMIN) */
export async function sante_rapport_annuel_pdf(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Rapport_Annuel", async (req2, res2, idSocNum) => {
    const an = Number(req.body?.Annee || 0);
    if (an < 2000) return res2.send({ result: false, message: "Année invalide" });
    const r = await genererEtArchiver({
      req,
      codReport: "Sante_Rapport_Annuel",
      params: { Annee: String(an), IDSOC: String(idSocNum) },
      nameEcran: "RH_Sante_Rapport_Annuel",
      valeurIndex: String(an),
      alias: "Rapport annuel médecine du travail " + an + ".pdf",
      tableMaj: "RH_Sante_Rapport_Annuel",
      colMaj: "Annee",
      colFd: "FD_Rapport",
      clinique: false,
    });
    await santeAudit({ req, action: "IMPR", objet: "RH_Sante_Rapport_Annuel", valeurIndex: String(an), succes: r.result });
    res2.send(r);
  });
}
