/**
 * init-config.js — Assistant de configuration du backend RHP_Portail.
 *
 * Usage : node tools/init-config.js
 *
 * Demande les paramètres SQL Server, TESTE la connexion, puis écrit
 * serverConfig.json (mot de passe chiffré avec le même algorithme que
 * l'application, module_encrypt). À lancer en console sur le serveur,
 * depuis le dossier du backend.
 *
 * Si un serverConfig.json existe déjà (reconfiguration), chaque valeur
 * actuelle est proposée par défaut : Entrée la conserve, y compris le
 * mot de passe (déchiffré puis rechiffré, jamais affiché). Le fichier
 * n'est réécrit qu'après un test de connexion réussi : en cas d'échec
 * ou d'abandon, la configuration précédente est conservée.
 *
 * Peut aussi être appelé de façon non interactive par le script
 * d'installation PowerShell avec les arguments :
 *   node tools/init-config.js --server SRV\INSTANCE --db RHP --user sa --pwd xxx --port 3500
 */
const fs = require("fs");
const path = require("path");
const readline = require("readline");

// module_encrypt compilé par tsc (dist/modules/module_encrypt.js)
const { encrypt, decrypt } = require("../dist/modules/module_encrypt.js");

function parseArgs(argv) {
  const args = {};
  for (let i = 2; i < argv.length; i += 2) {
    const key = String(argv[i]).replace(/^--/, "");
    args[key] = argv[i + 1];
  }
  if (args.server && args.db && args.user && args.pwd !== undefined) {
    return {
      server: args.server,
      db: args.db,
      user: args.user,
      pwd: args.pwd,
      port: parseInt(args.port || "3500", 10),
      odbc: args.odbc || "RHP",
    };
  }
  return null;
}

// Lit le serverConfig.json existant (reconfiguration) et déchiffre le mot
// de passe pour le proposer silencieusement comme valeur conservée.
// Retourne null si absent ou illisible (première installation).
function chargerConfigExistante(configPath) {
  try {
    if (!fs.existsSync(configPath)) return null;
    const json = JSON.parse(fs.readFileSync(configPath, "utf-8"));
    if (json.pwd) json.pwd = decrypt(json.pwd); // en clair pour test et réécriture
    return json;
  } catch (e) {
    console.log(
      "Avertissement : serverConfig.json existant illisible, nouvelle configuration."
    );
    return null;
  }
}

async function askInteractive(exist) {
  const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
  });
  const question = (q) => new Promise((resolve) => rl.question(q, resolve));
  try {
    console.log("=== Configuration du backend RHP_Portail ===");
    if (exist) {
      console.log(
        "Configuration existante detectee : Entree conserve la valeur entre crochets."
      );
    }
    const defServer = exist && exist.server ? exist.server : ".\\SQL2019";
    const server =
      (await question(`Serveur SQL (ex. .\\SQL2019 ou SRV,1433) [${defServer}] : `)) ||
      defServer;
    const defDb = exist && exist.db ? exist.db : "RHP";
    const db = (await question(`Base de donnees [${defDb}] : `)) || defDb;
    const defUser = exist && exist.user ? exist.user : "sa";
    const user = (await question(`Utilisateur SQL [${defUser}] : `)) || defUser;
    // Mot de passe : jamais affiché ; Entrée conserve l'actuel s'il existe.
    let pwd;
    if (exist && exist.pwd) {
      pwd = (await question("Mot de passe SQL [inchange] : ")) || exist.pwd;
    } else {
      pwd = await question("Mot de passe SQL : ");
    }
    const defPort = String(exist && exist.port ? exist.port : 3500);
    const port = parseInt((await question(`Port HTTP du portail [${defPort}] : `)) || defPort, 10);
    return { server, db, user, pwd, port, odbc: exist && exist.odbc ? exist.odbc : "RHP" };
  } finally {
    rl.close();
  }
}

async function testConnection(cfg) {
  const sql = require("mssql");
  const serverParts = String(cfg.server).split("\\");
  const server = serverParts[0] === "." ? "localhost" : serverParts[0];
  const instanceName = serverParts.length > 1 ? serverParts[1] : undefined;
  // Support de la forme SRV,port
  let port;
  let host = server;
  const comma = server.split(",");
  if (comma.length > 1) {
    host = comma[0] === "." ? "localhost" : comma[0];
    port = parseInt(comma[1], 10);
  }
  const pool = new sql.ConnectionPool({
    user: cfg.user,
    password: cfg.pwd,
    server: host,
    port: port,
    database: cfg.db,
    options: {
      encrypt: false,
      trustServerCertificate: true,
      instanceName: port ? undefined : instanceName,
      connectTimeout: 10000,
    },
  });
  await pool.connect();
  await pool.request().query("select 1 as ok");
  await pool.close();
}

(async () => {
  try {
    const configPath = path.join(process.cwd(), "serverConfig.json");
    let cfg = parseArgs(process.argv);
    if (!cfg) cfg = await askInteractive(chargerConfigExistante(configPath));

    process.stdout.write("Test de connexion SQL en cours... ");
    try {
      await testConnection(cfg);
      console.log("OK");
    } catch (e) {
      console.log("ECHEC");
      console.error("Connexion impossible : " + (e && e.message ? e.message : e));
      console.error("Verifiez le serveur, l'instance, le port TCP/IP et les identifiants.");
      process.exit(2);
    }

    const json = {
      port: cfg.port,
      odbc: cfg.odbc,
      server: cfg.server,
      user: cfg.user,
      db: cfg.db,
      pwd: encrypt(cfg.pwd),
    };
    fs.writeFileSync(configPath, JSON.stringify(json, null, 2), "utf-8");
    console.log("serverConfig.json ecrit dans " + configPath);
  } catch (e) {
    console.error("Erreur : " + (e && e.message ? e.message : e));
    process.exit(1);
  }
})();
