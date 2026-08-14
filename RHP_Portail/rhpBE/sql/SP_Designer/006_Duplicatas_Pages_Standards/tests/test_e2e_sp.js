/* Test de bout en bout des 6 pages duplicatas via le VRAI moteur SP_ serveur */
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

async function testPage(codPage, enteteNew, detailsNew, enteteModif) {
  console.log("");
  console.log("===== " + codPage + " =====");
  // Miroir de la couche HTTP/JSON du portail : les Date partent en chaines ISO
  const viaJson = function (o) { return JSON.parse(JSON.stringify(o)); };
  enteteNew = viaJson(enteteNew); detailsNew = viaJson(detailsNew); enteteModif = viaJson(enteteModif);
  const meta = await eng.chargerMetaPage(codPage);
  ok("meta chargee", !!meta && meta.page.Statut_Page === "PUBLIE");
  if (!meta) return;
  ok("droit Creer (profil 1)", await eng.verifierDroit(codPage, "1", "Creer"));
  ok("droit Consulter (profil 2)", await eng.verifierDroit(codPage, "2", "Consulter"));

  const r1 = await eng.enregistrerDocument(meta, enteteNew, detailsNew, null, AGENT);
  ok("creation", r1.result === true, r1.message || r1.numDoc);
  if (!r1.result) return;
  const numDoc = r1.numDoc;
  const table = meta.tables.find(function (t) { return t.Role_Table === "ENT"; }).Nom_Physique;

  const r2 = await eng.lireDocument(meta, numDoc, AGENT);
  ok("relecture", r2.result === true && r2.entete.Num_Doc === numDoc);
  // La couche HTTP renverrait des chaines : on serialise comme le fera le client
  const enteteLu = viaJson(r2.entete);
  const detailsLu = viaJson(r2.details);

  const r3 = await eng.executerValidations(meta, { entete: enteteLu, details: detailsLu }, AGENT);
  ok("validations sans blocage", r3.erreurs.length === 0, r3.erreurs.map(function (e) { return e.message; }).join(" | "));

  const r4 = await eng.enregistrerDocument(meta, Object.assign({}, enteteLu, enteteModif, { Num_Doc: numDoc, RV: enteteLu.RV }), detailsLu, null, AGENT);
  ok("modification", r4.result === true, r4.message || "");

  if (meta.page.Workflow_Actif === "true") {
    // Comme le client : rechargement apres modification (RV fraiche) avant soumission
    const r2b = viaJson(await eng.lireDocument(meta, numDoc, AGENT));
    const r5 = await eng.enregistrerDocument(meta, Object.assign({}, r2b.entete, { Num_Doc: numDoc }), r2b.details, "SS", AGENT);
    ok("soumission SS", r5.result === true, r5.message || "");
    const sig = await sqlRW.lireSql(
      "select count(*) as nb from Signatures_Lig where Typ_Document=@t and Valeur_Index=@v and id_Societe=@s",
      [
        { param: "t", sqlType: mssql.NVarChar, valeur: meta.page.Typ_Document },
        { param: "v", sqlType: mssql.NVarChar, valeur: numDoc },
        { param: "s", sqlType: mssql.Int, valeur: 3068 },
      ]);
    ok("circuit signature alimente", sig.result && sig.data[0].nb > 0, "lignes=" + (sig.data && sig.data[0] ? sig.data[0].nb : "?"));
    const statut = await sqlRW.lireSql(
      "select isnull(Statut,'') as st from " + table + " where Num_Doc=@v and id_Societe=@s",
      [
        { param: "v", sqlType: mssql.NVarChar, valeur: numDoc },
        { param: "s", sqlType: mssql.Int, valeur: 3068 },
      ]);
    ok("statut SS pose", statut.result && statut.data[0].st === "SS", "statut=" + (statut.data && statut.data[0] ? statut.data[0].st : "?"));
  }

  // Nettoyage : desoumettre puis supprimer le document de test
  await sqlRW.lireSql("update " + table + " set Statut='' where Num_Doc=@v and id_Societe=@s", [
    { param: "v", sqlType: mssql.NVarChar, valeur: numDoc },
    { param: "s", sqlType: mssql.Int, valeur: 3068 },
  ]);
  await sqlRW.lireSql("delete from Signatures_Lig where Typ_Document=@t and Valeur_Index=@v and id_Societe=@s", [
    { param: "t", sqlType: mssql.NVarChar, valeur: meta.page.Typ_Document },
    { param: "v", sqlType: mssql.NVarChar, valeur: numDoc },
    { param: "s", sqlType: mssql.Int, valeur: 3068 },
  ]);
  await sqlRW.lireSql("delete from Signatures_Ent where Typ_Document=@t and Valeur_Index=@v and id_Societe=@s", [
    { param: "t", sqlType: mssql.NVarChar, valeur: meta.page.Typ_Document },
    { param: "v", sqlType: mssql.NVarChar, valeur: numDoc },
    { param: "s", sqlType: mssql.Int, valeur: 3068 },
  ]);
  const r6 = await eng.supprimerDocument(meta, numDoc, AGENT);
  ok("suppression (nettoyage)", r6.result === true, r6.message || "");
}

