/* Exemples de lignes Param_Mod_Edition existantes */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

(async () => {
  await initialisationSeveur();
  const r = await lireSql("SELECT TOP 5 Cod_Report, Nom_Report, Typ_Edition, Module, Typ_Pie, parSociete, Portail, Typ_Modele_Edition, withPassword FROM Param_Mod_Edition");
  r.data.forEach((x: any) => console.log(JSON.stringify(x)));
  const c = await lireSql("SELECT TOP 5 * FROM Controle_Def_Ecran_Mod_Edition");
  console.log("--- Controle_Def_Ecran_Mod_Edition ---");
  c.data.forEach((x: any) => console.log(JSON.stringify(x)));
  await closePool();
})().catch((e) => { console.error("FATAL:", e.message); process.exit(1); });
