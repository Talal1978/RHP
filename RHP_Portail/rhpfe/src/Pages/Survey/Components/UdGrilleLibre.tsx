import React, { useCallback, useEffect, useMemo, useState, useRef } from "react";
import { Box, Typography, SxProps, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Checkbox, Radio } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { CheckBoxOutlineBlank, CheckBoxOutlined, RadioButtonChecked, RadioButtonUnchecked } from "@mui/icons-material";
import { colorBase } from "../../../modules/module_general";
import TextBox from "../../../components/TextBox/TextBox";
import CalendarZoom from "../../../components/Calendar/CalendarZoom";
import { Arrondi } from "../../../modules/module_general_formulas";
import { useDeepCompareEffect } from "../../../hooks/useDeepCompareEffect";
import { TInputType } from "../../../types";
import { TModeScoring, TNoteResult } from "../Types";
import { safeNumber } from "../Survey_Functions";

// Marqueurs de colonne basés sur le code VB
type TColMark = "[C]" | "[O]" | "[E]" | "[D]" | "[N]" | "[T]" | "TEXT_DEFAULT";

/**
 * Interface pour la définition interne des colonnes
 */
interface TColumnDefinition {
    header: string;
    colMark: TColMark;
    name: string;
    dataType: TInputType | 'date';
}

/**
 * Nombre de lignes par défaut pour la grille libre si non spécifié (arbitraire)
 */
const DEFAULT_ROWS = 3;

/**
 * Props pour le composant UdGrilleLibre.
 */
interface TProps {
    sx?: SxProps;
    numQuestion: number;
    laquestion: string;
    Obligatoire: boolean;
    avecNote: boolean;
    note: TNoteResult | null;
    handleNoteManuelle?: (numQuestion: number, note: TNoteResult) => void;
    colonnes: string; // Ex: "Titre [T]; Montant [N]; Date [D]; Choix [C]"
    lignes?: number; // Nombre de lignes à afficher (par défaut DEFAULT_ROWS)
    valeurInitiale?: any[][] | null; // Matrice des valeurs initiales
    onValueChange?: (value: any[][] | null) => void;
}

/**
 * Réplique du contrôle utilisateur Visual Basic "ud_grille_libre".
 * Gère une grille de saisie hétérogène.
 * @component
 */
