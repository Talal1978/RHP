# Modèle de données SQL Server — Module Santé (conception Phase 1)

Conventions appliquées (constatées dans le socle) : tables `<Domaine>_<Entité>` FR singulier ; PK = clé métier `nvarchar` + `id_Societe` ; détails `RowId IDENTITY` ; audit `Dat_Crea/Created_By/Dat_Modif/Modified_By` ; référentiels globaux `id_Societe = -1` ; listes de valeurs dans `Param_Rubriques` ; objets serveur `Sys_*` ; **aucune cascade destructive** ; suppressions tracées (`Mouchard_Suppression`) ; archivage logique pour le domaine santé.

Sensibilité : **C** = clinique (SANTE_CLINIQUE) · **A** = médico-administratif (SANTE_ADMIN) · **T** = AT administratif · **P** = paramétrage.

---

## 1. Tables métier

### 1.1 `RH_Sante_Dossier` — dossier santé de l'agent (1:1) — Sensibilité C

| Colonne | Type | Null | Défaut | Clé | Règle métier | Rôles |
|---|---|---|---|---|---|---|
| Matricule | nvarchar(20) | NO | — | PK | Agent (`RH_Agent`) | Médecin RW, Infirmier RW |
| id_Societe | int | NO | — | PK | | |
| Groupe_Sanguin | nvarchar(5) | YES | NULL | | Rubrique `Groupe_Sanguin` | Médecin/Infirmier |
| Medecin_Traitant | nvarchar(100) | YES | NULL | | Texte libre | Médecin/Infirmier |
| Antecedents | nvarchar(max) | YES | NULL | | Clinique | Médecin RW, Infirmier R |
| Observations | nvarchar(max) | YES | NULL | | Clinique | Médecin RW |
| Dat_Derniere_Visite | datetime | YES | NULL | | Dénormalisé, MAJ à la validation d'une visite | Lecture SANTE_ADMIN |
| Dat_Prochaine_Visite | datetime | YES | NULL | | Calculée (règles) ou ajustée | Lecture SANTE_ADMIN |
| Statut_Aptitude_Courant | nvarchar(10) | YES | NULL | | Dernière aptitude validée (rubrique `Statut_Aptitude`) | Lecture SANTE_ADMIN |
| Archive | bit | YES | 0 | | Suppression logique (module santé uniquement) | |
| Dat_Crea / Created_By / Dat_Modif / Modified_By | — | | | | Standard socle | |

### 1.2 `RH_Sante_Visite` — visites médicales — Sensibilité C (conclusion) / A (aptitude, échéance)

| Colonne | Type | Null | Clé | Règle métier |
|---|---|---|---|---|
| Num_Visite | nvarchar(20) | NO | PK | `'VM'+id_Societe+'-'+année+seq(6)` (pattern socle) |
| id_Societe | int | NO | PK | |
| Matricule | nvarchar(20) | NO | | Agent |
| Dat_Visite | datetime | NO | | |
| Typ_Visite | nvarchar(10) | NO | | Rubrique `Typ_Visite` : EMB (embauche), PRD (périodique), RPR (reprise), SPO (spontanée) — extensible |
| Cod_Medecin | nvarchar(20) | YES | | `Param_Sante_Intervenant` (typ MEDECIN) |
| Cod_Campagne | nvarchar(20) | YES | | Lien campagne |
| Conclusion | nvarchar(max) | YES | | **Clinique — jamais exposée hors SANTE_CLINIQUE** |
| Statut_Aptitude | nvarchar(10) | YES | | Rubrique `Statut_Aptitude` |
| Reserves | nvarchar(500) | YES | | Réserves ( médico-administratif, visible selon matrice ) |
| Restrictions | nvarchar(500) | YES | | Restrictions de poste (partageables RH si publiées) |
| Dat_Prochaine_Visite | datetime | YES | | Calculée puis ajustable |
| Cod_Regle_Appliquee | nvarchar(20) | YES | | Trace de la règle de périodicité retenue |
| Motif_Ajustement | nvarchar(250) | YES | | **Obligatoire si échéance ajustée manuellement** |
| Num_Visite_Rectifiee | nvarchar(20) | YES | | Lien version : rectifie la visite indiquée |
| Motif_Rectification | nvarchar(250) | YES | | Obligatoire si rectification |
| Statut | nvarchar(3) | YES | `''` | Cycle socle : ''/SS/VA/SG/RJ ; **VA = historisé, verrouillé** |
| + audit standard | | | | |

