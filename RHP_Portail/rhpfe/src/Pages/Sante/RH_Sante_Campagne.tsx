import { useContext, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Grid from "@mui/material/Unstable_Grid2";
import { Box } from "@mui/material";
import GroupBox from "../../components/GroupBox/GroupBox";
import TextZoom from "../../components/TextZoom/TextZoom";
import TextBox from "../../components/TextBox/TextBox";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import Bouton from "../../components/Bouton/Bouton";
import Grille from "../../components/Grille/Grille";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { cntX } from "../../Menu/MenuMain";
import { TMenuBtn } from "../../types";
import { SaveAsOutlined, NoteAddOutlined, DeleteForeverOutlined, AccountTreeOutlined } from "@mui/icons-material";

/* Campagne de visites medicales + convocations (SANTE_ADMIN). */
const RH_Sante_Campagne = () => {
  const { num } = useParams();
  const navigate = useNavigate();
  const currentNum = num || "new";
  const [entete, setEntete] = useState<TEntete>(iniEntete);
  const [convocations, setConvocations] = useState<TConvocation[]>([]);
  const msgBox = useMsgBox();
  const alert = useAlert();
  const myAxios = useAxiosPost();
  const { settbnMenu, setShowLoading, isSmall } = useContext(cntX);

  function stateChange(champs: string, valeur: any) {
    setEntete((e: TEntete) => ({ ...e, [champs]: valeur }));
  }

  const Request = () => {
    if (currentNum === "new") return;
    setShowLoading(true);
    myAxios("get_sante_campagne", { Cod_Campagne: currentNum }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.entete) {
        setEntete({ ...iniEntete, ...dt.data.entete });
        setConvocations(dt.data.detail || []);
      } else {
        alert({ titre: "Campagne", msg: dt.data?.message || "Campagne introuvable ou accès non autorisé", typMsg: "error" });
        navigate(-1);
      }
    });
  };

  useEffect(() => {
    Request();
  }, [currentNum]);

  const Enregistrer = async () => {
    if (!entete.Lib_Campagne) { await msgBox({ titre: "Campagne", msg: "Libellé non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    setShowLoading(true);
    const dt = await myAxios("save_sante_campagne", { entete });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      const nv = dt.data.data[0];
      alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      if (currentNum === "new") navigate(`../myspace/RH_Sante_Campagne/Campagne/${nv.Cod_Campagne}`, { replace: true });
      else Request();
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur d'enregistrement", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Generer = async () => {
    if (currentNum === "new") { await msgBox({ titre: "Campagne", msg: "Enregistrez d'abord la campagne.", typMsg: "info", typReply: "OkOnly" }); return; }
    setShowLoading(true);
    const dt = await myAxios("sante_convocation_generer", { Cod_Campagne: currentNum, Dat_Convocation: entete.Dat_Deb || new Date(), Heure: "" });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      alert({ titre: "Convocations", msg: (dt.data.data?.[0]?.generees ?? 0) + " convocation(s) générée(s)", typMsg: "success", timeOut: -1 });
      Request();
    } else {
      await msgBox({ titre: "Convocations", msg: dt.data?.message || "Erreur", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Supprimer = async () => {
    if ((await msgBox({ titre: "Suppression", msg: "Supprimer cette campagne et ses convocations non réalisées ?", typMsg: "warning", typReply: "OKCancel" })) === "Cancel") return;
    const dt = await myAxios("delete_sante_campagne", { Cod_Campagne: currentNum });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Supprimer", msg: "Campagne supprimée", typMsg: "success", timeOut: -1 });
      navigate(-1);
    } else {
      await msgBox({ titre: "Supprimer", msg: dt.data?.message || "Erreur", typMsg: "error", typReply: "OkOnly" });
    }
  };

  useEffect(() => {
    const menu: TMenuBtn[] = [
      { name: "save", libelle: "Enregistrer", icon: <SaveAsOutlined />, disabled: false, action: Enregistrer },
      { name: "generer", libelle: "Générer convocations", icon: <AccountTreeOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none", action: Generer },
      { name: "new", libelle: "Nouveau", icon: <NoteAddOutlined />, disabled: false, action: () => navigate("../myspace/RH_Sante_Campagne/Campagne/new") },
      { name: "del", libelle: "Supprimer", icon: <DeleteForeverOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none", action: Supprimer, color: "error.main" },
    ];
    settbnMenu(menu);
  }, [JSON.stringify(entete), currentNum]);

  const formatDate = (d: any) => {
    if (!d) return "";
    const dt = new Date(d);
    return isNaN(dt.getTime()) ? "" : dt.toLocaleDateString("fr-FR");
  };

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label="Campagne de visites médicales" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={2}>
            <TextBox nomControle="Cod_Campagne" label="Code" valeur={entete?.Cod_Campagne || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={5}>
            <TextBox nomControle="Lib_Campagne" label="Libellé campagne" valeur={entete?.Lib_Campagne || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Typ_Visite" nomControle="Typ_Visite" label="Type de visite" valeur={entete?.Typ_Visite || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={2}>
            <ComboBox rubrique="Statut_Campagne" nomControle="Statut" label="Statut" valeur={entete?.Statut || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Deb" label="Du" valeur={entete?.Dat_Deb || ""} onchange={stateChange} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Deb", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Fin" label="Au" valeur={entete?.Dat_Fin || ""} onchange={stateChange} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Fin", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS306" nomControle="Cod_Medecin" label="Médecin" valeur={entete?.Cod_Medecin || ""}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Cod_Intervenant", tblName: "Param_Sante_Intervenant" }}
              onchange={stateChange} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Lieu" label="Lieu" valeur={entete?.Lieu || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>

      <GroupBox label={"Convocations (" + convocations.length + ")"} showBorders={!isSmall} showTitre={true}>
        <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
          <Grille
            readonly={true}
            dataSource={convocations.map((c) => ({
              Matricule: c.Matricule,
              Convocation: formatDate(c.Dat_Convocation),
              Heure: c.Heure || "",
              Statut: c.Statut_Convocation || "",
              "Visite réalisée": c.Num_Visite || "",
            }))}
            className="laGrille"
          />
          {convocations.length === 0 && <Box sx={{ padding: "1em" }}>Aucune convocation — utilisez « Générer convocations ».</Box>}
        </Box>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Campagne;

type TEntete = {
  Cod_Campagne?: string;
  Lib_Campagne?: string;
  Typ_Visite?: string;
  Dat_Deb?: Date | string;
  Dat_Fin?: Date | string;
  Cod_Medecin?: string;
  Lieu?: string;
  Statut?: string;
};
const iniEntete: TEntete = {
  Cod_Campagne: "", Lib_Campagne: "", Typ_Visite: "PRD", Dat_Deb: "", Dat_Fin: "",
  Cod_Medecin: "", Lieu: "", Statut: "PRE",
};
type TConvocation = {
  RowId: number;
  Matricule: string;
  Dat_Convocation?: string;
  Heure?: string;
  Statut_Convocation?: string;
  Num_Visite?: string;
};
