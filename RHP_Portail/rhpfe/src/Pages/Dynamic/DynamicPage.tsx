/* ============================================================================
   Module SP_ - Moteur de rendu dynamique d'un document métier
   ----------------------------------------------------------------------------
   Généralise le cycle de vie des documents standards (Note_Frais,
   RH_Demande_Conge) : aucun code spécifique à une page, tout est interprété
   depuis les métadonnées publiées (sp_page_meta).
   URL : /myspace/SPP_<Cod_Page>/<titre>/<num?>   ("new" = création)
   ============================================================================ */
import { useCallback, useContext, useEffect, useMemo, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Box } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import {
  Add, AttachFileOutlined, ContentCopyOutlined, DeleteOutline,
  DrawOutlined, PrintOutlined, SaveAsOutlined, VisibilityOff,
} from "@mui/icons-material";
import isEqual from "lodash.isequal";
import GroupBox from "../../components/GroupBox/GroupBox";
import Bouton from "../../components/Bouton/Bouton";
import Grille, { TColonne, TColonneCollection, TGrilleAction } from "../../components/Grille/Grille";
import { cntX } from "../../Menu/MenuMain";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { Agent } from "../../modules/module_general";
import { findRubrique, listRubriques } from "../../modules/module_rubriques";
import { ObjetGenerique } from "../../types";
import { TReport } from "../../Report/ReportViewer";
import { TSpChamp, TSpContexte, TSpMeta, TSpTable } from "./Types";
import { champVisible, cleChamp, construireGraphe, recalculer, validerClient } from "./dynamicEngine";
import DynamicField, { valeurAffichee } from "./DynamicField";
import SpPrintDialog from "./SpPrintDialog";

/** Valeur initiale d'un champ (constante ou variable GV_*). */
function valeurInitiale(champ: TSpChamp): any {
  const def = champ.Valeur_Defaut;
  if (def === null || def === undefined || def === "") {
    if (champ.Typ_Controle === "CHECK") return false;
    return "";
  }
  switch (def.toUpperCase()) {
    case "GV_MATRICULE": return Agent?.Matricule ?? "";
    case "GV_NOW": return new Date();
    case "GV_LOGIN": return Agent?.Login ?? "";
    default:
      if (["INT", "DEC", "MNT"].includes(champ.Typ_Controle)) {
        const n = Number(def.replace(",", "."));
        return isNaN(n) ? 0 : n;
      }
      if (champ.Typ_Controle === "CHECK") return def === "true" || def === "1";
      return def;
  }
}
/** Sérialisation pour l'envoi au serveur : les Date deviennent des chaînes locales
 *  naïves "aaaa-mm-jjThh:mm:ss" (canon « heure naïve » : la lecture d'horloge fait foi,
 *  jamais le fuseau — évite le décalage UTC à l'enregistrement). */
function valeurPourEnvoi(v: any): any {
  if (v instanceof Date && !isNaN(v.getTime())) {
    const p = (n: number) => String(n).padStart(2, "0");
    return `${v.getFullYear()}-${p(v.getMonth() + 1)}-${p(v.getDate())}T${p(v.getHours())}:${p(v.getMinutes())}:${p(v.getSeconds())}`;
  }
  return v;
}
function valeursPourEnvoi(obj: { [k: string]: any }): { [k: string]: any } {
  return Object.fromEntries(Object.entries(obj ?? {}).map(([k, v]) => [k, valeurPourEnvoi(v)]));
}
function enteteInitial(meta: TSpMeta): ObjetGenerique {
  const e: ObjetGenerique = { Statut: "" };
  meta.champs
    .filter((c) => c.Cod_Table === "ENT")
    .forEach((c) => { e[cleChamp(c)] = valeurInitiale(c); });
  return e;
}
function ligneInitiale(meta: TSpMeta, codTable: string): ObjetGenerique {
  const l: ObjetGenerique = { RowId: 0 };
  meta.champs
    .filter((c) => c.Cod_Table === codTable && c.Nom_Colonne) // sans colonne = pied de grille, pas une donnée de ligne
    .forEach((c) => { l[cleChamp(c)] = valeurInitiale(c); });
  return l;
}
/** Mapping Typ_Sql -> dataType de la Grille partagée.
 *  La distinction datetime (avec heure) / smalldatetime-date (sans heure) est préservée. */
