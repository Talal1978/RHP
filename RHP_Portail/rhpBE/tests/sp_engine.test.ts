/* ============================================================================
   Tests automatisés du moteur SP_ (runner natif node:test + ts-node)
   Exécution : node --test -r ts-node/register tests/sp_engine.test.ts
   Couvre : identifiants SQL, whitelist des sources, évaluateur déclaratif,
            graphe de dépendances / cycles, validations déclaratives.
   Les fonctions testées sont pures (aucune connexion SQL requise).
   ============================================================================ */
import { test } from "node:test";
import assert from "node:assert/strict";
import {
  validerIdentifiant, validerNomTableMetier, qn, estRequeteLectureSeule,
  evaluer, validerExpression, construireGraphe, recalculer, executerValidations,
  TSpMeta, TSpContexte,
} from "../modules/module_sp_engine";

/* ------------------------- Fixtures ------------------------- */
function metaBase(): TSpMeta {
  return {
    page: {
      Cod_Page: "TEST", Cod_Document: "TST", Libelle: "Test", Libelle_Court: "",
      Nom_Page: "Test", Menu_Parent: "MesDemandes", Rang: 1, Icone: "",
      Statut_Page: "PUBLIE", Table_Ent: "SP_TST_Ent", Typ_Document: "",
      Workflow_Actif: "false", Cod_Modele_Edition: "", GED_Actif: "false",
      GED_Categories: "", GED_Obligatoire: "false", Act_Enregistrer: "true",
      Act_Soumettre: "true", Act_Imprimer: "false", Act_Exporter: "false", Version_Page: 1,
    },
    tables: [
      { Cod_Page: "TEST", Cod_Table: "ENT", Nom_Physique: "SP_TST_Ent", Role_Table: "ENT",
        Libelle: "", Rang: 0, Allow_Add: "false", Allow_Edit: "false", Allow_Delete: "false",
        Allow_Duplicate: "false", Tri_Defaut: "", Regle_Suppression: "CASCADE" },
      { Cod_Page: "TEST", Cod_Table: "LIGNES", Nom_Physique: "SP_TST_Det_LIGNES", Role_Table: "DET",
        Libelle: "Lignes", Rang: 1, Allow_Add: "true", Allow_Edit: "true", Allow_Delete: "true",
        Allow_Duplicate: "false", Tri_Defaut: "", Regle_Suppression: "CASCADE" },
    ],
    colonnes: [
      { Cod_Page: "TEST", Cod_Table: "ENT", Nom_Colonne: "Matricule", Libelle: "Matricule", Typ_Sql: "nvarchar",
        Longueur: 20, Precision_Sql: null, Echelle_Sql: null, Nullable: "false", Valeur_Defaut: null,
        estUnique: "false", estPK: "false", estIndexe: "false", Technique: "false", Rang: 1 },
      { Cod_Page: "TEST", Cod_Table: "ENT", Nom_Colonne: "Total", Libelle: "Total", Typ_Sql: "decimal",
        Longueur: null, Precision_Sql: 18, Echelle_Sql: 2, Nullable: "true", Valeur_Defaut: null,
        estUnique: "false", estPK: "false", estIndexe: "false", Technique: "false", Rang: 2 },
      { Cod_Page: "TEST", Cod_Table: "LIGNES", Nom_Colonne: "Mnt", Libelle: "Montant", Typ_Sql: "decimal",
        Longueur: null, Precision_Sql: 18, Echelle_Sql: 2, Nullable: "true", Valeur_Defaut: null,
        estUnique: "false", estPK: "false", estIndexe: "false", Technique: "false", Rang: 1 },
    ],
    champs: [
      { Cod_Page: "TEST", Cod_Champ: "Matricule", Cod_Table: "ENT", Nom_Colonne: "Matricule", Libelle: "Matricule",
        Typ_Controle: "TEXT", Rang: 1, Ligne: null, Colonne: null, Largeur: 3, Valeur_Defaut: null, Aide: null,
        Obligatoire: "true", Etat: "S", Rubrique: null, Num_Zoom: null, Zoom_Retour: null, Source_Metier: null,
        Formule: null, Persiste: "false", Recalc_Save: "true", Format_Affichage: null, Decimales: null,
        Regle_Visibilite: null, Regle_Activation: null, Visible_Grille: "true", Rang_Grille: 1,
        Largeur_Colonne: null, Total_Grille: "" },
      { Cod_Page: "TEST", Cod_Champ: "Total", Cod_Table: "ENT", Nom_Colonne: "Total", Libelle: "Total",
        Typ_Controle: "CALCULE", Rang: 2, Ligne: null, Colonne: null, Largeur: 3, Valeur_Defaut: null, Aide: null,
        Obligatoire: "false", Etat: "A", Rubrique: null, Num_Zoom: null, Zoom_Retour: null, Source_Metier: null,
        Formule: JSON.stringify({ op: "SUM", table: "LIGNES", colonne: "Mnt" }),
        Persiste: "true", Recalc_Save: "true", Format_Affichage: "MNT", Decimales: 2,
        Regle_Visibilite: null, Regle_Activation: null, Visible_Grille: "true", Rang_Grille: 2,
        Largeur_Colonne: null, Total_Grille: "" },
    ],
    validations: [
      { Cod_Page: "TEST", Cod_Validation: "V_MAT", Portee: "CHAMP", Cod_Table: "ENT", Cod_Champ: "Matricule",
        Typ_Regle: "REQUIRED", Parametres: null, Condition_Regle: null,
        Message: "Matricule obligatoire", Niveau: "B", Rang: 1, Moment: "SAVE", Actif: "true" },
      { Cod_Page: "TEST", Cod_Validation: "V_NBL", Portee: "DETAIL", Cod_Table: "LIGNES", Cod_Champ: null,
        Typ_Regle: "NB_LIGNES", Parametres: JSON.stringify({ min: 1 }), Condition_Regle: null,
        Message: "Au moins une ligne est requise", Niveau: "B", Rang: 2, Moment: "SAVE", Actif: "true" },
      { Cod_Page: "TEST", Cod_Validation: "V_UNIQ", Portee: "DETAIL", Cod_Table: "LIGNES", Cod_Champ: null,
        Typ_Regle: "UNIQUE", Parametres: JSON.stringify({ colonnes: ["Mnt"] }), Condition_Regle: null,
        Message: "Montant en double", Niveau: "W", Rang: 3, Moment: "SAVE", Actif: "true" },
      { Cod_Page: "TEST", Cod_Validation: "V_TOT", Portee: "DOCUMENT", Cod_Table: "ENT", Cod_Champ: null,
        Typ_Regle: "EXPR", Parametres: JSON.stringify({ expr: { op: "GE", args: [{ ref: "Total" }, { const: 0 }] } }),
        Condition_Regle: null, Message: "Total négatif interdit", Niveau: "B", Rang: 4, Moment: "SAVE", Actif: "true" },
    ],
  };
}
const AGENT = { codProfile: "1", id_Societe: "1" };

