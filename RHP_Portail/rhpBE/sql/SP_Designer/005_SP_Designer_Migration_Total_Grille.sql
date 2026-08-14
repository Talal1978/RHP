/* ============================================================================
   RHP - Module SP_ : MIGRATION Total_Grille -> champ calculé de pied de grille
   ----------------------------------------------------------------------------
   La colonne SP_Page_Champ.Total_Grille (combo SUM/AVG/MIN/MAX/COUNT affiché
   sous la grille) est remplacée par une convention plus générale :
     champ CALCULE rattaché au détail mais SANS colonne physique (Nom_Colonne
     vide) -> évalué au niveau document (agrégat) et affiché en pied de grille.
   Ce script :
     1. convertit chaque Total_Grille renseigné en champ calculé de pied de
        grille équivalent (Cod_Champ = 'TOT_<Cod_Champ>', formule json d'agrégat,
        libellé "Total <Libellé>" / "Nombre <Libellé>" comme l'ancien rendu) ;
     2. supprime la colonne Total_Grille.
   Idempotent : ré-exécutable sans erreur ni doublon.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('SP_Page_Champ', 'Total_Grille') IS NOT NULL
BEGIN
    /* 1. Conversion des totaux configurés en champs calculés de pied de grille */
    INSERT INTO SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle, Rang,
        Valeur_Defaut, Obligatoire, Etat, Formule, Persiste, Recalc_Save, Format_Affichage, Decimales,
        Visible_Grille, Rang_Grille, Aide, Dat_Crea, Created_By)
    SELECT
        c.Cod_Page,
        LEFT('TOT_' + c.Cod_Champ, 50),
        c.Cod_Table,
        '',                                                     -- sans colonne physique : jamais stocké
        CASE WHEN c.Total_Grille = 'COUNT' THEN 'Nombre ' ELSE 'Total ' END + c.Libelle,
        'CALCULE',
        900 + ROW_NUMBER() OVER (PARTITION BY c.Cod_Page ORDER BY c.Cod_Champ),
        NULL, 'false', 'A',
        CASE WHEN c.Total_Grille = 'COUNT'
             THEN '{"op":"COUNT","table":"' + c.Cod_Table + '"}'
             ELSE '{"op":"' + c.Total_Grille + '","table":"' + c.Cod_Table + '","colonne":"' + c.Nom_Colonne + '"}'
        END,
        'false', 'true',
        CASE WHEN c.Total_Grille = 'COUNT' THEN 'NUM' ELSE 'MNT' END,  -- ancien rendu : Monetaire
        CASE WHEN c.Total_Grille = 'COUNT' THEN 0 ELSE c.Decimales END,
        'false',                                                  -- pas une colonne de la grille
        900 + ROW_NUMBER() OVER (PARTITION BY c.Cod_Page ORDER BY c.Cod_Champ),
        'Pied de grille (migré de Total_Grille=' + c.Total_Grille + ')',
        GETDATE(), 'MIGRATION'
    FROM SP_Page_Champ c
    WHERE c.Total_Grille <> ''
      AND c.Cod_Table <> 'ENT'                                  -- un total de grille porte sur un détail
      AND NOT EXISTS (SELECT 1 FROM SP_Page_Champ x
                      WHERE x.Cod_Page = c.Cod_Page
                        AND x.Cod_Champ = LEFT('TOT_' + c.Cod_Champ, 50));

    /* 2. Suppression de la colonne */
    ALTER TABLE SP_Page_Champ DROP CONSTRAINT DF_SPChamp_TotGrd;
    ALTER TABLE SP_Page_Champ DROP COLUMN Total_Grille;
END

COMMIT TRANSACTION;
GO
