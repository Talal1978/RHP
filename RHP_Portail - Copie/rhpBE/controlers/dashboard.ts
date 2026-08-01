import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

export const getDashboardData = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    const Matricule = theAgent?.Matricule || "";
    const id_Societe = theAgent?.id_Societe || "0000";

    try {
        // 1. Signatures (Portefeuille)
        // Using the function Sys_Parapheur_Signature as seen in index.ts
        const sqlSignatures = `select top 5 Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature('${Matricule}', '${id_Societe}')`;
        const signaturesResult = await lireSql(sqlSignatures);

        // 2. Portail Insights (Formations, Evaluations, Recrutement)
        const sqlInsights = `select * from Sys_Portail_DashBoard_Insights(@Matricule, @id_Societe,5) order by Dat_Du asc`;
        const insightsParams = [
            { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
            { param: "id_Societe", sqlType: Int, valeur: id_Societe }
        ];
        const insightsResult = await lireSql(sqlInsights, insightsParams);

        // 3. Blogs (Actualités)
        const sqlBlogs = `select top 6 Num_Blog, Titre_Blog, Categorie, Tags, Contenus, Dat_Crea from Communication_Blogs where id_Societe=${id_Societe} and Publier=1 order by Dat_Crea desc`;
        const blogsResult = await lireSql(sqlBlogs);

        // 4. Solde de Congé
        const now = new Date();
        // Format: DD/MM/YYYY
        const todayStr = `${now.getDate().toString().padStart(2, '0')}/${(now.getMonth() + 1).toString().padStart(2, '0')}/${now.getFullYear()}`;

        const sqlSolde = `select Solde_Conge from dbo.Sys_Rh_Conge(${id_Societe},'${todayStr}') where Matricule='${Matricule}'`;
        const soldeResult = await lireSql(sqlSolde);
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
    // Fallback to body params if not in path (for flexibility) or use context
    // The callController adapter puts everything in req.params/req.body 

    // Mat/Soc usually from req.params (injected by callController from real user)
    const Matricule = context?.Matricule || req.body?.Matricule || "";
    const id_Societe = context?.id_Societe || req.body?.id_Societe || "0000";

    try {
        const sqlSignatures = `select Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature('${Matricule}', '${id_Societe}')`;
        const rsl = await lireSql(sqlSignatures);
        res.send(rsl);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