/* ------------------------- Identifiants SQL ------------------------- */
test("validerIdentifiant : accepte les identifiants sains", () => {
  assert.equal(validerIdentifiant("SP_TST_Ent").ok, true);
  assert.equal(validerIdentifiant("_x9").ok, true);
});
test("validerIdentifiant : rejette injection et mots réservés", () => {
  assert.equal(validerIdentifiant("x; DROP TABLE y").ok, false);
  assert.equal(validerIdentifiant("select").ok, false);
  assert.equal(validerIdentifiant("9abc").ok, false);
  assert.equal(validerIdentifiant("").ok, false);
});
test("validerNomTableMetier : préfixe SP_ obligatoire", () => {
  assert.equal(validerNomTableMetier("SP_X_Ent").ok, true);
  assert.equal(validerNomTableMetier("RH_Agent").ok, false);
});
test("qn : quote les identifiants validés, refuse les autres", () => {
  assert.equal(qn("MaTable"), "[MaTable]");
  assert.throws(() => qn("a]; drop table b"));
});

/* ------------------------- Whitelist des sources ------------------------- */
test("estRequeteLectureSeule : autorise SELECT / WITH / EXEC Sys_", () => {
  assert.equal(estRequeteLectureSeule("select Solde from T where a=@a").ok, true);
  assert.equal(estRequeteLectureSeule("with cte as (select 1 as x) select * from cte").ok, true);
  assert.equal(estRequeteLectureSeule("exec dbo.Sys_MaProc @a").ok, true);
});
test("estRequeteLectureSeule : rejette écriture, multi-instructions, procs étendues", () => {
  assert.equal(estRequeteLectureSeule("delete from T").ok, false);
  assert.equal(estRequeteLectureSeule("select 1; drop table T").ok, false);
  assert.equal(estRequeteLectureSeule("select * from T union select * from U -- ok mais union filtré ailleurs").ok, true);
  assert.equal(estRequeteLectureSeule("exec xp_cmdshell 'dir'").ok, false);
  assert.equal(estRequeteLectureSeule("select 1 update T set x=1").ok, false);
});

