
import { Request, Response } from "express";
import {
    estDate,
    toSqlDateFormat,
} from "../modules/module_format";
import { lireSql, controleInjection } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime } from "mssql";

export async function discipline_liste(req: Request, res: Response) {
    let { Matricule, Typ_Sanction, Dat_Du, Dat_Au } = req.body;

    if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
    if (controleInjection(Typ_Sanction).result === false) return res.send({ result: false, message: "Injection détectée dans Type Sanction" });

    const { processId, ...theAgent } = req.params;
    const TblRef = "RH_Discipline";
    let idSoc = theAgent?.id_Societe || "3068";

    if (theAgent.TeamLeader) {
        // Access control logic for team leaders if needed, for now standard access
    }

    Dat_Du = estDate(Dat_Du)
        ? toSqlDateFormat(Dat_Du)
        : toSqlDateFormat(new Date(1900, 0, 1));
    Dat_Au = estDate(Dat_Au)
        ? toSqlDateFormat(Dat_Au)
        : toSqlDateFormat(new Date(2045, 11, 31));
    Typ_Sanction = Typ_Sanction || "";
    Matricule = Matricule || "";

    let sqlStr = `SELECT Cod_Sanction as Code, Lib_Sanction as Intitulé, d.Matricule, a.Nom_Agent + ' ' + a.Prenom_Agent as Nom, d.Dat_Faute as 'Date faute', d.Dat_Decision as 'Date décision', dbo.FindRubrique('Sanctions',d.Typ_Sanction) as Type, d.Motif 
    FROM RH_Discipline d 
    LEFT JOIN RH_Agent a ON d.Matricule = a.Matricule AND d.id_Societe = a.id_Societe 
    WHERE d.id_Societe='${idSoc}'
    AND d.Matricule LIKE '%'+@Matricule
    AND d.Dat_Faute BETWEEN @Dat_Du AND @Dat_Au
    AND d.Typ_Sanction LIKE '${Typ_Sanction}%'
    ORDER BY d.Dat_Faute DESC`;

    const rsl = await lireSql(sqlStr, [
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
        { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
        { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ]);
    res.send(rsl);
}

export async function get_discipline(req: Request, res: Response) {
    const { Cod_Sanction } = req.body;
    const { processId, ...theAgent } = req.params;
    let idSoc = theAgent.id_Societe || "3068";

    let sqlStr = `SELECT * FROM RH_Discipline where Cod_Sanction=@Cod_Sanction and id_Societe=${idSoc}`;
    const rsl = await lireSql(sqlStr, [
        {
            param: "Cod_Sanction",
            sqlType: NVarChar,
            valeur: Cod_Sanction,
        },
    ]);
    return res.send(rsl);
}
