import {
  TextField,
  TextFieldProps,
  useTheme,
} from "@mui/material";
import { useEffect, useState } from "react";
import useAxiosPost from "../../hooks/useAxiosPost";
import { TInputType, styleLabel, styleLabelError, TFindLibelle } from "../../types";
import { formatsUsuels } from "../../modules/module_formats";
import { colorBase } from "../../modules/module_general";

function TextBox({
  nomControle,
  label,
  valeur = "",
  type = "text",
  readonly = false,
  onchange = () => { },
  style,
  findlibelle,
  ...props
}: TextFieldProps & {
  nomControle: string;
  label: string;
  valeur?: string | number;
  type?: TInputType;
  readonly?: boolean;
  findlibelle?: TFindLibelle;
  onchange?: (v: string, x: any) => void;
} & Omit<TextFieldProps, "variant" | "onChange">) {
  const [estErreur, setEstErreur] = useState(false);
  const [libelleText, setLibelleText] = useState("");
  const myAxios = useAxiosPost();
  const theme = useTheme();

  useEffect(() => {
    setEstErreur(
      Boolean(valeur) &&
      Object.keys(formatsUsuels).includes(type) &&
      !new RegExp(formatsUsuels[type]).test(String(valeur))
    );
  }, [valeur]);

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
    <TextField
      error={estErreur}
      className="textZoom"
      id={nomControle}
      label={label}
      value={findlibelle ? libelleText : (valeur ?? "")}
      helperText={findlibelle ? valeur : ""}
      variant="standard"
      type={type}
      style={{
        ...style,
      }}
      sx={{
        "& .MuiInputBase-input": {
          textAlign:
            type === "number" || type === "integer" ? "right" : "left",
          fontSize: { xs: "1rem", sm: "1rem" },
          colorScheme: theme.palette.mode,
        },
        "& .MuiInputLabel-root": {
          fontSize: { xs: "1rem", sm: "1rem" },
        },
        "& .MuiInput-underline:after": {
          borderBottomColor: colorBase.colorBase02,
        },
      }}
      FormHelperTextProps={{
        style: { fontSize: "0.9rem" },
      }}
      InputLabelProps={{
        style: estErreur ? styleLabelError : styleLabel,
      }}
      InputProps={{
        readOnly: readonly || !!findlibelle,
      }}
      onChange={(e) => {
        onchange(nomControle, e.currentTarget.value);
      }}
      {...props}
    />
  );
}

export default TextBox;
