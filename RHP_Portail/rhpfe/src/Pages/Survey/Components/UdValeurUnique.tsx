import React, { useCallback, useEffect, useMemo, useState } from "react";
import { Box, Divider, Typography, Select, MenuItem, SelectChangeEvent, SxProps } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { colorBase } from "../../../modules/module_general";
import TextBox from "../../../components/TextBox/TextBox";
import CalendarZoom from "../../../components/Calendar/CalendarZoom";
import { Arrondi } from "../../../modules/module_general_formulas";
import { TInputType, ObjetGenerique } from "../../../types";

// Types d'entrée mis à jour
type TReponseType =
  | "numerique"
  | "entier"
  | "dateTime"
  | "date"
  | "heure"
  | "alpha"
  | "liste"
  | "bit"
  | "multiLine";

// Modes de scoring basés sur la logique VB
type TModeScoring = "manuel" | "auto" | "na";

/**
 * Props pour le composant UdValeurUnique.
 */
interface TProps {
  sx?: SxProps; // Ajout de la prop sx pour les styles du conteneur
  numQuestion: string;
  laquestion: string;
  Typ_Reponse: TReponseType;
  Obligatoire: boolean;
  avecNote: boolean;
  modeScoring: TModeScoring;
  coef: number;
  maxScore: number;
  noteManuelle: number;
  funcScoring: string; // Nom de la fonction de scoring (non exécutable côté client)
  colonnes: string; // Liste d'options séparées par ';' pour le type 'liste'
  valeurInitiale?: any;
  onValueChange?: (value: any, note: TNoteResult) => void;
  onRecalculateParent?: () => void;
}

type TNoteResult = {
  note: number;
  coef: number;
  note_totale: number;
};


/**
 * Réplique du contrôle utilisateur Visual Basic "ud_valeur_unique".
 * @component
 */