Index : `(id_Societe, Matricule)`, `(id_Societe, Dat_Prochaine_Visite)`, `(id_Societe, Statut)`.

### 1.3 `RH_Sante_Aptitude` — fiches d'aptitude versionnées — Sensibilité A

| Colonne | Type | Null | Clé | Règle métier |
|---|---|---|---|---|
| Num_Aptitude | nvarchar(20) | NO | PK | `'FA'+id_Societe+'-'+année+seq(6)` |
| id_Societe | int | NO | PK | |
| Num_Visite | nvarchar(20) | YES | | Visite source |
| Matricule | nvarchar(20) | NO | | |
| Dat_Aptitude | datetime | NO | | |
| Cod_Medecin | nvarchar(20) | YES | | |
| Statut_Aptitude | nvarchar(10) | NO | | Rubrique |
| Reserves | nvarchar(500) | YES | | |
| Restrictions_Poste | nvarchar(500) | YES | | Nécessaires à l'aménagement du poste |
| Amenagements | nvarchar(500) | YES | | |
| Dat_Effet | datetime | NO | | |
| Dat_Fin | datetime | YES | | Fin de validité |
| Version | int | NO | 1 | |
| Num_Aptitude_Prec | nvarchar(20) | YES | | Version précédente |
| Motif_Version | nvarchar(250) | YES | | Obligatoire si Version > 1 |
| Publie_RH | bit | YES | 0 | Si 1 : conclusion+restrictions visibles SANTE_ADMIN |
| FD_PDF | int | YES | | `Param_GED.FD_id` du PDF archivé |
| Statut | nvarchar(3) | YES | | ''/SS/VA/SG/RJ ; **une version validée n'est jamais modifiée** |
| + audit standard | | | | |

### 1.4 `Param_Sante_Periodicite` — règles de périodicité (historisées) — P

| Colonne | Type | Null | Clé | Règle métier |
|---|---|---|---|---|
| Cod_Regle | nvarchar(20) | NO | PK | |
| id_Societe | int | NO | PK | `-1` = global |
| Lib_Regle | nvarchar(150) | YES | | |
| Critere | nvarchar(20) | NO | | `STANDARD`, `POSTE`, `POSTE_RISQUE`, `NUIT`, `ENCEINTE`, `MINEUR` (rubrique `Critere_Periodicite`) |
| Valeur_Critere | nvarchar(50) | YES | | Ex : Cod_Poste si Critere='POSTE' |
| Periodicite_Mois | int | NO | | > 0 |
| Priorite | int | NO | 100 | Plus petit = plus prioritaire (mode PRIORITE) |
| Dat_Deb_Effet | datetime | NO | | Versionnement temporel |
| Dat_Fin_Effet | datetime | YES | | |
| Source_Reglementaire | nvarchar(250) | YES | | Référence du texte (ex : « Art. 309 CT — à valider ») |
| Actif | bit | YES | 1 | |
| + audit standard | | | | |

### 1.5 `RH_Sante_Campagne` + `RH_Sante_Convocation` — A

`RH_Sante_Campagne` : `Cod_Campagne` PK + `id_Societe` PK, `Lib_Campagne`, `Typ_Visite`, `Dat_Deb`, `Dat_Fin`, `Cod_Medecin`, `Lieu`, `Statut` (rubrique `Statut_Campagne` : PRE/ENC/CLO), audit.

`RH_Sante_Convocation` : `RowId IDENTITY` PK, `Cod_Campagne`, `id_Societe`, `Matricule`, `Dat_Convocation`, `Heure` nvarchar(5), `Statut_Convocation` (rubrique : PRE planifiée, ENV envoyée, RSA réalisée, ABS absente, REP reportée), `Dat_Envoi`, `Num_Visite` (renseigné à réalisation), `Commentaire`, audit. Index `(id_Societe, Cod_Campagne)`, `(id_Societe, Matricule)`.

### 1.6 `RH_Sante_Consultation` — registre infirmerie — C

