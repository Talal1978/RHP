import { DesktopDatePicker } from "@mui/x-date-pickers";
import {
  estDate,
  formatDateFR,
} from "../../modules/module_formats";
import { parse } from "date-fns";
import { colorBase } from "../../modules/module_general";
import "./calendarZoom.scss";
import { styleLabel } from "../../types";
import { SxProps, ThemeProvider, createTheme } from "@mui/material";
const CalendarZoom = ({
  onClear,
  label,
  valeur = "",
  onchange,
  readOnly = false,
  nomControle,
  sx,
}: {
  onClear: any;
  nomControle: string;
  label: string;
  valeur?: string | Date;
  onchange?: any;
  readOnly?: boolean;
  sx?: SxProps;
}) => {
  return (
    <ThemeProvider theme={theme}>
      <DesktopDatePicker
        className={`calendarZoom ${readOnly ? "inactif" : "actif"}`}
        sx={{ ...sx, minWidth: "160px" }}
        readOnly={readOnly}
        label={label}
        format="dd/MM/yyyy"
        value={
          valeur instanceof Date
            ? valeur
            : estDate(valeur)
            ? parse(formatDateFR(valeur), "dd/MM/yyyy", new Date())
            : valeur
        }
        slotProps={{
          openPickerButton: {
            style: {
              color: `${readOnly ? "gray" : colorBase.colorBase01}`,
              marginRight: 0,
            },
          },
          textField: {
            variant: "standard",
            InputLabelProps: {
              style: styleLabel,
            },
          },

          field: {
            clearable: !readOnly,
          },
        }}
        onChange={(e) => {
          if (Boolean(onchange) && !readOnly)
            if (estDate(e)) {
              const laDate = e.toLocaleDateString("en-US", {
                year: "numeric",
                month: "2-digit",
                day: "2-digit",
              });
              onchange(nomControle, e);
            } else {
              console.log("La date entrée n'est pas valide", e);
            }
        }}
      />
    </ThemeProvider>
  );
};
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
export default CalendarZoom;
