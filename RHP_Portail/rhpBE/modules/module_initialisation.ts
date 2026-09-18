import fs from "fs";
import { decrypt, encrypt } from "./module_encrypt";
import readline from "readline";
import path from "node:path";
import { lireSql } from "./module_sqlRW";
import {
  IsNull,
  TablesSQLWithIdSocOuMatricule,
  handleIdSoc,
} from "./module_general";
import { setSocietes, Societes, TAgent } from "../src/types";
import { initAiContext } from "../controlers/ai_assistant";

export const VGLOBALES: {
  PORT: number;
  ODBC_SERVEUR: string;
  SQL_SERVER: string;
  SQL_DB: string;
  SQL_USER: string;
  SQL_PASSWORD: string;
  SMTP_USERNAME: string;
  SMTP_PASSWORD: string;
  SMTP_HOST: string;
  SMTP_PORT: number;
  SMTP_SSL_ACTIVE: boolean;
  SMTP_NOM: string;
  SMTP_FROM: string;
  UPLOADS_PATH: string;
  JWT_KEY: string;
  VERSION: string;
  ACTIVE_PROCESSES: string[];
} = {
  PORT: 3500,
  ODBC_SERVEUR: "",
  SQL_SERVER: "",
  SQL_USER: "",
  SQL_PASSWORD: "",
  SQL_DB: "",
  SMTP_USERNAME: "",
  SMTP_PASSWORD: "",
  SMTP_HOST: "",
  SMTP_PORT: 0,
  SMTP_SSL_ACTIVE: false,
  SMTP_NOM: "",
  SMTP_FROM: "",
  UPLOADS_PATH: "",
  JWT_KEY: process.env.JWT_KEY || "",
  VERSION: "2023.000.12",
  ACTIVE_PROCESSES: [],
};
export let TablesAvecMatricule: string[] = [];
export let TablesAvecIdSoc: string[] = [];
export let Tbl_Controle_Def_Zoom: { [key: string]: string }[];
export async function loadSmtpConfig() {
  const smtpConfig = await lireSql(
    "select top 1 * from Controle_Messagerie"
  );
  if (smtpConfig && smtpConfig.result) {
    VGLOBALES.SMTP_USERNAME = smtpConfig.data[0]["Mail_Addr"];
    VGLOBALES.SMTP_PASSWORD = decrypt(smtpConfig.data[0]["Pwd_Mail"]);
    VGLOBALES.SMTP_HOST = smtpConfig.data[0]["Smtp_Mail"];
    VGLOBALES.SMTP_PORT = smtpConfig.data[0]["Port_Mail"];
    VGLOBALES.SMTP_SSL_ACTIVE = smtpConfig.data[0]["Ssl_Actif"];
    VGLOBALES.SMTP_NOM = smtpConfig.data[0]["Nom_Prenom"];
    VGLOBALES.SMTP_FROM = smtpConfig.data[0]["Mail_From"];
  }
}

