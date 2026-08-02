/* ============================================================================
   RHP - Module Sante - TESTS SQL (T01 a T19) - Donnees fictives societe 3068
   Execution : npx ts-node --transpile-only sante/run_tests.ts
   Rejouable : purge des artefacts TEST* au demarrage.
   ============================================================================ */
SET NOCOUNT ON;
DECLARE @SOC int = 3068;
IF OBJECT_ID('tempdb..##SanteTests') IS NOT NULL DROP TABLE ##SanteTests;
CREATE TABLE ##SanteTests (Cod_Test nvarchar(10), Resultat nvarchar(4), Detail nvarchar(400));
DECLARE @d datetime; DECLARE @regle nvarchar(20); DECLARE @nb int; DECLARE @f float;

/* ---------------- SETUP : purge des artefacts de tests ------------------- */
DELETE FROM RH_Sante_Visite WHERE Num_Visite LIKE 'TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Sante_Aptitude WHERE Num_Aptitude LIKE 'TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Declaration_AT_Echeance WHERE Num_Declaration LIKE 'AT-TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Declaration_AT_Transmission WHERE Num_Declaration LIKE 'AT-TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Declaration_AT_Detail WHERE Num_Declaration LIKE 'AT-TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Declaration_AT WHERE Num_Declaration LIKE 'AT-TEST%' AND id_Societe=@SOC;
DELETE FROM Param_Sante_Etape_AT WHERE Cod_Etape LIKE 'TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Sante_Examen WHERE Num_Examen LIKE 'TEST%' AND id_Societe=@SOC;
DELETE FROM RH_Sante_Heures_Travaillees WHERE id_Societe=@SOC;
DELETE FROM RH_Sante_Dossier WHERE Matricule LIKE 'FICTIF%' AND id_Societe=@SOC;
INSERT INTO RH_Sante_Dossier (Matricule, id_Societe, Archive, Dat_Crea, Created_By)
SELECT Matricule, @SOC, 0, GETDATE(), 'TEST' FROM RH_Agent WHERE Matricule LIKE 'FICTIF%' AND id_Societe=@SOC;
DELETE FROM RH_Conge_Suivi_Detail WHERE Num_Conge IN (SELECT Num_Conge FROM RH_Conge_Suivi WHERE Matricule LIKE 'FICTIF%' AND id_Societe=@SOC AND Commentaire LIKE 'Arret AT%');
DELETE FROM RH_Conge_Suivi WHERE Matricule LIKE 'FICTIF%' AND id_Societe=@SOC AND Commentaire LIKE 'Arret AT%';
UPDATE Param_Sante_Reglement SET Valeur='MIN' WHERE Cod_Param='MODE_ARBITRAGE_PERIODICITE' AND id_Societe=-1;
DELETE FROM Param_Sante_Reglement WHERE Cod_Param IN ('GENERER_ABSENCE_AT','DUREE_CONSERVATION_EXAMEN_ANS') AND id_Societe=@SOC;
UPDATE Param_Sante_Periodicite SET Periodicite_Mois=12, Priorite=30 WHERE Cod_Regle='REGLE_NUIT' AND id_Societe=@SOC;
UPDATE Param_Sante_Periodicite SET Dat_Fin_Effet=NULL WHERE Cod_Regle='REGLE_RSK' AND id_Societe=@SOC;
DELETE FROM Param_Sante_Periodicite WHERE Cod_Regle='REGLE_RSK2' AND id_Societe=@SOC;

/* T01 - Regle STANDARD : prochaine visite = visite + 24 mois ---------------- */
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF001', @SOC, '2026-01-01');
INSERT INTO ##SanteTests SELECT 'T01', CASE WHEN @d='2028-01-01' AND @regle='REGLE_STD' THEN 'OK' ELSE 'KO' END,
 'Attendu 2028-01-01/REGLE_STD, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');

/* T02 - Cumul : poste a risque -> arbitrage MIN (12 mois) ------------------- */
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF002', @SOC, '2026-01-01');
INSERT INTO ##SanteTests SELECT 'T02', CASE WHEN @d='2027-01-01' AND @regle='REGLE_RSK' THEN 'OK' ELSE 'KO' END,
 'Attendu 2027-01-01/REGLE_RSK, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');

