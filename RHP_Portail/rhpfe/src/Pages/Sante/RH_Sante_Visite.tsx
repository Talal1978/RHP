import { useContext, useEffect, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Grid from "@mui/material/Unstable_Grid2";
import { Box } from "@mui/material";
import GroupBox from "../../components/GroupBox/GroupBox";
import TextZoom from "../../components/TextZoom/TextZoom";
import TextBox from "../../components/TextBox/TextBox";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { Agent, IsNull } from "../../modules/module_general";
import { cntX } from "../../Menu/MenuMain";
import { TMenuBtn } from "../../types";
import {
  SaveAsOutlined, NoteAddOutlined, DeleteForeverOutlined,
  AttachFileOutlined, DrawOutlined, CalculateOutlined,
} from "@mui/icons-material";
import isEqual from "lodash.isequal";

/* Fiche visite medicale (domaine CLINIQUE - controle serveur par fonction SANTE_CLINIQUE).
   Une visite validee (VA/SG) n'est plus modifiable : correction = nouvelle visite
   de rectification motivee. */
const RH_Sante_Visite = () => {
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
    myAxios("get_sante_visite", { Num_Visite: currentNum }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.data.length > 0) {
        const v = dt.data.data[0];
        setEntete({ ...iniEntete, ...v });
        enteteRef.current = { ...iniEntete, ...v };
        setCanSave(!["VA", "SG"].includes(IsNull(v.Statut, "")));
      } else {
        alert({ titre: "Visite", msg: dt.data?.message || "Visite introuvable ou accès non autorisé", typMsg: "error" });
        navigate(-1);
      }
    });
  };

  useEffect(() => {
    setEntete({ ...iniEntete, Matricule: Agent?.Matricule || "" });
    Request();
  }, [currentNum]);

  useEffect(() => {
    setSignatureProps({ typ_document: "VM", valeur_index: currentNum });
  }, [currentNum]);

  const Enregistrer = async (statut: string) => {
    if (!entete.Matricule) { await msgBox({ titre: "Visite", msg: "Matricule non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    if (!entete.Typ_Visite) { await msgBox({ titre: "Visite", msg: "Type de visite non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    if (entete.Num_Visite_Rectifiee && !entete.Motif_Rectification) {
      await msgBox({ titre: "Visite", msg: "Le motif de rectification est obligatoire", typMsg: "warning", typReply: "OkOnly" }); return;
    }
    if (statut === "VA") {
      if ((await msgBox({ titre: "Validation", msg: "Valider cette visite ? Elle deviendra historisée et ne sera plus modifiable.", typMsg: "question", typReply: "OKCancel" })) === "Cancel") return;
    }
    setShowLoading(true);
    const dt = await myAxios("save_sante_visite", { entete: { ...entete, Statut: statut } });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      const nv = dt.data.data[0];
      alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      if (currentNum === "new") {
        navigate(`../myspace/RH_Sante_Visite/Visite médicale/${nv.Num_Visite}`, { replace: true });
      } else {
        Request();
      }
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur d'enregistrement", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Supprimer = async () => {
    if (["VA", "SG"].includes(IsNull(entete.Statut, ""))) return;
    if ((await msgBox({ titre: "Suppression", msg: "Supprimer cette visite ?", typMsg: "warning", typReply: "OKCancel" })) === "Cancel") return;
    const dt = await myAxios("delete_sante_visite", { Num_Visite: currentNum });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Supprimer", msg: "Visite supprimée", typMsg: "success", timeOut: -1 });
      navigate(-1);
    } else {
      await msgBox({ titre: "Supprimer", msg: dt.data?.message || "Erreur", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Recalculer = async () => {
    if (!entete.Matricule || !entete.Dat_Visite) return;
    const dt = await myAxios("sante_calcul_echeance", { Matricule: entete.Matricule, Dat_Visite: entete.Dat_Visite });
    if (dt.data && dt.data?.result && dt.data.data.length > 0 && dt.data.data[0].Dat_Prochaine_Visite) {
      stateChange("Dat_Prochaine_Visite", dt.data.data[0].Dat_Prochaine_Visite);
      stateChange("Cod_Regle_Appliquee", dt.data.data[0].Cod_Regle_Appliquee || "");
    } else {
      await msgBox({ titre: "Calcul", msg: "Aucune règle de périodicité applicable (paramétrage).", typMsg: "info", typReply: "OkOnly" });
    }
  };

  useEffect(() => {
    const modifie = !isEqual(entete, enteteRef.current);
    const _canSave = canSave && (currentNum === "new" || modifie);
    const menu: TMenuBtn[] = [
      { name: "save", libelle: "Enregistrer", icon: <SaveAsOutlined />, disabled: false, visible: _canSave ? "visible" : "none", action: () => Enregistrer("") },
      { name: "valide", libelle: "Valider", icon: <DrawOutlined />, disabled: false, visible: canSave && currentNum !== "new" ? "visible" : "none", action: () => Enregistrer("VA") },
      { name: "new", libelle: "Nouveau", icon: <NoteAddOutlined />, disabled: false, action: () => navigate("../myspace/RH_Sante_Visite/Visite médicale/new") },
      { name: "del", libelle: "Supprimer", icon: <DeleteForeverOutlined />, disabled: false, visible: canSave && currentNum !== "new" ? "visible" : "none", action: Supprimer, color: "error.main" },
      {
        name: "pj", libelle: "Pièces jointes", icon: <AttachFileOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none",
        action: () => { setGEDprops({ name_ecran: "RH_Sante_Visite", valeur_index: currentNum }); setShowGED(true); },
      },
    ];
    settbnMenu(menu);
  }, [JSON.stringify(entete), canSave, currentNum]);

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label="Visite médicale" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Num_Visite" label="N° visite" valeur={entete?.Num_Visite || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS067" nomControle="Matricule" label="Matricule" valeur={entete?.Matricule}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Matricule", tblName: "RH_Agent" }}
              onchange={stateChange} readonly={!canSave || currentNum !== "new"} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Visite" label="Date visite" valeur={entete?.Dat_Visite || new Date()} onchange={stateChange} readOnly={!canSave} sx={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Typ_Visite" nomControle="Typ_Visite" label="Type de visite" valeur={entete?.Typ_Visite || ""} onchange={stateChange} readOnly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS306" nomControle="Cod_Medecin" label="Médecin" valeur={entete?.Cod_Medecin || ""}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Cod_Intervenant", tblName: "Param_Sante_Intervenant" }}
              onchange={stateChange} readonly={!canSave} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Statut_Aptitude" nomControle="Statut_Aptitude" label="Statut d'aptitude" valeur={entete?.Statut_Aptitude || ""} onchange={stateChange} readOnly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Reserves" label="Réserves" valeur={entete?.Reserves || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Restrictions" label="Restrictions de poste" valeur={entete?.Restrictions || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Conclusion" label="Conclusion (clinique)" valeur={entete?.Conclusion || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>

      <GroupBox label="Échéance" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Prochaine_Visite" label="Prochaine visite" valeur={entete?.Dat_Prochaine_Visite || ""} onchange={stateChange} readOnly={!canSave} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Prochaine_Visite", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <Bouton label="Recalculer" startIcon={<CalculateOutlined />} disabled={!canSave} onClick={Recalculer} sx={{ marginTop: "1.6em" }} />
          </Grid>
          <Grid xs={12} sm={12} lg={6}>
            <TextBox nomControle="Motif_Ajustement" label="Motif d'ajustement (obligatoire si échéance modifiée)" valeur={entete?.Motif_Ajustement || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>

      <GroupBox label="Rectification (correction d'une visite validée)" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={4}>
            <TextZoom
              numZoom="MS300" nomControle="Num_Visite_Rectifiee" label="Rectifie la visite N°" valeur={entete?.Num_Visite_Rectifiee || ""}
              onchange={stateChange} readonly={!canSave} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={12} lg={8}>
            <TextBox nomControle="Motif_Rectification" label="Motif de rectification" valeur={entete?.Motif_Rectification || ""} onchange={stateChange} readonly={!canSave} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Visite;

type TEntete = {
  Num_Visite?: string;
  Matricule?: string;
  Dat_Visite?: Date | string;
  Typ_Visite?: string;
  Cod_Medecin?: string;
  Cod_Campagne?: string;
  Conclusion?: string;
  Statut_Aptitude?: string;
  Reserves?: string;
  Restrictions?: string;
  Dat_Prochaine_Visite?: Date | string;
  Cod_Regle_Appliquee?: string;
  Motif_Ajustement?: string;
  Num_Visite_Rectifiee?: string;
  Motif_Rectification?: string;
  Statut?: string;
};
const iniEntete: TEntete = {
  Num_Visite: "", Matricule: "", Dat_Visite: new Date(), Typ_Visite: "PRD",
  Cod_Medecin: "", Cod_Campagne: "", Conclusion: "", Statut_Aptitude: "",
  Reserves: "", Restrictions: "", Dat_Prochaine_Visite: "", Cod_Regle_Appliquee: "",
  Motif_Ajustement: "", Num_Visite_Rectifiee: "", Motif_Rectification: "", Statut: "",
};
