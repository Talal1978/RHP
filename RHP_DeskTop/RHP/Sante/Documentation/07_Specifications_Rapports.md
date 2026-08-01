# Spécifications des rapports Crystal Reports — Module Santé

**Statut** : spécifications à faire valider (décision Q5). Les `.rpt` ne sont **pas** livrés en l'état (format binaire Crystal Reports) — ce document fournit tout ce qui est nécessaire à leur production dans Crystal Reports Designer. Le paramétrage (`Param_Mod_Edition`, `Controle_Def_Ecran_Mod_Edition`) est déjà installé et devient actif dès dépôt du `.rpt` dans `D:\Dev\RHP\RHP\Reports\`.

**Règle commune** : chaque rapport est appelé avec `IDSOC` automatiquement. Connexion ODBC du socle (même DSN que les états existants, paramètre `ODBC_RHP`). Habilitation vérifiée côté serveur avant génération.

---

## 1. `Sante_Fiche_Aptitude.rpt` — Fiche d'aptitude médicale

| Élément | Spécification |
|---|---|
| **Paramètres** | `Num_Aptitude` (chaîne), `IDSOC` (nombre) |
| **Source (commande SQL)** | `SELECT a.Num_Aptitude, a.Dat_Aptitude, a.Statut_Aptitude, a.Reserves, a.Restrictions_Poste, a.Amenagements, a.Dat_Effet, a.Dat_Fin, a.Version, ag.Matricule, ag.Nom_Agent, ag.Prenom_Agent, ag.Dat_Naissance, p.Lib_Poste, e.Lib_Entite, i.Nom AS Medecin_Nom, i.Prenom AS Medecin_Prenom, i.Num_Ordre AS Medecin_Ordre, s.Den AS Societe, s.Adresse AS Societe_Adresse FROM RH_Sante_Aptitude a INNER JOIN RH_Agent ag ON ag.Matricule=a.Matricule AND ag.id_Societe=a.id_Societe LEFT JOIN Org_Poste p ON p.Cod_Poste=ag.Cod_Poste AND p.id_Societe=ag.id_Societe LEFT JOIN Org_Entite e ON e.Cod_Entite=ag.Cod_Entite AND e.id_Societe=ag.id_Societe LEFT JOIN Param_Sante_Intervenant i ON i.Cod_Intervenant=a.Cod_Medecin AND i.id_Societe IN (a.id_Societe,-1) INNER JOIN Param_Societe s ON s.id_Societe=a.id_Societe WHERE a.Num_Aptitude={?Num_Aptitude} AND a.id_Societe={?IDSOC}` |
| **Sections** | En-tête : logo société + « FICHE D'APTITUDE MÉDICALE » + N° et version. Corps : identité agent (matricule, nom, date naissance, poste, entité), date de visite, **conclusion d'aptitude** (APTE / APTE AVEC RÉSERVES / INAPTE TEMPORAIRE / INAPTE DÉFINITIF), réserves, restrictions de poste, aménagements, période de validité. Pied : médecin du travail (nom, n° ordre, signature/cachet), date d'édition. **Aucune observation clinique.** |
| **Habilitation** | SANTE_CLINIQUE (génération) ; la version RH est l'objet publié (`Publie_RH`). |
| **Appel** | Desktop `RH_Sante_Aptitude` (bouton Imprimer automatique) ; portail `sante_aptitude_pdf` (archivage GED inclus) ; `getreport`. |
| **Archivage** | Automatique en GED (`Param_GED`, zone `MEDICAL`, droits restreints service médical), référence `RH_Sante_Aptitude.FD_PDF`. |

## 2. `Sante_Rapport_Incident_AT.rpt` — Rapport d'incident / accident du travail

| Élément | Spécification |
|---|---|
| **Paramètres** | `Num_Declaration` (chaîne), `IDSOC` (nombre) |
| **Source (commande SQL)** | Entête : `SELECT t.Num_Declaration, t.Dat_Accident, t.Heure_Accident, t.Lieu_Accident, t.Circonstances, t.Nature_Lesion, t.Siege_Lesion, t.Temoins, t.Tiers_Responsable, t.Num_Assurance, ISNULL(t.Typ_Accident,'TRAVAIL') AS Typ_Accident, ag.Matricule, ag.Nom_Agent, ag.Prenom_Agent, p.Lib_Poste, s.Den AS Societe, s.CNSS AS Societe_CNSS FROM RH_Declaration_AT t INNER JOIN RH_Agent ag ON ag.Matricule=t.Matricule AND ag.id_Societe=t.id_Societe LEFT JOIN Org_Poste p ON p.Cod_Poste=ag.Cod_Poste AND p.id_Societe=ag.id_Societe INNER JOIN Param_Societe s ON s.id_Societe=t.id_Societe WHERE t.Num_Declaration={?Num_Declaration} AND t.id_Societe={?IDSOC}` — Détail (sous-rapport) : `SELECT Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Valide FROM RH_Declaration_AT_Detail WHERE Num_Declaration={?Num_Declaration} AND id_Societe={?IDSOC} ORDER BY Dat_Certificat` |
| **Sections** | Identification société/salarié ; circonstances (date, heure, lieu, activité en cours, témoins, tiers) ; nature et siège des lésions ; premiers soins ; tableau des certificats et arrêts ; zone déclarant + visa. Mention « accident du travail / de trajet » selon `Typ_Accident`. |
| **Habilitation** | SANTE_ADMIN. |
| **Appel** | Desktop `RH_Declaration_AT_Suivi` ; portail `sante_incident_at_pdf`. |

