/* ============================================================================
   Module SP_ - Liste générique des documents d'une page dynamique
   Suit la logique de thème des listes standard (RH_Demande_Conge_Liste) :
   GroupBox "Critères" + boutons Interroger/Nouveau + grille avec lien colonne 0
   + persistance de l'état via useEtatListe.
   URL : /myspace/SPPL_<Cod_Page>/<titre>
   ============================================================================ */
import { useCallback, useContext, useEffect, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Box } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { CloudSyncOutlined, ContentCopyOutlined, DeleteOutline, FileDownloadOutlined, NavigateBefore, NavigateNext, NoteAddOutlined } from "@mui/icons-material";
import * as XLSX from "xlsx";
import GroupBox from "../../components/GroupBox/GroupBox";
import Bouton from "../../components/Bouton/Bouton";
import Grille, { TGrilleActionLigne } from "../../components/Grille/Grille";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import useMsgBox from "../../hooks/useMsgBox";
import useEtatListe from "../../hooks/useEtatListe";
import { cntX } from "../../Menu/MenuMain";
import { colorBase } from "../../modules/module_general";
import { libelleColonne } from "../../modules/module_libelles";
import { ObjetGenerique } from "../../types";
import { TSpChamp, TSpMeta } from "./Types";
import { cleChamp } from "./dynamicEngine";
import DynamicField from "./DynamicField";

const PAGE_SIZE = 20; // aligné sur la limitation d'affichage de la Grille partagée

