import { useContext, useEffect, useMemo, useState } from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import { Box, Typography } from "@mui/material";
import {
  ChevronLeft,
  ChevronRight,
  TodayOutlined,
} from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import { cntX } from "../../Menu/MenuMain";
import { format } from "date-fns";
import { fr } from "date-fns/locale";

/* Planning mensuel des congés par collaborateur : le manager visualise ses
   propres congés et ceux de son équipe, ainsi que les jours fériés définis
   sur la fiche société. */

type TAgentPlanning = {
  Matricule: string;
  Nom_Agent: string;
  Prenom_Agent: string;
  Entite: string;
};
type TConge = {
  Matricule: string;
  Num_Conge: string;
  Dat_Deb_Conge: string;
  Dat_Fin_Conge: string;
  Typ_Conge: string;
  Lib_Type: string;
  Statut: string;
  Lib_Statut: string;
};
type TFerie = { Lib_Jour: string; DatDeb: string; DatFin: string };

const JOURS_SEMAINE = ["lu", "ma", "me", "je", "ve", "sa", "di"];
const LARGEUR_COL_NOM = 210;
const LARGEUR_COL_JOUR = 36;

const cleDate = (d: Date) =>
  `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(
    d.getDate()
  ).padStart(2, "0")}`;

const dateLocale = (s: any) => {
  const d = new Date(s);
  return new Date(d.getFullYear(), d.getMonth(), d.getDate());
};

