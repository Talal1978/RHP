/* ============================================================================
   RHP - Module Sante, Infirmerie & Medecine du travail
   Script d'installation SQL Server (IDEMPOTENT)
   ----------------------------------------------------------------------------
   Contenu :
      1.  Tables metier RH_Sante_* et Param_Sante_*
      2.  Extensions non destructives de RH_Declaration_AT[_Detail]
      3.  Vues de restitution (separation domaine medical / domaine RH)
      4.  Fonctions et procedures Sys_Sante_*
      5.  Rubriques (Param_Rubriques)
      6.  Zooms (MS300-MS349, AT010)
      7.  Definition des ecrans + boutons + securite avancee
      8.  Workflow : types de document 'VM' (visite) et 'FA' (fiche aptitude)
      9.  Fonctions de securite SANTE_CLINIQUE / SANTE_ADMIN / SANTE_AUDIT
      10. Menus (Controle_TreeView + Controle_Menu)
      11. Audit espion (Param_Audit_Espion + triggers ESP_*)
      12. Parametres reglementaires (cles avec source - valeurs a completer
          apres verification du texte en vigueur)
   ----------------------------------------------------------------------------
   Apres execution :
      - Verifier les ecrans dans Admin_TreeView (Generation globale si besoin)
      - Parametrer les circuits Workflow_Signatures pour 'VM' et 'FA'
      - Affecter les fonctions SANTE_* aux profils via Admin_Profile
      - Completer les parametres reglementaires (ecran RH_Sante_Param)
      - Parametrer les Notifications (alertes) via l'ecran Notifications
   ============================================================================ */

SET NOCOUNT ON;
GO

/* -------------------------------------------------------------------------- */
/* 1. Tables metier                                                            */
/* -------------------------------------------------------------------------- */

IF OBJECT_ID('dbo.RH_Sante_Dossier', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Dossier (
        Matricule               nvarchar(20)  NOT NULL,
        id_Societe              int           NOT NULL,
        Groupe_Sanguin          nvarchar(5)   NULL,
        Medecin_Traitant        nvarchar(100) NULL,
        Antecedents             nvarchar(max) NULL,
        Observations            nvarchar(max) NULL,
        Dat_Derniere_Visite     datetime      NULL,
        Dat_Prochaine_Visite    datetime      NULL,
        Statut_Aptitude_Courant nvarchar(10)  NULL,
        Archive                 bit           NULL CONSTRAINT DF_RH_Sante_Dossier_Archive DEFAULT (0),
        Dat_Crea                datetime      NULL,
        Created_By              nvarchar(50)  NULL,
        Dat_Modif               datetime      NULL,
        Modified_By             nvarchar(50)  NULL,
        CONSTRAINT PK_RH_Sante_Dossier PRIMARY KEY (Matricule, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.RH_Sante_Visite', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Visite (
        Num_Visite            nvarchar(20)   NOT NULL,
        id_Societe            int            NOT NULL,
        Matricule             nvarchar(20)   NOT NULL,
        Dat_Visite            datetime       NULL,
        Typ_Visite            nvarchar(10)   NULL,   -- rubrique Typ_Visite : EMB/PRD/RPR/SPO
        Cod_Medecin           nvarchar(20)   NULL,   -- Param_Sante_Intervenant (MED)
        Cod_Campagne          nvarchar(20)   NULL,
        Conclusion            nvarchar(max)  NULL,   -- CLINIQUE
        Statut_Aptitude       nvarchar(10)   NULL,   -- rubrique Statut_Aptitude
        Reserves              nvarchar(500)  NULL,
        Restrictions          nvarchar(500)  NULL,
        Dat_Prochaine_Visite  datetime       NULL,
        Cod_Regle_Appliquee   nvarchar(20)   NULL,
        Motif_Ajustement      nvarchar(250)  NULL,
        Num_Visite_Rectifiee  nvarchar(20)   NULL,
        Motif_Rectification   nvarchar(250)  NULL,
        Statut                nvarchar(3)    NULL,   -- '' brouillon, SS, VA, SG, RJ
        Dat_Crea              datetime       NULL,
        Created_By            nvarchar(50)   NULL,
        Dat_Modif             datetime       NULL,
        Modified_By           nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Visite PRIMARY KEY (Num_Visite, id_Societe)
    );
    CREATE INDEX IX_RH_Sante_Visite_Agent ON RH_Sante_Visite (id_Societe, Matricule);
    CREATE INDEX IX_RH_Sante_Visite_Echeance ON RH_Sante_Visite (id_Societe, Dat_Prochaine_Visite);
    CREATE INDEX IX_RH_Sante_Visite_Statut ON RH_Sante_Visite (id_Societe, Statut);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Aptitude', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Aptitude (
        Num_Aptitude       nvarchar(20)   NOT NULL,
        id_Societe         int            NOT NULL,
        Num_Visite         nvarchar(20)   NULL,
        Matricule          nvarchar(20)   NOT NULL,
        Dat_Aptitude       datetime       NULL,
        Cod_Medecin        nvarchar(20)   NULL,
        Statut_Aptitude    nvarchar(10)   NULL,
        Reserves           nvarchar(500)  NULL,
        Restrictions_Poste nvarchar(500)  NULL,
        Amenagements       nvarchar(500)  NULL,
        Dat_Effet          datetime       NULL,
        Dat_Fin            datetime       NULL,
        Version            int            NOT NULL CONSTRAINT DF_RH_Sante_Aptitude_Version DEFAULT (1),
        Num_Aptitude_Prec  nvarchar(20)   NULL,
        Motif_Version      nvarchar(250)  NULL,
        Publie_RH          bit            NULL CONSTRAINT DF_RH_Sante_Aptitude_Publie DEFAULT (0),
        FD_PDF             bigint         NULL,      -- Param_GED.FD_id du PDF archive
        Statut             nvarchar(3)    NULL,
        Dat_Crea           datetime       NULL,
        Created_By         nvarchar(50)   NULL,
        Dat_Modif          datetime       NULL,
        Modified_By        nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Aptitude PRIMARY KEY (Num_Aptitude, id_Societe),
        CONSTRAINT CK_RH_Sante_Aptitude_Version CHECK (Version >= 1)
    );
    CREATE INDEX IX_RH_Sante_Aptitude_Agent ON RH_Sante_Aptitude (id_Societe, Matricule);
END
GO

IF OBJECT_ID('dbo.Param_Sante_Periodicite', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Param_Sante_Periodicite (
        Cod_Regle             nvarchar(20)  NOT NULL,
        id_Societe            int           NOT NULL,   -- -1 = global
        Lib_Regle             nvarchar(150) NULL,
        Critere               nvarchar(20)  NULL,       -- rubrique Critere_Periodicite
        Valeur_Critere        nvarchar(50)  NULL,
        Periodicite_Mois      int           NULL,
        Priorite              int           NULL CONSTRAINT DF_Param_Sante_Periodicite_Prio DEFAULT (100),
        Dat_Deb_Effet         datetime      NULL,
        Dat_Fin_Effet         datetime      NULL,
        Source_Reglementaire  nvarchar(250) NULL,
        Actif                 bit           NULL CONSTRAINT DF_Param_Sante_Periodicite_Actif DEFAULT (1),
        Dat_Crea              datetime      NULL,
        Created_By            nvarchar(50)  NULL,
        Dat_Modif             datetime      NULL,
        Modified_By           nvarchar(50)  NULL,
        CONSTRAINT PK_Param_Sante_Periodicite PRIMARY KEY (Cod_Regle, id_Societe),
        CONSTRAINT CK_Param_Sante_Periodicite_Mois CHECK (Periodicite_Mois IS NULL OR Periodicite_Mois > 0)
    );
END
GO

IF OBJECT_ID('dbo.RH_Sante_Agent_Critere', 'U') IS NULL
BEGIN
    -- Criteres medicaux temporaires d'un agent (ex : grossesse, travail de nuit)
    -- DONNEE CLINIQUE : acces SANTE_CLINIQUE uniquement
    CREATE TABLE dbo.RH_Sante_Agent_Critere (
        RowId        int IDENTITY(1,1) NOT NULL,
        Matricule    nvarchar(20)      NOT NULL,
        id_Societe   int               NOT NULL,
        Critere      nvarchar(20)      NULL,   -- rubrique Critere_Periodicite (NUIT/ENCEINTE/...)
        Dat_Deb      datetime          NULL,
        Dat_Fin      datetime          NULL,
        Cod_Medecin  nvarchar(20)      NULL,
        Commentaire  nvarchar(250)     NULL,
        Dat_Crea     datetime          NULL,
        Created_By   nvarchar(50)      NULL,
        Dat_Modif    datetime          NULL,
        Modified_By  nvarchar(50)      NULL,
        CONSTRAINT PK_RH_Sante_Agent_Critere PRIMARY KEY (RowId)
    );
    CREATE INDEX IX_RH_Sante_Agent_Critere_Agent ON RH_Sante_Agent_Critere (id_Societe, Matricule);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Campagne', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Campagne (
        Cod_Campagne  nvarchar(20)  NOT NULL,
        id_Societe    int           NOT NULL,
        Lib_Campagne  nvarchar(150) NULL,
        Typ_Visite    nvarchar(10)  NULL,
        Dat_Deb       datetime      NULL,
        Dat_Fin       datetime      NULL,
        Cod_Medecin   nvarchar(20)  NULL,
        Lieu          nvarchar(150) NULL,
        Statut        nvarchar(10)  NULL,   -- rubrique Statut_Campagne : PRE/ENC/CLO
        Dat_Crea      datetime      NULL,
        Created_By    nvarchar(50)  NULL,
        Dat_Modif     datetime      NULL,
        Modified_By   nvarchar(50)  NULL,
        CONSTRAINT PK_RH_Sante_Campagne PRIMARY KEY (Cod_Campagne, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.RH_Sante_Convocation', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Convocation (
        RowId              int IDENTITY(1,1) NOT NULL,
        Cod_Campagne       nvarchar(20)      NOT NULL,
        id_Societe         int               NOT NULL,
        Matricule          nvarchar(20)      NULL,
        Dat_Convocation    datetime          NULL,
        Heure              nvarchar(5)       NULL,
        Statut_Convocation nvarchar(10)      NULL,   -- rubrique Statut_Convocation
        Dat_Envoi          datetime          NULL,
        Num_Visite         nvarchar(20)      NULL,
        Commentaire        nvarchar(250)     NULL,
        Dat_Crea           datetime          NULL,
        Created_By         nvarchar(50)      NULL,
        Dat_Modif          datetime          NULL,
        Modified_By        nvarchar(50)      NULL,
        CONSTRAINT PK_RH_Sante_Convocation PRIMARY KEY (RowId)
    );
    CREATE INDEX IX_RH_Sante_Convocation_Campagne ON RH_Sante_Convocation (id_Societe, Cod_Campagne);
    CREATE INDEX IX_RH_Sante_Convocation_Agent ON RH_Sante_Convocation (id_Societe, Matricule);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Consultation', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Consultation (
        Num_Consultation nvarchar(20)   NOT NULL,
        id_Societe       int            NOT NULL,
        Matricule        nvarchar(20)   NOT NULL,
        Dat_Consultation datetime       NULL,
        Cod_Intervenant  nvarchar(20)   NULL,
        Typ_Acte         nvarchar(10)   NULL,   -- rubrique Typ_Acte_Infirmier
        Motif            nvarchar(500)  NULL,   -- CLINIQUE
        Observations     nvarchar(max)  NULL,   -- CLINIQUE
        Suite            nvarchar(10)   NULL,   -- rubrique Suite_Consultation
        Num_Declaration_AT nvarchar(20) NULL,
        Statut           nvarchar(3)    NULL,
        Dat_Crea         datetime       NULL,
        Created_By       nvarchar(50)   NULL,
        Dat_Modif        datetime       NULL,
        Modified_By      nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Consultation PRIMARY KEY (Num_Consultation, id_Societe)
    );
    CREATE INDEX IX_RH_Sante_Consultation_Agent ON RH_Sante_Consultation (id_Societe, Matricule);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Examen', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Examen (
        Num_Examen              nvarchar(20)   NOT NULL,
        id_Societe              int            NOT NULL,
        Matricule               nvarchar(20)   NOT NULL,
        Typ_Examen              nvarchar(20)   NULL,   -- rubrique Typ_Examen
        Dat_Prescription        datetime       NULL,
        Dat_Examen              datetime       NULL,
        Cod_Medecin_Prescripteur nvarchar(20)  NULL,
        Cod_Prestataire         nvarchar(20)   NULL,   -- Param_Sante_Intervenant (LAB)
        Motif                   nvarchar(500)  NULL,   -- CLINIQUE
        Statut_Examen           nvarchar(10)   NULL,   -- rubrique Statut_Examen : PRE/REA/RES
        Dat_Resultat            datetime       NULL,
        Resultat_Resume         nvarchar(max)  NULL,   -- CLINIQUE
        Visibilite              nvarchar(10)   NULL,   -- rubrique Visibilite_Examen : MED/AUT
        FD_Resultat             bigint         NULL,   -- Param_GED.FD_id (piece cloisonnee)
        Dat_Limite_Conservation datetime      NULL,
        Statut                  nvarchar(3)    NULL,
        Dat_Crea                datetime       NULL,
        Created_By              nvarchar(50)   NULL,
        Dat_Modif               datetime       NULL,
        Modified_By             nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Examen PRIMARY KEY (Num_Examen, id_Societe)
    );
    CREATE INDEX IX_RH_Sante_Examen_Agent ON RH_Sante_Examen (id_Societe, Matricule);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Maladie_Pro', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Maladie_Pro (
        Num_MP             nvarchar(20)   NOT NULL,
        id_Societe         int            NOT NULL,
        Matricule          nvarchar(20)   NOT NULL,
        Dat_Declaration    datetime       NULL,
        Dat_Premier_Constat datetime      NULL,
        Pathologie         nvarchar(250)  NULL,
        Tableau_MP         nvarchar(50)   NULL,
        Organisme          nvarchar(100)  NULL,
        Num_Dossier_Org    nvarchar(50)   NULL,
        Statut_Declaration nvarchar(10)   NULL,   -- rubrique Statut_Declaration_MP
        Commentaire        nvarchar(500)  NULL,
        Statut             nvarchar(3)    NULL,
        Dat_Crea           datetime       NULL,
        Created_By         nvarchar(50)   NULL,
        Dat_Modif          datetime       NULL,
        Modified_By        nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Maladie_Pro PRIMARY KEY (Num_MP, id_Societe)
    );
    CREATE INDEX IX_RH_Sante_Maladie_Pro_Agent ON RH_Sante_Maladie_Pro (id_Societe, Matricule);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Vaccination', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Sante_Vaccination (
        RowId           int IDENTITY(1,1) NOT NULL,
        Matricule       nvarchar(20)      NOT NULL,
        id_Societe      int               NOT NULL,
        Typ_Vaccin      nvarchar(20)      NULL,   -- rubrique Typ_Vaccin
        Dat_Vaccination datetime          NULL,
        Dat_Rappel      datetime          NULL,
        Cod_Intervenant nvarchar(20)      NULL,
        Num_Consultation nvarchar(20)     NULL,
        Commentaire     nvarchar(250)     NULL,
        Dat_Crea        datetime          NULL,
        Created_By      nvarchar(50)      NULL,
        Dat_Modif       datetime          NULL,
        Modified_By     nvarchar(50)      NULL,
        CONSTRAINT PK_RH_Sante_Vaccination PRIMARY KEY (RowId)
    );
    CREATE INDEX IX_RH_Sante_Vaccination_Agent ON RH_Sante_Vaccination (id_Societe, Matricule);
    CREATE INDEX IX_RH_Sante_Vaccination_Rappel ON RH_Sante_Vaccination (id_Societe, Dat_Rappel);
