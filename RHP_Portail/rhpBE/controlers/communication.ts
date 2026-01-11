import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar } from "mssql";

export const get_communication_blogs_liste = async (req: Request, res: Response) => {
    const { id_Societe } = req.params;

    // Query provided by user
    const codSql = `SELECT Num_Blog, id_Societe, Titre_Blog, Categorie, Tags, Publier, Contenus, Created_by, Dat_Crea, Modified_by, Dat_Modif 
                    FROM Communication_Blogs 
                    WHERE id_Societe = ${id_Societe} 
                    ORDER BY Dat_Crea DESC`;

    try {
        const result = await lireSql(codSql);
        res.send(result);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

export const get_communication_blog = async (req: Request, res: Response) => {
    const { Num_Blog } = req.body;
    const { id_Societe } = req.params;

    const codSql = `SELECT * FROM Communication_Blogs WHERE Num_Blog = @Num_Blog AND id_Societe = ${id_Societe}`;
    const params = [{ param: "Num_Blog", sqlType: NVarChar, valeur: Num_Blog }];

    try {
        const result = await lireSql(codSql, params);
        res.send(result);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
