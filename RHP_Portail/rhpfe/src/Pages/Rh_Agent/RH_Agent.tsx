import Box from "@mui/material/Box";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import "./rh_agent.scss";
import WidgetsIcon from "@mui/icons-material/Widgets";
import { ICompetence, ObjetGenerique, TMenuBtn } from "../../types";
import { useContext, useEffect, useState } from "react";
import { cntX } from "../../Menu/MenuMain";
import useMsgBox from "../../hooks/useMsgBox";
import TextBox from "../../components/TextBox/TextBox";
import {
  Avatar,
  Divider,
  FormControlLabel,
  Switch,
  Tab,
  Tabs,
} from "@mui/material";
import GroupBox from "../../components/GroupBox/GroupBox";
import useAxiosPost from "../../hooks/useAxiosPost";
import Competence from "../../components/Competence/Competence";
import Grille from "../../components/Grille/Grille";
import { Agent, colorBase } from "../../modules/module_general";
import { fromByteArray } from "base64-js";
const RH_Agent = ({ readonly = false }: { readonly?: boolean }) => {
  const myAxios = useAxiosPost();
  const { settbnMenu, isSmall } = useContext(cntX);
  const msgbox = useMsgBox();
  const [rhAgent, setRhAgent] = useState<IRH_Agent>(initialState);
  const [rhCompetence, setRhCompetence] = useState<ICompetence[]>([]);
  const [rhFormation, setRhFormation] = useState<ObjetGenerique[]>([]);
  const [experiences, setExperiences] = useState<ObjetGenerique[]>([]);
  const [famille, setFamille] = useState<ObjetGenerique[]>([]);
  const [paie, setPaie] = useState<ObjetGenerique[]>([]);
  const [selectedTab, setSelectedTab] = useState<number>(0);
  const tbnMenu: TMenuBtn[] = [
    {
      name: "Enregisrer",
      disabled: true,
      libelle: "Enregisrer",
      action: () => Enregistrer(),
      icon: <WidgetsIcon />,
    },
    {
      name: "Nouveau",
      disabled: false,
      libelle: "Nouveau",
      action: () => Nouveau(),
      icon: <WidgetsIcon />,
    },
    {
      name: "Supprimer",
      disabled: true,
      libelle: "Supprimer",
      action: () => console.log("Supprimer"),
      icon: <WidgetsIcon />,
    },
    {
      name: "Autres",
      disabled: false,
      libelle: "Autres",
      action: () => console.log("Autres"),
      icon: <WidgetsIcon />,
    },
  ];
  function stateChange(champs: string, valeur: any) {
    setRhAgent((agt: IRH_Agent) => {
      return { ...agt, [champs]: valeur };
    });
  }
  useEffect(() => {
    settbnMenu(tbnMenu);
  }, [Nouveau]);
  useEffect(() => {
    myAxios("rh_agent", { Matricule: rhAgent?.Matricule })
      .then((dt) => {
        if (dt.data.result) {
          setRhAgent(dt.data.data.agent[0]);
          setRhCompetence(dt.data.data.competences);
          setRhFormation(dt.data.data.formations);
          setExperiences(dt.data.data.experiences);
          setFamille(dt.data.data.famille);
          setPaie(dt.data.data.paie);
        } else {
          setRhAgent({});
          setRhCompetence([]);
          setRhFormation([]);
          setExperiences([]);
          setFamille([]);
          setPaie([]);
        }
      })
      .catch((err) => {
        console.log(err);
        setRhAgent({});
        setRhCompetence([]);
        setRhFormation([]);
        setExperiences([]);
        setFamille([]);
        setPaie([]);
      });
  }, [rhAgent?.Matricule]);
  function Enregistrer() {
    msgbox({
      titre: "Enregistrer",
      msg: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Distinctio, quisquam. Alias aliquam quibusdam sapiente suscipit sed ab tempora. Vero veritatis quis animi, quaerat voluptatum perferendis odio nulla ad asperiores deserunt.",
      typMsg: "warning",
      typReply: "YesNoCancel",
      handleOk: async () => {
        console.log("first ok");
      },
      handleCancel: async () => {
        console.log("second cancel");
      },
    });
  }
  function Nouveau() {
    setSelectedTab(0);
    setRhAgent({});
    setRhCompetence([]);
    setRhFormation([]);
    setExperiences([]);
    setFamille([]);
    setPaie([]);
  }
  return (
    <div className="rh_Agent" style={{ width: "100%" }}>
      {!isSmall && (
        <Box
          sx={{
            borderBottom: 1,
            borderColor: "divider",
            mb: "1em",
          }}
        >
          <Tabs
            value={selectedTab}
            onChange={(event: React.SyntheticEvent, newValue: number) => {
              setSelectedTab(newValue);
            }}
            variant="scrollable"
            scrollButtons="auto"
          >
            {tabPages.map((t, ind) => (
              <Tab key={ind} label={t} />
            ))}
          </Tabs>
        </Box>
      )}
      <GroupBox
        showTitre={isSmall}
        id="fiche"
        display={selectedTab === 0 || isSmall ? undefined : "none"}
        label={tabPages[0]}
      >
        <>
          <Grid container columnSpacing={3} rowSpacing={5}>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <div style={{ display: "flex", gap: "10px" }}>
                <TextZoom
                  numZoom="MS067"
                  nomControle="Matricule"
                  label="Matricule"
                  valeur={rhAgent?.Matricule || Agent.Matricule}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
                <ComboBox
                  readOnly={true}
                  rubrique="Civilite_Combo"
                  nomControle="Civilite"
                  label="Civilité"
                  valeur={rhAgent?.Civilite || ""}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
              </div>
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <TextBox
                nomControle="Nom_Agent"
                label="Nom"
                valeur={rhAgent?.Nom_Agent}
                readonly={true}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <TextBox
                nomControle="Prenom_Agent"
                label="Prénom"
                valeur={rhAgent?.Prenom_Agent}
                readonly={true}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={12} xl={12}>
              {rhAgent?.Photo && (
                <Avatar
                  sx={{
                    height: photoDimensions,
                    width: photoDimensions,
                    margin: "auto",
                  }}
                  src={`data:image/png;base64,${fromByteArray(
                    rhAgent?.Photo.data
                  )}`}
                  alt="agent"
                />
              )}
            </Grid>
          </Grid>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Affectation organisationnelle
          </Divider>
          <Grid container columnSpacing={3} rowSpacing={5}>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <TextBox
                nomControle="Titre"
                label="Titre"
                valeur={rhAgent?.Titre}
                readonly={true}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <ComboBox
                readOnly={true}
                numZoom="MS016"
                nomControle="Cod_Poste"
                label="Poste"
                valeur={rhAgent?.Cod_Poste || ""}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <ComboBox
                readOnly={true}
                numZoom="MS015"
                nomControle="Cod_Grade"
                label="Grade"
                valeur={rhAgent?.Cod_Grade || ""}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>{" "}
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <ComboBox
                readOnly={true}
                numZoom="MS010"
                nomControle="Cod_Entite"
                label="Entité"
                valeur={rhAgent?.Cod_Entite || ""}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
          </Grid>

          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Fiche personnelle
          </Divider>
          <Grid container columnSpacing={3} rowSpacing={5}>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <div style={{ display: "flex", gap: "10px" }}>
                <CalendarZoom
                  readOnly={true}
                  nomControle="Dat_Naissance"
                  label="Né le"
                  valeur={rhAgent?.Dat_Naissance || ""}
                  onchange={stateChange}
                  sx={{ width: "100%" }}
                  onClear={() => stateChange("Dat_Naissance", "")}
                />
                <ComboBox
                  readOnly={true}
                  numZoom="MS145"
                  conditionZoom="Cod_Pays='MAR'"
                  nomControle="Lieu_Naissance"
                  label="A"
                  valeur={rhAgent?.Lieu_Naissance || ""}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
              </div>
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <div style={{ display: "flex", gap: "10px" }}>
                <ComboBox
                  readOnly={true}
                  rubrique="Situation"
                  nomControle="Situation"
                  label="Situation"
                  valeur={rhAgent?.Situation || ""}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
                <TextBox
                  readonly={true}
                  nomControle="Nbr_Personne_A_Charge"
                  label="Personnes à charges"
                  type="integer"
                  valeur={rhAgent?.Nbr_Personne_A_Charge}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
              </div>
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <div style={{ display: "flex", gap: "10px" }}>
                <TextBox
                  readonly={true}
                  nomControle="CIN_Agent"
                  label="N° CIN"
                  type="cin"
                  valeur={rhAgent?.CIN_Agent}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
                <TextBox
                  readonly={true}
                  nomControle="NumCE"
                  label="Carte etranger"
                  valeur={rhAgent?.NumCE}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
              </div>
            </Grid>
          </Grid>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Coordonnées
          </Divider>
          <Grid container columnSpacing={3} rowSpacing={5}>
            <Grid xs={12} sm={8} md={6}>
              <TextBox
                nomControle="Adresse"
                label="Adresse"
                valeur={rhAgent?.Adresse}
                readonly={true}
                onchange={stateChange}
                multiline={isSmall}
                rows={4}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <ComboBox
                readOnly={true}
                numZoom="MS145"
                conditionZoom="Cod_Pays='MAR'"
                nomControle="Cod_Ville"
                label="Ville"
                valeur={rhAgent?.Cod_Ville || ""}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid
              xs={12}
              sm={6}
              md={4}
              xl={3}
              display="flex"
              justifyContent="space-between"
              alignItems="center"
              gap={2}
            >
              <TextBox
                readonly={true}
                nomControle="Gsm"
                label="Tél 1"
                valeur={rhAgent?.Gsm}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
              <TextBox
                readonly={true}
                nomControle="Fixe"
                label="Tél 2"
                valeur={rhAgent?.Fixe}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={6} lg={4} xl={3}>
              <TextBox
                nomControle="Mail"
                label="Mail"
                type="email"
                valeur={rhAgent?.Mail}
                readonly={true}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
          </Grid>
        </>
      </GroupBox>
      <GroupBox
        showTitre={isSmall}
        display={selectedTab === 1 || isSmall ? undefined : "none"}
        label={tabPages[1]}
      >
        <>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Compétences
          </Divider>
          <Box sx={{ display: "flex", flexWrap: "wrap", gap: 1 }}>
            {rhCompetence.map((cpt: ICompetence) => (
              <Competence
                competence={cpt.Competence}
                key={cpt.Competence}
                intitule={cpt.Intitule}
                note={cpt.Note}
                showNote={true}
              />
            ))}
          </Box>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Parcours académique
          </Divider>
          <Box
            sx={{
              margin: "auto",
              width: {
                xs: "96vw",
                sm: "96vw",
                md: "60vw",
                lg: "50vw",
                xl: "50vw",
              },
              overflow: "scroll",
            }}
          >
            <Grille
              readonly={true}
              dataSource={rhFormation}
              sx={{ "&.cl1": { display: "none" } }}
            />
          </Box>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Parcours professionnel
          </Divider>
          <Box
            sx={{
              margin: "auto",
              width: {
                xs: "96vw",
                sm: "96vw",
                md: "60vw",
                lg: "50vw",
                xl: "50vw",
              },
              overflow: "scroll",
            }}
          >
            <Grille readonly={true} dataSource={experiences} />
          </Box>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Famille
          </Divider>
          <Box
            sx={{
              margin: "auto",
              width: {
                xs: "96vw",
                sm: "96vw",
                md: "60vw",
                lg: "50vw",
                xl: "50vw",
              },
              overflow: "scroll",
            }}
          >
            <Grille
              readonly={true}
              dataSource={famille}
              sx={{ "&.cl1": { display: "none" } }}
            />
          </Box>
        </>
      </GroupBox>
      <GroupBox
        showTitre={isSmall}
        display={selectedTab === 2 || isSmall ? undefined : "none"}
        label={tabPages[2]}
      >
        <Grid container columnSpacing={3} rowSpacing={5}>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <ComboBox
              readOnly={true}
              rubrique="Typ_Agent"
              nomControle="Typ_Agent"
              label="Type agent"
              valeur={rhAgent?.Typ_Agent || ""}
              onchange={stateChange}
              style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <ComboBox
              readOnly={true}
              rubrique="Typ_Contrat"
              nomControle="Typ_Contrat"
              label="Type contrat"
              valeur={rhAgent?.Typ_Contrat || ""}
              onchange={stateChange}
              style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <ComboBox
              readOnly={true}
              rubrique="Typ_Periode"
              nomControle="Typ_Periode"
              label="Type période"
              valeur={rhAgent?.Typ_Periode || ""}
              onchange={stateChange}
              style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <ComboBox
              readOnly={true}
              numZoom="MS069"
              nomControle="Plan_Paie"
              label="Plan de paie"
              valeur={rhAgent?.Plan_Paie || ""}
              onchange={stateChange}
              style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <CalendarZoom
              readOnly={true}
              nomControle="Dat_Entree"
              label="Date entrée"
              valeur={rhAgent?.Dat_Entree || ""}
              onchange={stateChange}
              sx={{ width: "100%" }}
              onClear={() => stateChange("Dat_Entree", "")}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <CalendarZoom
              readOnly={true}
              nomControle="Dat_Confirmation"
              label="Date confirmation"
              valeur={rhAgent?.Dat_Confirmation || ""}
              onchange={stateChange}
              sx={{ width: "100%" }}
              onClear={() => stateChange("Dat_Confirmation", "")}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <FormControlLabel
              control={
                <Switch
                  checked={rhAgent?.Droit_Paie || false}
                  style={{
                    color: colorBase.colorBase01,
                  }}
                  onChange={(event: React.ChangeEvent<HTMLInputElement>) =>
                    stateChange("Droit_Paie", event.target.checked)
                  }
                />
              }
              label="Droit à la paie"
            />
          </Grid>
          <Grid xs={12} sm={6} lg={4} xl={3}>
            <CalendarZoom
              readOnly={true}
              nomControle="Dat_Fin_Contrat"
              label="Date fin de contrat"
              valeur={rhAgent?.Dat_Fin_Contrat || ""}
              onchange={stateChange}
              sx={{ width: "100%" }}
              onClear={() => stateChange("Dat_Fin_Contrat", "")}
            />
          </Grid>
          {rhAgent?.Dat_Sortie && (
            <>
              <Grid xs={12} sm={6} lg={4} xl={3}>
                <CalendarZoom
                  readOnly={true}
                  nomControle="Dat_Sortie"
                  label="Date sortie"
                  valeur={rhAgent?.Dat_Sortie || ""}
                  onchange={stateChange}
                  sx={{ width: "100%" }}
                  onClear={() => stateChange("Dat_Sortie", "")}
                />
              </Grid>
              <Grid xs={12} sm={6} lg={4} xl={3}>
                <ComboBox
                  readOnly={true}
                  rubrique="Motif_Depart"
                  nomControle="Motif_Depart"
                  label="Motif"
                  valeur={rhAgent?.Motif_Depart || ""}
                  onchange={stateChange}
                  style={{ width: "100%" }}
                />
              </Grid>
            </>
          )}
        </Grid>
      </GroupBox>
      <GroupBox
        showTitre={isSmall}
        display={selectedTab === 3 || isSmall ? undefined : "none"}
        label={tabPages[1]}
      >
        <>
          <Divider
            sx={{
              m: "3em 0",
              color: colorBase.colorBase02,
              fontWeight: "bold",
            }}
          >
            Détail des éléments de la paie
          </Divider>
          <Box
            sx={{
              margin: "auto",
              width: {
                xs: "96vw",
                sm: "96vw",
                md: "60vw",
                lg: "50vw",
                xl: "50vw",
              },
              overflow: "scroll",
            }}
          >
            <Grille
              readonly={true}
              dataSource={paie}
              className="grille-paie"
              sx={{
                margin: "auto",
                minWidth: "0px !important",
                width: "450px",
                display: "flex;",
                justifyContent: "center;",
                alignItems: "center;",
                "& .grille": { width: "450px", margin: "auto" },
                "& .cl1": { width: "150px" },
                "& .cl0": { width: "300px" },
              }}
            />
          </Box>
        </>
      </GroupBox>
    </div>
  );
};

