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
import { CloudSyncOutlined, NavigateBefore, NavigateNext, NoteAddOutlined } from "@mui/icons-material";
import GroupBox from "../../components/GroupBox/GroupBox";
import Bouton from "../../components/Bouton/Bouton";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import useEtatListe from "../../hooks/useEtatListe";
import { cntX } from "../../Menu/MenuMain";
import { colorBase } from "../../modules/module_general";
import { ObjetGenerique } from "../../types";
import { TSpChamp, TSpMeta } from "./Types";
import DynamicField from "./DynamicField";

const PAGE_SIZE = 20; // aligné sur la limitation d'affichage de la Grille partagée

const DynamicPage_Liste = ({ codPage }: { codPage: string }) => {
  const navigate = useNavigate();
  const alert = useAlert();
  const myAxios = useAxiosPost();
  const { isSmall, isXs, isSm, isLg, isXl, setShowLoading } = useContext(cntX);
  const { titre: titreUrl } = useParams();
  const titre = titreUrl || codPage;
  // Persistance critères + résultats (sessionStorage, convention des listes)
  const { criteres, stateChange, ds, setDs, dsFields, setDsFields } =
    useEtatListe<ObjetGenerique>(`SPPL_${codPage}`, {});
  const [page, setPage] = useState(1);

  /* ---- Métadonnées (critères générés depuis les champs d'entête) ---- */
  const [meta, setMeta] = useState<TSpMeta | null>(null);
  useEffect(() => {
    myAxios("sp_page_meta", { codPage })
      .then((dt) => { if (dt?.data?.result) setMeta(dt.data.data[0]); })
      .catch(() => {});
  }, [codPage]);
  /** Champs d'entête déclarés comme critères dans le Designer (estCritere). */
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
        .map((c) => ({ ...c, Obligatoire: "false", Etat: "S" as const })),
    [meta]
  );
  const ctx = useMemo(() => ({ entete: criteres ?? {}, details: {} }), [criteres]);

  const interroger = useCallback(
    async (pageDemandee: number = 1) => {
      setShowLoading(true);
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
                  valeur={criteres?.[champ.Nom_Colonne]}
                  ctx={ctx}
                  onchange={stateChange}
                />
              </Grid>
            ))}
          </Grid>
          <div
            style={{
              maxWidth: isXl || isLg ? "24vw" : "80%",
              width: isXl || isLg ? "24vw" : "100%",
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
