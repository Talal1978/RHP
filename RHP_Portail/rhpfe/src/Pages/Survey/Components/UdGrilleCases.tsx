import React, { useCallback, useEffect, useMemo, useState } from "react";
import { Box, Divider, Typography, SxProps } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { colorBase } from "../../../modules/module_general"; // Chemin ajusté pour l'arborescence logique
import TextBox from "../../../components/TextBox/TextBox"; // Chemin ajusté pour l'arborescence logique
import { Arrondi } from "../../../modules/module_general_formulas"; // Chemin ajusté pour l'arborescence logique
import { ObjetGenerique } from "../../../types";
import Grille, {
  TColonneCollection,
  TGrilleEventClick,
} from "../../../components/Grille/Grille"; // Chemin ajusté pour l'arborescence logique
import { useDeepCompareEffect } from "../../../hooks/useDeepCompareEffect";

// Modes de scoring basés sur la logique VB
type TModeScoring = "manuel" | "auto" | "na";

/**
 * Résultat de la note pour le composant.
 */
type TNoteResult = {
  note: number;
  coef: number;
  note_totale: number;
};

/**
 * Props pour le composant UdGrilleCases (Grille à cases radio/option).
 */
interface TProps {
  sx?: SxProps;
  numQuestion: string;
  laquestion: string;
  Obligatoire: boolean;
  avecNote: boolean;
  modeScoring: TModeScoring;
  coef: number;
  maxScore: number;
  noteManuelle: number;
  colonnes: string; // Liste d'options séparées par ';' pour les en-têtes de colonnes (choix)
  lignes: string; // Liste de questions séparées par ';' pour les lignes
  valeurInitiale?: number[] | null; // Tableau d'indices de colonnes sélectionnées par ligne: [0, 2, -1]
  onValueChange?: (value: number[] | null, note: TNoteResult) => void;
  onRecalculateParent?: () => void;
}

/**
 * Réplique du contrôle utilisateur Visual Basic "ud_grille_cases".
 * @component
 */