/* T03 - Arbitrage PRIORITE vs MIN ------------------------------------------- */
UPDATE Param_Sante_Periodicite SET Periodicite_Mois=36, Priorite=1 WHERE Cod_Regle='REGLE_NUIT' AND id_Societe=@SOC;
SELECT @d=Dat_Prochaine_Visite FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF005', @SOC, '2026-01-01');
INSERT INTO ##SanteTests SELECT 'T03a', CASE WHEN @d='2028-01-01' THEN 'OK' ELSE 'KO' END,
 'MIN attendu 2028-01-01 (STD 24m), obtenu '+convert(nvarchar(10),@d,120);
UPDATE Param_Sante_Reglement SET Valeur='PRIORITE' WHERE Cod_Param='MODE_ARBITRAGE_PERIODICITE' AND id_Societe=-1;
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF005', @SOC, '2026-01-01');
INSERT INTO ##SanteTests SELECT 'T03b', CASE WHEN @d='2029-01-01' AND @regle='REGLE_NUIT' THEN 'OK' ELSE 'KO' END,
 'PRIORITE attendu 2029-01-01/REGLE_NUIT, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');
UPDATE Param_Sante_Reglement SET Valeur='MIN' WHERE Cod_Param='MODE_ARBITRAGE_PERIODICITE' AND id_Societe=-1;
UPDATE Param_Sante_Periodicite SET Periodicite_Mois=12, Priorite=30 WHERE Cod_Regle='REGLE_NUIT' AND id_Societe=@SOC;

/* T04 - Historisation des regles (dates d'effet) ----------------------------- */
UPDATE Param_Sante_Periodicite SET Dat_Fin_Effet='2026-06-30' WHERE Cod_Regle='REGLE_RSK' AND id_Societe=@SOC;
INSERT INTO Param_Sante_Periodicite (Cod_Regle, id_Societe, Lib_Regle, Critere, Periodicite_Mois, Priorite, Dat_Deb_Effet, Actif, Dat_Crea, Created_By)
VALUES ('REGLE_RSK2', @SOC, 'Poste a risque v2 (test)', 'POSTE_RISQUE', 18, 20, '2026-07-01', 'true', GETDATE(), 'TEST');
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF002', @SOC, '2026-01-15');
INSERT INTO ##SanteTests SELECT 'T04a', CASE WHEN @d='2027-01-15' AND @regle='REGLE_RSK' THEN 'OK' ELSE 'KO' END,
 'Avant changement attendu 2027-01-15/REGLE_RSK, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF002', @SOC, '2026-08-01');
INSERT INTO ##SanteTests SELECT 'T04b', CASE WHEN @d='2028-02-01' AND @regle='REGLE_RSK2' THEN 'OK' ELSE 'KO' END,
 'Apres changement attendu 2028-02-01/REGLE_RSK2, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');
DELETE FROM Param_Sante_Periodicite WHERE Cod_Regle='REGLE_RSK2' AND id_Societe=@SOC;
UPDATE Param_Sante_Periodicite SET Dat_Fin_Effet=NULL WHERE Cod_Regle='REGLE_RSK' AND id_Societe=@SOC;

