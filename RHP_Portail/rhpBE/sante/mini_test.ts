/* Mini-test isole : appel de la fonction Sys_Sante_Prochaine_Visite */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

async function main() {
  await initialisationSeveur();
  const r1 = await lireSql("SELECT * FROM dbo.Sys_Sante_Prochaine_Visite('FICTIF001', 3068, '2026-01-01')");
  console.log("Appel fonction :", JSON.stringify(r1.data), r1.result ? "" : JSON.stringify(r1.sort).substring(0, 500));
  const r2 = await lireSql("SELECT dbo.Sys_Sante_Param('MODE_ARBITRAGE_PERIODICITE', 3068) as mode");
  console.log("Param mode :", JSON.stringify(r2.data));
  await closePool();
}
main().catch((e) => { console.error("FATAL:", e.message); process.exit(1); });
