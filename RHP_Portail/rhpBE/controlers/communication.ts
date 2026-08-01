import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar, Int } from "mssql";

export const get_communication_blogs_liste = async (req: Request, res: Response) => {
    const { id_Societe } = req.params;
    const idSocNum = Number(id_Societe);
    if (isNaN(idSocNum) || idSocNum <= 0) {
        res.send({ result: false, message: "id_Societe invalide" });
        return;
    }

    // Query provided by user
    const codSql = `SELECT Num_Blog, id_Societe, Titre_Blog, Categorie, Tags, Publier, Contenus, Created_by, Dat_Crea, Modified_by, Dat_Modif 
                    FROM Communication_Blogs 
                    WHERE id_Societe = @p_id_Societe 
                    ORDER BY Dat_Crea DESC`;
    const params = [{ param: "p_id_Societe", sqlType: Int, valeur: idSocNum }];

    try {
        const result = await lireSql(codSql, params);
        res.send(result);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

export const get_communication_blog = async (req: Request, res: Response) => {
    const { Num_Blog } = req.body;
    const { id_Societe } = req.params;
    const idSocNum = Number(id_Societe);
    if (isNaN(idSocNum) || idSocNum <= 0) {
        res.send({ result: false, message: "id_Societe invalide" });
        return;
    }

    const codSql = `SELECT * FROM Communication_Blogs WHERE Num_Blog = @p_Num_Blog AND id_Societe = @p_id_Societe`;
    const params = [
        { param: "p_Num_Blog", sqlType: NVarChar, valeur: Num_Blog },
        { param: "p_id_Societe", sqlType: Int, valeur: idSocNum }
    ];

    try {
        const result = await lireSql(codSql, params);
        res.send(result);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
