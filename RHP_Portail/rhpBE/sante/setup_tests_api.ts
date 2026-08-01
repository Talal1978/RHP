/* Cree les utilisateurs de test du module Sante (100% fictifs, societe 3068).
   - FICTIFMED (medecin, profil 90, SANTE_CLINIQUE)
   - FICTIFINF (infirmier, profil 92, SANTE_CLINIQUE)
   - FICTIFRH  (RH, profil 91, SANTE_ADMIN)
   - FICTIFAUD (auditeur, profil 93, SANTE_AUDIT)
   - FICTIF001 : agent simple (sans fonction), Mail pour login portail
   - FICTIFMED2 (societe 3071, medecin autre societe pour test cross-societe)
   Mot de passe pour tous : Test1234!                                        */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";
import { encrypt } from "../modules/module_encrypt";
import { Int, NVarChar } from "mssql";

const SOC = 3068;
const SOC2 = 3071;
const PWD = "Test1234!";

async function ins(sqlStr: string, params: { param: string; sqlType: any; valeur: any }[] = []) {
  const r = await lireSql(sqlStr, params);
  if (!r.result) console.error("ERREUR SQL:", JSON.stringify(r.sort).substring(0, 300), "\nRequete:", sqlStr.substring(0, 150));
  return r;
}

