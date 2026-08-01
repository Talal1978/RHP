# Traçabilité exigences → composants → tests, et plan de migration (Phase 1)

## 0bis. Résultats Phases 3 et 4 (01/08/2026)

- **Phase 3 — RHP_DeskTop** : `Sante\Module_Sante.vb` (audit paramétré ADODB, contrôle fonctions SANTE_*, verrou CNDP, exécution paramétrée anti-injection) + **20 écrans** (Visite+Liste, Dossier 8 onglets, Aptitude+Liste, Consultation+Liste, Examen+Liste, MaladiePro+Liste, Vaccination, Campagne, Declaration_AT_Suivi, Stats_AT, Tableau_Bord, Audit, Rapport_Annuel, Param). **Compilation VB : 0 erreur** (la copie finale de RHP.exe nécessite de fermer l'application en cours).
- **Phase 4 — RHP_Portail (pages clés)** : 5 pages (`RH_Sante_Visite_Liste` planning, `RH_Sante_Visite` fiche médecin, `Sante_MaSante` salarié, `RH_Sante_Tableau_Bord` agrégats, `RH_Declaration_AT_Suivi`) enregistrées dans `Ecran.tsx` + `menus.json`. **Lint : 0 erreur ; build (`tsc -b && vite build`) : OK.** Corrections appliquées : `TMenuBtn` réel (`libelle`/`action`/`color`), `lodash.isequal`, typages `onchange`.
- **Reste à décliner du gabarit (marqué)** : pages portail secondaires (Aptitude liste/fiche, Consultation, Examen, MaladiePro, Campagne) — même gabarit que les 5 pages livrées, endpoints déjà disponibles et testés.

## 0. Résultats d'exécution (Phase 2 — 01/08/2026)

- **Script d'installation** : `Script_SQL_Sante.sql` — **58/58 batches OK** (idempotent, rejoué 5 fois).
- **Données de démo** : `Script_SQL_Sante_Demo.sql` — 7/7 OK (agents FICTIF*, société 3068).
- **Tests SQL** (`Tests_Sante.sql` via `rhpBE\sante\run_tests.ts`) : **22/22 OK** (T01–T19 + sous-cas).
- **Build backend** (`rhpBE`) : `tsc` OK.
- **Tests API** (`rhpBE\sante\tests_api.ts` contre serveur :3500) : **29/29 OK** (T20–T32 + sous-cas), avec utilisateurs fictifs (profils MED/RH/INF/AUD créés via IDENTITY).
- **Corrections de Phase 2 intégrées** : FK `Controle_Menu_Avance` (menus avant sécurité avancée) ; règle POSTE_RISQUE assouplie (liaison `Cod_Regle` indicative) ; `Nb_Avec_Arret` = 1 par AT dans la vue stats ; paramètres d'audit renommés `p_*` + valeur `Succes` en String (EPARAM tedious) ; dates `SmallDateTime` dans `sante_audit_liste`.
- **Décision Q3 affinée** : le type `CAT` ("Accident de travail") **existait déjà** dans `RH_Conge_Type` (`deductibleDuConge=0`) — réutilisé comme valeur par défaut de `TYP_CONGE_AT` au lieu de créer `AAT`.
- **Non réalisé à ce stade** : NR02 (comparaison de bulletin de paie) — reporté en Phase 6 (nécessite un scénario paie complet) ; les `.rpt` (Phase 5).

## 1. Matrice de traçabilité initiale

| Capacité (grille) | Tables/API/Écrans/Rapports | Tests prévus | Statut |
|---|---|---|---|
| 4.1 Visites, aptitude, périodicités, échéances | `RH_Sante_Visite`, `Param_Sante_Periodicite`, `Sys_Sante_Prochaine_Visite`, `RH_Sante_Dossier` ; écrans `RH_Sante_Visite[_Liste]`, `RH_Sante_Dossier` ; API `sante_visite_*`, `sante_calcul_echeance` | SQL T01–T08 (règles, priorité, historisation, ajustement motivé) ; API T20–T23 | Conception |
| 4.1 Tableau de bord + exports + cloisonnement | `RH_Sante_Vue_TB_Aptitudes`, `RH_Sante_Tableau_Bord` (+ page portail), export EPPlus | SQL T09 (seuil agrégat) ; API T24 (droits par rôle) ; IHM manuelle | Conception |
| 4.1 Alertes multi-seuils | Paramétrage `Notifications` (N seuils) | Test RHPServer : événement → `Notification_Events` → envoi | Conception |
| 4.2 AT : déclaration, certificats, clôture | **Existant** `RH_Declaration_AT[_Detail]` — non modifié | Non-régression NR01 (scénarios existants) | Réutilisé |
| 4.2 AT : distinction, échéancier, transmissions, destinataires | `Typ_Accident`, `Param_Sante_Destinataire`, `Param_Sante_Etape_AT`, `RH_Declaration_AT_Echeance`, `_Transmission`, `Sys_Sante_AT_Generer_Echeances`, `RH_Declaration_AT_Suivi` | SQL T10–T12 ; API T25 ; Desktop manuel | Conception |
| 4.2 AT : arrêt → Absences | `Sys_Sante_AT_Generer_Absence`, `RH_Conge_Suivi` (type `AAT`), `Num_Conge` trace | SQL T13–T15 (génération, anti-chevauchement, MajConso) ; **NR02 paie** (bulletin avec arrêt AT) | Conception |
| 4.2 AT : statistiques TF/TG | `RH_Sante_Vue_Stats_AT`, `RH_Sante_Stats_AT`, API `sante_at_stats` | SQL T16 (jeu contrôlé, calculs vérifiés à la main) | Conception |
| 4.3 Fiches d'aptitude + versions + PDF + GED | `RH_Sante_Aptitude`, `Sante_Fiche_Aptitude.rpt`, archivage `Param_GED` | SQL T17 (versioning) ; PDF produit + archivé ; API T26 (masse, audit individuel) | Conception |
| 4.4 Rapport annuel + contrôle sources | `RH_Sante_Rapport_Annuel`, vues agrégées, `Sante_Rapport_Annuel.rpt` | SQL T18 (comptages) ; PDF/Excel ; archivage par version | Conception — **modèle légal à valider** |
| 4.5 Examens + GED cloisonnée + verrou CNDP + conservation | `RH_Sante_Examen`, GED droits restreints, `Param_Sante_Reglement`, `Sys_Sante_Purge` | SQL T19 (purge simulation) ; API T27 (visibilité MED/AUT, IDOR) ; upload MIME/taille | Conception |
| 5.x Infirmerie, campagnes, référentiels, MP, vaccinations, postes/risques, recherche multicritère | Tables et écrans dédiés (cf. 01_Conception) | SQL/API par objet | Conception |
| Sécurité : audit d'accès, no-store, non-exposition Requêteur | `RH_Sante_Audit_Acces`, headers, consigne Requêteur | API T28–T30 (audit écrit, header, refus rôle) ; revue `Param_Query` | Conception |

## 2. Plan de tests (scripts, sans nouveau framework)

### 2.1 SQL — `Sante\Tests_SQL.sql` (base de test, données fictives)

| # | Objet du test |
|---|---|
| T01 | Règle STANDARD : prochaine visite = visite + N mois |
| T02 | Cumul : agent poste à risque + nuit → arbitrage `MIN` (échéance la plus proche) |
| T03 | Arbitrage `PRIORITE` si paramétré |
| T04 | Historisation : règle modifiée (dates d'effet) → calculs antérieurs inchangés, nouveaux calculs = nouvelle règle |
| T05 | Ajustement médecin sans motif → refus ; avec motif → accepté + trace |
| T06 | Visite validée → verrouillée ; correction = nouvelle visite rectificative liée |
| T07 | `Sys_Sante_Maj_Dossier` : champs dénormalisés corrects |
| T08 | Périodicités différenciées : ENCEINTE, MINEUR (<18 ans via `RH_Agent.Dat_Naissance`), NUIT, POSTE_RISQUE |
| T09 | Vue agrégée : cellule < `SEUIL_AGREGAT_MIN` masquée |
| T10 | Génération échéancier AT depuis étapes paramétrées (dates de départ variables) |
| T11 | Étape dépassée → statut `DEP` (par requête de suivi) |
| T12 | Transmission + preuve GED rattachée |
| T13 | Validation certificat INITIAL → absence `RH_Conge_Suivi` type `AAT` créée (Statut `VA`, `deductibleDuConge=0`) |
| T14 | Chevauchement avec congé existant → blocage `Sys_Conge_Check` |
| T15 | Prolongation/rechute → absence mise à jour/nouvelle, `Sys_Conge_MajConso` cohérent |
| T16 | TF/TG sur jeu contrôlé (2 AT, 30 jours d'arrêt, heures paramétrées) = valeurs attendues |
| T17 | Aptitude validée → update refusé ; Version+1 avec motif → OK |
| T18 | Comptages rapport annuel vs requêtes de contrôle manuelles |
| T19 | `Sys_Sante_Purge` en simulation : lignes candidates correctes ; exécution journalisée |

### 2.2 API — `Sante\Tests_API.js` (Node, appels HTTP sur instance de test)

| # | Objet du test |
|---|---|
| T20 | Visite : CRUD nominal médecin (token profil MED) |
| T21 | Refus création visite par profil RH / Agent d'un autre matricule (403 générique + `AUTH_KO` en base) |
| T22 | IDOR : modification `Num_Visite`/`Matricule`/société dans le body → refus |
| T23 | Échéance : calcul exposé cohérent avec SQL |
| T24 | Tableau de bord : RH voit agrégats, jamais de ligne nominative clinique |
| T25 | AT : échéancier/transmissions CRUD + droits HSE |
| T26 | Aptitude en masse : N fiches → N lignes d'audit |
| T27 | Examen : résultat visible médecin, refus infirmier si `Visibilite='AUT'`, téléchargement GED après revalidation + audit `TELE` |
| T28 | Chaque appel clinique écrit `RH_Sante_Audit_Acces` (LECT/CREA/MODI) |
| T29 | Header `Cache-Control: no-store` présent sur toutes les réponses `sante_*` |
| T30 | Upload : MIME hors whitelist refusé, > 50 Mo refusé, extension vs MIME contrôlé |
| T31 | Salarié : `ma_sante` ne retourne que ses objets publiables ; tentative sur autre matricule → vide |
| T32 | Vues `sante_*_planning` : absence de colonnes cliniques dans la réponse |

### 2.3 Non-régression (obligatoire avant livraison)

| # | Module | Scénario |
|---|---|---|
| NR01 | AT existant | Déclaration complète + certificats + clôture (Desktop) : comportement inchangé |
| NR02 | Paie | Bulletin d'un agent fictif avec arrêt AT généré : vérification des rubriques impactées vs bulletin sans arrêt (comparaison) ; `Sys_GetCongePris` non perturbé |
| NR03 | Congés | Demande de congé portail + Desktop : inchangés ; `Sys_Conge_MajConso` cohérent après génération AT |
| NR04 | GED | Upload/download/renommage sur écrans existants : inchangé |
| NR05 | Workflow | Circuit de signature congé : inchangé ; nouvelle signature visite `'VM'` fonctionnelle |
| NR06 | Agent/Absences écrans existants | Ouverture, filtres, exports : inchangés |

## 3. Plan de migration et retour arrière

### 3.1 Migration

1. **Pré-requis** : backup de la base ; restauration sur base de test ; baseline build Desktop + portail **avant** toute modification.
2. Exécuter `RHP_DeskTop\RHP\Sante\Script_SQL_Sante.sql` (idempotent : tables, vues, rubriques, zooms, écrans, boutons, sécurité avancée, workflow, menus, `Param_Audit_Espion`, fonctions `Controle_Menu_Functions`).
3. « Génération globale » (`Admin_TreeView`) si nécessaire pour référencer les écrans, puis placement dans l'arborescence (le script provisionne déjà un dossier de menu).
4. Paramétrage `Workflow_Signatures` pour `'VM'` et `'FA'`.
5. Paramétrage des `Notifications` (alertes) et des paramètres réglementaires (valeurs validées + sources).
6. Déploiement code : Desktop (build solution), backend (`npm run build`), frontend (`npm run build`).
7. Tests SQL + API + non-régression sur base de test.
8. Production : même script (idempotent) + déploiement applicatif ; activation du verrou CNDP levée uniquement après saisie des paramètres d'autorisation.

### 3.2 Retour arrière

- `Script_SQL_Sante_Rollback.sql` : supprime les métadonnées framework du module (menus, écrans, boutons, zooms, rubriques `Sante*`, workflow `'VM'/'FA'`, notifications du module, lignes `Param_Audit_Espion`), désactive les triggers `ESP_*` générés pour les tables santé ; **conserve** les tables de données (par défaut) ou les supprime avec option explicite `--DROP DATA` documentée.
- Code : retour arrière Git standard (aucun fichier existant modifié hors ajouts listés dans la matrice).
- Colonnes ajoutées à `RH_Declaration_AT[_Detail]` : NULL, inoffensives ; suppression possible si retrait complet validé.
- Absences `AAT` générées : script de régularisation fourni (suppression des `RH_Conge_Suivi` tracés par `Num_Conge` sur les lignes AT, puis `Sys_Conge_MajConso`).

## 4. Données de démonstration

Jeu fictif fourni en fin de script (société de test `-1`/dédiée, matricules `FICTIF001…`) : agents, médecin, infirmier, règles de périodicité, 10 visites, 3 aptitudes, 2 AT avec échéancier, 5 examens, 1 campagne — **aucune donnée réelle**.
