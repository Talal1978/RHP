import { useRef } from "react";
import { DesktopDatePicker, DesktopDateTimePicker } from "@mui/x-date-pickers";
import {
  estDate,
  formatDateFR,
} from "../../modules/module_formats";
import { parse } from "date-fns";
import { colorBase } from "../../modules/module_general";
import "./calendarZoom.scss";
import { styleLabel } from "../../types";
import { SxProps } from "@mui/material";

function parseValue(v: any, showTime: boolean = false): Date | null {
  if (v instanceof Date) return v;
  if (estDate(v))
    return parse(
      formatDateFR(v, showTime),
      showTime ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy",
      new Date()
    );
  // Chaînes ISO date seule "yyyy-MM-dd" (parsing local pour éviter le décalage de fuseau horaire)
  if (typeof v === "string") {
    const m = /^(\d{4})-(\d{2})-(\d{2})$/.exec(v.trim());
    if (m) return new Date(+m[1], +m[2] - 1, +m[3]);
    // Chaînes ISO avec heure sans fuseau "yyyy-MM-ddTHH:mm(:ss)?"
    if (showTime) {
      const mh = /^(\d{4})-(\d{2})-(\d{2})[T ](\d{2}):(\d{2})/.exec(v.trim());
      if (mh) return new Date(+mh[1], +mh[2] - 1, +mh[3], +mh[4], +mh[5]);
    }
  }
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
  showTime = false,
}: {
  onClear?: any;
  nomControle: string;
  label: string;
  valeur?: string | Date;
  onchange?: any;
  readOnly?: boolean;
  sx?: SxProps;
  showTime?: boolean;
}) => {
  const lastEmitted = useRef<number | null>(null);

  const parsedValue = parseValue(valeur, showTime);
  // showTime : sélecteur date + heure (format jj/mm/aaaa hh:mm, 24h)
  const Picker = (showTime ? DesktopDateTimePicker : DesktopDatePicker) as React.ComponentType<any>;
  const minW = showTime ? "175px" : "140px";

  return (
    <Picker
      className={`calendarZoom ${readOnly ? "inactif" : "actif"}`}
      sx={[
        { minWidth: { xs: "120px", sm: minW } },
        ...(Array.isArray(sx) ? sx : [sx]),
        // Plancher non écrasable : la date jj/mm/aaaa doit rester entièrement visible
        { minWidth: { xs: "120px", sm: minW } },
      ]}
      readOnly={readOnly}
      label={label}
      format={showTime ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy"}
      ampm={showTime ? false : undefined}
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
      onChange={(e: any) => {
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
