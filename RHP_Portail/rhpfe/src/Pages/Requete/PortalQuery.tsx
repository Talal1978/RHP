/* ============================================================================
   Requêteur - Page de consultation portail générée depuis Param_Query (desktop)
   ----------------------------------------------------------------------------
   Une requête du requêteur exposée au portail (Param_Query_Widget.estPortail)
   s'affiche DIRECTEMENT depuis le menu (entrée SPQ_<Cod_Query>, sans page
   liste) : GroupBox "Critères" + boutons inline Interroger / Nouveau /
   Exporter (Excel .xlsx des résultats affichés) + grille en lecture seule
   (logique de thème des listes standard, DynamicPage_Liste).
   Pas de FAB : les actions sont inline (convention des pages-requêtes) ;
   critères + résultats persistés en session via useEtatListe.
   Les critères respectent la Fonction_Critere déclarée dans Param_Query
   (même comportement que l'écran d'exécution desktop Param_Query_Saisi) :
   TextBox => saisie libre ; Calender => calendrier ; Boolean => case à
   cocher ; Appel_Zoom (« Menu Local », zoom long) => panneau zoom
   (ZoomCritere, grille Code/Libellé) ; Combo (« Rubrique ») => liste
   déroulante (ComboBox). Listes alimentées par l'endpoint sp_query_zoom.
   URL : /myspace/SPQ_<Cod_Query>/<titre>
   ============================================================================ */
import { useCallback, useContext, useEffect, useMemo, useState } from "react";
import { Box } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { CloudSyncOutlined, FileDownloadOutlined, RefreshOutlined } from "@mui/icons-material";
import * as XLSX from "xlsx";
import GroupBox from "../../components/GroupBox/GroupBox";
import Bouton from "../../components/Bouton/Bouton";
import Grille from "../../components/Grille/Grille";
import ComboBox from "../../components/ComboBox/ComboBox";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import useEtatListe from "../../hooks/useEtatListe";
import { libelleColonne } from "../../modules/module_libelles";
import { cntX } from "../../Menu/MenuMain";
import { ObjetGenerique } from "../../types";
import { TSpChamp } from "../Dynamic/Types";
import DynamicField from "../Dynamic/DynamicField";
import ZoomCritere, { TChoixZoom } from "./ZoomCritere";

/** Critère à saisir, tel que retourné par sp_query_meta. */
type TCritereMeta = {
  nom: string;
  libelle: string;
  controle: "INT" | "DEC" | "DATE" | "DATETIME" | "CHECK" | "TEXT";
  /** Fonction_Critere déclarée : '' / TextBox / Calender / Appel_Zoom / Combo / Boolean */
  fonction: string;
  defaut: string;
  rang: number;
};
type TMeta = { nom: string; icone: string; criteres: TCritereMeta[] };

/** Appel_Zoom (« Menu Local », zoom long) => panneau zoom (grille Code/Libellé). */
const estCritereZoom = (c: TCritereMeta) => c.fonction === "Appel_Zoom";
/** Combo (« Rubrique ») => liste déroulante. */
const estCritereCombo = (c: TCritereMeta) => c.fonction === "Combo";
/** Critères dont la liste est alimentée par sp_query_zoom. */
const estCritereListe = (c: TCritereMeta) => estCritereZoom(c) || estCritereCombo(c);

/** Champ synthétique pour DynamicField (mêmes règles de rendu que les listes). */
function champCritere(c: TCritereMeta): TSpChamp {
  return {
    Cod_Champ: c.nom,
    Cod_Table: "ENT",
    Nom_Colonne: c.nom,
    Libelle: c.libelle,
    Typ_Controle: c.controle,
    Rang: c.rang,
    Ligne: null,
    Colonne: null,
    Largeur: null,
    Valeur_Defaut: null,
    Aide: null,
    Obligatoire: "false",
    Etat: "S",
    Rubrique: null,
    Num_Zoom: null,
    Zoom_Retour: null,
    Zoom_Condition: null,
    Source_Metier: null,
    Formule: null,
    Persiste: "false",
    Recalc_Save: "true",
    Format_Affichage: null,
    Decimales: null,
    Regle_Visibilite: null,
    Regle_Activation: null,
    Visible_Grille: "false",
    Rang_Grille: c.rang,
    Largeur_Colonne: null,
    estCritere: "false",
    Rang_Critere: null,
  };
}

/** Valeur initiale d'un critère (constante de Default_Value déclarée). */
function valeurInitiale(c: TCritereMeta): any {
  if (c.defaut === "") return c.controle === "CHECK" ? false : "";
  if (c.controle === "CHECK") return c.defaut === "true" || c.defaut === "1";
  if (c.controle === "INT" || c.controle === "DEC") {
    const n = Number(c.defaut.replace(",", "."));
    return isNaN(n) ? 0 : n;
  }
  if (c.controle === "DATE" || c.controle === "DATETIME") {
    const d = new Date(c.defaut);
    return isNaN(d.getTime()) ? "" : d;
  }
  return c.defaut;
}

/** Sérialisation pour l'envoi au serveur : Date -> chaîne locale naïve
 *  (jamais l'ISO UTC qui décalerait la date d'un jour côté SQL). */
