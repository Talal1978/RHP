/* ============================================================================
   RHP - Module SP_ : controles PRE-VOL pour "{{PAGE_TITLE}}" ({{PAGE_CODE}})
   ----------------------------------------------------------------------------
   GENERE PAR le skill "rhp-portal-page-deployer" - demande {{CHANGE_REFERENCE}}.
   100 % lecture seule. A executer AVANT le deploiement ; joindre le resultat
   au dossier de changement. Toute ligne "KO" est bloquante.
   ============================================================================ */
SET NOCOUNT ON;

DECLARE @CP   nvarchar(30) = '{{PAGE_CODE}}';
DECLARE @CDoc nvarchar(10) = '{{DOCUMENT_CODE}}';

SELECT 'A. Niveau schema SP_' AS Controle,
       CASE WHEN OBJECT_ID('dbo.SP_Page','U') IS NOT NULL
             AND COL_LENGTH('dbo.SP_Page','Acces_Personnalise') IS NOT NULL
             AND COL_LENGTH('dbo.SP_Page_Champ','estCritere') IS NOT NULL
            THEN 'OK (SP3)' ELSE 'KO' END AS Resultat;

-- Requis si l'input utilise freeze_statuses / zoom_condition / grid_total /
-- un detail virtuel (expected_schema_version = SP4) :
SELECT 'A2. Niveau schema SP4' AS Controle,
       CASE WHEN COL_LENGTH('dbo.SP_Page','Figer_Statuts') IS NOT NULL
             AND COL_LENGTH('dbo.SP_Page_Champ','Zoom_Condition') IS NOT NULL
             AND COL_LENGTH('dbo.SP_Page_Champ','Total_Grille') IS NOT NULL
             AND COL_LENGTH('dbo.SP_Page_Table','Source_Metier') IS NOT NULL
             AND COL_LENGTH('dbo.SP_Page_Table','Source_Mapping') IS NOT NULL
            THEN 'OK (SP4)'
            ELSE 'KO - executer 005_SP_Designer_Migration_Total_Grille.sql + 006_SP_Designer_Evolutions.sql' END AS Resultat;

SELECT 'B1. Page existe deja' AS Controle,
       CASE WHEN EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
            THEN 'OUI - ' + (SELECT Statut_Page FROM dbo.SP_Page WHERE Cod_Page = @CP)
            ELSE 'NON' END AS Resultat;   -- 'OUI' exige operation=update ou update_if_exists=true

SELECT 'B2. Cod_Document disponible' AS Controle,
       CASE WHEN EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Document = @CDoc AND Cod_Page <> @CP)
            THEN 'KO - pris par ' + (SELECT Cod_Page FROM dbo.SP_Page WHERE Cod_Document = @CDoc AND Cod_Page <> @CP)
            ELSE 'OK' END AS Resultat;

SELECT 'B3. Tables physiques cibles' AS Controle, t.name AS Resultat
FROM sys.tables t WHERE t.name IN ({{PHYSICAL_TABLE_NAMES}});
-- Toute ligne retournee = table deja presente => verifier qu'elle appartient
-- bien a CETTE page (SP_Page_Table.Nom_Physique), sinon KO.

SELECT 'C1. Section menu' AS Controle, Valeur, Membre FROM dbo.Param_Rubriques
WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = '{{TARGET_SECTION_CODE}}';
-- 0 ligne => KO sauf create_section_if_missing=true

{{PREFLIGHT_REF_CHECKS}}
/* Blocs generes par reference utilisee, ex. :
SELECT 'C2. Zoom' AS Controle, Num_Zoom FROM dbo.Controle_Def_Zoom WHERE Num_Zoom = 'MS067';
SELECT 'C3. Rubrique' AS Controle, Nom_Controle FROM dbo.Param_Rubriques WHERE Nom_Controle = '...' ;
SELECT 'C4. Source' AS Controle, Cod_Source, Actif FROM dbo.SP_Page_Source WHERE Cod_Source = '...';
-- C4-bis (detail virtuel) : la source DOIT etre de retour TABLE et active
--   (miroir VerifierTableVirtuelle) ; verifier aussi que ses parametres
--   obligatoires sont tous alimentes par le mapping de l'input :
SELECT 'C4b. Source detail virtuel' AS Controle, Cod_Source, Typ_Retour, Actif
FROM dbo.SP_Page_Source WHERE Cod_Source = '...';   -- exiger Typ_Retour='TABLE', Actif='true'
SELECT 'C5. Profil' AS Controle, Cod_Profile FROM dbo.Controle_Profile WHERE Cod_Profile IN (...);
SELECT 'C6. Modele edition' AS Controle, Cod_Report FROM dbo.Param_Mod_Edition WHERE Cod_Report = '...';
SELECT 'C7. Moteur workflow' AS Controle, OBJECT_ID('dbo.Sys_Workflow_Signature','P') AS ProcId;
*/
GO
