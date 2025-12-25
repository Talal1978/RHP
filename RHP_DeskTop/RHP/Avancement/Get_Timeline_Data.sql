DECLARE @Matricule VARCHAR(20) = '000001' -- Replace with actual Matricule
DECLARE @id_Societe INT = 1 -- Replace with actual Society ID

SELECT 
    A.Dat_Effet,
    A.Dat_Decision,
    A.Code_Avancement,
    P.Lib_Poste AS Nouveau_Poste,
    G.Lib_Grade AS Nouveau_Grade,
    E.Lib_Entite AS Nouvelle_Entite,
    A.Nouveau_Titre,
    A.Motif,
    A.Observation,
    A.Statut
FROM 
    RH_Avancement A
    LEFT JOIN Org_Poste P ON A.Nouveau_Poste = P.Cod_Poste AND A.id_Societe = P.id_Societe
    LEFT JOIN Org_Grade G ON A.Nouveau_Grade = G.Cod_Grade AND A.id_Societe = G.id_Societe
    LEFT JOIN Org_Entite E ON A.Nouvelle_Entite = E.Cod_Entite AND A.id_Societe = E.id_Societe
WHERE 
    A.Matricule = @Matricule 
    AND A.id_Societe = @id_Societe
    AND A.Statut IN ('VA', 'SG') -- Only Validated or Signed advancements
ORDER BY 
    A.Dat_Effet DESC