function valeurPourEnvoi(v: any): any {
  if (v instanceof Date && !isNaN(v.getTime())) {
    const p = (n: number) => String(n).padStart(2, "0");
    return `${v.getFullYear()}-${p(v.getMonth() + 1)}-${p(v.getDate())}T${p(v.getHours())}:${p(v.getMinutes())}:${p(v.getSeconds())}`;
  }
  return v;
}

const PortalQuery = ({ codQuery }: { codQuery: string }) => {
  const alert = useAlert();
  const myAxios = useAxiosPost();
  const { isSmall, isXs, isSm, isLg, isXl, setShowLoading } = useContext(cntX);
  // Persistance critères + résultats (sessionStorage, convention des listes)
  const { criteres, setCriteres, stateChange, ds, setDs, dsFields, setDsFields } =
    useEtatListe<ObjetGenerique>(`SPQ_${codQuery}`, {});
  const [meta, setMeta] = useState<TMeta | null>(null);
  const [tronque, setTronque] = useState(false);
  // Listes des critères Appel_Zoom (zoom) / Combo (rubrique), via sp_query_zoom
  const [listesZoom, setListesZoom] = useState<Record<string, TChoixZoom[]>>({});

  /* ---- Métadonnées de la page (nom + critères à saisir) ---- */
  useEffect(() => {
    myAxios("sp_query_meta", { codQuery })
      .then((dt) => {
        if (dt?.data?.result) {
          const m = dt.data.data[0] as TMeta;
          setMeta(m);
          // Valeurs initiales : Default_Value déclarée (sans écraser l'état restauré)
          setCriteres((prv) => {
            const nv = { ...prv };
            for (const c of m.criteres) {
              if (nv[c.nom] === undefined || nv[c.nom] === null || nv[c.nom] === "") {
                nv[c.nom] = valeurInitiale(c);
              }
            }
            return nv;
          });
          // Listes de choix des critères Appel_Zoom (« Menu Local ») / Combo (« Rubrique »)
          for (const c of m.criteres.filter(estCritereListe)) {
            myAxios("sp_query_zoom", { codQuery, critere: c.nom })
              .then((lz) => {
                if (lz?.data?.result) {
                  setListesZoom((prv) => ({ ...prv, [c.nom]: lz.data.data ?? [] }));
                }
              })
              .catch(() => {});
          }
        } else {
          alert({ titre: "Consultation", msg: dt?.data?.message || "Page introuvable ou non autorisée.", typMsg: "error" });
        }
      })
      .catch(() => alert({ titre: "Consultation", msg: "Erreur de chargement de la page.", typMsg: "error" }));
  }, [codQuery]);

  const ctx = useMemo(() => ({ entete: criteres ?? {}, details: {} }), [criteres]);

  /* ---- Exécution de la requête (bouton 'Interroger' + chargement initial) ---- */
  const interroger = useCallback(async () => {
    setShowLoading(true);
    try {
      const valeurs = Object.fromEntries(
        Object.entries(criteres ?? {}).map(([k, v]) => [k, valeurPourEnvoi(v)])
      );
      const dt = await myAxios("sp_query_exec", { codQuery, valeurs });
      if (dt?.data?.result) {
        setDs(dt.data.data ?? []);
        setDsFields(dt.data.fields ?? {});
        setTronque(dt.data.tronque === true);
      } else {
        setDs([]);
        setDsFields({});
        setTronque(false);
        if (dt?.data?.message) alert({ titre: "Consultation", msg: dt.data.message, typMsg: "error" });
      }
    } catch {
      setDs([]);
      setDsFields({});
      setTronque(false);
    } finally {
      setShowLoading(false);
    }
  }, [codQuery, criteres]);

  // Chargement initial : exécution automatique avec les critères par défaut
  // (les résultats restaurés du cache ne sont pas rejoués : ds déjà présent).
  useEffect(() => {
    if (meta && ds.length === 0) interroger();
  }, [meta]);

  /* ---- 'Nouveau' : vide les critères (retour aux valeurs par défaut) ---- */
  const nouveau = useCallback(() => {
    const nv: ObjetGenerique = {};
    for (const c of meta?.criteres ?? []) nv[c.nom] = valeurInitiale(c);
    setCriteres(nv);
    setDs([]);
    setDsFields({});
    setTronque(false);
  }, [meta]);

  /* ---- Export Excel des résultats affichés (fichier .xlsx, valeurs typées) ---- */
  const exporterExcel = useCallback(() => {
    const cols = Object.entries(dsFields ?? {}).filter(([, c]) => c?.visible !== false);
    if (ds.length === 0 || cols.length === 0) return;
    const estTypDate = (t: string) => t.includes("date") || t.includes("time");
    const estTypNombre = (t: string) =>
      ["int", "bigint", "smallint", "tinyint", "float", "real", "decimal", "numeric", "money"].some((x) => t.startsWith(x));
    // Mêmes entêtes que la grille (libelleColonne quand headerText = nom brut)
    const entetes = cols.map(([nom, c]) =>
      c?.headerText && c.headerText !== nom ? c.headerText : libelleColonne(nom)
    );
    const lignes = ds.map((row) =>
      cols.map(([nom, c]) => {
        const v = row[nom];
        if (v === null || v === undefined) return "";
        const t = String(c?.dataType ?? "").toLowerCase();
        if (estTypDate(t)) { const d = new Date(v); return isNaN(d.getTime()) ? String(v) : d; }
        if (estTypNombre(t)) { const n = Number(v); return isNaN(n) ? String(v) : n; }
        if (t === "bit") return v === true || v === 1 || String(v).toLowerCase() === "true";
        return String(v);
      })
    );
    const ws = XLSX.utils.aoa_to_sheet([entetes, ...lignes], { cellDates: true });
    // Dates au format jj/mm/aaaa + largeurs de colonnes ajustées au contenu
    cols.forEach(([, c], j) => {
      if (!estTypDate(String(c?.dataType ?? "").toLowerCase())) return;
      for (let i = 1; i <= lignes.length; i++) {
        const cell = ws[XLSX.utils.encode_cell({ r: i, c: j })];
        if (cell && cell.t === "d") cell.z = "dd/mm/yyyy";
      }
    });
    ws["!cols"] = cols.map(([nom], j) => ({
      wch: Math.min(50, Math.max(String(entetes[j]).length, ...ds.slice(0, 200).map((r) => String(r[nom] ?? "").length)) + 2),
    }));
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, "Résultats");
    XLSX.writeFile(wb, `${(meta?.nom || codQuery).replace(/[/\\:*?"<>|]/g, "_")}.xlsx`);
  }, [ds, dsFields, meta, codQuery]);

  return (
    <>
      <GroupBox
        label={meta?.nom || "Consultation"}
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px",
            width: "100%",
            minHeight: "10em",
          },
        }}
      >
        <>
          <Grid container spacing={5}>
            {(meta?.criteres ?? []).map((c) => {
              // Même comportement que l'écran d'exécution desktop
              // Param_Query_Saisi : Appel_Zoom (« Menu Local ») => panneau
              // zoom (grille Code/Libellé) ; Combo (« Rubrique ») => liste
              // déroulante. Listes alimentées par sp_query_zoom.
              if (estCritereZoom(c)) {
                return (
                  <Grid key={c.nom} xs={12} sm={12} lg={4} xl={3}>
                    <ZoomCritere
                      liste={listesZoom[c.nom] ?? []}
                      nomControle={c.nom}
                      label={c.libelle}
                      valeur={String(criteres?.[c.nom] ?? "")}
                      onchange={stateChange}
                      style={{ width: "100%" }}
                    />
                  </Grid>
                );
              }
              if (estCritereCombo(c)) {
                return (
                  <Grid key={c.nom} xs={12} sm={12} lg={4} xl={3}>
                    <ComboBox
                      dataSource={listesZoom[c.nom] ?? []}
                      nomControle={c.nom}
                      label={c.libelle}
                      valeur={String(criteres?.[c.nom] ?? "")}
                      onchange={stateChange}
                      style={{ width: "100%" }}
                    />
                  </Grid>
                );
              }
              const champ = champCritere(c);
              return (
                <Grid key={c.nom} xs={12} sm={12} lg={4} xl={3}>
                  <DynamicField
                    champ={champ}
                    valeur={criteres?.[c.nom]}
                    ctx={ctx}
                    onchange={stateChange}
                  />
                </Grid>
              );
            })}
          </Grid>
          <div
            style={{
              maxWidth: isXl || isLg ? "36vw" : "80%",
              width: isXl || isLg ? "36vw" : "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gap: "1em",
              margin: "3em auto 0.5em auto",
            }}
          >
            <Bouton
              iconOnly={isXs || isSm}
              variant={isXs || isSm ? "contained" : "outlined"}
              sx={{ flexGrow: 1 }}
              label="Interroger"
              startIcon={<CloudSyncOutlined />}
              onClick={interroger}
            />
            <Bouton
              label="Nouveau"
              iconOnly={isXs || isSm}
              sx={{ flexGrow: 1 }}
              startIcon={<RefreshOutlined />}
              onClick={nouveau}
            />
            <Bouton
              label="Exporter"
              iconOnly={isXs || isSm}
              sx={{ flexGrow: 1 }}
              startIcon={<FileDownloadOutlined />}
              onClick={exporterExcel}
              disabled={ds.length === 0}
            />
          </div>
        </>
      </GroupBox>
      <Box
        sx={{
          margin: "auto",
          padding: "2em 5px",
          width: "100%",
          overflow: "scroll",
        }}
      >
        <Grille
          readonly={true}
          dataSource={ds}
          Colonnes={dsFields}
          className="laGrille"
          sx={{
            "& .cl0": {
              width: "100px !important",
            },
          }}
        />
        {tronque && (
          <Box sx={{ textAlign: "center", color: "text.secondary", fontSize: "0.85em", mt: "0.5em" }}>
            Affichage limité aux 500 premières lignes (plafond de sécurité) — affinez les critères.
          </Box>
        )}
      </Box>
    </>
  );
};
export default PortalQuery;
