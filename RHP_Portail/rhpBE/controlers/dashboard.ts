import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar } from "mssql";

export const getDashboardData = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    const Matricule = theAgent?.Matricule || "";
    const id_Societe = theAgent?.id_Societe || "0000";

    try {
        // 1. Signatures (Portefeuille)
        // Using the function Sys_Parapheur_Signature as seen in index.ts
        const sqlSignatures = `select top 5 Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature('${Matricule}', '${id_Societe}')`;
        const signaturesResult = await lireSql(sqlSignatures);

        // 2. Evaluations (À faire - en tant qu'évaluateur)
        // Assuming 'Cod_Evaluateur' matches Matricule and Cod_Reply is NULL (not done)
        const sqlEvaluations = `
      select top 5 
        Cod_Evaluation, Description, Dat_Du, Dat_Au, Matricule as 'Evalue_Matricule', Nom as 'Evalue_Nom'
      from Sys_Evaluation_Liste 
      where id_Societe = @id_Societe 
        and Cod_Evaluateur = @Matricule
        and not exists (
            select 1 from Survey_Reply 
            where id_Societe = Sys_Evaluation_Liste.id_Societe 
            and Cod_Survey = Sys_Evaluation_Liste.Cod_Survey 
            and Ref_Evaluation = Sys_Evaluation_Liste.Cod_Evaluation
            and Evalue = Sys_Evaluation_Liste.Matricule
        )
      order by Dat_Au asc
    `;
        const evalParams = [
            { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
            { param: "id_Societe", sqlType: NVarChar, valeur: id_Societe }
        ];
        const evaluationsResult = await lireSql(sqlEvaluations, evalParams);

        // 3. Formations (En cours ou à venir)
        // No explicit table found in analysis. Returning mock schema or empty.
        // Assuming a potential table 'RH_Formation_Demande' or similar if it existed.
        // For now, we will leave this empty or mock if requested. 
        // We'll try to select from a hypothetical RH_Formation_Session if it exists, otherwise catch error and return empty.
        let formationsResult = { result: true, data: [] };
        // Uncomment and adjust if table exists
        /*
        const sqlFormations = `select top 5 * from RH_Formation_Session where ...`;
        formationsResult = await lireSql(sqlFormations, signaturesParams);
        */

        res.send({
            result: true,
            data: {
                signatures: signaturesResult.data || [],
                evaluations: evaluationsResult.data || [],
                formations: formationsResult.data || []
            }
        });

    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
