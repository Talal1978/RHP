/* Test direct de l'insert dans RH_Sante_Audit_Acces */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";
import { Int, NVarChar } from "mssql";

(async () => {
  await initialisationSeveur();
  const r = await lireSql(
    `insert into RH_Sante_Audit_Acces
      (id_Societe, Login_User, id_User, Cod_Profile, Typ_Role, Action, Objet, Valeur_Index, Matricule_Concerne, Poste, IP, Succes, Motif)
      values (@p_idSoc, @p_Login, @p_idUser, @p_CodProfile, @p_TypRole, @p_Action, @p_Objet, @p_ValeurIndex, @p_Matricule, 'web', @p_IP, @p_Succes, @p_Motif)`,
    [
      { param: "p_idSoc", sqlType: Int, valeur: 3068 },
      { param: "p_Login", sqlType: NVarChar, valeur: "TEST_DIRECT" },
      { param: "p_idUser", sqlType: Int, valeur: -1 },
      { param: "p_CodProfile", sqlType: NVarChar, valeur: "5" },
      { param: "p_TypRole", sqlType: NVarChar, valeur: "Ops" },
      { param: "p_Action", sqlType: NVarChar, valeur: "LECT" },
      { param: "p_Objet", sqlType: NVarChar, valeur: "RH_Sante_Visite" },
      { param: "p_ValeurIndex", sqlType: NVarChar, valeur: "X" },
      { param: "p_Matricule", sqlType: NVarChar, valeur: "" },
      { param: "p_IP", sqlType: NVarChar, valeur: "127.0.0.1" },
      { param: "p_Succes", sqlType: NVarChar, valeur: "1" },
      { param: "p_Motif", sqlType: NVarChar, valeur: "test direct" },
    ]
  );
  console.log("result:", r.result);
  if (!r.result) console.log("erreur:", JSON.stringify(r.sort).substring(0, 800));
  const c = await lireSql("select count(*) as nb from RH_Sante_Audit_Acces where Login_User='TEST_DIRECT'");
  console.log("lignes TEST_DIRECT:", JSON.stringify(c.data));
  await closePool();
})().catch((e) => { console.error("FATAL:", e.message); process.exit(1); });
