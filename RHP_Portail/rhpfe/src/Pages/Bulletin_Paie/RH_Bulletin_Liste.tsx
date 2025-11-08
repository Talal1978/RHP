import { useContext, useEffect, useState } from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import { Box } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
import { CloudSyncOutlined, PrintOutlined } from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate } from "react-router-dom";
import { cntX } from "../../Menu/MenuMain";
import useMsgBox from "../../hooks/useMsgBox";
import { TReport } from "../../Report/ReportViewer";

const RH_Bulletin_Liste = () => {
  const navigate = useNavigate();
  const msgBox = useMsgBox();
  const [criteres, setCriteres] = useState<TCriteres>(initialiserCriteres);
  const [ds, setDs] = useState<ObjetGenerique[]>([]);
  const [dsFields, setDsFields] = useState<TColonneCollection>({});
  const { isSmall, isXs, isSm, isMd, isLg, isXl } = useContext(cntX);
  function stateChange(champs: string, valeur: any) {
    setCriteres((crt: TCriteres) => {
      return { ...crt, [champs]: valeur };
    });
  }
  const date = new Date();
  const myAxios = useAxiosPost();
  useEffect(() => {
    setDs([]);
  }, [JSON.stringify(criteres)]);
  return (
    <>
      <GroupBox
        label="Critères"
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px",
            width: "90vw",
            minHeight: "10em",
          },
        }}
      >
        <>
          <Grid container spacing={5}>
            <Grid xs={12} sm={12} lg={4} xl={3}>
              <TextZoom
                numZoom="MS067"
                nomControle="Matricule"
                label="Matricule"
                valeur={criteres?.Matricule}
                findlibelle={{
                  champs: "Nom_Agent+ ' ' +Prenom_Agent",
                  code: "Matricule",
                  tblName: "RH_Agent",
                }}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={4}>
              <Box
                sx={{
                  display: "flex",
                  paddingRight: "5px",
                  gap: { xs: "5px", sm: "1em", md: "1.5em", lg: "2em" },
                }}
              >
                <CalendarZoom
                  nomControle="Dat_Du"
                  label="Du"
                  valeur={
                    criteres?.Dat_Du ||
                    new Date(
                      date.getFullYear(),
                      date.getMonth() - 1,
                      date.getDate()
                    )
                  }
                  onchange={stateChange}
                  sx={{
                    width: "100%",
                    "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                  }}
                  onClear={() => stateChange("Dat_Du", "")}
                />
                <CalendarZoom
                  nomControle="Dat_Au"
                  label="Au"
                  valeur={criteres?.Dat_Au || date}
                  onchange={stateChange}
                  sx={{
                    width: "100%",
                    "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                  }}
                  onClear={() => stateChange("Dat_Au", "")}
                />
              </Box>
            </Grid>
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
              onClick={() => {
                myAxios("bulletin_liste", criteres)
                  .then((dt) => {
                    if (dt.data && dt.data?.result) {
                      setDs(dt.data.data);
                      setDsFields(dt.data.fields);
                    } else {
                      setDs([]);
                      setDsFields({});
                    }
                  })
                  .catch((err) => {
                    console.log(err);
                    setDs([]);
                    setDsFields({});
                  });
              }}
            />
            <Bouton
              iconOnly={isXs || isSm}
              variant={isXs || isSm ? "contained" : "outlined"}
              sx={{ flexGrow: 1 }}
              label="Imprimer"
              startIcon={<PrintOutlined />}
              onClick={() => {
                navigate("/viewer", {
                  state: {
                    reportName: "Modele_Bulletin",
                    params: {
                      CodPlan: "",
                      MatDeb: criteres.Matricule,
                      MatFin: criteres.Matricule,
                      DatDeb: criteres.Dat_Du || "01/01/2020",
                      DatFin: criteres.Dat_Au || "31/12/2050",
                      CodPreparation: "",
                    },
                  } as TReport,
                });
              }}
            />
          </div>
        </>
      </GroupBox>
      <Box
        sx={{
          margin: "auto",
          padding: "2em 5px",
          width: {
            xs: "70vw",
            sm: "70vw",
            md: "30vw",
          },
          overflow: "scroll",
          //   " ::-webkit-scrollbar": {
          //     display: "none",
          //   },
          //   msOverflowStyle: "none",
          //   scrollbarWidth: "none",
        }}
      >
        <Grille
          readonly={true}
          dataSource={ds}
          Colonnes={dsFields}
          className="laGrille"
          onclick={({ colIndex, value }) => {
            if (colIndex === 0) {
              navigate("/viewer", {
                state: {
                  reportName: "Modele_Bulletin",
                  params: {
                    CodPlan: "",
                    MatDeb: criteres.Matricule,
                    MatFin: criteres.Matricule,
                    DatDeb: criteres.Dat_Du || "01/01/2020",
                    DatFin: criteres.Dat_Au || "31/12/2050",
                    CodPreparation: value,
                  },
                } as TReport,
              });
            }
          }}
          sx={{
            // width: "auto !important",
            "& .cl0": {
              width: "100px !important",
              maxWidth: "100px !important",
              cursor: "pointer !important",
              "&:hover": {
                color: colorBase.colorBase02,
                fontStyle: "bold",
                textDecoration: "underline",
              },
            },
          }}
        />
      </Box>
    </>
  );
};

export default RH_Bulletin_Liste;
type TCriteres = {
  Matricule?: string;
  Dat_Du?: Date | null;
  Dat_Au?: Date | null;
};
const initialiserCriteres: TCriteres = {
  Matricule: Agent.Matricule,
  Dat_Du: null,
  Dat_Au: null,
};
