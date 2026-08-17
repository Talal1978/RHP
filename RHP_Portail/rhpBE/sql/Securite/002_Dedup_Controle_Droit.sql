/* ============================================================================
   RHP - Sécurité : déduplication de Controle_Droit
   ----------------------------------------------------------------------------
   Des lignes strictement identiques (mêmes Name_Ecran, Cod_Profile et droits)
   ont pu être écrites en double par d'anciennes versions des écrans de gestion
   des droits ; elles faisaient apparaître en double les entrées de l'onglet
   Portail d'Admin_Profile (multiplication par outer apply — l'écran est
   désormais en TOP 1 et les écritures sont sans doublon).
   Ce script purge les doublons EXACTS (toutes colonnes de droit à l'identique),
   en conservant la ligne au Compteur le plus petit.
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

;WITH d AS (
    SELECT Compteur,
           ROW_NUMBER() OVER (PARTITION BY Name_Ecran, Cod_Profile,
                                           Visible, Actif, Consult, [Modify], [Delet]
                              ORDER BY Compteur) AS rn
    FROM dbo.Controle_Droit
)
DELETE FROM d WHERE rn > 1;

COMMIT TRANSACTION;
GO

SELECT 'Doublons restants dans Controle_Droit' AS Controle,
       COUNT(*) AS Nb
FROM (SELECT Name_Ecran, Cod_Profile
      FROM dbo.Controle_Droit
      GROUP BY Name_Ecran, Cod_Profile
      HAVING COUNT(*) > 1) x;
GO
