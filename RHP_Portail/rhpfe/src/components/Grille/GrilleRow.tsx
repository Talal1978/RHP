import { DeleteOutline } from "@mui/icons-material";
import { TableCell, TableRow } from "@mui/material";
import { memo, useContext, useEffect, useRef } from "react";
import { colorBase } from "../../modules/module_general";
import { TGrilleRow, cntx } from "./Grille";
import GrilleCell from "./GrilleCell";

const GrilleRow = ({
  Fields,
  indRow,
  readOnly,
  onclick,
  action,
  actionsLigne = [],
  row,
  showBorder,
  ondelete,
  active = false,
}: TGrilleRow) => {
  const { isFiltred } = useContext(cntx);
  const ligneRef = useRef<HTMLTableRowElement>(null);
  // Navigation clavier du zoom : la ligne active reste visible à l'écran.
  useEffect(() => {
    if (active) ligneRef.current?.scrollIntoView({ block: "nearest" });
  }, [active]);
  const setBorder = showBorder
    ? { border: `0.5px groove #e9f4f7 !important` }
    : {};
  // Cellule d'actions : l'action historique (rowIndex) est masquée sous
  // filtrage ; les actionsLigne (pilotées par la ligne) restent affichées.
  const nbActions = (action !== "" ? 1 : 0) + (actionsLigne?.length ?? 0);
  const afficherCellule =
    (action !== "" && !isFiltred) || (actionsLigne?.length ?? 0) > 0;
  const largeurCelluleAction =
    nbActions > 1 ? `${nbActions * 1.5}em !important` : "1em !important";
  return (
    <TableRow
      key={indRow}
      ref={ligneRef}
      sx={{
        "&:last-child td, &:last-child th": { border: 0 },
        fontSize: { xs: "0.90rem", sm: "1rem" },
      }}
      className={`ligne ${indRow % 2 === 0 ? "pair" : "impair"} ${
        active ? "ligneActive" : ""
      } ${readOnly ? " unselectable " : ""}`}
    >
      {afficherCellule && (
        <TableCell
          className={`td cl_1 rw${indRow}`}
          key={`R${indRow}C_1`}
          sx={{
            ...setBorder,
            maxWidth: largeurCelluleAction,
            width: largeurCelluleAction,
            whiteSpace: "nowrap",
            padding: "unset",
            textAlign: "center",
          }}
        >
          {action === "supprimer" && !isFiltred && (
            <DeleteOutline
              onClick={(e) => {
                ondelete &&
                  ondelete({
                    rowIndex: indRow,
                    row,
                  });
              }}
              sx={{ color: colorBase.colorBase03, cursor: "pointer" }}
            />
          )}
          {actionsLigne?.map((a) => {
            const des = a.desactivee?.(row) ?? false;
            return (
              <span
                key={a.name}
                title={des ? a.titreDesactive ?? a.titre : a.titre}
                onClick={(e) => {
                  e.stopPropagation();
                  if (!des) a.onClick({ rowIndex: indRow, row });
                }}
                style={{
                  display: "inline-flex",
                  verticalAlign: "middle",
                  marginInline: "1px",
                  cursor: des ? "default" : "pointer",
                  opacity: des ? 0.3 : 1,
                  color: a.couleur ?? colorBase.colorBase02,
                }}
              >
                {a.icone}
              </span>
            );
          })}
        </TableCell>
      )}
      {Object.entries(Fields).map(([col, typ], colInd) => {
        return (
          typ.visible && (
            <TableCell
              key={`R${indRow}C${colInd}`}
              id={`R${indRow}C${colInd}`}
              sx={{
                fontSize: "inherit",
                ...typ.sx,
                ...setBorder,
              }}
              className={`cl${colInd} rw${indRow} ${Fields[col].readOnly || readOnly ? " unselectable " : ""
                }`}
              onClick={(e) =>
                onclick({
                  colListe: Object.keys(Fields),
                  colIndex: colInd,
                  rowIndex: indRow,
                  colName: col,
                  colType: typ,
                  value: row[col],
                  row,
                })
              }
            >
              <GrilleCell
                typ={typ}
                row={row}
                col={col}
                editMode={!readOnly}
                colIndex={colInd}
                rowIndex={indRow}
              />
            </TableCell>
          )
        );
      })}
    </TableRow>
  );
};

export default memo(GrilleRow);
