/* ============================================================================
   RHP - Module SP_ : ROLLBACK de la page portail "Télétravail"
   ----------------------------------------------------------------------------
   GENERE PAR le skill "rhp-portal-page-deployer".
   Annule le deploiement deploy.sql (demande EXEMPLE-02).
   ----------------------------------------------------------------------------
   Semantique RHP (miroir SP_Page_Designer.Deleting / Publier) :
     - Phase 1 (toujours sure) : une page PUBLIE est DESACTIVEE
       (elle disparait du portail, les documents sont conserves).
     - Phase 2 (@RemoveMetadata=1) : suppression des METADONNEES, uniquement
       si la page n'est pas PUBLIE et si les tables metier sont vides
       (ou n'ont jamais ete creees).
     - JAMAIS de DROP TABLE : les tables metier SP_ et leurs donnees sont
       conservees (regle officielle du module).
   ============================================================================ */

SET XACT_ABORT ON;
SET NOCOUNT ON;

DECLARE @DryRun         bit          = 1;   -- 1 = dry-run, 0 = execution reelle
DECLARE @RemoveMetadata bit          = 0;   -- 0 = desactivation seule
DECLARE @CP             nvarchar(30) = 'TELETRAVAIL';
DECLARE @CDoc           nvarchar(10) = 'TT';
DECLARE @Login          nvarchar(50) = 'SCRIPT';
DECLARE @NameEcran      nvarchar(60) = 'SPP_TELETRAVAIL';

BEGIN TRANSACTION;
BEGIN TRY

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
        RAISERROR('Page %s introuvable : rien a annuler.', 16, 1, @CP);

/* -- Phase 1 : retrait du portail ---------------------------------------- */
    UPDATE dbo.SP_Page
    SET Statut_Page = 'DESACTIVE', Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP AND Statut_Page = 'PUBLIE';

/* -- Phase 2 : suppression controlee des metadonnees ---------------------- */
    IF @RemoveMetadata = 1
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP AND Statut_Page = 'PUBLIE')
            RAISERROR('La page %s est encore PUBLIE : phase 2 refusee.', 16, 1, @CP);

        -- Garde-fou donnees : phase 2 refusee si des documents existent.
        -- (SP_TT_Ent suffit : les lignes SP_TT_Det_JOURS sont liees par FK.)
        IF OBJECT_ID('dbo.SP_TT_Ent', 'U') IS NOT NULL
           AND EXISTS (SELECT 1 FROM dbo.SP_TT_Ent)
            RAISERROR('Des documents existent dans SP_TT_Ent : suppression des metadonnees refusee.', 16, 1);

        -- Ordre FK-safe (miroir SP_Page_Designer.Deleting)
        DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP;
        DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP;
        DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP;
        DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP;
        DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP;
        DELETE FROM dbo.SP_Page_DDL_Log    WHERE Cod_Page = @CP;
        DELETE FROM dbo.SP_Page            WHERE Cod_Page = @CP;

        -- Enregistrements crees par la publication
        DELETE FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = @NameEcran;
        DELETE FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = @CDoc;

        -- Section 'MesDemandes' : pre-existante, NON creee par ce deploiement -> conservee.
        -- Source 'solde_conge' : catalogue partage -> conservee.

        -- Note : pas de trace dans SP_Page_DDL_Log ici - la FK impose que la
        -- page existe encore. La trace d'audit du rollback est ce script
        -- lui-meme + les colonnes Dat_Modif/Modified_By posees en phase 1.
        PRINT 'Metadonnees de ' + @CP + ' supprimees. Tables metier SP_ conservees.';
    END
    ELSE
        PRINT 'Phase 2 non demandee : ' + @CP + ' reste configuree (Statut DESACTIVE).';

    SELECT Cod_Page, Statut_Page FROM dbo.SP_Page WHERE Cod_Page = @CP;

    IF @DryRun = 1
    BEGIN
        PRINT '*** DRY-RUN : ROLLBACK - aucune modification persistee. ***';
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Rollback de ' + @CP + ' termine (EXEMPLE-02).';
    END
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'Echec rollback TELETRAVAIL : ' + LEFT(ERROR_MESSAGE(), 1000);
    ;THROW;
END CATCH;
GO
