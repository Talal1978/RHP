import {
  TextField,
  TextFieldProps,
  ThemeProvider,
  createTheme,
} from "@mui/material";
import { useEffect, useState } from "react";
import { TInputType, styleLabel, styleLabelError } from "../../types";
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
  ...props
}: TextFieldProps & {
  nomControle: string;
  label: string;
  valeur?: string | number;
  type?: TInputType;
  readonly?: boolean;
  onchange?: (v: string, x: any) => void;
} & Omit<TextFieldProps, "variant" | "onChange">) {
  const [estErreur, setEstErreur] = useState(false);
  useEffect(() => {
    setEstErreur(
      Boolean(valeur) &&
      Object.keys(formatsUsuels).includes(type) &&
      !new RegExp(formatsUsuels[type]).test(String(valeur))
    );
  }, [valeur]);
  return (
    <ThemeProvider theme={theme}>
      <TextField
        error={estErreur}
        className="textZoom"
        id={nomControle}
        label={label}
        value={valeur}
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
          },
          "& .MuiInputLabel-root": {
            fontSize: { xs: "1rem", sm: "1rem" },
          },
        }}
        FormHelperTextProps={{
          style: { fontSize: "0.9rem" },
        }}
        InputLabelProps={{
          style: estErreur ? styleLabelError : styleLabel,
        }}
        InputProps={{
          readOnly: readonly,
        }}
        onChange={(e) => {
          onchange(nomControle, e.currentTarget.value);
        }}
        {...props}
      />
    </ThemeProvider>
  );
}

export default TextBox;
const theme = createTheme({
  components: {
    MuiOutlinedInput: {
      // For outlined variant
      styleOverrides: {
        notchedOutline: {
          "&:focus": {
            borderColor: colorBase.colorBase02,
          },
        },
      },
    },
    MuiInput: {
      // For standard variant
      styleOverrides: {
        underline: {
          "&:after": {
            borderBottomColor: colorBase.colorBase02,
          },
        },
      },
    },
  },
});
