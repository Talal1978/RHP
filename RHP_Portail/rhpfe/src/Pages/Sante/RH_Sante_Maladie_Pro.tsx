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

/* Maladie professionnelle (CLINIQUE). */
const RH_Sante_Maladie_Pro = () => {
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
    myAxios("get_sante_maladie_pro", { Num_MP: currentNum }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.data.length > 0) {
        const v = dt.data.data[0];
        setEntete({ ...iniEntete, ...v });
        enteteRef.current = { ...iniEntete, ...v };
      } else {
        alert({ titre: "Maladie pro", msg: dt.data?.message || "Déclaration introuvable ou accès non autorisé", typMsg: "error" });
        navigate(-1);
      }
    });
  };

  useEffect(() => {
    setEntete({ ...iniEntete, Matricule: Agent?.Matricule || "" });
    Request();
  }, [currentNum]);

  const Enregistrer = async () => {
    if (!entete.Matricule) { await msgBox({ titre: "Maladie pro", msg: "Matricule non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    if (!entete.Pathologie) { await msgBox({ titre: "Maladie pro", msg: "Pathologie non renseignée", typMsg: "warning", typReply: "OkOnly" }); return; }
    setShowLoading(true);
    const dt = await myAxios("save_sante_maladie_pro", { entete });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      const nv = dt.data.data[0];
      alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      if (currentNum === "new") navigate(`../myspace/RH_Sante_Maladie_Pro/Maladie professionnelle/${nv.Num_MP}`, { replace: true });
      else Request();
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur d'enregistrement", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Supprimer = async () => {
    if ((await msgBox({ titre: "Suppression", msg: "Supprimer cette déclaration ?", typMsg: "warning", typReply: "OKCancel" })) === "Cancel") return;
    const dt = await myAxios("delete_sante_maladie_pro", { Num_MP: currentNum });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Supprimer", msg: "Déclaration supprimée", typMsg: "success", timeOut: -1 });
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
      { name: "new", libelle: "Nouveau", icon: <NoteAddOutlined />, disabled: false, action: () => navigate("../myspace/RH_Sante_Maladie_Pro/Maladie professionnelle/new") },
      { name: "del", libelle: "Supprimer", icon: <DeleteForeverOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none", action: Supprimer, color: "error.main" },
      {
        name: "pj", libelle: "Pièces jointes", icon: <AttachFileOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none",
        action: () => { setGEDprops({ name_ecran: "RH_Sante_Maladie_Pro", valeur_index: currentNum }); setShowGED(true); },
      },
    ];
    settbnMenu(menu);
  }, [JSON.stringify(entete), currentNum]);

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label="Maladie professionnelle" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Num_MP" label="N° MP" valeur={entete?.Num_MP || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS067" nomControle="Matricule" label="Matricule" valeur={entete?.Matricule}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Matricule", tblName: "RH_Agent" }}
              onchange={stateChange} readonly={currentNum !== "new"} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Declaration" label="Déclarée le" valeur={entete?.Dat_Declaration || new Date()} onchange={stateChange} sx={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Premier_Constat" label="1er constat le" valeur={entete?.Dat_Premier_Constat || ""} onchange={stateChange} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Premier_Constat", "")} />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Pathologie" label="Pathologie" valeur={entete?.Pathologie || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Tableau_MP" label="Tableau (réf. légale)" valeur={entete?.Tableau_MP || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Statut_Declaration_MP" nomControle="Statut_Declaration" label="Statut" valeur={entete?.Statut_Declaration || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Organisme" label="Organisme" valeur={entete?.Organisme || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Num_Dossier_Org" label="N° dossier organisme" valeur={entete?.Num_Dossier_Org || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Commentaire" label="Commentaire" valeur={entete?.Commentaire || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Maladie_Pro;

type TEntete = {
  Num_MP?: string;
  Matricule?: string;
  Dat_Declaration?: Date | string;
  Dat_Premier_Constat?: Date | string;
  Pathologie?: string;
  Tableau_MP?: string;
  Organisme?: string;
  Num_Dossier_Org?: string;
  Statut_Declaration?: string;
  Commentaire?: string;
};
const iniEntete: TEntete = {
  Num_MP: "", Matricule: "", Dat_Declaration: new Date(), Dat_Premier_Constat: "",
  Pathologie: "", Tableau_MP: "", Organisme: "", Num_Dossier_Org: "",
  Statut_Declaration: "DEC", Commentaire: "",
};