export default RH_Agent;
const photoDimensions = { xs: "80vw", sm: "45vw", md: "35vw", lg: "300px" };
interface IRH_Agent {
  Matricule?: string;
  Nom_Agent?: string;
  Prenom_Agent?: string;
  Sexe?: string;
  Nationalite?: string;
  Civilite?: string;
  Adresse?: string;
  Cod_Ville?: string;
  Cod_Pays?: string;
  Cod_Pst?: string;
  Fixe?: string;
  Gsm?: string;
  Mail?: string;
  Situation?: string;
  Dat_Naissance?: Date;
  Lieu_Naissance?: string;
  CIN_Agent?: string;
  NumCE?: string;
  NumPPR?: string;
  NumIF?: string;
  Typ_Agent?: string;
  Typ_Contrat?: string;
  Plan_Paie?: string;
  Dat_Entree?: Date;
  Dat_Confirmation?: string;
  Dat_Sortie?: Date;
  Dat_Fin_Contrat?: Date;
  Droit_Paie?: boolean;
  Typ_Periode?: string;
  Motif_Depart?: string;
  Commentaire?: string;
  Affectation?: string;
  Titre?: string;
  Cod_Poste?: string;
  Cod_Grade?: string;
  Cod_Entite?: string;
  Affectation_1?: string;
  Affectation_2?: string;
  Nbr_Personne_A_Charge?: number;
  CNSS?: string;
  Organisme?: string;
  Organisme1?: string;
  Organisme2?: string;
  Organisme3?: string;
  Organisme4?: string;
  Droit_Conge_Mensuel?: number;
  Photo?: any;
  PW?: string;
  is_Temp?: boolean;
  Suppleant?: string;
  Suppleant_Du?: Date;
  Suppleant_Au?: Date;
  Designated_By?: string;
  submitAcceptation?: boolean;
  Accepted?: boolean;
  Notified?: boolean;
  Dat_Notif?: Date;
  Cod_Simulation?: string;
  Domaines_Competence?: string;
  Ref_Candidature?: string;
}
const initialState: IRH_Agent = {
  Matricule: Agent.Matricule,
  Nom_Agent: "",
  Prenom_Agent: "",
  Sexe: "",
  Nationalite: "",
  Civilite: "Mr",
  Adresse: "",
  Cod_Ville: "CASAB",
  Cod_Pays: "MAR",
  Cod_Pst: "",
  Fixe: "",
  Gsm: "",
  Mail: "",
  Situation: "C",
  Lieu_Naissance: "",
  CIN_Agent: "",
  NumCE: "",
  NumPPR: "",
  NumIF: "",
  Typ_Agent: "",
  Typ_Contrat: "",
  Plan_Paie: "",
  Dat_Confirmation: "",
  Droit_Paie: false,
  Typ_Periode: "",
  Motif_Depart: "",
  Commentaire: "",
  Affectation: "",
  Titre: "",
  Cod_Poste: "",
  Cod_Grade: "",
  Cod_Entite: "",
  Affectation_1: "",
  Affectation_2: "",
  Nbr_Personne_A_Charge: 0,
  CNSS: "",
  Organisme: "",
  Organisme1: "",
  Organisme2: "",
  Organisme3: "",
  Organisme4: "",
  Droit_Conge_Mensuel: 0,
  Photo: "",
  PW: "",
  is_Temp: false,
  Suppleant: "",
  Designated_By: "",
  submitAcceptation: false,
  Accepted: false,
  Notified: false,
  Cod_Simulation: "",
  Domaines_Competence: "",
  Ref_Candidature: "",
};
const tabPages = ["Fiche agent", "Profil", "Contrat", "Rémunération"];
