import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

export const getOrganigramme = async (req: Request, res: Response) => {
    try {
        const { cod_entite } = req.body;
        const id_Societe = req.params.id_Societe || 1;
        const entity = cod_entite || "";
        const query = `select o.*, 
            a.Matricule as Resp_Matricule,
            ltrim(rtrim(isnull(a.Nom_Agent,'') + ' ' + isnull(a.Prenom_Agent,''))) as Resp_Nom,
            a.Titre as Resp_Titre,
            a.Photo as Resp_Photo
         from dbo.Sys_Organigramme(@idSociete, @cod_entite) o
         left join dbo.RH_Agent a on o.Responsable = a.Matricule and a.id_Societe = @idSociete`;
        const result = await lireSql(query, [{ param: "idSociete", sqlType: Int, valeur: id_Societe }, { param: "cod_entite", sqlType: NVarChar, valeur: entity }]);

        console.log("getOrganigramme result:", result.result, result.sort);

        if (result.result && result.data) {
            result.data.forEach((row: any) => {
                if (row.Resp_Photo) {
                    row.Resp_Photo = `data:image/jpeg;base64,${Buffer.from(row.Resp_Photo).toString('base64')}`;
                }
            });
        }

        res.json(result);
    } catch (error: any) {
        res.json({ result: false, sort: error.message, data: [], fields: [] });
    }
};

export const getPoste = async (req: Request, res: Response) => {
    try {
        const { cod_poste } = req.body;
        const id_Societe = req.params.id_Societe || 1;
        const query = `SELECT Cod_Poste, Lib_Poste, Cod_Grade, Soft_Skills, Domaines_Competence, 
                            Background_Academique, nb_Annees_Experience, Mission, TachesAttributions,Responsabilites,
                            Dependance_Hierarchique, Dependance_fonctionnelle
                        FROM Org_Poste
                        where Cod_Poste=@cod_poste and id_Societe=@idSociete`;
        console.log(cod_poste, query);
        const result = await lireSql(query, [
            { param: "idSociete", sqlType: Int, valeur: id_Societe },
            { param: "cod_poste", sqlType: NVarChar, valeur: cod_poste }
        ]);
        res.json(result);
    } catch (error: any) {
        res.json({ result: false, sort: error.message, data: [], fields: [] });
    }
};
