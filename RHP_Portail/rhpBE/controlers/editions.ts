import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";

export const get_diverse_editions = async (req: Request, res: Response) => {
    const sqlStr = "select Cod_Report, Nom_Report from Param_Mod_Edition where isnull(Portail,'false')='true' order by Nom_Report";
    try {
        const rsl = await lireSql(sqlStr, []);
        return res.send({ result: rsl.result, data: rsl.data });
    } catch (err) {
        return res.send({ result: false, data: err });
    }
};
