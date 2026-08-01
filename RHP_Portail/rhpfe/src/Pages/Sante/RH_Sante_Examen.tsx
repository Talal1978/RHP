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

/* Examen complementaire (CLINIQUE). Resultats cloisonnes : le serveur masque
   motif/resume/piece selon la colonne Visibilite (MED / AUT = prescripteur). */
const RH_Sante_Examen = () => {
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
    myAxios("get_sante_examen", { Num_Examen: currentNum }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.data.length > 0) {
        const v = dt.data.data[0];
        setEntete({ ...iniEntete, ...v });
        enteteRef.current = { ...iniEntete, ...v };
      } else {
        alert({ titre: "Examen", msg: dt.data?.message || "Examen introuvable ou accès non autorisé", typMsg: "error" });
        navigate(-1);
      }
    });
  };

  useEffect(() => {
    setEntete({ ...iniEntete, Matricule: Agent?.Matricule || "" });
    Request();
  }, [currentNum]);

  const Enregistrer = async () => {
    if (!entete.Matricule) { await msgBox({ titre: "Examen", msg: "Matricule non renseigné", typMsg: "warning", typReply: "OkOnly" }); return; }
    setShowLoading(true);
    const dt = await myAxios("save_sante_examen", { entete });
    setShowLoading(false);
    if (dt.data && dt.data?.result) {
      const nv = dt.data.data[0];
      alert({ titre: "Enregistrer", msg: "Enregistré avec succès", typMsg: "success", timeOut: -1 });
      if (currentNum === "new") navigate(`../myspace/RH_Sante_Examen/Examen/${nv.Num_Examen}`, { replace: true });
      else Request();
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur d'enregistrement", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Supprimer = async () => {
    if ((await msgBox({ titre: "Suppression", msg: "Supprimer cet examen ?", typMsg: "warning", typReply: "OKCancel" })) === "Cancel") return;
    const dt = await myAxios("delete_sante_examen", { Num_Examen: currentNum });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Supprimer", msg: "Examen supprimé", typMsg: "success", timeOut: -1 });
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
      { name: "new", libelle: "Nouveau", icon: <NoteAddOutlined />, disabled: false, action: () => navigate("../myspace/RH_Sante_Examen/Examen/new") },
      { name: "del", libelle: "Supprimer", icon: <DeleteForeverOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none", action: Supprimer, color: "error.main" },
      {
        name: "pj", libelle: "Pièce (résultat)", icon: <AttachFileOutlined />, disabled: false, visible: currentNum !== "new" ? "visible" : "none",
        action: () => { setGEDprops({ name_ecran: "RH_Sante_Examen", valeur_index: currentNum }); setShowGED(true); },
      },
    ];
    settbnMenu(menu);
  }, [JSON.stringify(entete), currentNum]);

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label="Examen complémentaire" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <TextBox nomControle="Num_Examen" label="N° examen" valeur={entete?.Num_Examen || ""} readonly={true} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS067" nomControle="Matricule" label="Matricule" valeur={entete?.Matricule}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Matricule", tblName: "RH_Agent" }}
              onchange={stateChange} readonly={currentNum !== "new"} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Typ_Examen" nomControle="Typ_Examen" label="Examen" valeur={entete?.Typ_Examen || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Statut_Examen" nomControle="Statut_Examen" label="Statut" valeur={entete?.Statut_Examen || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Prescription" label="Prescrit le" valeur={entete?.Dat_Prescription || ""} onchange={stateChange} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Prescription", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Examen" label="Réalisé le" valeur={entete?.Dat_Examen || ""} onchange={stateChange} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Examen", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS306" nomControle="Cod_Medecin_Prescripteur" label="Prescripteur" valeur={entete?.Cod_Medecin_Prescripteur || ""}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Cod_Intervenant", tblName: "Param_Sante_Intervenant" }}
              onchange={stateChange} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="MS306" nomControle="Cod_Prestataire" label="Prestataire" valeur={entete?.Cod_Prestataire || ""}
              findlibelle={{ champs: "Nom_Agent+ ' ' +Prenom_Agent", code: "Cod_Intervenant", tblName: "Param_Sante_Intervenant" }}
              onchange={stateChange} style={{ width: "100%" }}
            />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <CalendarZoom nomControle="Dat_Resultat" label="Résultat le" valeur={entete?.Dat_Resultat || ""} onchange={stateChange} sx={{ width: "100%" }} onClear={() => stateChange("Dat_Resultat", "")} />
          </Grid>
          <Grid xs={12} sm={6} lg={3}>
            <ComboBox rubrique="Visibilite_Examen" nomControle="Visibilite" label="Visibilité du résultat" valeur={entete?.Visibilite || "MED"} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Motif" label="Motif (clinique)" valeur={entete?.Motif || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
          <Grid xs={12}>
            <TextBox nomControle="Resultat_Resume" label="Résumé du résultat (clinique)" valeur={entete?.Resultat_Resume || ""} onchange={stateChange} style={{ width: "100%" }} />
          </Grid>
        </Grid>
      </GroupBox>
    </Box>
  );
};

export default RH_Sante_Examen;

type TEntete = {
  Num_Examen?: string;
  Matricule?: string;
  Typ_Examen?: string;
  Dat_Prescription?: Date | string;
  Dat_Examen?: Date | string;
  Cod_Medecin_Prescripteur?: string;
  Cod_Prestataire?: string;
  Motif?: string;
  Statut_Examen?: string;
  Dat_Resultat?: Date | string;
  Resultat_Resume?: string;
  Visibilite?: string;
  FD_Resultat?: number;
};
const iniEntete: TEntete = {
  Num_Examen: "", Matricule: "", Typ_Examen: "", Dat_Prescription: "", Dat_Examen: "",
  Cod_Medecin_Prescripteur: "", Cod_Prestataire: "", Motif: "", Statut_Examen: "PRE",
  Dat_Resultat: "", Resultat_Resume: "", Visibilite: "MED",
};
