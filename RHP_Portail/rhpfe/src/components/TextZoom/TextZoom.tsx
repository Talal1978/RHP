import {
  TextField,
  TextFieldProps,
  Typography,
} from "@mui/material";
import {
  DragIndicatorOutlined,
  DeleteOutlineOutlined,
  Close,
} from "@mui/icons-material";
import { useEffect, useState } from "react";
import Grille from "../Grille/Grille";
import "./textZoom.scss";
import useAxiosPost from "../../hooks/useAxiosPost";
import { TFindLibelle, styleLabel } from "../../types";
import { colorBase } from "../../modules/module_general";

const TextZoom = ({
  readonly = false,
  numZoom,
  nomControle,
  label,
  findlibelle,
  libelleZoom = false,
  valeur = "",
  onchange = () => { },
  style,
}: TextFieldProps & {
  readonly?: boolean;
  numZoom: string;
  nomControle: string;
  label: string;
  findlibelle?: TFindLibelle;
  /** Affiche le libellé (2e colonne de la déclaration du zoom dans
   *  Controle_Def_Zoom) à la place du code, résolu via l'API zoomlibelle. */
  libelleZoom?: boolean;
  valeur?: string;
  onchange?: (v: string, x: any) => void;
} & Omit<TextFieldProps, "variant" | "onChange">) => {
  const [showZoom, setShowZoom] = useState(false);
  const [libelleText, setLibelleText] = useState("");
  const myAxios = useAxiosPost();
  const avecLibelle = Boolean(findlibelle) || libelleZoom;
  useEffect(() => {
    if (!avecLibelle) return;
    if (valeur === "") {
      setLibelleText("");
      return;
    }
    const req = findlibelle
      ? myAxios("findlibelle", { ...findlibelle, valeur: valeur })
      : myAxios("zoomlibelle", { numZoom, valeur: valeur });
    req
      .then((dt) => {
        setLibelleText(dt.data);
      })
      .catch((err) => {

        setLibelleText("");
      });
  }, [valeur, numZoom]);
  return (
    <div
      style={{
        display: "flex",
        position: "relative",
        minWidth: 0,
        overflow: "hidden",
        ...style,
      }}
      className="textZoomContainer"
    >
      <TextField
        className="textZoom"
        style={{ flex: 1, minWidth: 0 }}
        sx={{
          "& .MuiInputBase-input": {
            fontSize: { xs: "1rem", sm: "1rem" },
            whiteSpace: "nowrap",
            overflow: "hidden",
            textOverflow: "ellipsis",
            ...style
          },
          "& .MuiInputLabel-root": {
            fontSize: { xs: "1rem", sm: "1rem" },
          },
        }}
        id={nomControle}
        label={label}
        value={avecLibelle ? libelleText : valeur}
        helperText={avecLibelle ? valeur : ""}
        variant="standard"
        FormHelperTextProps={{
          style: { fontSize: "0.9rem" },
        }}
        InputLabelProps={{
          style: styleLabel,
        }}
        InputProps={{
          readOnly: true,
        }}
        onChange={(e) => { }}
      />
      {!readonly && (
        <div
          className="zoomIcon"
          style={{ position: "absolute", right: "4px", top: "50%", transform: "translateY(-50%)" }}
          onClick={() => {
            setShowZoom((zm) => !zm);
          }}
        >
          <DragIndicatorOutlined style={{ color: colorBase.colorBase01 }} />
        </div>
      )}
      <div hidden={!showZoom} className="overlay"></div>
      <div className={`zoomMenu ${showZoom ? "afficherZoom" : "masquerZoom"}`}>
        {showZoom && (
          <>
            <div className="barZoom">
              <Close
                className="barZoomItem"
                onClick={() => {
                  setShowZoom(false);
                }}
              />
              <DeleteOutlineOutlined
                className="barZoomItem"
                onClick={() => {
                  onchange(nomControle, "");
                  setLibelleText("");
                  setShowZoom(false);
                }}
              />
              <Typography className="barZoomNum">{numZoom}</Typography>
            </div>

            <Grille
              numZoom={numZoom}
              readonly={true}
              sx={{ "& .cl0": { cursor: "pointer !important" } }}
              onclick={({ row, colListe }) => {
                onchange(
                  nomControle,
                  row ? row[colListe ? colListe[0] : ""] : {}
                );
                setShowZoom(false);
              }}
            />
          </>
        )}
      </div>
    </div>
  );
};
export default TextZoom;
