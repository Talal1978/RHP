import { useContext, useEffect, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Grid from "@mui/material/Unstable_Grid2";
import { Box } from "@mui/material";
import GroupBox from "../../components/GroupBox/GroupBox";
import TextZoom from "../../components/TextZoom/TextZoom";
import TextBox from "../../components/TextBox/TextBox";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { Agent } from "../../modules/module_general";
import { cntX } from "../../Menu/MenuMain";
import { TMenuBtn } from "../../types";
import { SaveAsOutlined, NoteAddOutlined, DeleteForeverOutlined, AttachFileOutlined } from "@mui/icons-material";
import isEqual from "lodash.isequal";

/* Consultation / soin infirmier (CLINIQUE). */
const RH_Sante_Consultation = () => {
  const { num } = useParams();
  const navigate = useNavigate();
  const currentNum = num || "new";
  const [entete, setEntete] = useState<TEntete>(iniEntete);
  const enteteRef = useRef<TEntete>(iniEntete);
  const msgBox = useMsgBox();
  const alert = useAlert();
  const myAxios = useAxiosPost();
  const { settbnMenu, setGEDprops, setShowGED, setShowLoading, isSmall } = useContext(cntX);

  function stateChange(champs: string, valeur: any) {
    setEntete((e: TEntete) => ({ ...e, [champs]: valeur }));
  }

  const Request = () => {
    if (currentNum === "new") return;
    setShowLoading(true);
    myAxios("get_sante_consultation", { Num_Consultation: currentNum }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.data.length > 0) {
        const v = dt.data.data[0];
        setEntete({ ...iniEntete, ...v });
        enteteRef.current = { ...iniEntete, ...v };
      } else {
        alert({ titre: "Consultation", msg: dt.data?.message || "Consultation introuvable ou accès non autorisé", typMsg: "error" });
        navigate(-1);
      }
    });
  };

  useEffect(() => {
    setEntete({ ...iniEntete, Matricule: Agent?.Matricule || "" });
    Request();
  }, [currentNum]);

  const Enregistrer = async () => {
    if (!entete.Matricule) { await msgBox({ titre: "Consultation", msg: "Matricule non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    setShowLoading(true);
    const dt = await myAxios("save_sante_consultation", { entete });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      const nv = dt.data.data[0];
      alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      if (currentNum === "new") navigate(`../myspace/RH_Sante_Consultation/Consultation/${nv.Num_Consultation}`, { replace: true });
      else Request();
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur d'enregistrement", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Supprimer = async () => {
    if ((await msgBox({ titre: "Suppression", msg: "Supprimer cette consultation ?", typMsg: "warning", typReply: "OKCancel" })) === "Cancel") return;
    const dt = await myAxios("delete_sante_consultation", { Num_Consultation: currentNum });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Supprimer", msg: "Consultation supprimée", typMsg: "success", timeOut: -1 });
      navigate(-1);
    } else {
      await msgBox({ titre: "Supprimer", msg: dt.data?.message || "Erreur", typMsg: "error", typReply: "OkOnly" });
    }
  };

  useEffect(() => {
    const modifie = !isEqual(entete, enteteRef.current);
    const _canSave = currentNum === "new" || modifie;
    const menu: TMenuBtn[] = [
      { name: "save", libelle: "Enregistrer", icon: <SaveAsOutlined />, disabled: false, visible: _canSave ? "visible" : "none", action: Enregistrer },
      { name: "new", libelle: "Nouveau", icon: <NoteAddOutlined />, disabled: false, action: () => navigate("../myspace/RH_Sante_Consultation/Consultation/new") },
      { name: "del", libelle: "Supprimer", icon: <DeleteForeverOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none", action: Supprimer, color: "error.main" },
      {
        name: "pj", libelle: "Pièces jointes", icon: <AttachFileOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none",
        action: () => { setGEDprops({ name_ecran: "RH_Sante_Consultation", valeur_index: currentNum }); setShowGED(true); },
      },
    ];
    settbnMenu(menu);
  }, [JSON.stringify(entete), currentNum]);

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label="Consultation / Soin infirmier" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Num_Consultation" label="N° consultation" valeur={entete?.Num_Consultation || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS067" nomControle="Matricule" label="Matricule" valeur={entete?.Matricule}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Matricule", tblName: "RH_Agent" }}
              onchange={stateChange} readonly={currentNum !== "new"} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Consultation" label="Date" valeur={entete?.Dat_Consultation || new Date()} onchange={stateChange} sx={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS306" nomControle="Cod_Intervenant" label="Intervenant" valeur={entete?.Cod_Intervenant || ""}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Cod_Intervenant", tblName: "Param_Sante_Intervenant" }}
              onchange={stateChange} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Typ_Acte_Infirmier" nomControle="Typ_Acte" label="Acte" valeur={entete?.Typ_Acte || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Suite_Consultation" nomControle="Suite" label="Suite" valeur={entete?.Suite || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={6}>
            <TextZoom
              numZoom="AT001" nomControle="Num_Declaration_AT" label="Déclaration AT liée" valeur={entete?.Num_Declaration_AT || ""}
              onchange={stateChange} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Motif" label="Motif (clinique)" valeur={entete?.Motif || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Observations" label="Observations (clinique)" valeur={entete?.Observations || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Consultation;

type TEntete = {
  Num_Consultation?: string;
  Matricule?: string;
  Dat_Consultation?: Date | string;
  Cod_Intervenant?: string;
  Typ_Acte?: string;
  Motif?: string;
  Observations?: string;
  Suite?: string;
  Num_Declaration_AT?: string;
};
const iniEntete: TEntete = {
  Num_Consultation: "", Matricule: "", Dat_Consultation: new Date(),
  Cod_Intervenant: "", Typ_Acte: "", Motif: "", Observations: "", Suite: "", Num_Declaration_AT: "",
};
