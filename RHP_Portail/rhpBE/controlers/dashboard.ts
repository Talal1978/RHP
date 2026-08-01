import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar, DateTime } from "mssql";

export const getDashboardData = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    const Matricule = theAgent?.Matricule || "";
    const id_Societe = Number(theAgent?.id_Societe || 0);
    if (isNaN(id_Societe) || id_Societe <= 0) {
        return res.status(400).send({ result: false, message: "id_Societe invalide" });
    }

    try {
        const sqlSignatures = `select top 5 Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature(@Matricule, @id_Societe)`;
        const sqlInsights = `select * from Sys_Portail_DashBoard_Insights(@Matricule, @id_Societe,5) order by Dat_Du asc`;
        const sqlBlogs = `select top 6 Num_Blog, Titre_Blog, Categorie, Tags, Contenus, Dat_Crea from Communication_Blogs where id_Societe=@id_Societe and Publier=1 order by Dat_Crea desc`;

        const now = new Date();
        const sqlSolde = `select Solde_Conge from dbo.Sys_Rh_Conge(@id_Societe,@todayStr) where Matricule=@Matricule`;

        const [signaturesResult, insightsResult, blogsResult, soldeResult] = await Promise.all([
            lireSql(sqlSignatures, [
                { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            ]),
            lireSql(sqlInsights, [
                { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            ]),
            lireSql(sqlBlogs, [
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            ]),
            lireSql(sqlSolde, [
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
                { param: "todayStr", sqlType: DateTime, valeur: now },
                { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
            ]),
        ]);

        const soldeVal = (soldeResult.data && soldeResult.data.length > 0) ? soldeResult.data[0].Solde_Conge : 0;

        res.send({
            result: true,
            data: {
                signatures: signaturesResult.data || [],
                insights: insightsResult.data || [],
                blogs: blogsResult.data || [],
                solde: soldeVal
            }
        });

    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

export const get_signatures_api = async (req: Request, res: Response) => {
    const { processId, ...context } = req.params;
    const Matricule = context?.Matricule || req.body?.Matricule || "";
    const id_Societe = Number(context?.id_Societe || req.body?.id_Societe || 0);
    if (isNaN(id_Societe) || id_Societe <= 0) {
        return res.status(400).send({ result: false, message: "id_Societe invalide" });
    }

    try {
        const sqlSignatures = `select Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature(@Matricule, @id_Societe)`;
        const rsl = await lireSql(sqlSignatures, [
            { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
            { param: "id_Societe", sqlType: Int, valeur: id_Societe },
        ]);
        res.send(rsl);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