`Num_Consultation` PK (`'CS'+...`) + `id_Societe` PK, `Matricule`, `Dat_Consultation`, `Cod_Intervenant` (infirmier/médecin), `Typ_Acte` (rubrique `Typ_Acte_Infirmier` : SOIN, PANS, URGE, CONS, VACC…), `Motif` nvarchar(500) **clinique**, `Observations` nvarchar(max) **clinique**, `Suite` (rubrique `Suite_Consultation` : RET retour poste, ARR arrêt, ORI orientation, HOP hôpital), `Num_Declaration_AT` YES (lien si accident), `Statut`, audit.

### 1.7 `RH_Sante_Examen` — examens complémentaires — C

`Num_Examen` PK (`'EX'+...`) + `id_Societe` PK, `Matricule`, `Typ_Examen` (rubrique), `Dat_Prescription`, `Dat_Examen`, `Cod_Medecin_Prescripteur`, `Cod_Prestataire` (`Param_Sante_Intervenant` typ LABO), `Motif` nvarchar(500) **clinique**, `Statut_Examen` (rubrique : PRE prescrit, REA réalisé, RES résultat reçu), `Dat_Resultat`, `Resultat_Resume` nvarchar(max) **clinique**, `Visibilite` (rubrique `Visibilite_Examen` : MED médecin du travail, AUT auteur uniquement), `FD_Resultat` int YES (`Param_GED.FD_id`, pièce cloisonnée), `Dat_Limite_Conservation` (calculée depuis paramètre), `Statut`, audit.

### 1.8 `RH_Sante_Maladie_Pro` — C (déclaration) / A (statut)

`Num_MP` PK (`'MP'+...`) + `id_Societe` PK, `Matricule`, `Dat_Declaration`, `Dat_Premier_Constat`, `Pathologie` nvarchar(250), `Tableau_MP` nvarchar(50) (référence au tableau légal, rubrique), `Organisme`, `Num_Dossier_Org`, `Statut_Declaration` (rubrique `Statut_Declaration_MP` : DEC déclarée, INS en instruction, REC reconnue, REF refusée), `Commentaire`, `Statut`, audit.

### 1.9 `RH_Sante_Vaccination` — C — **option activable** (`ACTIVER_VACCINATIONS`)

`RowId IDENTITY` PK, `Matricule`, `id_Societe`, `Typ_Vaccin` (rubrique), `Dat_Vaccination`, `Dat_Rappel` YES, `Cod_Intervenant`, `Num_Consultation` YES, `Commentaire`, audit. Index `(id_Societe, Matricule)`, `(id_Societe, Dat_Rappel)`.

## 2. Satellites Accidents du Travail — T

### 2.1 Extension de l'existant (ALTERS non destructifs)

- `RH_Declaration_AT` **+ `Typ_Accident` nvarchar(20) NULL** (rubrique `Typ_Accident` : TRAVAIL / TRAJET / NREC non reconnu ; défaut `TRAVAIL`). Écran existant inchangé ; la colonne est administrée depuis `RH_Declaration_AT_Suivi`.
- `RH_Declaration_AT_Detail` **+ `Num_Conge` nvarchar(20) NULL** : trace de l'absence générée dans `RH_Conge_Suivi` à la validation d'un certificat avec arrêt.

### 2.2 `Param_Sante_Destinataire` — P

`Cod_Destinataire` PK + `id_Societe` PK (`-1` global), `Lib_Destinataire`, `Typ_Destinataire` (rubrique : ASS assureur, AUT autorité du travail, CNSS, INT interne, AUTRE), `Delai_Jours` int, `Point_Depart` (rubrique : ACC date accident, DEC date déclaration, GUER guérison), `Source_Reglementaire`, `Actif`.

### 2.3 `Param_Sante_Etape_AT` — P

`Cod_Etape` PK + `id_Societe` PK (`-1` global), `Lib_Etape`, `Rang`, `Cod_Destinataire` YES, `Delai_Jours`, `Point_Depart`, `Source_Reglementaire`, `Actif`. Workflow par défaut proposé (paramétrable) : Brouillon → Déclaré → Infirmerie → RH → Direction → Transmis → Instruction → Clos — aligné sur les étapes de signature existantes quand applicable.

### 2.4 `RH_Declaration_AT_Echeance` — T

`RowId IDENTITY` PK, `Num_Declaration`, `id_Societe`, `Cod_Etape`, `Dat_Debut`, `Delai_Jours`, `Dat_Echeance`, `Statut_Etape` (rubrique `Statut_Etape_AT` : AFA à faire, ENC en cours, FAI fait, DEP dépassé, ANN annulé+motif), `Dat_Realisation`, `FD_Preuve` int YES (GED), `Commentaire`, audit. Index `(id_Societe, Dat_Echeance, Statut_Etape)`.

