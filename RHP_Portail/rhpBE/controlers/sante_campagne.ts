/* Module Sante - Campagnes de visites et convocations (ADMIN) */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import {
  getAgent, santeEndpoint, santeAudit, toDate,
} from "../modules/module_sante";

export async function sante_campagne_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Campagne", async (req2, res2, idSocNum) => {
    const rsl = await lireSql(
      `select TOP 50 Cod_Campagne 'Code', Lib_Campagne as 'Campagne',
         dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type de visite',
         Dat_Deb as 'Du', Dat_Fin as 'Au', dbo.FindRubrique('Statut_Campagne',Statut) as 'Statut',
         (select count(*) from RH_Sante_Convocation c where c.Cod_Campagne=p.Cod_Campagne and c.id_Societe=p.id_Societe) as 'Convocations'
       from RH_Sante_Campagne p where id_Societe=@idSoc order by [Du] desc`,
      [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
    );
    res2.send(rsl);
  });
}

export async function get_sante_campagne(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Campagne", async (req2, res2, idSocNum) => {
    const { Cod_Campagne } = req.body;
    const entete = await lireSql(
      `select * from RH_Sante_Campagne where Cod_Campagne=@cod and id_Societe=@idSoc`,
      [
        { param: "cod", sqlType: NVarChar, valeur: Cod_Campagne || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    const detail = await lireSql(
      `select RowId, Matricule, Dat_Convocation, Heure, Statut_Convocation, Dat_Envoi, Num_Visite, Commentaire
       from RH_Sante_Convocation where Cod_Campagne=@cod and id_Societe=@idSoc order by Dat_Convocation`,
      [
        { param: "cod", sqlType: NVarChar, valeur: Cod_Campagne || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    res2.send({ result: entete.result, entete: entete.data?.[0] || null, detail: detail.data || [] });
  });
}

export async function save_sante_campagne(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Campagne", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { entete: _entete } = req.body;
    let { Cod_Campagne, ...entete } = _entete;
    const estCreation = !Cod_Campagne || Cod_Campagne === "";
    if (!entete.Lib_Campagne) return res2.send({ result: false, message: "Libellé campagne non renseigné" });
    if (estCreation) {
      if (controleInjection(Cod_Campagne).result === false) return res2.send({ result: false, message: "Injection détectée" });
      const rsl = await lireSql(
        `select 'CP'+convert(nvarchar(10),@idSoc)+'-'+right('000'+convert(nvarchar(3),isnull(max(racine),0)+1),3) as num
         from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end) as racine
               from RH_Sante_Campagne outer apply(select RIGHT(Cod_Campagne,3) as racine)n where id_Societe=@idSoc)f`,
        [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
      );
      Cod_Campagne = rsl?.data?.[0]?.num || "";
    }
    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Campagne",
      fields: { ...entete, Cod_Campagne, id_Societe: idSocNum },
      joinFields: ["Cod_Campagne", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Campagne", valeurIndex: Cod_Campagne, succes: rsEnt.result });
    res2.send(rsEnt);
  });
}

export async function delete_sante_campagne(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Campagne", async (req2, res2, idSocNum) => {
    const { Cod_Campagne } = req.body;
    const rsl = await lireSql(
      `delete from RH_Sante_Convocation where Cod_Campagne=@cod and id_Societe=@idSoc and isnull(Num_Visite,'')='';
       delete from RH_Sante_Campagne where Cod_Campagne=@cod and id_Societe=@idSoc;`,
      [
        { param: "cod", sqlType: NVarChar, valeur: Cod_Campagne || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "SUPP", objet: "RH_Sante_Campagne", valeurIndex: Cod_Campagne, succes: rsl.result });
    res2.send(rsl.result ? { result: true, data: Cod_Campagne } : { result: false, message: "Erreur suppression" });
  });
}

/* Generation des convocations : agents dont l'echeance tombe dans la campagne
   (ou sans aucune visite) et pas deja convoques. */
export async function sante_convocation_generer(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Convocation", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Cod_Campagne, Dat_Convocation, Heure } = req.body;
    if (!Cod_Campagne) return res2.send({ result: false, message: "Campagne non renseignée" });
    const camp = await lireSql(
      `select * from RH_Sante_Campagne where Cod_Campagne=@cod and id_Societe=@idSoc`,
      [
        { param: "cod", sqlType: NVarChar, valeur: Cod_Campagne },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    if (!camp.result || camp.data.length === 0) return res2.send({ result: false, message: "Campagne introuvable" });
    const datFin = camp.data[0].Dat_Fin || new Date(2045, 11, 31);

    const rsl = await lireSql(
      `insert into RH_Sante_Convocation (Cod_Campagne, id_Societe, Matricule, Dat_Convocation, Heure, Statut_Convocation, Dat_Crea, Created_By)
       select @cod, @idSoc, d.Matricule, @dat, @heure, 'PRE', getdate(), @usr
       from RH_Sante_Dossier d
       where d.id_Societe=@idSoc and isnull(d.Archive,'false')='false'
         and (d.Dat_Prochaine_Visite is null or d.Dat_Prochaine_Visite <= @datFin)
         and not exists (select 1 from RH_Sante_Convocation c where c.Cod_Campagne=@cod and c.id_Societe=@idSoc and c.Matricule=d.Matricule)
       select @@ROWCOUNT as nb`,
      [
        { param: "cod", sqlType: NVarChar, valeur: Cod_Campagne },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "dat", sqlType: SmallDateTime, valeur: toDate(Dat_Convocation) || new Date() },
        { param: "heure", sqlType: NVarChar, valeur: Heure || "" },
        { param: "usr", sqlType: NVarChar, valeur: theAgent.Matricule || theAgent.Login },
        { param: "datFin", sqlType: SmallDateTime, valeur: datFin },
      ]
    );
    const nb = rsl?.data?.[0]?.nb ?? 0;
    await santeAudit({ req, action: "CREA", objet: "RH_Sante_Convocation", valeurIndex: Cod_Campagne, succes: true, motif: nb + " convocation(s) générée(s)" });
    res2.send({ result: true, data: [{ generees: nb }] });
  });
}

export async function save_sante_convocation(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Convocation", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { entete } = req.body;
    if (!entete.RowId) return res2.send({ result: false, message: "Convocation non identifiée" });
    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Convocation",
      fields: { ...entete, id_Societe: idSocNum },
      joinFields: ["RowId"],
      excludeFields: ["RowId"],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: "MODI", objet: "RH_Sante_Convocation", valeurIndex: String(entete.RowId), matriculeConcerne: entete.Matricule, succes: rsEnt.result });
    res2.send(rsEnt);
  });
}
