# Module « Santé, Infirmerie & Médecine du travail » — Conception fonctionnelle et technique

**Version** : 1.0 (Phase 1 — en attente de validation)
**Statut** : Conception — aucun code métier produit à ce stade
**Socle** : RH-P (RHP_DeskTop VB.NET WinForms / RHP_Portail React + Express / SQL Server)

---

## 1. Principes directeurs

1. **Prolonger RH-P, ne rien réinventer** : workflow de signatures, notifications par triggers, GED (`Param_GED`), audit par triggers (`Audit_Events`), habilitations (`Controle_*`), Crystal Reports, Requêteur sont réutilisés par paramétrage.
2. **Trois domaines cloisonnés** :
   - `SANTE_CLINIQUE` : contenu médical (conclusions, motifs, observations, résultats). Réservé au service médical selon son rôle.
   - `SANTE_ADMIN` : médico-administratif partageable (aptitude, restrictions, échéances, campagnes, statistiques agrégées). RH/HSE selon habilitation.
   - `AT_ADMIN` : accidents du travail administratifs (existant `RH_Declaration_AT` + satellites), sans exposition du dossier clinique.
3. **Paramétrage, jamais de dur** : statuts, périodicités, délais réglementaires, destinataires, seuils d'alerte, durées de conservation sont en base avec **source réglementaire** et **version**.
4. **Historisation irréversible** : une visite/aptitude validée n'est jamais écrasée ; toute correction = nouvelle version motivée.
5. **Audit d'accès médical** : lecture, création, modification, suppression, impression, export, téléchargement tracés dans `RH_Sante_Audit_Acces` (append-only), Desktop **et** portail.
6. **Multi-société / multi-établissement** : `id_Societe` partout (PK composite), référentiels globaux possibles avec `id_Societe = -1`, filtrage par périmètre utilisateur.

## 2. Cartographie du module

### 2.1 Nouveau dossier Desktop : `RHP_DeskTop\RHP\Sante\`

| Écran (classe = `Name_Ecran`) | Rôle | Domaine |
|---|---|---|
| `RH_Sante_Dossier` | Dossier santé de l'agent (onglets : Visites, Aptitudes, Consultations, Examens, Vaccinations, Maladies pro, rappel AT) | CLINIQUE |
| `RH_Sante_Visite` + `RH_Sante_Visite_Liste` | Saisie/validation des visites médicales, échéances, rectifications versionnées | CLINIQUE |
| `RH_Sante_Aptitude` + `RH_Sante_Aptitude_Liste` | Fiches d'aptitude versionnées, édition PDF unitaire/masse, archivage GED | ADMIN (rédaction par le médecin) |
| `RH_Sante_Campagne` | Campagnes de visites + grille des convocations (génération, envoi, suivi réalisation) | ADMIN |
| `RH_Sante_Consultation` + `RH_Sante_Consultation_Liste` | Registre des soins et consultations infirmières | CLINIQUE |
| `RH_Sante_Examen` + `RH_Sante_Examen_Liste` | Examens complémentaires, résultats en GED cloisonnée | CLINIQUE |
| `RH_Sante_Maladie_Pro` + `RH_Sante_Maladie_Pro_Liste` | Suivi des maladies professionnelles | CLINIQUE (déclaration) / ADMIN (statut administratif) |
| `RH_Sante_Vaccination` | Vaccinations/actes préventifs (activable par paramétrage) | CLINIQUE |
| `RH_Sante_Tableau_Bord` | Indicateurs, alertes, échéances (agrégats filtrés par domaine) | ADMIN |
| `RH_Sante_Rapport_Annuel` | Rapport annuel médecine du travail : contrôle des sources, édition, archivage | ADMIN (édition) |
| `RH_Declaration_AT_Suivi` | Satellite AT : distinction travail/trajet, échéancier réglementaire, transmissions, rechutes | AT_ADMIN |
| `RH_Sante_Stats_AT` | Statistiques mensuelles AT (TF/TG) | ADMIN |
| `RH_Sante_Param` | Référentiels : intervenants, périodicités, destinataires AT, étapes, paramètres réglementaires, seuils, conservation | Paramétrage (admin fonctionnel, sans accès clinique) |
| `RH_Sante_Audit` | Consultation de l'audit d'accès médical | SANTE_AUDIT |