### 2.5 `RH_Declaration_AT_Transmission` — T

`RowId IDENTITY` PK, `Num_Declaration`, `id_Societe`, `Cod_Destinataire`, `Dat_Transmission`, `Mode_Transmission` (rubrique : MAIL, REMISE, ENLIGNE, COURRIER), `Reference`, `FD_Preuve` int YES, `Commentaire`, audit.

## 3. Paramétrage, référentiels et audit

### 3.1 `Param_Sante_Intervenant` — P

`Cod_Intervenant` PK + `id_Societe` PK (`-1` global), `Nom`, `Prenom`, `Typ_Intervenant` (rubrique : MED médecin, INF infirmier, LAB laboratoire, CAB cabinet, PRV prestataire), `Specialite`, `Num_Ordre`, `Tel`, `Mail`, `Adresse`, `Actif`, audit.

### 3.2 `Param_Sante_Poste_Risque` — P

`Cod_Poste` PK + `id_Societe` PK, `Niveau_Risque` (rubrique), `Expositions` nvarchar(500), `Cod_Regle` YES (règle de périodicité associée — **explique l'échéance**), audit.

### 3.3 `Param_Sante_Reglement` — P — délais et seuils versionnés avec source

| Colonne | Type | Règle |
|---|---|---|
| Cod_Param | nvarchar(50) PK + id_Societe PK (`-1` global) | Ex : `PERIODICITE_STANDARD_MOIS`, `DELAI_DECLARATION_AT_ASSUREUR`, `SEUIL_AGREGAT_MIN`, `DUREE_CONSERVATION_EXAMEN_ANS`, `CNDP_NUM_AUTORISATION`, `CNDP_DATE_AUTORISATION`, `BLOCAGE_PROD_SANS_CNDP`, `ACTIVER_VACCINATIONS`, `MODE_ARBITRAGE_PERIODICITE`, `TYP_CONGE_AT`, `RAPPORT_ANNUEL_MOIS_ALERTE`, `HEURES_TRAVAILLEES_SOURCE`, `TAUX_FREQ_BASE`, `TAUX_GRAV_BASE` |
| Lib_Param | nvarchar(150) | |
| Valeur | nvarchar(250) | |
| Source_Reglementaire | nvarchar(250) | Texte + référence exacte affichée dans l'écran de paramétrage |
| Version_Texte | nvarchar(50) | Version du texte vérifiée |
| Dat_Deb_Effet / Dat_Fin_Effet | datetime | Historisation |
| + audit standard | | |

**Règle absolue** : aucune valeur initiale de délai légal n'est insérée sans vérification du texte en vigueur ; le script n'insère que des clés **vides à compléter**, assorties de leur source à vérifier.

### 3.4 `RH_Sante_Audit_Acces` — journal append-only

| Colonne | Type | Règle |
|---|---|---|
| RowId | bigint IDENTITY PK | |
| id_Societe | int | |
| Login_User | nvarchar(50) | |
| id_User | int | |
| Cod_Profile | nvarchar(10) | |
| Typ_Role | nvarchar(10) | |
| Action | nvarchar(10) | `LECT`, `CREA`, `MODI`, `SUPP`, `IMPR`, `EXPO`, `TELE`, `AUTH_KO` |
| Objet | nvarchar(50) | Table/écran/endpoint |
| Valeur_Index | nvarchar(100) | Identifiant de l'objet |
| Matricule_Concerne | nvarchar(20) | Agent concerné (pas de contenu médical) |
| Dat_Action | datetime | défaut GETDATE() |
| Poste | nvarchar(100) | Machine (Desktop) |
| IP | nvarchar(50) | Portail |
| Succes | bit | |
| Motif | nvarchar(250) | Motif du refus ou de l'opération |

Aucune API d'update/delete ; purge uniquement par la procédure de conservation (`Sys_Sante_Purge`, politique paramétrée).

### 3.5 Rubriques créées (`Param_Rubriques`)

`Statut_Aptitude` (APTE, APTE_RES, INAPTE_TEMP, INAPTE_DEF), `Typ_Visite` (EMB, PRD, RPR, SPO), `Critere_Periodicite`, `Statut_Campagne`, `Statut_Convocation`, `Typ_Acte_Infirmier`, `Suite_Consultation`, `Typ_Examen`, `Statut_Examen`, `Visibilite_Examen`, `Statut_Declaration_MP`, `Typ_Vaccin`, `Typ_Intervenant`, `Typ_Accident`, `Typ_Destinataire`, `Mode_Transmission`, `Statut_Etape_AT`, `Niveau_Risque`, `Groupe_Sanguin`, `Point_Depart_Echeance`. (Réutilisées : `Nature_Lesion`, `Siege_Lesion_AT`, `Typ_Certificat_AT`, `Statut_Signature`.)

## 4. Vues de restitution (séparation des domaines)

| Vue | Contenu | Public |
|---|---|---|
| `RH_Sante_Vue_Aptitude_RH` | Matricule, nom, dernière aptitude **publiée** : statut, restrictions, aménagements, dates effet/fin, prochaine visite. **Aucune colonne clinique.** | SANTE_ADMIN |
| `RH_Sante_Vue_Echeances` | Échéances de visites par agent (sans clinique) | SANTE_ADMIN |
| `RH_Sante_Vue_TB_Aptitudes` | Agrégats : effectif par statut d'aptitude, visites échues/à venir/sans visite — avec masquage sous `SEUIL_AGREGAT_MIN` | SANTE_ADMIN |
| `RH_Sante_Vue_Stats_AT` | Mensuel : nb AT (travail/trajet), jours d'arrêt (somme `Nbr_Jours` des certificats validés), TF = nb AT avec arrêt × base / heures travaillées, TG = jours perdus × base / heures travaillées. Bases et source des heures paramétrées (`TAUX_FREQ_BASE` ex. 1 000 000, `TAUX_GRAV_BASE` ex. 1 000, `HEURES_TRAVAILLEES_SOURCE`) — **formules documentées dans l'écran** | SANTE_ADMIN |
| `RH_Sante_Vue_Rapport_Annuel` | Agrégats annuels pour le rapport (effectifs catégorie/sexe, visites par type, AT/MP) | Service médical |

## 5. Objets serveur `Sys_*` (à créer en Phase 2)

| Objet | Rôle |
|---|---|
| `Sys_Sante_Prochaine_Visite(@Matricule,@id_Societe,@Dat_Visite)` | Calcule la prochaine échéance selon les règles applicables + mode d'arbitrage ; retourne date + `Cod_Regle` |
| `Sys_Sante_Maj_Dossier(@Matricule,@id_Societe)` | Met à jour les champs dénormalisés du dossier après validation |
| `Sys_Sante_AT_Generer_Echeances(@Num_Declaration,@id_Societe)` | Génère l'échéancier depuis `Param_Sante_Etape_AT` |
| `Sys_Sante_AT_Generer_Absence(@RowId)` | Génère l'absence `RH_Conge_Suivi` (type paramétré) à la validation d'un certificat, avec `Sys_Conge_Check` anti-chevauchement puis `Sys_Conge_MajConso` |
| `Sys_Sante_Purge(@id_Societe,@Simuler)` | Purge contrôlée selon durées de conservation (log détaillé) |

## 6. Intégrité et index

- FK logiques vers `RH_Agent (Matricule, id_Societe)` et `Param_Societe (id_Societe)` — **sans `ON DELETE CASCADE`** (conforme au socle qui ne déclare pas de FK physiques : cohérence applicative + contrôles).
- Index sur : `(id_Societe, Matricule)` sur toutes les tables métier ; dates d'échéance ; `Statut` ; `RH_Sante_Audit_Acces (id_Societe, Dat_Action)` et `(Objet, Valeur_Index)`.
- CHECK utiles : `Periodicite_Mois > 0`, `Version >= 1`, `Dat_Fin >= Dat_Effet`, `Delai_Jours >= 0`.

## 7. Conservation et purge

- Durées paramétrées dans `Param_Sante_Reglement` (`DUREE_CONSERVATION_*`), jamais en dur.
- Archivage logique : `Archive=1` (les lignes archivées sont exclues des listes par défaut).
- `Sys_Sante_Purge` : mode simulation par défaut ; exécution réservée au profil paramétré, journalisée dans `RH_Sante_Audit_Acces` (`SUPP`).
- Gel légal : indicateur sur l'objet exclu de la purge (paramétrage documenté).
