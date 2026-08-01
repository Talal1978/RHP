# Matrice d'habilitation — Module Santé (Phase 1, à faire valider)

## 1. Mécanisme technique (socle RH-P, aucun nouveau mécanisme)

1. **Profils** (`Controle_Profile`, gérés par `Admin_Profile`) : profils dédiés proposés — `MED` Médecin du travail, `INF` Infirmier, `AUD_SANTE` Auditeur habilité — en plus des profils RH/HSE/Direction existants de chaque organisation.
2. **Fonctions de sécurité transverses** (`Controle_Menu_Functions` + `Controle_Droit_Functions`) :
   - `SANTE_CLINIQUE` : accès au contenu médical ;
   - `SANTE_ADMIN` : accès au médico-administratif (aptitude publiée, restrictions, campagnes, agrégats) ;
   - `SANTE_AUDIT` : consultation du journal d'accès médical.
3. **Écrans** : `Controle_Droit` (Visible/Actif) par profil ; boutons sensibles `SC` dans `Controle_Menu_Avance`/`Controle_Droit_Avance`.
4. **Filtrage lignes** : `Controle_Profile_Regles` (Desktop) ; portail : cloisonnement explicite dans chaque contrôleur (homogène aux modules existants : TeamLeader/Matricule + helper `checkSanteAccess` sur `Controle_Droit_Functions`).
5. **GED** : droits `Lecture`/`Ecriture`/`Cacher` de `Param_GED` restreints aux `id_User` du service médical.
6. **Principe** : administrer les habilitations (`Admin_Profile`) ≠ consulter le contenu médical. Aucun droit `SANTE_CLINIQUE` n'est accordé par défaut ; tout est accordé explicitement par l'organisation.

## 2. Matrice proposée (L = consulter, C = créer, M = modifier, S = supprimer(logique), V = valider, I = imprimer, E = exporter, T = télécharger, — = aucun)

| Objet / Action | Médecin | Infirmier | Resp. RH | Gest. RH | Resp. HSE | Manager | Direction | Salarié (portail) | Admin fonct. | Admin tech. | Auditeur |
|---|---|---|---|---|---|---|---|---|---|---|---|
| **Dossier clinique** (antécédents, observations) | L C M V I | L C M* | — | — | — | — | — | — | — | — | — |
| **Visites — conclusion clinique** | L C M V I E | L** | — | — | — | — | — | — | — | — | — |
| **Visites — données planning** (date, type, échéance) | L C M V | L C M | L | L | L | — | L | L (siennes) | — | — | — |
| **Aptitudes — rédaction/validation/version** | L C M V I E T | L | — | — | — | — | — | — | — | — | — |
| **Aptitudes — vue RH** (conclusion publiée + restrictions) | L | L | L I E | L I E | L I E | L*** | L | L (sienne, si publiée) | — | — | — |
| **Consultations/soins infirmiers** | L C M V I | L C M | — | — | — | — | — | — | — | — | — |
| **Examens — prescription** | L C M V I | L | — | — | — | — | — | — | — | — | — |
| **Examens — résultats (contenu + GED)** | L M I T | L† | — | — | — | — | — | — | — | — | — |
| **Maladies pro — clinique** | L C M V I | L | — | — | — | — | — | — | — | — | — |
| **Maladies pro — statut administratif** | L | L | L C M | L M | L | — | L | — | — | — | — |
| **Vaccinations** (si activé) | L C M I | L C M | — | — | — | — | — | — | — | — | — |
| **Campagnes/convocations** | L C M V I E | L C M | L C M E | L M | L | — | L | L (siennes) | — | — | — |
| **AT — déclaration/suivi (existant + satellites)** | L | L | L C M V I E | L C M | L C M V I E | L (périmètre) | L | L (siens) | — | — | — |
| **Tableau de bord (agrégats seuillés)** | L E | L | L E | L | L E | L (périmètre) | L E | — | — | — | — |
| **Rapport annuel** | L C M V I E T | L | L I E | L | L I E | — | L I | — | — | — | — |
| **Référentiels & paramètres santé** | L | L | L | L | — | — | — | — | L C M (hors contenu clinique) | — | — |
| **Verrou CNDP / paramètres réglementaires** | L | L | L | — | — | — | L | — | L C M | — | L |
| **Journal d'audit des accès** | — | — | — | — | — | — | — | — | — | — | L E |

\* Infirmier : selon délégation paramétrée par l'organisation (la matrice peut restreindre à la consultation pour certaines rubriques d'actes).
\** Infirmier : lecture de la conclusion selon délégation ; paramétrable.
\*** Manager : uniquement l'information validée et nécessaire à l'aménagement du poste des agents de son périmètre hiérarchique (`RacineHierarchique`).
\† Résultats d'examens : selon la colonne `Visibilite` de l'examen (`MED` = médecin du travail, `AUT` = médecin auteur/prescripteur uniquement) ; l'infirmier n'y accède que si la matrice de l'organisation l'y autorise explicitement.

## 3. Règles transverses

1. **Refus testé côté serveur** : chaque endpoint/API est testé en positif et négatif par rôle et par société (IDOR inclus).
2. **Exports/impressions/téléchargements** : même habilitation que la consultation + écriture dans `RH_Sante_Audit_Acces`.
3. **Profil 1 (superadmin)** : bypass codé en dur côté Desktop — risque documenté ; gouvernance : aucun compte d'exploitation en profil 1 ; côté portail le contrôle est explicite et effectif.
4. **Périmètre multi-établissements** : filtrage par `Cod_Entite`/racine hiérarchique selon le profil, comme les modules existants.
5. **Validation de cette matrice** : à faire approuver par l'organisation et son médecin du travail avant paramétrage en production.
