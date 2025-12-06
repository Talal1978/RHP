import jwt from "jsonwebtoken";
import { VGLOBALES } from "./module_initialisation";
import { Response, NextFunction, Request } from "express";
import { TAgent } from "../src/types";
export type TJwtSession = TAgent & {
  processId: string;
  TeamLeader: string;
};
let jwtSessions: TJwtSession[] = [];
export const getToken = (
  codProfile: string,
  Login: string,
  Typ_Role: string,
  Cod_Poste: string,
  Cod_Entite: string,
  Matricule: string,
  Nom: string,
  Mail: string,
  id_Societe: string,
  TeamLeader: string,
  RacineHierarchique: string,
  id_User: string,
) => {
  const processId = String(Math.floor(Math.random() * 100000));
  let stoken = "";
  const secret_key: jwt.Secret = VGLOBALES.JWT_KEY;
  stoken = jwt.sign(
    {
      processId,
      codProfile,
      Login,
      Typ_Role,
      Cod_Poste,
      Cod_Entite,
      Matricule,
      Nom,
      Mail,
      id_Societe,
      TeamLeader,
      RacineHierarchique,
      id_User,
    },
    secret_key,
    {
      expiresIn: 60 * 60,
    }
  );

  jwtSessions.push({
    processId,
    codProfile,
    Login,
    Typ_Role,
    Cod_Poste,
    Cod_Entite,
    Matricule,
    Nom,
    Mail,
    id_Societe,
    TeamLeader,
    RacineHierarchique,
    id_User,
  });
  return stoken;
};
export const validate = (req: Request, res: Response, next: NextFunction) => {
  if (!req.headers.authorization)
    return res.status(403).send("1 RHP : Accès non authorisé");
  if (req.headers.authorization.split(" ").length === 0)
    return res.status(403).send("2 RHP : Accès non authorisé");
  const jwtStr = req.headers.authorization.split(" ")[1]?.trim();
  if (!jwtStr) return res.status(403).send("3 RHP : Accès non authorisé");
  jwt.verify(jwtStr, VGLOBALES.JWT_KEY, (err, decod) => {
    if (err) return res.status(403).send("4 RHP : Accès non authorisé. " + err);
    const {
      processId,
      codProfile,
      Login,
      Typ_Role,
      Cod_Poste,
      Cod_Entite,
      Matricule,
      Nom,
      Mail,
      id_Societe,
      TeamLeader,
      RacineHierarchique,
      id_User,
    } = decod as TJwtSession;
    const jwtSession = jwtSessions.find((ss) => (ss.processId = processId));
    if (!jwtSession) {

      return res.status(403).send("5 RHP : Accès non authorisé");
    }
    req.params.processId = processId;
    req.params.Login = Login || Mail || Matricule;
    req.params.codProfile = codProfile;
    req.params.Typ_Role = Typ_Role;
    req.params.Cod_Poste = Cod_Poste;
    req.params.Cod_Entite = Cod_Entite;
    req.params.Matricule = Matricule;
    req.params.Nom = Nom;
    req.params.Mail = Mail;
    req.params.id_Societe = id_Societe;
    req.params.TeamLeader = TeamLeader;
    req.params.RacineHierarchique = RacineHierarchique;
    req.params.id_User = id_User;
    VGLOBALES.ACTIVE_PROCESSES.push(processId);
    next();
  });
};
function extractDatafromJwt(token: string) {
  const base64Url = token.split(".")[1]; // Get the payload part of the token
  const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/"); // Convert Base64URL to Base64
  const jsonPayload = decodeURIComponent(
    atob(base64)
      .split("")
      .map(function (c) {
        return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
      })
      .join("")
  );
  return JSON.parse(jsonPayload);
}
export const deconnexion = (processId: string) => {
  const newJwtSessions = jwtSessions.filter((s) => s.processId !== processId);
  jwtSessions = [...newJwtSessions];
};