export async function initialisationGlobale(theAgent?: TAgent) {
  await initialisationSeveur();

  //Liste des tables avec idSociete
  let rsl = await lireSql(
    "select isnull((select string_agg( lower(object_name(object_id)),';') as Table_Name from sys.columns where name = 'id_Societe' and object_name(object_id)<>'Param_Societe'),'') as tbl",
    []
  );
  if (rsl && rsl.result) TablesAvecIdSoc = rsl.data[0]["tbl"].split(";");
  // Liste des tables avec Matricule
  rsl = await lireSql(
    "select isnull((select string_agg( lower(object_name(object_id)),';') as Table_Name from sys.columns where name = 'Matricule'),'') as tbl",
    []
  );
  if (rsl && rsl.result) TablesAvecMatricule = rsl.data[0]["tbl"].split(";");
  //Définition des menus zoom
  if (theAgent) {
    Tbl_Controle_Def_Zoom = [];
    rsl = await lireSql("select * from Controle_Def_Zoom", []);
    if (rsl && rsl.result) {
      await rsl.data.forEach(async (z: any) => {
        let Zoom_Cod = IsNull(z["Index_Table"], "");
        let Zoom_Lib = IsNull(z["Description"], "");
        let Zoom_Tbl = IsNull(z["Table_Ref"], "");
        let Zoom_Where1 = IsNull(z["Condition"], "");
        let Zoom_Order = IsNull(z["Order_By"], "");
        let ZoomSens = IsNull(z["Order_By_Sens"], "Asc");
        Zoom_Where1 = Zoom_Where1 + " @@@condition ";

        let olistMat = await TablesSQLWithIdSocOuMatricule(
          TablesAvecMatricule,
          Zoom_Tbl,
          z["Num_Zoom"] === "MS067"
        );
        let MatriculeWhere = "";
        if (olistMat.length > 0) {
          if (theAgent.TeamLeader) {
            MatriculeWhere = ` ${olistMat[0].alias}.Matricule in (select Matricule from Rh_Agent _agt where id_Societe=${theAgent.id_Societe} and _agt.Cod_Entite in (
              select  Cod_Entite from Sys_Org_Entite s where 
                          ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('${theAgent.Cod_Entite}',''),'8787uhuhunjj')+';%' and id_Societe=_agt.id_Societe))`;
          } else {
            MatriculeWhere = `(${olistMat[0].alias}.id_Societe=${theAgent.id_Societe} and ${olistMat[0].alias}.Matricule='${theAgent.Matricule}')`;
          }
        }

        Zoom_Where1 =
          Zoom_Where1 + (MatriculeWhere ? `and (${MatriculeWhere})` : "");
        let sqlStr = `select distinct ${Zoom_Cod} as Code,${Zoom_Lib} FROM ${Zoom_Tbl} where ${Zoom_Where1}  ${Zoom_Order != "" ? `Order by ${Zoom_Order} ${ZoomSens}` : ""
          }`;
        sqlStr = await handleIdSoc(sqlStr, theAgent.id_Societe);
        // codExp : expression SQL de la 1ère colonne (Code) — nécessaire pour
        // retrouver le libellé (2e colonne) d'une valeur, l'alias Code n'étant
        // pas utilisable dans le WHERE.
        Tbl_Controle_Def_Zoom.push({ numZoom: z["Num_Zoom"], codExp: Zoom_Cod, sqlStr });
      });
    }
  }
  const soc = await lireSql(
    "select   id_Societe, Den as Denomination,  FJ,  Regime,  Activite,  IdentFisc,  RC,  TP,  CNSS,  Adresse,  Cp,  Ville,  Cod_Pays,  Tel,  Fax,  Email,  Cod_TFP,  Cod_Commune, Moyen_Paiement,  CNSS_Agence,  Racine,  Compteur_Auto,  [Sequence],  isnull(JourOuvrables,'1;1;1;1;1;1;0') JourOuvrables,  Masquer_Element_Paie_Agent,  Obliger_Demande_Pret from Param_societe"
  );
  setSocietes(soc.data);

  loadSmtpConfig();
  initAiContext(theAgent?.id_Societe ? Number(theAgent.id_Societe) : undefined);
}

