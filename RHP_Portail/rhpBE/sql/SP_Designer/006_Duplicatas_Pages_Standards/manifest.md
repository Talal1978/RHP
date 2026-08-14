# Duplicatas des pages standards — test de couverture du Designer SP_

**Demande** : DUP-PAGES-2026-08
**Objectif** : recréer, dans la section portail **« Pages spécifiques »**, un duplicata
des 6 pages documents standards (demande de congé, note de frais, déclaration AT,
dossier médical, demande d'avance, demande de prêt) **en n'utilisant que les
mécanismes du Designer de pages (module SP_)**, afin d'éprouver sa couverture
fonctionnelle. Les pages standards, leurs tables et leurs composants ne sont
**ni touchés ni altérés**.

## 1. Contenu du package

| Fichier | Rôle |
|---|---|
| `000_preflight.sql` | Contrôles pré-vol 100 % lecture seule (exécuté : **OK**) |
| `001_deploy.sql` | Déploiement idempotent (dry-run par défaut ; `@DryRun=0` pour appliquer) |
| `002_rollback.sql` | Retrait (phase 1 : désactivation ; phase 2 optionnelle : métadonnées) |
| `manifest.md` | Le présent rapport |

Déploiement vérifié en dry-run intégral (ROLLBACK final) puis **appliqué** :
6 pages `PUBLIE`, 8 tables métier créées, 7 profils habilités par page,
10 sources métier, circuits de signature miroir dans les sociétés 3060 et 3068.

Tests exécutés contre la base de développement (scripts archivés dans `tests/`) :
- les 10 sources SQL (repos, fériés, durée de congé, solde, contrôles paie,
  avances/prêts en cours, dernier salaire) → résultats conformes au calcul
  standard (ex. 03/08→14/08/2026 : repos=2, fériés=1, durée=9, identique à
  `calcul_conge`) ;
- les formules déclaratives (DATEDIFF/COND/ROUND/SUM/DIVSAFE, règles EXPR,
  COMPARE, visibilité) évaluées avec le moteur serveur réel → **20/20 OK** ;
- **test de bout en bout** via le moteur serveur réel
  (`module_sp_engine.js`, `tests/test_e2e_sp.js`) : pour chaque page,
  création → relecture → validations → modification → soumission SS
  (circuit de signature alimenté, statut `SS` posé) → suppression ;
  droits de consultation/refus de création sur la page AT en lecture seule ;
  **tous les tests passent** ;
- requête du menu portail (`sp_menu_portail`) simulée : la section
  « Pages spécifiques » et ses 6 entrées remontent pour un profil non admin.

### Corrections apportées en cours de test

1. **Sources** : le garde-fou `estRequeteLectureSeule` (« instruction multiple »)
   rejette tout littéral contenant `;` — la valeur par défaut des jours ouvrables
   (`'1;1;1;1;1;1;0'`) a été réécrite sans point-virgule
   (`replace('1.1.1.1.1.1.0', '.', char(59))`).
2. **Idempotence du déploiement** : l'ordre officiel des suppressions
   (`SP_Page_Table` avant `SP_Page_Colonne`, pattern du script 002) viole la FK
   `FK_SPCol_Table` dès la ré-exécution. Ce package supprime **Colonne avant
   Table** (ordre FK-safe) — à reporter dans le pattern officiel.
3. **Agrégats SQL** : `SUM(CASE ... EXISTS (sous-requête))` est refusé par
   SQL Server ; les sources de décompte matérialisent d'abord les indicateurs
   par jour (CTE `j2`), puis agrègent.

## 2. Correspondance des pages

| Page standard | Duplicata SP_ | Table(s) | Workflow | GED |
|---|---|---|---|---|
| `RH_Demande_Conge` | `DUP_CONGE` (XCG) | `SP_XCG_Ent` | XCG (miroir C) | ✔ |
| `Note_Frais` | `DUP_NOTE_FRAIS` (XNF) | `SP_XNF_Ent` + `SP_XNF_Det_LIGNES` | XNF (miroir NF) | ✔ |
| `RH_Declaration_AT` | `DUP_DECLARATION_AT` (XAT) | `SP_XAT_Ent` + `SP_XAT_Det_CERTIFS` | — (consultation, comme le standard portail) | ✔ |
| `RH_Dossier_Maladie` | `DUP_DOSSIER_MALADIE` (XDM) | `SP_XDM_Ent` | XDM (miroir DM) | ✔ |
| `Demande_Avance` | `DUP_AVANCE` (XAV) | `SP_XAV_Ent` | XAV (miroir AV) | ✔ |
| `Demande_Pret` | `DUP_PRET` (XDP) | `SP_XDP_Ent` | XDP (miroir DP) | ✔ |

Couverture **identique au standard** (vérifié champ par champ) :
- FAB : Enregistrer / Nouveau / Supprimer / Soumettre pour signature /
  Pièces jointes, verrou concurrent (`check_accessible`), blocage paie en cours
  (`is_paie_encours`), statuts figés, numérotation automatique, anti
  double-soumission, confirmation d'abandon, grille d'édition avec ajout /
  suppression de lignes (note de frais), pied de grille total (somme des
  montants), colonnes combo par rubrique (`Typ_Frais`), combo zoom
  (`Typ_Conge` MS165, `Nom_Malade` MS023), radio (`Le malade`), règle de
  visibilité (`Nom_Malade` visible si « membre de la famille »), champs
  calculés (`Mnt = Base × Tx`, `Durée`, `Taux de remboursement`), champs
  SOURCE temps réel (solde de congé, avances/prêts en cours, dernier salaire).
- Validations reproduites : matricule obligatoire, ordre des dates, durée de
  congé > 0, montant engagé > 0, **période clôturée** (`Sys_Conge_CheckPeriode`)
  et **postériorité à la dernière paie** (paramètre
  `Autoriser_SaisieCongeApresPaie` respecté) via validations SOURCE, total de
  frais nul = avertissement non bloquant.
- Listes : critères Matricule + date, cloisonnement « ses propres documents »
  pour les non-TeamLeader, pagination, persistance d'état — fournis par le
  moteur SP_ (`SPPL_*`), équivalents aux listes standards.
- Workflow de signature : circuits des duplicatas générés par **miroir exact**
  des circuits standards (sociétés, lignes, signataires `getSuperieur` /
  `getResponsable`) avec substitution de la table et de la clé du document.

## 3. Évolutions du Designer implémentées (lot SP4)

Suite à l'analyse des écarts, les 9 propositions ont été **implémentées**
(migration `006_SP_Designer_Evolutions.sql` + moteur `module_sp_engine.ts` /
`sp_document.ts` + rendu `DynamicPage.tsx` / `DynamicField.tsx` /
`DynamicPage_Liste.tsx` / `SpPrintDialog.tsx` + `ComboBox`/`TextZoom`/`Grille`) :

| # | Évolution | Mise en œuvre |
|---|---|---|
| P1 | **Contexte technique dans validations/sources** : `Num_Doc`, `Statut`, `Created_By` injectés dans le contexte serveur à l'enregistrement ; `@Login`, `@Matricule`, `@Cod_Profile` injectés dans les sources (comme `@id_Societe`) | Le contrôle de **chevauchement** du congé duplicata exclut le document courant (modification possible, doublon bloqué) ; la règle **propriétaire** (« on ne saisit que pour soi ») est active sur les 5 pages d'édition |
| P2 | **Détail virtuel alimenté par une source TABLE** (`SP_Page_Table.Source_Metier` + `Source_Mapping`) | La grille « Détail par période de paie » du congé duplicata est **identique au standard** (source `sp_cng_detail`, miroir de `calcul_conge`) ; lecture seule, ré-exécutée côté serveur à l'enregistrement, jamais persistée |
| P3 | **Champ Statut affichable** (convention : champ lié au nom technique `Statut`, sans colonne métier déclarée — exclu de l'UPSERT de fait) | Le statut (rubrique `Statut_Signature`, lecture seule) s'affiche dans l'entête des pages Note de frais / Avance / Prêt, comme le standard |
| P4 | **`SP_Page.Figer_Statuts`** (CSV, défaut `'SG,RJ,SP,VA'`) | Duplicatas : `'SS,SG,RJ,SP,VA'` → un document soumis n'est plus modifiable/supprimable, **comme le standard** (vérifié par test : « Document déjà traité ») |
| P5 | **`SP_Page_Champ.Zoom_Condition`** avec placeholders `{Champ}` | Le combo « Le malade » (dossier maladie duplicata) est filtré par le matricule courant : `Matricule='{Matricule}'` — `ComboBox`/`TextZoom`/`Grille` rechargent le zoom quand la condition change |
| P6 | **Critères de liste** : plages de dates (`<col>__Du`/`__Au`), libellé rubrique du statut (`FindRubrique`), colonne « Nom » de l'agent jointe, critère Statut (prefix) | Les listes des duplicatas affichent Nom, Statut libellé, et filtrent par plage Du/Au et Statut comme les listes standards |
| P7 | **Cascade SOURCE → CALCULE** (client) + **ré-exécution serveur** des champs SOURCE persistés à l'enregistrement | La valeur persistée fait foi côté serveur (jamais la valeur client) |
| P8 | **Impression générique** par les métadonnées (`SpPrintDialog`, sans modèle Crystal) quand `Act_Imprimer='true'` sans `Cod_Modele_Edition` | Le bouton Imprimer du FAB est actif sur les 6 duplicatas (la consultation AT retrouve son impression, comme le standard) |
| P9 | **Robustesses** : binding `Date→ISO` des paramètres de source ; garde-fou sources (littéraux `;` neutralisés ; `sp_\w+` sensible à la casse pour ne plus bloquer les tables `SP_*`) ; ordre FK-safe des DELETE de métadonnées (exemple `002` et template du skill corrigés) | Testé : sources avec littéraux `;` acceptées, multi-instructions toujours refusées |

### Écarts résiduels (assumés)

| # | Écart | Commentaire |
|---|---|---|
| R1 | Numérotation SP_ (`<CodDoc><Soc>-<aaaa><seq>` sur `Dat_Crea`) distincte de la numérotation standard (par date de demande) | Convention du module SP_ |
| R2 | Rubrique « Le malade » : valeur `'A'` au lieu de `''` (une rubrique ne porte pas la valeur vide) | Sans impact fonctionnel |
| R3 | Dossier maladie : bascule « agent lui-même » ne vide pas automatiquement `Nom_Malade` (pas d'effet de bord au changement) | Valeur masquée conservée |
| R4 | Page AT duplicata : le FAB présente « Nouveau » désactivé (absent du standard) | Cosmétique, sans effet |
| R5 | Impression générique = mise en page tabulaire sobre | Un modèle Crystal dédié reste possible (`Cod_Modele_Edition`) |
| R6 | Les circuits de signature des duplicatas sont le miroir des circuits standards **au jour du déploiement** (3060/3068) | Les modifier ensuite via l'écran Workflow_Signatures n'altère pas les standards |

## 4. Vérifications finales (moteur serveur réel, base de développement)

- Cycle complet sur les 6 pages : création → relecture → validations →
  modification → soumission SS (circuit alimenté, statut posé) → suppression. **OK**
- Congé : grille périodes alimentée (durées identiques au calcul standard),
  chevauchement bloqué à la création, **auto-exclusion à la modification OK**,
  règle propriétaire bloquante, modification refusée après soumission (SS figé).
- Sources : 13/13 exécutées (dont TABLE `sp_cng_detail` et les règles d'appartenance).
- Liste : plage de dates, critère Statut, nom de l'agent, libellé de statut. **OK**
- Garde-fou sources : littéraux `;` acceptés, multi-instructions/écriture refusées. **OK**
- Builds : backend `tsc` et frontend `tsc -b && vite build` sans erreur ;
  FAB du portail vérifié intact (DynamicPage alimente toujours `settbnMenu`).
- Scripts archivés dans `tests/` (`test_formules.js`, `test_e2e_sp.js`,
  `test_e2e_v2.js`, `test_sources.sql`).

## 5. Exploitation

1. `000_preflight.sql` (lecture seule) → toutes lignes OK.
2. `001_deploy.sql` : `@DryRun=1` pour la revue ; `@DryRun=0` pour appliquer.
3. Rafraîchir le portail : la section **Pages spécifiques** apparaît avec les
   6 entrées « … (SP) ».
4. Retrait : `002_rollback.sql` (phase 1 ; phase 2 avec `@RemoveMetadata=1`).

Notes d'exploitation :
- Les droits sont octroyés à **tous les profils actifs** (comme les pages
  standards, ouvertes à tout utilisateur connecté). Un profil créé après le
  déploiement devra être habilité (écran `SP_Page_Designer` ou `Admin_Profile`).
- La page AT duplicata est volontairement en consultation seule (miroir strict
  du portail standard) ; un bloc d'exemple commenté permet d'y insérer un
  document de test.
- Le circuit `XAV` en société 3068 est créé inactif (`Actif=0`), miroir exact
  du circuit standard `AV` de cette société.
