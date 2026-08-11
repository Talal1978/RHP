/* ============================================================================
   RHP - Module SP_ : deploiement de la page portail "{{PAGE_TITLE}}"
   ----------------------------------------------------------------------------
   GENERE PAR le skill "rhp-portal-page-deployer" - NE PAS EDITER A LA MAIN.
   Demande        : {{CHANGE_REFERENCE}}     Environnement : {{ENVIRONMENT}}
   Genere par     : {{GENERATOR}}            Pour          : {{REQUESTED_BY}}
   Date generation: {{GENERATION_DATE}}
   Description    : {{PAGE_DESCRIPTION}}
   ----------------------------------------------------------------------------
   Operation      : {{OPERATION}}  (create | update | disable)
   Mode           : @DryRun = 1 => ROLLBACK final (aucun changement persiste)
                    @DryRun = 0 => COMMIT final
   Idempotent     : oui - re-executable sans erreur (tous les ordres gardes).
   Reversible     : oui - voir {{ROLLBACK_FILE}}.
   Cible          : SQL Server 2019 (base RHP). Une seule transaction.
   ============================================================================ */

SET XACT_ABORT ON;
SET NOCOUNT ON;

/* --------------------------------------------------------------------------
   0. Parametres du deploiement
   -------------------------------------------------------------------------- */
DECLARE @DryRun      bit           = {{DRY_RUN}};   -- 1 = dry-run, 0 = execution reelle
DECLARE @CP          nvarchar(30)  = '{{PAGE_CODE}}';
DECLARE @CDoc        nvarchar(10)  = '{{DOCUMENT_CODE}}';
DECLARE @Login       nvarchar(50)  = '{{REQUESTED_BY}}';
DECLARE @ChangeRef   nvarchar(50)  = '{{CHANGE_REFERENCE}}';
DECLARE @TableEnt    nvarchar(60)  = 'SP_{{DOCUMENT_CODE}}_Ent';
DECLARE @NameEcran   nvarchar(60)  = 'SPP_{{PAGE_CODE}}';

BEGIN TRANSACTION;
BEGIN TRY

/* --------------------------------------------------------------------------
   1. Preconditions bloquantes
   -------------------------------------------------------------------------- */
    -- 1.a Niveau de schema SP_ attendu : {{EXPECTED_SCHEMA_VERSION}}
    IF OBJECT_ID('dbo.SP_Page', 'U') IS NULL
        RAISERROR('SP_ metadata absentes : executer 001_SP_Designer_Metadata.sql d''abord.', 16, 1);
    IF '{{EXPECTED_SCHEMA_VERSION}}' IN ('SP2','SP3') AND COL_LENGTH('dbo.SP_Page', 'Acces_Personnalise') IS NULL
        RAISERROR('Niveau SP2 requis : colonne SP_Page.Acces_Personnalise absente.', 16, 1);
    IF '{{EXPECTED_SCHEMA_VERSION}}' = 'SP3' AND COL_LENGTH('dbo.SP_Page_Champ', 'estCritere') IS NULL
        RAISERROR('Niveau SP3 requis : colonne SP_Page_Champ.estCritere absente.', 16, 1);

    -- 1.b Regles de l'operation
    IF '{{OPERATION}}' = 'create' AND EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
       AND {{UPDATE_IF_EXISTS}} = 0
        RAISERROR('La page %s existe deja et update_if_exists=false : arret.', 16, 1, @CP);
    IF '{{OPERATION}}' = 'update' AND NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
        RAISERROR('Operation update mais la page %s n''existe pas : arret.', 16, 1, @CP);
    IF '{{OPERATION}}' IN ('create','update')
       AND EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Document = @CDoc AND Cod_Page <> @CP)
        RAISERROR('Cod_Document %s deja utilise par une autre page : arret.', 16, 1, @CDoc);
    IF '{{OPERATION}}' = 'disable' AND NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
        RAISERROR('Operation disable mais la page %s n''existe pas : arret.', 16, 1, @CP);

    -- 1.c Objets references (zooms / rubriques / sources / profils / modele edition / section)
{{PRECONDITION_REFS}}

IF '{{OPERATION}}' IN ('create','update')
BEGIN
/* --------------------------------------------------------------------------
   2. Section du menu portail (si create_section_if_missing)
      Miroir de SP_Page_Designer.vb:380-394
   -------------------------------------------------------------------------- */
{{SECTION_BLOCK}}