async function main() {
  await initialisationSeveur();
  const pw = encrypt(PWD);

  // 0. Nettoyage prealable
  await ins(`delete from Controle_Droit_Functions where Cod_Profile in ('90','91','92','93')
              or Cod_Profile in (select convert(nvarchar(10),Cod_Profile) from Controle_Profile where Lib_Profile like 'Santé - %test%')`);
  const oldProfiles = await lireSql(`select Cod_Profile from Controle_Profile where Lib_Profile like 'Santé - %test%'`);
  for (const p of oldProfiles.data || []) {
    await ins(`delete from Controle_Users where Cod_Profile = ${p.Cod_Profile} and Login_User in ('MEDTEST','INFTEST','RHTEST','AUDTEST','MEDTEST2')`);
  }
  await ins(`delete from Controle_Users where Login_User in ('MEDTEST','INFTEST','RHTEST','AUDTEST','MEDTEST2')`);
  await ins(`delete from RH_Agent where Matricule in ('FICTIFMED','FICTIFINF','FICTIFRH','FICTIFAUD','FICTIFMED2')`);
  await ins(`delete from Controle_Profile where Lib_Profile like 'Santé - %test%'`);

  // 1. Profils (Cod_Profile est IDENTITY : on recupere les codes generes)
  const profileDefs = [
    { key: "MED", lib: "Santé - Médecin (test)" },
    { key: "RH", lib: "Santé - RH (test)" },
    { key: "INF", lib: "Santé - Infirmier (test)" },
    { key: "AUD", lib: "Santé - Auditeur (test)" },
  ];
  const codProfiles: { [key: string]: number } = {};
  for (const p of profileDefs) {
    await ins(`insert into Controle_Profile (Lib_Profile, Actif, Created_By, Dat_Crea)
               values ('${p.lib}', 'true', 'TEST', getdate())`);
    const g = await lireSql(`select max(Cod_Profile) as c from Controle_Profile where Lib_Profile='${p.lib}'`);
    codProfiles[p.key] = Number(g?.data?.[0]?.c || 0);
  }
  console.log("Profils crees :", JSON.stringify(codProfiles));

  // 2. Agents (login portail = Mail + Pw)
  const agents = [
    { mat: "FICTIFMED", nom: "DEMO", pre: "Medecin", mail: "medecin@demo.local", soc: SOC },
    { mat: "FICTIFINF", nom: "DEMO", pre: "Infirmier", mail: "infirmier@demo.local", soc: SOC },
    { mat: "FICTIFRH", nom: "DEMO", pre: "Rh", mail: "rh@demo.local", soc: SOC },
    { mat: "FICTIFAUD", nom: "DEMO", pre: "Auditeur", mail: "auditeur@demo.local", soc: SOC },
    { mat: "FICTIFMED2", nom: "DEMO", pre: "MedecinAutre", mail: "medecin2@demo.local", soc: SOC2 },
  ];
  for (const a of agents) {
    await ins(
      `insert into RH_Agent (Matricule, id_Societe, Nom_Agent, Prenom_Agent, Mail, Pw, Droit_Paie, Dat_Crea, Created_By)
       values (@mat, @soc, @nom, @pre, @mail, @pw, 'true', getdate(), 'TEST')`,
      [
        { param: "mat", sqlType: NVarChar, valeur: a.mat },
        { param: "soc", sqlType: Int, valeur: a.soc },
        { param: "nom", sqlType: NVarChar, valeur: a.nom },
        { param: "pre", sqlType: NVarChar, valeur: a.pre },
        { param: "mail", sqlType: NVarChar, valeur: a.mail },
        { param: "pw", sqlType: NVarChar, valeur: pw },
      ]
    );
  }
  // Agent simple (sans compte Controle_Users -> codProfile -1)
  await ins(
    `update RH_Agent set Mail='fictif001@demo.local', Pw=@pw where Matricule='FICTIF001' and id_Societe=@soc`,
    [
      { param: "pw", sqlType: NVarChar, valeur: pw },
      { param: "soc", sqlType: Int, valeur: SOC },
    ]
  );

  // 3. Comptes Controle_Users (profil rattache par Mail au login portail)
  const users = [
    { login: "MEDTEST", profil: codProfiles["MED"], mail: "medecin@demo.local", nom: "Medecin Test" },
    { login: "RHTEST", profil: codProfiles["RH"], mail: "rh@demo.local", nom: "RH Test" },
    { login: "INFTEST", profil: codProfiles["INF"], mail: "infirmier@demo.local", nom: "Infirmier Test" },
    { login: "AUDTEST", profil: codProfiles["AUD"], mail: "auditeur@demo.local", nom: "Auditeur Test" },
    { login: "MEDTEST2", profil: codProfiles["MED"], mail: "medecin2@demo.local", nom: "Medecin Test Autre" },
  ];
  for (const u of users) {
    await ins(
      `insert into Controle_Users (Login_User, Cod_Profile, Nom_User, Mail, Typ_Role, Actif, Pwd_User, Created_By, Dat_Crea)
       values (@login, @profil, @nom, @mail, 'Ops', 'true', @pw, 'TEST', getdate())`,
      [
        { param: "login", sqlType: NVarChar, valeur: u.login },
        { param: "profil", sqlType: Int, valeur: u.profil },
        { param: "nom", sqlType: NVarChar, valeur: u.nom },
        { param: "mail", sqlType: NVarChar, valeur: u.mail },
        { param: "pw", sqlType: NVarChar, valeur: pw },
      ]
    );
  }

  // 4. Fonctions de securite accordees aux profils de test
  const fonctions = [
    { profil: String(codProfiles["MED"]), fonc: "SANTE_CLINIQUE" },
    { profil: String(codProfiles["RH"]), fonc: "SANTE_ADMIN" },
    { profil: String(codProfiles["INF"]), fonc: "SANTE_CLINIQUE" },
    { profil: String(codProfiles["AUD"]), fonc: "SANTE_AUDIT" },
  ];
  for (const f of fonctions) {
    await ins(
      `insert into Controle_Droit_Functions (Cod_Profile, Function_Sec, Visible, Actif)
       values (@profil, @fonc, 'true', 'true')`,
      [
        { param: "profil", sqlType: NVarChar, valeur: f.profil },
        { param: "fonc", sqlType: NVarChar, valeur: f.fonc },
      ]
    );
  }

  // 5. Parametre CNDP de test pour la societe 3068 (leve le verrou d'ecriture)
  await ins(`delete from Param_Sante_Reglement where Cod_Param='CNDP_NUM_AUTORISATION' and id_Societe=@soc`, [
    { param: "soc", sqlType: Int, valeur: SOC },
  ]);
  await ins(
    `insert into Param_Sante_Reglement (Cod_Param, id_Societe, Lib_Param, Valeur, Source_Reglementaire, Dat_Crea, Created_By)
     values ('CNDP_NUM_AUTORISATION', @soc, 'Autorisation CNDP (test)', 'CNDP-TEST-2026', 'VALEUR FICTIVE DE TEST', getdate(), 'TEST')`,
    [{ param: "soc", sqlType: Int, valeur: SOC }]
  );

  console.log("Utilisateurs de test crees. Mot de passe : " + PWD);
  await closePool();
}
main().catch((e) => { console.error("FATAL:", e); process.exit(1); });
