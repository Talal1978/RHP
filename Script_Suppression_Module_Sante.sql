/* ============================================================================
   RHP - SUPPRESSION DU MODULE "Sante au travail"
   ----------------------------------------------------------------------------
   Supprime TOUTES les metadonnees du module (menus, ecrans, boutons, zooms,
   rubriques, workflow, audit, fonctions de securite, editions, parametres),
   les objets SQL (vues, fonctions, procedures, triggers ESP_*) et les
   21 TABLES DE DONNEES du module.

   PRESERVE (module Accident du travail - NE PAS TOUCHER) :
     - RH_Declaration_AT et RH_Declaration_AT_Detail : conservees
       INTEGRALEMENT, y compris les colonnes Typ_Accident et Num_Conge
       (colonnes inertes, non utilisees par le module AT)
     - Le zoom AT010 (sur RH_Declaration_AT)
     - La rubrique Typ_Accident

   IMPORTANT : action irreversible pour les tables de donnees.
   Faire une sauvegarde de la base avant execution.
   Execution manuelle : SSMS ou sqlcmd. Script idempotent (rejouable).
   ============================================================================ */

SET NOCOUNT ON;
GO

PRINT '=== Suppression du module Sante : debut ===';
GO

/* ----------------------------------------------------------------------------
   0. Rappel prealable : les absences AT generees par le module dans
      RH_Conge_Suivi sont tracees par RH_Declaration_AT_Detail.Num_Conge.
      La section 3 les regularise AVANT suppression des tables du module.
   ---------------------------------------------------------------------------- */

/* 1. Metadonnees framework -------------------------------------------------- */

-- Menus (dossier "Sante au travail" + tous ses ecrans, fiches comprises)
-- + filet de securite sur le libelle pour d'eventuelles entrees manuelles
DELETE FROM Controle_TreeView
WHERE Name_Ecran LIKE 'RH_Sante_%'
   OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000')
   OR Parent = 'FDR1_20268010900000'
   OR Text_Ecran = N'Santé au travail';
DELETE FROM Controle_Menu
WHERE Name_Ecran LIKE 'RH_Sante_%'
   OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000')
   OR Text_Ecran = N'Santé au travail';

-- Ecrans, boutons, editions attachees, securite avancee, droits
DELETE FROM Controle_Def_Ecran_Button      WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Menu_Avance           WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Def_Ecran_Mod_Edition WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Def_Ecran             WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Droit                 WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000');

-- Zooms propres au module : liste explicite + filet de securite sur Table_Ref
-- pour capter d'eventuels zooms crees manuellement sur les tables du module.
-- (AT010 conserve : il appartient a RH_Declaration_AT)
DELETE FROM Controle_Def_Zoom
WHERE Num_Zoom IN ('MS300','MS301','MS302','MS303','MS304','MS305','MS306','MS307')
   OR Table_Ref IN ('RH_Sante_Dossier','RH_Sante_Visite','RH_Sante_Aptitude','RH_Sante_Agent_Critere',
                    'RH_Sante_Campagne','RH_Sante_Convocation','RH_Sante_Consultation','RH_Sante_Examen',
                    'RH_Sante_Maladie_Pro','RH_Sante_Vaccination','RH_Sante_Audit_Acces',
                    'RH_Sante_Heures_Travaillees','RH_Sante_Rapport_Annuel',
                    'RH_Declaration_AT_Echeance','RH_Declaration_AT_Transmission',
                    'Param_Sante_Periodicite','Param_Sante_Intervenant','Param_Sante_Poste_Risque',
                    'Param_Sante_Reglement','Param_Sante_Destinataire','Param_Sante_Etape_AT');

-- Workflow : types de document du module + circuits eventuellement parametres
DELETE FROM Workflow_Signatures_Signataires WHERE Typ_Document IN ('VM','FA');
DELETE FROM Workflow_Signatures_Detail      WHERE Typ_Document IN ('VM','FA');
DELETE FROM Workflow_Signatures_Tables      WHERE Typ_Document IN ('VM','FA');
DELETE FROM Workflow_Signatures             WHERE Typ_Document IN ('VM','FA');
DELETE FROM Param_Workflow_Typ_Document     WHERE Typ_Document IN ('VM','FA');

-- Fonctions de securite du cloisonnement medical + leurs affectations profils
DELETE FROM Controle_Menu_Functions  WHERE Function_Sec IN ('SANTE_CLINIQUE','SANTE_ADMIN','SANTE_AUDIT');
DELETE FROM Controle_Droit_Functions WHERE Function_Sec IN ('SANTE_CLINIQUE','SANTE_ADMIN','SANTE_AUDIT');

-- Audit espion (les triggers ESP_* sont supprimes en section 2)
DELETE FROM Param_Audit_Espion WHERE Cod_Audit IN ('SANTE_VISITE','SANTE_APTITUDE','SANTE_EXAMEN','SANTE_DOSSIER','SANTE_MP','SANTE_CONSULT','SANTE_AT_ECH');