Tous ces écrans : `Inherits Ecran`, boutons déclarés dans `Controle_Def_Ecran_Button`, sécurité avancée `Controle_Menu_Avance` (`Typ_Security='SC'` sur Enregistrer/Supprimer/Valider), verrous `Controle_Access`, GED par `PJ=True` + `Index_Ecran`, éditions par `Controle_Def_Ecran_Mod_Edition`.

### 2.2 Portail (`RHP_Portail`)

| Pages (`rhpfe\src\Pages\Sante\`) | Public | Contenu |
|---|---|---|
| `Sante_MaSante.tsx` | Salarié | Ses convocations, ses documents explicitement publiables (conclusion d'aptitude si publiée), rappel de ses AT (lien vers écran existant) |
| `RH_Sante_Visite_Liste.tsx` / `RH_Sante_Visite.tsx` | Service médical | Visites (saisie médecin) |
| `RH_Sante_Aptitude_Liste.tsx` / `RH_Sante_Aptitude.tsx` | Service médical + RH (vue limitée) | Aptitudes ; la vue RH n'expose que conclusion/restrictions |
| `RH_Sante_Consultation_Liste.tsx` / `...Consultation.tsx` | Service médical | Registre infirmerie |
| `RH_Sante_Examen_Liste.tsx` / `...Examen.tsx` | Service médical | Examens + résultats GED |
| `RH_Sante_Campagne.tsx` | Service médical/RH selon droit | Campagnes et convocations |
| `RH_Sante_Maladie_Pro_Liste.tsx` / `....tsx` | Service médical | Maladies professionnelles |
| `RH_Sante_Tableau_Bord.tsx` | Selon domaine | Agrégats uniquement, seuil anti-réidentification |
| `RH_Declaration_AT_Suivi.tsx` | RH/HSE/service médical | Échéancier et transmissions AT |

Backend : `rhpBE\controlers\sante_*.ts`, routes enregistrées dans `root\root.ts`, toutes derrière `validate`.

## 3. Flux métier principaux

### 3.1 Visite médicale et aptitude

```
Campagne (ou spontanée) → Convocation (mail + invitation agenda via Notifications.Agenda=1)
→ Visite saisie par le médecin (Typ_Visite, conclusion clinique, Statut_Aptitude, réserves, restrictions)
→ Validation (Statut='VA') : la visite devient historisée (verrouillage)
→ Calcul de la prochaine échéance (règles Param_Sante_Periodicite) ; ajustement médecin possible avec Motif_Ajustement
→ Fiche d'aptitude générée (version 1) → PDF Crystal → archivage GED dossier médical
→ Correction éventuelle : nouvelle version (Version+1, Num_Aptitude_Prec, Motif_Version obligatoire)
```

### 3.2 Règles de périodicité (cumulables, arbitrées)

- Chaque règle : critère (`STANDARD`, `POSTE` + Cod_Poste, `POSTE_RISQUE`, `NUIT`, `ENCEINTE`, `MINEUR`), périodicité en mois, priorité, dates d'effet (historisée).
- Mode d'arbitrage paramétré (`Param_Sante_Reglement`, clé `MODE_ARBITRAGE_PERIODICITE`) :
  - `MIN` (défaut, principe de précaution) : échéance retenue = **min** des échéances de toutes les règles applicables ;
  - `PRIORITE` : échéance de la règle applicable de plus haute priorité.
- La règle retenue est **tracée** sur la visite (`Cod_Regle_Appliquee`) pour expliquer l'échéance.

### 3.3 Accident du travail (complément sans refonte)

```
RH_Declaration_AT existant (inchangé) ─┬─> Satellite RH_Declaration_AT_Suivi :
                                       │    • Typ_Accident (TRAVAIL/TRAJET/NON_RECONNU)
                                       │    • Échéancier généré depuis Param_Sante_Etape_AT
                                       │      (date de départ paramétrable, délai jours, statut, preuve GED)
                                       │    • Transmissions vers destinataires (Param_Sante_Destinataire)
                                       │    • Alertes J-x / dépassement via Notifications
                                       └─> Certificat validé avec arrêt → génération RH_Conge_Suivi
                                            (Typ_Conge paramétré, ex. 'AAT', deductibleDuConge=0,
                                             statut 'VA' direct, anti-chevauchement Sys_Conge_Check,
                                             Sys_Conge_MajConso, traçabilité Num_Conge sur la ligne AT)
```

**Point de vigilance paie (Q3)** : la génération dans `RH_Conge_Suivi` doit être vérifiée contre `Sys_GetCongePris` et le moteur de paie (Phase 2, test de non-régression obligatoire). Le type `AAT` est créé dans `RH_Conge_Type` avec les flags validés par l'exploitant paie.

### 3.4 Rapport annuel de médecine du travail

1. Écran `RH_Sante_Rapport_Annuel` : choix société + exercice (défaut : année civile précédente).
2. **Étape de contrôle des données sources** : grille d'anomalies (agents sans visite dans la période, visites sans aptitude, AT sans clôture, effectifs incohérents) avec liens vers les écrans.
3. Alimentation automatique : effectifs par catégorie/sexe (`RH_Agent`), visites par type, AT/MP, examens — requêtes dédiées, aucune donnée clinique individuelle.
4. Statuts : `Brouillon → Contrôlé → Validé → Transmis` (preuve de transmission en GED).
5. Édition PDF Crystal (`Sante_Rapport_Annuel.rpt` — **gabarit à faire valider**, le modèle légal de l'arrêté 3125-10 doit être obtenu) + export Excel + archivage GED (société/exercice/version).

## 4. Sécurité et confidentialité (conception)

| Mécanisme | Mise en œuvre |
|---|---|
| Habilitations | 3 fonctions de sécurité transversales `SANTE_CLINIQUE`, `SANTE_ADMIN`, `SANTE_AUDIT` (`Controle_Menu_Functions` + `Controle_Droit_Functions`) ; écrans et boutons sensibles déclarés `SC` ; filtrage lignes par `Controle_Profile_Regles` |
| Backend portail | Homogénéité modules existants : `validate` (JWT) + contrôles dans chaque contrôleur. Helper `module_sante.ts` : `checkSanteAccess(req, domaine)` interroge `Controle_Droit_Functions` pour le `codProfile` du JWT — même esprit que le cloisonnement TeamLeader, table d'habilitation du socle |
| UI portail | Masquage selon droits (jamais considéré comme suffisant) ; aucune donnée médicale en `localStorage`/`sessionStorage` ; nettoyage des states au démontage |
| Headers | `Cache-Control: no-store` sur toutes les réponses `sante_*` |
| Audit d'accès | Fonction `Sante_Audit(...)` Desktop (`Module_Sante.vb`) + backend : insert `RH_Sante_Audit_Acces` sur lecture/création/modification/suppression/impression/export/téléchargement, avec succès/échec et motif |
| GED | Dossiers racine « MEDICAL » par objet ; droits `Lecture`/`Cacher` de `Param_GED` restreints aux utilisateurs du service médical (via `Zoom_Hibilitation`) ; whitelist MIME existante (PDF/images) ; taille ≤ 50 Mo (socle) |
| Requêteur | Aucune table/vue clinique référencée dans `Param_Query` ; seules des vues agrégées/autorisées y sont déclarées ; consigne inscrite dans la documentation d'exploitation |
| Agrégats | Seuil minimal d'effectif (`SEUIL_AGREGAT_MIN`, défaut proposé 5) : en dessous, la cellule est masquée |
| Verrou CNDP | Paramètres `CNDP_NUM_AUTORISATION` / `CNDP_DATE_AUTORISATION` / `BLOCAGE_PROD_SANS_CNDP` : tant que le verrou est actif, les fonctions cliniques sont bloquées hors paramétrage |
| Superadmin (profil 1) | Le bypass du profil 1 est codé en dur dans le framework Desktop — **risque résiduel documenté** : gouvernance des comptes exigée (aucun compte d'exploitation en profil 1) ; côté portail, le contrôle est explicite donc effectif |

## 5. Éditions Crystal Reports (gabarits à valider)

| Rapport | Source | Paramètres | Appel | Archivage GED |
|---|---|---|---|---|
| `Sante_Fiche_Aptitude.rpt` | Vue aptitude validée | `Num_Aptitude`, `IDSOC` | Desktop `RH_Sante_Aptitude` (bouton Imprimer auto via `Controle_Def_Ecran_Mod_Edition`) + portail (`getreport`) | Oui — écriture explicite `Param_GED` après génération (catégorie « Aptitudes ») |
| `Sante_Rapport_Incident_AT.rpt` | `RH_Declaration_AT` + détail | `Num_Declaration`, `IDSOC` | Desktop `RH_Declaration_AT` / `RH_Declaration_AT_Suivi` + portail | Oui (catégorie « AT ») |
| `Sante_Rapport_Annuel.rpt` | Requêtes agrégées dédiées | `Annee`, `IDSOC` | `RH_Sante_Rapport_Annuel` | Oui (société/exercice/version) |
| `Sante_Convocation.rpt` (option) | Convocation | `Cod_Campagne`, `Matricule`, `IDSOC` | `RH_Sante_Campagne` | Non (envoi mail avec invitation agenda) |

## 6. Alertes paramétrées (moteur `Notifications` existant)

| Alerte | Déclencheur | Destinataires | Seuils |
|---|---|---|---|
| Visite à planifier / proche / échue / aptitude expirée | `RH_Sante_Visite.Dat_Prochaine_Visite` vs seuils | Médecin, RH (version neutre) | Paramétrables (`ALERTE_VISITE_J1/J2/J3`), N notifications à seuils croissants (escalade simulée par destinataires distincts) |
| Campagne sans convocation / visite non réalisée | `RH_Sante_Convocation.Statut_Convocation` | Service médical | Paramétrable |
| Étape AT en retard / délai proche | `RH_Declaration_AT_Echeance.Dat_Echeance` | RH/HSE + assureur si externe | Paramétrable |
| Document obligatoire manquant | Absence pièce GED typée | Service médical | Paramétrable |
| Rapport annuel à préparer/contrôler/transmettre | Calendrier (`RAPPORT_ANNUEL_MOIS_ALERTE`) | Médecin + Direction | Annuel |
| Résultat d'examen disponible | `RH_Sante_Examen.Dat_Resultat` renseignée | **Notification neutre** (« Un résultat est disponible »), sans contenu médical | Immédiat |

## 7. Points ouverts reportés en Phase 2 (vérifications en base)

1. Définition SQL de `Sys_GetCongePris` et consommation des types de congé par `PayRollEngine` (impact du type `AAT` sur la paie).
2. Colonnes exactes de `RH_Conge_Type` (flags paie) et de `Controle_Profile` (présence `id_Societe`).
3. Existence du type de document workflow `AT` dans `Param_Workflow_Typ_Document`.
4. Plages de zooms disponibles (réservation proposée `MS300–MS349` pour santé, `AT010–AT019` pour satellites AT) — vérifier les collisions.
5. Instance SQL de test et compte de connexion (l'authentification Windows est refusée sur `.\SQL2019` ; utiliser le compte de `rhpBE\serverConfig.json`).
