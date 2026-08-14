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
import { champActif, cleChamp } from "./dynamicEngine";

const stylePlein = { width: "100%" };

/** Libellé affiché (avec marqueur d'obligation). */
export function libelleChamp(champ: TSpChamp): string {
  return champ.Obligatoire === "true" ? `${champ.Libelle} *` : champ.Libelle;
}
/** Mise en forme d'affichage d'une valeur (champ calculé / lecture seule).
    Formats inspirés d'Excel : NUM = nombre, MNT = monétaire, PCT = pourcentage
    (0,15 -> 15 %), DAT = date, DTM = date et heure ; à défaut Décimales, puis texte brut. */
export function valeurAffichee(champ: TSpChamp, valeur: any): string {
  if (valeur === null || valeur === undefined) return "";
  const n = Number(valeur);
  const dec = champ.Decimales ?? 2;
  const fmt = champ.Format_Affichage || (champ.Typ_Controle === "MNT" ? "MNT" : "");
  switch (fmt) {
    case "MNT":
      return isNaN(n) ? String(valeur) : Monetaire(n);
    case "NUM":
      return isNaN(n) ? String(valeur)
        : new Intl.NumberFormat("fr-FR", { minimumFractionDigits: dec, maximumFractionDigits: dec }).format(n);
    case "PCT":
      return isNaN(n) ? String(valeur)
        : new Intl.NumberFormat("fr-FR", { style: "percent", minimumFractionDigits: dec, maximumFractionDigits: dec }).format(n);
    case "DAT":
    case "DTM": {
      const d = valeur instanceof Date ? valeur : new Date(valeur);
      if (isNaN(d.getTime())) return String(valeur);
      return fmt === "DAT"
        ? new Intl.DateTimeFormat("fr-FR").format(d)
        : new Intl.DateTimeFormat("fr-FR", { dateStyle: "short", timeStyle: "short" }).format(d);
    }
  }
  if (champ.Decimales !== null && champ.Decimales !== undefined && !isNaN(n)) {
    return n.toFixed(champ.Decimales);
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
  const nom = cleChamp(champ);
  // Condition de zoom déclarative : "Matricule='{Matricule}'" -> les placeholders
  // {Champ} sont remplacés par les valeurs courantes de l'entête.
  const conditionZoom = champ.Zoom_Condition
    ? champ.Zoom_Condition.replace(/\{([A-Za-z_][A-Za-z0-9_]*)\}/g, (_m, n) => String(ctx?.entete?.[n] ?? ""))
    : undefined;

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
        <ComboBox numZoom={champ.Num_Zoom ?? ""} conditionZoom={conditionZoom} nomControle={nom} label={label}
          valeur={valeur ?? ""} readOnly={readonly} onchange={onchange} style={stylePlein} />
      );
    case "ZOOM":
      return (
        <TextZoom numZoom={champ.Num_Zoom ?? ""} conditionZoom={conditionZoom} nomControle={nom} label={label}
          valeur={valeur ?? ""} readonly={readonly} onchange={onchange} style={stylePlein} libelleZoom />
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
