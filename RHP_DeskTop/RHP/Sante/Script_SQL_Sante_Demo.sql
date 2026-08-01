/* ============================================================================
   RHP - Module Sante - DONNEES DE DEMONSTRATION (100% FICTIVES)
   Societe 3068 (DEMO). A executer APRES Script_SQL_Sante.sql.
   Rejouable : purge les donnees FICTIF* avant reinsertion.
   ATTENTION : les periodicites ci-dessous sont des valeurs de TEST, pas des
   valeurs legales. Les valeurs legales sont a parametrer par l'organisation.
   ============================================================================ */

SET NOCOUNT ON;
DECLARE @SOC int = 3068;
GO

/* 1. Agents fictifs ----------------------------------------------------------*/
DECLARE @SOC int = 3068;
DELETE FROM RH_Sante_Agent_Critere WHERE Matricule LIKE 'FICTIF%' AND id_Societe = @SOC;
DELETE FROM RH_Agent WHERE Matricule LIKE 'FICTIF%' AND id_Societe = @SOC;

INSERT INTO RH_Agent (Matricule, id_Societe, Nom_Agent, Prenom_Agent, Sexe, Dat_Naissance, Cod_Poste, Cod_Entite, Plan_Paie, Dat_Crea, Created_By) VALUES
('FICTIF001', @SOC, 'DEMO', 'Standard',   'H', '1990-05-12', 'STD', 'DG', 'PLP', GETDATE(), 'SCRIPT'),
('FICTIF002', @SOC, 'DEMO', 'PosteRisque','H', '1985-03-20', 'RSK', 'DG', 'PLP', GETDATE(), 'SCRIPT'),
('FICTIF003', @SOC, 'DEMO', 'Mineur',     'H', '2009-08-01', 'STD', 'DG', 'PLP', GETDATE(), 'SCRIPT'),
('FICTIF004', @SOC, 'DEMO', 'Enceinte',   'F', '1992-11-05', 'STD', 'DG', 'PLP', GETDATE(), 'SCRIPT'),
('FICTIF005', @SOC, 'DEMO', 'Nuit',       'H', '1988-01-25', 'STD', 'DG', 'PLP', GETDATE(), 'SCRIPT'),
('FICTIF006', @SOC, 'DEMO', 'SansVisite', 'H', '1995-06-30', 'STD', 'DG', 'PLP', GETDATE(), 'SCRIPT');
GO

/* 2. Intervenants fictifs -----------------------------------------------------*/
DECLARE @SOC int = 3068;
DELETE FROM Param_Sante_Intervenant WHERE Cod_Intervenant IN ('MED001','INF001','LAB001') AND id_Societe = @SOC;
INSERT INTO Param_Sante_Intervenant (Cod_Intervenant, id_Societe, Nom, Prenom, Typ_Intervenant, Specialite, Actif, Dat_Crea, Created_By) VALUES
('MED001', @SOC, 'FICTIF', 'Medecin',  'MED', 'Médecine du travail', 'true', GETDATE(), 'SCRIPT'),
('INF001', @SOC, 'FICTIF', 'Infirmier','INF', NULL, 'true', GETDATE(), 'SCRIPT'),
('LAB001', @SOC, 'FICTIF', 'Labo',     'LAB', 'Analyses médicales', 'true', GETDATE(), 'SCRIPT');
GO

/* 3. Regles de periodicite de demonstration (VALEURS FICTIVES DE TEST) ---------*/
DECLARE @SOC int = 3068;
DELETE FROM Param_Sante_Periodicite WHERE id_Societe = @SOC AND Cod_Regle LIKE 'REGLE[_]%';
DELETE FROM Param_Sante_Poste_Risque WHERE Cod_Poste = 'RSK' AND id_Societe = @SOC;

INSERT INTO Param_Sante_Periodicite (Cod_Regle, id_Societe, Lib_Regle, Critere, Valeur_Critere, Periodicite_Mois, Priorite, Dat_Deb_Effet, Actif, Source_Reglementaire, Dat_Crea, Created_By) VALUES
('REGLE_STD',     @SOC, 'Standard (démo)',        'STANDARD',     NULL, 24, 100, '2020-01-01', 'true', 'VALEUR DE TEST', GETDATE(), 'SCRIPT'),
('REGLE_RSK',     @SOC, 'Poste à risque (démo)',  'POSTE_RISQUE', NULL, 12, 20,  '2020-01-01', 'true', 'VALEUR DE TEST', GETDATE(), 'SCRIPT'),
('REGLE_MINEUR',  @SOC, 'Moins de 18 ans (démo)', 'MINEUR',       NULL, 12, 10,  '2020-01-01', 'true', 'VALEUR DE TEST', GETDATE(), 'SCRIPT'),
('REGLE_ENCEINTE',@SOC, 'Salariée enceinte (démo)','ENCEINTE',    NULL, 6,  5,   '2020-01-01', 'true', 'VALEUR DE TEST', GETDATE(), 'SCRIPT'),
('REGLE_NUIT',    @SOC, 'Travail de nuit (démo)', 'NUIT',         NULL, 12, 30,  '2020-01-01', 'true', 'VALEUR DE TEST', GETDATE(), 'SCRIPT');

INSERT INTO Param_Sante_Poste_Risque (Cod_Poste, id_Societe, Niveau_Risque, Expositions, Cod_Regle, Dat_Crea, Created_By)
VALUES ('RSK', @SOC, 'ELEVE', 'Bruit, poussières (démo)', 'REGLE_RSK', GETDATE(), 'SCRIPT');
GO

/* 4. Criteres medicaux temporaires (CLINIQUE - fictifs) -------------------------*/
DECLARE @SOC int = 3068;
INSERT INTO RH_Sante_Agent_Critere (Matricule, id_Societe, Critere, Dat_Deb, Dat_Fin, Cod_Medecin, Commentaire, Dat_Crea, Created_By) VALUES
('FICTIF004', @SOC, 'ENCEINTE', '2025-10-01', '2027-06-30', 'MED001', 'Critère déclaré (démo)', GETDATE(), 'SCRIPT'),
('FICTIF005', @SOC, 'NUIT',     '2020-01-01', NULL,         'MED001', 'Poste de nuit (démo)', GETDATE(), 'SCRIPT');
GO

/* 5. Dossiers sante (cres vides, alimentes par les tests) -----------------------*/
DECLARE @SOC int = 3068;
DELETE FROM RH_Sante_Dossier WHERE Matricule LIKE 'FICTIF%' AND id_Societe = @SOC;
INSERT INTO RH_Sante_Dossier (Matricule, id_Societe, Archive, Dat_Crea, Created_By)
SELECT Matricule, @SOC, 0, GETDATE(), 'SCRIPT' FROM RH_Agent WHERE Matricule LIKE 'FICTIF%' AND id_Societe = @SOC;
GO

PRINT '=== Donnees de demonstration Sante inserees (societe 3068, FICTIF*) ===';
GO