## 3. `Sante_Rapport_Annuel.rpt` — Rapport annuel du service médical du travail

> **Avertissement conformité** : la structure finale doit reproduire le **modèle annexé à l'arrêté n° 3125-10 du 22 novembre 2010** (modèle du rapport annuel prévu par l'article 307 du Code du travail). Le modèle officiel en vigueur doit être **obtenu et contrôlé** par le médecin du travail de l'organisation avant finalisation. Les sections ci-dessous sont la trame technique d'alimentation ; la maquette réglementaire prime.

| Élément | Spécification |
|---|---|
| **Paramètres** | `Annee` (nombre), `IDSOC` (nombre) |
| **Sources (une commande par section)** | (a) Effectifs : `SELECT ISNULL(Cod_Grade,'') AS Categorie, ISNULL(Sexe,'') AS Sexe, COUNT(*) AS Effectif FROM RH_Agent WHERE id_Societe={?IDSOC} GROUP BY Cod_Grade, Sexe` ; (b) Visites : `SELECT Typ_Visite, COUNT(*) AS Nb FROM RH_Sante_Visite WHERE id_Societe={?IDSOC} AND YEAR(Dat_Visite)={?Annee} AND ISNULL(Statut,'') IN ('VA','SG') GROUP BY Typ_Visite` ; (c) Aptitudes : `SELECT Statut_Aptitude, COUNT(*) AS Nb FROM RH_Sante_Aptitude WHERE id_Societe={?IDSOC} AND YEAR(Dat_Aptitude)={?Annee} AND ISNULL(Statut,'') IN ('VA','SG') GROUP BY Statut_Aptitude` ; (d) AT/MP : `SELECT ISNULL(Typ_Accident,'TRAVAIL') AS Typ, COUNT(*) AS Nb, ISNULL(SUM(j.Jours),0) AS Jours FROM RH_Declaration_AT t OUTER APPLY (SELECT SUM(d.Nbr_Jours) AS Jours FROM RH_Declaration_AT_Detail d WHERE d.Num_Declaration=t.Num_Declaration AND d.id_Societe=t.id_Societe AND ISNULL(d.Valide,'false')='true' AND d.Dat_Debut_Arret IS NOT NULL) j WHERE t.id_Societe={?IDSOC} AND YEAR(t.Dat_Accident)={?Annee} AND ISNULL(t.Typ_Accident,'TRAVAIL')<>'NREC' GROUP BY ISNULL(Typ_Accident,'TRAVAIL')` + `SELECT Statut_Declaration, COUNT(*) AS Nb FROM RH_Sante_Maladie_Pro WHERE id_Societe={?IDSOC} AND YEAR(Dat_Declaration)={?Annee} GROUP BY Statut_Declaration` ; (e) Examens : `SELECT Typ_Examen, COUNT(*) AS Nb FROM RH_Sante_Examen WHERE id_Societe={?IDSOC} AND YEAR(ISNULL(Dat_Examen,Dat_Prescription))={?Annee} GROUP BY Typ_Examen` ; (f) Société/médecin : `Param_Societe` + `Param_Sante_Intervenant` (médecin du travail déclaré). |
| **Sections** | Identification de l'établissement et du service médical ; effectifs par catégorie professionnelle et sexe ; activité de surveillance (visites par type, aptitudes) ; accidents du travail et maladies professionnelles (effectifs et jours) ; examens complémentaires ; actions de prévention ; observations et programme de l'année à venir ; visa du médecin du travail. **Uniquement des agrégats — aucune donnée individuelle.** |
| **Habilitation** | SANTE_ADMIN (édition) ; validation par le médecin du travail (cycle Brouillon→Contrôlé→Validé→Transmis dans `RH_Sante_Rapport_Annuel`). |
| **Appel** | Desktop `RH_Sante_Rapport_Annuel` ; backend `sante_rapport_annuel_pdf`. |
| **Archivage** | GED par société/exercice/version (`RH_Sante_Rapport_Annuel.FD_Rapport`), preuve de transmission (`FD_Preuve`). |

## 4. Option — `Sante_Convocation.rpt` (si validée)

Convocation individuelle à une visite (campagne, date/heure, lieu, médecin, consignes neutres). Source : `RH_Sante_Convocation` + `RH_Sante_Campagne` + `RH_Agent`. **Alternative sans rapport** : notification externe avec `Agenda=1` (invitation calendrier) — déjà disponible par paramétrage, recommandée en V1.

---

### Points d'attention pour la production des `.rpt`

1. Créer les rapports dans Crystal Reports Designer **version compatible CR 13** (runtime du socle : CrystalDecisions 13.0.4000.0) avec connexion ODBC `ODBC_RHP` — mêmes conventions que les états existants du dossier `Reports\`.
2. Déclarer les paramètres avec les **noms exacts** (`Num_Aptitude`, `Num_Declaration`, `Annee`, `IDSOC`) — `crexport.exe` les passe par `-p`/`-v` dans l'ordre.
3. Déposer les `.rpt` dans `D:\Dev\RHP\RHP\Reports\` puis tester : bouton Imprimer Desktop + endpoint `sante_*_pdf` + visualiseur portail (`/viewer`).
4. Le rapport annuel : faire **valider la maquette par le médecin du travail** (modèle légal arrêté 3125-10) et consigner la référence du modèle dans le paramètre `RAPPORT_ANNUEL_MODELE`.
