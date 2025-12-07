export type TQuestionType = "alpha" | "choix" | "cocher" | "date" | "dateTime" | "echelle" | "entier" | "grille_cases" | "grille_choix" | "grille_libre" | "heure" | "liste" | "numerique" | "oui_non" | "paragraph" | "vrai_faux" | "multiLine";

export type TModeScoring = "auto" | "multi_sum" | "multi_avg" | "multi_min" | "multi_max" | "manuel" | "func" | "na";

export type TNoteResult = { note: number; coef: number; note_totale: number; max_score?: number; min_score?: number; note_manuelle?: boolean; };

export interface TQuestion {
  NumQuestion: number;
  Typ_Reponse: TQuestionType;
  Cod_Question: number;
  Question: string;
  Sous_Question: string;
  Reponses_Possibles: string;
  Obligatoire: boolean;
  AvecNote: boolean;
  Mode_Scoring: TModeScoring;
  Max_Score: number;
  Func_Scoring: string;
  Coef: number;
  Obligatoire_Si: string;
  Erreur_Si: string;
  Erreur_Msg: string;
}

export interface TDbAnswer {
  Cod_Reply: number;
  Cod_Question: number;
  Num_Sous_Question: string;
  Reponses: string;
  Note: number;
  Coef: number;
  Note_Totale: number;
  Statut: string;
  Paie_Calculee: string;
}

export interface TAnswerState {
  value: any;
  note: TNoteResult | null;
  isVisible: boolean;
  isMandatory: boolean;
  hasError: boolean;
  errorMsg: string;
  typ_reponse: TQuestionType;
  mode_scoring: TModeScoring;
}

export interface TAnswers {
  [key: number]: TAnswerState;
}

export type ChildHandle = {
  save: () => Promise<void>;
};
