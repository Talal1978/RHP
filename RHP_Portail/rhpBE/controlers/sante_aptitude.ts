/* Module Sante - Fiches d'aptitude (redaction CLINIQUE ; consultation ADMIN si publiees) */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
import {
  getAgent, checkSanteAccess, santeEndpoint, santeAudit, verrouCndpActif, nouveauNumero, toDate, setNoStore,
} from "../modules/module_sante";

/* Liste aptitudes : CLINIQUE = tout ; ADMIN = publiees uniquement -------------- */
export async function sante_aptitude_liste(req: Request, res: Response) {
  setNoStore(res);
  const { theAgent, idSocNum } = getAgent(req);
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });
  const clinique = await checkSanteAccess(theAgent, "CLINIQUE");
  const admin = clinique.ok ? clinique : await checkSanteAccess(theAgent, "ADMIN");
  if (!admin.ok) {
    await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Aptitude", succes: false, motif: admin.motif });
    return res.send({ result: false, message: "Accès non autorisé" });
  }
  let { Matricule, Statut_Aptitude, Dat_Du, Dat_Au } = req.body;
  if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
  const du = toDate(Dat_Du) || new Date(1900, 0, 1);
  const au = toDate(Dat_Au) || new Date(2045, 11, 31);
  const filtrePublication = clinique.ok ? "1=1" : "isnull(a.Publie_RH,'false')='true' and isnull(a.Statut,'') in ('VA','SG')";
  const rsl = await lireSql(
    `select TOP 50 Num_Aptitude 'N° fiche', a.Matricule, r.Nom, Dat_Aptitude as 'Date',
       dbo.FindRubrique('Statut_Aptitude',a.Statut_Aptitude) as 'Aptitude',
       a.Restrictions_Poste as 'Restrictions', a.Dat_Effet as 'Effet', a.Dat_Fin as 'Fin validité',
       a.Version, dbo.FindRubrique('Statut_Signature',a.Statut) as Statut
     from RH_Sante_Aptitude a
     outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=a.id_Societe and Matricule=a.Matricule) r
     where a.id_Societe=@idSoc and a.Matricule like '%'+@Matricule
       and Dat_Aptitude between @du and @au
       and isnull(a.Statut_Aptitude,'') like @apt and ${filtrePublication}
     order by [Date] desc`,
    [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
      { param: "apt", sqlType: NVarChar, valeur: (Statut_Aptitude || "") + "%" },
      { param: "du", sqlType: SmallDateTime, valeur: du },
      { param: "au", sqlType: SmallDateTime, valeur: au },
    ]
  );
  await santeAudit({ req, action: "LECT", objet: "RH_Sante_Aptitude", succes: true, motif: clinique.ok ? "Liste (clinique)" : "Liste (publiees)" });
  res.send(rsl);
}