const UdValeurUnique = ({
  sx = {},
  numQuestion,
  laquestion,
  Typ_Reponse,
  Obligatoire,
  avecNote,
  modeScoring,
  coef,
  maxScore,
  noteManuelle,
  colonnes,
  valeurInitiale,
  onValueChange,
  onRecalculateParent,
}: TProps) => {
  const [inputValue, setInputValue] = useState(valeurInitiale ?? "");
  const [manualNote, setManualNote] = useState(noteManuelle);
  const [noteResult, setNoteResult] = useState<TNoteResult>({
    note: 0,
    coef: coef,
    note_totale: 0,
  });
  
  // Fonction utilitaire déplacée à l'intérieur pour éviter ts(2451)
  const isSmallInputType = (type: TReponseType) => 
    ["numerique", "entier", "date", "dateTime", "heure", "bit"].includes(type);

  // Définir le résultat de l'appel ici
  const isSmallInputResult = isSmallInputType(Typ_Reponse);


  // --- LOGIQUE DE SCORING ---

  const calculNote = useCallback((): TNoteResult => {
    let laNote = 0;

    if (modeScoring === "manuel") {
      laNote = manualNote;
    } else if (modeScoring === "auto") {
      if (Typ_Reponse === 'numerique' || Typ_Reponse === 'entier') {
        laNote = parseFloat(inputValue || 0);
      } else {
        laNote = 0;
      }
    }

    laNote = Math.min(laNote, maxScore);
    const note_totale = Arrondi(coef * laNote, 2);

    return {
      note: Arrondi(laNote, 2),
      coef: coef,
      note_totale: note_totale,
    };
  }, [inputValue, modeScoring, manualNote, coef, maxScore, Typ_Reponse]);

  useEffect(() => {
    const newNote = calculNote();
    setNoteResult(newNote);
    onValueChange?.(inputValue, newNote);
    onRecalculateParent?.();
  }, [inputValue, manualNote, calculNote, onValueChange, onRecalculateParent]);

  // --- GESTION DES CHANGEMENTS DE VALEUR ---

  const handleValueChange = (value: any) => {
    setInputValue(value);
  };

  const handleDateChange = (name: string, date: Date | null) => {
    setInputValue(date);
  };

  const handleManualNoteChange = (name: string, value: any) => {
    let newNote = parseFloat(value) || 0;
    newNote = Math.min(newNote, maxScore);
    setManualNote(newNote);
  };

  // --- RENDU DYNAMIQUE DE L'INPUT ---

  const InputComponent = useMemo(() => {
    
    const commonProps: ObjetGenerique = {
        valeur: inputValue,
        onchange: (name: string, value: any) => handleValueChange(value),
        style: { width: "100%" },
        sx: { 
            "& .MuiInputBase-input": { 
                backgroundColor: 'white !important', 
                padding: '5px 10px',
            },
            "& .MuiSelect-select": {
                backgroundColor: 'white !important',
            }
        },
    };

    switch (Typ_Reponse) {
      case "numerique":
      case "entier":
        return <TextBox {...commonProps} label="" type={Typ_Reponse === "numerique" ? "number" : "integer"} nomControle={`reponse_${Typ_Reponse}`} />;
      
      case "alpha":
        return <TextBox {...commonProps} label="" type="text" nomControle="reponse_alpha" />;

      case "multiLine":
        return (
            <TextBox 
                {...commonProps} 
                label="" 
                type="text" 
                style={{ minWidth: "39vw" }}
                nomControle="reponse_multiline"
                multiline={true}
                rows={4}
            />
        );

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
                ...commonProps.lg,
                width: "100%",
                "& input": { fontSize: "1em", textAlign: "center", backgroundColor: 'white !important' },
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
            sx={{ 
                ...commonProps.sx,
                flexGrow: 1, 
                minWidth: '100px',
                borderBottom: `1px solid gray`,
                backgroundColor: 'white !important'
            }}
          >
            {options.map((option, index) => (
              <MenuItem key={index} value={option.trim()}>
                {option.trim()}
              </MenuItem>
            ))}
          </Select>
        );
      case "bit":
        return (
          <Select
            value={inputValue === true ? "Oui" : inputValue === false ? "Non" : ""}
            onChange={(e: SelectChangeEvent) => handleValueChange(e.target.value === "Oui")}
            variant="standard"
            sx={{ 
                ...commonProps.sx,
                flexGrow: 1, 
                minWidth: '80px',
                borderBottom: `1px solid gray`,
                backgroundColor: 'white !important'
            }}
          >
            <MenuItem value="Oui">Oui</MenuItem>
            <MenuItem value="Non">Non</MenuItem>
          </Select>
        );
      default:
        return <TextBox {...commonProps} label="" type="text" nomControle="reponse_defaut" />;
    }
  }, [Typ_Reponse, inputValue, colonnes]);


  // --- STRUCTURE DU COMPOSANT ---
  return (
    <Box
      className="ud-valeur-unique"
      sx={{
        ...sx,
        backgroundColor: "#f5f5f5",
        display: "grid",
        gridTemplateColumns: {
          xs: "1fr",
          sm: "53px 1fr 200px",
        },
        gridTemplateRows: "auto 8px",
        padding: "2px",
        width: "100%",
        fontSize: "1em",
        border: '1px solid #e0e0e0'
      }}
    >
      <Box
        sx={{
          gridRow: 1,
          gridColumn: { xs: "1 / -1", sm: "1 / -1" },
          display: "contents",
        }}
      >
        {/* Colonne 1: Numéro de question */}
        <Box
          className="numQuestion_pnl"
          sx={{
            gridColumn: { xs: "1 / -1", sm: 1 },
            bgcolor: colorBase.colorBase01,
            color: "white",
            height: { xs: "3em", sm: "auto" },
            minHeight: "4em",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            paddingRight: { xs: "0", sm: "2px" },
          }}
        >
          <Typography
            component="span"
            className="Num_Question_lbl"
            sx={{
              bgcolor: "white",
              color: colorBase.colorBase01,
              width: "100%",
              height: "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              fontWeight: "bold",
              fontSize: "1.5em",
            }}
          >
            {numQuestion}
          </Typography>
        </Box>

        {/* Colonne 2: Question et Input */}
        <Box
          className="grd-content"
          sx={{
            gridColumn: { xs: "1 / -1", sm: 2 },
            // La direction change si c'est un champ large (multiLine/alpha) ou sur petit écran
            display: 'flex',
            flexDirection: (Typ_Reponse === 'multiLine' || Typ_Reponse === 'alpha') ? 'column' : { xs: 'column', sm: 'row' },
            alignItems: (Typ_Reponse === 'multiLine' || Typ_Reponse === 'alpha') ? 'flex-start' : { xs: 'flex-start', sm: 'center' },
            justifyContent: 'space-between',
            gap: { xs: '0.5em', sm: '1em' },
            padding: {
                xs: "1em 20px 1em 20px",
                sm: "3px 20px 3px 73px",
            }
          }}
        >
          {/* Question (partie gauche) */}
          <Typography
            component="span"
            sx={{
                flexShrink: 0,
                fontWeight: '400',
                color: colorBase.foreColorBase01,
                fontSize: '1em',
            }}
          >
            {laquestion} {Obligatoire && <span style={{ color: "red" }}>(*)</span>}
          </Typography>
          
          {/* Input dynamique (partie droite/bas) */}
          <Box 
            className="input-container" 
            sx={{ 
                // Styles d'optimisation de taille
                minWidth: { 
                    xs: '100%', 
                    sm: isSmallInputResult ? '120px' : '200px' 
                },
                maxWidth: { 
                    xs: '100%', 
                    sm: isSmallInputResult ? '180px' : 'none' 
                },
                flexGrow: isSmallInputResult ? 0 : 1,
                
                padding: '0 5px',
                "& .MuiInput-underline:after": { borderBottom: 'none' }, 
                "& .MuiInput-underline:before": { borderBottom: 'none' },
                "& .MuiInput-underline:hover:not(.Mui-disabled):before": { borderBottom: 'none' },
            }}
          >
            {InputComponent}
          </Box>
        </Box>

        {/* Colonne 3: Panneau de notes */}
        {avecNote && modeScoring !== "na" && (
          <Box
            className="pnl_note"
            sx={{
              gridColumn: { xs: "1 / -1", sm: 3 },
              minWidth: { xs: "100%", sm: "200px" },
              maxWidth: "200px",
              margin: { xs: "1em 0", sm: "unset" },
              padding: "3px",
              display: "flex",
              flexDirection: "column",
              gap: "5px",
              backgroundColor: 'white',
              borderLeft: { sm: '1px solid #e0e0e0' },
            }}
          >
            <NoteField
              label="Note"
              value={noteResult.note}
              readonly={modeScoring !== "manuel"}
              onChange={handleManualNoteChange}
            />
            <NoteField
              label="Coef."
              value={noteResult.coef}
              readonly={true}
            />
            <NoteField
              label="Note totale"
              value={noteResult.note_totale}
              readonly={true}
            />
          </Box>
        )}
      </Box>

      {/* Ligne de séparation */}
      <Box
        sx={{
          gridRow: 2,
          gridColumn: "1 / -1",
          height: "8px",
          display: "flex",
          justifyContent: "center",
          alignItems: "flex-end",
          padding: "0 10px",
          overflow: "hidden",
        }}
      >
        <Divider
          className="Line"
          sx={{
            width: "100%",
            height: "1px",
            bgcolor: "#d0e7ef",
          }}
        />
      </Box>
    </Box>
  );
};

