/* ============================================================================
   Module SP_ - Types des métadonnées (miroir de SP_Page* côté serveur)
   ============================================================================ */
export type TSpPage = {
  Cod_Page: string;
  Cod_Document: string;
  Libelle: string;
  Libelle_Court: string;
  Nom_Page: string;
  Menu_Parent: string;
  Rang: number;
  Icone: string;
  Statut_Page: "BROUILLON" | "PUBLIE" | "DESACTIVE" | "ARCHIVE";
  Table_Ent: string;
  Typ_Document: string;
  Workflow_Actif: string;
  Cod_Modele_Edition: string;
  GED_Actif: string;
  GED_Categories: string;
  GED_Obligatoire: string;
  Act_Enregistrer: string;
  Act_Soumettre: string;
  Act_Imprimer: string;
  Act_Exporter: string;
  Version_Page: number;
};
export type TSpTable = {
  Cod_Table: string;
  Nom_Physique: string;
  Role_Table: "ENT" | "DET";
  Libelle: string;
  Rang: number;
  Allow_Add: string;
  Allow_Edit: string;
  Allow_Delete: string;
  Allow_Duplicate: string;
  Tri_Defaut: string;
  Regle_Suppression: string;
};
export type TSpColonne = {
  Cod_Table: string;
  Nom_Colonne: string;
  Libelle: string;
  Typ_Sql: string;
  Longueur: number | null;
  Precision_Sql: number | null;
  Echelle_Sql: number | null;
  Nullable: string;
  Valeur_Defaut: string | null;
  Technique: string;
  Rang: number;
};
export type TSpChamp = {
  Cod_Champ: string;
  Cod_Table: string;
  Nom_Colonne: string;
  Libelle: string;
  Typ_Controle:
    | "TEXT" | "MEMO" | "INT" | "DEC" | "MNT" | "DATE" | "DATETIME"
    | "CHECK" | "RADIO" | "COMBO" | "RUBRIQUE" | "ZOOM" | "CALCULE" | "SOURCE" | "GED";
  Rang: number;
  Ligne: number | null;
  Colonne: number | null;
  Largeur: number | null;
  Valeur_Defaut: string | null;
  Aide: string | null;
  Obligatoire: string;
  Etat: "S" | "R" | "A" | "I";
  Rubrique: string | null;
  Num_Zoom: string | null;
  Zoom_Retour: string | null;
  Source_Metier: string | null;
  Formule: string | null;
  Persiste: string;
  Recalc_Save: string;
  Format_Affichage: string | null;
  Decimales: number | null;
  Regle_Visibilite: string | null;
  Regle_Activation: string | null;
  Visible_Grille: string;
  Rang_Grille: number;
  Largeur_Colonne: number | null;
  Total_Grille: string;
  estCritere: string;
  Rang_Critere: number | null;
};
export type TSpValidation = {
  Cod_Validation: string;
  Portee: "CHAMP" | "ENTETE" | "LIGNE" | "DETAIL" | "DOCUMENT";
  Cod_Table: string | null;
  Cod_Champ: string | null;
  Typ_Regle: string;
  Parametres: string | null;
  Condition_Regle: string | null;
  Message: string;
  Niveau: "I" | "W" | "B";
  Rang: number;
  Moment: "SAISIE" | "CHANGE" | "AJOUT_LIGNE" | "SAVE";
  Actif: string;
};
export type TSpMeta = {
  page: TSpPage;
  tables: TSpTable[];
  colonnes: TSpColonne[];
  champs: TSpChamp[];
  validations: TSpValidation[];
  droits: { [action: string]: boolean };
};
export type TSpErreur = {
  codValidation: string;
  portee: string;
  codTable: string;
  codChamp: string;
  ligne: number;
  niveau: "I" | "W" | "B";
  message: string;
};
export type TSpContexte = {
  entete: { [k: string]: any };
  details: { [codTable: string]: any[] };
};