/* T05 - Ajustement manuel avec motif (conserve) ------------------------------ */
INSERT INTO RH_Sante_Visite (Num_Visite, id_Societe, Matricule, Dat_Visite, Typ_Visite, Statut_Aptitude,
       Dat_Prochaine_Visite, Motif_Ajustement, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T05', @SOC, 'FICTIF001', '2026-01-10', 'PRD', 'APTE', '2027-06-30', 'Ajustement medecin (test)', '', GETDATE(), 'TEST');
SELECT @nb=COUNT(*) FROM RH_Sante_Visite WHERE Num_Visite='TEST-T05' AND id_Societe=@SOC AND ISNULL(Motif_Ajustement,'')<>'';
INSERT INTO ##SanteTests SELECT 'T05', CASE WHEN @nb=1 THEN 'OK' ELSE 'KO' END, 'Ajustement + motif conserves';

/* T06 - Rectification : nouvelle visite liee --------------------------------- */
INSERT INTO RH_Sante_Visite (Num_Visite, id_Societe, Matricule, Dat_Visite, Typ_Visite, Statut_Aptitude, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T06V', @SOC, 'FICTIF001', '2026-02-01', 'PRD', 'APTE', 'VA', GETDATE(), 'TEST');
INSERT INTO RH_Sante_Visite (Num_Visite, id_Societe, Matricule, Dat_Visite, Typ_Visite, Statut_Aptitude,
       Num_Visite_Rectifiee, Motif_Rectification, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T06R', @SOC, 'FICTIF001', '2026-02-01', 'PRD', 'APTE_RES', 'TEST-T06V', 'Erreur de saisie (test)', 'VA', GETDATE(), 'TEST');
SELECT @nb=COUNT(*) FROM RH_Sante_Visite WHERE Num_Visite='TEST-T06R' AND id_Societe=@SOC AND Num_Visite_Rectifiee='TEST-T06V' AND ISNULL(Motif_Rectification,'')<>'';
INSERT INTO ##SanteTests SELECT 'T06', CASE WHEN @nb=1 THEN 'OK' ELSE 'KO' END, 'Visite rectificative liee et motivee';

/* T07 - Maj dossier apres validation (agent dedie FICTIF006 pour rejouabilite) */
INSERT INTO RH_Sante_Visite (Num_Visite, id_Societe, Matricule, Dat_Visite, Typ_Visite, Statut_Aptitude, Dat_Prochaine_Visite, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T07', @SOC, 'FICTIF006', '2026-03-15', 'PRD', 'APTE_RES', '2028-03-15', 'VA', GETDATE(), 'TEST');
EXEC Sys_Sante_Maj_Dossier 'FICTIF006', @SOC;
SELECT @nb=COUNT(*) FROM RH_Sante_Dossier WHERE Matricule='FICTIF006' AND id_Societe=@SOC
  AND Dat_Derniere_Visite='2026-03-15' AND Statut_Aptitude_Courant='APTE_RES' AND Dat_Prochaine_Visite='2028-03-15';
INSERT INTO ##SanteTests SELECT 'T07', CASE WHEN @nb=1 THEN 'OK' ELSE 'KO' END, 'Dossier denormalise mis a jour';

/* T08 - Periodicites MINEUR et ENCEINTE --------------------------------------- */
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF003', @SOC, '2026-01-01');
INSERT INTO ##SanteTests SELECT 'T08a', CASE WHEN @d='2027-01-01' AND @regle='REGLE_MINEUR' THEN 'OK' ELSE 'KO' END,
 'MINEUR attendu 2027-01-01/REGLE_MINEUR, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');
SELECT @d=Dat_Prochaine_Visite, @regle=Cod_Regle_Appliquee FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF004', @SOC, '2026-01-01');
INSERT INTO ##SanteTests SELECT 'T08b', CASE WHEN @d='2026-07-01' AND @regle='REGLE_ENCEINTE' THEN 'OK' ELSE 'KO' END,
 'ENCEINTE attendu 2026-07-01/REGLE_ENCEINTE, obtenu '+convert(nvarchar(10),@d,120)+'/'+isnull(@regle,'NULL');

/* T09 - Vue agregee tableau de bord ------------------------------------------- */
SELECT @nb=ISNULL(SUM(Effectif),0) FROM RH_Sante_Vue_TB_Aptitudes WHERE id_Societe=@SOC;
INSERT INTO ##SanteTests SELECT 'T09', CASE WHEN @nb>=6 THEN 'OK' ELSE 'KO' END, 'Agregats dossiers fictifs = '+convert(nvarchar(10),@nb);

/* T10 - Generation echeancier AT ---------------------------------------------- */
INSERT INTO RH_Declaration_AT (Num_Declaration, id_Societe, Matricule, Dat_Accident, Statut, Dat_Crea, Created_By)
VALUES ('AT-TEST001', @SOC, 'FICTIF002', '2027-02-01', '', '2027-02-02', 'TEST');
INSERT INTO Param_Sante_Etape_AT (Cod_Etape, id_Societe, Lib_Etape, Rang, Delai_Jours, Point_Depart, Actif, Dat_Crea, Created_By)
VALUES ('TEST_ETAPE1', @SOC, 'Declaration assureur (test)', 1, 2, 'ACC', 'true', GETDATE(), 'TEST'),
       ('TEST_ETAPE2', @SOC, 'Declaration autorite (test)', 2, 5, 'DEC', 'true', GETDATE(), 'TEST');
EXEC Sys_Sante_AT_Generer_Echeances 'AT-TEST001', @SOC;
SELECT @nb=COUNT(*) FROM RH_Declaration_AT_Echeance WHERE Num_Declaration='AT-TEST001' AND id_Societe=@SOC;
SELECT @d=Dat_Echeance FROM RH_Declaration_AT_Echeance WHERE Num_Declaration='AT-TEST001' AND id_Societe=@SOC AND Cod_Etape='TEST_ETAPE1';
INSERT INTO ##SanteTests SELECT 'T10', CASE WHEN @nb=2 AND @d='2027-02-03' THEN 'OK' ELSE 'KO' END,
 'Echeances='+convert(nvarchar(3),@nb)+', ETAPE1='+convert(nvarchar(10),@d,120)+' (attendu 2027-02-03)';

/* T11 - Detection etape depassee ---------------------------------------------- */
INSERT INTO RH_Declaration_AT_Echeance (Num_Declaration, id_Societe, Cod_Etape, Dat_Debut, Delai_Jours, Dat_Echeance, Statut_Etape, Dat_Crea, Created_By)
VALUES ('AT-TEST001', @SOC, 'TEST_ETAPE_PASSEE', '2025-01-01', 2, '2025-01-03', 'AFA', GETDATE(), 'TEST');
SELECT @nb=COUNT(*) FROM RH_Declaration_AT_Echeance
WHERE id_Societe=@SOC AND ISNULL(Statut_Etape,'AFA') IN ('AFA','ENC') AND Dat_Echeance < GETDATE();
INSERT INTO ##SanteTests SELECT 'T11', CASE WHEN @nb>=1 THEN 'OK' ELSE 'KO' END, 'Etapes en retard detectees = '+convert(nvarchar(5),@nb);

/* T12 - Transmission + preuve -------------------------------------------------- */
INSERT INTO RH_Declaration_AT_Transmission (Num_Declaration, id_Societe, Cod_Destinataire, Dat_Transmission, Mode_Transmission, Reference, Dat_Crea, Created_By)
VALUES ('AT-TEST001', @SOC, 'ASSUR01', '2027-02-03', 'COURRIER', 'AR-12345 (test)', GETDATE(), 'TEST');
SELECT @nb=COUNT(*) FROM RH_Declaration_AT_Transmission WHERE Num_Declaration='AT-TEST001' AND id_Societe=@SOC;
INSERT INTO ##SanteTests SELECT 'T12', CASE WHEN @nb=1 THEN 'OK' ELSE 'KO' END, 'Transmission enregistree';

/* T13 - Generation absence (arret AT -> RH_Conge_Suivi) ------------------------ */
INSERT INTO Param_Sante_Reglement (Cod_Param, id_Societe, Lib_Param, Valeur, Dat_Crea, Created_By)
VALUES ('GENERER_ABSENCE_AT', @SOC, 'Generation absence AT (test)', 'O', GETDATE(), 'TEST');
INSERT INTO RH_Declaration_AT_Detail (Num_Declaration, id_Societe, Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Valide)
VALUES ('AT-TEST001', @SOC, 'INITIAL', '2027-02-20', '2027-02-20', '2027-03-10', 19, 'true');
DECLARE @RowId13 int = SCOPE_IDENTITY();
EXEC Sys_Sante_AT_Generer_Absence @RowId13;
DECLARE @NumC13 varchar(20);
SELECT @NumC13=Num_Conge FROM RH_Declaration_AT_Detail WHERE RowId=@RowId13;
SELECT @nb=COUNT(*) FROM RH_Conge_Suivi WHERE Num_Conge=@NumC13 AND id_Societe=@SOC AND Typ_Conge='CAT' AND Statut='V' AND Duree_Conge=19;
DECLARE @nbDet int, @j1 float, @j2 float;
SELECT @nbDet=COUNT(*) FROM RH_Conge_Suivi_Detail WHERE Num_Conge=@NumC13 AND id_Societe=@SOC;
SELECT @j1=SUM(CASE WHEN MONTH(Dat_Deb)=2 THEN Duree_Conge ELSE 0 END), @j2=SUM(CASE WHEN MONTH(Dat_Deb)=3 THEN Duree_Conge ELSE 0 END)
FROM RH_Conge_Suivi_Detail WHERE Num_Conge=@NumC13 AND id_Societe=@SOC;
INSERT INTO ##SanteTests SELECT 'T13', CASE WHEN @nb=1 AND @nbDet=2 AND @j1=9 AND @j2=10 THEN 'OK' ELSE 'KO' END,
 'Absence '+isnull(@NumC13,'NULL')+' : detail='+convert(nvarchar(3),isnull(@nbDet,0))+' lignes ('+convert(nvarchar(5),isnull(@j1,0))+'j/'+convert(nvarchar(5),isnull(@j2,0))+'j), attendu 2 lignes (9j/10j)';

/* T14 - Anti-chevauchement : pas de 2e absence -------------------------------- */
INSERT INTO RH_Declaration_AT_Detail (Num_Declaration, id_Societe, Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Valide)
VALUES ('AT-TEST001', @SOC, 'PROLONGATION', '2027-03-05', '2027-03-05', '2027-03-15', 11, 'true');
DECLARE @RowId14 int = SCOPE_IDENTITY();
EXEC Sys_Sante_AT_Generer_Absence @RowId14;
SELECT @nb=COUNT(*) FROM RH_Declaration_AT_Detail WHERE RowId=@RowId14 AND ISNULL(Num_Conge,'')='';
INSERT INTO ##SanteTests SELECT 'T14', CASE WHEN @nb=1 THEN 'OK' ELSE 'KO' END, 'Absence non generee sur chevauchement (attendu)';

/* T15 - Solde de conge non impacte par CAT ------------------------------------- */
SELECT @f=ISNULL(SUM(Conge_Pris),0) FROM RH_Conge WHERE Matricule='FICTIF002' AND id_Societe=@SOC AND Annee=2027;
INSERT INTO ##SanteTests SELECT 'T15', CASE WHEN ISNULL(@f,0)=0 THEN 'OK' ELSE 'KO' END,
 'Conge_Pris CAD 2027 = '+convert(nvarchar(10),isnull(@f,0))+' (doit rester 0 pour un arret CAT)';

/* T16 - Taux de frequence et gravite ------------------------------------------- */
INSERT INTO RH_Declaration_AT (Num_Declaration, id_Societe, Matricule, Dat_Accident, Statut, Dat_Crea, Created_By)
VALUES ('AT-TEST002', @SOC, 'FICTIF001', '2027-02-05', '', '2027-02-06', 'TEST');
INSERT INTO RH_Declaration_AT_Detail (Num_Declaration, id_Societe, Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Valide)
VALUES ('AT-TEST002', @SOC, 'INITIAL', '2027-02-10', '2027-02-10', '2027-02-19', 10, 'true');
INSERT INTO RH_Sante_Heures_Travaillees (Annee, Mois, id_Societe, Heures, Source, Dat_Crea, Created_By)
VALUES (2027, 2, @SOC, 10000, 'TEST', GETDATE(), 'TEST');
DECLARE @tf float, @tg float, @nj int;
SELECT @nj=Jours_Arret, @tf=Taux_Frequence, @tg=Taux_Gravite FROM RH_Sante_Vue_Stats_AT WHERE id_Societe=@SOC AND Annee=2027 AND Mois=2;
INSERT INTO ##SanteTests SELECT 'T16', CASE WHEN @nj=40 AND @tf=200 AND @tg=4 THEN 'OK' ELSE 'KO' END,
 'Jours='+convert(nvarchar(5),isnull(@nj,-1))+' (40), TF='+convert(nvarchar(10),isnull(@tf,-1))+' (200), TG='+convert(nvarchar(10),isnull(@tg,-1))+' (4)';

/* T17 - Versioning des aptitudes ------------------------------------------------ */
INSERT INTO RH_Sante_Aptitude (Num_Aptitude, id_Societe, Matricule, Dat_Aptitude, Statut_Aptitude, Dat_Effet, Version, Publie_RH, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T17A', @SOC, 'FICTIF001', '2026-01-10', 'APTE', '2026-01-10', 1, 'true', 'VA', GETDATE(), 'TEST');
INSERT INTO RH_Sante_Aptitude (Num_Aptitude, id_Societe, Matricule, Dat_Aptitude, Statut_Aptitude, Dat_Effet, Version, Num_Aptitude_Prec, Motif_Version, Publie_RH, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T17B', @SOC, 'FICTIF001', '2026-01-20', 'APTE_RES', '2026-01-20', 2, 'TEST-T17A', 'Rectification (test)', 'true', 'VA', GETDATE(), 'TEST');
SELECT @nb=COUNT(*) FROM RH_Sante_Vue_Aptitude_RH WHERE Matricule='FICTIF001' AND id_Societe=@SOC AND Num_Aptitude='TEST-T17B' AND Statut_Aptitude='APTE_RES';
INSERT INTO ##SanteTests SELECT 'T17', CASE WHEN @nb=1 THEN 'OK' ELSE 'KO' END, 'Vue RH expose la version 2 (rectificative)';

/* T18 - Comptages rapport annuel (visites par type) ----------------------------- */
DECLARE @c1 int, @c2 int;
SELECT @c1=COUNT(*) FROM RH_Sante_Visite WHERE id_Societe=@SOC AND YEAR(Dat_Visite)=2026;
SELECT @c2=ISNULL(SUM(nb),0) FROM (SELECT Typ_Visite, COUNT(*) as nb FROM RH_Sante_Visite WHERE id_Societe=@SOC AND YEAR(Dat_Visite)=2026 GROUP BY Typ_Visite) x;
INSERT INTO ##SanteTests SELECT 'T18', CASE WHEN @c1=@c2 AND @c1>0 THEN 'OK' ELSE 'KO' END,
 'Total visites 2026='+convert(nvarchar(5),@c1)+' / somme par type='+convert(nvarchar(5),@c2);

/* T19 - Purge controlee des examens ---------------------------------------------- */
INSERT INTO Param_Sante_Reglement (Cod_Param, id_Societe, Lib_Param, Valeur, Dat_Crea, Created_By)
VALUES ('DUREE_CONSERVATION_EXAMEN_ANS', @SOC, 'Duree conservation (test)', '5', GETDATE(), 'TEST');
INSERT INTO RH_Sante_Examen (Num_Examen, id_Societe, Matricule, Typ_Examen, Dat_Examen, Statut_Examen, Dat_Limite_Conservation, Statut, Dat_Crea, Created_By)
VALUES ('TEST-T19', @SOC, 'FICTIF001', 'BIO', '2019-01-10', 'RES', '2024-01-10', '', GETDATE(), 'TEST');
DECLARE @cand int;
CREATE TABLE #cand (Table_Ref nvarchar(100), Lignes_Candidates int);
INSERT INTO #cand EXEC Sys_Sante_Purge @SOC, 1;
SELECT @cand=Lignes_Candidates FROM #cand;
EXEC Sys_Sante_Purge @SOC, 0;
SELECT @nb=COUNT(*) FROM RH_Sante_Examen WHERE Num_Examen='TEST-T19' AND id_Societe=@SOC;
DECLARE @aud int;
SELECT @aud=COUNT(*) FROM RH_Sante_Audit_Acces WHERE Objet='RH_Sante_Examen' AND Valeur_Index='TEST-T19' AND Action='SUPP';
INSERT INTO ##SanteTests SELECT 'T19', CASE WHEN @cand=1 AND @nb=0 AND @aud>=1 THEN 'OK' ELSE 'KO' END,
 'Candidats='+convert(nvarchar(3),isnull(@cand,-1))+', restant='+convert(nvarchar(3),@nb)+', audit='+convert(nvarchar(3),isnull(@aud,-1));
DROP TABLE #cand;

/* Nettoyage des parametres de test */
DELETE FROM Param_Sante_Reglement WHERE Cod_Param IN ('GENERER_ABSENCE_AT','DUREE_CONSERVATION_EXAMEN_ANS') AND id_Societe=@SOC;

/* ---------------- Rapport ---------------- */
SELECT Cod_Test, Resultat, Detail FROM ##SanteTests ORDER BY Cod_Test;
SELECT CASE WHEN SUM(CASE WHEN Resultat='KO' THEN 1 ELSE 0 END)=0 THEN 'TOUS LES TESTS OK'
            ELSE convert(nvarchar(3),SUM(CASE WHEN Resultat='KO' THEN 1 ELSE 0 END))+' TEST(S) EN ECHEC' END AS Bilan
FROM ##SanteTests;
DROP TABLE ##SanteTests;