/* --------------------------------------------------------------------------
   3. Metadonnees : page
   -------------------------------------------------------------------------- */
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
    BEGIN
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter,
            Acces_Personnalise, Dat_Crea, Created_By)
        VALUES (@CP, @CDoc, N'{{LIBELLE}}', N'{{LIBELLE_COURT}}', N'{{NOM_PAGE}}',
            '{{MENU_PARENT}}', {{RANG}}, {{ICONE_SQL}}, 'BROUILLON', @TableEnt, @CDoc,
            '{{WORKFLOW_ACTIF}}', {{MODELE_EDITION_SQL}}, '{{GED_ACTIF}}', {{GED_CATEGORIES_SQL}}, '{{GED_OBLIGATOIRE}}',
            '{{ACT_ENREGISTRER}}', '{{ACT_SOUMETTRE}}', '{{ACT_IMPRIMER}}', '{{ACT_EXPORTER}}',
            '{{ACCES_PERSONNALISE}}', GETDATE(), @Login);
    END
    ELSE IF {{UPDATE_IF_EXISTS}} = 1
    BEGIN
        -- Mise a jour autorisee : colonnes mutables uniquement
        -- (Cod_Page / Cod_Document / Table_Ent sont immuables).
        UPDATE dbo.SP_Page
        SET Libelle = N'{{LIBELLE}}', Libelle_Court = N'{{LIBELLE_COURT}}', Nom_Page = N'{{NOM_PAGE}}',
            Menu_Parent = '{{MENU_PARENT}}', Rang = {{RANG}}, Icone = {{ICONE_SQL}},
            Workflow_Actif = '{{WORKFLOW_ACTIF}}', Cod_Modele_Edition = {{MODELE_EDITION_SQL}},
            GED_Actif = '{{GED_ACTIF}}', GED_Categories = {{GED_CATEGORIES_SQL}}, GED_Obligatoire = '{{GED_OBLIGATOIRE}}',
            Act_Enregistrer = '{{ACT_ENREGISTRER}}', Act_Soumettre = '{{ACT_SOUMETTRE}}',
            Act_Imprimer = '{{ACT_IMPRIMER}}', Act_Exporter = '{{ACT_EXPORTER}}',
            Acces_Personnalise = '{{ACCES_PERSONNALISE}}',
            Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP;
    END

/* --------------------------------------------------------------------------
   4. Metadonnees : collections filles (pattern officiel 002_...sql:
      suppression controlee - strictement limitee a Cod_Page = @CP - puis
      re-insertion deterministe)
   -------------------------------------------------------------------------- */
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP;

    -- 4.a Tables (ENT d'abord, Rang 0)
{{TABLE_INSERTS}}

    -- 4.b Colonnes physiques
{{COLONNE_INSERTS}}

    -- 4.c Champs UI
{{CHAMP_INSERTS}}

    -- 4.d Validations
{{VALIDATION_INSERTS}}

    -- 4.e Droits par profil
{{DROIT_INSERTS}}

/* --------------------------------------------------------------------------
   5. Sources metier (catalogue partage : insertion si absente, jamais
      d'ecrasement - une source existante n'est pas modifiee)
   -------------------------------------------------------------------------- */
{{SOURCE_INSERTS}}

/* --------------------------------------------------------------------------
   6. Tables metier - format exact Module_SP_DDL
      (creation gardee / migration non destructive : ALTER ADD uniquement)
   -------------------------------------------------------------------------- */
{{BUSINESS_DDL}}

    -- Journal DDL
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP, 'CREATE', '{{DDL_LOG_SCRIPT}}', 'true',
                N'{{DDL_LOG_MESSAGE}}', @Login, GETDATE());
{{DDL_LOG_MIGRATE}}

/* --------------------------------------------------------------------------
   7. Publication (controles de coherence - miroir SP_Page_Designer.Publier)
      Sautee si page.enabled = false (la page reste BROUILLON, invisible).
   -------------------------------------------------------------------------- */
{{PUBLICATION_BLOCK}}
END

/* --------------------------------------------------------------------------
   8. Operation disable : retrait du portail (donnees conservees)
   -------------------------------------------------------------------------- */
IF '{{OPERATION}}' = 'disable'
BEGIN
    UPDATE dbo.SP_Page
    SET Statut_Page = 'DESACTIVE', Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP AND Statut_Page = 'PUBLIE';
    PRINT 'Page ' + @CP + ' desactivee (documents conserves).';
END

/* --------------------------------------------------------------------------
   9. Verification finale + issue de transaction
   -------------------------------------------------------------------------- */
    SELECT Cod_Page, Cod_Document, Statut_Page, Menu_Parent, Rang, Version_Page
    FROM dbo.SP_Page WHERE Cod_Page = @CP;
{{FINAL_CHECKS}}

    IF @DryRun = 1
    BEGIN
        PRINT '*** DRY-RUN : ROLLBACK - aucune modification persistee. ***';
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Deploiement de ' + @CP + ' termine ({{CHANGE_REFERENCE}}).';
    END
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    DECLARE @Msg nvarchar(1000) = LEFT(ERROR_MESSAGE(), 1000);
    IF OBJECT_ID('dbo.SP_Page_DDL_Log', 'U') IS NOT NULL
       AND EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = '{{PAGE_CODE}}')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES ('{{PAGE_CODE}}', 'MIGRATE', '', 'false', @Msg, '{{REQUESTED_BY}}', GETDATE());
    PRINT 'Echec deploiement {{PAGE_CODE}} : ' + @Msg;
    ;THROW;
END CATCH;
GO
