import { Request, Response } from "express";
import { Int, NVarChar } from "mssql";
import { lireSql } from "../modules/module_sqlRW";
export async function ficheposte(req: Request, res: Response) {
  const { id_Societe, Matricule } = req.params;
  const rsl = await lireSql(
    `select isnull(JobDescription,'') as JobDescription,isnull(Domaines_Competence,'') Domaines_Competence 
from Org_Poste o where exists(select 1 from RH_Agent where id_Societe=@idSoc and Matricule=@Matricule and Cod_Poste=o.Cod_Poste)`,
    [
      { param: "idSoc", sqlType: Int, valeur: id_Societe },
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    ]
  );
  res.send(rsl);
}