-- Rubriques du module (Typ_Accident conservee : colonne conservee sur RH_Declaration_AT)
DELETE FROM Param_Rubriques WHERE Nom_Controle IN (
 'Statut_Aptitude','Typ_Visite','Critere_Periodicite','Statut_Campagne','Statut_Convocation',
 'Typ_Acte_Infirmier','Suite_Consultation','Typ_Examen','Statut_Examen','Visibilite_Examen',
 'Statut_Declaration_MP','Typ_Vaccin','Typ_Intervenant','Typ_Destinataire',
 'Mode_Transmission','Statut_Etape_AT','Point_Depart_Echeance','Statut_Rapport_Annuel',
 'Niveau_Risque','Groupe_Sanguin');

-- Section "Sante" du menu portail (pages dynamiques Designer)
DELETE FROM Param_Rubriques WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = 'Sante';

-- Editions declarees du module
DELETE FROM Param_Mod_Edition WHERE Cod_Report IN ('Sante_Fiche_Aptitude','Sante_Rapport_Incident_AT','Sante_Rapport_Annuel');
GO

/* 2. Triggers d'audit generes (ESP_*) sur les tables du module --------------- */
DECLARE @sql nvarchar(max) = '';
SELECT @sql = @sql + 'IF OBJECT_ID(''' + QUOTENAME(t.name) + ''',''TR'') IS NOT NULL DROP TRIGGER ' + QUOTENAME(t.name) + ';' + CHAR(10)
FROM sys.triggers t
WHERE t.parent_id IN (OBJECT_ID('RH_Sante_Visite'),OBJECT_ID('RH_Sante_Aptitude'),OBJECT_ID('RH_Sante_Examen'),
                      OBJECT_ID('RH_Sante_Dossier'),OBJECT_ID('RH_Sante_Maladie_Pro'),OBJECT_ID('RH_Sante_Consultation'),
                      OBJECT_ID('RH_Declaration_AT_Echeance'))
  AND t.name LIKE 'ESP[_]%';
EXEC sp_executesql @sql;
GO

/* 3. Regularisation des absences AT generees par le module ------------------- */
/* Supprime UNIQUEMENT les absences que le module a generees dans              */
/* RH_Conge_Suivi (tracees par RH_Declaration_AT_Detail.Num_Conge), puis       */
/* reconsolide les soldes. Aucune autre donnee du module Conges n'est touchee. */
DECLARE @nb int;
SELECT @nb = COUNT(DISTINCT d.Num_Conge)
FROM RH_Declaration_AT_Detail d
WHERE ISNULL(d.Num_Conge, '') <> '';
PRINT 'Absences AT generees par le module a regulariser : ' + CONVERT(varchar(10), ISNULL(@nb, 0));

DECLARE @Mat nvarchar(20), @Soc int, @NumC nvarchar(20);
DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT DISTINCT d.Num_Conge, d.id_Societe, h.Matricule
    FROM RH_Declaration_AT_Detail d
    JOIN RH_Declaration_AT h ON h.Num_Declaration = d.Num_Declaration AND h.id_Societe = d.id_Societe
    WHERE ISNULL(d.Num_Conge, '') <> '';
OPEN cur;
FETCH NEXT FROM cur INTO @NumC, @Soc, @Mat;
WHILE @@FETCH_STATUS = 0
BEGIN
    DELETE FROM RH_Conge_Suivi_Detail WHERE Num_Conge = @NumC AND id_Societe = @Soc;
    DELETE FROM RH_Conge_Suivi WHERE Num_Conge = @NumC AND id_Societe = @Soc;
    EXEC Sys_Conge_MajConso @Mat, @Soc;
    FETCH NEXT FROM cur INTO @NumC, @Soc, @Mat;
END
CLOSE cur; DEALLOCATE cur;
UPDATE RH_Declaration_AT_Detail SET Num_Conge = NULL WHERE ISNULL(Num_Conge, '') <> '';
GO

/* 4. Objets SQL du module (procedures, fonctions, vues) ---------------------- */
IF OBJECT_ID('dbo.Sys_Sante_Purge','P') IS NOT NULL DROP PROC dbo.Sys_Sante_Purge;
IF OBJECT_ID('dbo.Sys_Sante_AT_Generer_Absence','P') IS NOT NULL DROP PROC dbo.Sys_Sante_AT_Generer_Absence;
IF OBJECT_ID('dbo.Sys_Sante_AT_Generer_Echeances','P') IS NOT NULL DROP PROC dbo.Sys_Sante_AT_Generer_Echeances;
IF OBJECT_ID('dbo.Sys_Sante_Maj_Dossier','P') IS NOT NULL DROP PROC dbo.Sys_Sante_Maj_Dossier;
IF OBJECT_ID('dbo.Sys_Sante_Prochaine_Visite','IF') IS NOT NULL DROP FUNCTION dbo.Sys_Sante_Prochaine_Visite;
IF OBJECT_ID('dbo.Sys_Sante_Param','FN') IS NOT NULL DROP FUNCTION dbo.Sys_Sante_Param;
IF OBJECT_ID('dbo.RH_Sante_Vue_Stats_AT','V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_Stats_AT;
IF OBJECT_ID('dbo.RH_Sante_Vue_TB_Aptitudes','V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_TB_Aptitudes;
IF OBJECT_ID('dbo.RH_Sante_Vue_Echeances','V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_Echeances;
IF OBJECT_ID('dbo.RH_Sante_Vue_Aptitude_RH','V') IS NOT NULL DROP VIEW dbo.RH_Sante_Vue_Aptitude_RH;
GO

/* 5. Tables de donnees du module (21 tables - ordre : dependantes d'abord) --- */
DROP TABLE IF EXISTS dbo.RH_Sante_Convocation;
DROP TABLE IF EXISTS dbo.RH_Sante_Campagne;
DROP TABLE IF EXISTS dbo.RH_Sante_Vaccination;
DROP TABLE IF EXISTS dbo.RH_Sante_Examen;
DROP TABLE IF EXISTS dbo.RH_Sante_Consultation;
DROP TABLE IF EXISTS dbo.RH_Sante_Maladie_Pro;
DROP TABLE IF EXISTS dbo.RH_Sante_Aptitude;
DROP TABLE IF EXISTS dbo.RH_Sante_Visite;
DROP TABLE IF EXISTS dbo.RH_Sante_Agent_Critere;
DROP TABLE IF EXISTS dbo.RH_Sante_Dossier;
DROP TABLE IF EXISTS dbo.RH_Declaration_AT_Transmission;
DROP TABLE IF EXISTS dbo.RH_Declaration_AT_Echeance;
DROP TABLE IF EXISTS dbo.RH_Sante_Rapport_Annuel;
DROP TABLE IF EXISTS dbo.RH_Sante_Heures_Travaillees;
DROP TABLE IF EXISTS dbo.RH_Sante_Audit_Acces;
DROP TABLE IF EXISTS dbo.Param_Sante_Etape_AT;
DROP TABLE IF EXISTS dbo.Param_Sante_Destinataire;
DROP TABLE IF EXISTS dbo.Param_Sante_Reglement;
DROP TABLE IF EXISTS dbo.Param_Sante_Poste_Risque;
DROP TABLE IF EXISTS dbo.Param_Sante_Intervenant;
DROP TABLE IF EXISTS dbo.Param_Sante_Periodicite;
GO

/* 6. Verification finale ----------------------------------------------------- */
DECLARE @reste int = 0;
SELECT @reste = @reste + COUNT(*) FROM sys.objects o
WHERE o.name LIKE 'RH_Sante_%' OR o.name LIKE 'Param_Sante_%' OR o.name LIKE 'Sys_Sante_%'
   OR o.name IN ('RH_Declaration_AT_Echeance','RH_Declaration_AT_Transmission');
SELECT @reste = @reste + COUNT(*) FROM Controle_Menu WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000') OR Text_Ecran = N'Santé au travail';
SELECT @reste = @reste + COUNT(*) FROM Controle_TreeView WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000') OR Parent = 'FDR1_20268010900000' OR Text_Ecran = N'Santé au travail';
SELECT @reste = @reste + COUNT(*) FROM Controle_Droit WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000');
SELECT @reste = @reste + COUNT(*) FROM Controle_Def_Ecran WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
SELECT @reste = @reste + COUNT(*) FROM Controle_Def_Zoom WHERE Num_Zoom IN ('MS300','MS301','MS302','MS303','MS304','MS305','MS306','MS307') OR Table_Ref LIKE 'RH_Sante_%' OR Table_Ref LIKE 'Param_Sante_%';
SELECT @reste = @reste + COUNT(*) FROM Controle_Menu_Functions WHERE Function_Sec IN ('SANTE_CLINIQUE','SANTE_ADMIN','SANTE_AUDIT');

IF @reste = 0
    PRINT '=== Module Sante : suppression terminee, aucun objet restant ===';
ELSE
    PRINT '=== ATTENTION : ' + CONVERT(varchar(10), @reste) + ' objet(s) Sante restant(s) - verifier ===';
GO

/* ----------------------------------------------------------------------------
   ANNEXE (optionnel) - Pieces jointes GED deposees sur les ecrans du module
   ----------------------------------------------------------------------------
   Des utilisateurs ont pu joindre des documents (GED) aux ecrans Sante.
   Pour recenser ces pieces jointes, executer :

   SELECT Name_Ecran, Value_Index, COUNT(*) AS Nb
   FROM <table_GED>           -- table des pieces jointes (cf. ged.ts)
   WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi'
   GROUP BY Name_Ecran, Value_Index;

   Leur suppression (en base ET sur le disque) est une decision d'exploitation :
   elle n'est PAS incluse dans ce script par precaution.
   ---------------------------------------------------------------------------- */
