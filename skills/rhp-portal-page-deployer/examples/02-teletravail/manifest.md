# Manifest — TELETRAVAIL (EXEMPLE-02)

Package généré par le skill `rhp-portal-page-deployer`. Demande : EXEMPLE-02.
Environnement cible : development. Opération : create. Dry-run par défaut : oui.

## 1. Classification des faits

### Verified (sources du dépôt)
- Tables `SP_Page*` (8), contraintes, defaults : `001_SP_Designer_Metadata.sql`.
- Format tables métier + FK + journal : `002_SP_Designer_Exemple_FKM.sql`, `Module_SP_DDL.vb`.
- Procédure de publication : `SP_Page_Designer.vb` (`Publier`).
- Section `MesDemandes` : rubrique `SP_Menu_Portail` seedée par `001_...sql:417`.
- Source `solde_conge` : seedée par `001_...sql:442-449`.
- Zoom `MS067` : utilisé par l'exemple officiel FKM (`002_...sql:54`).
- Profil `'1'` super-admin : convention RHP (`module_sp_engine.ts:271`).

### Assumptions (à confirmer par le preflight)
- Zoom `MS067` existe dans `Controle_Def_Zoom` de l'environnement cible (C2).
- `Sys_Workflow_Signature` est installé (C7) — requis car `workflow.enabled=true`.
- Colonne `Controle_Profile.Cod_Profile` conforme à la découverte (C5).
- `decimal(5,1)` jugé suffisant pour `Nb_Jours` (borné par la validation V04 : lignes ≤ 1).

### Missing
- Aucune (entrée complète).

## 2. Décisions de mapping (input → RHP)

| Input | Cible RHP |
|---|---|
| `page_code=TELETRAVAIL` | `SP_Page.Cod_Page` ; écran `SPP_TELETRAVAIL` ; liste `SPPL_TELETRAVAIL` |
| `document_code=TT` | `Cod_Document`/`Typ_Document` ; tables `SP_TT_Ent`, `SP_TT_Det_JOURS` |
| `title` / `page_name` / `short_title` | `Nom_Page` / `Libelle` / `Libelle_Court` |
| `target_section_code`, `display_order`, `icon` | `Menu_Parent='MesDemandes'`, `Rang=95`, `Icone='HomeWork'` |
| `enabled=true` | publication au 1er déploiement (`PUBLIE`) |
| `actions.submit=true` + `workflow.enabled=true` | `Act_Soumettre='true'`, `Workflow_Actif='true'`, insert `Param_Workflow_Typ_Document` |
| composants ENT (zoom/date/calculated/source/memo) | `SP_Page_Champ.Typ_Controle` ZOOM/DATE/CALCULE/SOURCE/MEMO |
| `JOURS` (detail_grid) | `SP_Page_Table` DET `SP_TT_Det_JOURS` |
| `calculated` + `persist=true` | colonne physique `Nb_Jours decimal(5,1)` |
| `source` + `persist=false` | pas de colonne physique pour `Solde_Conge` |
| `is_criteria` (Matricule, Dat_Debut) | `estCritere='true'`, `Rang_Critere=1,2` |
| `default_policy=deny` + rôle `'1'` | `Acces_Personnalise='true'` + 1 ligne `SP_Page_Droit` |
| `description` | non persistée (aucune colonne — vérifié) ; header + ce manifest |
| `route` (vide) | routes conventionnelles `/myspace/SPPL_TELETRAVAIL/...` |

## 3. Non couvert par le package (documenté)

- Circuit de signature workflow (`Workflow_Signatures*`) : à paramétrer après
  déploiement via l'écran dédié (pattern : `004_FKM_Workflow_Signature.sql`).
- Droits au-delà du profil `'1'` : ajouter des rôles dans l'input après
  vérification `Controle_Profile` (preflight C5).

## 4. Checklist d'acceptation

Voir `references/testing-acceptance-checklist.md` — sections 1 à 6 applicables
(section 7 : production uniquement).
