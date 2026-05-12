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
import { createContext, useEffect, useState, useMemo } from "react";
import GrilleHeaderCell from "./GrilleHeaderCell";
import GrilleRow from "./GrilleRow";
import useAxiosPost from "../../hooks/useAxiosPost";
import { estDate } from "../../modules/module_formats";
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
  showBorder = true,
  onclick = () => {},
  onchange = () => {},
  ondelete = () => {},
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
  useDeepCompareEffect(() => {
    if (dataSource.length === 0 && numZoom !== "") {
      myAxios("zoom", { numZoom })
        .then((dt) => {
          if (dt.data) {
            if (dt.data.result) {
              const obj: { [key: string]: any }[] = [...dt.data.data];
              setFiltredData(obj.slice(0, 20));
              setInnerDataSource(obj);
              setFields(dt.data.fields);
            }
          }
        })
        .catch((err) => console.error(err));
    } else {
      setFiltredData(dataSource.slice(0, 20));
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
  }, [numZoom, dataSource, Colonnes]);
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
    }),
    [filtre, innerDataSource, isFiltred]
  );
  return (
    <cntx.Provider value={contextValue}>
      <TableContainer
        component={Paper}
        className={`${className} grilleContainer`}
        sx={{ ...sx, fontSize: { xs: "0.9em", sm: "0.95em", md: "1em" } }}
      >
        <Table stickyHeader aria-label="sticky table" className="grille">
          <TableHead className="th">
            <TableRow className="tr">
              {action && (
                <TableCell
                  className={`td cl_1 rw_1`}
                  key="cl_1"
                  sx={{
                    maxWidth: "1em !important",
                    width: "1em !important",
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
                        headerText={Fields?.[cl]?.headerText || cl}
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
                  Fields={Fields}
                  onclick={onclick}
                  ondelete={ondelete}
                  key={indRow}
                  readOnly={readOnlyRows.includes(indRow) || readonly}
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
  sx?: {};
  readOnlyRows?: number[];
  colonnesAFiltrer?: number[];
  dataSource?: any[];
  Colonnes?: TColonneCollection;
  readonly?: boolean;
  className?: string;
  action?: TGrilleAction;
  showBorder?: boolean;
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
  row: ObjetGenerique;
  showBorder: boolean;
  ondelete?: (e: { rowIndex: number; row: ObjetGenerique }) => void;
};