const RH_Conge_Planning = () => {
  const { isSmall, isXs, isSm, setShowLoading } = useContext(cntX);
  const myAxios = useAxiosPost();
  const dateJour = new Date();
  const debutMoisCourant = new Date(
    dateJour.getFullYear(),
    dateJour.getMonth(),
    1
  );

  const [mois, setMois] = useState<Date>(debutMoisCourant);
  const [matricule, setMatricule] = useState<string>("");
  const [agents, setAgents] = useState<TAgentPlanning[]>([]);
  const [conges, setConges] = useState<TConge[]>([]);
  const [feries, setFeries] = useState<TFerie[]>([]);
  const [jourOuvrables, setJourOuvrables] = useState<string[]>([
    "1", "1", "1", "1", "1", "1", "0",
  ]);

  const nbJours = new Date(mois.getFullYear(), mois.getMonth() + 1, 0).getDate();
  const jours = useMemo(
    () =>
      Array.from(
        { length: nbJours },
        (_, i) => new Date(mois.getFullYear(), mois.getMonth(), i + 1)
      ),
    [mois, nbJours]
  );

  useEffect(() => {
    const datDu = new Date(mois.getFullYear(), mois.getMonth(), 1);
    const datAu = new Date(mois.getFullYear(), mois.getMonth() + 1, 0);
    setShowLoading(true);
    myAxios("conge_planning", {
      Matricule: matricule || "",
      Dat_Du: datDu,
      Dat_Au: datAu,
    })
      .then((dt) => {
        if (dt.data && dt.data?.result) {
          setAgents(dt.data.agents || []);
          setConges(dt.data.conges || []);
          setFeries(dt.data.feries || []);
          setJourOuvrables(dt.data.jourOuvrables || ["1", "1", "1", "1", "1", "1", "0"]);
        } else {
          setAgents([]);
          setConges([]);
          setFeries([]);
        }
      })
      .catch(() => {
        setAgents([]);
        setConges([]);
        setFeries([]);
      })
      .finally(() => setShowLoading(false));
  }, [mois, matricule]);

  // Jours fériés indexés par date (clé yyyy-mm-dd -> libellé de la fête)
  const feriesMap = useMemo(() => {
    const map = new Map<string, string>();
    feries.forEach((f) => {
      let d = dateLocale(f.DatDeb);
      const fin = dateLocale(f.DatFin);
      while (d <= fin) {
        map.set(cleDate(d), f.Lib_Jour);
        d = new Date(d.getFullYear(), d.getMonth(), d.getDate() + 1);
      }
    });
    return map;
  }, [feries]);

  // Congés indexés par collaborateur puis par date
  const congesMap = useMemo(() => {
    const map = new Map<string, Map<string, TConge>>();
    conges.forEach((c) => {
      let d = dateLocale(c.Dat_Deb_Conge);
      const fin = dateLocale(c.Dat_Fin_Conge);
      if (!map.has(c.Matricule)) map.set(c.Matricule, new Map());
      const mapAgent = map.get(c.Matricule)!;
      while (d <= fin) {
        mapAgent.set(cleDate(d), c);
        d = new Date(d.getFullYear(), d.getMonth(), d.getDate() + 1);
      }
    });
    return map;
  }, [conges]);

  const changerMois = (nb: number) =>
    setMois((m) => new Date(m.getFullYear(), m.getMonth() + nb, 1));

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
            minHeight: "6em",
          },
        }}
      >
        <Grid container spacing={3} alignItems="center">
          <Grid xs={12} lg={Agent.TeamLeader ? 7 : 12} xl={Agent.TeamLeader ? 6 : 12}>
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                flexWrap: "wrap",
                gap: "0.6em",
              }}
            >
              <Bouton
                label="Mois précédent"
                title="Mois précédent"
                iconOnly
                variant="outlined"
                startIcon={<ChevronLeft />}
                onClick={() => changerMois(-1)}
              />
              <Typography
                sx={{
                  minWidth: "8em",
                  textAlign: "center",
                  fontWeight: "bold",
                  fontSize: "1.1em",
                  color: "var(--title-color)",
                  textTransform: "capitalize",
                }}
              >
                {format(mois, "MMMM yyyy", { locale: fr })}
              </Typography>
              <Bouton
                label="Mois suivant"
                title="Mois suivant"
                iconOnly
                variant="outlined"
                startIcon={<ChevronRight />}
                onClick={() => changerMois(1)}
              />
              <Bouton
                label="Aujourd'hui"
                title="Revenir au mois courant"
                iconOnly={isXs || isSm}
                variant="outlined"
                startIcon={<TodayOutlined />}
                onClick={() => setMois(debutMoisCourant)}
              />
            </Box>
          </Grid>
          {Agent.TeamLeader && (
            <Grid xs={12} lg={5} xl={4}>
              <TextZoom
                numZoom="MS067"
                nomControle="Matricule"
                label="Collaborateur"
                valeur={matricule}
                findlibelle={{
                  champs: "Nom_Agent+ ' ' +Prenom_Agent",
                  code: "Matricule",
                  tblName: "RH_Agent",
                }}
                onchange={(_nom, valeur) =>
                  setMatricule(typeof valeur === "string" ? valeur : "")
                }
                style={{ width: "100%" }}
              />
            </Grid>
          )}
        </Grid>
      </GroupBox>

      <GroupBox
        label="Planning des congés"
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px",
            width: "100%",
          },
        }}
      >
        <Box sx={{ width: "100%", overflowX: "auto", pb: 1 }}>
          <table
            style={{
              borderCollapse: "separate",
              borderSpacing: 0,
            }}
          >
            <thead>
              <tr>
                <th
                  style={{
                    position: "sticky",
                    left: 0,
                    zIndex: 3,
                    backgroundColor: "var(--bg-input, #ffffff)",
                    color: "var(--title-color)",
                    minWidth: LARGEUR_COL_NOM,
                    maxWidth: LARGEUR_COL_NOM,
                    width: LARGEUR_COL_NOM,
                    padding: "4px 8px",
                    textAlign: "left",
                    borderBottom: `2px solid ${colorBase.colorBase01}`,
                    borderRight: `1px solid rgba(128,128,128,0.4)`,
                  }}
                >
                  Collaborateur
                </th>
                {jours.map((j) => {
                  const cle = cleDate(j);
                  const estFerie = feriesMap.has(cle);
                  const estRepos =
                    jourOuvrables[j.getDay() === 0 ? 6 : j.getDay() - 1] === "0";
                  const estAujourdhui = cle === cleDate(dateJour);
                  return (
                    <th
                      key={cle}
                      title={estFerie ? feriesMap.get(cle) : undefined}
                      style={{
                        minWidth: LARGEUR_COL_JOUR,
                        width: LARGEUR_COL_JOUR,
                        maxWidth: LARGEUR_COL_JOUR,
                        padding: "2px",
                        textAlign: "center",
                        fontSize: "0.75em",
                        borderBottom: `2px solid ${colorBase.colorBase01}`,
                        backgroundColor: estFerie
                          ? "rgba(240,90,10,0.35)"
                          : estRepos
                            ? "rgba(128,128,128,0.15)"
                            : "var(--bg-input, #ffffff)",
                        outline: estAujourdhui
                          ? `2px solid ${colorBase.colorBase03}`
                          : "none",
                        outlineOffset: "-2px",
                        color: "var(--fore-color-base-01)",
                      }}
                    >
                      <div>{JOURS_SEMAINE[j.getDay() === 0 ? 6 : j.getDay() - 1]}</div>
                      <div style={{ fontWeight: "bold" }}>{j.getDate()}</div>
                    </th>
                  );
                })}
              </tr>
            </thead>
            <tbody>
              {agents.length === 0 && (
                <tr>
                  <td
                    colSpan={nbJours + 1}
                    style={{
                      textAlign: "center",
                      padding: "2em",
                      color: "var(--fore-color-base-01)",
                    }}
                  >
                    Aucun collaborateur à afficher
                  </td>
                </tr>
              )}
              {agents.map((ag) => (
                <tr key={ag.Matricule}>
                  <td
                    style={{
                      position: "sticky",
                      left: 0,
                      zIndex: 2,
                      backgroundColor: "var(--bg-input, #ffffff)",
                      minWidth: LARGEUR_COL_NOM,
                      maxWidth: LARGEUR_COL_NOM,
                      width: LARGEUR_COL_NOM,
                      padding: "4px 8px",
                      borderBottom: "1px solid rgba(128,128,128,0.3)",
                      borderRight: `1px solid rgba(128,128,128,0.4)`,
                      color: "var(--fore-color-base-01)",
                    }}
                    title={`${ag.Nom_Agent} ${ag.Prenom_Agent}${ag.Entite ? " - " + ag.Entite : ""}`}
                  >
                    <div
                      style={{
                        overflow: "hidden",
                        textOverflow: "ellipsis",
                        whiteSpace: "nowrap",
                        fontWeight: "bold",
                      }}
                    >
                      {ag.Nom_Agent} {ag.Prenom_Agent}
                    </div>
                    {ag.Entite && (
                      <div
                        style={{
                          overflow: "hidden",
                          textOverflow: "ellipsis",
                          whiteSpace: "nowrap",
                          fontSize: "0.75em",
                          opacity: 0.7,
                        }}
                      >
                        {ag.Entite}
                      </div>
                    )}
                  </td>
                  {jours.map((j) => {
                    const cle = cleDate(j);
                    const ferie = feriesMap.get(cle);
                    const conge = congesMap.get(ag.Matricule)?.get(cle);
                    const estRepos =
                      jourOuvrables[j.getDay() === 0 ? 6 : j.getDay() - 1] === "0";
                    const infobulle = [
                      `${ag.Nom_Agent} ${ag.Prenom_Agent}`,
                      format(j, "dd/MM/yyyy"),
                      conge
                        ? `${conge.Lib_Type} du ${format(
                            dateLocale(conge.Dat_Deb_Conge),
                            "dd/MM/yyyy"
                          )} au ${format(dateLocale(conge.Dat_Fin_Conge), "dd/MM/yyyy")} (${conge.Lib_Statut || conge.Statut})`
                        : "",
                      ferie ? `Férié : ${ferie}` : "",
                    ]
                      .filter((x) => x !== "")
                      .join("\n");
                    return (
                      <td
                        key={cle}
                        title={infobulle}
                        style={{
                          height: "34px",
                          minWidth: LARGEUR_COL_JOUR,
                          width: LARGEUR_COL_JOUR,
                          maxWidth: LARGEUR_COL_JOUR,
                          borderBottom: "1px solid rgba(128,128,128,0.3)",
                          backgroundColor: conge
                            ? conge.Statut === "SS"
                              ? "rgba(94,185,117,0.45)"
                              : colorBase.colorBase02
                            : ferie
                              ? "rgba(240,90,10,0.35)"
                              : estRepos
                                ? "rgba(128,128,128,0.15)"
                                : "transparent",
                          boxShadow:
                            conge && ferie
                              ? `inset 0 -3px 0 0 ${colorBase.colorBase03}`
                              : "none",
                        }}
                      />
                    );
                  })}
                </tr>
              ))}
            </tbody>
          </table>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexWrap: "wrap",
            gap: "1.5em",
            marginTop: "1.5em",
            justifyContent: "center",
          }}
        >
          {[
            { libelle: "Congé validé", couleur: colorBase.colorBase02 },
            { libelle: "Congé en attente", couleur: "rgba(94,185,117,0.45)" },
            { libelle: "Jour férié", couleur: "rgba(240,90,10,0.35)" },
            { libelle: "Repos hebdomadaire", couleur: "rgba(128,128,128,0.15)" },
          ].map((leg) => (
            <Box
              key={leg.libelle}
              sx={{ display: "flex", alignItems: "center", gap: "0.5em" }}
            >
              <span
                style={{
                  display: "inline-block",
                  width: "1.2em",
                  height: "1.2em",
                  backgroundColor: leg.couleur,
                  border: "1px solid rgba(128,128,128,0.4)",
                }}
              />
              <Typography
                sx={{ fontSize: "0.85em", color: "var(--fore-color-base-01)" }}
              >
                {leg.libelle}
              </Typography>
            </Box>
          ))}
        </Box>
      </GroupBox>
    </>
  );
};

export default RH_Conge_Planning;
