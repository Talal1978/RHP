# Manifest — TELETRAVAIL (EXEMPLE-02)

Package généré par le skill `rhp-portal-page-deployer` (mode **JSON import**).
Demande : EXEMPLE-02. Environnement cible : development. Opération : create.
Sortie : `RHP_Page_TELETRAVAIL.json` (format RHP_PAGE_DESIGNER 1.0), importable
dans `SP_Page_Designer` via « Importer JSON ». **Aucun script SQL n'est produit.**

## 1. Classification des faits

### Verified (sources du dépôt)
- Format d'import/export JSON : `Module_SP_Page_Json.vb` (DTO + validation +
  remplissage des grilles), `SP_Page_Designer.vb` (`ImporterJson`,
  `AppliquerImport`, `Saving`).
- Tables `Controle_Designer*` (8), contraintes, defaults : `001_SP_Designer_Metadata.sql`.
- Structure métadonnées équivalente (oracle) : `002_SP_Designer_Exemple_FKM.sql`.
- Procédure de publication : `SP_Page_Designer.vb` (`Publier`).
- Section `MesDemandes` : rubrique `SP_Menu_Portail` seedée par `001_...sql:417`.
- Source `solde_conge` : seedée par `001_...sql:442-449` (retour SCALAIRE).
- Zoom `MS067` : utilisé par l'exemple officiel FKM (`002_...sql:54`).
- Profil `'1'` super-admin : convention RHP (`module_sp_engine.ts:271`).

### Assumptions (à confirmer — l'import les signale en avertissements)
- Zoom `MS067` existe dans `Controle_Def_Zoom` de l'environnement cible.
- `Sys_Workflow_Signature` est installé — requis car `workflow.enabled=true`
  (vérifié à la publication).
- Colonne `Controle_Profile.Cod_Profile` conforme à la découverte.
- `decimal(5,1)` jugé suffisant pour `Nb_Jours` (borné par la validation V04).

### Missing
- Aucune (entrée complète).

## 2. Décisions de mapping (input → JSON)

| Input | Cible dans le fichier |
|---|---|
| `page_code=TELETRAVAIL` | `page.Cod_Page` (écran `SPP_TELETRAVAIL`, liste `SPPL_TELETRAVAIL` après publication) |
| `document_code=TT` | `page.Cod_Document` ; tables `SP_TT_Ent` / `SP_TT_Det_JOURS` recalculées à l'import |
| `title` | `page.Nom_Page` (le Designer écrit `Libelle = Nom_Page` au Saving ; `page_name`/`short_title` non persistés séparément) |
| `target_section_code`, `display_order`, `icon` | `page.Menu_Parent='MesDemandes'`, `page.Rang=95`, `page.Icone='HomeWork'` |
| `enabled=true` | étape manuelle « Publier » ci-dessous (jamais automatisée) |
| `actions.submit=true` + `workflow.enabled=true` | `page.Act_Soumettre=true`, `page.Workflow_Actif=true` (l'upsert `Param_Workflow_Typ_Document` est fait par « Publier ») |
| composants ENT (zoom/date/calculated/source/memo) | `components[].Typ_Controle` ZOOM/DATE/CALCULE/SOURCE/MEMO |
| `JOURS` (detail_grid) | `sqlStructure[1]` DET + colonnes physiques |
| `calculated` + `persist=true` | colonne physique `Nb_Jours decimal(5,1)` |
| `source` + `persist=false` | `Solde_Conge.Nom_Colonne=''` : aucune colonne physique |
| pied de grille | `Pied_Nb` : `CALCULE`, `Nom_Colonne=''`, `Persiste=false`, agrégat SUM (pattern officiel, migration 005) |
| `is_criteria` (Matricule, Dat_Debut) | `estCritere=true`, `Rang_Critere=1,2` |
| `default_policy=deny` | `page.Acces_Personnalise=true` (appliqué à la création) |
| rôle `'1'` (tous droits) | **hors fichier** (`metadata.habilitations="EXCLUES"`) : étape manuelle ci-dessous |

## 3. Avertissements d'import attendus

- Aucun si la base cible contient : section `MesDemandes`, zoom `MS067`,
  icône `HomeWork` (rubrique `SP_Menu_Icones`), source `solde_conge` active.
- Sinon, l'import les signale (« Dépendance non résolue… ») : à corriger dans
  l'onglet Conception **avant** l'enregistrement.

## 4. Étapes manuelles post-import (obligatoires)

1. `SP_Page_Designer` → **« Importer JSON »** → sélectionner
   `RHP_Page_TELETRAVAIL.json` → vérifier l'aperçu (mode NOUVELLE PAGE,
   compteurs : 2 tables, 8 colonnes, 10 champs, 1 source, 4 validations) →
   **« Valider »**.
2. Vérifier la configuration chargée (aucune écriture en base à ce stade).
3. **« Enregistrer »** : contrôles + transaction + création des tables
   `SP_TT_Ent` / `SP_TT_Det_JOURS` (DDL non destructif).
4. Onglet **Habilitations** : accorder au profil `'1'` Consulter/Creer/
   Modifier/Supprimer/Valider (les droits ne sont jamais dans le fichier).
5. **« Publier »** (`page.enabled=true`) : préconditions re-vérifiées ;
   upsert `Controle_Def_Ecran` (`SPP_TELETRAVAIL`) et
   `Param_Workflow_Typ_Document` (`TT`).
6. Configurer le **circuit de signatures** workflow (`Workflow_Signatures*` —
   jamais généré ; pattern : `004_FKM_Workflow_Signature.sql`).
7. Re-connexion au portail (cache du menu) : l'entrée `SPPL_TELETRAVAIL`
   apparaît sous `MesDemandes`.

## 5. Checklist d'acceptation

Voir `references/testing-acceptance-checklist.md` — toutes sections
applicables (section production : non concernée ici).
