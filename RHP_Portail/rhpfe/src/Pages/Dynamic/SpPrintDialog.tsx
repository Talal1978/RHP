/* ============================================================================
   Module SP_ - Impression générique d'un document (fiche produite depuis les
   métadonnées, sans modèle Crystal). Utilisée par DynamicPage quand
   Act_Imprimer='true' et aucun Cod_Modele_Edition n'est configuré.
   ============================================================================ */
import { Dialog, DialogContent, DialogTitle, IconButton } from "@mui/material";
import { Close, PrintOutlined } from "@mui/icons-material";
import Bouton from "../../components/Bouton/Bouton";
import { findRubrique } from "../../modules/module_rubriques";
import { TSpChamp, TSpContexte, TSpMeta, TSpTable } from "./Types";
import { champVisible, cleChamp } from "./dynamicEngine";
import { valeurAffichee } from "./DynamicField";

/** Valeur d'un champ pour impression : libellé de rubrique si applicable,
 *  sinon la valeur formatée (valeurAffichee gère MNT/NUM/PCT/DAT/DTM). */
function valeurImprimee(champ: TSpChamp, v: any): string {
  if (v === null || v === undefined || v === "") return "";
  if (champ.Typ_Controle === "RUBRIQUE" && champ.Rubrique) {
    return findRubrique(champ.Rubrique, v) || String(v);
  }
  if ((champ.Typ_Controle === "DATE" || champ.Typ_Controle === "DATETIME") && !champ.Format_Affichage) {
    const d = v instanceof Date ? v : new Date(v);
    if (isNaN(d.getTime())) return String(v);
    return champ.Typ_Controle === "DATE"
      ? new Intl.DateTimeFormat("fr-FR").format(d)
      : new Intl.DateTimeFormat("fr-FR", { dateStyle: "short", timeStyle: "short" }).format(d);
  }
  return valeurAffichee(champ, v);
}
/** Cellule de grille de détail : formatage léger selon le type déclaré. */
function celluleImprimee(champ: TSpChamp, v: any): string {
  if (v === null || v === undefined || v === "") return "";
  if (champ.Typ_Controle === "RUBRIQUE" && champ.Rubrique) {
    return findRubrique(champ.Rubrique, v) || String(v);
  }
  if (champ.Typ_Controle === "DATE" || champ.Typ_Controle === "DATETIME") {
    const d = v instanceof Date ? v : new Date(v);
    return isNaN(d.getTime()) ? String(v) : new Intl.DateTimeFormat("fr-FR").format(d);
  }
  if (["DEC", "MNT", "INT"].includes(champ.Typ_Controle) || champ.Typ_Controle === "CALCULE") {
    return valeurAffichee(champ, v);
  }
  return String(v);
}

const thStyle: React.CSSProperties = {
  border: "0.5px solid #999", padding: "4px 8px", textAlign: "left",
  background: "#eef4f7", fontSize: "0.85em",
};
const tdStyle: React.CSSProperties = {
  border: "0.5px solid #999", padding: "4px 8px", fontSize: "0.85em",
};