export default UdValeurUnique;

// -----------------------------------------------------------------------
// COMPOSANT AUXILIAIRE POUR LES CHAMPS DE NOTE (INCHANGÉ)
// -----------------------------------------------------------------------

const NoteField = ({
  label,
  value,
  readonly,
  onChange = () => {},
}: {
  label: string;
  value: number;
  readonly: boolean;
  onChange?: (name: string, value: any) => void;
}) => (
  <Grid container spacing={1} alignItems="center">
    <Grid xs={6}>
      <Typography
        component="span"
        sx={{
          color: colorBase.colorBase01,
          fontWeight: "400",
          fontSize: "0.9em",
        }}
      >
        {label}
      </Typography>
    </Grid>
    <Grid xs={6}>
      <TextBox
        nomControle="note_txt"
        label=""
        type="number"
        valeur={Arrondi(value, 2)}
        readonly={readonly}
        onchange={onChange}
        style={{ width: "100%" }}
        sx={{
          "& .MuiInputBase-input": {
            textAlign: "center",
            color: colorBase.colorBase01,
            fontWeight: "bold",
            fontSize: "1.2em",
            textDecoration: readonly ? "none" : "underline",
            backgroundColor: readonly ? 'transparent' : 'white', // Fond blanc seulement en mode édition
          },
          // Masquer la ligne inférieure par défaut du standard variant pour coller au design VB
          "& .MuiInput-underline:after": { borderBottom: 'none' }, 
          "& .MuiInput-underline:before": { borderBottom: 'none' },
          "& .MuiInput-underline:hover:not(.Mui-disabled):before": { borderBottom: 'none' },
        }}
      />
    </Grid>
  </Grid>
);