END
GO

IF OBJECT_ID('dbo.Param_Sante_Intervenant', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Param_Sante_Intervenant (
        Cod_Intervenant nvarchar(20)  NOT NULL,
        id_Societe      int           NOT NULL,   -- -1 = global
        Nom             nvarchar(100) NULL,
        Prenom          nvarchar(100) NULL,
        Typ_Intervenant nvarchar(10)  NULL,   -- rubrique Typ_Intervenant : MED/INF/LAB/CAB/PRV
        Specialite      nvarchar(100) NULL,
        Num_Ordre       nvarchar(30)  NULL,
        Tel             nvarchar(30)  NULL,
        Mail            nvarchar(100) NULL,
        Adresse         nvarchar(250) NULL,
        Actif           bit           NULL CONSTRAINT DF_Param_Sante_Intervenant_Actif DEFAULT (1),
        Dat_Crea        datetime      NULL,
        Created_By      nvarchar(50)  NULL,
        Dat_Modif       datetime      NULL,
        Modified_By     nvarchar(50)  NULL,
        CONSTRAINT PK_Param_Sante_Intervenant PRIMARY KEY (Cod_Intervenant, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.Param_Sante_Poste_Risque', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Param_Sante_Poste_Risque (
        Cod_Poste     nvarchar(20)   NOT NULL,
        id_Societe    int            NOT NULL,
        Niveau_Risque nvarchar(10)   NULL,   -- rubrique Niveau_Risque
        Expositions   nvarchar(500)  NULL,
        Cod_Regle     nvarchar(20)   NULL,   -- regle de periodicite associee (explique l'echeance)
        Dat_Crea      datetime       NULL,
        Created_By    nvarchar(50)   NULL,
        Dat_Modif     datetime       NULL,
        Modified_By   nvarchar(50)   NULL,
        CONSTRAINT PK_Param_Sante_Poste_Risque PRIMARY KEY (Cod_Poste, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.Param_Sante_Reglement', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Param_Sante_Reglement (
        Cod_Param             nvarchar(50)  NOT NULL,
        id_Societe            int           NOT NULL,   -- -1 = global
        Lib_Param             nvarchar(150) NULL,
        Valeur                nvarchar(250) NULL,
        Source_Reglementaire  nvarchar(250) NULL,
        Version_Texte         nvarchar(50)  NULL,
        Dat_Deb_Effet         datetime      NULL,
        Dat_Fin_Effet         datetime      NULL,
        Dat_Crea              datetime      NULL,
        Created_By            nvarchar(50)  NULL,
        Dat_Modif             datetime      NULL,
        Modified_By           nvarchar(50)  NULL,
        CONSTRAINT PK_Param_Sante_Reglement PRIMARY KEY (Cod_Param, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.RH_Sante_Audit_Acces', 'U') IS NULL
BEGIN
    -- Journal APPEND-ONLY des acces aux donnees de sante.
    -- Aucune API de modification/suppression. Purge via Sys_Sante_Purge uniquement.
    CREATE TABLE dbo.RH_Sante_Audit_Acces (
        RowId              bigint IDENTITY(1,1) NOT NULL,
        id_Societe         int            NULL,
        Login_User         nvarchar(50)   NULL,
        id_User            int            NULL,
        Cod_Profile        nvarchar(10)   NULL,
        Typ_Role           nvarchar(10)   NULL,
        Action             nvarchar(10)   NULL,   -- LECT/CREA/MODI/SUPP/IMPR/EXPO/TELE/AUTH_KO
        Objet              nvarchar(50)   NULL,
        Valeur_Index       nvarchar(100)  NULL,
        Matricule_Concerne nvarchar(20)   NULL,
        Dat_Action         datetime       NULL CONSTRAINT DF_RH_Sante_Audit_Acces_Dat DEFAULT (GETDATE()),
        Poste              nvarchar(100)  NULL,
        IP                 nvarchar(50)   NULL,
        Succes             bit            NULL,
        Motif              nvarchar(250)  NULL,
        CONSTRAINT PK_RH_Sante_Audit_Acces PRIMARY KEY (RowId)
    );
    CREATE INDEX IX_RH_Sante_Audit_Acces_Dat ON RH_Sante_Audit_Acces (id_Societe, Dat_Action);
    CREATE INDEX IX_RH_Sante_Audit_Acces_Objet ON RH_Sante_Audit_Acces (Objet, Valeur_Index);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Heures_Travaillees', 'U') IS NULL
BEGIN
    -- Denominateur des taux de frequence/gravite (source parametree et auditable)
    CREATE TABLE dbo.RH_Sante_Heures_Travaillees (
        Annee       int            NOT NULL,
        Mois        int            NOT NULL,
        id_Societe  int            NOT NULL,
        Heures      float          NULL,
        Source      nvarchar(100)  NULL,   -- ex : 'SAISIE', 'PAIE', 'POINTAGE'
        Dat_Crea    datetime       NULL,
        Created_By  nvarchar(50)   NULL,
        Dat_Modif   datetime       NULL,
        Modified_By nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Heures_Travaillees PRIMARY KEY (Annee, Mois, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.Param_Sante_Destinataire', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Param_Sante_Destinataire (
        Cod_Destinataire nvarchar(20)  NOT NULL,
        id_Societe       int           NOT NULL,   -- -1 = global
        Lib_Destinataire nvarchar(150) NULL,
        Typ_Destinataire nvarchar(10)  NULL,   -- rubrique Typ_Destinataire : ASS/AUT/CNSS/INT/AUTRE
        Delai_Jours      int           NULL,
        Point_Depart     nvarchar(10)  NULL,   -- rubrique Point_Depart_Echeance : ACC/DEC/GUER
        Source_Reglementaire nvarchar(250) NULL,
        Actif            bit           NULL CONSTRAINT DF_Param_Sante_Destinataire_Actif DEFAULT (1),
        Dat_Crea         datetime      NULL,
        Created_By       nvarchar(50)  NULL,
        Dat_Modif        datetime      NULL,
        Modified_By      nvarchar(50)  NULL,
        CONSTRAINT PK_Param_Sante_Destinataire PRIMARY KEY (Cod_Destinataire, id_Societe),
        CONSTRAINT CK_Param_Sante_Destinataire_Delai CHECK (Delai_Jours IS NULL OR Delai_Jours >= 0)
    );
END
GO

IF OBJECT_ID('dbo.Param_Sante_Etape_AT', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Param_Sante_Etape_AT (
        Cod_Etape      nvarchar(20)  NOT NULL,
        id_Societe     int           NOT NULL,   -- -1 = global
        Lib_Etape      nvarchar(150) NULL,
        Rang           int           NULL,
        Cod_Destinataire nvarchar(20) NULL,
        Delai_Jours    int           NULL,
        Point_Depart   nvarchar(10)  NULL,   -- rubrique Point_Depart_Echeance
        Source_Reglementaire nvarchar(250) NULL,
        Actif          bit           NULL CONSTRAINT DF_Param_Sante_Etape_AT_Actif DEFAULT (1),
        Dat_Crea       datetime      NULL,
        Created_By     nvarchar(50)  NULL,
        Dat_Modif      datetime      NULL,
        Modified_By    nvarchar(50)  NULL,
        CONSTRAINT PK_Param_Sante_Etape_AT PRIMARY KEY (Cod_Etape, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.RH_Declaration_AT_Echeance', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Declaration_AT_Echeance (
        RowId           int IDENTITY(1,1) NOT NULL,
        Num_Declaration nvarchar(20)      NOT NULL,
        id_Societe      int               NOT NULL,
        Cod_Etape       nvarchar(20)      NULL,
        Dat_Debut       datetime          NULL,
        Delai_Jours     int               NULL,
        Dat_Echeance    datetime          NULL,
        Statut_Etape    nvarchar(10)      NULL,   -- rubrique Statut_Etape_AT : AFA/ENC/FAI/DEP/ANN
        Dat_Realisation datetime          NULL,
        FD_Preuve       bigint            NULL,
        Commentaire     nvarchar(250)     NULL,
        Dat_Crea        datetime          NULL,
        Created_By      nvarchar(50)      NULL,
        Dat_Modif       datetime          NULL,
        Modified_By     nvarchar(50)      NULL,
        CONSTRAINT PK_RH_Declaration_AT_Echeance PRIMARY KEY (RowId)
    );
    CREATE INDEX IX_RH_Declaration_AT_Echeance_Decl ON RH_Declaration_AT_Echeance (id_Societe, Num_Declaration);
    CREATE INDEX IX_RH_Declaration_AT_Echeance_Dat ON RH_Declaration_AT_Echeance (id_Societe, Dat_Echeance, Statut_Etape);
END
GO

IF OBJECT_ID('dbo.RH_Declaration_AT_Transmission', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Declaration_AT_Transmission (
        RowId            int IDENTITY(1,1) NOT NULL,
        Num_Declaration  nvarchar(20)      NOT NULL,
        id_Societe       int               NOT NULL,
        Cod_Destinataire nvarchar(20)      NULL,
        Dat_Transmission datetime          NULL,
        Mode_Transmission nvarchar(10)     NULL,   -- rubrique Mode_Transmission
        Reference        nvarchar(100)     NULL,
        FD_Preuve        bigint            NULL,
        Commentaire      nvarchar(250)     NULL,
        Dat_Crea         datetime          NULL,
        Created_By       nvarchar(50)      NULL,
        Dat_Modif        datetime          NULL,
        Modified_By      nvarchar(50)      NULL,
        CONSTRAINT PK_RH_Declaration_AT_Transmission PRIMARY KEY (RowId)
    );
    CREATE INDEX IX_RH_Declaration_AT_Transmission_Decl ON RH_Declaration_AT_Transmission (id_Societe, Num_Declaration);
END
GO

IF OBJECT_ID('dbo.RH_Sante_Rapport_Annuel', 'U') IS NULL
BEGIN
    -- Rapport annuel de medecine du travail (statut et preuves ; le PDF est en GED)
    CREATE TABLE dbo.RH_Sante_Rapport_Annuel (
        Annee           int            NOT NULL,
        id_Societe      int            NOT NULL,
        Statut          nvarchar(10)   NULL,   -- BROUILLON/CONTROLE/VALIDE/TRANSMIS (rubrique Statut_Rapport_Annuel)
        Dat_Controle    datetime       NULL,
        Dat_Validation  datetime       NULL,
        Dat_Transmission datetime      NULL,
        FD_Rapport      bigint         NULL,   -- Param_GED.FD_id du PDF archive
        FD_Preuve       bigint         NULL,   -- preuve de transmission
        Version         int            NULL CONSTRAINT DF_RH_Sante_Rapport_Annuel_V DEFAULT (1),
        Commentaire     nvarchar(250)  NULL,
        Dat_Crea        datetime       NULL,
        Created_By      nvarchar(50)   NULL,
        Dat_Modif       datetime       NULL,
        Modified_By     nvarchar(50)   NULL,
        CONSTRAINT PK_RH_Sante_Rapport_Annuel PRIMARY KEY (Annee, id_Societe)
    );
END
GO

/* -------------------------------------------------------------------------- */
/* 2. Extensions non destructives des tables AT existantes                     */
/* -------------------------------------------------------------------------- */

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.RH_Declaration_AT') AND name = 'Typ_Accident')
    ALTER TABLE dbo.RH_Declaration_AT ADD Typ_Accident varchar(20) NULL;   -- rubrique Typ_Accident : TRAVAIL/TRAJET/NREC
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.RH_Declaration_AT_Detail') AND name = 'Num_Conge')
    ALTER TABLE dbo.RH_Declaration_AT_Detail ADD Num_Conge varchar(20) NULL; -- absence generee dans RH_Conge_Suivi
GO

/* -------------------------------------------------------------------------- */
/* 3. Vues de restitution (separation des domaines)                            */
/* -------------------------------------------------------------------------- */

IF OBJECT_ID('dbo.RH_Sante_Vue_Aptitude_RH', 'V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_Aptitude_RH;
GO
-- Vue MEDICO-ADMINISTRATIVE : aucune colonne clinique.
CREATE VIEW dbo.RH_Sante_Vue_Aptitude_RH AS
SELECT  a.id_Societe,
        a.Matricule,
        r.Nom_Agent + ' ' + r.Prenom_Agent AS Nom,
        a.Num_Aptitude,
        a.Dat_Aptitude,
        apt.Membre AS Statut_Aptitude_Lib,
        a.Statut_Aptitude,
        a.Restrictions_Poste,
        a.Amenagements,
        a.Dat_Effet,
        a.Dat_Fin,
        d.Dat_Prochaine_Visite
FROM RH_Sante_Aptitude a
INNER JOIN RH_Agent r ON r.Matricule = a.Matricule AND r.id_Societe = a.id_Societe
LEFT JOIN RH_Sante_Dossier d ON d.Matricule = a.Matricule AND d.id_Societe = a.id_Societe
LEFT JOIN Param_Rubriques apt ON apt.Nom_Controle = 'Statut_Aptitude' AND apt.Valeur = a.Statut_Aptitude
WHERE ISNULL(a.Publie_RH, 0) = 1
  AND ISNULL(a.Statut, '') IN ('VA', 'SG')
  AND a.Version = (SELECT MAX(v.Version) FROM RH_Sante_Aptitude v
                   WHERE v.Matricule = a.Matricule AND v.id_Societe = a.id_Societe
                     AND ISNULL(v.Publie_RH, 0) = 1 AND ISNULL(v.Statut, '') IN ('VA', 'SG'));
GO

IF OBJECT_ID('dbo.RH_Sante_Vue_Echeances', 'V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_Echeances;
GO
CREATE VIEW dbo.RH_Sante_Vue_Echeances AS
SELECT  d.id_Societe,
        d.Matricule,
        r.Nom_Agent + ' ' + r.Prenom_Agent AS Nom,
        r.Cod_Entite,
        r.Cod_Poste,
        d.Dat_Derniere_Visite,
        d.Dat_Prochaine_Visite,
        d.Statut_Aptitude_Courant,
        CASE WHEN d.Dat_Prochaine_Visite IS NULL THEN 'SANS_VISITE'
             WHEN d.Dat_Prochaine_Visite < GETDATE() THEN 'ECHUE'
             WHEN d.Dat_Prochaine_Visite <= DATEADD(day, 30, GETDATE()) THEN 'PROCHE'
             ELSE 'A_VENIR' END AS Situation
FROM RH_Sante_Dossier d
INNER JOIN RH_Agent r ON r.Matricule = d.Matricule AND r.id_Societe = d.id_Societe
WHERE ISNULL(d.Archive, 0) = 0;
GO

IF OBJECT_ID('dbo.RH_Sante_Vue_TB_Aptitudes', 'V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_TB_Aptitudes;
GO
-- Agregats pour tableau de bord (masquage anti-reidentification applique par l'appelant
-- selon SEUIL_AGREGAT_MIN).
CREATE VIEW dbo.RH_Sante_Vue_TB_Aptitudes AS
SELECT  d.id_Societe,
        ISNULL(d.Statut_Aptitude_Courant, 'SANS_VISITE') AS Statut_Aptitude,
        CASE WHEN d.Dat_Prochaine_Visite IS NULL THEN 'SANS_VISITE'
             WHEN d.Dat_Prochaine_Visite < GETDATE() THEN 'ECHUE'
             WHEN d.Dat_Prochaine_Visite <= DATEADD(day, 30, GETDATE()) THEN 'PROCHE'
             ELSE 'A_VENIR' END AS Situation,
        COUNT(*) AS Effectif
FROM RH_Sante_Dossier d
WHERE ISNULL(d.Archive, 0) = 0
GROUP BY d.id_Societe, ISNULL(d.Statut_Aptitude_Courant, 'SANS_VISITE'),
        CASE WHEN d.Dat_Prochaine_Visite IS NULL THEN 'SANS_VISITE'
             WHEN d.Dat_Prochaine_Visite < GETDATE() THEN 'ECHUE'
             WHEN d.Dat_Prochaine_Visite <= DATEADD(day, 30, GETDATE()) THEN 'PROCHE'
             ELSE 'A_VENIR' END;
GO

IF OBJECT_ID('dbo.RH_Sante_Vue_Stats_AT', 'V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_Stats_AT;
GO
-- Statistiques mensuelles AT.
-- Taux de frequence = Nb AT avec arret x TAUX_FREQ_BASE / Heures travaillees
-- Taux de gravite   = Jours d'arret  x TAUX_GRAV_BASE / Heures travaillees
-- Les bases et la source des heures sont parametrees (Param_Sante_Reglement) et
-- les heures sont saisies/importees dans RH_Sante_Heures_Travaillees (auditable).
CREATE VIEW dbo.RH_Sante_Vue_Stats_AT AS
SELECT  t.id_Societe,
        YEAR(t.Dat_Accident) AS Annee,
        MONTH(t.Dat_Accident) AS Mois,
        COUNT(*) AS Nb_Accidents,
        SUM(CASE WHEN ISNULL(t.Typ_Accident, 'TRAVAIL') = 'TRAJET' THEN 1 ELSE 0 END) AS Nb_Trajet,
        SUM(CASE WHEN ISNULL(t.Typ_Accident, 'TRAVAIL') = 'TRAVAIL' THEN 1 ELSE 0 END) AS Nb_Travail,
        ISNULL(SUM(j.Nb_Avec_Arret), 0) AS Nb_Avec_Arret,
        ISNULL(SUM(j.Jours_Arret), 0) AS Jours_Arret,
        h.Heures AS Heures_Travaillees,
        CASE WHEN ISNULL(h.Heures, 0) > 0
             THEN CAST(ISNULL(SUM(j.Nb_Avec_Arret), 0) * ISNULL(bf.Base_Freq, 1000000) / h.Heures AS decimal(18, 2))
             ELSE NULL END AS Taux_Frequence,
        CASE WHEN ISNULL(h.Heures, 0) > 0
             THEN CAST(ISNULL(SUM(j.Jours_Arret), 0) * ISNULL(bg.Base_Grav, 1000) / h.Heures AS decimal(18, 2))
             ELSE NULL END AS Taux_Gravite
FROM RH_Declaration_AT t
OUTER APPLY (
    SELECT CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS Nb_Avec_Arret, ISNULL(SUM(d.Nbr_Jours), 0) AS Jours_Arret
    FROM RH_Declaration_AT_Detail d
    WHERE d.Num_Declaration = t.Num_Declaration AND d.id_Societe = t.id_Societe
      AND ISNULL(d.Valide, 0) = 1 AND d.Dat_Debut_Arret IS NOT NULL
) j
LEFT JOIN RH_Sante_Heures_Travaillees h
       ON h.id_Societe = t.id_Societe AND h.Annee = YEAR(t.Dat_Accident) AND h.Mois = MONTH(t.Dat_Accident)
OUTER APPLY (
    SELECT TRY_CAST(ISNULL((SELECT TOP 1 Valeur FROM Param_Sante_Reglement
                            WHERE Cod_Param = 'TAUX_FREQ_BASE' AND id_Societe IN (t.id_Societe, -1)
                            ORDER BY CASE WHEN id_Societe = -1 THEN 1 ELSE 0 END), '1000000') AS float) AS Base_Freq
) bf
OUTER APPLY (
    SELECT TRY_CAST(ISNULL((SELECT TOP 1 Valeur FROM Param_Sante_Reglement
                            WHERE Cod_Param = 'TAUX_GRAV_BASE' AND id_Societe IN (t.id_Societe, -1)
                            ORDER BY CASE WHEN id_Societe = -1 THEN 1 ELSE 0 END), '1000') AS float) AS Base_Grav
) bg
WHERE ISNULL(t.Typ_Accident, 'TRAVAIL') <> 'NREC'
GROUP BY t.id_Societe, YEAR(t.Dat_Accident), MONTH(t.Dat_Accident), h.Heures, bf.Base_Freq, bg.Base_Grav;
GO

/* -------------------------------------------------------------------------- */
/* 4. Fonctions et procedures Sys_Sante_*                                      */
/* -------------------------------------------------------------------------- */

IF OBJECT_ID('dbo.Sys_Sante_Param', 'FN') IS NOT NULL DROP FUNCTION dbo.Sys_Sante_Param;
GO
-- Lecture d'un parametre reglementaire : valeur de la societe prioritaire sur la globale (-1)
CREATE FUNCTION dbo.Sys_Sante_Param(@Cod_Param nvarchar(50), @id_Societe int)
RETURNS nvarchar(250)
AS
BEGIN
    DECLARE @Valeur nvarchar(250);
    SELECT TOP 1 @Valeur = Valeur
    FROM Param_Sante_Reglement
    WHERE Cod_Param = @Cod_Param AND id_Societe IN (@id_Societe, -1)
      AND (Dat_Deb_Effet IS NULL OR Dat_Deb_Effet <= GETDATE())
      AND (Dat_Fin_Effet IS NULL OR Dat_Fin_Effet >= GETDATE())
    ORDER BY CASE WHEN id_Societe = -1 THEN 1 ELSE 0 END;
    RETURN @Valeur;
END
GO

IF OBJECT_ID('dbo.Sys_Sante_Prochaine_Visite', 'IF') IS NOT NULL DROP FUNCTION dbo.Sys_Sante_Prochaine_Visite;
GO
-- Calcule la prochaine echeance de visite selon les regles applicables a l'agent.
-- Arbitrage : 'MIN' (defaut, principe de precaution : echeance la plus proche)
--             ou 'PRIORITE' (regle applicable de plus haute priorite).
CREATE FUNCTION dbo.Sys_Sante_Prochaine_Visite(@Matricule nvarchar(20), @id_Societe int, @Dat_Visite datetime)
RETURNS TABLE
AS
RETURN
(
    WITH Regles AS (
        SELECT  p.Cod_Regle, p.Periodicite_Mois, p.Priorite,
                DATEADD(month, p.Periodicite_Mois, @Dat_Visite) AS Echeance
        FROM Param_Sante_Periodicite p
        OUTER APPLY (SELECT Cod_Poste, Dat_Naissance FROM RH_Agent
                     WHERE Matricule = @Matricule AND id_Societe = @id_Societe) ag
        WHERE p.id_Societe IN (@id_Societe, -1)
          AND ISNULL(p.Actif, 0) = 1
          AND (p.Dat_Deb_Effet IS NULL OR p.Dat_Deb_Effet <= @Dat_Visite)
          AND (p.Dat_Fin_Effet IS NULL OR p.Dat_Fin_Effet >= @Dat_Visite)
          AND p.Periodicite_Mois IS NOT NULL
          AND (
                p.Critere = 'STANDARD'
             OR (p.Critere = 'POSTE' AND p.Valeur_Critere = ag.Cod_Poste)
             OR (p.Critere = 'POSTE_RISQUE' AND EXISTS (SELECT 1 FROM Param_Sante_Poste_Risque pr
                                                        WHERE pr.Cod_Poste = ag.Cod_Poste
                                                          AND pr.id_Societe IN (@id_Societe, -1)))
             OR (p.Critere = 'MINEUR' AND ag.Dat_Naissance IS NOT NULL AND DATEADD(year, 18, ag.Dat_Naissance) > @Dat_Visite)
             OR (p.Critere IN ('NUIT', 'ENCEINTE') AND EXISTS (SELECT 1 FROM RH_Sante_Agent_Critere c
                                                               WHERE c.Matricule = @Matricule AND c.id_Societe = @id_Societe
                                                                 AND c.Critere = p.Critere
                                                                 AND (c.Dat_Deb IS NULL OR c.Dat_Deb <= @Dat_Visite)
                                                                 AND (c.Dat_Fin IS NULL OR c.Dat_Fin >= @Dat_Visite)))
          )
    ),
    Choix AS (
        SELECT TOP 1 Cod_Regle, Echeance
        FROM Regles
        ORDER BY CASE WHEN ISNULL(dbo.Sys_Sante_Param('MODE_ARBITRAGE_PERIODICITE', @id_Societe), 'MIN') = 'PRIORITE'
                      THEN Priorite ELSE 0 END ASC,
                 Echeance ASC
    )
    SELECT Echeance AS Dat_Prochaine_Visite, Cod_Regle AS Cod_Regle_Appliquee FROM Choix
);
GO

IF OBJECT_ID('dbo.Sys_Sante_Maj_Dossier', 'P') IS NOT NULL DROP PROC dbo.Sys_Sante_Maj_Dossier;
GO
-- Met a jour les champs denormalises du dossier sante apres validation d'une visite.
CREATE PROC dbo.Sys_Sante_Maj_Dossier @Matricule nvarchar(20), @id_Societe int
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM RH_Sante_Dossier WHERE Matricule = @Matricule AND id_Societe = @id_Societe)
        INSERT INTO RH_Sante_Dossier (Matricule, id_Societe, Archive, Dat_Crea, Created_By)
        VALUES (@Matricule, @id_Societe, 0, GETDATE(), 'Sys_Sante');

    UPDATE d
    SET d.Dat_Derniere_Visite     = v.Dat_Derniere_Visite,
        d.Dat_Prochaine_Visite    = v.Dat_Prochaine_Visite,
        d.Statut_Aptitude_Courant = v.Statut_Aptitude,
        d.Dat_Modif               = GETDATE(),
        d.Modified_By             = 'Sys_Sante'
    FROM RH_Sante_Dossier d
    OUTER APPLY (
        SELECT TOP 1 Dat_Visite AS Dat_Derniere_Visite, Dat_Prochaine_Visite, Statut_Aptitude
        FROM RH_Sante_Visite s
        WHERE s.Matricule = @Matricule AND s.id_Societe = @id_Societe
          AND ISNULL(s.Statut, '') IN ('VA', 'SG')
        ORDER BY s.Dat_Visite DESC, s.Dat_Crea DESC
    ) v
    WHERE d.Matricule = @Matricule AND d.id_Societe = @id_Societe;
END
GO

IF OBJECT_ID('dbo.Sys_Sante_AT_Generer_Echeances', 'P') IS NOT NULL DROP PROC dbo.Sys_Sante_AT_Generer_Echeances;
GO
-- Genere l'echeancier reglementaire d'une declaration AT depuis Param_Sante_Etape_AT.
-- Point de depart : ACC = date accident, DEC = date de creation de la declaration,
-- GUER = date du certificat GUERISON valide (echeance calculee seulement si connue).
CREATE PROC dbo.Sys_Sante_AT_Generer_Echeances @Num_Declaration nvarchar(20), @id_Societe int
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Dat_Accident datetime, @Dat_Crea datetime, @Dat_Guerison datetime;
    SELECT @Dat_Accident = Dat_Accident, @Dat_Crea = Dat_Crea
    FROM RH_Declaration_AT WHERE Num_Declaration = @Num_Declaration AND id_Societe = @id_Societe;
    IF @Dat_Accident IS NULL RETURN;

    SELECT TOP 1 @Dat_Guerison = d.Dat_Certificat
    FROM RH_Declaration_AT_Detail d
    WHERE d.Num_Declaration = @Num_Declaration AND d.id_Societe = @id_Societe
      AND d.Typ_Certificat = 'GUERISON' AND ISNULL(d.Valide, 0) = 1
    ORDER BY d.Dat_Certificat DESC;

    INSERT INTO RH_Declaration_AT_Echeance
        (Num_Declaration, id_Societe, Cod_Etape, Dat_Debut, Delai_Jours, Dat_Echeance, Statut_Etape, Dat_Crea, Created_By)
    SELECT  @Num_Declaration, @id_Societe, e.Cod_Etape,
            CASE e.Point_Depart WHEN 'ACC' THEN @Dat_Accident WHEN 'DEC' THEN @Dat_Crea WHEN 'GUER' THEN @Dat_Guerison ELSE @Dat_Accident END,
            e.Delai_Jours,
            DATEADD(day, ISNULL(e.Delai_Jours, 0),
                    CASE e.Point_Depart WHEN 'ACC' THEN @Dat_Accident WHEN 'DEC' THEN @Dat_Crea WHEN 'GUER' THEN @Dat_Guerison ELSE @Dat_Accident END),
            'AFA', GETDATE(), 'Sys_Sante'
    FROM Param_Sante_Etape_AT e
    WHERE e.id_Societe IN (@id_Societe, -1) AND ISNULL(e.Actif, 0) = 1
      AND NOT (e.Point_Depart = 'GUER' AND @Dat_Guerison IS NULL)
      AND NOT EXISTS (SELECT 1 FROM RH_Declaration_AT_Echeance x
                      WHERE x.Num_Declaration = @Num_Declaration AND x.id_Societe = @id_Societe
                        AND x.Cod_Etape = e.Cod_Etape AND ISNULL(x.Statut_Etape, '') <> 'ANN')
    ORDER BY e.Rang;
END
GO

IF OBJECT_ID('dbo.Sys_Sante_AT_Generer_Absence', 'P') IS NOT NULL DROP PROC dbo.Sys_Sante_AT_Generer_Absence;
GO
-- Genere l'absence (RH_Conge_Suivi) d'un certificat d'arret VALIDE, si le parametre
-- GENERER_ABSENCE_AT = 'O'. Type de conge parametrable (TYP_CONGE_AT, defaut 'CAT').
-- Anti-chevauchement via Sys_Conge_Check. Consolidation via Sys_Conge_MajConso.
CREATE PROC dbo.Sys_Sante_AT_Generer_Absence @RowId int
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Num_Declaration nvarchar(20), @id_Societe int, @Matricule nvarchar(20),
            @Dat_Deb smalldatetime, @Dat_Fin smalldatetime, @Num_Conge nvarchar(20),
            @Typ_Conge nvarchar(50), @Plan nvarchar(50), @JourPaie int;

    SELECT  @Num_Declaration = d.Num_Declaration, @id_Societe = d.id_Societe,
            @Dat_Deb = d.Dat_Debut_Arret, @Dat_Fin = d.Dat_Fin_Arret
    FROM RH_Declaration_AT_Detail d WHERE d.RowId = @RowId;
    IF @Dat_Deb IS NULL OR @Dat_Fin IS NULL RETURN;

    SELECT @Matricule = Matricule FROM RH_Declaration_AT
    WHERE Num_Declaration = @Num_Declaration AND id_Societe = @id_Societe;

    IF ISNULL(dbo.Sys_Sante_Param('GENERER_ABSENCE_AT', @id_Societe), 'N') <> 'O' RETURN;

    SET @Typ_Conge = ISNULL(dbo.Sys_Sante_Param('TYP_CONGE_AT', @id_Societe), 'CAT');
    SELECT @Plan = Plan_Paie FROM RH_Agent WHERE Matricule = @Matricule AND id_Societe = @id_Societe;
    SELECT @JourPaie = ISNULL(JourPaie, 1) FROM RH_Param_Plan_Paie WHERE Cod_Plan_Paie = @Plan AND id_Societe = @id_Societe;
    IF @JourPaie IS NULL SET @JourPaie = 1;

    -- Anti-chevauchement : ne pas generer si une absence existe deja sur la periode
    IF EXISTS (SELECT 1 FROM RH_Conge_Suivi s
               WHERE s.Matricule = @Matricule AND s.id_Societe = @id_Societe
                 AND ISNULL(s.Statut, '') IN ('', 'V')
                 AND ((@Dat_Fin BETWEEN s.Dat_Deb_Conge AND DATEADD(day, -1, s.Dat_Fin_Conge))
                   OR (@Dat_Deb BETWEEN s.Dat_Deb_Conge AND DATEADD(day, -1, s.Dat_Fin_Conge))
                   OR (s.Dat_Deb_Conge BETWEEN @Dat_Deb AND DATEADD(day, -1, @Dat_Fin))))
        RETURN;

    -- Numerotation identique au pattern demande_conge : 'C'+soc+'-'+annee+seq(6)
    SELECT @Num_Conge = 'C' + CONVERT(nvarchar(10), @id_Societe) + '-' + CONVERT(nvarchar(4), YEAR(GETDATE()))
           + RIGHT('000000' + CONVERT(nvarchar(6), ISNULL(MAX(CONVERT(int, racine)), 0) + 1), 6)
    FROM (SELECT CASE WHEN ISNUMERIC(ISNULL(RIGHT(Num_Conge, 6), '')) <> 1 THEN '0' ELSE RIGHT(Num_Conge, 6) END AS racine
          FROM RH_Conge_Suivi WHERE id_Societe = @id_Societe AND YEAR(Dat_Deb_Conge) = YEAR(GETDATE())) f;

    INSERT INTO RH_Conge_Suivi
        (Num_Conge, id_Societe, Matricule, Cod_Plan_Paie, JourPaie, Typ_Conge,
         Dat_Deb_Conge, Dat_Deb_Am_Pm, Dat_Fin_Conge, Dat_Fin_Am_Pm,
         Duree_Globale, Repos_Hebdomadaire, Jours_Feries, Duree_Conge,
         Commentaire, Statut, Dat_Crea, Created_By)
    VALUES
        (@Num_Conge, @id_Societe, @Matricule, @Plan, @JourPaie, @Typ_Conge,
         @Dat_Deb, 'am', @Dat_Fin, 'pm',
         DATEDIFF(day, @Dat_Deb, @Dat_Fin) + 1, 0, 0, DATEDIFF(day, @Dat_Deb, @Dat_Fin) + 1,
         'Arret AT ' + @Num_Declaration, 'V', GETDATE(), 'Sys_Sante');

    -- Detail decoupe par periode de paie (borne JourPaie du plan de paie)
    DECLARE @DebPer smalldatetime = @Dat_Deb,
            @FinPer smalldatetime;
    WHILE @DebPer <= @Dat_Fin
    BEGIN
        SET @FinPer = DATEADD(day, -1, DATEADD(month, 1,
                        DATEFROMPARTS(YEAR(@DebPer), MONTH(@DebPer), CASE WHEN @JourPaie > 28 AND MONTH(@DebPer) = 2 THEN 28 ELSE @JourPaie END)));
        IF @DebPer > @FinPer SET @FinPer = DATEADD(day, -1, DATEADD(month, 2, DATEFROMPARTS(YEAR(@DebPer), MONTH(@DebPer), 1)));
        IF @FinPer > @Dat_Fin SET @FinPer = @Dat_Fin;

        INSERT INTO RH_Conge_Suivi_Detail
            (Num_Conge, id_Societe, Matricule, Dat_Deb, Dat_Fin,
             Duree_Globale, Repos_Hebdomadaire, Jours_Feries, Duree_Conge, Flag_Maj, Dat_Crea, Created_By)
        VALUES
            (@Num_Conge, @id_Societe, @Matricule, @DebPer, @FinPer,
             DATEDIFF(day, @DebPer, @FinPer) + 1, 0, 0, DATEDIFF(day, @DebPer, @FinPer) + 1, 0, GETDATE(), 'Sys_Sante');

        SET @DebPer = DATEADD(day, 1, @FinPer);
    END

    UPDATE RH_Declaration_AT_Detail SET Num_Conge = @Num_Conge WHERE RowId = @RowId;
    EXEC Sys_Conge_MajConso @Matricule, @id_Societe;
END
GO

IF OBJECT_ID('dbo.Sys_Sante_Purge', 'P') IS NOT NULL DROP PROC dbo.Sys_Sante_Purge;
GO
-- Purge controlee selon les durees de conservation parametrees.
-- @Simuler = 1 (defaut) : compte les lignes candidates sans rien supprimer.
CREATE PROC dbo.Sys_Sante_Purge @id_Societe int, @Simuler bit = 1
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @AnsExamen int = TRY_CAST(ISNULL(dbo.Sys_Sante_Param('DUREE_CONSERVATION_EXAMEN_ANS', @id_Societe), '') AS int);
    IF @AnsExamen IS NULL RETURN;   -- pas de duree parametree : aucune purge

    DECLARE @Limite datetime = DATEADD(year, -@AnsExamen, GETDATE());

    IF @Simuler = 1
        SELECT 'RH_Sante_Examen' AS Table_Ref, COUNT(*) AS Lignes_Candidates
        FROM RH_Sante_Examen
        WHERE id_Societe = @id_Societe AND Dat_Limite_Conservation IS NOT NULL AND Dat_Limite_Conservation < GETDATE()
          AND ISNULL(Statut, '') <> 'GEL';
    ELSE
    BEGIN
        INSERT INTO RH_Sante_Audit_Acces (id_Societe, Login_User, Action, Objet, Valeur_Index, Succes, Motif)
        SELECT @id_Societe, 'Sys_Sante_Purge', 'SUPP', 'RH_Sante_Examen', Num_Examen, 1, 'Purge conservation'
        FROM RH_Sante_Examen
        WHERE id_Societe = @id_Societe AND Dat_Limite_Conservation IS NOT NULL AND Dat_Limite_Conservation < GETDATE()
          AND ISNULL(Statut, '') <> 'GEL';

        DELETE FROM RH_Sante_Examen
        WHERE id_Societe = @id_Societe AND Dat_Limite_Conservation IS NOT NULL AND Dat_Limite_Conservation < GETDATE()
          AND ISNULL(Statut, '') <> 'GEL';
    END
END
GO

/* -------------------------------------------------------------------------- */
/* 5. Rubriques                                                                */
/* -------------------------------------------------------------------------- */

DECLARE @rubriques TABLE (Nom_Controle nvarchar(100), Valeur nvarchar(50), Membre nvarchar(150), Rang int);
INSERT INTO @rubriques VALUES
-- Statuts d'aptitude
('Statut_Aptitude','APTE','Apte',1),('Statut_Aptitude','APTE_RES','Apte avec réserves',2),
('Statut_Aptitude','INAPTE_TEMP','Inapte temporaire',3),('Statut_Aptitude','INAPTE_DEF','Inapte définitif',4),
-- Types de visite
('Typ_Visite','EMB','Visite d''embauche',1),('Typ_Visite','PRD','Visite périodique',2),
('Typ_Visite','RPR','Visite de reprise',3),('Typ_Visite','SPO','Visite spontanée',4),
-- Criteres de periodicite
('Critere_Periodicite','STANDARD','Poste standard',1),('Critere_Periodicite','POSTE','Poste spécifique',2),
('Critere_Periodicite','POSTE_RISQUE','Poste à risque',3),('Critere_Periodicite','NUIT','Travail de nuit',4),
('Critere_Periodicite','ENCEINTE','Salariée enceinte',5),('Critere_Periodicite','MINEUR','Moins de 18 ans',6),
-- Campagnes / convocations
('Statut_Campagne','PRE','En préparation',1),('Statut_Campagne','ENC','En cours',2),('Statut_Campagne','CLO','Clôturée',3),
('Statut_Convocation','PRE','Planifiée',1),('Statut_Convocation','ENV','Envoyée',2),
('Statut_Convocation','RSA','Réalisée',3),('Statut_Convocation','ABS','Absente',4),('Statut_Convocation','REP','Reportée',5),
-- Infirmerie
('Typ_Acte_Infirmier','SOIN','Soin',1),('Typ_Acte_Infirmier','PANS','Pansement',2),
('Typ_Acte_Infirmier','URGE','Urgence',3),('Typ_Acte_Infirmier','CONS','Conseil / écoute',4),('Typ_Acte_Infirmier','VACC','Vaccination',5),
('Suite_Consultation','RET','Retour au poste',1),('Suite_Consultation','ARR','Arrêt de travail',2),
('Suite_Consultation','ORI','Orientation médicale',3),('Suite_Consultation','HOP','Evacuation / hôpital',4),
-- Examens
('Typ_Examen','BIO','Analyses biologiques',1),('Typ_Examen','RAD','Imagerie / radiologie',2),
('Typ_Examen','AUD','Audiométrie',3),('Typ_Examen','VIS','Visiotest / ophtalmologie',4),
('Typ_Examen','SPI','Spirométrie',5),('Typ_Examen','ECG','ECG',6),('Typ_Examen','AUTRE','Autre examen',7),
('Statut_Examen','PRE','Prescrit',1),('Statut_Examen','REA','Réalisé',2),('Statut_Examen','RES','Résultat reçu',3),
('Visibilite_Examen','MED','Médecin du travail',1),('Visibilite_Examen','AUT','Médecin prescripteur uniquement',2),
-- Maladies professionnelles
('Statut_Declaration_MP','DEC','Déclarée',1),('Statut_Declaration_MP','INS','En instruction',2),
('Statut_Declaration_MP','REC','Reconnue',3),('Statut_Declaration_MP','REF','Refusée',4),
-- Vaccinations
('Typ_Vaccin','GRI','Grippe',1),('Typ_Vaccin','TET','Tétanos',2),('Typ_Vaccin','HEPB','Hépatite B',3),('Typ_Vaccin','AUTRE','Autre',4),
-- Intervenants
('Typ_Intervenant','MED','Médecin du travail',1),('Typ_Intervenant','INF','Infirmier(ère)',2),
('Typ_Intervenant','LAB','Laboratoire',3),('Typ_Intervenant','CAB','Cabinet / centre',4),('Typ_Intervenant','PRV','Autre prestataire',5),
-- AT
('Typ_Accident','TRAVAIL','Accident du travail',1),('Typ_Accident','TRAJET','Accident de trajet',2),('Typ_Accident','NREC','Evénement non reconnu',3),
('Typ_Destinataire','ASS','Assureur',1),('Typ_Destinataire','AUT','Autorité du travail',2),
('Typ_Destinataire','CNSS','CNSS',3),('Typ_Destinataire','INT','Interne',4),('Typ_Destinataire','AUTRE','Autre',5),
('Mode_Transmission','MAIL','Email',1),('Mode_Transmission','COURRIER','Courrier',2),
('Mode_Transmission','REMISE','Remise en main propre',3),('Mode_Transmission','ENLIGNE','Télétransmission',4),
('Statut_Etape_AT','AFA','A faire',1),('Statut_Etape_AT','ENC','En cours',2),('Statut_Etape_AT','FAI','Fait',3),
('Statut_Etape_AT','DEP','Dépassé',4),('Statut_Etape_AT','ANN','Annulé',5),
('Point_Depart_Echeance','ACC','Date de l''accident',1),('Point_Depart_Echeance','DEC','Date de déclaration',2),
('Point_Depart_Echeance','GUER','Date de guérison',3),
('Statut_Rapport_Annuel','BROUILLON','Brouillon',1),('Statut_Rapport_Annuel','CONTROLE','Contrôlé',2),
('Statut_Rapport_Annuel','VALIDE','Validé',3),('Statut_Rapport_Annuel','TRANSMIS','Transmis',4),
-- Divers
('Niveau_Risque','FAIBLE','Faible',1),('Niveau_Risque','MODERE','Modéré',2),('Niveau_Risque','ELEVE','Elevé',3),
('Groupe_Sanguin','O+','O+',1),('Groupe_Sanguin','O-','O-',2),('Groupe_Sanguin','A+','A+',3),('Groupe_Sanguin','A-','A-',4),
('Groupe_Sanguin','B+','B+',5),('Groupe_Sanguin','B-','B-',6),('Groupe_Sanguin','AB+','AB+',7),('Groupe_Sanguin','AB-','AB-',8);

INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By)
SELECT r.Nom_Controle, r.Valeur, r.Membre, r.Rang, 'U', GETDATE(), 'SCRIPT'
FROM @rubriques r
WHERE NOT EXISTS (SELECT 1 FROM Param_Rubriques p WHERE p.Nom_Controle = r.Nom_Controle AND p.Valeur = r.Valeur);
GO

/* -------------------------------------------------------------------------- */
/* 6. Zooms                                                                    */
/* -------------------------------------------------------------------------- */

DELETE FROM Controle_Def_Zoom WHERE Num_Zoom IN ('MS300','MS301','MS302','MS303','MS304','MS305','MS306','MS307','AT010');
GO
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS300', 'RH_Sante_Visite', 'Num_Visite',
        'Matricule, Dat_Visite as [Date visite], dbo.FindRubrique(''Typ_Visite'',Typ_Visite) as [Type], dbo.FindRubrique(''Statut_Aptitude'',Statut_Aptitude) as [Aptitude], Dat_Prochaine_Visite as [Prochaine visite]',
        'Num_Visite <> ''''', 3, 1, 'Desc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS301', 'RH_Sante_Aptitude', 'Num_Aptitude',
        'Matricule, Dat_Aptitude as [Date], dbo.FindRubrique(''Statut_Aptitude'',Statut_Aptitude) as [Aptitude], Version, Dat_Fin as [Fin validité]',
        'Num_Aptitude <> ''''', 2, 1, 'Desc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS302', 'RH_Sante_Consultation', 'Num_Consultation',
        'Matricule, Dat_Consultation as [Date], dbo.FindRubrique(''Typ_Acte_Infirmier'',Typ_Acte) as [Acte], dbo.FindRubrique(''Suite_Consultation'',Suite) as [Suite]',
        'Num_Consultation <> ''''', 2, 1, 'Desc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS303', 'RH_Sante_Examen', 'Num_Examen',
        'Matricule, dbo.FindRubrique(''Typ_Examen'',Typ_Examen) as [Examen], Dat_Examen as [Date], dbo.FindRubrique(''Statut_Examen'',Statut_Examen) as [Statut]',
        'Num_Examen <> ''''', 3, 1, 'Desc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS304', 'RH_Sante_Maladie_Pro', 'Num_MP',
        'Matricule, Dat_Declaration as [Déclarée le], Pathologie, dbo.FindRubrique(''Statut_Declaration_MP'',Statut_Declaration) as [Statut]',
        'Num_MP <> ''''', 2, 1, 'Desc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS305', 'RH_Sante_Campagne', 'Cod_Campagne',
        'Lib_Campagne as [Campagne], Dat_Deb as [Du], Dat_Fin as [Au], dbo.FindRubrique(''Statut_Campagne'',Statut) as [Statut]',
        'Cod_Campagne <> ''''', 2, 1, 'Desc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS306', 'Param_Sante_Intervenant', 'Cod_Intervenant',
        'Nom + '' '' + isnull(Prenom,'''') as [Nom], dbo.FindRubrique(''Typ_Intervenant'',Typ_Intervenant) as [Type], Specialite as [Spécialité]',
        'isnull(Actif,''true'') = ''true''', 1, 1, 'Asc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS307', 'RH_Sante_Convocation', 'RowId',
        'Matricule, Dat_Convocation as [Date convocation], Heure, dbo.FindRubrique(''Statut_Convocation'',Statut_Convocation) as [Statut]',
        'Cod_Campagne = ''@@@', 2, 1, 'Asc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('AT010', 'RH_Declaration_AT', 'Num_Declaration',
        'Matricule, Dat_Accident as [Date accident], isnull(Typ_Accident,''TRAVAIL'') as [Type], Statut',
        'Num_Declaration <> ''''', 2, 1, 'Desc', 'false');
GO

/* -------------------------------------------------------------------------- */
/* 7. Definition des ecrans, boutons et securite avancee                       */
/* -------------------------------------------------------------------------- */

DECLARE @ecrans TABLE (Name_Ecran nvarchar(100), Table_Ref nvarchar(100), Index_Ecran nvarchar(100), Num_Zoom nvarchar(10), Index_Table nvarchar(100), PJ bit);
INSERT INTO @ecrans VALUES
('RH_Sante_Dossier',          'RH_Sante_Dossier',       'Matricule_txt',       'MS018', 'Matricule',       'true'),
('RH_Sante_Visite',           'RH_Sante_Visite',        'Num_Visite_txt',      'MS300', 'Num_Visite',      'true'),
('RH_Sante_Visite_Liste',     'RH_Sante_Visite',        'Num_Visite',          'MS300', 'Num_Visite',      'false'),
('RH_Sante_Aptitude',         'RH_Sante_Aptitude',      'Num_Aptitude_txt',    'MS301', 'Num_Aptitude',    'true'),
('RH_Sante_Aptitude_Liste',   'RH_Sante_Aptitude',      'Num_Aptitude',        'MS301', 'Num_Aptitude',    'false'),
('RH_Sante_Campagne',         'RH_Sante_Campagne',      'Cod_Campagne_txt',    'MS305', 'Cod_Campagne',    'false'),
('RH_Sante_Consultation',     'RH_Sante_Consultation',  'Num_Consultation_txt','MS302', 'Num_Consultation','true'),
('RH_Sante_Consultation_Liste','RH_Sante_Consultation', 'Num_Consultation',    'MS302', 'Num_Consultation','false'),
('RH_Sante_Examen',           'RH_Sante_Examen',        'Num_Examen_txt',      'MS303', 'Num_Examen',      'true'),
('RH_Sante_Examen_Liste',     'RH_Sante_Examen',        'Num_Examen',          'MS303', 'Num_Examen',      'false'),
('RH_Sante_Maladie_Pro',      'RH_Sante_Maladie_Pro',   'Num_MP_txt',          'MS304', 'Num_MP',          'true'),
('RH_Sante_Maladie_Pro_Liste','RH_Sante_Maladie_Pro',   'Num_MP',              'MS304', 'Num_MP',          'false'),
('RH_Sante_Vaccination',      'RH_Sante_Vaccination',   'Matricule_txt',       'MS018', 'Matricule',       'false'),
('RH_Sante_Tableau_Bord',     'RH_Sante_Dossier',       '',                    '',      '',                'false'),
('RH_Sante_Rapport_Annuel',   'RH_Sante_Dossier',       '',                    '',      '',                'true'),
('RH_Declaration_AT_Suivi',   'RH_Declaration_AT',      'Num_Declaration_txt', 'AT010', 'Num_Declaration', 'true'),
('RH_Sante_Stats_AT',         'RH_Declaration_AT',      '',                    '',      '',                'false'),
('RH_Sante_Param',            'Param_Sante_Reglement',  '',                    '',      '',                'false'),
('RH_Sante_Audit',            'RH_Sante_Audit_Acces',   '',                    '',      '',                'false');

INSERT INTO Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
SELECT e.Name_Ecran, e.Table_Ref, e.Index_Ecran, e.Num_Zoom, e.Index_Table, 'false', e.PJ, 'false', GETDATE(), 'SCRIPT'
FROM @ecrans e
WHERE NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran d WHERE d.Name_Ecran = e.Name_Ecran);
GO

-- Boutons standards des ecrans de saisie (Typ_Security='SC' sur les actions sensibles)
DECLARE @btns TABLE (Name_Ecran nvarchar(100), Cod_Button nvarchar(20), Lib_Button nvarchar(50), ProcName nvarchar(50), Img nvarchar(30), Rang int, Typ_Security nvarchar(5));
INSERT INTO @btns VALUES
('RH_Sante_Visite','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Visite','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Visite','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Sante_Visite','Valide_D','Valider','Valider','btn_validate',4,'SC'),
('RH_Sante_Aptitude','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Aptitude','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Aptitude','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Sante_Aptitude','Valide_D','Valider','Valider','btn_validate',4,'SC'),
('RH_Sante_Aptitude','Rectif_D','Nouvelle version','NouvelleVersion','btn_duplicate',5,'SC'),
('RH_Sante_Campagne','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Campagne','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Campagne','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Sante_Campagne','Generer_D','Générer convocations','GenererConvocations','btn_request',4,'SC'),
('RH_Sante_Consultation','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Consultation','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Consultation','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Sante_Examen','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Examen','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Examen','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Sante_Maladie_Pro','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Maladie_Pro','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Maladie_Pro','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Sante_Vaccination','New_D','Nouveau','Nouveau','btn_add',1,''),
('RH_Sante_Vaccination','Save_D','Enregistrer','Enregistrer','btn_save',2,'SC'),
('RH_Sante_Vaccination','Del_D','Supprimer','Deleting','btn_delete',3,'SC'),
('RH_Declaration_AT_Suivi','Save_D','Enregistrer','Enregistrer','btn_save',1,'SC'),
('RH_Declaration_AT_Suivi','Generer_D','Générer échéancier','GenererEcheancier','btn_request',2,'SC'),
('RH_Sante_Param','Save_D','Enregistrer','Enregistrer','btn_save',1,'SC'),
('RH_Sante_Rapport_Annuel','Controle_D','Contrôler les données','ControlerDonnees','btn_request',1,''),
('RH_Sante_Rapport_Annuel','Valide_D','Valider','Valider','btn_validate',2,'SC');

INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security)
SELECT b.Name_Ecran, b.Cod_Button, b.Lib_Button, b.ProcName, b.Img, 25, 25, b.Rang, b.Typ_Security
FROM @btns b
WHERE NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button x WHERE x.Name_Ecran = b.Name_Ecran AND x.Cod_Button = b.Cod_Button);
GO

-- (Le miroir Controle_Menu_Avance est insere en section 10bis, apres les menus :
--  la FK FK_Controle_Menu_Avance_Controle_Menu exige le menu prealable.)
GO

/* -------------------------------------------------------------------------- */
/* 8. Workflow : types de document (Typ_Document limite a 2 caracteres)        */
/* -------------------------------------------------------------------------- */

IF NOT EXISTS (SELECT 1 FROM Param_Workflow_Typ_Document WHERE Typ_Document = 'VM')
    INSERT INTO Param_Workflow_Typ_Document
        (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
    VALUES
        ('VM', 'Visite médicale', 'RH_Sante_Visite', 'Num_Visite', 'false', 'RH_Sante_Visite', 'Num_Visite_txt', 'Matricule', -1);

IF NOT EXISTS (SELECT 1 FROM Param_Workflow_Typ_Document WHERE Typ_Document = 'FA')
    INSERT INTO Param_Workflow_Typ_Document
        (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
    VALUES
        ('FA', 'Fiche d''aptitude', 'RH_Sante_Aptitude', 'Num_Aptitude', 'false', 'RH_Sante_Aptitude', 'Num_Aptitude_txt', 'Matricule', -1);
GO

/* -------------------------------------------------------------------------- */
/* 9. Fonctions de securite (cloisonnement des domaines)                       */
/*    L'affectation aux profils se fait via Admin_Profile - aucune attribution */
/*    par defaut : personne n'a acces tant que ce n'est pas accorde.           */
/* -------------------------------------------------------------------------- */

IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Functions WHERE Function_Sec = 'SANTE_CLINIQUE')
    INSERT INTO Controle_Menu_Functions (Function_Sec, Description, Ecrans)
    VALUES ('SANTE_CLINIQUE', 'Accès au contenu médical (clinique)',
            ';RH_Sante_Dossier;RH_Sante_Visite;RH_Sante_Visite_Liste;RH_Sante_Consultation;RH_Sante_Consultation_Liste;RH_Sante_Examen;RH_Sante_Examen_Liste;RH_Sante_Maladie_Pro;RH_Sante_Maladie_Pro_Liste;RH_Sante_Vaccination;');
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Functions WHERE Function_Sec = 'SANTE_ADMIN')
    INSERT INTO Controle_Menu_Functions (Function_Sec, Description, Ecrans)
    VALUES ('SANTE_ADMIN', 'Accès au médico-administratif (aptitude publiée, campagnes, agrégats)',
            ';RH_Sante_Aptitude;RH_Sante_Aptitude_Liste;RH_Sante_Campagne;RH_Sante_Tableau_Bord;RH_Sante_Rapport_Annuel;RH_Declaration_AT_Suivi;RH_Sante_Stats_AT;');
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Functions WHERE Function_Sec = 'SANTE_AUDIT')
    INSERT INTO Controle_Menu_Functions (Function_Sec, Description, Ecrans)
    VALUES ('SANTE_AUDIT', 'Consultation du journal d''accès aux données de santé',
            ';RH_Sante_Audit;');
GO

/* -------------------------------------------------------------------------- */
/* 10. Menus : dossier "Santé au travail" sous le dossier gestion administrative */
/* -------------------------------------------------------------------------- */

IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran = 'FDR1_20268010900000')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj, Created_By, Dat_Crea)
    VALUES ('FDR1_20268010900000', 'Santé au travail', 'FDR', 'FDR1_20197231657389', 'FDR', NULL, 9, 1, 63505, 'SCRIPT', GETDATE());
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran = 'FDR1_20268010900000')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
    VALUES ('FDR1_20268010900000', 'Santé au travail', 'FDR', 'FDR', NULL, 9, NULL, NULL, 63505, 1, NULL, NULL, NULL);
GO

DECLARE @menus TABLE (Name_Ecran nvarchar(100), Text_Ecran nvarchar(150), Rang int);
INSERT INTO @menus VALUES
('RH_Sante_Dossier',           'Dossier santé de l''agent',       0),
('RH_Sante_Visite_Liste',      'Visites médicales',               1),
('RH_Sante_Visite',            'Visite médicale (fiche)',         2),
('RH_Sante_Aptitude_Liste',    'Fiches d''aptitude',              3),
('RH_Sante_Aptitude',          'Fiche d''aptitude (fiche)',       4),
('RH_Sante_Campagne',          'Campagnes et convocations',       5),
('RH_Sante_Consultation_Liste','Infirmerie (consultations/soins)',6),
('RH_Sante_Consultation',      'Consultation / soin (fiche)',     7),
('RH_Sante_Examen_Liste',      'Examens complémentaires',         8),
('RH_Sante_Examen',            'Examen complémentaire (fiche)',   9),
('RH_Sante_Maladie_Pro_Liste', 'Maladies professionnelles',       10),
('RH_Sante_Maladie_Pro',       'Maladie professionnelle (fiche)', 11),
('RH_Sante_Vaccination',       'Vaccinations',                    12),
('RH_Declaration_AT_Suivi',    'Suivi réglementaire AT',          13),
('RH_Sante_Stats_AT',          'Statistiques AT',                 14),
('RH_Sante_Tableau_Bord',      'Tableau de bord santé',           15),
('RH_Sante_Rapport_Annuel',    'Rapport annuel médecine du travail', 16),
('RH_Sante_Param',             'Paramètres et référentiels santé',17),
('RH_Sante_Audit',             'Audit des accès (données de santé)', 18);

-- Rejouable : purge des entrees du dossier avant reinsertion (rangs coherents)
DELETE FROM Controle_TreeView WHERE Parent = 'FDR1_20268010900000';
DELETE FROM Controle_Menu WHERE Name_Ecran IN (SELECT Name_Ecran FROM @menus);

INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj, Created_By, Dat_Crea)
SELECT m.Name_Ecran, m.Text_Ecran, 'ECR', 'FDR1_20268010900000', 'Form', NULL, m.Rang, 1, 1526879, 'SCRIPT', GETDATE()
FROM @menus m
WHERE NOT EXISTS (SELECT 1 FROM Controle_TreeView t WHERE t.Name_Ecran = m.Name_Ecran);

INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
SELECT m.Name_Ecran, m.Text_Ecran, 'ECR', 'ECR', NULL, m.Rang, NULL, NULL, 1526879, 1, NULL, NULL, NULL
FROM @menus m
WHERE NOT EXISTS (SELECT 1 FROM Controle_Menu t WHERE t.Name_Ecran = m.Name_Ecran);
GO

/* -------------------------------------------------------------------------- */
/* 10bis. Miroir securite avancee (apres les menus : FK vers Controle_Menu)    */
/* -------------------------------------------------------------------------- */
INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
SELECT b.Name_Ecran, b.Cod_Button, b.Lib_Button, 'STD_Btn', b.Typ_Security, 1, b.Lib_Button, 'S', 1526879
FROM (SELECT 'RH_Sante_Visite' AS Name_Ecran, 'Save_D' AS Cod_Button, 'Enregistrer' AS Lib_Button, 'SC' AS Typ_Security
      UNION ALL SELECT 'RH_Sante_Visite','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Sante_Visite','Valide_D','Valider','SC'
      UNION ALL SELECT 'RH_Sante_Aptitude','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Aptitude','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Sante_Aptitude','Valide_D','Valider','SC'
      UNION ALL SELECT 'RH_Sante_Aptitude','Rectif_D','Nouvelle version','SC'
      UNION ALL SELECT 'RH_Sante_Campagne','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Campagne','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Sante_Campagne','Generer_D','Générer convocations','SC'
      UNION ALL SELECT 'RH_Sante_Consultation','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Consultation','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Sante_Examen','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Examen','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Sante_Maladie_Pro','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Maladie_Pro','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Sante_Vaccination','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Vaccination','Del_D','Supprimer','SC'
      UNION ALL SELECT 'RH_Declaration_AT_Suivi','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Declaration_AT_Suivi','Generer_D','Générer échéancier','SC'
      UNION ALL SELECT 'RH_Sante_Param','Save_D','Enregistrer','SC'
      UNION ALL SELECT 'RH_Sante_Rapport_Annuel','Valide_D','Valider','SC') b
WHERE NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance x WHERE x.Name_Ecran = b.Name_Ecran AND x.Name_Controle = b.Cod_Button);
GO

/* -------------------------------------------------------------------------- */
/* 11. Audit espion sur les tables du module (triggers ESP_* generes)          */
/* -------------------------------------------------------------------------- */

DECLARE @audits TABLE (Cod_Audit nvarchar(50), Table_Name nvarchar(100), Col_Audit_Upd nvarchar(500), Col_Audit_Ins nvarchar(500), Col_Audit_Del nvarchar(500));
INSERT INTO @audits VALUES
('SANTE_VISITE',  'RH_Sante_Visite',  'Statut_Aptitude;Dat_Prochaine_Visite;Conclusion;Statut', 'Num_Visite', 'Num_Visite'),
('SANTE_APTITUDE','RH_Sante_Aptitude','Statut_Aptitude;Restrictions_Poste;Publie_RH;Statut', 'Num_Aptitude', 'Num_Aptitude'),
('SANTE_EXAMEN',  'RH_Sante_Examen',  'Statut_Examen;Dat_Resultat;Resultat_Resume;FD_Resultat', 'Num_Examen', 'Num_Examen'),
('SANTE_DOSSIER', 'RH_Sante_Dossier', 'Antecedents;Observations;Groupe_Sanguin', 'Matricule', 'Matricule'),
('SANTE_MP',      'RH_Sante_Maladie_Pro', 'Statut_Declaration;Pathologie', 'Num_MP', 'Num_MP'),
('SANTE_CONSULT', 'RH_Sante_Consultation', 'Motif;Observations;Suite', 'Num_Consultation', 'Num_Consultation'),
('SANTE_AT_ECH',  'RH_Declaration_AT_Echeance', 'Statut_Etape;Dat_Realisation;FD_Preuve', 'RowId', 'RowId');

INSERT INTO Param_Audit_Espion (Cod_Audit, Table_Name, Col_Audit_Upd, Col_Audit_Ins, Col_Audit_Del, Audits_Espions, Dat_Crea, Created_By)
SELECT a.Cod_Audit, a.Table_Name, a.Col_Audit_Upd, a.Col_Audit_Ins, a.Col_Audit_Del, NULL, GETDATE(), 'SCRIPT'
FROM @audits a
WHERE NOT EXISTS (SELECT 1 FROM Param_Audit_Espion p WHERE p.Cod_Audit = a.Cod_Audit);

-- Generation des triggers (procedures du socle, cf. Audit\Param_Audit.vb)
IF OBJECT_ID('dbo.Sys_Generation_Audit_UPD', 'P') IS NOT NULL
BEGIN
    DECLARE @t nvarchar(100), @u nvarchar(500), @i nvarchar(500), @d nvarchar(500);
    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT Table_Name, Col_Audit_Upd, Col_Audit_Ins, Col_Audit_Del FROM @audits;
    OPEN cur;
    FETCH NEXT FROM cur INTO @t, @u, @i, @d;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF ISNULL(@u, '') <> '' EXEC Sys_Generation_Audit_UPD @t, @u;
        IF ISNULL(@i, '') <> '' EXEC Sys_Generation_Audit_INS @t, @i;
        IF ISNULL(@d, '') <> '' EXEC Sys_Generation_Audit_DEL @t, @d;
        FETCH NEXT FROM cur INTO @t, @u, @i, @d;
    END
    CLOSE cur; DEALLOCATE cur;
END
GO

/* -------------------------------------------------------------------------- */
/* 12. Parametres reglementaires                                               */
/*    REGLE : aucune valeur de delai legal n'est inseree. Les cles sont creees */
/*    VIDES avec leur source a verifier ; la valeur est saisie par             */
/*    l'organisation apres verification du texte en vigueur.                   */
/* -------------------------------------------------------------------------- */

DECLARE @params TABLE (Cod_Param nvarchar(50), Lib_Param nvarchar(150), Valeur nvarchar(250), Source_Reglementaire nvarchar(250));
INSERT INTO @params VALUES
('PERIODICITE_STANDARD_MOIS',      'Périodicité visite périodique standard (mois)', '', 'Code du travail, art. 304-331 - A VERIFIER'),
('DELAI_DECLARATION_AT_ASSUREUR',  'Délai de déclaration AT à l''assureur (jours)', '', 'Loi 18-12 réparation des AT - A VERIFIER'),
('DELAI_DECLARATION_AT_AUTORITE',  'Délai de déclaration AT à l''autorité (jours)', '', 'Loi 18-12 / Code du travail - A VERIFIER'),
('RAPPORT_ANNUEL_MODELE',          'Référence du modèle de rapport annuel validé',  '', 'Arrêté n° 3125-10 du 22/11/2010 - modèle à joindre et valider'),
('RAPPORT_ANNUEL_MOIS_ALERTE',     'Mois d''alerte de préparation du rapport annuel', '1', 'Paramètre produit'),
('CNDP_NUM_AUTORISATION',          'N° d''autorisation CNDP (données de santé)',    '', 'Loi 09-08 art. 21 - autorisation préalable CNDP (formulaire F112)'),
('CNDP_DATE_AUTORISATION',         'Date de l''autorisation CNDP',                '', 'Loi 09-08 - A VERIFIER'),
('BLOCAGE_PROD_SANS_CNDP',         'Bloquer la production sans autorisation CNDP (O/N)', 'O', 'Paramètre produit'),
('SEUIL_AGREGAT_MIN',              'Effectif minimal affiché dans les agrégats',    '5', 'Paramètre produit (anti-réidentification)'),
('DUREE_CONSERVATION_EXAMEN_ANS',  'Durée de conservation des examens (années)',    '', 'A définir avec le médecin du travail et la CNDP - A VERIFIER'),
('ACTIVER_VACCINATIONS',           'Activer le suivi des vaccinations (O/N)',       'N', 'Paramètre produit'),
('GENERER_ABSENCE_AT',             'Générer l''absence RH_Conge_Suivi à la validation d''un certificat AT (O/N)', 'N', 'Paramètre produit - activer après validation paie'),
('TYP_CONGE_AT',                   'Type de congé utilisé pour les arrêts AT',      'CAT', 'RH_Conge_Type (CAT = Accident de travail, existant)'),
('MODE_ARBITRAGE_PERIODICITE',     'Arbitrage des règles de périodicité (MIN/PRIORITE)', 'MIN', 'Paramètre produit'),
('TAUX_FREQ_BASE',                 'Base du taux de fréquence AT',                  '1000000', 'Paramètre produit (convention 10^6 heures)'),
('TAUX_GRAV_BASE',                 'Base du taux de gravité AT',                    '1000', 'Paramètre produit (convention 10^3 heures)'),
('HEURES_TRAVAILLEES_SOURCE',      'Source des heures travaillées (SAISIE/PAIE/POINTAGE)', 'SAISIE', 'Paramètre produit'),
('ALERTE_VISITE_J1',               'Alerte visite - seuil 1 (jours avant échéance)', '30', 'Paramètre produit'),
('ALERTE_VISITE_J2',               'Alerte visite - seuil 2 (jours avant échéance)', '15', 'Paramètre produit'),
('ALERTE_VISITE_J3',               'Alerte visite - seuil 3 (jours avant échéance)', '7',  'Paramètre produit'),
('ALERTE_AT_ETAPE_J',              'Alerte étape AT (jours avant échéance)',        '5',  'Paramètre produit');

INSERT INTO Param_Sante_Reglement (Cod_Param, id_Societe, Lib_Param, Valeur, Source_Reglementaire, Dat_Crea, Created_By)
SELECT p.Cod_Param, -1, p.Lib_Param, p.Valeur, p.Source_Reglementaire, GETDATE(), 'SCRIPT'
FROM @params p
WHERE NOT EXISTS (SELECT 1 FROM Param_Sante_Reglement x WHERE x.Cod_Param = p.Cod_Param AND x.id_Societe = -1);
GO

PRINT '=== Module Sante : installation terminee ===';
PRINT 'Actions restantes : Generation globale (Admin_TreeView), circuits Workflow VM/FA,';
PRINT 'affectation des fonctions SANTE_* aux profils, parametres reglementaires, Notifications.';
GO

/* -------------------------------------------------------------------------- */
/* 13. Editions Crystal Reports (gabarits a produire - voir Documentation      */
/*     07_Specifications_Rapports.md). Le bouton Imprimer apparait             */
/*     automatiquement sur les ecrans des que le .rpt est depose dans Reports. */
/* -------------------------------------------------------------------------- */

IF NOT EXISTS (SELECT 1 FROM Param_Mod_Edition WHERE Cod_Report = 'Sante_Fiche_Aptitude')
    INSERT INTO Param_Mod_Edition (Cod_Report, Nom_Report, Typ_Pie, parSociete, Portail, Typ_Modele_Edition, withPassword, Dat_Crea, Created_By)
    VALUES ('Sante_Fiche_Aptitude', 'Fiche d''aptitude médicale', '', 'true', 'true', 'A', 'false', GETDATE(), 'SCRIPT');
IF NOT EXISTS (SELECT 1 FROM Param_Mod_Edition WHERE Cod_Report = 'Sante_Rapport_Incident_AT')
    INSERT INTO Param_Mod_Edition (Cod_Report, Nom_Report, Typ_Pie, parSociete, Portail, Typ_Modele_Edition, withPassword, Dat_Crea, Created_By)
    VALUES ('Sante_Rapport_Incident_AT', 'Rapport d''incident - accident du travail', '', 'true', 'true', 'A', 'false', GETDATE(), 'SCRIPT');
IF NOT EXISTS (SELECT 1 FROM Param_Mod_Edition WHERE Cod_Report = 'Sante_Rapport_Annuel')
    INSERT INTO Param_Mod_Edition (Cod_Report, Nom_Report, Typ_Pie, parSociete, Portail, Typ_Modele_Edition, withPassword, Dat_Crea, Created_By)
    VALUES ('Sante_Rapport_Annuel', 'Rapport annuel du service médical du travail', '', 'true', 'false', 'A', 'false', GETDATE(), 'SCRIPT');
GO

IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Mod_Edition WHERE Name_Ecran = 'RH_Sante_Aptitude' AND Cod_Report = 'Sante_Fiche_Aptitude')
    INSERT INTO Controle_Def_Ecran_Mod_Edition (Name_Ecran, Cod_Report, Criteres)
    VALUES ('RH_Sante_Aptitude', 'Sante_Fiche_Aptitude', 'IDSOC:=GV_IDSOC;Num_Aptitude:=Num_Aptitude_txt');
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Mod_Edition WHERE Name_Ecran = 'RH_Declaration_AT_Suivi' AND Cod_Report = 'Sante_Rapport_Incident_AT')
    INSERT INTO Controle_Def_Ecran_Mod_Edition (Name_Ecran, Cod_Report, Criteres)
    VALUES ('RH_Declaration_AT_Suivi', 'Sante_Rapport_Incident_AT', 'IDSOC:=GV_IDSOC;Num_Declaration:=Num_Declaration_txt');
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Mod_Edition WHERE Name_Ecran = 'RH_Sante_Rapport_Annuel' AND Cod_Report = 'Sante_Rapport_Annuel')
    INSERT INTO Controle_Def_Ecran_Mod_Edition (Name_Ecran, Cod_Report, Criteres)
    VALUES ('RH_Sante_Rapport_Annuel', 'Sante_Rapport_Annuel', 'IDSOC:=GV_IDSOC;Annee:=Annee_txt');
GO
