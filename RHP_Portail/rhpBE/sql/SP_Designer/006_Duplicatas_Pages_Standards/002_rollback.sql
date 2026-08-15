/* ============================================================================
   RHP - Module SP_ : ROLLBACK des duplicatas des pages standards
   ----------------------------------------------------------------------------
   Annule le deploiement 001_deploy.sql (demande DUP-PAGES-2026-08).
   Semantique RHP (miroir SP_Page_Designer.Deleting / Publier) :
     - Phase 1 (toujours sure) : les 6 pages PUBLIE sont DESACTIVEES
       (elles disparaissent du portail, les documents sont conserves).
     - Phase 2 (@RemoveMetadata=1) : suppression des METADONNEES, uniquement
       pour les pages non PUBLIE et dont les tables metier sont vides ;
       puis des circuits de signature X** (entetes/lignes/signataires) et
       des enregistrements crees par la publication.
     - JAMAIS de DROP TABLE : les tables metier SP_X** et leurs donnees sont
       conservees (regle officielle du module).
     - Les sources metier sp_* (catalogue partage) sont conservees par defaut ;
       @RemoveSources=1 les supprime (uniquement si non referencees ailleurs).
   ============================================================================ */

SET XACT_ABORT ON;
SET NOCOUNT ON;

DECLARE @DryRun         bit = 1;   -- 1 = dry-run (defaut), 0 = execution reelle
DECLARE @RemoveMetadata bit = 0;   -- 1 = supprime aussi les metadonnees
DECLARE @RemoveSources  bit = 0;   -- 1 = supprime aussi les sources sp_* du package
DECLARE @Login          nvarchar(50) = 'SCRIPT';

DECLARE @Pages TABLE (Cod_Page nvarchar(30), Cod_Document nvarchar(10), Table_Ent nvarchar(60));
INSERT INTO @Pages (Cod_Page, Cod_Document, Table_Ent) VALUES
    ('DUP_CONGE',           'XCG', 'SP_XCG_Ent'),
    ('DUP_NOTE_FRAIS',      'XNF', 'SP_XNF_Ent'),
    ('DUP_DECLARATION_AT',  'XAT', 'SP_XAT_Ent'),
    ('DUP_DOSSIER_MALADIE', 'XDM', 'SP_XDM_Ent'),
    ('DUP_AVANCE',          'XAV', 'SP_XAV_Ent'),
    ('DUP_PRET',            'XDP', 'SP_XDP_Ent');

BEGIN TRANSACTION;
BEGIN TRY

/* -- Phase 1 : retrait du portail (documents conserves) -------------------- */
    UPDATE p
    SET Statut_Page = 'DESACTIVE', Dat_Modif = GETDATE(), Modified_By = @Login
    FROM dbo.Controle_Designer p
    JOIN @Pages m ON m.Cod_Page = p.Cod_Page
    WHERE p.Statut_Page = 'PUBLIE';

