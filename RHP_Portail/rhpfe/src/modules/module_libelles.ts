// Libellés littéraires des colonnes de grilles.
// Permet d'afficher des intitulés lisibles (ex. "Nom complet")
// à la place des noms de champs techniques (ex. "Nom_Complet").

// Libellés exacts pour les colonnes connues (clés en minuscules)
const libellesConnus: { [key: string]: string } = {
  // Colonnes génériques
  rowid: "N°",
  matricule: "Matricule",
  nom: "Nom",
  prenom: "Prénom",
  nom_agent: "Nom",
  prenom_agent: "Prénom",
  nom_complet: "Nom complet",
  entite: "Entité",
  cod_entite: "Entité",
  lib_entite: "Entité",
  poste: "Poste",
  cod_poste: "Poste",
  lib_poste: "Poste",
  grade: "Grade",
  statut: "Statut",
  dat_du: "Du",
  dat_au: "Au",
  dat_crea: "Créé le",
  created_by: "Créé par",
  cree_par: "Créé par",
  // Formation
  cod_formation: "Code",
  lib_formation: "Formation",
  cod_formateur: "Formateur",
  statut_formation: "Statut",
  budget: "Budget",
  present: "Présent",
  // Evaluation
  evaluation: "Évaluation",
  cod_evaluation: "Évaluation",
  lib_evaluation: "Évaluation",
  statut_evaluation: "Statut",
  cod_survey: "Enquête",
  lib_survey: "Enquête",
  cod_reply: "N° réponse",
  statut_reponse: "Réponse",
  dat_survey: "Date",
};

// Traduction mot à mot pour les colonnes non répertoriées
const traductionMot: { [key: string]: string } = {
  cod: "Code",
  lib: "Libellé",
  dat: "Date",
  num: "N°",
  nbr: "Nombre",
  nb: "Nombre",
  mnt: "Montant",
  qte: "Quantité",
  typ: "Type",
  nom: "Nom",
  prenom: "Prénom",
  statut: "Statut",
  entite: "Entité",
  evaluation: "Évaluation",
  complet: "complet",
  du: "du",
  au: "au",
  reply: "réponse",
  survey: "enquête",
  present: "Présent",
};

// Retourne le libellé littéraire d'une colonne à partir de son nom de champ
export function libelleColonne(nomColonne: string): string {
  if (!nomColonne) return nomColonne;
  const exact = libellesConnus[nomColonne.toLowerCase()];
  if (exact !== undefined) return exact;
  const libelle = nomColonne
    .split("_")
    .filter((mot) => mot !== "")
    .map((mot) => traductionMot[mot.toLowerCase()] ?? mot)
    .join(" ");
  return libelle.charAt(0).toUpperCase() + libelle.slice(1);
}
