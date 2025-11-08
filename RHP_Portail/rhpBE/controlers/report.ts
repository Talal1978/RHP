import { Response, Request } from "express";
import { exec } from "node:child_process";
import path from "node:path";
import { Int, NVarChar } from "mssql";
import { lireSql } from "../modules/module_sqlRW";
import fs from "fs";
import { VGLOBALES } from "../modules/module_initialisation";
import { makeid } from "../modules/module_general";
let PATH_REPORT = "";
let ODBC_SERVEUR = "";
const getOdbcInfo = async () => {
  const sqlStr = `select * from (select Valeur as 'odbc' from Param_General where Cod_Param ='ODBC_RHP') o,
  (select Valeur as 'path' from Param_General where Cod_Param ='Lecteur_Digital_Mod_Edition')p`;
  try {
    const rsl = await lireSql(sqlStr, []);
    if (rsl.result) {
      PATH_REPORT = rsl.data[0].path;
      ODBC_SERVEUR = rsl.data[0].odbc;
      return { rsl: true, data: rsl.data };
    } else {
      return { rsl: false, data: rsl.data };
    }
  } catch (err) {
    return { rsl: true, data: err };
  }
};

export const getReportInfo = async (req: Request, res: Response) => {
  const { report } = req.body;

  let db = req.params.db || "";
  const sqlStr = `select critere,lib_critere, typ_critere,fonction_critere,case Default_Value
  when 'GV_DB' then DB_NAME() 
  when 'GV_DATDEBEXERCICE' then (select top 1 convert(nvarchar(10),Dat_Deb,103) from Compta_Exercice where isnull(Ouvert,'false')='true' order by Dat_Deb asc)
  when 'GV_DATFINEXERCICE' then (select top 1 convert(nvarchar(10),Dat_Fin,103) from Compta_Exercice where isnull(Ouvert,'false')='true' order by Dat_Deb Desc)
  when 'GV_DATSTOCKINITIAL' then (select top 1 convert(nvarchar(10),isnull(Dat_Stock_Initial,Dat_Deb),103) from Compta_Exercice where isnull(Ouvert,'false')='true' order by Dat_Deb Desc)
  when 'GV_NOW' then convert(nvarchar(10),getdate(),103)
  when 'GV_DEBMOIS' then convert(nvarchar(10),dateadd(day,-day(getdate())+1, getdate()),103)
  when 'GV_FINMOIS' then convert(nvarchar(10),dateadd(day,-day(getdate()), dateadd(month,1,getdate())),103)
  when 'GV_YEAR' then convert(nvarchar(4),year(getdate()) )
  when 'GV_MONTH' then convert(nvarchar(4),month(getdate()) )
  when 'GV_DAY' then  convert(nvarchar(4),day(getdate()) )
  when 'GV_DEBYEAR' then convert(nvarchar(10),dateadd(day,-DATEPART (DayOfYear, GETDATE())+1, getdate()),103)
  when 'GV_DAY' then (select Valeur from Param_General where Cod_Param='Valeur')
  else isnull(Default_Value,'')
  end as default_value,rang 
  from Param_Mod_Edition_Criteres
  where Cod_Report=@report
  order by Rang`;
  try {
    const rsl = await lireSql(sqlStr, [
      { param: "report", sqlType: NVarChar, valeur: report },
    ]);
    return res.send({ result: rsl.result, data: rsl.data });
  } catch (err) {
    return res.send({ result: false, data: err });
  }
};
export const getReportZoom = async (req: Request, res: Response) => {
  const { report, rang, criteres, valeurs } = req.body;

  const sqlStr = `select 'select '+Champs_01+' as code, '+Champs_02+' as description 
  from '+Table_Critere+ case when ltrim(rtrim(isnull(Condition,'')))='' then '' else '
  where '+ltrim(rtrim(isnull(Condition,''))) end as zoomSql
  from Param_Mod_Edition_Criteres 
  where Cod_Report=@report and rang=@rang and fonction_critere='Appel_Zoom'`;
  let sqlcri = await lireSql(sqlStr, [
    { param: "report", sqlType: NVarChar, valeur: report },
    { param: "rang", sqlType: Int, valeur: rang },
  ]);
  if (!sqlcri.result) {
    return res.send({ result: false, data: sqlcri.data });
  }
  let sqlZoom = sqlcri.data[0].zoomSql.replace(/&/gi, "");
  if (criteres.length > 0) {
    for (let i = 0; i < criteres.length; i++) {
      let rg = new RegExp(`\\B\\@${criteres[i]}\\b`, "gi");
      sqlZoom = sqlZoom.replace(rg, `${valeurs[i]}`);
    }
  }
  try {
    const rsl = await lireSql(sqlZoom, []);
    return res.send({ result: rsl.result, data: rsl.data });
  } catch (err) {
    return res.send({ result: false, data: err });
  }
};

export const generateReport = async (req: Request, res: Response) => {
  const { report, params: criteres } = req.body;
  criteres["idSoc"] = String(req.params.id_Societe || "-1");
  const params = criteres ? Object.keys(criteres) : [];
  const values = criteres ? Object.values(criteres) : [];
  const rpt = await lireSql(
    "select * from Param_Mod_Edition where Cod_Report=@Cod_Report",
    [{ param: "Cod_Report", sqlType: NVarChar, valeur: report }]
  );
  let withPwd = false;
  if (rpt.result) withPwd = rpt.data[0].withPassword;
  const rptPwd = Math.floor(Math.random() * 10000);
  const { SQL_USER, SQL_PASSWORD, SQL_DB } = VGLOBALES;
  await getOdbcInfo();
  const filename = `${report}_${makeid(6)}.pdf`;
  const fileFullName = path.resolve(process.cwd(), "tmp", filename);
  const crystalExe = path.resolve(process.cwd(), "tools/CRExport/crexport.exe");
  const cmdString: string = ` ${crystalExe} -r "${PATH_REPORT}/${report}.rpt" -u "${SQL_USER}" -pw "${SQL_PASSWORD}" -o "${ODBC_SERVEUR}" -db "${SQL_DB}"  -f "${fileFullName}" -p "${params}" -v "${values}" ${
    withPwd ? `-reportPwd ${rptPwd}` : ""
  }`;
  res.setHeader("Autres", withPwd ? rptPwd : "");
  res.setHeader("Access-Control-Expose-Headers", "Autres");
  exec(cmdString, (err) => {
    res.download(fileFullName, (err) => {
      if (err) {
        res.send(
          "module : report.ts : " + "\n" + err.message + "\n" + cmdString
        );
      } else {
        fs.unlink(fileFullName, (err0) => {
          if (err0) {
            console.error("suppression de fichier impossible:", err0.message);
          }
        });
      }
    });
  });
};
