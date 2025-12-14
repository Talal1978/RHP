import {
  CheckBoxOutlineBlankOutlined,
  CheckBoxOutlined,
} from "@mui/icons-material";
import { TGrilleCell, cntx } from "./Grille";
import { formatDateFR } from "../../modules/module_formats";
import { useContext, useRef } from "react";

const GrilleCell = ({
  row,
  col,
  rowIndex,
  typ,
  editMode = true,
}: TGrilleCell) => {
  const myInput = useRef<HTMLInputElement>(null);
  const handleKeyDown = (e: React.KeyboardEvent) => {
    if (e.key === "Enter") {
      myInput?.current?.blur();
    } else if (
      !/[0-9,]/.test(myInput.current?.value || "0") &&
      typ?.dataType === "float"
    ) {
      e.preventDefault();
    } else if (
      !/[0-9]/.test(myInput.current?.value || "0") &&
      typ?.dataType === "int"
    ) {
      e.preventDefault();
    }
  };
  const { onchange } = useContext(cntx);
  const align =
    typ?.dataType === "float" || typ?.dataType === "int"
      ? "right"
      : typ?.dataType === "smalldatetime" ||
        typ?.dataType === "datetime" ||
        typ?.dataType === "bit"
        ? "center"
        : "left";
  const composant = () => {
    if (typ?.typeColonne === "Image") {
      return <img src={row[col]} alt={row[col]} />;
    } else if (typ?.dataType === "bit") {
      return row[col] ? <CheckBoxOutlined /> : <CheckBoxOutlineBlankOutlined />;
    } else if (typ?.dataType?.includes("date")) {
      if (editMode && !typ.readOnly) {
        return (
          <input
            type="date"
            ref={myInput}
            onKeyDown={handleKeyDown}
            onChange={(e) => {
              if (myInput.current) myInput.current.value = e.target.value;
              onchange &&
                onchange({
                  rowIndex: rowIndex,
                  columnName: typ?.columnName,
                  valeur: e.target.value,
                });
            }}
            value={formatDateFR(row[col])}
            placeholder="dd/mm/yy"
            style={{
              width: "100%",
              border: "0",
              padding: "2px",
              fontSize: "inherit",
              textAlign: align,
            }}
          />
        );
      } else {
        return (
          <div style={{ width: "100%", textAlign: align }}>
            {formatDateFR(row[col])}
          </div>
        );
      }
    } else if (typ?.dataType === "int" || typ?.dataType === "float") {
      if (editMode && !typ.readOnly) {
        return (
          <input
            ref={myInput}
            type="number"
            onKeyDown={handleKeyDown}
            onChange={(e) => {
              if (myInput.current) myInput.current.value = e.target.value;
              onchange &&
                onchange({
                  rowIndex: rowIndex,
                  columnName: typ?.columnName,
                  valeur: e.target.value,
                });
            }}
            value={row[col]}
            placeholder="0"
            style={{
              width: "100%",
              border: "0",
              padding: "2px",
              fontSize: "inherit",
              textAlign: align,
            }}
          />
        );
      } else {
        return (
          <div style={{ width: "100%", textAlign: align, fontSize: "inherit" }}>
            {row[col]}
          </div>
        );
      }
    } else if (
      typ?.typeColonne === "Combo" &&
      typ.dataSource
    ) {
      if (editMode && !typ.readOnly) {
        return (
          <select
            value={row[col]}
            onChange={(e) => {
              onchange &&
                onchange({
                  rowIndex: rowIndex,
                  columnName: typ?.columnName,
                  valeur: e.target.value,
                });
            }}
            style={{
              width: "100%",
              border: "0",
              padding: "2px",
              textAlign: "center",
              outline: "0px",
            }}
          >
            {typ.dataSource.map((op, i) => (
              <option value={op.valeur} key={op.valeur}>
                {op.membre}
              </option>
            ))}
          </select>
        );
      } else {
        return (
          <div style={{ width: "100%", textAlign: align }}>
            {typ?.dataSource?.find((x) => x.valeur == row[col])?.membre ?? ""}
          </div>
        );
      }
    } else if (editMode && !typ.readOnly) {
      return (
        <input
          style={{
            width: "100%",
            border: "none",
            fontSize: "inherit",
            padding: "2px",
          }}
          ref={myInput}
          value={row[col]}
          onKeyDown={handleKeyDown}
          onChange={(e) => {
            if (myInput.current) myInput.current.value = e.target.value;
            onchange &&
              onchange({
                rowIndex: rowIndex,
                columnName: typ?.columnName,
                valeur: e.target.value,
              });
          }}
        />
      );
    } else {
      return <div style={{ width: "100%", textAlign: align }}>{row[col]}</div>;
    }
  };
  return <>{composant()}</>;
};

export default GrilleCell;
