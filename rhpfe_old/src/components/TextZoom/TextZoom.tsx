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
  valeur = "",
  onchange = () => { },
  style,
}: TextFieldProps & {
  readonly?: boolean;
  numZoom: string;
  nomControle: string;
  label: string;
  findlibelle?: TFindLibelle;
  valeur?: string;
  onchange?: (v: string, x: any) => void;
} & Omit<TextFieldProps, "variant" | "onChange">) => {
  const [showZoom, setShowZoom] = useState(false);
  const [libelleText, setLibelleText] = useState("");
  const myAxios = useAxiosPost();
  useEffect(() => {
    if (!findlibelle) return;
    myAxios("findlibelle", { ...findlibelle, valeur: valeur })
      .then((dt) => {
        setLibelleText(dt.data);
      })
      .catch((err) => {

        setLibelleText("");
      });
  }, [valeur]);
  return (
    <div
      style={{
        display: "flex",
        position: "relative",
        ...style,
      }}
      className="textZoomContainer"
    >
      <TextField
        className="textZoom"
        style={{ flexGrow: 1 }}
        sx={{
          "& .MuiInputBase-input": {
            fontSize: { xs: "1rem", sm: "1rem" },
            ...style
          },
          "& .MuiInputLabel-root": {
            fontSize: { xs: "1rem", sm: "1rem" },
          },
        }}
        id={nomControle}
        label={label}
        value={findlibelle ? libelleText : valeur}
        helperText={findlibelle ? valeur : ""}
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
          onClick={() => {
            setShowZoom((zm) => !zm);
          }}
        >
          <DragIndicatorOutlined style={{ color: "#ffffff" }} />
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
