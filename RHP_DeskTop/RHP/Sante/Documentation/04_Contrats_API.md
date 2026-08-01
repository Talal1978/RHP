# Contrats API — Backend portail (`rhpBE`) — Module Santé (Phase 1)

Conventions reprises du socle : routes **POST** à plat dans `root\root.ts`, préfixe `/api/` ; handlers dans `controlers\sante_*.ts` ; SQL paramétré via `lireSql`/`ecrireSql` (`modules\module_sqlRW.ts`) ; anti-injection `controleInjection` sur les filtres texte ; réponses `{ result, data?, fields?, message? }` ; `id_Societe` toujours issu du JWT (jamais du body) ; listes plafonnées (`TOP 50` + fenêtres de dates) ; workflow via `sousmettre_signature`.

## 1. Sécurité appliquée à chaque endpoint (homogène au socle)

```
validate (JWT) → const { processId, ...theAgent } = req.params
→ checkSanteAccess(theAgent, '<DOMAINE>', '<action>')   // module_sante.ts
     • lit Controle_Droit_Functions pour (theAgent.codProfile, 'SANTE_CLINIQUE' | 'SANTE_ADMIN' | 'SANTE_AUDIT')
     • salarié 'Agent' : accès uniquement à ses propres objets publiables (matricule = theAgent.Matricule)
     • écrit dans RH_Sante_Audit_Acces (succès ET refus AUTH_KO)
→ logique métier (SQL paramétré, filtre id_Societe systématique)
→ res.setHeader('Cache-Control', 'no-store') + audit LECT/CREA/MODI/SUPP/EXPO/TELE
```

Le helper `checkSanteAccess` est un contrôleur-adjacent (même esprit que le cloisonnement `TeamLeader` des listes existantes) — il ne modifie aucun module existant.

## 2. Endpoints

### 2.1 Dossier & visites (domaine CLINIQUE sauf mention)

| Endpoint | Body | Réponse | Domaine |
|---|---|---|---|
| `sante_dossier` | `{ Matricule }` | `{ result, data: [dossier] }` (404 clinique si non autorisé) | CLINIQUE |
| `sante_visite_liste` | `{ Matricule?, Typ_Visite?, Statut?, Dat_Du?, Dat_Au? }` | `{ result, data, fields }` — colonnes cliniques incluses | CLINIQUE |
| `sante_visite_liste_planning` | idem | mêmes lignes **sans** `Conclusion` (planning/échéances) | ADMIN |
| `get_sante_visite` | `{ Num_Visite }` | `{ result, data: [visite] }` | CLINIQUE |
| `save_sante_visite` | `{ entete }` | upsert ; refuse la modif si `Statut='VA'` (sauf nouvelle rectification avec `Num_Visite_Rectifiee` + `Motif_Rectification`) ; recalcule `Dat_Prochaine_Visite` via `Sys_Sante_Prochaine_Visite` ; si `Statut='SS'` → signature `'VM'` | CLINIQUE |
| `delete_sante_visite` | `{ Num_Visite }` | Refus si validée ; sinon suppression + `Mouchard_Suppression` | CLINIQUE |
| `sante_calcul_echeance` | `{ Matricule, Dat_Visite }` | `{ result, data: [{ Dat_Prochaine_Visite, Cod_Regle }] }` | CLINIQUE |

### 2.2 Aptitudes (rédaction CLINIQUE ; consultation ADMIN si `Publie_RH=1`)

