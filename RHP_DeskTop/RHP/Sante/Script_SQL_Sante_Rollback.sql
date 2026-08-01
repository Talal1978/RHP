/* ============================================================================
   RHP - Module Sante - RETOUR ARRIERE
   ----------------------------------------------------------------------------
   Supprime les metadonnees du module (menus, ecrans, boutons, zooms, rubriques,
   workflow, audit, fonctions de securite, parametres) et les objets SQL.
   PAR DEFAUT : les tables de DONNEES sont conservees.
   Pour supprimer aussi les tables de donnees, executer avec :sqlcmd -v DROPDATA="1"
   (ou decommenter la section finale).
   ----------------------------------------------------------------------------
   Les absences AT generees dans RH_Conge_Suivi sont tracees par
   RH_Declaration_AT_Detail.Num_Conge : un script de regularisation est fourni
   en section 3 (suivi de Sys_Conge_MajConso).
   ============================================================================ */

SET NOCOUNT ON;
GO

/* 1. Metadonnees framework -------------------------------------------------- */
DELETE FROM Controle_TreeView WHERE Name_Ecran IN (
 'FDR1_20268010900000','RH_Sante_Dossier','RH_Sante_Visite_Liste','RH_Sante_Aptitude_Liste',
 'RH_Sante_Campagne','RH_Sante_Consultation_Liste','RH_Sante_Examen_Liste','RH_Sante_Maladie_Pro_Liste',
 'RH_Sante_Vaccination','RH_Declaration_AT_Suivi','RH_Sante_Stats_AT','RH_Sante_Tableau_Bord',
 'RH_Sante_Rapport_Annuel','RH_Sante_Param','RH_Sante_Audit');
DELETE FROM Controle_Menu WHERE Name_Ecran IN (
 'FDR1_20268010900000','RH_Sante_Dossier','RH_Sante_Visite_Liste','RH_Sante_Aptitude_Liste',
 'RH_Sante_Campagne','RH_Sante_Consultation_Liste','RH_Sante_Examen_Liste','RH_Sante_Maladie_Pro_Liste',
 'RH_Sante_Vaccination','RH_Declaration_AT_Suivi','RH_Sante_Stats_AT','RH_Sante_Tableau_Bord',
 'RH_Sante_Rapport_Annuel','RH_Sante_Param','RH_Sante_Audit');
DELETE FROM Controle_Def_Ecran_Button WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Menu_Avance WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Def_Ecran WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Def_Ecran_Mod_Edition WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran = 'RH_Declaration_AT_Suivi';
DELETE FROM Controle_Droit WHERE Name_Ecran LIKE 'RH_Sante_%' OR Name_Ecran IN ('RH_Declaration_AT_Suivi','FDR1_20268010900000');
DELETE FROM Controle_Def_Zoom WHERE Num_Zoom IN ('MS300','MS301','MS302','MS303','MS304','MS305','MS306','MS307','AT010');
DELETE FROM Param_Workflow_Typ_Document WHERE Typ_Document IN ('VM','FA');
DELETE FROM Controle_Menu_Functions WHERE Function_Sec IN ('SANTE_CLINIQUE','SANTE_ADMIN','SANTE_AUDIT');
DELETE FROM Controle_Droit_Functions WHERE Function_Sec IN ('SANTE_CLINIQUE','SANTE_ADMIN','SANTE_AUDIT');
DELETE FROM Param_Audit_Espion WHERE Cod_Audit IN ('SANTE_VISITE','SANTE_APTITUDE','SANTE_EXAMEN','SANTE_DOSSIER','SANTE_MP','SANTE_CONSULT','SANTE_AT_ECH');
DELETE FROM Param_Rubriques WHERE Nom_Controle IN (
 'Statut_Aptitude','Typ_Visite','Critere_Periodicite','Statut_Campagne','Statut_Convocation',
 'Typ_Acte_Infirmier','Suite_Consultation','Typ_Examen','Statut_Examen','Visibilite_Examen',
 'Statut_Declaration_MP','Typ_Vaccin','Typ_Intervenant','Typ_Accident','Typ_Destinataire',
 'Mode_Transmission','Statut_Etape_AT','Point_Depart_Echeance','Niveau_Risque','Groupe_Sanguin');
DELETE FROM Param_Sante_Reglement;
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

/* 3. Regularisation des absences AT generees (AVANT retrait du module) ------- */
/* Supprime les absences generees (tracees) puis reconsolide les soldes.        */
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

/* 4. Objets SQL du module ---------------------------------------------------- */
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

/* 5. Colonnes ajoutees aux tables existantes --------------------------------- */
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.RH_Declaration_AT_Detail') AND name = 'Num_Conge')
    ALTER TABLE dbo.RH_Declaration_AT_Detail DROP COLUMN Num_Conge;
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.RH_Declaration_AT') AND name = 'Typ_Accident')
    ALTER TABLE dbo.RH_Declaration_AT DROP COLUMN Typ_Accident;
GO

/* 6. Tables de donnees : CONSERVEES par defaut.                                */
/* Pour les supprimer, decommenter le bloc ci-dessous (action irreversible).    */
/*
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
DROP TABLE IF EXISTS dbo.RH_Sante_Heures_Travaillees;
DROP TABLE IF EXISTS dbo.RH_Sante_Audit_Acces;
DROP TABLE IF EXISTS dbo.Param_Sante_Etape_AT;
DROP TABLE IF EXISTS dbo.Param_Sante_Destinataire;
DROP TABLE IF EXISTS dbo.Param_Sante_Reglement;
DROP TABLE IF EXISTS dbo.Param_Sante_Poste_Risque;
DROP TABLE IF EXISTS dbo.Param_Sante_Intervenant;
DROP TABLE IF EXISTS dbo.Param_Sante_Periodicite;
*/
GO

PRINT '=== Module Sante : retour arriere termine (tables de donnees conservees) ===';
GO
