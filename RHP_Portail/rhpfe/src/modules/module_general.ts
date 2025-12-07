import { TAgent } from "../types";

export const Num_Version = "2024.000.00";
export const Connexion = "http://localhost:3500/api/";
export let myJwt = "";

export const setJwt = (jwtKey: string) => {
  myJwt = jwtKey;
};

export let Agent: TAgent = {
  codProfile: "",
  Login: "",
  Typ_Role: "",
  Cod_Poste: "",
  Cod_Entite: "",
  Matricule: "",
  Nom: "",
  Mail: "",
  id_Societe: "",
  TeamLeader: false,
  RacineHierarchique: "",
};
export const setAgent = (Ag: TAgent) => (Agent = { ...Ag });
export const colorBase = {
  colorBase01: "#3899b9",
  colorBase02: "#5eb975",
  colorBase03: "#f05a0a",
  colorBase04: "#e6f4f1",
  foreColorBase01: "#382424",
  bgColorBase01: "#fafafa",
};
export function IsNull(champs: any, retour: any) {
  return champs ?? retour;
}
export function getRandomKey() {
  return Math.floor(Math.random() * 10000);
}
