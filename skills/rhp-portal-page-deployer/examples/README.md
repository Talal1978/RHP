# Examples

> Les `input.yaml` illustrent le **contrat d'input interne** (structure de
> travail validée via stdin) : ils ne sont **jamais produits** comme livrables.
> Le skill ne génère qu'**un seul fichier : le JSON** ; le compte rendu
> (classification, avertissements attendus, étapes manuelles) est tenu dans la
> réponse finale.

| Exemple | Contenu | Objectif |
|---|---|---|
| `01-frais-km/` | `input.yaml` + `RHP_Page_FRAIS_KM.json` | Reproduit la page officielle `002_SP_Designer_Exemple_FKM.sql` (+ critères de `003_...sql`) : sert d'oracle — le JSON généré doit encoder les mêmes métadonnées (y compris le pied de grille `Pied_Mnt`, qui remplace l'ancienne colonne `Total_Grille` supprimée par la migration 005). |
| `02-teletravail/` | `input.yaml`, `RHP_Page_TELETRAVAIL.json` | Exemple abouti de bout en bout : ENT + DET, zoom, champ calculé persisté, source métier, pied de grille, validations, workflow. |
| `03-consultation-soldes/` | `input.yaml`, `RHP_Page_Consult_Soldes.json` | **Page de consultation** (pattern `references/sources-metier.md` §6.1) : ENT = critères (Année, Matricule) + grille **virtuelle** alimentée par la source TABLE `SRC_SOLDES_CONGES` + `Act_Enregistrer=false` (aucun document parasite). Vérifié sur les tables `RH_Conge`/`RH_Agent` ; oracle du mécanisme en production : page `DUP_CONGE` (grille `PERIODES`). |

Mode d'emploi de l'exemple 02 sur une base de test :

1. Ouvrir `SP_Page_Designer` → **« Importer JSON »** → sélectionner
   `RHP_Page_TELETRAVAIL.json`.
2. Vérifier l'aperçu (mode NOUVELLE PAGE, compteurs, avertissements) →
   **« Valider »**.
3. **« Enregistrer »** (contrôles + création des tables `SP_TT_Ent` /
   `SP_TT_Det_JOURS`), accorder les droits dans l'onglet **Habilitations**,
   puis **« Publier »**.
