import { colorBase } from "./modules/module_general";

export const styleLabel = {
  color: colorBase.colorBase01,
  fontWeight: "bold",
};
export const styleLabelError = {
  fontSize: "1rem",
  color: "red",
  fontWeight: "bold",
};
export type TAgent = {
  codProfile: string;
  Login: string;
  Typ_Role: string;
  Cod_Poste: string;
  Cod_Entite: string;
  Matricule: string;
  Nom: string;
  Mail: string;
  id_Societe: string;
  TeamLeader: boolean;
  RacineHierarchique: string;
};
export type TFindLibelle = {
  champs: string;
  code: string;
  tblName: string;
};
export type TMenuBtn = {
  name: string;
  libelle: string;
  icon: React.ReactNode;
  action: () => void;
  disabled: boolean;
  visible?: "visible" | "none";
  color?: string;
};
export type TSignature = {
  typ_document: string;
  valeur_index: string;
};
export type TGed = {
  name_ecran: string;
  valeur_index: string;
};
export type TAlert = {
  titre?: string;
  msg: string | JSX.Element;
  typMsg?: "warning" | "error" | "info" | "success";
  timeOut?: number;
};

export type TMsgBox = {
  titre?: string;
  msg: string | JSX.Element;
  typMsg?: "warning" | "error" | "info" | "question" | "stop";
  typReply?: "OkOnly" | "YesNoCancel" | "OKCancel";
  handleOk?: () => Promise<any>;
  handleYes?: () => Promise<any>;
  handleNo?: () => Promise<any>;
  handleCancel?: () => Promise<any>;
};
export type TMsgBoxResult = "Ok" | "Cancel" | "Yes" | "No";
export const MsgBoxResult = {
  Ok: "Ok",
  Cancel: "Cancel",
  Yes: "Yes",
  No: "No",
};
export type ICompetence = {
  Competence: string;
  Intitule: string;
  Note: number;
};

export type ObjetGenerique = {
  [key: string]: any;
};

export type TInputType =
  | "number"
  | "integer"
  | "cin"
  | "date"
  | "text"
  | "email"
  | "password";
