import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  ThemeProvider,
  createTheme,
} from "@mui/material";
import React, { useEffect, useMemo, useRef, useState } from "react";
import { IsNull, colorBase, getRandomKey } from "../../modules/module_general";
import useAxiosPost from "../../hooks/useAxiosPost";
import "./combobox.scss";
import CloseIcon from "@mui/icons-material/Close";
import { ObjetGenerique, styleLabel } from "../../types";
import { listRubriques, rubriques } from "../../modules/module_rubriques";
type TComboBoxProps = {
  style?: React.CSSProperties;
  numZoom?: string;
  conditionZoom?: string;
  rubrique?: string;
  nomControle: string;
  label: string;
  valeur?: string;
  onchange?: any;
  readOnly?: boolean;
};

function ComboBox({
  numZoom,
  conditionZoom,
  nomControle,
  label,
  rubrique,
  valeur = "",
  onchange,
  readOnly = false,
  style,
}: TComboBoxProps) {
  const [dataSource, setDataSource] = useState<ObjetGenerique[]>([]);
  const champs = useMemo(
    () => Object.keys(dataSource?.[0] ?? []),
    [dataSource]
  );
  const myAxios = useAxiosPost();
  useEffect(() => {
    let donnees: ObjetGenerique[] = [];
    if (IsNull(numZoom, "") !== "") {
      myAxios("zoom", { numZoom, conditionZoom })
        .then((dt) => {
          if (dt.data) {
            donnees = [...dt.data.data];
          }
          setDataSource(donnees);
        })
        .catch((err) => {
          setDataSource(donnees);
          console.error(err);
        });
    } else if (rubrique && rubrique !== "") {
      setDataSource(listRubriques(rubrique));
    }
  }, [numZoom, rubrique]);
  return (
    <ThemeProvider theme={theme}>
      <FormControl
        variant="standard"
        className="comboBoxContainer"
        style={style}
      >
        <InputLabel id="demo-simple-select-standard-label" style={styleLabel}>
          {label}
        </InputLabel>
        <Select
          sx={{ fontSize: { xs: "1rem", sm: "1rem" } }}
          className="comboBox"
          labelId="demo-simple-select-standard-label"
          variant="standard"
          id={nomControle}
          value={
            dataSource.find((t) => t[champs?.[0]] === valeur) ? valeur : ""
          }
          onChange={(event) => {
            if (Boolean(onchange)) onchange(nomControle, event.target.value);
          }}
          inputProps={{ readOnly: readOnly }}
          slotProps={{}}
        >
          {champs.length >= 2 &&
            dataSource.map((k, ind) => {
              return (
                <MenuItem key={ind} value={k[champs?.[0]]}>
                  <em>{k[champs?.[1]]}</em>
                </MenuItem>
              );
            })}
        </Select>
        <CloseIcon
          onClick={() => {
            if (!readOnly) onchange(nomControle, "");
          }}
          className="clearIcon"
        />
      </FormControl>
    </ThemeProvider>
  );
}
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
export default ComboBox;
