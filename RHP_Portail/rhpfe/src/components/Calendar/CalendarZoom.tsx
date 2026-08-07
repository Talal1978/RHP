import { useRef } from "react";
import { DesktopDatePicker } from "@mui/x-date-pickers";
import {
  estDate,
  formatDateFR,
} from "../../modules/module_formats";
import { parse } from "date-fns";
import { colorBase } from "../../modules/module_general";
import "./calendarZoom.scss";
import { styleLabel } from "../../types";
import { SxProps } from "@mui/material";

function parseValue(v: any): Date | null {
  if (v instanceof Date) return v;
  if (estDate(v)) return parse(formatDateFR(v), "dd/MM/yyyy", new Date());
  return null;
}

const CalendarZoom = ({
  onClear,
  label,
  valeur = "",
  onchange,
  readOnly = false,
  nomControle,
  sx,
}: {
  onClear?: any;
  nomControle: string;
  label: string;
  valeur?: string | Date;
  onchange?: any;
  readOnly?: boolean;
  sx?: SxProps;
}) => {
  const lastEmitted = useRef<number | null>(null);

  const parsedValue = parseValue(valeur);

  return (
    <DesktopDatePicker
      className={`calendarZoom ${readOnly ? "inactif" : "actif"}`}
      sx={[
        { minWidth: { xs: "120px", sm: "140px" } },
        ...(Array.isArray(sx) ? sx : [sx]),
        // Plancher non écrasable : la date jj/mm/aaaa doit rester entièrement visible
        { minWidth: { xs: "120px", sm: "140px" } },
      ]}
      readOnly={readOnly}
      label={label}
      format="dd/MM/yyyy"
      value={parsedValue}
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
            sx: { fontSize: { xs: "1rem", sm: "1rem" } },
          },
          sx: {
            minWidth: 0,
            width: "100%",
            "& .MuiInputBase-input": {
              fontSize: { xs: "1rem", sm: "1rem" },
            },
          },
        },
        field: {
          clearable: !readOnly,
        },
      }}
      onChange={(e) => {
        if (!onchange || readOnly) return;
        if (estDate(e)) {
          const ts = new Date(e).getTime();
          if (lastEmitted.current === ts) {
            return;
          }
          lastEmitted.current = ts;
          onchange(nomControle, e);
        }
      }}
    />
  );
};

export default CalendarZoom;
