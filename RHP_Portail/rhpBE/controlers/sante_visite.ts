/* Module Sante - Visites medicales et dossier sante (domaine CLINIQUE) */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
import {
  getAgent, santeEndpoint, santeAudit, verrouCndpActif, nouveauNumero, toDate,
} from "../modules/module_sante";

/* Liste complete (CLINIQUE) ------------------------------------------------- */
export async function sante_visite_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Visite", async (req2, res2, idSocNum) => {
    let { Matricule, Typ_Visite, Statut, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée dans Matricule" });
    if (controleInjection(Typ_Visite).result === false) return res2.send({ result: false, message: "Injection détectée dans Typ_Visite" });
    if (controleInjection(Statut).result === false) return res2.send({ result: false, message: "Injection détectée dans Statut" });
    const du = toDate(Dat_Du) || new Date(1900, 0, 1);
    const au = toDate(Dat_Au) || new Date(2045, 11, 31);
    const rsl = await lireSql(
      `select TOP 50 Num_Visite 'N° visite', v.Matricule, r.Nom, Dat_Visite as 'Date visite',
         dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type',
         dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as 'Aptitude',
         Dat_Prochaine_Visite as 'Prochaine visite',
         dbo.FindRubrique('Statut_Signature',Statut) as Statut, Conclusion, Reserves, Restrictions
       from RH_Sante_Visite v
       outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
       where v.id_Societe=@idSoc and v.Matricule like '%'+@Matricule
         and Dat_Visite between @du and @au
         and isnull(Typ_Visite,'') like @typ and isnull(Statut,'') like @statut
       order by [Date visite] desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "typ", sqlType: NVarChar, valeur: (Typ_Visite || "") + "%" },
        { param: "statut", sqlType: NVarChar, valeur: (Statut || "") + "%" },
        { param: "du", sqlType: SmallDateTime, valeur: du },
        { param: "au", sqlType: SmallDateTime, valeur: au },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Visite", succes: true, motif: "Liste (clinique)" });
    res2.send(rsl);
  });
}

/* Liste planning (ADMIN) : sans colonnes cliniques --------------------------- */
export async function sante_visite_liste_planning(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Visite", async (req2, res2, idSocNum) => {
    let { Matricule, Typ_Visite, Statut, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée dans Matricule" });
    const du = toDate(Dat_Du) || new Date(1900, 0, 1);
    const au = toDate(Dat_Au) || new Date(2045, 11, 31);
    const rsl = await lireSql(
      `select TOP 50 Num_Visite 'N° visite', v.Matricule, r.Nom, Dat_Visite as 'Date visite',
         dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type',
         dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as 'Aptitude',
         Restrictions, Dat_Prochaine_Visite as 'Prochaine visite',
         dbo.FindRubrique('Statut_Signature',Statut) as Statut
       from RH_Sante_Visite v
       outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
       where v.id_Societe=@idSoc and v.Matricule like '%'+@Matricule
         and Dat_Visite between @du and @au
         and isnull(Typ_Visite,'') like @typ and isnull(Statut,'') like @statut
       order by [Date visite] desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "typ", sqlType: NVarChar, valeur: (Typ_Visite || "") + "%" },
        { param: "statut", sqlType: NVarChar, valeur: (Statut || "") + "%" },
        { param: "du", sqlType: SmallDateTime, valeur: du },
        { param: "au", sqlType: SmallDateTime, valeur: au },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Visite", succes: true, motif: "Liste (planning)" });
    res2.send(rsl);
  });
}

