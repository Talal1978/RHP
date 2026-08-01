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
import { Agent, IsNull } from "../../modules/module_general";
import { cntX } from "../../Menu/MenuMain";
import { TMenuBtn } from "../../types";
import {
  SaveAsOutlined, NoteAddOutlined, DeleteForeverOutlined,
  AttachFileOutlined, DrawOutlined, ContentCopyOutlined,
} from "@mui/icons-material";
import isEqual from "lodash.isequal";

/* Fiche d'aptitude (redaction CLINIQUE). Une version validee n'est jamais
   modifiee : toute correction = nouvelle version motivee (Version+1). */
const RH_Sante_Aptitude = () => {
  const { num } = useParams();
  const navigate = useNavigate();
  const currentNum = num || "new";
  const [entete, setEntete] = useState<TEntete>(iniEntete);
  const [canSave, setCanSave] = useState(true);
  const enteteRef = useRef<TEntete>(iniEntete);
  const msgBox = useMsgBox();
  const alert = useAlert();
  const myAxios = useAxiosPost();
  const { settbnMenu, setSignatureProps, setGEDprops, setShowGED, setShowLoading, isSmall } = useContext(cntX);

  function stateChange(champs: string, valeur: any) {
    setEntete((e: TEntete) => ({ ...e, [champs]: valeur }));
  }

  const Request = () => {
    if (currentNum === "new") return;
    setShowLoading(true);
    myAxios("get_sante_aptitude", { Num_Aptitude: currentNum }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.data.length > 0) {
        const v = dt.data.data[0];
        setEntete({ ...iniEntete, ...v });
        enteteRef.current = { ...iniEntete, ...v };
        setCanSave(!["VA", "SG"].includes(IsNull(v.Statut, "")));
      } else {
        alert({ titre: "Aptitude", msg: dt.data?.message || "Fiche introuvable ou accès non autorisé", typMsg: "error" });
        navigate(-1);
      }
    });
  };

  useEffect(() => {
    setEntete({ ...iniEntete, Matricule: Agent?.Matricule || "" });
    Request();
  }, [currentNum]);

  useEffect(() => {
    setSignatureProps({ typ_document: "FA", valeur_index: currentNum });
  }, [currentNum]);

  const Enregistrer = async (statut: string) => {
    if (!entete.Matricule) { await msgBox({ titre: "Aptitude", msg: "Matricule non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    if (!entete.Statut_Aptitude) { await msgBox({ titre: "Aptitude", msg: "Statut d'aptitude non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    if (entete.Num_Aptitude_Prec && !entete.Motif_Version) {
      await msgBox({ titre: "Aptitude", msg: "Le motif de la nouvelle version est obligatoire", typMsg: "warning", typReply: "OkOnly" }); return;
    }
    if (statut === "VA") {
      if ((await msgBox({ titre: "Validation", msg: "Valider cette fiche ? Toute correction passera ensuite par une nouvelle version.", typMsg: "question", typReply: "OKCancel" })) === "Cancel") return;
    }
    setShowLoading(true);
    const dt = await myAxios("save_sante_aptitude", { entete: { ...entete, Statut: statut } });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      const nv = dt.data.data[0];
      alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      if (currentNum === "new") navigate(`../myspace/RH_Sante_Aptitude/Fiche d'aptitude/${nv.Num_Aptitude}`, { replace: true });
      else Request();
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur d'enregistrement", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Supprimer = async () => {
    if (["VA", "SG"].includes(IsNull(entete.Statut, ""))) return;
    if ((await msgBox({ titre: "Suppression", msg: "Supprimer cette fiche d'aptitude ?", typMsg: "warning", typReply: "OKCancel" })) === "Cancel") return;
    const dt = await myAxios("delete_sante_aptitude", { Num_Aptitude: currentNum });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Supprimer", msg: "Fiche supprimée", typMsg: "success", timeOut: -1 });
      navigate(-1);
    } else {
      await msgBox({ titre: "Supprimer", msg: dt.data?.message || "Erreur", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const NouvelleVersion = () => {
    if (!["VA", "SG"].includes(IsNull(entete.Statut, ""))) return;
    setEntete({
      ...entete,
      Num_Aptitude: "",
      Num_Aptitude_Prec: currentNum,
      Motif_Version: "",
      Dat_Aptitude: new Date(),
      Version: (entete.Version || 1) + 1,
      Statut: "",
    });
    setCanSave(true);
    navigate("../myspace/RH_Sante_Aptitude/Fiche d'aptitude/new", { replace: true });
  };

  useEffect(() => {
    const modifie = !isEqual(entete, enteteRef.current);
    const _canSave = canSave && (currentNum === "new" || modifie);
    const menu: TMenuBtn[] = [
      { name: "save", libelle: "Enregistrer", icon: <SaveAsOutlined />, disabled: false, visible: _canSave ? "visible" : "none", action: () => Enregistrer("") },
      { name: "valide", libelle: "Valider", icon: <DrawOutlined />, disabled: false, visible: canSave && currentNum !== "new" ? "visible" : "none", action: () => Enregistrer("VA") },
      { name: "rectif", libelle: "Nouvelle version", icon: <ContentCopyOutlined />, disabled: false, visible: !canSave ? "visible" : "none", action: NouvelleVersion },
      { name: "new", libelle: "Nouveau", icon: <NoteAddOutlined />, disabled: false, action: () => navigate("../myspace/RH_Sante_Aptitude/Fiche d'aptitude/new") },
      { name: "del", libelle: "Supprimer", icon: <DeleteForeverOutlined />, disabled: false, visible: canSave && currentNum !== "new" ? "visible" : "none", action: Supprimer, color: "error.main" },
      {
        name: "pj", libelle: "Pièces jointes", icon: <AttachFileOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none",
        action: () => { setGEDprops({ name_ecran: "RH_Sante_Aptitude", valeur_index: currentNum }); setShowGED(true); },
      },
    ];
    settbnMenu(menu);
  }, [JSON.stringify(entete), canSave, currentNum]);

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label={"Fiche d'aptitude" + (entete.Version ? " — version " + entete.Version : "")} showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Num_Aptitude" label="N° fiche" valeur={entete?.Num_Aptitude || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS067" nomControle="Matricule" label="Matricule" valeur={entete?.Matricule}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Matricule", tblName: "RH_Agent" }}
              onchange={stateChange} readonly={!canSave || currentNum !== "new"} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS300" nomControle="Num_Visite" label="Visite source" valeur={entete?.Num_Visite || ""}
              onchange={stateChange} readonly={!canSave} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Aptitude" label="Date" valeur={entete?.Dat_Aptitude || new Date()} onchange={stateChange} readOnly={!canSave} sx={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Statut_Aptitude" nomControle="Statut_Aptitude" label="Statut d'aptitude" valeur={entete?.Statut_Aptitude || ""} onchange={stateChange} readOnly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS306" nomControle="Cod_Medecin" label="Médecin" valeur={entete?.Cod_Medecin || ""}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Cod_Intervenant", tblName: "Param_Sante_Intervenant" }}
              onchange={stateChange} readonly={!canSave} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Reserves" label="Réserves" valeur={entete?.Reserves || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Restrictions_Poste" label="Restrictions de poste" valeur={entete?.Restrictions_Poste || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Amenagements" label="Aménagements" valeur={entete?.Amenagements || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Effet" label="Effet" valeur={entete?.Dat_Effet || ""} onchange={stateChange} readOnly={!canSave} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Effet", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Fin" label="Fin de validité" valeur={entete?.Dat_Fin || ""} onchange={stateChange} readOnly={!canSave} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Fin", "")} />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Publie_RH" label="Publier pour la RH (1=oui, 0=non) — conclusion et restrictions uniquement" valeur={String(entete?.Publie_RH ?? "0")} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>

      <GroupBox label="Version (rectification d'une fiche validée)" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={4}>
            <TextBox nomControle="Num_Aptitude_Prec" label="Version précédente N°" valeur={entete?.Num_Aptitude_Prec || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={8}>
            <TextBox nomControle="Motif_Version" label="Motif de la nouvelle version" valeur={entete?.Motif_Version || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Aptitude;

type TEntete = {
  Num_Aptitude?: string;
  Num_Visite?: string;
  Matricule?: string;
  Dat_Aptitude?: Date | string;
  Cod_Medecin?: string;
  Statut_Aptitude?: string;
  Reserves?: string;
  Restrictions_Poste?: string;
  Amenagements?: string;
  Dat_Effet?: Date | string;
  Dat_Fin?: Date | string;
  Version?: number;
  Num_Aptitude_Prec?: string;
  Motif_Version?: string;
  Publie_RH?: number | string;
  Statut?: string;
};
const iniEntete: TEntete = {
  Num_Aptitude: "", Num_Visite: "", Matricule: "", Dat_Aptitude: new Date(),
  Cod_Medecin: "", Statut_Aptitude: "", Reserves: "", Restrictions_Poste: "",
  Amenagements: "", Dat_Effet: "", Dat_Fin: "", Version: 1,
  Num_Aptitude_Prec: "", Motif_Version: "", Publie_RH: 0, Statut: "",
};
