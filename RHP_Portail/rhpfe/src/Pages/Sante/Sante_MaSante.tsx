import { useContext, useEffect, useState } from "react";
import { Box } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grille from "../../components/Grille/Grille";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import { Agent } from "../../modules/module_general";
import { cntX } from "../../Menu/MenuMain";

/* Espace "Ma sante au travail" du salarie : ses convocations, sa prochaine
   echeance et les documents explicitement publiables (conclusion d'aptitude
   et restrictions si publiees). AUCUNE donnee clinique. */
const Sante_MaSante = () => {
  const [data, setData] = useState<TMaSante>({ convocations: [], aptitudes: [], prochaine_visite: null });
  const myAxios = useAxiosPost();
  const alert = useAlert();
  const { setShowLoading, isSmall } = useContext(cntX);

  useEffect(() => {
    setShowLoading(true);
    myAxios("ma_sante", {})
      .then((dt) => {
        setShowLoading(false);
        if (dt.data && dt.data?.result) {
          setData(dt.data.data);
        } else {
          setData({ convocations: [], aptitudes: [], prochaine_visite: null });
        }
      })
      .catch(() => setShowLoading(false));
    // Nettoyage des donnees a la sortie de l'ecran (aucune persistance locale)
    return () => setData({ convocations: [], aptitudes: [], prochaine_visite: null });
  }, []);

  const formatDate = (d: any) => {
    if (!d) return "";
    const dt = new Date(d);
    return isNaN(dt.getTime()) ? "" : dt.toLocaleDateString("fr-FR");
  };

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label={"Ma santé au travail — " + (Agent?.Nom || "")} showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={4}>
            <Box sx={{ fontSize: "1.1em", padding: "0.5em" }}>
              <strong>Prochaine visite médicale : </strong>
              {data.prochaine_visite ? formatDate(data.prochaine_visite) : "Non planifiée"}
            </Box>
          </Grid>
        </Grid>
      </GroupBox>

      <GroupBox label="Mes convocations" showBorders={!isSmall} showTitre={true}>
        <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
          <Grille
            readonly={true}
            dataSource={data.convocations.map((c) => ({
              Campagne: c.Campagne,
              "Date convocation": formatDate(c["Date convocation"]),
              Heure: c.Heure || "",
              Statut: c.Statut || "",
            }))}
            className="laGrille"
          />
          {data.convocations.length === 0 && <Box sx={{ padding: "1em" }}>Aucune convocation.</Box>}
        </Box>
      </GroupBox>

      <GroupBox label="Mes aptitudes publiées" showBorders={!isSmall} showTitre={true}>
        <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
          <Grille
            readonly={true}
            dataSource={data.aptitudes.map((a) => ({
              Date: formatDate(a.Dat_Aptitude),
              Aptitude: a.Aptitude || "",
              "Restrictions de poste": a.Restrictions_Poste || "",
              "Fin de validité": formatDate(a.Dat_Fin),
            }))}
            className="laGrille"
          />
          {data.aptitudes.length === 0 && <Box sx={{ padding: "1em" }}>Aucune aptitude publiée.</Box>}
        </Box>
      </GroupBox>
    </Box>
  );
};

export default Sante_MaSante;

type TConvocation = {
  RowId: number;
  Campagne: string;
  "Date convocation": string;
  Heure?: string;
  Statut?: string;
};
type TAptitude = {
  Num_Aptitude: string;
  Dat_Aptitude: string;
  Aptitude?: string;
  Restrictions_Poste?: string;
  Dat_Fin?: string;
};
type TMaSante = {
  convocations: TConvocation[];
  aptitudes: TAptitude[];
  prochaine_visite: string | null;
};