/* ------------------------- Évaluateur déclaratif ------------------------- */
test("evaluer : arithmétique et division sécurisée", () => {
  const ctx: TSpContexte = { entete: { A: 10, B: 3, Z: 0 }, details: {} };
  assert.equal(evaluer({ op: "ADD", args: [{ ref: "A" }, { ref: "B" }, { const: 1 }] }, ctx), 14);
  assert.equal(evaluer({ op: "SUB", args: [{ ref: "A" }, { ref: "B" }] }, ctx), 7);
  assert.equal(evaluer({ op: "MUL", args: [{ ref: "A" }, { ref: "B" }] }, ctx), 30);
  assert.equal(evaluer({ op: "DIVSAFE", args: [{ ref: "A" }, { ref: "B" }] }, ctx) > 3.3, true);
  assert.equal(evaluer({ op: "DIVSAFE", args: [{ ref: "A" }, { ref: "Z" }] }, ctx), 0);
});
test("evaluer : agrégats sur lignes de détail", () => {
  const ctx: TSpContexte = {
    entete: {},
    details: { LIGNES: [{ Mnt: 10 }, { Mnt: 20 }, { Mnt: 30 }] },
  };
  assert.equal(evaluer({ op: "SUM", table: "LIGNES", colonne: "Mnt" }, ctx), 60);
  assert.equal(evaluer({ op: "AVG", table: "LIGNES", colonne: "Mnt" }, ctx), 20);
  assert.equal(evaluer({ op: "MIN", table: "LIGNES", colonne: "Mnt" }, ctx), 10);
  assert.equal(evaluer({ op: "MAX", table: "LIGNES", colonne: "Mnt" }, ctx), 30);
  assert.equal(evaluer({ op: "COUNT", table: "LIGNES" }, ctx), 3);
});
test("evaluer : conditions et comparaisons", () => {
  const ctx: TSpContexte = { entete: { Dat_Deb: "2026-01-01", Dat_Fin: "2026-02-01", Typ: "A", Vide: "" }, details: {} };
  assert.equal(evaluer({ op: "IN", args: [{ ref: "Typ" }, ["A", "B", "V"]] }, ctx), true);
  assert.equal(evaluer({ op: "EMPTY", args: [{ ref: "Vide" }] }, ctx), true);
  assert.equal(evaluer({ op: "AND", args: [{ op: "GT", args: [{ ref: "Dat_Fin" }, { ref: "Dat_Deb" }] }, { op: "NOTEMPTY", args: [{ ref: "Typ" }] }] }, ctx), true);
  assert.equal(evaluer({ op: "LT", args: [{ ref: "Dat_Fin" }, { ref: "Dat_Deb" }] }, ctx), false);
  assert.equal(evaluer({ op: "COND", args: [{ op: "EQ", args: [{ ref: "Typ" }, { const: "A" }] }, { const: 1 }, { const: 2 }] }, ctx), 1);
});
test("validerExpression : rejette un opérateur non autorisé", () => {
  assert.equal(validerExpression({ op: "EVAL", args: [{ const: "alert(1)" }] }).ok, false);
  assert.equal(validerExpression({ op: "SUM", table: "LIGNES", colonne: "Mnt" }).ok, true);
});

/* ------------------------- Graphe de dépendances / recalcul ------------------------- */
test("recalculer : total = somme des lignes (recalcul serveur avant enregistrement)", () => {
  const meta = metaBase();
  const ctx: TSpContexte = { entete: {}, details: { LIGNES: [{ Mnt: 5 }, { Mnt: 7 }] } };
  const r = recalculer(meta, ctx);
  assert.equal(r.cycle, null);
  assert.equal(ctx.entete.Total, 12);
  // Ajout d'une ligne -> nouveau total
  ctx.details = { LIGNES: [{ Mnt: 5 }, { Mnt: 7 }, { Mnt: 8 }] };
  recalculer(meta, ctx);
  assert.equal(ctx.entete.Total, 20);
});
test("construireGraphe : détection de référence circulaire", () => {
  const meta = metaBase();
  meta.champs.push(
    { ...meta.champs[1], Cod_Champ: "X", Nom_Colonne: "X", Formule: JSON.stringify({ op: "ADD", args: [{ ref: "Y" }, { const: 1 }] }) },
    { ...meta.champs[1], Cod_Champ: "Y", Nom_Colonne: "Y", Formule: JSON.stringify({ op: "ADD", args: [{ ref: "X" }, { const: 1 }] }) },
  );
  const g = construireGraphe(meta);
  assert.ok(g.cycle !== null && g.cycle.includes("X"));
});

/* ------------------------- Validations déclaratives ------------------------- */
test("executerValidations : REQUIRED bloquant, NB_LIGNES, EXPR document", async () => {
  const meta = metaBase();
  const ko = await executerValidations(meta, { entete: { Matricule: "", Total: 5 }, details: { LIGNES: [] } }, AGENT);
  assert.equal(ko.erreurs.length, 2); // Matricule requis + au moins une ligne
  const ok = await executerValidations(meta, { entete: { Matricule: "M001", Total: 12 }, details: { LIGNES: [{ Mnt: 5 }, { Mnt: 7 }] } }, AGENT);
  assert.equal(ok.erreurs.length, 0);
});
test("executerValidations : UNIQUE en avertissement sur combinaison de colonnes", async () => {
  const meta = metaBase();
  const r = await executerValidations(meta, {
    entete: { Matricule: "M001", Total: 20 },
    details: { LIGNES: [{ Mnt: 5 }, { Mnt: 5 }] },
  }, AGENT);
  assert.equal(r.erreurs.length, 0);
  assert.equal(r.avertissements.length, 1); // doublon Mnt=5
  assert.equal(r.avertissements[0].niveau, "W");
});
