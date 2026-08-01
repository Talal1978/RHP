/* Execute la suite de tests SQL du module Sante et affiche le rapport.
   Usage : npx ts-node --transpile-only sante/run_tests.ts */
import * as fs from "fs";
import { getPool, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

async function main() {
  const fichier = process.argv[2] || "D:\\Dev\\RHP\\RHP\\RHP_DeskTop\\RHP\\Sante\\Tests_Sante.sql";
  await initialisationSeveur();
  const pool = await getPool();
  const contenu = fs.readFileSync(fichier, "utf8");

  // Un seul batch (pas de GO dans le fichier de tests)
  const result = await pool.request().query(contenu);
  const recordsets: any[] = (result as any).recordsets || [];
  const tests = recordsets.length >= 2 ? recordsets[recordsets.length - 2] : [];
  const bilan = recordsets.length >= 1 ? recordsets[recordsets.length - 1] : [];

  console.log("=== RAPPORT DES TESTS - MODULE SANTE ===\n");
  let ko = 0;
  for (const t of tests) {
    const mark = t.Resultat === "OK" ? "[OK] " : "[KO] ";
    if (t.Resultat !== "OK") ko++;
    console.log(`${mark}${t.Cod_Test} : ${t.Detail}`);
  }
  console.log("\n" + (bilan[0]?.Bilan || ""));
  await closePool();
  process.exit(ko > 0 ? 2 : 0);
}

main().catch((e) => { console.error("FATAL:", e); process.exit(1); });