/* Fiche visite (CLINIQUE) ---------------------------------------------------- */
export async function get_sante_visite(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Visite", async (req2, res2, idSocNum) => {
    const { Num_Visite } = req.body;
    const rsl = await lireSql(
      `select * from RH_Sante_Visite where Num_Visite=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Visite || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Visite", valeurIndex: Num_Visite, matriculeConcerne: rsl?.data?.[0]?.Matricule, succes: true });
    res2.send(rsl);
  });
}

/* Enregistrement visite (CLINIQUE + verrou CNDP) ----------------------------- */
export async function save_sante_visite(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Visite", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Visite", succes: false, motif: "Verrou CNDP actif" });
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const { entete: _entete } = req.body;
    let { Num_Visite, ...entete } = _entete;
    const estCreation = !Num_Visite || Num_Visite === "";

    if (!entete.Matricule) return res2.send({ result: false, message: "Matricule non renseigné" });
    if (!entete.Dat_Visite || !toDate(entete.Dat_Visite)) return res2.send({ result: false, message: "Date de visite invalide" });

    if (!estCreation) {
      const ex = await lireSql(
        `select Statut from RH_Sante_Visite where Num_Visite=@num and id_Societe=@idSoc`,
        [
          { param: "num", sqlType: NVarChar, valeur: Num_Visite },
          { param: "idSoc", sqlType: Int, valeur: idSocNum },
        ]
      );
      if (ex.result && ex.data.length > 0 && ["VA", "SG"].includes(ex.data[0].Statut || "")) {
        return res2.send({ result: false, message: "Visite validée : toute correction doit passer par une visite de rectification" });
      }
    } else {
      if (entete.Num_Visite_Rectifiee && !entete.Motif_Rectification) {
        return res2.send({ result: false, message: "Le motif de rectification est obligatoire" });
      }
      Num_Visite = await nouveauNumero("VM", "RH_Sante_Visite", "Num_Visite", "Dat_Visite", idSocNum);
    }

    // Echeance : calcul automatique si absente ; ajustement manuel motive sinon
    if (entete.Statut === "VA" || entete.Statut === "SG") {
      const calc = await lireSql(
        `select Dat_Prochaine_Visite, Cod_Regle_Appliquee from dbo.Sys_Sante_Prochaine_Visite(@mat, @idSoc, @dat)`,
        [
          { param: "mat", sqlType: NVarChar, valeur: entete.Matricule },
          { param: "idSoc", sqlType: Int, valeur: idSocNum },
          { param: "dat", sqlType: SmallDateTime, valeur: toDate(entete.Dat_Visite) },
        ]
      );
      const calcDate = calc?.data?.[0]?.Dat_Prochaine_Visite || null;
      const saisie = toDate(entete.Dat_Prochaine_Visite);
      if (!saisie) {
        entete.Dat_Prochaine_Visite = calcDate;
        entete.Cod_Regle_Appliquee = calc?.data?.[0]?.Cod_Regle_Appliquee || "";
      } else if (calcDate && new Date(calcDate).getTime() !== saisie.getTime() && !entete.Motif_Ajustement) {
        return res2.send({ result: false, message: "L'ajustement de l'échéance calculée doit être justifié (motif)" });
      }
    }

    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Visite",
      fields: { ...entete, Num_Visite, id_Societe: idSocNum },
      joinFields: ["Num_Visite", "id_Societe"],
      excludeFields: ["Cod_Regle_Appliquee"],
      login: theAgent.Matricule || theAgent.Login,
    });
    if (!rsEnt.result) return res2.send(rsEnt);

    if (entete.Cod_Regle_Appliquee) {
      await lireSql(
        `update RH_Sante_Visite set Cod_Regle_Appliquee=@regle where Num_Visite=@num and id_Societe=@idSoc`,
        [
          { param: "regle", sqlType: NVarChar, valeur: entete.Cod_Regle_Appliquee },
          { param: "num", sqlType: NVarChar, valeur: Num_Visite },
          { param: "idSoc", sqlType: Int, valeur: idSocNum },
        ]
      );
    }
    if (entete.Statut === "VA" || entete.Statut === "SG") {
      await lireSql(`exec Sys_Sante_Maj_Dossier @mat, @idSoc`, [
        { param: "mat", sqlType: NVarChar, valeur: entete.Matricule },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]);
    }
    if (entete.Statut === "SS") {
      await sousmettre_signature("VM", Num_Visite, String(idSocNum), theAgent.Matricule);
    }
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Visite", valeurIndex: Num_Visite, matriculeConcerne: entete.Matricule, succes: true });
    res2.send(rsEnt);
  });
}

/* Suppression visite (CLINIQUE) ---------------------------------------------- */
export async function delete_sante_visite(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Visite", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Num_Visite } = req.body;
    const ex = await lireSql(
      `select Statut, Matricule from RH_Sante_Visite where Num_Visite=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Visite || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    if (ex.result && ex.data.length > 0 && ["VA", "SG"].includes(ex.data[0].Statut || "")) {
      return res2.send({ result: false, message: "Impossible de supprimer une visite validée" });
    }
    await lireSql(
      `insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
       values ('RH_Sante_Visite','Num_Visite',@num, @usr, convert(nvarchar(20),getdate(),120))`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Visite || "" },
        { param: "usr", sqlType: Int, valeur: Number(theAgent?.id_User || 0) },
      ]
    );
    const rsl = await lireSql(
      `delete from RH_Sante_Visite where Num_Visite=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Visite || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "SUPP", objet: "RH_Sante_Visite", valeurIndex: Num_Visite, matriculeConcerne: ex?.data?.[0]?.Matricule, succes: rsl.result });
    res2.send(rsl.result ? { result: true, data: Num_Visite } : { result: false, message: "Erreur suppression" });
  });
}

/* Calcul d'echeance (ADMIN) ---------------------------------------------------- */
export async function sante_calcul_echeance(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Visite", async (req2, res2, idSocNum) => {
    const { Matricule, Dat_Visite } = req.body;
    const rsl = await lireSql(
      `select Dat_Prochaine_Visite, Cod_Regle_Appliquee from dbo.Sys_Sante_Prochaine_Visite(@mat, @idSoc, @dat)`,
      [
        { param: "mat", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "dat", sqlType: SmallDateTime, valeur: toDate(Dat_Visite) || new Date() },
      ]
    );
    res2.send(rsl);
  });
}

/* Dossier sante complet (CLINIQUE) ---------------------------------------------- */
export async function sante_dossier(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Dossier", async (req2, res2, idSocNum) => {
    const { Matricule } = req.body;
    const rsl = await lireSql(
      `select * from RH_Sante_Dossier where Matricule=@mat and id_Societe=@idSoc`,
      [
        { param: "mat", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Dossier", valeurIndex: Matricule, matriculeConcerne: Matricule, succes: true });
    res2.send(rsl);
  });
}
