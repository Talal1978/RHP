import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  SxProps,
} from "@mui/material";
import { Search } from "@mui/icons-material";
import { createContext, useEffect, useRef, useState, useMemo, ReactNode } from "react";
import GrilleHeaderCell, { filterEngine } from "./GrilleHeaderCell";
import GrilleRow from "./GrilleRow";
import useAxiosPost from "../../hooks/useAxiosPost";
import { estDate } from "../../modules/module_formats";
import { libelleColonne } from "../../modules/module_libelles";
import "./grille.scss";
import { ObjetGenerique } from "../../types";
import { useDeepCompareEffect } from "../../hooks/useDeepCompareEffect";

export const cntx = createContext<{
  filtre?: filtreF;
  setFiltre?: any;
  innerDataSource?: { [key: string]: any }[];
  setFiltredData?: any;
  isFiltred?: boolean;
  setIsFiltred?: any;
  onchange?: (e: any) => void;
  rechercheZoom?: boolean;
  colRecherche?: string;
  setColRecherche?: any;
}>({ filtre: {} });
export default function Grille({
  numZoom = "",
  sx = {},
  readOnlyRows = [],
  colonnesAFiltrer = [],
  dataSource = [],
  Colonnes = {},
  readonly = false,
  className = "",
  action = "",
  actionsLigne = [],
  showBorder = true,
  rechercheZoom = false,
  nbLignesMax = 20,
  onclick = () => {},
  onchange = () => {},
  ondelete = () => {},
  conditionZoom,
}: TGrille) {
  const setBorder = showBorder
    ? { border: `0.5px groove #7cb2c4 !important` }
    : {};
  const myAxios = useAxiosPost();
  const [filtre, setFiltre] = useState<filtreF>({});
  const [isFiltred, setIsFiltred] = useState(false);
  const [innerDataSource, setInnerDataSource] =
    useState<{ [key: string]: any }[]>(dataSource);
  const [Fields, setFields] = useState<TColonneCollection>(Colonnes);
  const [filtredData, setFiltredData] = useState<{ [key: string]: any }[]>([]);
  // --- Recherche clavier du zoom (rechercheZoom) -------------------------
  // searchBy : position 1-based de la colonne de recherche par défaut, lue de
  // Controle_Def_Zoom.Search_By (renvoyée par l'API zoom) ; colRecherche :
  // colonne actuellement ciblée (Search_By par défaut, colonne cliquée sinon).
  const [searchBy, setSearchBy] = useState("");
  const [colRecherche, setColRecherche] = useState("");
  const [recherche, setRecherche] = useState("");
  const [ligneActive, setLigneActive] = useState(0);
  const [nbResultats, setNbResultats] = useState(0);
  const rechercheRef = useRef<HTMLInputElement>(null);
  useDeepCompareEffect(() => {
    if (dataSource.length === 0 && numZoom !== "") {
      myAxios("zoom", { numZoom, conditionZoom })
        .then((dt) => {
          if (dt.data) {
            if (dt.data.result) {
              const obj: { [key: string]: any }[] = [...dt.data.data];
              setFiltredData(obj.slice(0, nbLignesMax));
              setInnerDataSource(obj);
              setFields(dt.data.fields);
              setSearchBy(String(dt.data.searchBy ?? ""));
            }
          }
        })
        .catch((err) => console.error(err));
    } else {
      setFiltredData(dataSource.slice(0, nbLignesMax));
      setInnerDataSource(dataSource);
      if (Object.keys(Colonnes).length === 0 && dataSource.length > 0) {
        let lesChamps = Object.keys(dataSource[0]);
        let typesDeDonnees: TColonneCollection = {};
        lesChamps.forEach((t, ind) => {
          switch (true) {
            case typeof dataSource[0][t] === "boolean":
              typesDeDonnees[t] = {
                columnName: t,
                dataType: "bit",
                readOnly: true,
                typeColonne: "Check",
                visible: true,
              };
              break;
            case typeof dataSource[0][t] === "number":
              typesDeDonnees[t] = {
                columnName: t,
                dataType: "float",
                readOnly: true,
                typeColonne: "Text",
                visible: true,
              };
              break;
            case estDate(dataSource[0][t]):
              typesDeDonnees[t] = {
                columnName: t,
                dataType: "smalldatetime",
                readOnly: true,
                typeColonne: "Text",
                visible: true,
              };
              break;
            default:
              typesDeDonnees[t] = {
                columnName: t,
                dataType: "nvarchar",
                readOnly: true,
                typeColonne: "Text",
                visible: true,
              };
              break;
          }
        });
        setFields(typesDeDonnees);
      } else setFields(Colonnes);
    }
  }, [numZoom, dataSource, Colonnes, conditionZoom, nbLignesMax]);
  useDeepCompareEffect(() => {
    setFiltre(() => {
      const obj: filtreF = {};
      Object.entries(Fields).forEach(([col, typ], ind) => {
        if (numZoom || colonnesAFiltrer.includes(ind))
          obj[col] = {
            expression: "",
            visible: false,
            typeData: typ.dataType,
          };
      });
      return obj;
    });
  }, [Fields]);
  const contextValue = useMemo(
    () => ({
      filtre,
      setFiltre,
      setFiltredData,
      innerDataSource,
      isFiltred,
      setIsFiltred,
      onchange,
      rechercheZoom,
      colRecherche,
      setColRecherche,
    }),
    [filtre, innerDataSource, isFiltred, rechercheZoom, colRecherche]
  );
  /* Colonne ciblée par la recherche clavier : Search_By (1-based) par défaut,
   * même règle que le desktop (Zoom.vb : >1 → index-1, sinon 0 ; absent ou
   * non numérique → 2e colonne = libellé), bornée aux colonnes visibles. Un
   * choix manuel (clic sur un en-tête) est conservé tant qu'il est valide. */
  useEffect(() => {
    if (!rechercheZoom) return;
    const visibles = Object.keys(Fields).filter((c) => Fields[c]?.visible);
    if (visibles.length === 0) return;
    setColRecherche((prv) => {
      if (prv && visibles.includes(prv)) return prv;
      const n = parseInt(searchBy, 10);
      if (!isNaN(n)) {
        return visibles[n > 1 ? Math.min(n - 1, visibles.length - 1) : 0];
      }
      return visibles[Math.min(1, visibles.length - 1)];
    });
  }, [Fields, searchBy, rechercheZoom]);
  /* Filtrage des lignes, centralisé ici (et non dans chaque cellule d'en-tête)
   * : filtres par colonne (icônes des en-têtes) puis recherche clavier du
   * zoom sur la colonne ciblée. */
  useEffect(() => {
    if (!filtre || !innerDataSource) {
      setIsFiltred(false);
      return;
    }
    let _filtred = [...innerDataSource];
    let estFiltree = false;
    Object.entries(filtre).forEach(([col, v]) => {
      if (v.expression && v.expression.trim() !== "") {
        estFiltree = true;
        _filtred = _filtred.filter((f) =>
          filterEngine(v.typeData, f[col], v.expression)
        );
      }
    });
    const exprRecherche = recherche.trim();
    if (rechercheZoom && exprRecherche !== "" && colRecherche) {
      estFiltree = true;
      const typCol =
        filtre[colRecherche]?.typeData ??
        Fields[colRecherche]?.dataType ??
        "nvarchar";
      _filtred = _filtred.filter((f) =>
        filterEngine(typCol, f[colRecherche], exprRecherche)
      );
    }
    setIsFiltred(estFiltree);
    setNbResultats(_filtred.length);
    setFiltredData(_filtred.slice(0, nbLignesMax));
  }, [filtre, innerDataSource, recherche, colRecherche, rechercheZoom, Fields, nbLignesMax]);
  // La ligne active (navigation ↑/↓) repart sur la 1ère ligne à chaque
  // nouveau résultat de recherche/filtrage.
  useEffect(() => {
    setLigneActive(0);
  }, [filtredData]);
  // Après un changement de colonne (clic sur un en-tête), le focus revient à
  // la zone de recherche pour enchaîner la frappe sans repasser à la souris.
  useEffect(() => {
    if (rechercheZoom && colRecherche) rechercheRef.current?.focus();
  }, [colRecherche, rechercheZoom]);
  const libelleColRecherche = (() => {
    if (!colRecherche) return "";
    const h = Fields[colRecherche]?.headerText;
    return h && h !== colRecherche ? h : libelleColonne(colRecherche);
  })();
  const onKeyDownRecherche = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "ArrowDown") {
      e.preventDefault();
      setLigneActive((i) => Math.min(i + 1, filtredData.length - 1));
    } else if (e.key === "ArrowUp") {
      e.preventDefault();
      setLigneActive((i) => Math.max(i - 1, 0));
    } else if (e.key === "Enter") {
      // Entrée = sélection de la ligne active (la 1ère ligne par défaut)
      e.preventDefault();
      const ind = ligneActive < filtredData.length ? ligneActive : 0;
      const row = filtredData[ind];
      if (row) onclick({ colListe: Object.keys(Fields), rowIndex: ind, row });
    }
    // Échap n'est pas consommé : il remonte au panneau zoom qui ferme.
  };
  // Cellule d'actions de ligne (1ère colonne, sans en-tête) : présente dès
  // qu'une action est déclarée (action historique OU actionsLigne génériques).
  const nbActions = (action !== "" ? 1 : 0) + (actionsLigne?.length ?? 0);
  const largeurCelluleAction =
    nbActions > 1 ? `${nbActions * 1.5}em !important` : "1em !important";
  return (
    <cntx.Provider value={contextValue}>
      {rechercheZoom && (
        <div className="rechercheZoom">
          <Search className="iconeRecherche" />
          <input
            ref={rechercheRef}
            type="text"
            autoFocus
            value={recherche}
            placeholder={`Filtrer par ${libelleColRecherche}...`}
            title="Tapez pour filtrer — clic sur un en-tête pour changer de colonne — ↑/↓ : naviguer — Entrée : sélectionner — Échap : fermer"
            onChange={(e) => setRecherche(e.target.value)}
            onKeyDown={onKeyDownRecherche}
          />
          {recherche.trim() !== "" && (
            <span className="compteurResultats">
              {nbResultats === 0
                ? "Aucune ligne"
                : `${nbResultats} ligne${nbResultats > 1 ? "s" : ""}`}
            </span>
          )}
        </div>
      )}
      <TableContainer
        component={Paper}
        className={`${className} grilleContainer`}
        sx={{ ...sx, fontSize: { xs: "0.9em", sm: "0.95em", md: "1em" } }}
      >
        <Table stickyHeader aria-label="sticky table" className="grille">
          <TableHead className="th">
            <TableRow className="tr">
              {nbActions > 0 && (
                <TableCell
                  className={`td cl_1 rw_1`}
                  key="cl_1"
                  sx={{
                    maxWidth: largeurCelluleAction,
                    width: largeurCelluleAction,
                    whiteSpace: "nowrap",
                  }}
                />
              )}
              {Object.keys(Fields).map((cl, indCol) => {
                return (
                  Fields?.[cl]?.visible && (
                    <TableCell
                      sx={{
                        ...Fields?.[cl]?.sx,
                        ...setBorder,
                      }}
                      className={`td cl${indCol} rw_1`}
                      key={cl}
                    >
                      <GrilleHeaderCell
                        headerText={
                          Fields?.[cl]?.headerText &&
                          Fields[cl].headerText !== cl
                            ? Fields[cl].headerText
                            : libelleColonne(cl)
                        }
                        colName={cl}
                      />
                    </TableCell>
                  )
                );
              })}
            </TableRow>
          </TableHead>
          <TableBody sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
            {filtredData.map((row, indRow) => {
              return (
                <GrilleRow
                  showBorder={showBorder}
                  row={row}
                  indRow={indRow}
                  action={action}
                  actionsLigne={actionsLigne}
                  Fields={Fields}
                  onclick={onclick}
                  ondelete={ondelete}
                  key={indRow}
                  readOnly={readOnlyRows.includes(indRow) || readonly}
                  active={rechercheZoom && indRow === ligneActive}
                />
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
    </cntx.Provider>
  );
}
export type TColonneCollection = {
  [key: string]: TColonne;
};
export type TColonne = {
  columnName: string;
  headerText?: string;
  dataType: TDataType;
  readOnly: boolean;
  visible: boolean;
  typeColonne?: "Text" | "Combo" | "Check" | "Calendar" | "Image";
  dataSource?: ObjetGenerique[];
  sx?: SxProps;
};
export type TDataType =
  | "int"
  | "float"
  | "datetime"
  | "smalldatetime"
  | "nvarchar"
  | "varchar"
  | "bit"
  | "varbinary"
  | string;

interface filtreF {
  [key: string]: { expression: string; visible: boolean; typeData: string };
}
type TGrille = {
  numZoom?: string;
  /** Condition additionnelle transmise à l'API zoom (ex. "Matricule='D0011'"). */
  conditionZoom?: string;
  sx?: {};
  readOnlyRows?: number[];
  colonnesAFiltrer?: number[];
  dataSource?: any[];
  Colonnes?: TColonneCollection;
  readonly?: boolean;
  className?: string;
  action?: TGrilleAction;
  /** Actions génériques par ligne (icônes de la 1ère colonne) : plusieurs
   *  actions par ligne possibles, chacune désactivable selon la ligne
   *  (ex. suppression grisée dès que le statut du document a évolué).
   *  Contrairement à `action` (pilotée par rowIndex, masquée sous filtrage),
   *  le handler reçoit la LIGNE et reste affiché même si la grille est filtrée. */
  actionsLigne?: TGrilleActionLigne[];
  showBorder?: boolean;
  /** Active la barre de recherche clavier du zoom (filtrage sur la colonne
   *  Search_By par défaut, colonne cliquée sinon ; ↑/↓ + Entrée pour
   *  sélectionner sans souris). À réserver aux panneaux de zoom. */
  rechercheZoom?: boolean;
  /** Nombre maximal de lignes rendues (défaut 20 — comportement historique).
   *  Les pages liste paginées côté serveur (ex. DynamicPage_Liste) passent
   *  leur taille de page pour afficher toutes les lignes reçues. */
  nbLignesMax?: number;
  onclick?: (e: TGrilleEventClick) => void;
  onchange?: (e: any) => void;
  ondelete?: (e: { rowIndex: number; row: ObjetGenerique }) => void;
};
export type TGrilleEventClick = {
  colListe?: string[];
  colIndex?: number;
  rowIndex?: number;
  colName?: string;
  colType?: TColonne;
  value?: any;
  row?: ObjetGenerique;
};
export type TGrilleAction = "inserer" | "modifier" | "supprimer" | "";
/** Action générique affichée en icône dans la cellule d'action de chaque ligne. */
export type TGrilleActionLigne = {
  /** Identifiant de l'action (clé de rendu). */
  name: string;
  /** Icône rendue (sa couleur suit `couleur`, currentColor). */
  icone: ReactNode;
  /** Infobulle au survol. */
  titre?: string;
  /** Infobulle quand l'action est désactivée pour la ligne (défaut : titre). */
  titreDesactive?: string;
  /** Couleur de l'icône (défaut : colorBase.colorBase02 ; danger = colorBase03). */
  couleur?: string;
  /** Désactive l'action pour la ligne (icône estompée, clic ignoré). */
  desactivee?: (row: ObjetGenerique) => boolean;
  onClick: (e: { rowIndex: number; row: ObjetGenerique }) => void;
};
export type TGrilleCell = {
  row: ObjetGenerique;
  col: string;
  colIndex: number;
  rowIndex: number;
  typ: TColonne;
  editMode: boolean;
};
export type TGrilleRow = {
  Fields: TColonneCollection;
  indRow: number;
  readOnly: boolean;
  onclick: (e: TGrilleEventClick) => void;
  action: TGrilleAction;
  actionsLigne?: TGrilleActionLigne[];
  row: ObjetGenerique;
  showBorder: boolean;
  ondelete?: (e: { rowIndex: number; row: ObjetGenerique }) => void;
  /** Ligne active de la navigation clavier du zoom (mise en surbrillance). */
  active?: boolean;
};