const DynamicPage_Liste = ({ codPage }: { codPage: string }) => {
  const navigate = useNavigate();
  const alert = useAlert();
  const msgBox = useMsgBox();
  const myAxios = useAxiosPost();
  const { isSmall, isXs, isSm, isLg, isXl, setShowLoading } = useContext(cntX);
  const { titre: titreUrl } = useParams();
  const titre = titreUrl || codPage;
  // Persistance critères + résultats (sessionStorage, convention des listes)
  const { criteres, stateChange, ds, setDs, dsFields, setDsFields } =
    useEtatListe<ObjetGenerique>(`SPPL_${codPage}`, {});
  const [page, setPage] = useState(1);
  // Mode d'action activé par les boutons Dupliquer / Supprimer (icônes par
  // ligne affichées uniquement dans ce mode — UX des grilles de détail)
  const [actionMode, setActionMode] = useState<"" | "dupliquer" | "supprimer">("");

  /* ---- Métadonnées (critères générés depuis les champs d'entête) ---- */
  const [meta, setMeta] = useState<TSpMeta | null>(null);
  useEffect(() => {
    myAxios("sp_page_meta", { codPage })
      .then((dt) => { if (dt?.data?.result) setMeta(dt.data.data[0]); })
      .catch(() => {});
  }, [codPage]);
  /** Champs d'entête déclarés comme critères dans le Designer (estCritere).
   *  Un critère de type DATE/DATETIME est décliné en deux bornes "<col>__Du" /
   *  "<col>__Au" (plage, comme les listes standards) - le serveur traduit en
   *  >= / <= sur la colonne déclarée. */
  const champsCriteres = useMemo<TSpChamp[]>(
    () =>
      (meta?.champs ?? [])
        .filter((c) =>
          c.Cod_Table === "ENT" &&
          c.estCritere === "true" &&
          c.Etat !== "I" &&
          !["CALCULE", "SOURCE", "GED", "CHECK", "RADIO"].includes(c.Typ_Controle)
        )
        .sort((a, b) => (a.Rang_Critere ?? 99) - (b.Rang_Critere ?? 99))
        .flatMap((c) => {
          const base = { ...c, Obligatoire: "false", Etat: "S" as const };
          if (["DATE", "DATETIME"].includes(c.Typ_Controle) && c.Nom_Colonne) {
            return [
              { ...base, Cod_Champ: `${c.Cod_Champ}__Du`, Nom_Colonne: `${c.Nom_Colonne}__Du`, Libelle: `${c.Libelle} (du)` },
              { ...base, Cod_Champ: `${c.Cod_Champ}__Au`, Nom_Colonne: `${c.Nom_Colonne}__Au`, Libelle: `${c.Libelle} (au)` },
            ];
          }
          return [base];
        }),
    [meta]
  );
  const ctx = useMemo(() => ({ entete: criteres ?? {}, details: {} }), [criteres]);

  const interroger = useCallback(
    async (pageDemandee: number = 1) => {
      setShowLoading(true);
      setActionMode(""); // une nouvelle interrogation quitte le mode d'action
      try {
        await myAxios("sp_document_liste", {
          codPage,
          filtres: criteres ?? {},
          page: pageDemandee,
          pageSize: PAGE_SIZE,
        })
          .then((dt) => {
            if (dt?.data?.result) {
              setDs(dt.data.data ?? []);
              setDsFields(dt.data.fields ?? {});
              setPage(dt.data.page ?? pageDemandee);
            } else {
              setDs([]);
              setDsFields({});
              if (dt?.data?.message) alert({ titre: "Liste", msg: dt.data.message, typMsg: "error" });
            }
          })
          .catch(() => {
            setDs([]);
            setDsFields({});
          });
      } finally {
        setShowLoading(false);
      }
    },
    [codPage, criteres]
  );
  useEffect(() => {
    if (meta) interroger(1);
  }, [meta]);

  /* ---- Actions Dupliquer / Supprimer (options de page du Designer, onglet
     « Conception » : Act_Dupliquer / Act_Supprimer + habilitations du profil :
     Creer pour la duplication, Supprimer pour la suppression).
     Même UX que les grilles de détail du document : les boutons à côté
     d'Interroger ACTIVENT un mode ; les icônes par ligne n'apparaissent que
     dans ce mode et disparaissent après l'action (ou ré-interrogation). ---- */
  /** Duplique le document de la ligne en une nouvelle pièce brouillon, puis
   *  l'ouvre pour saisie. */
  const dupliquerDoc = useCallback(
    async (row: ObjetGenerique) => {
      const num = String(row?.["N°"] ?? "");
      if (!num) return;
      try {
        if ((await msgBox({
          titre: "Dupliquer", typMsg: "warning", typReply: "OKCancel",
          msg: `Dupliquer le document ${num} en une nouvelle pièce (brouillon) ?`,
        })) === "Cancel") return;
        const rsl = await myAxios("sp_duplicate_document", { codPage, numDoc: num });
        if (rsl?.data?.result) {
          const numN = rsl.data.numDoc ?? rsl.data.data?.[0]?.Num_Doc;
          alert({ titre: "Dupliquer", msg: `Document dupliqué sous le n° ${numN}.`, typMsg: "success", timeOut: -1 });
          if (numN) navigate(`../myspace/SPP_${codPage}/${titre}/${numN}`);
        } else {
          alert({ titre: "Dupliquer", msg: rsl?.data?.message || "Duplication impossible.", typMsg: "error", timeOut: -10 });
        }
      } finally {
        setActionMode(""); // action terminée (ou annulée) : les icônes disparaissent
      }
    },
    [codPage, titre]
  );
  /** Supprime le document de la ligne (brouillons uniquement — le serveur
   *  refuse toute pièce dont le statut a évolué), puis rafraîchit la liste. */
  const supprimerDoc = useCallback(
    async (row: ObjetGenerique) => {
      const num = String(row?.["N°"] ?? "");
      if (!num) return;
      try {
        if ((await msgBox({
          titre: "Supprimer", typMsg: "warning", typReply: "OKCancel",
          msg: `Êtes-vous sûr de vouloir supprimer définitivement le document ${num} ?`,
        })) === "Cancel") return;
        const rsl = await myAxios("sp_delete_document", { codPage, numDoc: num });
        if (rsl?.data?.result) {
          alert({ titre: "Suppression", msg: "Document supprimé.", typMsg: "success", timeOut: -1 });
          interroger(page);
        } else {
          alert({ titre: "Suppression", msg: rsl?.data?.message || "Suppression impossible.", typMsg: "error", timeOut: -10 });
        }
      } finally {
        setActionMode(""); // action terminée (ou annulée) : les icônes disparaissent
      }
    },
    [codPage, page, interroger]
  );
  // Icône de la ligne, déterminée par le mode actif (une seule action à la fois)
  const actionsLigne = useMemo<TGrilleActionLigne[]>(() => {
    if (actionMode === "dupliquer") {
      return [{
        name: "dupliquer",
        icone: <ContentCopyOutlined fontSize="small" />,
        titre: "Dupliquer ce document",
        couleur: colorBase.colorBase02,
        onClick: ({ row }) => dupliquerDoc(row),
      }];
    }
    if (actionMode === "supprimer") {
      return [{
        name: "supprimer",
        icone: <DeleteOutline fontSize="small" />,
        titre: "Supprimer ce document",
        titreDesactive: "Document déjà soumis : suppression impossible",
        couleur: colorBase.colorBase03,
        // Une pièce dont le statut a évolué (soumise, signée...) ne se
        // supprime pas : seuls les brouillons ('' ou 'NSS') sont supprimables.
        desactivee: (row) => !["", "NSS"].includes(String(row?.["Cod_Statut"] ?? "")),
        onClick: ({ row }) => supprimerDoc(row),
      }];
    }
    return [];
  }, [actionMode, dupliquerDoc, supprimerDoc]);

  /* ---- Export Excel (.xlsx) de la liste FILTRÉE COMPLÈTE : disponible sur
     TOUTES les pages liste (aucune option à activer au Designer). Le serveur
     ré-interroge avec les mêmes critères, plafond 5000 lignes. Même pattern
     que PortalQuery (entêtes = libellés de la grille, valeurs typées, dates
     jj/mm/aaaa). ---- */
  const EXPORT_MAX = 5000;
  const exporterExcel = useCallback(async () => {
    setShowLoading(true);
    try {
      const dt = await myAxios("sp_document_liste", {
        codPage, filtres: criteres ?? {}, page: 1, pageSize: EXPORT_MAX, exporter: true,
      });
      if (!dt?.data?.result) {
        if (dt?.data?.message) alert({ titre: "Exporter", msg: dt.data.message, typMsg: "error" });
        return;
      }
      const data: ObjetGenerique[] = dt.data.data ?? [];
      const fields = dt.data.fields ?? {};
      const cols = Object.entries(fields).filter(([, c]: any) => c?.visible !== false);
      if (data.length === 0 || cols.length === 0) {
        alert({ titre: "Exporter", msg: "Aucune ligne à exporter.", typMsg: "warning" });
        return;
      }
      const estTypDate = (t: string) => t.includes("date") || t.includes("time");
      const estTypNombre = (t: string) =>
        ["int", "bigint", "smallint", "tinyint", "float", "real", "decimal", "numeric", "money"].some((x) => t.startsWith(x));
      // Mêmes entêtes que la grille (libelleColonne quand headerText = nom brut)
      const entetes = cols.map(([nom, c]: any) =>
        c?.headerText && c.headerText !== nom ? c.headerText : libelleColonne(nom)
      );
      const lignes = data.map((row) =>
        cols.map(([nom, c]: any) => {
          const v = row[nom];
          if (v === null || v === undefined) return "";
          const t = String(c?.dataType ?? "").toLowerCase();
          if (estTypDate(t)) { const d = new Date(v); return isNaN(d.getTime()) ? String(v) : d; }
          if (estTypNombre(t)) { const n = Number(v); return isNaN(n) ? String(v) : n; }
          if (t === "bit") return v === true || v === 1 || String(v).toLowerCase() === "true";
          return String(v);
        })
      );
      const ws = XLSX.utils.aoa_to_sheet([entetes, ...lignes], { cellDates: true });
      // Dates au format jj/mm/aaaa + largeurs de colonnes ajustées au contenu
      cols.forEach(([, c]: any, j) => {
        if (!estTypDate(String(c?.dataType ?? "").toLowerCase())) return;
        for (let i = 1; i <= lignes.length; i++) {
          const cell = ws[XLSX.utils.encode_cell({ r: i, c: j })];
          if (cell && cell.t === "d") cell.z = "dd/mm/yyyy";
        }
      });
      ws["!cols"] = cols.map(([nom], j) => ({
        wch: Math.min(50, Math.max(String(entetes[j]).length, ...data.slice(0, 200).map((r) => String(r[nom] ?? "").length)) + 2),
      }));
      const wb = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, "Résultats");
      XLSX.writeFile(wb, `${(meta?.page?.Nom_Page || codPage).replace(/[/\\:*?"<>|]/g, "_")}.xlsx`);
      if (data.length >= EXPORT_MAX) {
        alert({ titre: "Exporter", msg: `Export limité aux ${EXPORT_MAX} premières lignes.`, typMsg: "warning", timeOut: -10 });
      }
    } finally {
      setShowLoading(false);
    }
  }, [codPage, criteres, meta]);

  return (
    <>
      <GroupBox
        label="Critères"
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px",
            width: "100%",
            minHeight: "10em",
          },
        }}
      >
        <>
          <Grid container spacing={5}>
            {champsCriteres.map((champ) => (
              <Grid key={champ.Cod_Champ} xs={12} sm={12} lg={4} xl={3}>
                <DynamicField
                  champ={champ}
                  valeur={criteres?.[cleChamp(champ)]}
                  ctx={ctx}
                  onchange={stateChange}
                />
              </Grid>
            ))}
          </Grid>
          <div
            style={{
              maxWidth: isXl || isLg ? "54vw" : "95%",
              width: isXl || isLg ? "54vw" : "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gap: "1em",
              margin: "3em auto 0.5em auto",
            }}
          >
            <Bouton
              iconOnly={isXs || isSm}
              variant={isXs || isSm ? "contained" : "outlined"}
              sx={{ flexGrow: 1 }}
              label="Interroger"
              startIcon={<CloudSyncOutlined />}
              onClick={() => interroger(1)}
            />
            <Bouton
              label="Nouveau"
              iconOnly={isXs || isSm}
              sx={{ flexGrow: 1 }}
              disabled={!(meta?.droits?.Creer ?? false)}
              startIcon={<NoteAddOutlined />}
              onClick={() => navigate(`../myspace/SPP_${codPage}/${titre}/new`)}
            />
            {/* Dupliquer : option de page (opt-in) + droit Creer — active le
                mode « duplication » (icônes copie sur les lignes) ; reclic = annuler */}
            {(meta?.page?.Act_Dupliquer === "true" && (meta?.droits?.Creer ?? false)) && (
              <Bouton
                label="Dupliquer"
                iconOnly={isXs || isSm}
                variant={actionMode === "dupliquer" ? "contained" : "outlined"}
                sx={{ flexGrow: 1 }}
                disabled={ds.length === 0}
                startIcon={<ContentCopyOutlined />}
                onClick={() => setActionMode((m) => (m === "dupliquer" ? "" : "dupliquer"))}
              />
            )}
            {/* Supprimer : option de page (opt-out, défaut 'true') + droit
                Supprimer — active le mode « suppression » (icônes poubelle) ;
                reclic = annuler */}
            {(meta?.page?.Act_Supprimer !== "false" && (meta?.droits?.Supprimer ?? false)) && (
              <Bouton
                label="Supprimer"
                iconOnly={isXs || isSm}
                variant={actionMode === "supprimer" ? "contained" : "outlined"}
                color="error"
                sx={{ flexGrow: 1 }}
                disabled={ds.length === 0}
                startIcon={<DeleteOutline />}
                onClick={() => setActionMode((m) => (m === "supprimer" ? "" : "supprimer"))}
              />
            )}
            {/* Exporter : disponible sur TOUTES les pages liste (sans option
                à activer) — export Excel de la liste filtrée complète
                (plafond 5000 lignes) */}
            <Bouton
              label="Exporter"
              iconOnly={isXs || isSm}
              variant="outlined"
              sx={{ flexGrow: 1 }}
              disabled={ds.length === 0}
              startIcon={<FileDownloadOutlined />}
              onClick={exporterExcel}
            />
          </div>
        </>
      </GroupBox>
      <Box
        sx={{
          margin: "auto",
          padding: "2em 5px",
          width: "100%",
          overflow: "scroll",
        }}
      >
        <Grille
          readonly={true}
          dataSource={ds}
          Colonnes={dsFields}
          className="laGrille"
          actionsLigne={actionsLigne}
          onclick={({ colIndex, value }) => {
            if (colIndex === 0 && value) {
              navigate(`../myspace/SPP_${codPage}/${titre}/${value}`);
            }
          }}
          sx={{
            "& .cl0": {
              width: "100px !important",
              cursor: "pointer !important",
              "&:hover": {
                color: colorBase.colorBase02,
                fontStyle: "bold",
                textDecoration: "underline",
              },
            },
          }}
        />
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            gap: "0.5em",
            mt: "0.5em",
            color: "text.secondary",
            fontSize: "0.9em",
          }}
        >
          <Bouton label="" iconOnly startIcon={<NavigateBefore />} disabled={page <= 1} onClick={() => interroger(page - 1)} />
          <span>Page {page}</span>
          <Bouton label="" iconOnly startIcon={<NavigateNext />} disabled={ds.length < PAGE_SIZE} onClick={() => interroger(page + 1)} />
        </Box>
      </Box>
    </>
  );
};
export default DynamicPage_Liste;
