/* ============================================================================
   Requêteur - Critère « Menu Local » (Fonction_Critere = Appel_Zoom) : zoom
   ----------------------------------------------------------------------------
   Même comportement que le zoom long du desktop (Param_Query_Saisi + fenêtre
   Zoom) : champ en lecture seule + icône ouvrant un panneau zoom (grille
   Code/Libellé — clic sur une ligne = sélection du Code, poubelle = effacer).
   La liste est celle déclarée dans Param_Query_Criteres (Table_Critere /
   Champs_01 / Champs_02 / Condition), chargée par PortalQuery via
   sp_query_zoom. Le champ affiche le libellé, le code reste la valeur du
   critère (visible en aide sous le champ). Aspect visuel repris de TextZoom
   (classes textZoom.scss). Seuls les critères « Combo » (Rubrique) sont des
   listes déroulantes.
   ============================================================================ */
import { TextField, Typography } from "@mui/material";
import {
  Close,
  DeleteOutlineOutlined,
  DragIndicatorOutlined,
} from "@mui/icons-material";
import { useState } from "react";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import "../../components/TextZoom/textZoom.scss";
import { styleLabel } from "../../types";
import { colorBase } from "../../modules/module_general";

/** Ligne de la liste zoom (sp_query_zoom) : Code = valeur, Libelle = affichage. */
export type TChoixZoom = { Code: string; Libelle: string };

const COLONNES_ZOOM: TColonneCollection = {
  Code: { columnName: "Code", headerText: "Code", dataType: "nvarchar", readOnly: true, visible: true },
  Libelle: { columnName: "Libelle", headerText: "Libellé", dataType: "nvarchar", readOnly: true, visible: true },
};

const ZoomCritere = ({
  nomControle,
  label,
  liste,
  valeur = "",
  onchange,
  style,
}: {
  nomControle: string;
  label: string;
  /** Lignes du zoom (Code/Libelle) chargées via sp_query_zoom. */
  liste: TChoixZoom[];
  valeur?: string;
  onchange: (nom: string, valeur: any) => void;
  style?: React.CSSProperties;
}) => {
  const [showZoom, setShowZoom] = useState(false);
  // Libellé du code courant (liste déjà chargée ; repli sur le code brut)
  const libelle = liste.find((x) => String(x.Code) === valeur)?.Libelle ?? "";
  return (
    <div
      style={{
        display: "flex",
        position: "relative",
        minWidth: 0,
        overflow: "hidden",
        ...style,
      }}
      className="textZoomContainer"
    >
      <TextField
        className="textZoom"
        style={{ flex: 1, minWidth: 0 }}
        sx={{
          "& .MuiInputBase-input": {
            fontSize: { xs: "1rem", sm: "1rem" },
            whiteSpace: "nowrap",
            overflow: "hidden",
            textOverflow: "ellipsis",
          },
          "& .MuiInputLabel-root": {
            fontSize: { xs: "1rem", sm: "1rem" },
          },
        }}
        id={nomControle}
        label={label}
        value={valeur === "" ? "" : libelle || valeur}
        helperText={valeur}
        variant="standard"
        FormHelperTextProps={{ style: { fontSize: "0.9rem" } }}
        InputLabelProps={{ style: styleLabel }}
        InputProps={{ readOnly: true }}
        onChange={() => {}}
      />
      <div
        className="zoomIcon"
        style={{ position: "absolute", right: "4px", top: "50%", transform: "translateY(-50%)" }}
        onClick={() => setShowZoom((zm) => !zm)}
      >
        <DragIndicatorOutlined style={{ color: colorBase.colorBase01 }} />
      </div>
      <div hidden={!showZoom} className="overlay"></div>
      <div className={`zoomMenu ${showZoom ? "afficherZoom" : "masquerZoom"}`}>
        {showZoom && (
          <>
            <div className="barZoom">
              <Close className="barZoomItem" onClick={() => setShowZoom(false)} />
              <DeleteOutlineOutlined
                className="barZoomItem"
                onClick={() => {
                  onchange(nomControle, "");
                  setShowZoom(false);
                }}
              />
              <Typography className="barZoomNum">{label}</Typography>
            </div>
            <Grille
              readonly={true}
              dataSource={liste}
              Colonnes={COLONNES_ZOOM}
              sx={{ "& .cl0": { cursor: "pointer !important" } }}
              onclick={({ row }) => {
                onchange(nomControle, row ? String(row["Code"] ?? "") : "");
                setShowZoom(false);
              }}
            />
          </>
        )}
      </div>
    </div>
  );
};
export default ZoomCritere;
