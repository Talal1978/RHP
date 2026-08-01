import { useContext, useEffect, useState } from "react";
import { Box } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grille from "../../components/Grille/Grille";
import useAxiosPost from "../../hooks/useAxiosPost";
import { cntX } from "../../Menu/MenuMain";

/* Tableau de bord sante au travail (SANTE_ADMIN) : agregats seuilles
   (anti-reidentification), aucune donnee nominative ni clinique. */
const RH_Sante_Tableau_Bord = () => {
  const [data, setData] = useState<TTB | null>(null);
  const myAxios = useAxiosPost();
  const { setShowLoading, isSmall } = useContext(cntX);

  const load = () => {
    setShowLoading(true);
    myAxios("sante_tableau_bord", {})
      .then((dt) => {
        setShowLoading(false);
        if (dt.data && dt.data?.result) setData(dt.data.data);
        else setData(null);
      })
      .catch(() => setShowLoading(false));
  };

  useEffect(() => {
    load();
  }, []);

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label={"Tableau de bord santé au travail (agrégats masqués < " + (data?.seuil ?? 5) + " agents)"} showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={6} sm={4} lg={2}>
            <Box sx={{ textAlign: "center", padding: "1em", border: "1px solid var(--color-base-02)", borderRadius: "8px" }}>
              <Box sx={{ fontSize: "2em", fontWeight: "bold" }}>{data?.at_en_cours ?? "—"}</Box>
              <Box>AT en cours</Box>
            </Box>
          </Grid>
          <Grid xs={6} sm={4} lg={2}>
            <Box sx={{ textAlign: "center", padding: "1em", border: "1px solid var(--color-base-02)", borderRadius: "8px" }}>
              <Box sx={{ fontSize: "2em", fontWeight: "bold", color: (data?.etapes_en_retard ?? 0) > 0 ? "error.main" : "inherit" }}>{data?.etapes_en_retard ?? "—"}</Box>
              <Box>Étapes AT en retard</Box>
            </Box>
          </Grid>
        </Grid>
      </GroupBox>

      <GroupBox label="Effectif par statut d'aptitude et situation" showBorders={!isSmall} showTitre={true}>
        <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
          <Grille
            readonly={true}
            dataSource={(data?.aptitudes || []).map((a) => ({
              "Statut d'aptitude": a.Statut_Aptitude,
              Situation: a.Situation,
              Effectif: a.Effectif === null ? "< " + (data?.seuil ?? 5) : a.Effectif,
            }))}
            className="laGrille"
          />
        </Box>
      </GroupBox>

      <GroupBox label="Visites de l'année par type" showBorders={!isSmall} showTitre={true}>
        <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
          <Grille
            readonly={true}
            dataSource={(data?.visites_par_type || []).map((v) => ({
              Type: v.Type,
              Nombre: v.Nb,
            }))}
            className="laGrille"
          />
        </Box>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Tableau_Bord;

type TApt = { Statut_Aptitude: string; Situation: string; Effectif: number | null };
type TVisite = { Type: string; Nb: number };
type TTB = {
  seuil: number;
  aptitudes: TApt[];
  visites_par_type: TVisite[];
  at_en_cours: number;
  etapes_en_retard: number;
};