function dataTypeGrille(typSql: string): TColonne["dataType"] {
  switch ((typSql ?? "").toLowerCase()) {
    case "int": case "bigint": return "int";
    case "float": case "decimal": return "float";
    case "datetime": case "datetime2": return "datetime";
    case "date": case "smalldatetime": return "smalldatetime";
    case "bit": return "bit";
    default: return "nvarchar";
  }
}

const DynamicPage = ({ codPage }: { codPage: string }) => {
  const navigate = useNavigate();
  const alert = useAlert();
  const msgBox = useMsgBox();
  const myAxios = useAxiosPost();
  const {
    settbnMenu, isSmall, isXs, isSm, setShowSignature, setSignatureProps,
    setShowGED, setGEDprops, setShowLoading,
  } = useContext(cntX);
  const { num } = useParams();

  /* ---- Métadonnées ---- */
  const [meta, setMeta] = useState<TSpMeta | null>(null);
  const [metaErreur, setMetaErreur] = useState("");
  useEffect(() => {
    let ok = false;
    setShowLoading(true);
    myAxios("sp_page_meta", { codPage })
      .then((dt) => {
        if (dt?.data?.result) {
          ok = true;
          setMeta(dt.data.data[0]);
        }
        else setMetaErreur(dt?.data?.message || "Page introuvable ou non publiée.");
      })
      .catch(() => setMetaErreur("Erreur de chargement de la page."))
      // En cas de succès, le waiter reste affiché : il sera masqué par loadData
      // une fois le document complètement chargé (évite un clignotement).
      .finally(() => { if (!ok) setShowLoading(false); });
  }, [codPage]);

  /* ---- État du document ---- */
  const [currentNum, setCurrentNum] = useState(num);
  useEffect(() => {
    setCurrentNum(num);
    setAccessible({ canModify: true, Taken_By_User: "", Process_Id: "" });
  }, [num]);
  const [entete, setEntete] = useState<ObjetGenerique>({});
  const [details, setDetails] = useState<{ [k: string]: any[] }>({});
  const enteteRef = useRef<ObjetGenerique | undefined>(undefined);
  const detailsRef = useRef<{ [k: string]: any[] } | undefined>(undefined);
  const savingRef = useRef(false);
  const [isAccessible, setAccessible] = useState({ canModify: true, Taken_By_User: "", Process_Id: "" });
  const [actionsGrille, setActionsGrille] = useState<{ [k: string]: TGrilleAction }>({});
  const [showPrint, setShowPrint] = useState(false);
  // Signal de (re)chargement du document : force la ré-exécution des champs SOURCE
  const [seqChargement, setSeqChargement] = useState(0);
  const ligneSelectionnee = useRef<{ [k: string]: number }>({});
  const nameEcran = `SPP_${codPage}`;
  const tablesDet = useMemo(
    () => (meta?.tables ?? []).filter((t) => t.Role_Table === "DET").sort((a, b) => a.Rang - b.Rang),
    [meta]
  );
  const champsEntete = useMemo(
    () => (meta?.champs ?? []).filter((c) => c.Cod_Table === "ENT").sort((a, b) =>
      (a.Ligne ?? 0) - (b.Ligne ?? 0) || (a.Colonne ?? 0) - (b.Colonne ?? 0) || a.Rang - b.Rang),
    [meta]
  );
  const ctx: TSpContexte = useMemo(() => ({ entete, details }), [entete, details]);

  /* ---- Chargement ---- */
  const resetDocument = useCallback(() => {
    if (!meta) return;
    const e = enteteInitial(meta);
    const d: { [k: string]: any[] } = {};
    tablesDet.forEach((t) => { d[t.Cod_Table] = []; });
    const r = recalculer(meta, e, d);
    setEntete(r.entete);
    setDetails(r.details);
    enteteRef.current = r.entete;
    detailsRef.current = r.details;
    setSeqChargement((s) => s + 1);
  }, [meta, tablesDet]);

  const loadData = useCallback(async () => {
    if (!meta) return;
    setShowLoading(true);
    try {
      if (currentNum !== "" && currentNum !== "new" && currentNum !== undefined) {
        await myAxios("sp_get_document", { codPage, numDoc: currentNum })
          .then((dt) => {
            if (dt?.data?.result) {
              // Recalcul complet au chargement : les champs calculés non persistés
              // (dont les pieds de grille) ne sont jamais stockés, ils se dérivent.
              const r = recalculer(meta, dt.data.entete, dt.data.details ?? {});
              setEntete(r.entete);
              setDetails(r.details);
              enteteRef.current = r.entete;
              detailsRef.current = r.details;
            } else {
              resetDocument();
            }
          })
          .catch(() => resetDocument());
      } else {
        resetDocument();
      }
      // Les champs SOURCE ne sont jamais persistés ni renvoyés par le serveur :
      // ce signal force leur ré-exécution après chaque (re)chargement, même quand
      // leurs paramètres mappés sont inchangés (ex. après un enregistrement).
      setSeqChargement((s) => s + 1);
    } finally {
      setShowLoading(false);
    }
  }, [currentNum, meta, resetDocument]);

  /* ---- Verrou d'accès concurrent (convention portail) ---- */
  const manageAccess = useCallback(async () => {
    if (currentNum !== "" && currentNum !== "new" && currentNum !== undefined) {
      await myAxios("check_accessible", { nameEcran, idEcran: currentNum })
        .then((dt) => { if (dt?.data && typeof dt.data === "object") setAccessible(dt.data); });
    }
  }, [currentNum, nameEcran]);

  useEffect(() => {
    if (!meta) return;
    loadData();
    if (meta.page.Workflow_Actif === "true") {
      setSignatureProps({ typ_document: meta.page.Typ_Document, valeur_index: currentNum || "" });
    }
    return () => {
      if (currentNum !== "" && currentNum !== "new" && currentNum !== undefined) {
        myAxios("release_accessible", { nameEcran, idEcran: currentNum });
      }
    };
  }, [loadData]);
  useEffect(() => { manageAccess(); }, [manageAccess]);

  // Détection d'une référence circulaire dans les calculs (signalée une fois)
  useEffect(() => {
    if (!meta) return;
    const g = construireGraphe(meta);
    if (g.cycle) {
      alert({ titre: "Configuration", msg: `Référence circulaire détectée : ${g.cycle}`, typMsg: "error" });
    }
  }, [meta]);

  /* ---- Champs SOURCE : valeurs ramenées du catalogue sécurisé ---- */
  const champsSource = useMemo(
    () => (meta?.champs ?? []).filter((c) => c.Cod_Table === "ENT" && c.Typ_Controle === "SOURCE" && c.Formule),
    [meta]
  );
  const depsSources = JSON.stringify(
    champsSource.map((c) => {
      try {
        const f = JSON.parse(c.Formule!);
        return Object.values(f?.mapping ?? {}).map((d: any) => (d?.ref ? entete?.[d.ref] : d?.const));
      } catch { return []; }
    })
  );
  useEffect(() => {
    if (!meta || champsSource.length === 0) return;
    champsSource.forEach((c) => {
      try {
        const f = JSON.parse(c.Formule!);
        const params: { [k: string]: any } = {};
        for (const [nomP, def] of Object.entries<any>(f?.mapping ?? {})) {
          params[nomP] = def?.ref ? entete?.[def.ref] : def?.const;
        }
        myAxios("sp_exec_source", { codSource: f.source, params }).then((dt) => {
          if (dt?.data?.result) {
            const val = dt.data.data?.[0]?.valeur;
            // Cascade SOURCE -> CALCULE : les champs calculés référençant cette
            // source sont recalculés dès sa résolution (graphe de dépendances).
            setEntete((prv) => {
              const nouvel = { ...prv, [cleChamp(c)]: val };
              const r = recalculer(meta, nouvel, details, cleChamp(c), undefined);
              if (r.details !== details) setDetails(r.details);
              return r.entete;
            });
          }
        }).catch(() => {});
      } catch { /* source invalide : ignorée */ }
    });
  }, [depsSources, meta, seqChargement]);

  /* ---- Détails VIRTUELS : grilles alimentées par une source (Typ_Retour
     TABLE), rafraîchies quand les paramètres mappés changent. Lecture seule. ---- */
  const tablesVirtuelles = useMemo(
    () => tablesDet.filter((t) => t.Source_Metier),
    [tablesDet]
  );
  const depsVirtuelles = JSON.stringify(
    tablesVirtuelles.map((t) => {
      try {
        const m = JSON.parse(t.Source_Mapping ?? "{}");
        return Object.values(m).map((d: any) => (d?.ref ? entete?.[d.ref] : d?.const));
      } catch { return []; }
    })
  );
  useEffect(() => {
    if (!meta || tablesVirtuelles.length === 0) return;
    tablesVirtuelles.forEach((t) => {
      try {
        const m = JSON.parse(t.Source_Mapping ?? "{}");
        const params: { [k: string]: any } = {};
        for (const [nomP, def] of Object.entries<any>(m)) {
          params[nomP] = def?.ref ? entete?.[def.ref] : def?.const;
        }
        myAxios("sp_exec_source", { codSource: t.Source_Metier, params }).then((dt) => {
          if (dt?.data?.result) {
            const lignes = (dt.data.data ?? []).map((l: any, i: number) => ({ ...l, RowId: i + 1 }));
            setDetails((prv) => {
              const nouveaux = { ...prv, [t.Cod_Table]: lignes };
              const r = recalculer(meta, entete, nouveaux, undefined, t.Cod_Table);
              if (r.entete !== entete) setEntete(r.entete);
              return r.details;
            });
          }
        }).catch(() => {});
      } catch { /* mapping invalide : ignoré */ }
    });
  }, [depsVirtuelles, meta]);

  /* ---- Changement d'un champ d'entête (convention onchange(nom, valeur)) ---- */
  function stateChange(nomColonne: string, valeur: any) {
    if (!meta) return;
    setEntete((prv) => {
      const nouvel = { ...prv, [nomColonne]: valeur };
      const r = recalculer(meta, nouvel, details, nomColonne, undefined);
      if (r.details !== details) setDetails(r.details);
      return r.entete;
    });
    // Validations au changement de champ (confort, niveau B uniquement signalé)
    const champModifie = meta.champs.find((c) => cleChamp(c) === nomColonne)?.Cod_Champ;
    const v = validerClient(meta, { entete: { ...entete, [nomColonne]: valeur }, details }, "CHANGE", champModifie);
    if (v.erreurs.length > 0) {
      alert({ titre: "Contrôle", msg: v.erreurs[0].message, typMsg: "warning" });
    }
  }
  /* ---- Grilles de détail ---- */
  function onChangeLigne(codTable: string, obj: { rowIndex: number; columnName: string; valeur: any }) {
    if (!meta) return;
    setDetails((prv) => {
      const lignes = [...(prv[codTable] ?? [])];
      lignes[obj.rowIndex] = { ...lignes[obj.rowIndex], [obj.columnName]: obj.valeur };
      const nouveaux = { ...prv, [codTable]: lignes };
      const r = recalculer(meta, entete, nouveaux, obj.columnName, codTable);
      if (r.entete !== entete) setEntete(r.entete);
      return r.details;
    });
  }
  function ajouterLigne(t: TSpTable) {
    if (!meta) return;
    const nouvelle = ligneInitiale(meta, t.Cod_Table);
    const nouveaux = { ...details, [t.Cod_Table]: [...(details[t.Cod_Table] ?? []), nouvelle] };
    // Validations à l'ajout de ligne
    const v = validerClient(meta, { entete, details: nouveaux }, "AJOUT_LIGNE");
    if (v.erreurs.length > 0) {
      alert({ titre: "Ajout de ligne", msg: v.erreurs[0].message, typMsg: "warning" });
      return;
    }
    const r = recalculer(meta, entete, nouveaux, undefined, t.Cod_Table);
    if (r.entete !== entete) setEntete(r.entete);
    setDetails(r.details);
  }
  async function supprimerLigne(t: TSpTable, e: { rowIndex: number; row: ObjetGenerique }) {
    if (!meta) return;
    const rsl = await msgBox({
      titre: "Suppression", typMsg: "stop", typReply: "OKCancel",
      msg: "Etes-vous sûr de vouloir supprimer cette ligne?",
      async handleOk() {
        setDetails((prv) => {
          const lignes = [...(prv[t.Cod_Table] ?? [])];
          lignes.splice(e.rowIndex, 1);
          const nouveaux = { ...prv, [t.Cod_Table]: lignes };
          const r = recalculer(meta, entete, nouveaux, undefined, t.Cod_Table);
          if (r.entete !== entete) setEntete(r.entete);
          return r.details;
        });
      },
      async handleCancel() { setActionsGrille((prv) => ({ ...prv, [t.Cod_Table]: "" })); },
    });
    void rsl;
  }
  function dupliquerLigne(t: TSpTable) {
    const lignes = details[t.Cod_Table] ?? [];
    const idx = ligneSelectionnee.current[t.Cod_Table] ?? lignes.length - 1;
    if (idx < 0 || idx >= lignes.length) return;
    const copie = { ...lignes[idx], RowId: 0 };
    ajouterCopie(t, copie);
  }
  function ajouterCopie(t: TSpTable, copie: any) {
    if (!meta) return;
    const nouveaux = { ...details, [t.Cod_Table]: [...(details[t.Cod_Table] ?? []), copie] };
    const r = recalculer(meta, entete, nouveaux, undefined, t.Cod_Table);
    if (r.entete !== entete) setEntete(r.entete);
    setDetails(r.details);
  }
  /** Colonnes d'une grille de détail, construites depuis les métadonnées. */
  function colonnesGrille(codTable: string, lectureSeule: boolean): TColonneCollection {
    const champs = (meta?.champs ?? [])
      .filter((c) => c.Cod_Table === codTable && c.Nom_Colonne) // sans colonne = pied de grille, jamais une colonne
      .sort((a, b) => a.Rang_Grille - b.Rang_Grille);
    const colonnes: TColonneCollection = {};
    const colMeta = new Map((meta?.colonnes ?? []).map((c) => [`${c.Cod_Table}|${c.Nom_Colonne}`, c]));
    for (const c of champs) {
      const typSql = colMeta.get(`${codTable}|${c.Nom_Colonne}`)?.Typ_Sql ?? "nvarchar";
      const enLecture = lectureSeule || c.Etat !== "S" || c.Typ_Controle === "CALCULE" || c.Typ_Controle === "SOURCE";
      colonnes[cleChamp(c)] = {
        columnName: cleChamp(c),
        headerText: c.Libelle,
        dataType: dataTypeGrille(typSql),
        readOnly: enLecture,
        visible: c.Visible_Grille === "true",
        typeColonne:
          c.Typ_Controle === "RUBRIQUE" || c.Typ_Controle === "COMBO" ? "Combo"
          : c.Typ_Controle === "CHECK" ? "Check"
          : c.Typ_Controle === "DATE" || c.Typ_Controle === "DATETIME" ? "Calendar"
          : "Text",
        dataSource: c.Typ_Controle === "RUBRIQUE" && c.Rubrique ? listRubriques(c.Rubrique) : undefined,
        sx: c.Largeur_Colonne ? { minWidth: `${c.Largeur_Colonne}em` } : undefined,
      };
    }
    colonnes["RowId"] = { columnName: "RowId", dataType: "int", readOnly: true, visible: false, headerText: "RowId", typeColonne: "Text" };
    return colonnes;
  }
  /** Pieds de grille : champs calculés rattachés au détail mais sans colonne
   *  physique (la formule porte l'agrégat, Format/Décimales le rendu). */
  function piedsGrille(codTable: string): TSpChamp[] {
    return (meta?.champs ?? [])
      .filter((c) => c.Cod_Table === codTable && !c.Nom_Colonne && c.Typ_Controle === "CALCULE")
      .sort((a, b) => a.Rang_Grille - b.Rang_Grille);
  }

  /* ---- Actions du document ---- */
  // Statuts figeant le document : paramétrables par page (Controle_Designer.Figer_Statuts),
  // défaut = convention RHP. Ex. 'SS,SG,RJ,SP,VA' fige dès la soumission.
  const statutFiges = useMemo(
    () => String(meta?.page?.Figer_Statuts ?? "SG,RJ,SP,VA").split(",").map((s) => s.trim()).filter(Boolean),
    [meta]
  );
  const estNouveau = currentNum === "" || currentNum === "new" || currentNum === undefined;
  const droitAction = estNouveau ? meta?.droits?.Creer : meta?.droits?.Modifier;
  const canSave =
    isAccessible.canModify &&
    !statutFiges.includes(entete?.Statut || "") &&
    (droitAction ?? false);

  const Enregistrer = useCallback(
    async (Statut: "" | "SS" = "") => {
      if (!meta) return;
      if (statutFiges.includes(entete?.Statut || "")) {
        await msgBox({ titre: "Enregistrer", msg: "Document traité. Modification impossible.", typMsg: "error", typReply: "OkOnly" });
        return;
      }
      const rslPaie = await myAxios("is_paie_encours", {});
      if (rslPaie.data) {
        await msgBox({ titre: "Enregistrer", msg: "Une préparation de la paie est en cours. Veuillez essayer plus tard.", typMsg: "error", typReply: "OkOnly" });
        return;
      }
      // Validations côté client (confort) - le serveur re-valide systématiquement
      const v = validerClient(meta, ctx, "SAVE");
      if (v.erreurs.length > 0) {
        await msgBox({
          titre: "Enregistrer", typMsg: "error", typReply: "OkOnly",
          msg: v.erreurs.map((e) => (e.ligne >= 0 ? `Ligne ${e.ligne + 1} : ${e.message}` : e.message)).join("\n"),
        });
        return;
      }
      if (v.avertissements.length > 0) {
        const r = await msgBox({
          titre: "Enregistrer", typMsg: "warning", typReply: "OKCancel",
          msg: v.avertissements.map((e) => (e.ligne >= 0 ? `Ligne ${e.ligne + 1} : ${e.message}` : e.message)).join("\n") + "\nVoulez-vous continuer?",
        });
        if (r === "Cancel") return;
      }
      if (savingRef.current) return;
      savingRef.current = true;
      // Les détails virtuels (alimentés par une source) ne sont jamais postés :
      // le serveur les ré-exécute lui-même avant validation/persistance.
      const tablesExclues = new Set(tablesVirtuelles.map((t) => t.Cod_Table));
      const rslSave = await myAxios("sp_save_document", {
        codPage,
        entete: valeursPourEnvoi(entete),
        details: Object.fromEntries(
          Object.entries(details ?? {})
            .filter(([t]) => !tablesExclues.has(t))
            .map(([t, ls]) => [t, (ls ?? []).map(valeursPourEnvoi)])
        ),
        statut: Statut,
      }).finally(() => { savingRef.current = false; });
      if (rslSave?.data?.result) {
        const numN = rslSave.data.data?.[0]?.Num_Doc;
        if (numN && numN !== currentNum) {
          // Affiche immédiatement le numéro généré (sans attendre le rechargement déclenché par l'URL)
          setEntete((prv) => ({ ...prv, Num_Doc: numN }));
          navigate(`/myspace/${nameEcran}/${meta.page.Nom_Page}/${numN}`, { replace: true });
        } else {
          await loadData();
        }
        alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      } else {
        alert({ titre: "Erreur", msg: rslSave?.data?.message || "Erreur lors de l'enregistrement", typMsg: "error" });
      }
    },
    [meta, entete, details, currentNum, ctx]
  );
  async function NonAccessible() {
    await msgBox({ titre: "Document utilisé", msg: "Document utilisé par: " + isAccessible.Taken_By_User, typMsg: "warning", typReply: "OkOnly" });
  }
  const Nouveau = useCallback(async () => {
    if (!isEqual(entete, enteteRef.current) || !isEqual(details, detailsRef.current)) {
      if ((await msgBox({
        titre: "Abandonner les modifications", typMsg: "warning", typReply: "OKCancel",
        msg: "Vous avez des modifications non enregistrées. Voulez-vous les abandonner?",
      })) === "Cancel") return;
    }
    if (!estNouveau) await myAxios("release_accessible", { nameEcran, idEcran: currentNum });
    navigate(`/myspace/${nameEcran}/${meta?.page?.Nom_Page}/new`);
  }, [entete, details, currentNum, meta]);
  const Supprimer = useCallback(async () => {
    if (!meta) return;
    if (estNouveau) { resetDocument(); return; }
    if (statutFiges.includes(entete?.Statut || "")) {
      await msgBox({ titre: "Supprimer", msg: "Document traité. Suppression impossible", typMsg: "warning", typReply: "OkOnly" });
      return;
    }
    if ((await msgBox({
      titre: "Supprimer", typMsg: "warning", typReply: "OKCancel",
      msg: "Êtes-vous sûr de vouloir supprimer ce document?",
    })) === "Cancel") return;
    const rsl = await myAxios("sp_delete_document", { codPage, numDoc: currentNum });
    if (rsl?.data?.result) {
      alert({ titre: "Suppression", msg: "Document supprimé.", typMsg: "success", timeOut: -1 });
      navigate(`/myspace/${nameEcran}/${meta.page.Nom_Page}/new`, { replace: true });
    } else {
      alert({ titre: "Suppression", msg: rsl?.data?.message || "Suppression impossible.", typMsg: "error", timeOut: -10 });
    }
  }, [meta, entete, currentNum]);
  const SoumettreEnSignature = useCallback(async () => {
    if (!meta || !currentNum) return;
    if (entete.Statut === "" || entete.Statut === "NSS") {
      if ((await msgBox({
        titre: "Signature", typMsg: "warning", typReply: "OKCancel",
        msg: `Êtes-vous sûr de vouloir soumettre ce document en signature?`,
      })) === "Ok") await Enregistrer("SS");
    } else {
      setShowSignature(true);
    }
  }, [Enregistrer, meta, entete, currentNum]);
  const ouvrirGED = useCallback(() => {
    if (currentNum && !estNouveau) {
      setGEDprops({ name_ecran: nameEcran, valeur_index: currentNum });
      setShowGED(true);
    }
  }, [currentNum, estNouveau, nameEcran]);

  /* ---- Barre d'actions (FloatMenu) ---- */
  useEffect(() => {
    if (!meta) return;
    const p = meta.page;
    settbnMenu([
      { name: "Accessible", disabled: false, libelle: "Accessible", action: NonAccessible, icon: <VisibilityOff />, visible: !isAccessible?.canModify ? "visible" : "none" },
      ...(p.Act_Enregistrer === "true"
        ? [{ name: "Enregistrer", disabled: !canSave, libelle: "Enregistrer", action: () => Enregistrer(""), icon: <SaveAsOutlined /> }]
        : []),
      { name: "Nouveau", disabled: !(meta.droits?.Creer ?? false), libelle: "Nouveau", action: Nouveau, icon: <Add /> },
      ...(meta.droits?.Supprimer
        ? [{ name: "Supprimer", disabled: !canSave, libelle: "Supprimer", action: Supprimer, icon: <DeleteOutline />, color: "error.main" }]
        : []),
      ...(p.Act_Imprimer === "true" && meta.droits?.Imprimer
        ? [{
            name: "Imprimer", disabled: estNouveau, libelle: "Imprimer",
            action: p.Cod_Modele_Edition
              ? () => navigate("/viewer", { state: { reportName: p.Cod_Modele_Edition, params: { NumDoc: currentNum } } as TReport })
              : () => setShowPrint(true), // impression générique (métadonnées)
            icon: <PrintOutlined />,
          }]
        : []),
      ...(p.Act_Soumettre === "true" && p.Workflow_Actif === "true" && meta.droits?.Valider
        ? [{
            name: "SS", disabled: false,
            libelle: !entete?.Statut || ["", "NSS"].includes(entete.Statut)
              ? "Soumettre pour signature"
              : findRubrique("Statut_Signature", entete.Statut),
            action: SoumettreEnSignature, icon: <DrawOutlined />,
          }]
        : []),
      ...(p.GED_Actif === "true" && meta.droits?.GED
        ? [{ name: "PJ", disabled: estNouveau, libelle: "Pièces jointes", action: ouvrirGED, icon: <AttachFileOutlined /> }]
        : []),
    ]);
  }, [meta, canSave, isAccessible.canModify, entete?.Statut, Enregistrer, Nouveau, currentNum]);

  /* ---- Rendu ---- */
  if (metaErreur) {
    return <GroupBox label="Page dynamique" showTitre showBorders={false}><Box sx={{ p: "2em", color: "error.main" }}>{metaErreur}</Box></GroupBox>;
  }
  if (!meta) return null;
  const lectureSeuleDoc = !canSave;
  return (
    <>
      <GroupBox
        label={meta.page.Nom_Page}
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          width: "100%", marginInline: "auto",
          "& .grpDiv": { padding: "2em 5px 5px 5px", width: "100%", minHeight: "10em", marginInline: "auto" },
        }}
      >
        <Grid container spacing={2}>
          {champsEntete.filter((c) => champVisible(c, ctx)).map((champ) => (
            <Grid key={champ.Cod_Champ} xs={12} sm={Math.min(12, (champ.Largeur ?? 3) * 2)} lg={champ.Largeur ?? 3} xl={champ.Largeur ?? 3}>
              <DynamicField
                champ={champ}
                valeur={entete?.[cleChamp(champ)]}
                ctx={ctx}
                readonlyGlobal={lectureSeuleDoc}
                onchange={stateChange}
                onOpenGed={ouvrirGED}
              />
            </Grid>
          ))}
        </Grid>
      </GroupBox>

      {tablesDet.map((t) => {
        const champsDet = (meta.champs ?? []).filter((c) => c.Cod_Table === t.Cod_Table);
        if (champsDet.length === 0) return null;
        const lignes = details[t.Cod_Table] ?? [];
        const lectureSeule = lectureSeuleDoc || t.Allow_Edit !== "true";
        return (
          <GroupBox key={t.Cod_Table} label={t.Libelle || t.Cod_Table} showBorders={!isSmall} showTitre={true}
            sx={{ width: "100%", marginInline: "auto", mt: "1em",
              "& .grpDiv": { padding: "2em 5px 5px 5px", width: "100%", marginInline: "auto" } }}>
            <>
              {(t.Allow_Add === "true" || t.Allow_Delete === "true" || t.Allow_Duplicate === "true") && (
                <div style={{ display: "flex", justifyContent: "center", alignItems: "center", gap: "1em", margin: "0 auto 0.5em auto", maxWidth: "40em" }}>
                  {t.Allow_Add === "true" && (
                    <Bouton disabled={!canSave} iconOnly={isXs || isSm} variant={isXs || isSm ? "contained" : "outlined"}
                      sx={{ flexGrow: 1 }} label="Ajouter" startIcon={<Add />}
                      onClick={() => ajouterLigne(t)} />
                  )}
                  {t.Allow_Duplicate === "true" && (
                    <Bouton disabled={!canSave || lignes.length === 0} iconOnly={isXs || isSm} variant="outlined"
                      sx={{ flexGrow: 1 }} label="Dupliquer" startIcon={<ContentCopyOutlined />}
                      onClick={() => dupliquerLigne(t)} />
                  )}
                  {t.Allow_Delete === "true" && (
                    <Bouton disabled={!canSave} sx={{ flexGrow: 1 }} variant="contained" color="error"
                      iconOnly={isXs || isSm} label="Supprimer" startIcon={<DeleteOutline />}
                      onClick={() => setActionsGrille((prv) => ({ ...prv, [t.Cod_Table]: (prv[t.Cod_Table] ?? "") === "" ? "supprimer" : "" }))} />
                  )}
                </div>
              )}
              <Box sx={{ margin: "auto", padding: "5px", width: "100%", overflow: "scroll" }}>
                <Grille
                  readonly={lectureSeule}
                  dataSource={lignes}
                  Colonnes={colonnesGrille(t.Cod_Table, lectureSeule)}
                  className="laGrille"
                  onchange={(e: any) => onChangeLigne(t.Cod_Table, e)}
                  action={actionsGrille[t.Cod_Table] ?? ""}
                  ondelete={(e: any) => supprimerLigne(t, e)}
                  onclick={(e: any) => { if (e?.rowIndex !== undefined) ligneSelectionnee.current[t.Cod_Table] = e.rowIndex; }}
                />
                {piedsGrille(t.Cod_Table).filter((c) => champVisible(c, ctx)).map((champ) => (
                  <Box key={champ.Cod_Champ} sx={{ padding: "0.5em", fontWeight: "bold", textAlign: "center", color: "var(--color-base-01, #3899b9)" }}>
                    {champ.Libelle} : {valeurAffichee(champ, entete?.[cleChamp(champ)])}
                  </Box>
                ))}
              </Box>
            </>
          </GroupBox>
        );
      })}
      <SpPrintDialog meta={meta} ctx={ctx} open={showPrint} onClose={() => setShowPrint(false)} />
    </>
  );
};
export default DynamicPage;