const UdGrilleLibre = ({
    sx = {},
    numQuestion,
    laquestion,
    Obligatoire,
    avecNote,
    note,
    handleNoteManuelle,
    colonnes,
    valeurInitiale,
    lignes = DEFAULT_ROWS,
    onValueChange,
}: TProps) => {
    // ✅ FIX 1: Utiliser useRef pour onValueChange
    const onValueChangeRef = useRef(onValueChange);
    useEffect(() => {
        onValueChangeRef.current = onValueChange;
    }, [onValueChange]);

    const rowCount = useMemo(() => {
        return (lignes && lignes > 0) ? lignes : DEFAULT_ROWS;
    }, [lignes]);

    const handleManualNoteChange = (value: any) => {
        if (!note?.note_manuelle) return;
        const newNote = safeNumber(value, 0);
        const safeMaxScore = safeNumber(note?.max_score, 100000000);
        handleNoteManuelle && handleNoteManuelle(numQuestion, { note: Math.min(newNote, safeMaxScore), coef: note?.coef || 1, note_totale: Math.min(newNote, safeMaxScore) * (note?.coef || 1), max_score: safeMaxScore });
    };

    // 1. Parsing des colonnes
    const parsedColumns = useMemo((): TColumnDefinition[] => {
        const regex = /\[([COEDNT])\]/g;
        const columnDefinitions: TColumnDefinition[] = [];

        colonnes.split(";").forEach((colStr, index) => {
            let header = colStr.trim();
            let colMark: TColMark = "TEXT_DEFAULT";
            let dataType: TInputType | 'date' = 'text';

            const match = Array.from(colStr.matchAll(regex))[0];

            if (match) {
                const mark = `[${match[1]}]` as TColMark;
                colMark = mark;
                header = header.replace(mark, "").trim();

                switch (colMark) {
                    case "[C]":
                    case "[O]":
                        dataType = 'text';
                        break;
                    case "[E]":
                        dataType = 'integer';
                        break;
                    case "[D]":
                        dataType = 'date';
                        break;
                    case "[N]":
                        dataType = 'number';
                        break;
                    default:
                        dataType = 'text';
                        break;
                }
            } else {
                colMark = "[T]";
                dataType = 'text';
            }

            if (header || colMark === "[T]") {
                columnDefinitions.push({
                    header: header || "Valeur",
                    colMark: colMark,
                    name: `col_${index}`,
                    dataType: dataType,
                });
            }
        });
        return columnDefinitions;
    }, [colonnes]);

    // 2. Data State Management
    const initialGridData = useMemo(() => {
        if (valeurInitiale && valeurInitiale.length > 0) {
            return valeurInitiale;
        }
        return Array.from({ length: rowCount }, () =>
            parsedColumns.map(col => (col.colMark === '[O]' || col.colMark === '[C]') ? false : '')
        );
    }, [valeurInitiale, parsedColumns, rowCount]);

    const [gridData, setGridData] = useState<any[][]>(initialGridData);

    useDeepCompareEffect(() => {
        if (valeurInitiale) setGridData(initialGridData);
    }, [initialGridData]);


    // ✅ FIX 2: Retirer onValueChange des dépendances
    useEffect(() => {
        if (onValueChangeRef.current) {
            onValueChangeRef.current(gridData);
        }
    }, [gridData]); // ← Retirer manualNote car déjà dans calculNote



    // 4. Gestion des changements dans la grille
    const handleGridChange = useCallback((
        rowIndex: number,
        colIndex: number,
        newValue: any,
        isControl?: boolean
    ) => {
        setGridData(prevGridData => {
            const newGridData = prevGridData.map(row => [...row]);
            const colMark = parsedColumns[colIndex].colMark;

            if (isControl) {
                // Gère le comportement Radio ([C])
                if (colMark === '[C]') {
                    const isChecked = !newGridData[rowIndex][colIndex];
                    newGridData[rowIndex] = newGridData[rowIndex].map((val, idx) => {
                        if (parsedColumns[idx].colMark === '[C]') {
                            return (idx === colIndex && isChecked) ? true : false;
                        }
                        return val;
                    });
                }
                // Gère le comportement Checkbox ([O])
                else if (colMark === '[O]') {
                    newGridData[rowIndex][colIndex] = !newGridData[rowIndex][colIndex];
                }
            } else {
                // Gère les inputs standard (Text, Number, Date)
                newGridData[rowIndex][colIndex] = newValue;
            }
            return newGridData;
        });
    }, [parsedColumns]);

    // 6. Rendu final du composant
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
            {/* Colonne 1: Numéro */}
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

            {/* Colonne 2: Question et Grille */}
            <Box sx={{
                gridColumn: { xs: "1 / -1", sm: 2 },
                padding: "10px",
                overflowX: "auto"
            }}>
                <Typography sx={{ color: colorBase.foreColorBase01, fontWeight: 500, marginBottom: "10px" }}>
                    {laquestion} {Obligatoire && <span style={{ color: "red" }}>(*)</span>}
                </Typography>

                <TableContainer>
                    <Table size="small" sx={{
                        minWidth: "100%",
                        "& .MuiTableCell-root": { padding: '5px' },
                        "& .MuiTableCell-head": { fontWeight: "bold", color: colorBase.colorBase01, textAlign: 'center' }
                    }}>
                        <TableHead>
                            <TableRow>
                                {parsedColumns.map((col, i) => (
                                    <TableCell key={i} sx={{
                                        minWidth: col.colMark === '[T]' ? '200px' : (col.colMark === '[D]' ? '120px' : (col.colMark === '[N]' || col.colMark === '[E]' ? '80px' : '80px')),
                                        textAlign: 'center'
                                    }}>
                                        {col.header}
                                    </TableCell>
                                ))}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {gridData.map((row, rowIndex) => (
                                <TableRow key={rowIndex} hover>
                                    {parsedColumns.map((col, colIndex) => (
                                        <TableCell
                                            key={colIndex}
                                            align={col.colMark === '[C]' || col.colMark === '[O]' || col.colMark === '[D]' ? 'center' : (col.colMark === '[N]' || col.colMark === '[E]' ? 'right' : 'left')}
                                        >
                                            <CellRenderer
                                                rowIndex={rowIndex}
                                                colIndex={colIndex}
                                                definition={col}
                                                handleGridChange={handleGridChange}
                                                cellValue={gridData[rowIndex]?.[colIndex]} // ✅ FIX 3: Passer la valeur en prop
                                            />
                                        </TableCell>
                                    ))}
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Box>

            {/* Colonne 3: Notes */}
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

export default UdGrilleLibre;

// Composant Auxiliaire pour l'affichage de la note
const NoteField = ({ label, value, readonly, onChange = () => { } }: any) => (
    <Grid container spacing={1} alignItems="center">
        <Grid xs={6}><Typography sx={{ color: colorBase.colorBase01, fontSize: "0.8em" }}>{label}</Typography></Grid>
        <Grid xs={6}>
            <TextBox nomControle="nt" label="" type="number" valeur={Arrondi(value, 2)} readonly={readonly} onchange={onChange} style={{ width: "100%" }} sx={{ "& .MuiInputBase-input": { textAlign: "center", fontWeight: "bold", fontSize: "1em", padding: "0", backgroundColor: readonly ? 'var(--chip-bg)' : "var(--bg-input)", color: "var(--fore-color-base-01)" } }} />
        </Grid>
    </Grid>
);

// ✅ FIX 3: CellRenderer reçoit cellValue en prop au lieu d'utiliser un state local
const CellRenderer = ({
    rowIndex,
    colIndex,
    definition,
    handleGridChange,
    cellValue // ← Valeur contrôlée par le parent
}: {
    rowIndex: number,
    colIndex: number,
    definition: TColumnDefinition,
    handleGridChange: any,
    cellValue: any // ← Ajout de cette prop
}) => {
    const isChecked = typeof cellValue === 'boolean' ? cellValue : false;

    const commonSx = {
        "& .MuiInputBase-input": {
            padding: '5px 8px',
            fontSize: '0.9em',
            height: 'auto',
            lineHeight: 'normal',
            minHeight: '20px',
            backgroundColor: 'var(--bg-input) !important',
            color: 'var(--fore-color-base-01) !important'
        },
        "& .MuiInput-underline:before": { borderBottom: '1px solid #ccc' },
        "& .MuiInput-underline:after": { borderBottomColor: colorBase.colorBase02 },
        "& .Mui-disabled:before": { borderBottomStyle: 'solid' },
    };

    switch (definition.colMark) {
        case "[C]":
            return (
                <Box
                    onClick={() => handleGridChange(rowIndex, colIndex, null, true)}
                    sx={{ cursor: 'pointer', textAlign: 'center', height: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                >
                    <Radio
                        checked={isChecked}
                        icon={<RadioButtonUnchecked sx={{ color: '#ccc', fontSize: '1.2em' }} />}
                        checkedIcon={<RadioButtonChecked sx={{ color: colorBase.colorBase01, fontSize: '1.2em' }} />}
                    />
                </Box>
            );
        case "[O]":
            return (
                <Box
                    onClick={() => handleGridChange(rowIndex, colIndex, null, true)}
                    sx={{ cursor: 'pointer', textAlign: 'center', height: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                >
                    <Checkbox
                        checked={isChecked}
                        icon={<CheckBoxOutlineBlank sx={{ color: '#ccc', fontSize: '1.2em' }} />}
                        checkedIcon={<CheckBoxOutlined sx={{ color: colorBase.colorBase01, fontSize: '1.2em' }} />}
                    />
                </Box>
            );
        case "[D]":
            return (
                <CalendarZoom
                    nomControle={definition.name}
                    label=""
                    valeur={cellValue}
                    onchange={(_n: string, date: Date | null) => handleGridChange(rowIndex, colIndex, date)}
                    sx={{
                        width: "100%",
                        maxWidth: '120px',
                        "& input": { fontSize: '0.85em', textAlign: 'center', backgroundColor: 'var(--bg-input) !important', color: 'var(--fore-color-base-01) !important' }
                    }}
                />
            );
        case "[E]":
        case "[N]":
            return (
                <TextBox
                    nomControle={definition.name}
                    label=""
                    type={definition.dataType as 'number' | 'integer'}
                    valeur={cellValue}
                    onchange={(_n, val) => handleGridChange(rowIndex, colIndex, val)}
                    style={{ width: '100%' }}
                    sx={{ ...commonSx, maxWidth: '80px', "& .MuiInputBase-input": { ...commonSx["& .MuiInputBase-input"], textAlign: 'right' } }}
                />
            );
        case "[T]":
        default:
            return (
                <TextBox
                    nomControle={definition.name}
                    label=""
                    type="text"
                    valeur={cellValue}
                    onchange={(_n, val) => handleGridChange(rowIndex, colIndex, val)}
                    style={{ width: '100%' }}
                    sx={commonSx}
                />
            );
    }
};