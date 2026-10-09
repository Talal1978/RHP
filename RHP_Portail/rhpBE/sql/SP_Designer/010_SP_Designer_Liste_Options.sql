/* ============================================================================
   RHP - Module SP_ : options de la page LISTE des documents du portail
   ----------------------------------------------------------------------------
   Trois options de page (onglet « Conception de la page » du Designer) pilotant
   la grille principale de la page liste SPPL_<Cod_Page> du portail :

     Controle_Designer.Aff_Dat_Crea  ('true'/'false', défaut 'true') :
       affiche la colonne système « Créé le » (Dat_Crea) dans la liste.
       Opt-out : 'true' par défaut pour préserver le comportement actuel
       (la colonne a toujours été affichée) ; 'false' la retire de la liste.

     Controle_Designer.Aff_Cree_Par  ('true'/'false', défaut 'true') :
       affiche la colonne système « Créé par » (Created_By) dans la liste.
       Opt-out, même sémantique que Aff_Dat_Crea.

     Controle_Designer.Tri_Liste  (nvarchar(200), défaut '') :
       colonnes de tri de la liste, expression déclarative au format du
       « Tri par défaut » des grilles de détail (Tri_Defaut) :
       noms de colonnes de l'entête séparés par des virgules, sens optionnel
       asc/desc — ex. 'Dat_Depart desc' ou 'Dat_Depart desc, Ref_OM asc'.
       Colonnes admises : colonnes physiques déclarées de l'entête et colonnes
       techniques Num_Doc, Statut, Dat_Crea, Created_By, Dat_Modif, Modified_By
       (vérifiées côté serveur par triListeDocuments, repli 'Dat_Crea desc').
       Vide = comportement actuel : les plus récents d'abord (Dat_Crea desc).

   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.Controle_Designer', 'Aff_Dat_Crea') IS NULL
    ALTER TABLE dbo.Controle_Designer
        ADD Aff_Dat_Crea nvarchar(5) NOT NULL
            CONSTRAINT DF_SP_Page_AffDatCrea DEFAULT ('true') WITH VALUES;

IF COL_LENGTH('dbo.Controle_Designer', 'Aff_Cree_Par') IS NULL
    ALTER TABLE dbo.Controle_Designer
        ADD Aff_Cree_Par nvarchar(5) NOT NULL
            CONSTRAINT DF_SP_Page_AffCreePar DEFAULT ('true') WITH VALUES;

IF COL_LENGTH('dbo.Controle_Designer', 'Tri_Liste') IS NULL
    ALTER TABLE dbo.Controle_Designer
        ADD Tri_Liste nvarchar(200) NOT NULL
            CONSTRAINT DF_SP_Page_TriListe DEFAULT ('') WITH VALUES;

COMMIT TRANSACTION;
GO

SELECT 'Controle_Designer.Aff_Dat_Crea' AS Colonne,
       CASE WHEN COL_LENGTH('dbo.Controle_Designer','Aff_Dat_Crea') IS NULL THEN 'KO' ELSE 'OK' END AS Etat
UNION ALL SELECT 'Controle_Designer.Aff_Cree_Par',
       CASE WHEN COL_LENGTH('dbo.Controle_Designer','Aff_Cree_Par') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'Controle_Designer.Tri_Liste',
       CASE WHEN COL_LENGTH('dbo.Controle_Designer','Tri_Liste') IS NULL THEN 'KO' ELSE 'OK' END;
GO
