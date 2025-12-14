import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
export async function noteFraisListe(req: Request, res: Response) {
  let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
  const { processId, ...theAgent } = req.params;
  const TblRef = "RH_Note_Frais";
  let idSoc = theAgent?.id_Societe || "3068";
  let MatriculeWhere = "";
  if (theAgent.TeamLeader) {
    MatriculeWhere = `exists(select Matricule from Rh_Agent _agt where id_Societe=${theAgent.id_Societe} and _agt.Cod_Entite in (
        select  Cod_Entite from Sys_Org_Entite s where 
                    ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('${theAgent.Cod_Entite}',''),'8787uhuhunjj')+';%' and id_Societe=_agt.id_Societe))`;
  } else {
    MatriculeWhere = `(${TblRef}.id_Societe=${theAgent.id_Societe} and ${TblRef}.Matricule='${theAgent.Matricule}')`;
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
  let sqlStr = `SELECT  Num_NF as 'N° Note de frais', ${Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""
    } isnull(Lib_NF,'') as Libellé, dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_NF as 'Date', Mnt_NF as 'Montant' 
   ${Cod_Entite === theAgent.Cod_Entite
      ? ""
      : ", isnull(Lib_Entite,'') as 'Entité'"
    }
  FROM Rh_Note_Frais v
   outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
    outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
  where id_Societe='${idSoc}' and Matricule like '%'+@Matricule and Dat_NF between @Dat_Du and @Dat_Au and isnull(Statut,'') like '${Statut}%' Order by [Date] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "Statut", sqlType: NVarChar, valeur: Statut },
    { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
  ]);
  res.send(rsl);
}

export async function get_note_frais(req: Request, res: Response) {
  const { num_nf } = req.body;
  const { processId, ...theAgent } = req.params;
  let idSoc = theAgent.id_Societe || "3068";
  let sqlStr = `SELECT   *
  FROM Rh_Note_Frais where  Num_NF=@num_nf and id_Societe=${idSoc}`;
  const rsl = await lireSql(sqlStr, [
    { param: "num_nf", sqlType: NVarChar, valeur: num_nf },
  ]);
  if (rsl.result) {
    sqlStr = `select Typ_Frais, Base, Tx, Mnt, Comment, RowId
    from Rh_Note_Frais_Detail f 
    where Num_NF=@num_nf and id_Societe=${idSoc}`;
    const rslDetail = await lireSql(sqlStr, [
      { param: "num_nf", sqlType: NVarChar, valeur: num_nf },
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
  console.log("save_note_frais", _entete, detail);
  const { id_Societe, Matricule } = req.params;
  let { Num_NF, ...entete } = _entete;
  if (!Num_NF || Num_NF === "") {
    const rsNum = await lireSql(
      `select 'NF${id_Societe}-${new Date().getFullYear()}'+right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from Rh_Note_Frais 
    outer apply(select RIGHT(Num_NF,6) as racine)n
    where id_Societe=${id_Societe} and year(Dat_NF)=${new Date().getFullYear()})f`,
      []
    );
    Num_NF = rsNum?.data?.[0]?.racine;
  }
  const rsEnt = await ecrireSql({
    tableName: "RH_Note_Frais",
    fields: { ...entete, Num_NF, id_Societe },
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
        fields: { ...d, id_Societe, Num_NF, Flag_Maj: flgMaj },
        joinFields: ["Num_NF", "id_Societe", "RowId"],
        excludeFields: ["RowId"],
        login: Matricule,
      });
      if (!rsDet.result) {
        detailOk = false;
        detailError = rsDet.sort; // Capture error
        console.error("Detail Save Error:", rsDet);
        break;
      }
    }

    if (detailOk) {
      await lireSql(
        `delete from RH_Note_Frais_Detail where id_Societe=${id_Societe} and Num_NF='${Num_NF}' and Flag_Maj!=${flgMaj}`,
        []
      );
      if (entete.Statut === "SS")
        await sousmettre_signature("NF", Num_NF, id_Societe, Matricule);
      return res.send(rsEnt);
    } else {
      return res.send({ result: false, message: "Error saving details", error: detailError });
    }
  }
}
export async function delete_note_frais(req: Request, res: Response) {
  const { Num_NF } = req.body;
  const rsl = await lireSql(
    `delete from RH_Note_Frais where Num_NF=@Num_NF and id_Societe='${req.params.id_Societe}'`,
    [{ param: "Num_NF", sqlType: NVarChar, valeur: Num_NF }]
  );
  if (rsl.result) {
    return res.send({ result: true, data: Num_NF });
  } else return res.send({ result: false, data: rsl.sort });
}