export const initialisationSeveur = async (): Promise<boolean> => {
  try {
    const configPath = "serverConfig.json";
    // Priorité aux variables d'environnement (déploiement service/conteneur) :
    // si SQL_SERVER + SQL_DB + SQL_USER + SQL_PASSWORD sont fournis, le
    // fichier serverConfig.json n'est pas exigé.
    const envConfig = process.env.SQL_SERVER && process.env.SQL_DB &&
      process.env.SQL_USER && process.env.SQL_PASSWORD
      ? {
          port: Number(process.env.PORT) || 3500,
          odbc: process.env.ODBC_NAME || "RHP",
          server: process.env.SQL_SERVER as string,
          user: process.env.SQL_USER as string,
          db: process.env.SQL_DB as string,
          pwd: process.env.SQL_PASSWORD as string, // déjà en clair
          _fromEnv: true,
        }
      : null;

    let cnfJson: any = envConfig;

    if (!cnfJson && !fs.existsSync(configPath)) {
      // Sans console interactive (service Windows, NSSM, conteneur), le
      // questionnement readline ne répondrait jamais : on arrête net avec
      // un message exploitable dans les journaux.
      if (!process.stdin.isTTY) {
        throw new Error(
          "serverConfig.json introuvable et aucune console interactive disponible. " +
          "Fournir la configuration via les variables d'environnement " +
          "SQL_SERVER, SQL_DB, SQL_USER, SQL_PASSWORD (et PORT en option), " +
          "ou lancer une première fois le serveur en console pour générer le fichier."
        );
      }
      console.log("Configuration file not found. Starting interactive setup...");

      const rl = readline.createInterface({
        input: process.stdin,
        output: process.stdout,
      });

      const question = (query: string): Promise<string> => {
        return new Promise((resolve) => rl.question(query, resolve));
      };

      try {
        const port =
          (await question("Enter Port (default 3500): ")) || "3500";
        const odbc =
          (await question("Enter ODBC Name (default RHP): ")) || "RHP";
        const server =
          (await question("Enter SQL Server (e.g. .\\SQL2019): ")) ||
          ".\\SQL2019";
        const db =
          (await question("Enter le nom de la base de données RHP (default RHP): ")) ||
          "RHP";
        const user = (await question("Enter SQL User (default sa): ")) || "sa";
        const pwd = await question("Enter SQL Password: ");

        rl.close();

        const config = {
          port: parseInt(port),
          odbc: odbc,
          server: server,
          user: user,
          db: db,
          pwd: encrypt(pwd),
        };

        fs.writeFileSync(configPath, JSON.stringify(config, null, 2));
        console.log("Configuration saved successfully.");
        cnfJson = { ...config, pwd: pwd };
      } catch (err) {
        rl.close();
        throw err;
      }
    }

    if (!cnfJson) {
      cnfJson = JSON.parse(fs.readFileSync(configPath, { encoding: "utf-8" }));
      if (!cnfJson.pwd) throw new Error("Password missing in config");
      cnfJson.pwd = decrypt(cnfJson.pwd);
    }

    // Les variables d'environnement peuvent surcharger ponctuellement le
    // fichier (utile en déploiement : changer le port sans régénérer le JSON).
    if (process.env.PORT) cnfJson.port = Number(process.env.PORT);

    VGLOBALES.PORT = cnfJson.port;
    VGLOBALES.ODBC_SERVEUR = cnfJson.odbc;
    VGLOBALES.SQL_SERVER = cnfJson.server;
    VGLOBALES.SQL_USER = cnfJson.user;
    VGLOBALES.SQL_DB = cnfJson.db;
    VGLOBALES.SQL_PASSWORD = cnfJson.pwd;
    // Dossier des fichiers GED/uploadés : UPLOAD_PATH (absolu recommandé en
    // production, ex. C:\RHP_Portail\Uploads), sinon "Uploads" sous le
    // répertoire d'exécution du backend. Créé si absent.
    const opath = process.env.UPLOAD_PATH || "Uploads";
    VGLOBALES.UPLOADS_PATH = path.isAbsolute(opath)
      ? opath
      : path.resolve(process.cwd(), opath);
    if (!fs.existsSync(VGLOBALES.UPLOADS_PATH)) {
      fs.mkdirSync(VGLOBALES.UPLOADS_PATH, { recursive: true });
    }
    return true;
  } catch (err) {
    console.error("Erreur initialisation : ", err);
    throw new Error("Server initialization failed [VGLOBALES]");
  }
};
