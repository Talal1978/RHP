import { useContext, useEffect, useState } from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import { Box } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
import { CloudSyncOutlined, NoteAddOutlined } from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate } from "react-router-dom";
import { cntX } from "../../Menu/MenuMain";
const Demande_Pret_Liste = () => {
  const navigate = useNavigate();
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
            <Grid xs={12} sm={12} lg={4} xl={3}>
              <TextZoom
                numZoom="MS010"
                nomControle="Cod_Entite"
                label="Entité"
                valeur={criteres?.Cod_Entite}
                findlibelle={{
                  champs: "Lib_Entite",
                  code: "Cod_Entite",
                  tblName: "Org_Entite",
                }}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={8} sm={12} lg={3} xl={2}>
              <ComboBox
                rubrique="Statut_Signature"
                nomControle="Statut"
                label="Statut"
                valeur={criteres?.Statut || ""}
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
                myAxios("dossier_maladie_liste", criteres)
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

                    setDs([]);
                    setDsFields({});
                  });
              }}
            />
            <Bouton
              label="Nouveau"
              iconOnly={isXs || isSm}
              sx={{ flexGrow: 1 }}
              startIcon={<NoteAddOutlined />}
              onClick={() => {
                navigate(
                  `../myspace/RH_Dossier_Maladie/Dossiers de maladie/new`
                );
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
            xs: "96vw",
            sm: "96vw",
            md: "80vw",
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
              navigate(
                `../myspace/RH_Dossier_Maladie/Dossiers de maladie/${value}`
              );
            }
          }}
          sx={{
            // width: "auto !important",
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
      </Box>
    </>
  );
};

export default Demande_Pret_Liste;
type TCriteres = {
  Matricule?: string;
  Cod_Entite?: string;
  Statut?: string;
  Dat_Du?: Date | null;
  Dat_Au?: Date | null;
};
const initialiserCriteres: TCriteres = {
  Matricule: Agent.Matricule,
  Cod_Entite: Agent.Cod_Entite,
  Statut: "",
  Dat_Du: null,
  Dat_Au: null,
};
