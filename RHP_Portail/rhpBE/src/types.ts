import { Socket } from "socket.io";

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
  TeamLeader: boolean | string;
  RacineHierarchique: string;
  id_User: string;
};

export type TColonneCollection = {
  [key: string]: TColonne;
};
export type TColonne = {
  headerText?: string;
  dataType: TDataType;
  readOnly: boolean;
  visible: boolean;
  typeColonne?: "Text" | "Combo" | "Check" | "Calendar";
  dataSource?: ObjetGenerique[];
};
export type TDataType =
  | "int"
  | "float"
  | "datetime"
  | "smalldatetime"
  | "nvarchar"
  | "varchar"
  | "bit"
  | "varbinary"
  | string;

export type ObjetGenerique = {
  [key: string]: any;
};
export type TSociete = {
  id_Societe: number;
  Denomination: string;
  FJ: string;
  Regime: string;
  Activite: string;
  IdentFisc: string;
  RC: string;
  TP: string;
  CNSS: string;
  Adresse: string;
  Cp: string;
  Ville: string;
  Cod_Pays: string;
  Tel: string;
  Fax: string;
  Email: string;
  Cod_TFP: string;
  Cod_Commune: string;
  Moyen_Paiement: string;
  CNSS_Agence: string;
  LeMatricule: string;
  Racine: string;
  Compteur_Auto: boolean;
  Sequence: number;
  DateDebPaie: Date;
  DateFinPaie: Date;
  JourOuvrables: string;
  Masquer_Element_Paie_Agent: boolean;
  Obliger_Demande_Pret: boolean;
};
export const setSocietes = (soc: TSociete[]) => {
  Societes = [...soc];
};
export let Societes: TSociete[] = [
  {
    id_Societe: 0,
    Denomination: "",
    FJ: "",
    Regime: "",
    Activite: "",
    IdentFisc: "",
    RC: "",
    TP: "",
    CNSS: "",
    Adresse: "",
    Cp: "",
    Ville: "",
    Cod_Pays: "",
    Tel: "",
    Fax: "",
    Email: "",
    Cod_TFP: "",
    Cod_Commune: "",
    Moyen_Paiement: "",
    CNSS_Agence: "",
    LeMatricule: "",
    Racine: "",
    Compteur_Auto: true,
    Sequence: 0,
    DateDebPaie: new Date(1900, 0, 1),
    DateFinPaie: new Date(2900, 0, 1),
    JourOuvrables: "1;1;1;1;1;1;0",
    Masquer_Element_Paie_Agent: false,
    Obliger_Demande_Pret: false,
  },
];
