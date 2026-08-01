/* Module Sante - Infirmerie (consultations/soins) et Vaccinations (CLINIQUE) */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import {
  getAgent, santeEndpoint, santeAudit, verrouCndpActif, nouveauNumero, toDate,
} from "../modules/module_sante";

export async function sante_consultation_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Consultation", async (req2, res2, idSocNum) => {
    let { Matricule, Typ_Acte, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée dans Matricule" });
    const du = toDate(Dat_Du) || new Date(1900, 0, 1);
    const au = toDate(Dat_Au) || new Date(2045, 11, 31);
    const rsl = await lireSql(
      `select TOP 50 Num_Consultation 'N°', c.Matricule, r.Nom, Dat_Consultation as 'Date',
         dbo.FindRubrique('Typ_Acte_Infirmier',Typ_Acte) as 'Acte',
         dbo.FindRubrique('Suite_Consultation',Suite) as 'Suite', Motif
       from RH_Sante_Consultation c
       outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=c.id_Societe and Matricule=c.Matricule) r
       where c.id_Societe=@idSoc and c.Matricule like '%'+@Matricule
         and Dat_Consultation between @du and @au and isnull(Typ_Acte,'') like @typ
       order by [Date] desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "typ", sqlType: NVarChar, valeur: (Typ_Acte || "") + "%" },
        { param: "du", sqlType: SmallDateTime, valeur: du },
        { param: "au", sqlType: SmallDateTime, valeur: au },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Consultation", succes: true });
    res2.send(rsl);
  });
}

export async function get_sante_consultation(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Consultation", async (req2, res2, idSocNum) => {
    const { Num_Consultation } = req.body;
    const rsl = await lireSql(
      `select * from RH_Sante_Consultation where Num_Consultation=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Consultation || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Consultation", valeurIndex: Num_Consultation, matriculeConcerne: rsl?.data?.[0]?.Matricule, succes: true });
    res2.send(rsl);
  });
}

export async function save_sante_consultation(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Consultation", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Consultation", succes: false, motif: "Verrou CNDP actif" });
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const { entete: _entete } = req.body;
    let { Num_Consultation, ...entete } = _entete;
    const estCreation = !Num_Consultation || Num_Consultation === "";
    if (!entete.Matricule) return res2.send({ result: false, message: "Matricule non renseigné" });
    if (estCreation) Num_Consultation = await nouveauNumero("CS", "RH_Sante_Consultation", "Num_Consultation", "Dat_Consultation", idSocNum);

    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Consultation",
      fields: { ...entete, Num_Consultation, id_Societe: idSocNum },
      joinFields: ["Num_Consultation", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Consultation", valeurIndex: Num_Consultation, matriculeConcerne: entete.Matricule, succes: rsEnt.result });
    res2.send(rsEnt);
  });
}

export async function delete_sante_consultation(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Consultation", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Num_Consultation } = req.body;
    await lireSql(
      `insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
       values ('RH_Sante_Consultation','Num_Consultation',@num, @usr, convert(nvarchar(20),getdate(),120))`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Consultation || "" },
        { param: "usr", sqlType: Int, valeur: Number(theAgent?.id_User || 0) },
      ]
    );
    const rsl = await lireSql(
      `delete from RH_Sante_Consultation where Num_Consultation=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Consultation || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "SUPP", objet: "RH_Sante_Consultation", valeurIndex: Num_Consultation, succes: rsl.result });
    res2.send(rsl.result ? { result: true, data: Num_Consultation } : { result: false, message: "Erreur suppression" });
  });
}

/* Vaccinations (option activable) ---------------------------------------------- */
export async function sante_vaccination_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Vaccination", async (req2, res2, idSocNum) => {
    const actif = await lireSql(`select dbo.Sys_Sante_Param('ACTIVER_VACCINATIONS', @idSoc) as v`, [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
    ]);
    if (actif?.data?.[0]?.v !== "O") return res2.send({ result: false, message: "Le suivi des vaccinations n'est pas activé" });
    const { Matricule } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée dans Matricule" });
    const rsl = await lireSql(
      `select TOP 50 RowId, v.Matricule, r.Nom, dbo.FindRubrique('Typ_Vaccin',Typ_Vaccin) as 'Vaccin',
         Dat_Vaccination as 'Date', Dat_Rappel as 'Rappel'
       from RH_Sante_Vaccination v
       outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
       where v.id_Societe=@idSoc and v.Matricule like '%'+@Matricule
       order by [Date] desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Vaccination", succes: true });
    res2.send(rsl);
  });
}

export async function save_sante_vaccination(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Vaccination", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const actif = await lireSql(`select dbo.Sys_Sante_Param('ACTIVER_VACCINATIONS', @idSoc) as v`, [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
    ]);
    if (actif?.data?.[0]?.v !== "O") return res2.send({ result: false, message: "Le suivi des vaccinations n'est pas activé" });
    const { entete } = req.body;
    if (!entete.Matricule) return res2.send({ result: false, message: "Matricule non renseigné" });
    const estCreation = !entete.RowId;
    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Vaccination",
      fields: { ...entete, id_Societe: idSocNum },
      joinFields: estCreation ? ["Matricule", "id_Societe", "Typ_Vaccin", "Dat_Vaccination"] : ["RowId"],
      excludeFields: ["RowId"],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Vaccination", valeurIndex: String(entete.RowId || ""), matriculeConcerne: entete.Matricule, succes: rsEnt.result });
    res2.send(rsEnt);
  });
}
