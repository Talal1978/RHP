import React, { useEffect, useMemo, useState, useRef } from "react";
import { Box, Typography, SxProps, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Radio } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { colorBase } from "../../../modules/module_general";
import TextBox from "../../../components/TextBox/TextBox";
import { Arrondi } from "../../../modules/module_general_formulas";
import { RadioButtonChecked, RadioButtonUnchecked } from "@mui/icons-material";
import { TNoteResult } from "../Types";

const safeNumber = (value: any, defaultValue: number = 0): number => {
  if (value === null || value === undefined) return defaultValue;
  const num = Number(value);
  return isNaN(num) ? defaultValue : num;
};

const safeArrondi = (value: any, decimals: number = 2): number => {
  const safe = safeNumber(value, 0);
  return Arrondi(safe, decimals);
};

interface TProps {
  sx?: SxProps;
  numQuestion: number;
  laquestion: string;
  Obligatoire: boolean;
  avecNote: boolean;
  colonnes: string;
  lignes: string;
  note: TNoteResult | null;
  handleNoteManuelle?: (numQuestion: number, note: TNoteResult) => void;
  valeurInitiale?: number[][] | null;
  onValueChange?: (value: number[][] | null) => void;
}

const UdGrilleCases = ({
  sx = {},
  numQuestion,
  laquestion,
  Obligatoire,
  avecNote,
  note,
  handleNoteManuelle,
  colonnes,
  lignes,
  valeurInitiale,
  onValueChange,
}: TProps) => {
  const options = useMemo(() => colonnes.split(";").filter((c) => c.trim() !== ""), [colonnes]);
  const rowsTexts = useMemo(() => lignes.split(";").filter((l) => l.trim() !== ""), [lignes]);

  const [gridValues, setGridValues] = useState<number[][]>(() => {
    if (valeurInitiale && Array.isArray(valeurInitiale) && valeurInitiale.length === rowsTexts.length) {
      return valeurInitiale;
    }
    return Array(rowsTexts.length).fill(null).map(() =>
      Array(options.length).fill(0)
    );
  });

  const handleManualNoteChange = (value: any) => {
    if (!note?.note_manuelle) return;
    const newNote = safeNumber(value, 0);
    const safeMaxScore = safeNumber(note?.max_score, 100000000);
    handleNoteManuelle && handleNoteManuelle(numQuestion, { note: Math.min(newNote, safeMaxScore), coef: note?.coef || 1, note_totale: Math.min(newNote, safeMaxScore) * (note?.coef || 1), max_score: safeMaxScore });
  };

  // CORRECTION : Utiliser useRef pour éviter de réinclure onValueChange dans les dépendances
  const onValueChangeRef = useRef(onValueChange);
  useEffect(() => {
    onValueChangeRef.current = onValueChange;
  }, [onValueChange]);


  useEffect(() => {
    if (onValueChangeRef.current) {
      onValueChangeRef.current(gridValues);
    }
  }, [gridValues]);


  const handleCellClick = (rowIndex: number, colIndex: number) => {
    setGridValues((prev) => {
      const newGrid = prev.map(row => [...row]);

      if (newGrid[rowIndex][colIndex] === 1) {
        newGrid[rowIndex] = newGrid[rowIndex].map(() => 0);
      } else {
        newGrid[rowIndex] = newGrid[rowIndex].map(() => 0);
        newGrid[rowIndex][colIndex] = 1;
      }

      return newGrid;
    });
  };

  return (
    <Box
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
        border: "1px solid #e0e0e0",
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
        <Box sx={{ bgcolor: "var(--bg-input)", color: colorBase.colorBase01, width: "100%", height: "100%", display: "flex", justifyContent: "center", alignItems: "center", fontWeight: "bold", fontSize: "1.2em" }}>
          {numQuestion}
        </Box>
      </Box>

      <Box sx={{
        gridColumn: { xs: "1 / -1", sm: 2 },
        padding: "10px",
        overflowX: "auto"
      }}>
        {rowsTexts.length > 1 && <Typography sx={{ color: colorBase.colorBase01, fontWeight: 500, marginBottom: "10px" }}>
          {laquestion} {Obligatoire && <span style={{ color: "red" }}>(*)</span>}
        </Typography>}

        <TableContainer>
          <Table size="small" sx={{
            minWidth: "100%",
            "& .MuiTableCell-root": { borderBottom: "1px solid #e0e0e0" },
            "& .MuiTableCell-head": { fontWeight: "bold", color: colorBase.colorBase01, textAlign: "center" }
          }}>
            <TableHead>
              <TableRow>
                <TableCell sx={{ textAlign: 'left !important' }}></TableCell>
                {options.map((opt, i) => <TableCell key={i}>{opt}</TableCell>)}
              </TableRow>
            </TableHead>
            <TableBody>
              {rowsTexts.map((text, rowIndex) => (
                <TableRow key={rowIndex} hover>
                  <TableCell component="th" scope="row" sx={{ fontWeight: 500, color: colorBase.foreColorBase01 }}>
                    {rowsTexts.length === 1 ? <Typography sx={{ color: colorBase.colorBase01, marginRight: '10px', fontWeight: 500 }}>
                      {text} {Obligatoire && <span style={{ color: "red" }}>(*)</span>}
                    </Typography> : text}
                  </TableCell>
                  {options.map((_, colIndex) => (
                    <TableCell key={colIndex} align="center" padding="checkbox">
                      <Radio
                        checked={gridValues[rowIndex]?.[colIndex] === 1}
                        onClick={() => handleCellClick(rowIndex, colIndex)}
                        icon={<RadioButtonUnchecked sx={{ color: '#ccc' }} />}
                        checkedIcon={<RadioButtonChecked sx={{ color: colorBase.colorBase01 }} />}
                      />
                    </TableCell>
                  ))}
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
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
          {note && (
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

export default UdGrilleCases;

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