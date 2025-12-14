import React, { useEffect, useMemo, useState, useRef } from "react";
import { Box, Typography, Select, MenuItem, SelectChangeEvent, SxProps } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { colorBase } from "../../../modules/module_general";
import TextBox from "../../../components/TextBox/TextBox";
import CalendarZoom from "../../../components/Calendar/CalendarZoom";
import { TNoteResult, TQuestionType } from "../Types";
import { safeArrondi, safeNumber } from "../Survey_Functions";

interface TProps {
  sx?: SxProps;
  numQuestion: number;
  laquestion: string;
  Typ_Reponse: TQuestionType;
  Obligatoire: boolean;
  avecNote: boolean;
  colonnes: string;
  funcScoring: string;
  valeurInitiale?: any;
  note: TNoteResult | null;
  handleNoteManuelle?: (numQuestion: number, note: TNoteResult) => void;
  onValueChange?: (value: any) => void;
  onRecalculateParent?: () => void;
}

const UdValeurUnique = ({
  sx = {},
  numQuestion,
  laquestion,
  Typ_Reponse,
  Obligatoire,
  avecNote,
  note,
  handleNoteManuelle,
  colonnes,
  valeurInitiale,
  onValueChange,
}: TProps) => {
  const [inputValue, setInputValue] = useState(valeurInitiale ?? "");
  // CORRECTION: useRef pour éviter la boucle infinie
  const onValueChangeRef = useRef(onValueChange);
  useEffect(() => {
    onValueChangeRef.current = onValueChange;
  }, [onValueChange]);

  useEffect(() => {
    if (onValueChangeRef.current) {
      onValueChangeRef.current(inputValue);
    }
  }, [inputValue]);

  const handleValueChange = (value: any) => setInputValue(value);
  const handleDateChange = (name: string, date: Date | null) => setInputValue(date);
  const handleManualNoteChange = (value: any) => {
    if (!note?.note_manuelle) return;
    const newNote = safeNumber(value, 0);
    const safeMaxScore = safeNumber(note?.max_score, 100000000);
    handleNoteManuelle && handleNoteManuelle(numQuestion, { ...note, note: Math.min(newNote, safeMaxScore), coef: (note?.coef || 1), note_totale: Math.min(newNote, safeMaxScore) * (note?.coef || 1), max_score: safeMaxScore });
  };

  const InputComponent = useMemo(() => {
    const commonSx = {
      "& .MuiInputBase-input": { backgroundColor: 'var(--bg-input) !important', padding: '5px 10px', color: 'var(--fore-color-base-01) !important' },
      "& .MuiSelect-select": { backgroundColor: 'var(--bg-input) !important', color: 'var(--fore-color-base-01) !important' }
    };
    const numericSx = {
      ...commonSx,
      "& .MuiInputBase-input": {
        backgroundColor: 'var(--bg-input) !important',
        padding: '5px 10px',
        textAlign: 'right',
        color: 'var(--fore-color-base-01) !important'
      }
    };
    switch (Typ_Reponse) {
      case "numerique":
      case "entier":
        return (
          <TextBox
            valeur={inputValue}
            onchange={(n, v) => handleValueChange(v)}
            style={{ width: `${Math.min(Math.max(3, inputValue.length + 4), 32)}ch`, minWidth: "100px" }}
            sx={numericSx}
            label=""
            type={Typ_Reponse === "numerique" ? "number" : "integer"}
            nomControle={`reponse_${Typ_Reponse}`}
          />
        );
      case "alpha":
        return <TextBox valeur={inputValue} onchange={(n, v) => handleValueChange(v)} style={{ width: "100%" }} sx={commonSx} label="" type="text" nomControle="reponse_alpha" />;
      case "multiLine":
        return <TextBox valeur={inputValue} onchange={(n, v) => handleValueChange(v)} label="" type="text" style={{ width: "100%" }} sx={commonSx} nomControle="reponse_multiline" multiline={true} rows={4} />;
      case "date":
      case "dateTime":
      case "heure":
        return (
          <CalendarZoom
            nomControle="reponse_date"
            label=""
            valeur={inputValue}
            onchange={handleDateChange}
            onClear={() => handleDateChange("reponse_date", null)}
            sx={{
              width: "100%",
              maxWidth: "180px",
              "& .MuiFormControl-root": { width: "100%" },
              "& input": { fontSize: "1em", textAlign: "center", backgroundColor: 'var(--bg-input) !important', color: 'var(--fore-color-base-01) !important' },
            }}
          />
        );
      case "liste":
        const options = colonnes.split(";").filter((c) => c.trim() !== "");
        return (
          <Select
            value={inputValue ?? ''}
            onChange={(e: SelectChangeEvent) => handleValueChange(e.target.value)}
            variant="standard"
            displayEmpty
            sx={{ ...commonSx, width: "100%", borderBottom: `1px solid gray`, backgroundColor: 'var(--bg-input) !important' }}
          >
            <MenuItem value="" disabled><em>Sélectionnez...</em></MenuItem>
            {options.map((option, index) => (
              <MenuItem key={index} value={option.trim()}>{option.trim()}</MenuItem>
            ))}
          </Select>
        );
      default:
        return <TextBox valeur={inputValue} onchange={(n, v) => handleValueChange(v)} style={{ width: "100%" }} sx={commonSx} label="" type="text" nomControle="reponse_defaut" />;
    }
  }, [Typ_Reponse, inputValue, colonnes]);

  return (
    <Box
      className="ud-valeur-unique"
      sx={{
        ...sx,
        backgroundColor: "var(--bg-input)",
        color: "var(--fore-color-base-01)",
        display: "grid",
        gridTemplateColumns: {
          xs: "1fr",
          sm: avecNote ? "53px 1fr 200px" : "53px 1fr"
        },
        gap: 0,
        width: "100%",
        fontSize: "1em",
        border: '1px solid #e0e0e0',
        marginBottom: '10px'
      }}
    >
      <Box sx={{
        gridColumn: { xs: "1 / -1", sm: 1 },
        bgcolor: colorBase.colorBase01,
        display: "flex", justifyContent: "center", alignItems: "center",
        paddingRight: { xs: 0, sm: "2px" },
        minHeight: { xs: "2em", sm: "auto" }
      }}>
        <Box sx={{ bgcolor: { xs: colorBase.colorBase01, sm: "var(--bg-input)" }, color: { xs: "white", sm: colorBase.colorBase01 }, width: "100%", height: "100%", display: "flex", justifyContent: "center", alignItems: "center", fontWeight: "bold", fontSize: "1.2em" }}>
          {numQuestion}
        </Box>
      </Box>

      <Box sx={{
        gridColumn: { xs: "1 / -1", sm: 2 },
        display: 'flex',
        flexDirection: (Typ_Reponse === 'multiLine' || Typ_Reponse === 'alpha') ? 'column' : { xs: 'column', md: 'row' },
        alignItems: (Typ_Reponse === 'multiLine' || Typ_Reponse === 'alpha') ? 'stretch' : { xs: 'stretch', md: 'center' },
        justifyContent: 'space-between',
        padding: "10px 15px",
        gap: "10px"
      }}>
        <Typography sx={{ color: colorBase.colorBase01, marginRight: '10px', fontWeight: 500 }}>
          {laquestion} {Obligatoire && <span style={{ color: "red" }}>(*)</span>}
        </Typography>

        <Box sx={{
          flexGrow: 1,
          width: "100%",
          display: 'flex',
          justifyContent: (Typ_Reponse === 'numerique' || Typ_Reponse === 'entier' || Typ_Reponse === 'date') ? 'flex-end' : 'flex-start',
          maxWidth: (Typ_Reponse === 'multiLine' || Typ_Reponse === 'alpha') ? "100%" : { xs: "100%", md: "50%" }
        }}>
          {InputComponent}
        </Box>
      </Box>

      {avecNote && (
        <Box sx={{
          gridColumn: { xs: "1 / -1", sm: 3 },
          width: "100%",
          borderLeft: { sm: '1px solid #e0e0e0' },
          padding: "5px",
          backgroundColor: 'var(--chip-bg)',
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center'
        }}>
          {(note) && (
            <>
              <NoteField label="Note" value={note?.note} readonly={!note?.note_manuelle} onChange={handleManualNoteChange} />
              <NoteField label="Coef." value={note?.coef} readonly={true} />
              <NoteField label="Total" value={note?.note_totale} readonly={true} />
            </>
          )}
        </Box>
      )}
    </Box>
  );
};

export default UdValeurUnique;

const NoteField = ({ label, value, readonly, onChange = () => { } }: any) => {
  const safeValue = safeArrondi(value, 2);
  return (
    <Grid container spacing={1} alignItems="center">
      <Grid xs={6}><Typography sx={{ color: colorBase.colorBase01, fontSize: "0.8em" }}>{label}</Typography></Grid>
      <Grid xs={6}>
        <TextBox
          nomControle="nt"
          label=""
          type="number"
          valeur={safeValue}
          readonly={readonly}
          onchange={(n, v) => onChange(v)}
          style={{ width: "100%" }}
          sx={{ "& .MuiInputBase-input": { textAlign: "center", fontWeight: "bold", fontSize: "1em", padding: "0", backgroundColor: readonly ? 'var(--chip-bg)' : "var(--bg-input)", color: "var(--fore-color-base-01)" } }}
        />
      </Grid>
    </Grid>
  );
};