import { FilterListOutlined } from "@mui/icons-material";
import { useContext, useEffect, useRef } from "react";
import { cntx } from "./Grille";
import { cDate, estDate, estNumeric } from "../../modules/module_formats";

const GrilleHeaderCell = ({
  headerText,
  colName,
}: {
  headerText: string;
  colName: string;
}) => {
  const { filtre, setFiltre, rechercheZoom, colRecherche, setColRecherche } =
    useContext(cntx);

  const filtreRef = useRef<HTMLInputElement>(null);
  // Le filtrage des lignes (filtres par colonne + recherche clavier du zoom)
  // est centralisé dans Grille.tsx.
  const showFilterText = (show: boolean) => {
    setFiltre((prv: any) => {
      return {
        ...prv,
        [colName]: {
          ...prv[colName],
          visible: show,
        },
      };
    });
  };
  useEffect(() => {
    if (!filtre) return;
    if (filtre[colName]?.visible) {
      filtreRef.current?.select();
    }
  }, [filtre ? !filtre[colName]?.visible : true, colName]);
  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <input
        ref={filtreRef}
        className="filterText"
        hidden={filtre ? !filtre[colName]?.visible : true}
        type="text"
        onKeyDown={(e) => {
          if (e.key === "Enter") showFilterText(false);
        }}
        onBlur={(e) => {
          showFilterText(false);
        }}
        onChange={(e) => {
          setFiltre((prv: any) => {
            return {
              ...prv,
              [colName]: {
                ...prv[colName],
                expression: e.target.value || "",
              },
            };
          });
        }}
      />
      <span
        className={
          rechercheZoom
            ? `libelleEntete ${
                colRecherche === colName ? "colRechercheActive" : ""
              }`
            : undefined
        }
        title={rechercheZoom ? "Filtrer sur cette colonne" : undefined}
        onClick={
          rechercheZoom && setColRecherche
            ? () => setColRecherche(colName)
            : undefined
        }
        style={{
          marginRight:
            filtre && Object.keys(filtre).includes(colName) ? "3.5em" : "inset",
        }}
      >
        {headerText}
      </span>
      {filtre && Object.keys(filtre).includes(colName) && (
        <FilterListOutlined
          className={`filterIcon ${
            filtre ? (filtre[colName]?.expression ? "filtreActif" : "") : ""
          }`}
          onClick={() => {
            showFilterText(filtre ? !filtre[colName]?.visible : false);
          }}
        />
      )}
    </div>
  );
};

export function filterEngine(datatype: string, value1: any, value2: string): boolean {
  value2 = value2.trim().toLowerCase();
  if (value2 === "") return true;
  let operande: string = "";
  const grp = /^(?<operande>(>=|<=|=|<|>|<>|!=))/.exec(value2)?.groups;
  if (grp && grp.operande) {
    operande = grp.operande;
    value2 = value2.replace(grp.operande, "").trim();
  }
  switch (operande) {
    case "<=":
      if (datatype === "date" && estDate(value1) && estDate(value2)) {
        return cDate(String(value1)) <= cDate(value2);
      }
      if (datatype === "number" && estNumeric(value1) && estNumeric(value2)) {
        return parseFloat(value1) <= parseFloat(value2);
      }
      return false;
    case "<":
      if (datatype === "date" && estDate(value1) && estDate(value2)) {
        return cDate(String(value1)) < cDate(value2);
      }
      if (datatype === "number" && estNumeric(value1) && estNumeric(value2)) {
        return parseFloat(value1) < parseFloat(value2);
      }
      return false;
    case ">=":
      if (datatype === "date" && estDate(value1) && estDate(value2)) {
        return cDate(String(value1)) >= cDate(value2);
      }
      if (datatype === "number" && estNumeric(value1) && estNumeric(value2)) {
        return parseFloat(value1) >= parseFloat(value2);
      }
      return false;
    case ">":
      if (datatype === "date" && estDate(value1) && estDate(value2)) {
        return cDate(String(value1)) > cDate(value2);
      }
      if (datatype === "number" && estNumeric(value1) && estNumeric(value2)) {
        return parseFloat(value1) > parseFloat(value2);
      }
      return false;
    case "!=":
    case "<>":
    case "!==":
      if (datatype === "date" && estDate(value1) && estDate(value2)) {
        return cDate(String(value1)) !== cDate(value2);
      }
      if (datatype === "number" && estNumeric(value1) && estNumeric(value2)) {
        return parseFloat(value1) !== parseFloat(value2);
      }
      if (datatype === "boolean") {
        return (
          Boolean(value1) !==
          (value2 === "1" || value2 === "true" || value2 === "vrai")
        );
      }
      if (datatype === "any") {
        return value1.toLowerCase().trim() !== value2.toLowerCase().trim();
      }
      return false;
    default:
      if (datatype === "date" && estDate(value1) && estDate(value2)) {
        return cDate(String(value1)) === cDate(value2);
      }
      if (datatype === "number" && estNumeric(value1) && estNumeric(value2)) {
        return parseFloat(value1) === parseFloat(value2);
      }
      if (datatype === "boolean") {
        return (
          Boolean(value1) ===
          (value2 === "1" || value2 === "true" || value2 === "vrai")
        );
      }
      if (value2.endsWith("*") && value2.startsWith("*")) {
        value2 = value2.replace(/\*/g, "").trim().toLowerCase();
        return String(value1).toLowerCase().trim().includes(value2);
      }
      if (value2.trim().endsWith("*")) {
        return String(value1)
          .toLowerCase()
          .trim()
          .startsWith(value2.replace("*", "").toLowerCase().trim());
      }
      if (value2.trim().startsWith("*")) {
        return String(value1)
          .toLowerCase()
          .trim()
          .endsWith(value2.replace("*", "").toLowerCase().trim());
      } else {
        return String(value1)
          .toLowerCase()
          .trim()
          .includes(value2.toLowerCase().trim());
      }
  }
}
export default GrilleHeaderCell;
