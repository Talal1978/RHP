/* Diagnostic audit : dernieres lignes du journal */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

(async () => {
  await initialisationSeveur();
  const r = await lireSql(
    `select TOP 15 RowId, Dat_Action, Login_User, Cod_Profile, Action, Objet, Valeur_Index, Succes, Motif
     from RH_Sante_Audit_Acces order by RowId desc`
  );
  r.data.forEach((x: any) => console.log(JSON.stringify(x)));
  const c = await lireSql(
    `select Action, count(*) as nb from RH_Sante_Audit_Acces group by Action`
  );
  console.log("Par action:", JSON.stringify(c.data));
  await closePool();
})().catch((e) => { console.error("FATAL:", e.message); process.exit(1); });
