/* NR02 - Verification paie : Sys_GetCongePris (fonction consommee par le moteur
   de paie) doit compter les jours d'arret AT generes (type CAT) comme toute
   absence enregistree dans RH_Conge_Suivi. Le traitement (paye/non paye) est
   ensuite determine par le plan de paie de l'organisation (hors perimetre). */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

(async () => {
  await initialisationSeveur();
  console.log("=== NR02 - Verification Sys_GetCongePris sur l'arret AT genere ===\n");

  // L'absence generee par T13 (AT-TEST001, FICTIF002, 20/02/2027 -> 10/03/2027, 19 jours)
  const abs = await lireSql(
    `select Num_Conge, Typ_Conge, Statut, Duree_Conge, Commentaire
     from RH_Conge_Suivi where Matricule='FICTIF002' and id_Societe=3068 and Typ_Conge='CAT'`
  );
  console.log("Absences CAT FICTIF002 :", JSON.stringify(abs.data));

  // Sys_GetCongePris consolide par plan de paie et periode (meme logique que PayRollEngine)
  const fev = await lireSql(
    `select Matricule, Duree_Conge from dbo.Sys_GetCongePris('PLP', '2027-02-01', '2027-02-28', 3068) where Matricule='FICTIF002'`
  );
  console.log("Sys_GetCongePris fevrier 2027 :", JSON.stringify(fev.data), "(attendu 9 jours)");

  const mar = await lireSql(
    `select Matricule, Duree_Conge from dbo.Sys_GetCongePris('PLP', '2027-03-01', '2027-03-31', 3068) where Matricule='FICTIF002'`
  );
  console.log("Sys_GetCongePris mars 2027 :", JSON.stringify(mar.data), "(attendu 10 jours)");

  // Le solde de conge annuel (CAD) ne doit PAS etre impacte (Sys_Conge_MajConso = CAD seul)
  const solde = await lireSql(
    `select Annee, Conge_Pris, Solde_Conge from RH_Conge where Matricule='FICTIF002' and id_Societe=3068 and Annee=2027`
  );
  console.log("Solde conge CAD 2027 :", JSON.stringify(solde.data), "(Conge_Pris doit rester 0)");

  const ok =
    abs.data.length > 0 &&
    Number(fev.data?.[0]?.Duree_Conge || 0) === 9 &&
    Number(mar.data?.[0]?.Duree_Conge || 0) === 10 &&
    Number(solde.data?.[0]?.Conge_Pris || 0) === 0;

  console.log("\nNR02 : " + (ok ? "OK - l'arret AT est visible de la paie, le solde de conge n'est pas impacte" : "ECART A ANALYSER"));
  await closePool();
  process.exit(ok ? 0 : 2);
})().catch((e) => { console.error("FATAL:", e.message); process.exit(1); });