export async function get_sante_aptitude(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Aptitude", async (req2, res2, idSocNum) => {
    const { Num_Aptitude } = req.body;
    const rsl = await lireSql(
      `select * from RH_Sante_Aptitude where Num_Aptitude=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Aptitude || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Aptitude", valeurIndex: Num_Aptitude, matriculeConcerne: rsl?.data?.[0]?.Matricule, succes: true });
    res2.send(rsl);
  });
}

/* Enregistrement : jamais d'ecrasement d'une version validee ------------------- */
export async function save_sante_aptitude(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Aptitude", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Aptitude", succes: false, motif: "Verrou CNDP actif" });
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const { entete: _entete } = req.body;
    let { Num_Aptitude, ...entete } = _entete;
    const estCreation = !Num_Aptitude || Num_Aptitude === "";

    if (!entete.Matricule) return res2.send({ result: false, message: "Matricule non renseigné" });
    if (!entete.Statut_Aptitude) return res2.send({ result: false, message: "Statut d'aptitude non renseigné" });

    if (!estCreation) {
      const ex = await lireSql(
        `select Statut, Version from RH_Sante_Aptitude where Num_Aptitude=@num and id_Societe=@idSoc`,
        [
          { param: "num", sqlType: NVarChar, valeur: Num_Aptitude },
          { param: "idSoc", sqlType: Int, valeur: idSocNum },
        ]
      );
      if (ex.result && ex.data.length > 0 && ["VA", "SG"].includes(ex.data[0].Statut || "")) {
        return res2.send({ result: false, message: "Fiche validée : créez une nouvelle version (rectification motivée)" });
      }
    } else {
      // Nouvelle version d'une fiche existante : motif obligatoire
      if (entete.Num_Aptitude_Prec) {
        if (!entete.Motif_Version) {
          return res2.send({ result: false, message: "Le motif de la nouvelle version est obligatoire" });
        }
        const v = await lireSql(
          `select isnull(max(Version),0)+1 as v from RH_Sante_Aptitude where Matricule=@mat and id_Societe=@idSoc`,
          [
            { param: "mat", sqlType: NVarChar, valeur: entete.Matricule },
            { param: "idSoc", sqlType: Int, valeur: idSocNum },
          ]
        );
        entete.Version = v?.data?.[0]?.v || 1;
      } else {
        entete.Version = entete.Version || 1;
      }
      Num_Aptitude = await nouveauNumero("FA", "RH_Sante_Aptitude", "Num_Aptitude", "Dat_Aptitude", idSocNum);
    }

    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Aptitude",
      fields: { ...entete, Num_Aptitude, id_Societe: idSocNum },
      joinFields: ["Num_Aptitude", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    if (!rsEnt.result) return res2.send(rsEnt);

    if (entete.Statut === "SS") {
      await sousmettre_signature("FA", Num_Aptitude, String(idSocNum), theAgent.Matricule);
    }
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Aptitude", valeurIndex: Num_Aptitude, matriculeConcerne: entete.Matricule, succes: true });
    res2.send(rsEnt);
  });
}

/* Generation en masse pour une campagne : audit individuel par fiche ------------ */
export async function sante_aptitude_masse(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Aptitude", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const { Cod_Campagne, Dat_Aptitude, Cod_Medecin } = req.body;
    if (!Cod_Campagne) return res2.send({ result: false, message: "Campagne non renseignée" });
    if (controleInjection(Cod_Campagne).result === false) return res2.send({ result: false, message: "Injection détectée" });

    // Agents de la campagne ayant une visite realisee sans fiche d'aptitude
    const cibles = await lireSql(
      `select distinct v.Matricule, v.Num_Visite, v.Statut_Aptitude, v.Reserves, v.Restrictions
       from RH_Sante_Visite v
       where v.id_Societe=@idSoc and v.Cod_Campagne=@camp and isnull(v.Statut,'') in ('VA','SG')
         and not exists (select 1 from RH_Sante_Aptitude a where a.Num_Visite=v.Num_Visite and a.id_Societe=v.id_Societe)`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "camp", sqlType: NVarChar, valeur: Cod_Campagne },
      ]
    );
    if (!cibles.result) return res2.send({ result: false, message: "Erreur lecture des visites de la campagne" });

    let nb = 0;
    for (const c of cibles.data) {
      const num = await nouveauNumero("FA", "RH_Sante_Aptitude", "Num_Aptitude", "Dat_Aptitude", idSocNum);
      const rs = await ecrireSql({
        tableName: "RH_Sante_Aptitude",
        fields: {
          Num_Aptitude: num, id_Societe: idSocNum, Num_Visite: c.Num_Visite,
          Matricule: c.Matricule, Dat_Aptitude: toDate(Dat_Aptitude) || new Date(),
          Cod_Medecin: Cod_Medecin || "", Statut_Aptitude: c.Statut_Aptitude,
          Reserves: c.Reserves || "", Restrictions_Poste: c.Restrictions || "",
          Dat_Effet: toDate(Dat_Aptitude) || new Date(), Version: 1, Statut: "",
        },
        joinFields: ["Num_Aptitude", "id_Societe"],
        excludeFields: [],
        login: theAgent.Matricule || theAgent.Login,
      });
      if (rs.result) {
        nb++;
        await santeAudit({ req, action: "CREA", objet: "RH_Sante_Aptitude", valeurIndex: num, matriculeConcerne: c.Matricule, succes: true, motif: "Génération en masse (campagne " + Cod_Campagne + ")" });
      }
    }
    res2.send({ result: true, data: [{ generees: nb }] });
  });
}