| Endpoint | Remarque |
|---|---|
| `sante_aptitude_liste` | Filtres ; colonnes selon domaine (CLINIQUE = tout ; ADMIN = uniquement publiées) |
| `get_sante_aptitude` | Idem, par `Num_Aptitude` |
| `save_sante_aptitude` | Jamais d'update sur version validée : création `Version+1` avec `Motif_Version` obligatoire ; `Statut='SS'` → signature `'FA'` |
| `sante_aptitude_masse` | `{ Cod_Campagne }` → génération en masse (une ligne d'audit par fiche) |
| `sante_aptitude_pdf` | `{ Num_Aptitude }` → génération PDF (crexport) + archivage GED + audit `IMPR` |

### 2.3 Infirmerie, examens, maladies pro, vaccinations (CLINIQUE)

`sante_consultation_liste|get_|save_|delete_` · `sante_examen_liste|get_|save_|delete_` · `sante_maladie_pro_liste|get_|save_|delete_` · `sante_vaccination_liste|save_` (404 si `ACTIVER_VACCINATIONS<>'O'`).
Règles spécifiques : examen → `Visibilite` contrôlée (MED/AUT) ; résultat GED → téléchargement via `download` existant après revalidation `checkSanteAccess` + audit `TELE` ; maladie pro : statut administratif modifiable par SANTE_ADMIN sans accès au clinique (endpoint dédié `save_sante_maladie_pro_statut`).

### 2.4 Campagnes (ADMIN)

`sante_campagne_liste|get_|save_|delete_` ; `sante_convocation_liste` ; `save_sante_convocation` ; `sante_convocation_generer` (génère les convocations des agents ciblés) ; `sante_convocation_envoyer` (notification externe + invitation agenda).

### 2.5 Satellites AT (AT_ADMIN — profils RH/HSE/médical)

`sante_at_suivi_get` `{ Num_Declaration }` → entête + `Typ_Accident` + échéances + transmissions ; `save_sante_at_typ` ; `sante_at_echeance_liste` / `save_sante_at_echeance` ; `sante_at_transmission_liste` / `save_sante_at_transmission` ; `sante_at_generer_echeances` ; `sante_at_stats` `{ Annee? }` → TF/TG mensuels (vue `RH_Sante_Vue_Stats_AT`).

### 2.6 Espace salarié (rôle Agent, ses données uniquement)

`ma_sante` → `{ result, data: { convocations, aptitudes_publiees, documents } }` — requêtes forcées `Matricule = theAgent.Matricule`, uniquement objets publiables (`Publie_RH=1` ou convocations) ; aucune donnée clinique.

### 2.7 Tableau de bord, rapport annuel, audit

`sante_tableau_bord` (agrégats seuillés `SEUIL_AGREGAT_MIN`) · `sante_rapport_annuel_donnees` `{ Annee }` · `sante_rapport_annuel_controle` (anomalies sources) · `save_sante_rapport_annuel` (statut Brouillon/Contrôlé/Validé/Transmis + preuve GED) · `sante_audit_liste` (**SANTE_AUDIT** uniquement, filtres date/utilisateur/objet).

### 2.8 Référentiels (paramétrage)

`sante_intervenant_liste|save_` · `sante_periodicite_liste|save_` · `sante_reglement_liste|save_` · `sante_destinataire_liste|save_` · `sante_etape_at_liste|save_` — accès : admin fonctionnel (profil paramétré), **sans** accès clinique ; modifications tracées.

## 3. Contrats de réponse et erreurs

- Succès liste/get : retour brut de `lireSql` (`{ result: true, data, fields, sort: 'succès' }`).
- Erreur métier : `{ result: false, message: '...' }` (messages **sans** contenu médical ni identifiants internes sensibles).
- Refus d'habilitation : `{ result: false, message: 'Accès non autorisé' }` (générique, sans détailler la règle) + ligne `AUTH_KO` dans l'audit.
- Upload : réutilise `/api/uploadfile` (whitelist MIME + 50 Mo) ; l'association à l'examen est faite par `save_sante_examen` (`FD_Resultat`).

## 4. Non-régression imposée

Aucun endpoint existant n'est modifié. Les seuls points de contact avec l'existant :
1. `RH_Conge_Suivi` : **écriture** par `Sys_Sante_AT_Generer_Absence` (nouvelle SP) — tests paie/absences obligatoires ;
2. `RH_Declaration_AT[_Detail]` : ajout de colonnes NULL (aucune modification des écrans/endpoints existants) ;
3. `Param_GED` : écriture d'archivage PDF (pattern `Zoom_GED.AjouterFicher` / `module_file.ts`).
