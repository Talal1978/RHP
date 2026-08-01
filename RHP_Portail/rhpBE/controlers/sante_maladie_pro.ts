/* Module Sante - Maladies professionnelles (clinique CLINIQUE ; statut administratif ADMIN) */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import {
  getAgent, santeEndpoint, santeAudit, verrouCndpActif, nouveauNumero, toDate,
} from "../modules/module_sante";

export async function sante_maladie_pro_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Maladie_Pro", async (req2, res2, idSocNum) => {
    let { Matricule, Statut_Declaration, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée dans Matricule" });
    const du = toDate(Dat_Du) || new Date(1900, 0, 1);
    const au = toDate(Dat_Au) || new Date(2045, 11, 31);
    const rsl = await lireSql(
      `select TOP 50 Num_MP 'N° MP', m.Matricule, r.Nom, Dat_Declaration as 'Déclarée le',
         Pathologie, dbo.FindRubrique('Statut_Declaration_MP',Statut_Declaration) as 'Statut'
       from RH_Sante_Maladie_Pro m
       outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=m.id_Societe and Matricule=m.Matricule) r
       where m.id_Societe=@idSoc and m.Matricule like '%'+@Matricule
         and Dat_Declaration between @du and @au and isnull(Statut_Declaration,'') like @st
       order by [Déclarée le] desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "st", sqlType: NVarChar, valeur: (Statut_Declaration || "") + "%" },
        { param: "du", sqlType: SmallDateTime, valeur: du },
        { param: "au", sqlType: SmallDateTime, valeur: au },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Maladie_Pro", succes: true });
    res2.send(rsl);
  });
}

export async function get_sante_maladie_pro(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Maladie_Pro", async (req2, res2, idSocNum) => {
    const { Num_MP } = req.body;
    const rsl = await lireSql(
      `select * from RH_Sante_Maladie_Pro where Num_MP=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_MP || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Maladie_Pro", valeurIndex: Num_MP, matriculeConcerne: rsl?.data?.[0]?.Matricule, succes: true });
    res2.send(rsl);
  });
}

export async function save_sante_maladie_pro(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Maladie_Pro", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Maladie_Pro", succes: false, motif: "Verrou CNDP actif" });
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const { entete: _entete } = req.body;
    let { Num_MP, ...entete } = _entete;
    const estCreation = !Num_MP || Num_MP === "";
    if (!entete.Matricule) return res2.send({ result: false, message: "Matricule non renseigné" });
    if (estCreation) Num_MP = await nouveauNumero("MP", "RH_Sante_Maladie_Pro", "Num_MP", "Dat_Declaration", idSocNum);

    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Maladie_Pro",
      fields: { ...entete, Num_MP, id_Societe: idSocNum },
      joinFields: ["Num_MP", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Maladie_Pro", valeurIndex: Num_MP, matriculeConcerne: entete.Matricule, succes: rsEnt.result });
    res2.send(rsEnt);
  });
}

export async function delete_sante_maladie_pro(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Maladie_Pro", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Num_MP } = req.body;
    await lireSql(
      `insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
       values ('RH_Sante_Maladie_Pro','Num_MP',@num, @usr, convert(nvarchar(20),getdate(),120))`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_MP || "" },
        { param: "usr", sqlType: Int, valeur: Number(theAgent?.id_User || 0) },
      ]
    );
    const rsl = await lireSql(
      `delete from RH_Sante_Maladie_Pro where Num_MP=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_MP || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "SUPP", objet: "RH_Sante_Maladie_Pro", valeurIndex: Num_MP, succes: rsl.result });
    res2.send(rsl.result ? { result: true, data: Num_MP } : { result: false, message: "Erreur suppression" });
  });
}

/* Statut administratif (ADMIN : RH/HSE) : ne touche que le statut de declaration,
   jamais le contenu clinique. */
export async function save_sante_maladie_pro_statut(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Maladie_Pro", async (req2, res2, idSocNum) => {
    const { Num_MP, Statut_Declaration, Num_Dossier_Org } = req.body;
    if (!Num_MP || !Statut_Declaration) return res2.send({ result: false, message: "Paramètres incomplets" });
    if (controleInjection(Statut_Declaration).result === false) return res2.send({ result: false, message: "Injection détectée" });
    const rsl = await lireSql(
      `update RH_Sante_Maladie_Pro set Statut_Declaration=@st, Num_Dossier_Org=isnull(@doss, Num_Dossier_Org),
         Dat_Modif=getdate(), Modified_By=@usr
       where Num_MP=@num and id_Societe=@idSoc
       select * from RH_Sante_Maladie_Pro where Num_MP=@num and id_Societe=@idSoc`,
      [
        { param: "st", sqlType: NVarChar, valeur: Statut_Declaration },
        { param: "doss", sqlType: NVarChar, valeur: Num_Dossier_Org || null },
        { param: "usr", sqlType: NVarChar, valeur: req.params.Matricule || req.params.Login },
        { param: "num", sqlType: NVarChar, valeur: Num_MP },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "MODI", objet: "RH_Sante_Maladie_Pro", valeurIndex: Num_MP, succes: rsl.result, motif: "Statut administratif" });
    res2.send(rsl);
  });
}