const UdGrilleCases = ({
  sx = {},
  numQuestion,
  laquestion,
  Obligatoire,
  avecNote,
  modeScoring,
  coef,
  maxScore,
  noteManuelle,
  colonnes,
  lignes,
  valeurInitiale,
  onValueChange,
  onRecalculateParent,
}: TProps) => {
  // État pour stocker l'indice de colonne sélectionné pour chaque ligne (-1 si aucune)
  const [selectedColumns, setSelectedColumns] = useState<number[]>(
    valeurInitiale || []
  );
  const [manualNote, setManualNote] = useState(noteManuelle);
  const [noteResult, setNoteResult] = useState<TNoteResult>({
    note: 0,
    coef: coef,
    note_totale: 0,
  });

  const options = useMemo(
    () => colonnes.split(";").filter((c) => c.trim() !== ""),
    [colonnes]
  );
  const rowsTexts = useMemo(
    () => lignes.split(";").filter((l) => l.trim() !== ""),
    [lignes]
  );

  // Initialisation de l'état de sélection (si non initialisé)
  useEffect(() => {
    if (selectedColumns.length === 0 || selectedColumns.length !== rowsTexts.length) {
      setSelectedColumns(Array(rowsTexts.length).fill(-1));
    }
  }, [rowsTexts]);

  // --- LOGIQUE DE SCORING ---

  const calculNote = useCallback((): TNoteResult => {
    let laNote = 0;
    const rowsCount = selectedColumns.length;

    if (modeScoring === "manuel") {
      laNote = manualNote;
    } else if (modeScoring === "auto") {
      let totalScore = 0;

      selectedColumns.forEach((selectedIndex) => {
        if (selectedIndex !== -1) {
          // Le code VB utilise j+1 où j commence à 1, ce qui donne des scores 2, 3, 4...
          // Nous utilisons l'indice de colonne sélectionnée (0, 1, 2...) + 1 pour avoir des scores 1, 2, 3...
          totalScore += selectedIndex + 1;
        }
      });

      // Le code VB divise par le nombre total de lignes, qu'elles soient sélectionnées ou non.
      laNote = rowsCount > 0 ? totalScore / rowsCount : 0;

      // Note: On ignore l'exécution de funcScoring pour des raisons de sécurité.
    }

    laNote = Math.min(laNote, maxScore);
    const note_totale = Arrondi(coef * laNote, 2);

    return {
      note: Arrondi(laNote, 2),
      coef: coef,
      note_totale: note_totale,
    };
  }, [selectedColumns, modeScoring, manualNote, coef, maxScore]);

  // Met à jour la note et notifie le parent à chaque changement de sélection ou de note manuelle
  useEffect(() => {
    const newNote = calculNote();
    setNoteResult(newNote);
    onValueChange?.(selectedColumns, newNote);
    // onRecalculateParent?.(); // Appel de recalcul désactivé ici pour éviter des boucles si le parent le gère
  }, [selectedColumns, manualNote, calculNote, onValueChange]);
  
  // Utilisation de useDeepCompareEffect pour éviter les mises à jour inutiles si la référence des props change
  useDeepCompareEffect(() => {
      setManualNote(noteManuelle);
  }, [noteManuelle]);

  // --- GESTION DU CLIC ET DE LA GRILLE ---

  const handleGrilleClick = useCallback(
    ({ rowIndex, colName }: TGrilleEventClick) => {
      if (rowIndex === undefined || !colName?.startsWith("Opt_")) return;

      const clickedOptIndex = parseInt(colName.replace("Opt_", ""), 10);

      setSelectedColumns((prevSelections) => {
        const newSelections = [...prevSelections];
        const isCurrentlySelected = newSelections[rowIndex] === clickedOptIndex;

        // Logique de bouton radio : si déjà sélectionné, désélectionner (-1). Sinon, sélectionner la nouvelle option.
        newSelections[rowIndex] = isCurrentlySelected
          ? -1
          : clickedOptIndex;

        return newSelections;
      });
    },
    []
  );

  // Définition des colonnes pour le composant Grille
  const grilleCols: TColonneCollection = useMemo(() => {
    const cols: TColonneCollection = {
      Question_Text: {
        columnName: "Question_Text",
        headerText: laquestion + (Obligatoire ? " (*)" : ""),
        dataType: "nvarchar",
        readOnly: true,
        visible: true,
        typeColonne: "Text",
        sx: { minWidth: "200px", maxWidth: "400px" },
      },
    };
    options.forEach((opt, index) => {
      cols[`Opt_${index}`] = {
        columnName: `Opt_${index}`,
        headerText: opt.trim(),
        dataType: "nvarchar",
        readOnly: true,
        visible: true,
        typeColonne: "Image", // Utiliser Image pour afficher l'icône de sélection
        sx: { textAlign: "center", cursor: "pointer", maxWidth: "80px" },
      };
    });
    return cols;
  }, [laquestion, colonnes, Obligatoire]);

  // Construction dynamique de la source de données pour le composant Grille
  const dataSource = useMemo(() => {
    if (selectedColumns.length !== rowsTexts.length) return [];
    
    return rowsTexts.map((lineText, rowIndex) => {
      const row: ObjetGenerique = {
        Question_Text: lineText.trim(),
      };
      // Définir la source de l'image pour chaque colonne d'option
      options.forEach((_, optIndex) => {
        row[`Opt_${optIndex}`] =
          selectedColumns[rowIndex] === optIndex
            ? `${process.env.PUBLIC_URL}/selected_radio.png` // A remplacer par votre icône "sélectionnée"
            : `${process.env.PUBLIC_URL}/unselected_radio.png`; // A remplacer par votre icône "non sélectionnée"
      });
      return row;
    });
  }, [rowsTexts, options, selectedColumns]);

  // --- GESTION DES CHANGEMENTS DE VALEUR (NOTE MANUELLE) ---

  const handleManualNoteChange = useCallback(
    (name: string, value: any) => {
      let newNote = parseFloat(value) || 0;
      newNote = Math.min(newNote, maxScore);
      setManualNote(newNote);
    },
    [maxScore]
  );

  // --- STRUCTURE DU COMPOSANT ---
  return (
    <Box
      className="ud-grille-cases"
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
        border: "1px solid #e0e0e0",
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

        {/* Colonne 2 & 3: Grille et Panneau de notes */}
        <Box
          sx={{
            gridColumn: { xs: "1 / -1", sm: "2 / -1" },
            display: "flex",
            flexDirection: { xs: "column", sm: "row" },
            alignItems: "stretch",
            padding: { xs: "1em 5px", sm: "3px 5px 3px 20px" },
          }}
        >
          {/* Sous-Colonne 1: Grille de Questions/Options */}
          <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', sm: '400px' } }}>
            <Grille
              readonly={false}
              dataSource={dataSource}
              Colonnes={grilleCols}
              className="udGrilleCases"
              showBorder={false}
              onclick={handleGrilleClick}
            />
          </Box>

          {/* Sous-Colonne 2: Panneau de notes */}
          {avecNote && modeScoring !== "na" && (
            <Box
              className="pnl_note"
              sx={{
                minWidth: { xs: "100%", sm: "200px" },
                maxWidth: "200px",
                margin: { xs: "1em 0", sm: "unset" },
                padding: "3px",
                display: "flex",
                flexDirection: "column",
                gap: "5px",
                backgroundColor: "white",
                borderLeft: { sm: "1px solid #e0e0e0" },
                flexShrink: 0,
              }}
            >
              <NoteField
                label="Note"
                value={noteResult.note}
                readonly={modeScoring !== "manuel"}
                onChange={handleManualNoteChange}
              />
              <NoteField label="Coef." value={noteResult.coef} readonly={true} />
              <NoteField
                label="Note totale"
                value={noteResult.note_totale}
                readonly={true}
              />
            </Box>
          )}
        </Box>
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

export default UdGrilleCases;

// -----------------------------------------------------------------------
// COMPOSANT AUXILIAIRE POUR LES CHAMPS DE NOTE (COPIÉ DE UdValeurUnique.tsx)
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
            backgroundColor: readonly ? "transparent" : "white", // Fond blanc seulement en mode édition
          },
          // Masquer la ligne inférieure par défaut du standard variant pour coller au design VB
          "& .MuiInput-underline:after": { borderBottom: "none" },
          "& .MuiInput-underline:before": { borderBottom: "none" },
          "& .MuiInput-underline:hover:not(.Mui-disabled):before": {
            borderBottom: "none",
          },
        }}
      />
    </Grid>
  </Grid>
);