async function main() {
  await init.initialisationSeveur();

  const sources = [
    ["sp_solde_conge_date", { Matricule: "D0002", DatRef: "2026-08-03T00:00:00" }],
    ["sp_cng_repos", { Deb: "2026-08-03T00:00:00", Fin: "2026-08-14T00:00:00", Typ: "CAD" }],
    ["sp_cng_feries", { Deb: "2026-08-03T00:00:00", Fin: "2026-08-14T00:00:00", Typ: "CAD" }],
    ["sp_cng_duree", { Deb: "2026-08-03T00:00:00", Fin: "2026-08-14T00:00:00", DebPm: "am", FinPm: "pm", Typ: "CAD" }],
    ["sp_cng_periode_cloturee", { Deb: "2026-08-03T00:00:00" }],
    ["sp_cng_controle_paie", { Matricule: "D0002", Deb: "2026-08-03T00:00:00" }],
    ["sp_avances_encours", { Matricule: "D0002" }],
    ["sp_prets_encours", { Matricule: "D0002" }],
    ["sp_dernier_salaire_av", { Matricule: "D0002" }],
    ["sp_dernier_salaire_pr", { Matricule: "D0002" }],
  ];
  for (const [src, params] of sources) {
    const r = await eng.executerSource(src, params, AGENT);
    ok("source " + src, r.ok === true, "valeur=" + r.valeur + (r.message ? " err=" + r.message : ""));
  }

  // DUP_CONGE : comme le client, on resout d'abord les sources (repos/feries/duree)
  const cgParams = { Deb: "2026-09-07T00:00:00", Fin: "2026-09-11T00:00:00", DebPm: "am", FinPm: "pm", Typ: "CAD" };
  const cgRepos = (await eng.executerSource("sp_cng_repos", cgParams, AGENT)).valeur;
  const cgFeries = (await eng.executerSource("sp_cng_feries", cgParams, AGENT)).valeur;
  const cgDuree = (await eng.executerSource("sp_cng_duree", cgParams, AGENT)).valeur;
  console.log("   sources conge : repos=" + cgRepos + " feries=" + cgFeries + " duree=" + cgDuree);
  await testPage("DUP_CONGE",
    { Matricule: "D0002", Typ_Conge: "CAD", Dat_Deb_Conge: "2026-09-07T00:00:00", Dat_Fin_Conge: "2026-09-11T00:00:00", Dat_Deb_am_pm: "am", Dat_Fin_am_pm: "pm",
      Duree_Globale: 5, Repos_Hebdomadaire: cgRepos, Jours_Feries: cgFeries, Duree_Conge: cgDuree, Commentaire: "Test duplicata" },
    {},
    { Commentaire: "Test duplicata modifié" });

  await testPage("DUP_NOTE_FRAIS",
    { Matricule: "D0002", Dat_NF: "2026-08-13T00:00:00", Commentaire: "Test duplicata" },
    { LIGNES: [
        { Typ_Frais: "HEB", Base: 2, Tx: 100, Comment: "Hotel", RowId: 0 },
        { Typ_Frais: "Taxi", Base: 1, Tx: 50, Comment: "Aéroport", RowId: 0 }] },
    { Commentaire: "Test duplicata modifié" });

  await testPage("DUP_DOSSIER_MALADIE",
    { Matricule: "D0002", Lien: "L", Nom_Malade: "TEST", Typ_Maladie: "", Dat_Dossier: "2026-08-13T00:00:00", Mnt_Engage: 500 },
    {},
    { Mnt_Engage: 600 });

  await testPage("DUP_AVANCE",
    { Matricule: "D0002", Dat_Demande: "2026-08-13T00:00:00", Montant_Avance: 1000, Commentaire: "Test duplicata" },
    {},
    { Montant_Avance: 1200 });

  await testPage("DUP_PRET",
    { Matricule: "D0002", Dat_Demande: "2026-08-13T00:00:00", Montant_Pret: 5000, Nb_Echeance: 12, Premiere_Echeance: "2026-10-01T00:00:00", Commentaire: "Test duplicata" },
    {},
    { Montant_Pret: 5500 });

  // Page AT : consultation seule
  console.log("");
  console.log("===== DUP_DECLARATION_AT =====");
  const metaAT = await eng.chargerMetaPage("DUP_DECLARATION_AT");
  ok("meta chargee (page consultation)", !!metaAT && metaAT.page.Act_Enregistrer === "false");
  ok("droit Creer refuse (profil 2)", (await eng.verifierDroit("DUP_DECLARATION_AT", "2", "Creer")) === false);
  ok("droit Consulter ok (profil 2)", await eng.verifierDroit("DUP_DECLARATION_AT", "2", "Consulter"));
  await sqlRW.lireSql("if not exists (select 1 from SP_XAT_Ent where Num_Doc='XAT-TEST' and id_Societe=3068) " +
    "insert into SP_XAT_Ent (Num_Doc, id_Societe, Statut, Matricule, Dat_Accident, Heure_Accident, Lieu_Accident, Circonstances, Dat_Crea, Created_By) " +
    "values ('XAT-TEST', 3068, '', 'D0002', '2026-08-01', '10:30', 'Atelier', 'Chute de plain-pied (test).', getdate(), 'TEST')", []);
  await sqlRW.lireSql("if not exists (select 1 from SP_XAT_Det_CERTIFS where Num_Doc='XAT-TEST' and id_Societe=3068) " +
    "insert into SP_XAT_Det_CERTIFS (Num_Doc, id_Societe, Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Comment, Dat_Crea, Created_By) " +
    "values ('XAT-TEST', 3068, 'Initial', '2026-08-01', '2026-08-02', '2026-08-15', 14, 'Certificat initial', getdate(), 'TEST')", []);
  const rAT = await eng.lireDocument(metaAT, "XAT-TEST", AGENT);
  ok("relecture document AT (entete + certificats)", rAT.result === true && rAT.details && rAT.details.CERTIFS && rAT.details.CERTIFS.length === 1,
     "lignes=" + (rAT.details && rAT.details.CERTIFS ? rAT.details.CERTIFS.length : "?"));
  const rDelAT = await eng.supprimerDocument(metaAT, "XAT-TEST", AGENT);
  ok("nettoyage document AT", rDelAT.result === true, rDelAT.message || "");

  console.log("");
  console.log(echecs === 0 ? "=== TOUS LES TESTS PASSENT ===" : "=== " + echecs + " ECHEC(S) ===");
  await sqlRW.closePool();
  process.exit(echecs === 0 ? 0 : 1);
}

main().catch(async function (e) { console.error("FATAL", e); await sqlRW.closePool(); process.exit(1); });
