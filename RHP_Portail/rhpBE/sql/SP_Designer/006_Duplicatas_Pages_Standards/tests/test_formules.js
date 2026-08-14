/* Validation des formules declaratives des duplicatas avec le moteur SP_ reel */
const eng = require("D:/Dev/RHP/RHP/RHP_Portail/rhpBE/dist/modules/module_sp_engine.js");

const ctxConge = {
  entete: {
    Matricule: "D0002", Typ_Conge: "CAD",
    Dat_Deb_Conge: "2026-08-03T00:00:00", Dat_Fin_Conge: "2026-08-14T00:00:00",
    Dat_Deb_am_pm: "am", Dat_Fin_am_pm: "pm",
    Duree_Conge: 9, Mnt_Engage: 100, Mnt_Remboursement: 25, Lien: "L",
  },
  details: { LIGNES: [
    { Typ_Frais: "HEB", Base: 2, Tx: 10.5, Mnt: 0, RowId: 0 },
    { Typ_Frais: "Taxi", Base: 1, Tx: 50, Mnt: 0, RowId: 0 },
  ] },
};

const fDureeGlobale = {"op":"SUB","args":[{"op":"ADD","args":[{"op":"DATEDIFF","unite":"J","args":[{"ref":"Dat_Fin_Conge"},{"ref":"Dat_Deb_Conge"}]},{"const":1}]},{"op":"ADD","args":[{"op":"COND","args":[{"op":"EQ","args":[{"ref":"Dat_Deb_am_pm"},{"const":"pm"}]},{"const":0.5},{"const":0}]},{"op":"COND","args":[{"op":"EQ","args":[{"ref":"Dat_Fin_am_pm"},{"const":"am"}]},{"const":0.5},{"const":0}]}]}]};
const fMnt = {"op":"ROUND","args":[{"op":"MUL","args":[{"ref":"Base"},{"ref":"Tx"}]},{"const":2}]};
const fTotal = {"op":"SUM","table":"LIGNES","colonne":"Mnt"};
const fTaux = {"op":"DIVSAFE","args":[{"ref":"Mnt_Remboursement"},{"ref":"Mnt_Engage"}]};
const rVisibleMalade = {"op":"EQ","args":[{"ref":"Lien"},{"const":"L"}]};

let ko = 0;
function check(nom, attendu, obtenu) {
  const ok = obtenu === attendu;
  if (!ok) ko++;
  console.log(`${ok ? "OK " : "KO "} ${nom} : attendu=${attendu} obtenu=${obtenu}`);
}

// 1. Duree_Globale conge : 03/08 -> 14/08 (pm fin) = 12
check("Duree_Globale 03/08->14/08 am/pm", 12, eng.evaluer(fDureeGlobale, ctxConge));
// 1b. Demi-journees : deb pm + fin am = 12 - 1 = 11
const ctx2 = { ...ctxConge, entete: { ...ctxConge.entete, Dat_Deb_am_pm: "pm", Dat_Fin_am_pm: "am" } };
check("Duree_Globale deb pm + fin am", 11, eng.evaluer(fDureeGlobale, ctx2));
// 2. Mnt ligne : 2 x 10.5 = 21
check("Mnt ligne (2 x 10.5)", 21, eng.evaluer(fMnt, ctxConge, ctxConge.details.LIGNES[0]));
// 3. Total : lignes non calculees ici (Mnt=0) => 0 ; avec Mnt => somme
check("Total (Mnt=0)", 0, eng.evaluer(fTotal, ctxConge));
const ctx3 = { entete: {}, details: { LIGNES: [{ Mnt: 21 }, { Mnt: 50 }] } };
check("Total (21+50)", 71, eng.evaluer(fTotal, ctx3));
// 4. Taux remboursement : 25/100 = 0.25
check("Taux_Remboursement", 0.25, eng.evaluer(fTaux, ctxConge));
// 5. Regle visibilite Nom_Malade : Lien='L' => true ; 'A' => false
check("Visible si Lien=L", true, eng.evaluer(rVisibleMalade, ctxConge));
check("Invisible si Lien=A", false, eng.evaluer(rVisibleMalade, { entete: { Lien: "A" }, details: {} }));
// 6. EXPR ordre dates : LT(deb, fin) => true ; inverse => false
const fOrdre = {"op":"LT","args":[{"ref":"Dat_Deb_Conge"},{"ref":"Dat_Fin_Conge"}]};
check("Ordre dates ok", true, eng.evaluer(fOrdre, ctxConge));
check("Ordre dates ko", false, eng.evaluer(fOrdre, { entete: { Dat_Deb_Conge: "2026-08-14", Dat_Fin_Conge: "2026-08-03" }, details: {} }));
// 7. EXPR total nul (warning NF)
const fTotalNul = {"op":"NE","args":[{"ref":"Mnt_NF"},{"const":0}]};
check("Total nul -> avertissement", false, eng.evaluer(fTotalNul, { entete: { Mnt_NF: 0 }, details: {} }));
check("Total non nul -> pas d'avertissement", true, eng.evaluer(fTotalNul, { entete: { Mnt_NF: 71 }, details: {} }));
// 8. ValiderExpression sur toutes les formules (gabarit de publication)
for (const [nom, f] of [["Duree_Globale", fDureeGlobale], ["Mnt", fMnt], ["Total", fTotal], ["Taux", fTaux], ["Ordre", fOrdre]]) {
  const v = eng.validerExpression(typeof f === "string" ? JSON.parse(f) : f);
  check("validerExpression " + nom, true, v.ok);
}
// 9. graphe de dependances : pas de cycle entre les calcules des duplicatas
const meta = { champs: [
  { Cod_Champ: "Duree_Globale", Cod_Table: "ENT", Nom_Colonne: "Duree_Globale", Typ_Controle: "CALCULE", Formule: JSON.stringify(fDureeGlobale) },
  { Cod_Champ: "Mnt_NF", Cod_Table: "ENT", Nom_Colonne: "Mnt_NF", Typ_Controle: "CALCULE", Formule: JSON.stringify(fTotal) },
  { Cod_Champ: "L_Mnt", Cod_Table: "LIGNES", Nom_Colonne: "Mnt", Typ_Controle: "CALCULE", Formule: JSON.stringify(fMnt) },
  { Cod_Champ: "Pied", Cod_Table: "LIGNES", Nom_Colonne: "", Typ_Controle: "CALCULE", Formule: JSON.stringify(fTotal) },
] };
const g = eng.construireGraphe(meta);
check("Pas de cycle", null, g.cycle);
// 10. recalcul complet : Mnt ligne calcule puis total
const ctx4 = { entete: {}, details: { LIGNES: [{ Base: 2, Tx: 10.5, Mnt: 0 }, { Base: 1, Tx: 50, Mnt: 0 }] } };
eng.recalculer(meta, ctx4);
check("Recalc Mnt ligne 1", 21, ctx4.details.LIGNES[0].Mnt);
check("Recalc total entete", 71, ctx4.entete.Mnt_NF);

console.log(ko === 0 ? "\nTOUS LES CONTROLES PASSENT" : `\n${ko} CONTROLE(S) EN ECHEC`);
process.exit(ko === 0 ? 0 : 1);
