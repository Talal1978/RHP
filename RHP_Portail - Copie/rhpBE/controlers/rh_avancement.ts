import { Request, Response } from "express";
import { IsNull } from "../modules/module_general";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

export const get_avancement_timeline = async (req: Request, res: Response) => {
  const { Matricule } = req.body;
  let idSoc = IsNull(req.params?.id_Societe, "3068");

  const sql = `
    SELECT 
      GETDATE() as Dat_Effet,
      P.Lib_Poste AS Nouveau_Poste, 
      G.Lib_Grade AS Nouveau_Grade, 
      E.Lib_Entite AS Nouvelle_Entite, 
      '' as Motif, '' as Mission,
      'ACTUEL' as Type_Avancement, '' as Cod_Avancement,
      'Actuel' as Lib_Type_Avancement
    FROM RH_Agent A
    LEFT JOIN Org_Poste P ON A.Cod_Poste = P.Cod_Poste AND A.id_Societe = P.id_Societe 
    LEFT JOIN Org_Grade G ON A.Cod_Grade = G.Cod_Grade AND A.id_Societe = G.id_Societe 
    LEFT JOIN Org_Entite E ON A.Cod_Entite = E.Cod_Entite AND A.id_Societe = E.id_Societe 
    WHERE A.Matricule = @Matricule AND A.id_Societe = @idSoc

    UNION ALL

    SELECT 
      A.Dat_Effet, 
      P.Lib_Poste AS Nouveau_Poste, 
      G.Lib_Grade AS Nouveau_Grade, 
      E.Lib_Entite AS Nouvelle_Entite, 
      A.Motif, P.Mission,
      A.Type_Avancement, A.Cod_Avancement,
      dbo.FindRubrique('Avancement', A.Type_Avancement) as Lib_Type_Avancement
    FROM RH_Avancement A 
    LEFT JOIN Org_Poste P ON A.Nouveau_Poste = P.Cod_Poste AND A.id_Societe = P.id_Societe 
    LEFT JOIN Org_Grade G ON A.Nouveau_Grade = G.Cod_Grade AND A.id_Societe = G.id_Societe 
    LEFT JOIN Org_Entite E ON A.Nouvelle_Entite = E.Cod_Entite AND A.id_Societe = E.id_Societe 
    WHERE A.Matricule = @Matricule 
    AND A.id_Societe = @idSoc 
    AND A.Statut IN ('VA', 'SG') 
    
    ORDER BY Dat_Effet DESC
  `;

  const rsl = await lireSql(sql, [
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "idSoc", sqlType: Int, valeur: idSoc },
  ]);

  return res.send(rsl);
};
