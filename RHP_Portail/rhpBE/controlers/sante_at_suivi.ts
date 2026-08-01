/* Module Sante - Suivi reglementaire des accidents du travail (AT_ADMIN)
   Satellites de l'existant : distinction, echeancier, transmissions, statistiques. */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import {
  getAgent, santeEndpoint, santeAudit, toDate,
} from "../modules/module_sante";

/* Suivi complet d'une declaration : entete (avec Typ_Accident) + echeances + transmissions */
export async function sante_at_suivi_get(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Declaration_AT_Suivi", async (req2, res2, idSocNum) => {
    const { Num_Declaration } = req.body;
    const entete = await lireSql(
      `select Num_Declaration, Matricule, Dat_Accident, Heure_Accident, Lieu_Accident,
              isnull(Typ_Accident,'TRAVAIL') as Typ_Accident, Statut, Cloture
       from RH_Declaration_AT where Num_Declaration=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Declaration || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    const echeances = await lireSql(
      `select RowId, Cod_Etape, Dat_Debut, Delai_Jours, Dat_Echeance, Statut_Etape, Dat_Realisation, FD_Preuve, Commentaire,
              case when isnull(Statut_Etape,'AFA') in ('AFA','ENC') and Dat_Echeance < getdate() then 'true' else 'false' end as En_Retard
       from RH_Declaration_AT_Echeance where Num_Declaration=@num and id_Societe=@idSoc order by Dat_Echeance`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Declaration || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    const transmissions = await lireSql(
      `select RowId, Cod_Destinataire, Dat_Transmission, Mode_Transmission, Reference, FD_Preuve, Commentaire
       from RH_Declaration_AT_Transmission where Num_Declaration=@num and id_Societe=@idSoc order by Dat_Transmission`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Declaration || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Declaration_AT_Suivi", valeurIndex: Num_Declaration, succes: true });
    res2.send({
      result: entete.result,
      entete: entete.data?.[0] || null,
      echeances: echeances.data || [],
      transmissions: transmissions.data || [],
    });
  });
}

/* Mise a jour de la distinction travail / trajet / non reconnu */
export async function save_sante_at_typ(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Declaration_AT_Suivi", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Num_Declaration, Typ_Accident } = req.body;
    if (!Num_Declaration || !Typ_Accident) return res2.send({ result: false, message: "Paramètres incomplets" });
    if (controleInjection(Typ_Accident).result === false) return res2.send({ result: false, message: "Injection détectée" });
    const rsl = await lireSql(
      `update RH_Declaration_AT set Typ_Accident=@typ, Dat_Modif=getdate(), Modified_By=@usr
       where Num_Declaration=@num and id_Societe=@idSoc`,
      [
        { param: "typ", sqlType: NVarChar, valeur: Typ_Accident },
        { param: "usr", sqlType: NVarChar, valeur: theAgent.Matricule || theAgent.Login },
        { param: "num", sqlType: NVarChar, valeur: Num_Declaration },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "MODI", objet: "RH_Declaration_AT", valeurIndex: Num_Declaration, succes: rsl.result, motif: "Typ_Accident=" + Typ_Accident });
    res2.send(rsl.result ? { result: true, data: Num_Declaration } : { result: false, message: "Erreur mise à jour" });
  });
}

/* Generation de l'echeancier reglementaire */
export async function sante_at_generer_echeances(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Declaration_AT_Echeance", async (req2, res2, idSocNum) => {
    const { Num_Declaration } = req.body;
    await lireSql(`exec Sys_Sante_AT_Generer_Echeances @num, @idSoc`, [
      { param: "num", sqlType: NVarChar, valeur: Num_Declaration || "" },
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
    ]);
    const rsl = await lireSql(
      `select RowId, Cod_Etape, Dat_Echeance, Statut_Etape from RH_Declaration_AT_Echeance
       where Num_Declaration=@num and id_Societe=@idSoc order by Dat_Echeance`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Declaration || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "CREA", objet: "RH_Declaration_AT_Echeance", valeurIndex: Num_Declaration, succes: true, motif: "Génération échéancier" });
    res2.send(rsl);
  });
}

export async function save_sante_at_echeance(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Declaration_AT_Echeance", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { entete } = req.body;
    if (!entete.RowId) return res2.send({ result: false, message: "Échéance non identifiée" });
    // Annulation : motif obligatoire
    if (entete.Statut_Etape === "ANN" && !entete.Commentaire) {
      return res2.send({ result: false, message: "L'annulation d'une étape doit être motivée" });
    }
    const rsEnt = await ecrireSql({
      tableName: "RH_Declaration_AT_Echeance",
      fields: { ...entete, id_Societe: idSocNum },
      joinFields: ["RowId"],
      excludeFields: ["RowId"],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: "MODI", objet: "RH_Declaration_AT_Echeance", valeurIndex: String(entete.RowId), succes: rsEnt.result });
    res2.send(rsEnt);
  });
}

export async function save_sante_at_transmission(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Declaration_AT_Transmission", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { entete } = req.body;
    if (!entete.Num_Declaration) return res2.send({ result: false, message: "Déclaration non identifiée" });
    const estCreation = !entete.RowId;
    const rsEnt = await ecrireSql({
      tableName: "RH_Declaration_AT_Transmission",
      fields: { ...entete, id_Societe: idSocNum },
      joinFields: estCreation ? ["Num_Declaration", "id_Societe", "Cod_Destinataire", "Dat_Transmission"] : ["RowId"],
      excludeFields: ["RowId"],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Declaration_AT_Transmission", valeurIndex: String(entete.RowId || ""), succes: rsEnt.result });
    res2.send(rsEnt);
  });
}

/* Statistiques AT (TF/TG mensuels) */
export async function sante_at_stats(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Stats_AT", async (req2, res2, idSocNum) => {
    const { Annee } = req.body;
    const an = Number(Annee || 0);
    const rsl = await lireSql(
      `select Annee, Mois, Nb_Accidents, Nb_Travail, Nb_Trajet, Nb_Avec_Arret, Jours_Arret,
              Heures_Travaillees, Taux_Frequence, Taux_Gravite
       from RH_Sante_Vue_Stats_AT
       where id_Societe=@idSoc ${an > 0 ? "and Annee=@an" : ""}
       order by Annee desc, Mois`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        ...(an > 0 ? [{ param: "an", sqlType: Int, valeur: an }] : []),
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Stats_AT", succes: true });
    res2.send(rsl);
  });
}