const SpPrintDialog = ({
  meta,
  ctx,
  open,
  onClose,
}: {
  meta: TSpMeta;
  ctx: TSpContexte;
  open: boolean;
  onClose: () => void;
}) => {
  const champsEntete = (meta.champs ?? [])
    .filter((c) => c.Cod_Table === "ENT" && champVisible(c, ctx))
    .sort((a, b) => (a.Ligne ?? 0) - (b.Ligne ?? 0) || (a.Colonne ?? 0) - (b.Colonne ?? 0) || a.Rang - b.Rang);
  const tablesDet = (meta.tables ?? [])
    .filter((t) => t.Role_Table === "DET")
    .sort((a, b) => a.Rang - b.Rang);
  const colonnesDe = (t: TSpTable) =>
    (meta.champs ?? [])
      .filter((c) => c.Cod_Table === t.Cod_Table && c.Nom_Colonne && c.Visible_Grille === "true")
      .sort((a, b) => a.Rang_Grille - b.Rang_Grille);
  const piedsDe = (t: TSpTable) =>
    (meta.champs ?? [])
      .filter((c) => c.Cod_Table === t.Cod_Table && !c.Nom_Colonne && c.Typ_Controle === "CALCULE" && champVisible(c, ctx))
      .sort((a, b) => a.Rang_Grille - b.Rang_Grille);
  return (
    <Dialog open={open} onClose={onClose} maxWidth="md" fullWidth scroll="paper">
      <DialogTitle sx={{ display: "flex", alignItems: "center", gap: "1em" }}>
        <span style={{ flexGrow: 1 }}>Aperçu — {meta.page.Nom_Page}</span>
        <Bouton label="Imprimer" startIcon={<PrintOutlined />} variant="contained"
          onClick={() => window.print()} />
        <IconButton onClick={onClose} size="small"><Close /></IconButton>
      </DialogTitle>
      <DialogContent>
        {/* Feuille de style impression : seule la zone du document est imprimée */}
        <style>{`
          @media print {
            body * { visibility: hidden; }
            .sp-print-zone, .sp-print-zone * { visibility: visible; }
            .sp-print-zone { position: absolute; left: 0; top: 0; width: 100%; padding: 1em; }
          }
        `}</style>
        <div className="sp-print-zone">
          <h2 style={{ margin: "0 0 0.2em 0", color: "#3899b9" }}>{meta.page.Nom_Page}</h2>
          <div style={{ marginBottom: "1em", color: "#555", fontSize: "0.9em" }}>
            N° {ctx.entete?.Num_Doc || "(non enregistré)"}
            {ctx.entete?.Statut ? ` — ${findRubrique("Statut_Signature", ctx.entete.Statut) || ctx.entete.Statut}` : ""}
          </div>
          <table style={{ borderCollapse: "collapse", width: "100%", marginBottom: "1.2em" }}>
            <tbody>
              {champsEntete.map((c) => (
                <tr key={c.Cod_Champ}>
                  <td style={{ ...tdStyle, width: "35%", color: "#555", fontWeight: 600 }}>{c.Libelle}</td>
                  <td style={tdStyle}>{valeurImprimee(c, ctx.entete?.[cleChamp(c)])}</td>
                </tr>
              ))}
            </tbody>
          </table>
          {tablesDet.map((t) => {
            const cols = colonnesDe(t);
            const lignes = ctx.details?.[t.Cod_Table] ?? [];
            if (cols.length === 0) return null;
            return (
              <div key={t.Cod_Table} style={{ marginBottom: "1.2em" }}>
                <h3 style={{ margin: "0 0 0.4em 0", color: "#3899b9", fontSize: "1em" }}>{t.Libelle || t.Cod_Table}</h3>
                <table style={{ borderCollapse: "collapse", width: "100%" }}>
                  <thead>
                    <tr>{cols.map((c) => <th key={c.Cod_Champ} style={thStyle}>{c.Libelle}</th>)}</tr>
                  </thead>
                  <tbody>
                    {lignes.map((l, i) => (
                      <tr key={i}>
                        {cols.map((c) => <td key={c.Cod_Champ} style={tdStyle}>{celluleImprimee(c, l?.[cleChamp(c)])}</td>)}
                      </tr>
                    ))}
                  </tbody>
                </table>
                {piedsDe(t).map((c) => (
                  <div key={c.Cod_Champ} style={{ textAlign: "right", fontWeight: 700, marginTop: "0.4em" }}>
                    {c.Libelle} : {valeurAffichee(c, ctx.entete?.[cleChamp(c)])}
                  </div>
                ))}
              </div>
            );
          })}
        </div>
      </DialogContent>
    </Dialog>
  );
};
export default SpPrintDialog;
