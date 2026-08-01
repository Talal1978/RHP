import { TAgent } from "../types";

export const Num_Version = "2026.000.04";
export const Connexion = "http://localhost:3500/api/";

const defaultAgent: TAgent = {
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

function getStoredAgent(): TAgent {
  try {
    const s = localStorage.getItem("auth_agent");
    if (s) return { ...defaultAgent, ...JSON.parse(s) };
  } catch { /* ignore */ }
  return { ...defaultAgent };
}

// ATTENTION : Variables globales mutables.
// En mode concurrent React 19, privilégiez l'utilisation du AuthContext (useAuth)
// plutôt que la lecture directe de ces variables.
export let myJwt = localStorage.getItem("auth_token") || "";

export const setJwt = (jwtKey: string) => {
  myJwt = jwtKey;
  if (jwtKey) localStorage.setItem("auth_token", jwtKey);
  else localStorage.removeItem("auth_token");
};

export let Agent: TAgent = getStoredAgent();

export const setAgent = (Ag: TAgent) => {
  Agent = { ...Ag };
  localStorage.setItem("auth_agent", JSON.stringify(Agent));
};

export function refreshAgentFromStorage(): void {
  Agent = getStoredAgent();
  myJwt = localStorage.getItem("auth_token") || "";
}

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
