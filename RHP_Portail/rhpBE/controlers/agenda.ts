import { Request, Response } from "express";
import { IsNull } from "../modules/module_general";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

export const get_agenda = async (req: Request, res: Response) => {
  const { Matricule } = req.body;
  let idSoc = IsNull(req.params?.id_Societe, "3068");
  
  const rsl = await lireSql(
    `exec Sys_Agenda @Matricule, @idSoc`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );

  return res.send(rsl);
};