/* -- Phase 2 : suppression controlee des metadonnees ----------------------- */
    IF @RemoveMetadata = 1
    BEGIN
        -- Garde-fou donnees : phase 2 refusee pour toute page encore PUBLIE
        -- ou dont les tables metier contiennent des documents
        IF EXISTS (SELECT 1 FROM dbo.Controle_Designer p JOIN @Pages m ON m.Cod_Page = p.Cod_Page
                   WHERE p.Statut_Page = 'PUBLIE')
            RAISERROR('Une page duplicata est encore PUBLIE : phase 2 refusee.', 16, 1);

        DECLARE @nbDocs int = 0;
        IF OBJECT_ID('dbo.SP_XCG_Ent','U') IS NOT NULL SELECT @nbDocs = @nbDocs + COUNT(*) FROM dbo.SP_XCG_Ent;
        IF OBJECT_ID('dbo.SP_XNF_Ent','U') IS NOT NULL SELECT @nbDocs = @nbDocs + COUNT(*) FROM dbo.SP_XNF_Ent;
        IF OBJECT_ID('dbo.SP_XAT_Ent','U') IS NOT NULL SELECT @nbDocs = @nbDocs + COUNT(*) FROM dbo.SP_XAT_Ent;
        IF OBJECT_ID('dbo.SP_XDM_Ent','U') IS NOT NULL SELECT @nbDocs = @nbDocs + COUNT(*) FROM dbo.SP_XDM_Ent;
        IF OBJECT_ID('dbo.SP_XAV_Ent','U') IS NOT NULL SELECT @nbDocs = @nbDocs + COUNT(*) FROM dbo.SP_XAV_Ent;
        IF OBJECT_ID('dbo.SP_XDP_Ent','U') IS NOT NULL SELECT @nbDocs = @nbDocs + COUNT(*) FROM dbo.SP_XDP_Ent;
        IF @nbDocs > 0
            RAISERROR('Des documents existent dans les tables duplicatas : phase 2 refusee.', 16, 1);

        -- Ordre FK-safe (miroir SP_Page_Designer.Deleting)
        DELETE c FROM dbo.Controle_Designer_Colonne c    JOIN @Pages m ON m.Cod_Page = c.Cod_Page;
        DELETE c FROM dbo.Controle_Designer_Champ c      JOIN @Pages m ON m.Cod_Page = c.Cod_Page;
        DELETE c FROM dbo.Controle_Designer_Validation c JOIN @Pages m ON m.Cod_Page = c.Cod_Page;
        DELETE c FROM dbo.Controle_Designer_Droit c      JOIN @Pages m ON m.Cod_Page = c.Cod_Page;
        DELETE c FROM dbo.Controle_Designer_Table c      JOIN @Pages m ON m.Cod_Page = c.Cod_Page;
        DELETE c FROM dbo.Controle_Designer_DDL_Log c    JOIN @Pages m ON m.Cod_Page = c.Cod_Page;
        DELETE c FROM dbo.Controle_Designer c            JOIN @Pages m ON m.Cod_Page = c.Cod_Page;

        -- Enregistrements crees par la publication
        DELETE FROM dbo.Controle_Def_Ecran
        WHERE Name_Ecran IN ('SPP_DUP_CONGE','SPP_DUP_NOTE_FRAIS','SPP_DUP_DECLARATION_AT',
                             'SPP_DUP_DOSSIER_MALADIE','SPP_DUP_AVANCE','SPP_DUP_PRET');
        DELETE FROM dbo.Param_Workflow_Typ_Document
        WHERE Typ_Document IN ('XCG','XNF','XDM','XAV','XDP');

        -- Circuits de signature des duplicatas (les circuits standards ne sont PAS touches)
        DELETE FROM dbo.Workflow_Signatures_Signataires WHERE Typ_Document IN ('XCG','XNF','XDM','XAV','XDP');
        DELETE FROM dbo.Workflow_Signatures_Detail      WHERE Typ_Document IN ('XCG','XNF','XDM','XAV','XDP');
        DELETE FROM dbo.Workflow_Signatures             WHERE Typ_Document IN ('XCG','XNF','XDM','XAV','XDP');

        -- Rubriques creees par le deploiement (uniquement si la section est vide
        -- d'autres pages : le retrait de la section n'est jamais force)
        IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Designer WHERE Menu_Parent = 'PagesSpecifiques')
            DELETE FROM dbo.Param_Rubriques
            WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = 'PagesSpecifiques';
        DELETE FROM dbo.Param_Rubriques WHERE Nom_Controle = 'SP_Lien_Malade';

        -- Sources metier du package (optionnel, seulement si non referencees par d'autres pages)
        IF @RemoveSources = 1
            DELETE s FROM dbo.Controle_Designer_Source s
            WHERE s.Cod_Source IN ('sp_solde_conge_date','sp_cng_periode_cloturee','sp_cng_controle_paie',
                                   'sp_cng_repos','sp_cng_feries','sp_cng_duree',
                                   'sp_avances_encours','sp_prets_encours',
                                   'sp_dernier_salaire_av','sp_dernier_salaire_pr')
              AND NOT EXISTS (SELECT 1 FROM dbo.Controle_Designer_Champ ch
                              WHERE ch.Source_Metier = s.Cod_Source
                                 OR ISNULL(ch.Formule, '') LIKE '%"source":"' + s.Cod_Source + '"%')
              AND NOT EXISTS (SELECT 1 FROM dbo.Controle_Designer_Validation v
                              WHERE ISNULL(v.Parametres, '') LIKE '%"source":"' + s.Cod_Source + '"%');

        PRINT 'Metadonnees des duplicatas supprimees. Tables metier SP_X** conservees.';
    END
    ELSE
        PRINT 'Phase 2 non demandee : les pages duplicatas restent configurees (Statut DESACTIVE).';

    SELECT Cod_Page, Statut_Page FROM dbo.Controle_Designer
    WHERE Cod_Page IN (SELECT Cod_Page FROM @Pages);

    IF @DryRun = 1
    BEGIN
        PRINT '*** DRY-RUN : ROLLBACK - aucune modification persistee. ***';
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Rollback des duplicatas termine (DUP-PAGES-2026-08).';
    END
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'Echec rollback duplicatas : ' + LEFT(ERROR_MESSAGE(), 1000);
    ;THROW;
END CATCH;
GO
