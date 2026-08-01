/* Execute un script .sql (decoupe sur les lignes GO) via la config rhpBE.
   Usage : npx ts-node --transpile-only sante/run_script.ts <chemin_fichier.sql> */
import * as fs from "fs";
import { getPool, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

async function main() {
  const fichier = process.argv[2];
  if (!fichier || !fs.existsSync(fichier)) {
    console.error("Fichier introuvable : " + fichier);
    process.exit(1);
  }
  await initialisationSeveur();
  const pool = await getPool();

  const contenu = fs.readFileSync(fichier, "utf8");
  const batches = contenu
    .split(/^\s*GO\s*$/gim)
    .map((b) => b.trim())
    .filter((b) => b.length > 0);

  console.log(`Script : ${fichier} - ${batches.length} batch(es)`);
  let ok = 0;
  let ko = 0;
  for (let i = 0; i < batches.length; i++) {
    try {
      await pool.request().query(batches[i]);
      ok++;
    } catch (err: any) {
      ko++;
      console.error(`\n[ERREUR batch ${i + 1}/${batches.length}] ${err.message}`);
      console.error("--- debut du batch en erreur ---");
      console.error(batches[i].substring(0, 600));
      console.error("--- fin extrait ---\n");
    }
  }
  console.log(`\nResultat : ${ok} batch(es) OK, ${ko} en erreur.`);
  await closePool();
  process.exit(ko > 0 ? 2 : 0);
}

main().catch((e) => { console.error("FATAL:", e); process.exit(1); });
