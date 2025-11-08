import { DeleteOutline } from "@mui/icons-material";
import { TableCell, TableRow } from "@mui/material";
import { useContext } from "react";
import { colorBase } from "../../modules/module_general";
import { TGrilleRow, cntx } from "./Grille";
import GrilleCell from "./GrilleCell";

const GrilleRow = ({
  Fields,
  indRow,
  readOnly,
  onclick,
  action,
  row,
  showBorder,
  ondelete,
}: TGrilleRow) => {
  const { isFiltred } = useContext(cntx);
  const setBorder = showBorder
    ? { border: `0.5px groove #e9f4f7 !important` }
    : {};
  return (
    <TableRow
      key={indRow}
      sx={{
        "&:last-child td, &:last-child th": { border: 0 },
        fontSize: "medium",
      }}
      className={`ligne ${indRow % 2 === 0 ? "pair" : "impair"} ${
        readOnly ? " unselectable " : ""
      }`}
    >
      {action && !isFiltred && (
        <TableCell
          className={`td cl_1 rw${indRow}`}
          key={`R${indRow}C_1`}
          sx={{
            ...setBorder,
            maxWidth: "1em !important",
            width: "1em !important",
            padding: "unset",
            textAlign: "center",
          }}
        >
          {action === "supprimer" && (
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
              className={`cl${colInd} rw${indRow} ${
                Fields[col].readOnly || readOnly ? " unselectable " : ""
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

export default GrilleRow;
