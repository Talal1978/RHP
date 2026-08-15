/* ============================================================================
   RHP - Module SP_ : évolutions du Designer (niveau SP4)
   ----------------------------------------------------------------------------
   Extensions de métadonnées introduites par le lot DUP-PAGES-2026-08
   (duplicatas des pages standards) :
     P2  Controle_Designer_Table.Source_Metier + Source_Mapping : détail VIRTUEL alimenté
         par une source (Typ_Retour='TABLE') - grille en lecture seule sans
         table physique (ex. découpe d'un congé par période de paie).
     P4  Controle_Designer.Figer_Statuts : liste CSV des statuts figeant le document
         (défaut 'SG,RJ,SP,VA' ; ex. 'SS,SG,RJ,SP,VA' pour figer dès soumission).
     P5  Controle_Designer_Champ.Zoom_Condition : condition de zoom avec placeholders
         "{Champ}" évalués dans le contexte (ex. Matricule='{Matricule}').
   Les autres évolutions du lot ne requièrent aucune colonne :
     P1 champs techniques (Num_Doc/Statut/Created_By) exposés aux validations ;
        @Login/@Matricule/@Cod_Profile injectés dans les sources.
     P3 champ lié à la colonne technique Statut (convention, sans colonne
        physique - affichage rubrique Statut_Signature en lecture seule).
     P6 critères de liste : plages de dates (__Du/__Au), libellé rubrique du
        statut, nom de l'agent joint, critère Statut.
     P7 cascade SOURCE -> CALCULE + ré-exécution des sources à l'enregistrement.
     P8 impression générique par les métadonnées (sans modèle Crystal).
     P9 robustesse (binding Date des sources, garde-fou ';' en littéral,
        ordre FK-safe des suppressions de métadonnées).
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.Controle_Designer', 'Figer_Statuts') IS NULL
    ALTER TABLE dbo.Controle_Designer
        ADD Figer_Statuts nvarchar(50) NOT NULL
            CONSTRAINT DF_SP_Page_FigerStatuts DEFAULT ('SG,RJ,SP,VA') WITH VALUES;

IF COL_LENGTH('dbo.Controle_Designer_Champ', 'Zoom_Condition') IS NULL
    ALTER TABLE dbo.Controle_Designer_Champ
        ADD Zoom_Condition nvarchar(500) NULL;

IF COL_LENGTH('dbo.Controle_Designer_Table', 'Source_Metier') IS NULL
    ALTER TABLE dbo.Controle_Designer_Table
        ADD Source_Metier nvarchar(50) NULL;

IF COL_LENGTH('dbo.Controle_Designer_Table', 'Source_Mapping') IS NULL
    ALTER TABLE dbo.Controle_Designer_Table
        ADD Source_Mapping nvarchar(max) NULL;

COMMIT TRANSACTION;
GO

SELECT 'Controle_Designer.Figer_Statuts' AS Colonne,
       CASE WHEN COL_LENGTH('dbo.Controle_Designer','Figer_Statuts') IS NULL THEN 'KO' ELSE 'OK' END AS Etat
UNION ALL SELECT 'Controle_Designer_Champ.Zoom_Condition',
       CASE WHEN COL_LENGTH('dbo.Controle_Designer_Champ','Zoom_Condition') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'Controle_Designer_Table.Source_Metier',
       CASE WHEN COL_LENGTH('dbo.Controle_Designer_Table','Source_Metier') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'Controle_Designer_Table.Source_Mapping',
       CASE WHEN COL_LENGTH('dbo.Controle_Designer_Table','Source_Mapping') IS NULL THEN 'KO' ELSE 'OK' END;
GO
