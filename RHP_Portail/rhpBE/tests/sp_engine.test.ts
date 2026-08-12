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
  valeurPour, TSpMeta, TSpContexte,
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
        Largeur_Colonne: null, Total_Grille: "", estCritere: "false", Rang_Critere: null },
      { Cod_Page: "TEST", Cod_Champ: "Total", Cod_Table: "ENT", Nom_Colonne: "Total", Libelle: "Total",
        Typ_Controle: "CALCULE", Rang: 2, Ligne: null, Colonne: null, Largeur: 3, Valeur_Defaut: null, Aide: null,
        Obligatoire: "false", Etat: "A", Rubrique: null, Num_Zoom: null, Zoom_Retour: null, Source_Metier: null,
        Formule: JSON.stringify({ op: "SUM", table: "LIGNES", colonne: "Mnt" }),
        Persiste: "true", Recalc_Save: "true", Format_Affichage: "MNT", Decimales: 2,
        Regle_Visibilite: null, Regle_Activation: null, Visible_Grille: "true", Rang_Grille: 2,
        Largeur_Colonne: null, Total_Grille: "", estCritere: "false", Rang_Critere: null },
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
test("evaluer : soustraction de dates -> durée en secondes", () => {
  // Cas réel : {"op":"DIVSAFE","args":[{"op":"SUB", dates}, 3600]} -> heures
  const ctx: TSpContexte = {
    entete: { Dat_Deb_Abs: "2026-08-12T07:00:00", Dat_Fin_Abs: "2026-08-12T09:30:00" },
    details: {},
  };
  assert.equal(evaluer({ op: "SUB", args: [{ ref: "Dat_Fin_Abs" }, { ref: "Dat_Deb_Abs" }] }, ctx), 9000);
  assert.equal(
    evaluer({ op: "DIVSAFE", args: [{ op: "SUB", args: [{ ref: "Dat_Fin_Abs" }, { ref: "Dat_Deb_Abs" }] }, 3600] }, ctx), 2.5);
  // Chaînes françaises jj/mm/aaaa hh:mm acceptées
  const ctxFr: TSpContexte = { entete: { A: "12/08/2026 07:00", B: "12/08/2026 08:30" }, details: {} };
  assert.equal(evaluer({ op: "SUB", args: [{ ref: "B" }, { ref: "A" }] }, ctxFr), 5400);
  assert.equal(evaluer({ op: "DATEDIFF", unite: "MI", args: [{ ref: "B" }, { ref: "A" }] }, ctxFr), 90);
  // Objets Date (état du portail / driver SQL)
  const ctxD: TSpContexte = { entete: { A: new Date(2026, 7, 12, 7, 0), B: new Date(2026, 7, 12, 7, 45) }, details: {} };
  assert.equal(evaluer({ op: "SUB", args: [{ ref: "B" }, { ref: "A" }] }, ctxD), 2700);
  // Aucune régression : nombres et numériques restent de l'arithmétique
  assert.equal(evaluer({ op: "SUB", args: [{ const: 10 }, { const: 4 }] }, ctx), 6);
  assert.equal(evaluer({ op: "SUB", args: [{ const: "10" }, { const: "4" }] }, ctx), 6);
  assert.equal(evaluer({ op: "SUB", args: [{ const: "2026" }, { const: "2025" }] }, ctx), 1); // "2026" n'est pas une date
  assert.equal(evaluer({ op: "SUB", args: [{ ref: "Dat_Fin_Abs" }, { const: 5 }] }, ctx), -5); // mixte : la date vaut 0 en numérique
});
test("evaluer : trames mélangées (chaîne chargée de la base + Date saisie au navigateur)", () => {
  // Canon « heure naïve » : la lecture d'horloge fait foi, quel que soit le support de la valeur
  const ctx: TSpContexte = {
    entete: { Deb: "2026-08-12T07:00:00.000Z", Fin: new Date(2026, 7, 12, 9, 30) },
    details: {},
  };
  assert.equal(
    evaluer({ op: "DIVSAFE", args: [{ op: "SUB", args: [{ ref: "Fin" }, { ref: "Deb" }] }, 3600] }, ctx), 2.5);
});
test("valeurPour : les dates sont stockées selon la lecture d'horloge naïve", () => {
  const col: any = { Typ_Sql: "datetime", Nullable: "true" };
  assert.equal((valeurPour(col, "2026-08-12T09:30:00") as Date).toISOString(), "2026-08-12T09:30:00.000Z");
  assert.equal((valeurPour(col, "12/08/2026 09:30") as Date).toISOString(), "2026-08-12T09:30:00.000Z");
  assert.equal((valeurPour(col, "2026-08-12T07:00:00.000Z") as Date).toISOString(), "2026-08-12T07:00:00.000Z");
  assert.equal((valeurPour(col, "2026-08-12") as Date).toISOString(), "2026-08-12T00:00:00.000Z");
  assert.equal(valeurPour(col, "n'importe quoi"), null);
});
test("validerExpression : rejette un opérateur non autorisé", () => {
  assert.equal(validerExpression({ op: "EVAL", args: [{ const: "alert(1)" }] }).ok, false);
  assert.equal(validerExpression({ op: "SUM", table: "LIGNES", colonne: "Mnt" }).ok, true);
  assert.equal(validerExpression({ op: "DATEDIFF", unite: "S", args: [{ ref: "A" }, { ref: "B" }] }).ok, true);
});
test("evaluer : DATEDIFF (durée entre deux dates, unités S/MI/H/J)", () => {
  const ctx: TSpContexte = { entete: { Fin: "2026-02-01T12:00:00Z", Deb: "2026-01-01T12:00:00Z" }, details: {} };
  assert.equal(evaluer({ op: "DATEDIFF", unite: "J", args: [{ ref: "Fin" }, { ref: "Deb" }] }, ctx), 31);
  assert.equal(evaluer({ op: "DATEDIFF", unite: "H", args: [{ ref: "Fin" }, { ref: "Deb" }] }, ctx), 31 * 24);
  assert.equal(evaluer({ op: "DATEDIFF", unite: "S", args: [{ ref: "Fin" }, { ref: "Deb" }] }, ctx), 31 * 86400);
  // Cas d'usage : durée d'une absence en secondes (Dat_Fin_ABS - Dat_Deb_ABS)
  const ctx2: TSpContexte = { entete: { Dat_Fin_ABS: "2026-03-02T08:30:00Z", Dat_Deb_ABS: "2026-03-02T08:00:00Z" }, details: {} };
  assert.equal(evaluer({ op: "DATEDIFF", unite: "S", args: [{ ref: "Dat_Fin_ABS" }, { ref: "Dat_Deb_ABS" }] }, ctx2), 1800);
  assert.equal(evaluer({ op: "DATEDIFF", unite: "MI", args: [{ ref: "Dat_Fin_ABS" }, { ref: "Dat_Deb_ABS" }] }, ctx2), 30);
  // Dates invalides ou absentes -> 0 (jamais d'erreur bloquante)
  assert.equal(evaluer({ op: "DATEDIFF", unite: "J", args: [{ ref: "Inconnu" }, { const: "abc" }] }, ctx2), 0);
});
test("evaluer : variables globales GV_* résolues dans les formules", () => {
  const ctx: TSpContexte = { entete: { A: 5 }, details: {} };
  assert.equal(evaluer({ ref: "GV_YEAR" }, ctx), new Date().getFullYear());
  assert.equal(evaluer({ op: "DATEDIFF", unite: "J", args: [{ ref: "GV_NOW" }, { ref: "GV_DEBYEAR" }] }, ctx) >= 0, true);
  assert.equal(evaluer({ op: "ADD", args: [{ ref: "A" }, { ref: "GV_MONTH" }] }, ctx), 5 + new Date().getMonth() + 1);
  assert.equal(evaluer({ ref: "GV_INCONNUE" }, ctx), null); // inconnue -> null (0 en numérique)
});
test("evaluer : fonctions texte (positions 1-based, convention tableur)", () => {
  const ctx: TSpContexte = { entete: { Nom: "  Dupont  ", Code: "AB1234", Vide: "" }, details: {} };
  assert.equal(evaluer({ op: "LEFT", args: [{ ref: "Code" }, { const: 2 }] }, ctx), "AB");
  assert.equal(evaluer({ op: "LEFT", args: [{ ref: "Code" }, { const: 99 }] }, ctx), "AB1234"); // clamp, jamais d'erreur
  assert.equal(evaluer({ op: "RIGHT", args: [{ ref: "Code" }, { const: 4 }] }, ctx), "1234");
  assert.equal(evaluer({ op: "RIGHT", args: [{ ref: "Code" }, { const: 0 }] }, ctx), "");
  assert.equal(evaluer({ op: "SUBSTRING", args: [{ ref: "Code" }, { const: 3 }, { const: 2 }] }, ctx), "12");
  assert.equal(evaluer({ op: "SUBSTRING", args: [{ ref: "Code" }, { const: 3 }] }, ctx), "1234");
  assert.equal(evaluer({ op: "SUBSTRING", args: [{ ref: "Code" }, { const: 9 }] }, ctx), "");
  assert.equal(evaluer({ op: "INDEXOF", args: [{ const: "12" }, { ref: "Code" }] }, ctx), 3);
  assert.equal(evaluer({ op: "INDEXOF", args: [{ const: "ZZ" }, { ref: "Code" }] }, ctx), 0); // absent -> 0
  assert.equal(evaluer({ op: "LEN", args: [{ ref: "Code" }] }, ctx), 6);
  assert.equal(evaluer({ op: "UPPER", args: [{ const: "abc" }] }, ctx), "ABC");
  assert.equal(evaluer({ op: "LOWER", args: [{ const: "AbC" }] }, ctx), "abc");
  assert.equal(evaluer({ op: "TRIM", args: [{ ref: "Nom" }] }, ctx), "Dupont");
  assert.equal(evaluer({ op: "REPLACE", args: [{ const: "a-b-c" }, { const: "-" }, { const: "/" }] }, ctx), "a/b/c");
  assert.equal(evaluer({ op: "CONCAT", args: [{ op: "LEFT", args: [{ ref: "Code" }, { const: 2 }] }, { const: "-" }, { const: 2026 }] }, ctx), "AB-2026");
  assert.equal(evaluer({ op: "CONCAT", args: [{ ref: "Vide" }, { const: "x" }] }, ctx), "x");
  // Canon « heure naïve » : une date devient sa lecture d'horloge littérale
  assert.equal(evaluer({ op: "LEFT", args: [{ const: "2026-08-12T07:30:00" }, { const: 10 }] }, ctx), "2026-08-12");
  const ctxD: TSpContexte = { entete: { D3: new Date(2026, 7, 12, 9, 30, 5) }, details: {} };
  assert.equal(evaluer({ op: "CONCAT", args: [{ ref: "D3" }] }, ctxD), "2026-08-12 09:30:05");
});
test("evaluer : fonctions nombres (INT, CEIL, FLOOR, MIN/MAX scalaires)", () => {
  const ctx: TSpContexte = { entete: { A: 2.5, B: -2.5 }, details: {} };
  assert.equal(evaluer({ op: "INT", args: [{ ref: "A" }] }, ctx), 2);
  assert.equal(evaluer({ op: "INT", args: [{ ref: "B" }] }, ctx), -3); // ENT tableur : vers -∞
  assert.equal(evaluer({ op: "CEIL", args: [{ ref: "A" }] }, ctx), 3);
  assert.equal(evaluer({ op: "CEIL", args: [{ ref: "B" }] }, ctx), -2);
  assert.equal(evaluer({ op: "FLOOR", args: [{ ref: "A" }] }, ctx), 2);
  assert.equal(evaluer({ op: "MIN", args: [{ const: 5 }, { const: 2 }, { const: 8 }] }, ctx), 2);
  assert.equal(evaluer({ op: "MAX", args: [{ const: 5 }, { const: 2 }, { const: 8 }] }, ctx), 8);
  assert.equal(evaluer({ op: "MIN", args: [{ ref: "A" }, { ref: "B" }] }, ctx), -2.5);
  // Aucune régression : la forme agrégat (table + colonne) est inchangée
  const ctx2: TSpContexte = { entete: {}, details: { LIGNES: [{ Mnt: 10 }, { Mnt: 20 }] } };
  assert.equal(evaluer({ op: "MIN", table: "LIGNES", colonne: "Mnt" }, ctx2), 10);
  assert.equal(evaluer({ op: "MAX", table: "LIGNES", colonne: "Mnt" }, ctx2), 20);
});
test("evaluer : fonctions dates (DATEADD, DATEPART, DAYOFWEEK)", () => {
  const ctx: TSpContexte = { entete: { D: "2026-08-12T07:30:15Z", D2: "2026-01-31" }, details: {} };
  // DATEADD : ajout dans le canon « heure naïve » (composants de la lecture littérale)
  assert.equal((evaluer({ op: "DATEADD", unite: "J", args: [{ ref: "D" }, { const: 30 }] }, ctx) as Date).toISOString(), "2026-09-11T07:30:15.000Z");
  assert.equal((evaluer({ op: "DATEADD", unite: "H", args: [{ ref: "D" }, { const: 2 }] }, ctx) as Date).toISOString(), "2026-08-12T09:30:15.000Z");
  assert.equal((evaluer({ op: "DATEADD", unite: "MI", args: [{ ref: "D" }, { const: -30 }] }, ctx) as Date).toISOString(), "2026-08-12T07:00:15.000Z");
  assert.equal((evaluer({ op: "DATEADD", unite: "MO", args: [{ ref: "D2" }, { const: 1 }] }, ctx) as Date).toISOString(), "2026-02-28T00:00:00.000Z"); // clamp fin de mois
  assert.equal((evaluer({ op: "DATEADD", unite: "A", args: [{ ref: "D" }, { const: 1 }] }, ctx) as Date).toISOString(), "2027-08-12T07:30:15.000Z");
  assert.equal(evaluer({ op: "DATEADD", unite: "J", args: [{ const: "abc" }, { const: 1 }] }, ctx), null); // date invalide -> null
  // DATEPART : extraction d'une partie en nombre
  assert.equal(evaluer({ op: "DATEPART", partie: "A", args: [{ ref: "D" }] }, ctx), 2026);
  assert.equal(evaluer({ op: "DATEPART", partie: "M", args: [{ ref: "D" }] }, ctx), 8);
  assert.equal(evaluer({ op: "DATEPART", partie: "J", args: [{ ref: "D" }] }, ctx), 12);
  assert.equal(evaluer({ op: "DATEPART", partie: "H", args: [{ ref: "D" }] }, ctx), 7);
  assert.equal(evaluer({ op: "DATEPART", partie: "MI", args: [{ ref: "D" }] }, ctx), 30);
  assert.equal(evaluer({ op: "DATEPART", partie: "S", args: [{ ref: "D" }] }, ctx), 15);
  assert.equal(evaluer({ op: "DATEPART", partie: "A", args: [{ const: "abc" }] }, ctx), 0);
  // DAYOFWEEK : 1 = lundi … 7 = dimanche (12/08/2026 = mercredi -> 3 ; 16/08/2026 = dimanche -> 7)
  assert.equal(evaluer({ op: "DAYOFWEEK", args: [{ ref: "D" }] }, ctx), 3);
  assert.equal(evaluer({ op: "DAYOFWEEK", args: [{ const: "16/08/2026" }] }, ctx), 7);
});
test("validerExpression : les nouveaux opérateurs sont whitelistés", () => {
  assert.equal(validerExpression({ op: "CONCAT", args: [{ ref: "A" }, { const: "x" }] }).ok, true);
  assert.equal(validerExpression({ op: "DATEADD", unite: "MO", args: [{ ref: "D" }, { const: 1 }] }).ok, true);
  assert.equal(validerExpression({ op: "DATEPART", partie: "A", args: [{ ref: "D" }] }).ok, true);
  assert.equal(validerExpression({ op: "MIN", args: [{ const: 1 }, { const: 2 }] }).ok, true); // forme scalaire
  assert.equal(validerExpression({ op: "GAUCHE", args: [{ ref: "A" }] }).ok, false); // nom français refusé côté moteur
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
test("recalculer : champ calculé sans colonne physique (clé = Cod_Champ)", () => {
  const meta = metaBase();
  meta.champs.push(
    { ...meta.champs[1], Cod_Champ: "Duree", Nom_Colonne: "", Persiste: "false",
      Formule: JSON.stringify({ op: "DATEDIFF", unite: "S", args: [{ ref: "Dat_Fin" }, { ref: "Dat_Deb" }] }) },
  );
  const ctx: TSpContexte = {
    entete: { Dat_Deb: "2026-03-02T08:00:00Z", Dat_Fin: "2026-03-02T08:30:00Z" },
    details: { LIGNES: [] },
  };
  const r = recalculer(meta, ctx);
  assert.equal(r.cycle, null);
  assert.equal(ctx.entete.Duree, 1800); // 30 minutes en secondes
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
