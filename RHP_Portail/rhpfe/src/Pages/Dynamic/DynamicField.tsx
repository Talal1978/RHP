/* ============================================================================
   Module SP_ - Rendu dynamique d'un champ (mapping Typ_Controle -> composant)
   Réutilise les composants partagés du portail : TextBox, TextZoom, ComboBox,
   CalendarZoom. Jamais de rendu spécifique à une page métier.
   ============================================================================ */
import { Checkbox, FormControlLabel, Radio, RadioGroup, FormControl, FormLabel } from "@mui/material";
import TextBox from "../../components/TextBox/TextBox";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import Bouton from "../../components/Bouton/Bouton";
import { AttachFileOutlined } from "@mui/icons-material";
import { listRubriques } from "../../modules/module_rubriques";
import { Monetaire } from "../../modules/module_general_formulas";
import { TSpChamp, TSpContexte } from "./Types";
import { champActif } from "./dynamicEngine";

const stylePlein = { width: "100%" };

/** Libellé affiché (avec marqueur d'obligation). */
export function libelleChamp(champ: TSpChamp): string {
  return champ.Obligatoire === "true" ? `${champ.Libelle} *` : champ.Libelle;
}
/** Mise en forme d'affichage d'une valeur (champ calculé / lecture seule). */
export function valeurAffichee(champ: TSpChamp, valeur: any): string {
  if (valeur === null || valeur === undefined) return "";
  if (champ.Format_Affichage === "MNT" || champ.Typ_Controle === "MNT") {
    const n = Number(valeur);
    return isNaN(n) ? String(valeur) : Monetaire(n);
  }
  if (champ.Decimales !== null && champ.Decimales !== undefined && !isNaN(Number(valeur))) {
    return Number(valeur).toFixed(champ.Decimales);
  }
  return String(valeur);
}

const DynamicField = ({
  champ,
  valeur,
  ctx,
  readonlyGlobal = false,
  onchange,
  onOpenGed,
}: {
  champ: TSpChamp;
  valeur: any;
  ctx: TSpContexte;
  readonlyGlobal?: boolean;
  onchange: (nomColonne: string, valeur: any) => void;
  onOpenGed?: () => void;
}) => {
  const readonly = readonlyGlobal || !champActif(champ, ctx) || champ.Typ_Controle === "CALCULE" || champ.Typ_Controle === "SOURCE";
  const label = libelleChamp(champ);
  const nom = champ.Nom_Colonne;

  switch (champ.Typ_Controle) {
    case "MEMO":
      return (
        <TextBox nomControle={nom} label={label} multiline rows={3}
          valeur={valeur ?? ""} readonly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "INT":
      return (
        <TextBox nomControle={nom} label={label} type="integer"
          valeur={valeur ?? ""} readonly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "DEC":
    case "MNT":
      return (
        <TextBox nomControle={nom} label={label} type="number"
          valeur={valeur ?? ""} readonly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "DATE":
      return (
        <CalendarZoom nomControle={nom} label={label} valeur={valeur || ""} readOnly={readonly}
          onchange={onchange} onClear={() => onchange(nom, "")} sx={{ width: "100%" }} />
      );
    case "DATETIME":
      return (
        <CalendarZoom nomControle={nom} label={label} valeur={valeur || ""} readOnly={readonly} showTime
          onchange={onchange} onClear={() => onchange(nom, "")} sx={{ width: "100%" }} />
      );
    case "CHECK":
      return (
        <FormControlLabel
          control={
            <Checkbox
              checked={valeur === true || valeur === 1 || valeur === "1" || String(valeur).toLowerCase() === "true"}
              onChange={(e) => onchange(nom, e.target.checked)}
              disabled={readonly}
            />
          }
          label={label}
          title={champ.Aide ?? ""}
        />
      );
    case "RADIO": {
      const options = champ.Rubrique ? listRubriques(champ.Rubrique) : [];
      return (
        <FormControl component="fieldset" disabled={readonly} title={champ.Aide ?? ""}>
          <FormLabel component="legend" sx={{ fontSize: "0.85em" }}>{label}</FormLabel>
          <RadioGroup row value={valeur ?? ""} onChange={(e) => onchange(nom, e.target.value)}>
            {options.map((o: any, i: number) => (
              <FormControlLabel key={i} value={o.valeur} control={<Radio size="small" />} label={o.membre} />
            ))}
          </RadioGroup>
        </FormControl>
      );
    }
    case "RUBRIQUE":
      return (
        <ComboBox rubrique={champ.Rubrique ?? ""} nomControle={nom} label={label}
          valeur={valeur ?? ""} readOnly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "COMBO":
      return (
        <ComboBox numZoom={champ.Num_Zoom ?? ""} nomControle={nom} label={label}
          valeur={valeur ?? ""} readOnly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "ZOOM":
      return (
        <TextZoom numZoom={champ.Num_Zoom ?? ""} nomControle={nom} label={label}
          valeur={valeur ?? ""} readonly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "CALCULE":
    case "SOURCE":
      return (
        <TextBox nomControle={nom} label={label} readonly
          valeur={valeurAffichee(champ, valeur)} onchange={() => {}} style={stylePlein} />
      );
    case "GED":
      return (
        <Bouton label={champ.Libelle || "Pièces jointes"} startIcon={<AttachFileOutlined />}
          variant="outlined" onClick={() => onOpenGed && onOpenGed()} />
      );
    case "TEXT":
    default:
      return (
        <TextBox nomControle={nom} label={label} type="text"
          valeur={valeur ?? ""} readonly={readonly} onchange={onchange} style={stylePlein} />
      );
  }
};
export default DynamicField;
