/* ============================================================================
   Test e2e v2 - duplicatas + evolutions SP4 (P1..P9) via le moteur reel
   ============================================================================ */
process.chdir("D:/Dev/RHP/RHP/RHP_Portail/rhpBE");
const mssql = require("D:/Dev/RHP/RHP/RHP_Portail/rhpBE/node_modules/mssql");
const eng = require("D:/Dev/RHP/RHP/RHP_Portail/rhpBE/dist/modules/module_sp_engine.js");
const init = require("D:/Dev/RHP/RHP/RHP_Portail/rhpBE/dist/modules/module_initialisation.js");
const sqlRW = require("D:/Dev/RHP/RHP/RHP_Portail/rhpBE/dist/modules/module_sqlRW.js");

const AGENT = { Login: "D0002", Matricule: "D0002", id_Societe: "3068", codProfile: "1", TeamLeader: "false" };
let echecs = 0;
function ok(nom, cond, extra) {
  console.log((cond ? "OK   " : "KO   ") + nom + (extra ? "  [" + extra + "]" : ""));
  if (!cond) echecs++;
}
const viaJson = (o) => JSON.parse(JSON.stringify(o));
const P = (p, t, v) => ({ param: p, sqlType: t, valeur: v });

async function main() {
  await init.initialisationSeveur();

  /* ---- P9 : garde-fou sources (littéral avec ';' accepté) ---------------- */
  ok("garde-fou: littéral ';' accepté", eng.estRequeteLectureSeule("select replace('1.1.1.1.1.1.0', '.', char(59))").ok === true);
  ok("garde-fou: '1;1;0' en littéral accepté", eng.estRequeteLectureSeule("select * from t where x = '1;1;0'").ok === true);
  ok("garde-fou: 2 instructions refusées", eng.estRequeteLectureSeule("select 1; select 2").ok === false);
  ok("garde-fou: delete refusé", eng.estRequeteLectureSeule("delete from t").ok === false);

  /* ---- Nouvelles sources ------------------------------------------------- */
  const rPropOk = await eng.executerSource("sp_check_proprietaire", { Doc_Matricule: "D0002" }, AGENT);
  ok("source sp_check_proprietaire (même agent)", rPropOk.ok && rPropOk.valeur === 1, "valeur=" + rPropOk.valeur);
  const rPropKo = await eng.executerSource("sp_check_proprietaire", { Doc_Matricule: "D9999" }, AGENT);
  ok("source sp_check_proprietaire (autre agent)", rPropKo.ok && rPropKo.valeur === 0, "valeur=" + rPropKo.valeur);
  const rDetail = await eng.executerSource("sp_cng_detail",
    { Matricule: "D0002", Deb: "2026-09-07T00:00:00", Fin: "2026-10-05T00:00:00", DebPm: "am", FinPm: "pm" }, AGENT);
  ok("source sp_cng_detail (TABLE)", rDetail.ok && rDetail.typRetour === "TABLE" && rDetail.data.length >= 2,
     "periodes=" + (rDetail.data ? rDetail.data.length : "?"));
  if (rDetail.data && rDetail.data.length >= 2) {
    const l1 = rDetail.data[0];
    const tot = rDetail.data.reduce((t, l) => t + (l.Duree_Conge || 0), 0);
    console.log("      p1: " + JSON.stringify(l1));
    console.log("      total Duree_Conge lignes = " + tot);
  }

  /* ---- DUP_CONGE : cycle complet ------------------------------------------ */
  console.log("\n===== DUP_CONGE (P1/P2/P4/P7) =====");
  const meta = await eng.chargerMetaPage("DUP_CONGE");
  ok("meta SP4", !!meta && meta.page.Figer_Statuts === "SS,SG,RJ,SP,VA");
  const tPer = meta.tables.find((t) => t.Cod_Table === "PERIODES");
  ok("détail virtuel PERIODES déclaré", !!tPer && tPer.Source_Metier === "sp_cng_detail");

  // création doc A (07/09 -> 11/09/2026)
  const entA = { Matricule: "D0002", Typ_Conge: "CAD", Dat_Deb_Conge: "2026-09-07T00:00:00", Dat_Fin_Conge: "2026-09-11T00:00:00",
    Dat_Deb_am_pm: "am", Dat_Fin_am_pm: "pm", Commentaire: "Doc A" };
  const rA = await eng.enregistrerDocument(meta, viaJson(entA), {}, null, AGENT);
  ok("création A", rA.result === true, rA.message || rA.numDoc);
  const numA = rA.numDoc;

  // relecture : grille virtuelle alimentée
  const rLire = await eng.lireDocument(meta, numA, AGENT);
  const nbPer = rLire.details?.PERIODES?.length ?? -1;
  ok("grille virtuelle alimentée à la lecture", rLire.result && nbPer === 1, "périodes=" + nbPer);
  if (nbPer === 1) {
    const p = rLire.details.PERIODES[0];
    ok("période: durées cohérentes", p.Duree_Globale === 5 && p.Repos_Hebdomadaire === 0 && p.Duree_Conge === 5,
       `glob=${p.Duree_Globale} repos=${p.Repos_Hebdomadaire} fer=${p.Jours_Feries} conge=${p.Duree_Conge}`);
  }

  // P1 : exclusion du document courant -> la modification de A (dates inchangées) passe
  const luA = viaJson(await eng.lireDocument(meta, numA, AGENT));
  const rModifA = await eng.enregistrerDocument(meta, Object.assign({}, luA.entete, { Commentaire: "Doc A modifié" }), luA.details, null, AGENT);
  ok("modification A (auto-exclusion chevauchement)", rModifA.result === true, rModifA.message || "");

  // chevauchement : création B chevauchant A -> bloqué
  const entB = Object.assign({}, entA, { Dat_Deb_Conge: "2026-09-10T00:00:00", Dat_Fin_Conge: "2026-09-15T00:00:00", Commentaire: "Doc B (chevauche)" });
  const rB = await eng.enregistrerDocument(meta, viaJson(entB), {}, null, AGENT);
  ok("chevauchement bloqué à la création B", rB.result === false && /chevauchement/i.test(rB.message || ""), rB.message || rB.numDoc);

  // création C sans chevauchement -> passe
  const entC = Object.assign({}, entA, { Dat_Deb_Conge: "2026-09-21T00:00:00", Dat_Fin_Conge: "2026-09-25T00:00:00", Commentaire: "Doc C (libre)" });
  const rC = await eng.enregistrerDocument(meta, viaJson(entC), {}, null, AGENT);
  ok("création C (sans chevauchement)", rC.result === true, rC.message || rC.numDoc);

  // propriétaire : sauvegarde pour un autre matricule -> bloqué
  const rAutre = await eng.enregistrerDocument(meta, viaJson(Object.assign({}, entC, { Matricule: "D0011", Commentaire: "tentative autre" })), {}, null, AGENT);
  ok("propriétaire bloqué (autre matricule)", rAutre.result === false && /autre matricule/i.test(rAutre.message || ""), rAutre.message || "");

  // P4 : soumission de A puis tentative de modification -> bloquée (SS fige)
  const luA2 = viaJson(await eng.lireDocument(meta, numA, AGENT));
  const rSS = await eng.enregistrerDocument(meta, Object.assign({}, luA2.entete, { Num_Doc: numA }), luA2.details, "SS", AGENT);
  ok("soumission SS de A", rSS.result === true, rSS.message || "");
  const luA3 = viaJson(await eng.lireDocument(meta, numA, AGENT));
  const rModifApresSS = await eng.enregistrerDocument(meta, Object.assign({}, luA3.entete, { Commentaire: "modif interdite" }), luA3.details, null, AGENT);
  ok("modification bloquée après SS (Figer_Statuts)", rModifApresSS.result === false && /traité/i.test(rModifApresSS.message || ""), rModifApresSS.message || "");

  // nettoyage A et C (désoumission + delete)
  for (const num of [numA, rC.numDoc]) {
    await sqlRW.lireSql("update SP_XCG_Ent set Statut='' where Num_Doc=@v and id_Societe=@s", [P("v", mssql.NVarChar, num), P("s", mssql.Int, 3068)]);
    await sqlRW.lireSql("delete from Signatures_Lig where Typ_Document='XCG' and Valeur_Index=@v and id_Societe=@s", [P("v", mssql.NVarChar, num), P("s", mssql.Int, 3068)]);
    await sqlRW.lireSql("delete from Signatures_Ent where Typ_Document='XCG' and Valeur_Index=@v and id_Societe=@s", [P("v", mssql.NVarChar, num), P("s", mssql.Int, 3068)]);
    const rd = await eng.supprimerDocument(meta, num, AGENT);
    ok("nettoyage " + num, rd.result === true, rd.message || "");
  }

  /* ---- P6 : requête de liste (miroir du contrôleur) ----------------------- */
  console.log("\n===== P6 : liste =====");
  const rListe = await sqlRW.lireSql(
    `select t.[Num_Doc] as [N°], dbo.FindRubrique('Statut_Signature', isnull(t.[Statut],'')) as [Statut],
            t.[Matricule] as [Matricule], isnull(ag.Nom,'') as [Nom], t.[Dat_Deb_Conge] as [Du]
     from [SP_XCG_Ent] t outer apply (select Nom_Agent + ' ' + Prenom_Agent as Nom from dbo.RH_Agent a
            where a.id_Societe = t.id_Societe and a.Matricule = t.Matricule) ag
     where t.[id_Societe]=@p_idSoc and convert(date, t.[Dat_Deb_Conge]) >= @p_du and convert(date, t.[Dat_Deb_Conge]) <= @p_au
       and isnull(t.[Statut],'') like @p_st + '%'
     order by t.[Dat_Crea] desc offset 0 rows fetch next 50 rows only`,
    [P("p_idSoc", mssql.Int, 3068), P("p_du", mssql.Date, new Date("2026-01-01")), P("p_au", mssql.Date, new Date("2026-12-31")), P("p_st", mssql.NVarChar, "")]);
  ok("liste (plage dates + statut + nom agent)", rListe.result === true, "lignes=" + (rListe.data ? rListe.data.length : "?"));

  /* ---- NF : champ Statut lié à la colonne technique (P3) ------------------ */
  const metaNF = await eng.chargerMetaPage("DUP_NOTE_FRAIS");
  const champStatut = metaNF.champs.find((c) => c.Cod_Champ === "Statut");
  ok("champ Statut déclaré (sans colonne métier)", !!champStatut && champStatut.Nom_Colonne === "Statut"
     && !metaNF.colonnes.some((c) => c.Nom_Colonne === "Statut"));

  /* ---- AT : droits consultation ------------------------------------------- */
  ok("AT: impression activée (générique)", (await eng.chargerMetaPage("DUP_DECLARATION_AT")).page.Act_Imprimer === "true");

  console.log("\n" + (echecs === 0 ? "=== TOUS LES TESTS V2 PASSENT ===" : "=== " + echecs + " ECHEC(S) ==="));
  await sqlRW.closePool();
  process.exit(echecs === 0 ? 0 : 1);
}
main().catch(async (e) => { console.error("FATAL", e); await sqlRW.closePool(); process.exit(1); });
