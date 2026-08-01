import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
export async function noteFraisListe(req: Request, res: Response) {
  let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
  if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
  if (controleInjection(Cod_Entite).result === false) return res.send({ result: false, message: "Injection détectée dans Entité" });
  if (controleInjection(Statut).result === false) return res.send({ result: false, message: "Injection détectée dans Statut" });

  const { processId, ...theAgent } = req.params;
  let idSoc = Number(theAgent?.id_Societe || 0);
  if (isNaN(idSoc) || idSoc <= 0) return res.status(400).send({ result: false, message: "id_Societe invalide" });

  let isTeamLeader = String(theAgent.TeamLeader).toLowerCase() === "true";
  if (!isTeamLeader) {
    Matricule = theAgent.Matricule;
    Cod_Entite = theAgent.Cod_Entite;
  }
  Dat_Du = estDate(Dat_Du)
    ? toSqlDateFormat(Dat_Du)
    : toSqlDateFormat(new Date(1900, 0, 1));
  Dat_Au = estDate(Dat_Au)
    ? toSqlDateFormat(Dat_Au)
    : toSqlDateFormat(new Date(2045, 11, 31));
  Statut = Statut || "";
  let sqlStr = `SELECT TOP 50 Num_NF as 'N° Note de frais', ${Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""
    } isnull(Lib_NF,'') as Libellé, dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_NF as 'Date', Mnt_NF as 'Montant' 
   ${Cod_Entite === theAgent.Cod_Entite
      ? ""
      : ", isnull(Lib_Entite,'') as 'Entité'"
    }
  FROM Rh_Note_Frais v
   outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
    outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
  where id_Societe=@p_idSoc and Matricule like '%'+@Matricule and Dat_NF between @Dat_Du and @Dat_Au and isnull(Statut,'') like @StatutPrefix Order by [Date] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "p_idSoc", sqlType: Int, valeur: idSoc },
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "StatutPrefix", sqlType: NVarChar, valeur: Statut + "%" },
    { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
  ]);
  res.send(rsl);
}

export async function get_note_frais(req: Request, res: Response) {
  const { num_nf } = req.body;
  const { processId, ...theAgent } = req.params;
  let idSoc = Number(theAgent.id_Societe || 0);
  if (isNaN(idSoc) || idSoc <= 0) return res.status(400).send({ result: false, message: "id_Societe invalide" });
  let sqlStr = `SELECT   *
  FROM Rh_Note_Frais where  Num_NF=@num_nf and id_Societe=@p_idSoc`;
  const rsl = await lireSql(sqlStr, [
    { param: "num_nf", sqlType: NVarChar, valeur: num_nf },
    { param: "p_idSoc", sqlType: Int, valeur: idSoc },
  ]);
  if (rsl.result) {
    sqlStr = `select Typ_Frais, Base, Tx, Mnt, Comment, RowId
    from Rh_Note_Frais_Detail f 
    where Num_NF=@num_nf and id_Societe=@p_idSoc`;
    const rslDetail = await lireSql(sqlStr, [
      { param: "num_nf", sqlType: NVarChar, valeur: num_nf },
      { param: "p_idSoc", sqlType: Int, valeur: idSoc },
    ]);
    if (rslDetail.result) {
      res.send({ result: true, entete: rsl.data[0], detail: rslDetail.data });
      return;
    } else {
      res.send({ result: true, entete: rsl.data[0], detail: [] });
      return;
    }
  } else {
    res.send({ result: false, entete: {}, detail: [], message: rsl.sort });
    return;
  }
}
export async function save_note_frais(req: Request, res: Response) {
  const { entete: _entete, detail } = req.body;

  const { id_Societe, Matricule } = req.params;
  let idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) return res.status(400).send({ result: false, message: "id_Societe invalide" });

  let { Num_NF, ...entete } = _entete;
  if (!Num_NF || Num_NF === "") {
    const rsNum = await lireSql(
      `select 'NF'+convert(nvarchar(10),@p_idSoc)+'-'+convert(nvarchar(4),year(getdate()))+right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from Rh_Note_Frais 
    outer apply(select RIGHT(Num_NF,6) as racine)n
    where id_Societe=@p_idSoc and year(Dat_NF)=year(getdate()))f`,
      [{ param: "p_idSoc", sqlType: Int, valeur: idSocNum }]
    );
    Num_NF = rsNum?.data?.[0]?.racine;
  }
  const rsEnt = await ecrireSql({
    tableName: "RH_Note_Frais",
    fields: { ...entete, Num_NF, id_Societe: idSocNum },
    joinFields: ["Num_NF", "id_Societe"],
    excludeFields: [],
    login: Matricule,
  });
  if (rsEnt.result) {
    const flgMaj = Math.floor(Math.random() * 10000);
    let detailOk = true;
    let detailError: any = null;

    for (const d of detail) {
      const rsDet = await ecrireSql({
        tableName: "RH_Note_Frais_Detail",
        fields: { ...d, id_Societe: idSocNum, Num_NF, Flag_Maj: flgMaj },
        joinFields: ["Num_NF", "id_Societe", "RowId"],
        excludeFields: ["RowId"],
        login: Matricule,
      });
      if (!rsDet.result) {
        detailOk = false;
        detailError = rsDet.sort;
        console.error("Detail Save Error:", rsDet);
        break;
      }
    }

    if (detailOk) {
      await lireSql(
        `delete from RH_Note_Frais_Detail where id_Societe=@p_idSoc and Num_NF=@p_Num_NF and Flag_Maj!=@p_flgMaj`,
        [
          { param: "p_idSoc", sqlType: Int, valeur: idSocNum },
          { param: "p_Num_NF", sqlType: NVarChar, valeur: Num_NF },
          { param: "p_flgMaj", sqlType: Int, valeur: flgMaj },
        ]
      );
      if (entete.Statut === "SS")
        await sousmettre_signature("NF", Num_NF, id_Societe, Matricule);
      return res.send(rsEnt);
    } else {
      return res.send({ result: false, message: "Error saving details", error: detailError });
    }
  } else {
    return res.send(rsEnt);
  }
}
export async function delete_note_frais(req: Request, res: Response) {
  const { Num_NF } = req.body;
  const idSoc = Number(req.params.id_Societe);
  if (isNaN(idSoc) || idSoc <= 0) return res.status(400).send({ result: false, message: "id_Societe invalide" });
  const rsl = await lireSql(
    `delete from RH_Note_Frais where Num_NF=@Num_NF and id_Societe=@p_idSoc`,
    [
      { param: "Num_NF", sqlType: NVarChar, valeur: Num_NF },
      { param: "p_idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  if (rsl.result) {
    return res.send({ result: true, data: Num_NF });
  } else return res.send({ result: false, data: rsl.sort });
}
