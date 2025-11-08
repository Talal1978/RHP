import {
  useCallback,
  useContext,
  useEffect,
  useMemo,
  useRef,
  useState,
} from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import {
  Add,
  AttachFileOutlined,
  DeleteOutline,
  DrawOutlined,
  PrintOutlined,
  SaveAsOutlined,
  VisibilityOff,
} from "@mui/icons-material";
import { Agent } from "../../modules/module_general";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate, useParams } from "react-router-dom";
import TextBox from "../../components/TextBox/TextBox";
import { cntX } from "../../Menu/MenuMain";
import useMsgBox from "../../hooks/useMsgBox";
import isEqual from "lodash.isequal";
import { findRubrique } from "../../modules/module_rubriques";
import useAlert from "../../hooks/useAlert";
import { TReport } from "../../Report/ReportViewer";
import { Box } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import {
  dateWithoutTimezone,
  estDate,
  formatDateFR,
} from "../../modules/module_formats";
const RH_Demande_Conge = () => {
  const navigate = useNavigate();
  const alert = useAlert();
  const {
    settbnMenu,
    isSmall,
    setShowSignature,
    setSignatureProps,
    setShowGED,
    setGEDprops,
  } = useContext(cntX);
  const msgBox = useMsgBox();
  const { num } = useParams();
  const [isAccessible, setAccessible] = useState<{
    canModify: boolean;
    Taken_By_User: string;
    Process_Id: string;
  }>({ canModify: true, Taken_By_User: "", Process_Id: "" });
  const [currentNum, setCurrentNum] = useState(num);
  const [entete, setEntete] = useState<TEntete>(iniEntete);
  const [ligne, setLigne] = useState<TLigDemande[]>([]);
  const [calculerConge, setCalculerConge] = useState(true);
  const [droitsConge, setDroitsConge] = useState<TConge>(iniConge);
  const [canSave, setCanSave] = useState(false);
  const enteteRef = useRef<TEntete>();
  const myAxios = useAxiosPost();
  const { isXs, isSm, isLg, isXl } = useContext(cntX);
  function stateChange(champs: string, valeur: any) {
    if (champs === "Num_Conge" && currentNum !== valeur) {
      setCurrentNum(valeur);
    }
    setEntete((prv: TEntete) => {
      const newState = {
        ...prv,
        [champs]: valeur,
      };
      return newState;
    });
    setCalculerConge((prv) => !prv);
  }
  const Request = useCallback(async () => {
    if (currentNum !== "" && currentNum !== "new") {
      await myAxios("get_demande_conge", { Num_Conge: currentNum })
        .then((dt) => {
          if (dt.data && dt.data?.result) {
            setEntete(dt.data.data[0]);
            enteteRef.current = dt.data.data[0];
          } else {
            setEntete(iniEntete);
            enteteRef.current = iniEntete;
          }
        })
        .catch((err) => {
          setEntete(iniEntete);
          enteteRef.current = iniEntete;
        });
    } else {
      setEntete(iniEntete);
      setLigne([]);
    }
    if (canSave) {
      if (currentNum !== "" && currentNum !== "new") {
        await myAxios("check_accessible", {
          nameEcran: "RH_Demande_Conge",
          idEcran: currentNum,
        }).then((dt) => {
          setAccessible(dt.data);
        });
      } else {
        await myAxios("release_accessible", {
          nameEcran: "RH_Demande_Conge",
          idEcran: currentNum,
        });
      }
    }
  }, [currentNum, canSave]);
  const Colonnes = useMemo<TColonneCollection>(
    () => ({
      Dat_Deb: {
        columnName: "Dat_Deb",
        dataType: "smalldatetime",
        readOnly: true,
        visible: true,
        headerText: "Du",
        typeColonne: "Text",
        sx: { minWidth: "4em" },
      },
      Dat_Fin: {
        columnName: "Dat_Fin",
        dataType: "smalldatetime",
        readOnly: true,
        visible: true,
        headerText: "Au",
        typeColonne: "Text",
        sx: { maxWidth: "8em" },
      },
      Duree_Globale: {
        columnName: "Duree_Globale",
        dataType: "float",
        readOnly: true,
        visible: true,
        headerText: "Durée globale",
        typeColonne: "Text",
        sx: { maxWidth: "4em" },
      },
      Repos_Hebdomadaire: {
        columnName: "Repos_Hebdomadaire",
        dataType: "float",
        readOnly: true,
        visible: true,
        headerText: "Repos",
        typeColonne: "Text",
        sx: { maxWidth: "4em" },
      },
      Jours_Feries: {
        columnName: "Jours_Feries",
        dataType: "float",
        readOnly: true,
        visible: true,
        headerText: "Jrs fériés",
        typeColonne: "Text",
        sx: { minWidth: "4em" },
      },
      Duree_Conge: {
        columnName: "Duree_Conge",
        dataType: "float",
        readOnly: true,
        visible: true,
        headerText: "Congé",
        typeColonne: "Text",
        sx: { minWidth: "4em" },
      },
    }),
    []
  );
  useEffect(() => {
    Request();
    setSignatureProps({ typ_document: "C", valeur_index: currentNum ?? "" });
    return () => {
      if (currentNum !== "" && currentNum !== "new") {
        myAxios("release_accessible", {
          nameEcran: "RH_Demande_Conge",
          idEcran: currentNum,
        });
      }
    };
  }, [Request]);
  useEffect(() => {
    if (!entete) {
      setDroitsConge(iniConge);
      return;
    }
    if (!entete?.Matricule) {
      console.error("Erreur le matricule est non défini");
      setDroitsConge(iniConge);
      return;
    }
    myAxios("get_conge_droits", {
      Dat_Deb_Conge: entete.Dat_Deb_Conge,
      Matricule: entete.Matricule,
    })
      .then((dt) => {
        if (dt.data && dt.data?.result) {
          setDroitsConge(dt.data.data[0]);
        } else {
          setDroitsConge(iniConge);
        }
      })
      .catch((err) => {
        setEntete(iniEntete);
        enteteRef.current = iniEntete;
      });
  }, [calculerConge]);
  const calcul_conge = useCallback(() => {
    if (!entete.Statut)
      myAxios("calcul_conge", { entete }).then((dt) => {
        if (Boolean(dt.data)) {
          setLigne(dt.data.lignes);
          setEntete((prv: TEntete) => ({
            ...prv,
            Duree_Conge: dt.data.entete.Duree_Conge,
            Jours_Feries: dt.data.entete.Jours_Feries,
            Repos_Hebdomadaire: dt.data.entete.Repos_Hebdomadaire,
            Duree_Globale: dt.data.entete.Duree_Globale,
          }));
        }
      });
  }, [
    entete.Dat_Deb_Conge,
    entete.Dat_Fin_Conge,
    entete.Dat_Deb_am_pm,
    entete.Dat_Fin_am_pm,
    entete.Typ_Conge,
  ]);
  useEffect(() => {
    calcul_conge();
  }, [calcul_conge]);
  const Enregistrer = useCallback(
    async (Statut: "NSS" | "SS" | "SG" | "RJ" | "SP" | "" = "") => {
      if (["SG", "RJ", "SP", "VA"].includes(entete?.Statut || "")) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Demande traitée. Modification impossible.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      let rsl = await myAxios("is_paie_encours", {});
      if (rsl.data) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Une préparation de la paie est en cours. Veuillez essayer plus tard.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if (!entete?.Matricule) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Veuillez renseigner le matricule.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if (entete?.Matricule !== Agent?.Matricule) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Vous ne pouvez pas saisir une demande pour un autre matricule.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if (!estDate(entete?.Dat_Deb_Conge) || !estDate(entete?.Dat_Fin_Conge)) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Erreur  de date.",

          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if (entete?.Dat_Deb_Conge >= entete?.Dat_Fin_Conge) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Incohérence dates début et fin de congé.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if ((entete?.Duree_Conge ?? 0) <= 0) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Aucun durée de congé n'est renseignée.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      let _entete = { ...entete };
      if (Statut === "SS") _entete = { ..._entete, Statut };
      const rslSave = await myAxios("save_demande_conge", {
        entete: _entete,
      });
      if (rslSave.data.result) {
        const numN = rslSave.data.data[0].Num_Conge;
        if (numN !== currentNum) {
          setCurrentNum(numN);
        } else {
          await Request();
        }
        alert({
          titre: "Enregistrer",
          msg: "Enegistré avce succès",
          typMsg: "success",
          timeOut: -1,
        });
      } else {
        alert({
          titre: "Enregistrer",
          msg: "Erreur : " + rslSave.data.data,
          typMsg: "error",
          timeOut: -1,
        });
      }
    },
    [entete]
  );
  async function NonAccessible() {
    await msgBox({
      titre: "Document utilisé",
      msg: "Document utilisé par: " + isAccessible.Taken_By_User,
      typMsg: "warning",
      typReply: "OkOnly",
    });
  }
  const Nouveau = useCallback(async () => {
    if (!isEqual(entete, enteteRef.current)) {
      if (
        (await msgBox({
          titre: "Abandonner les modifications",
          msg: "Vous avez des modifications non enregistrées. Voulez-vous les abandonner?",
          typMsg: "warning",
          typReply: "OKCancel",
          async handleCancel() {
            return;
          },
        })) === "Cancel"
      )
        return;
    }
    setCurrentNum("");
    setEntete(iniEntete);
    setDroitsConge(iniConge);
  }, [entete]);
  const SoumettreEnSignature = useCallback(async () => {
    if (!currentNum) return;
    if (entete.Statut === "" || entete.Statut === "NSS") {
      if (
        (await msgBox({
          titre: "Signature",
          msg: "Êtes-vous sûr de vouloir soumettre cette Demande en signature?",
          typMsg: "warning",
          typReply: "OKCancel",
          async handleCancel() {
            return;
          },
        })) === "Ok"
      )
        await Enregistrer("SS");
    } else {
      setShowSignature(true);
    }
  }, [Enregistrer]);
  const Supprimer = useCallback(async () => {
    if (entete?.Num_Conge) {
      if (
        (await msgBox({
          titre: "Supprimer",
          msg: "Êtes-vous sûr de vouloir supprimer cette demande?",
          typMsg: "warning",
          typReply: "OKCancel",
          async handleCancel() {
            return;
          },
        })) === "Cancel"
      )
        return;
    } else {
      return;
    }
    let rsl = await myAxios("is_paie_encours", {});
    if (rsl.data) {
      await msgBox({
        titre: "Supprimer",
        msg: "Une préparation de la paie est en cours. Veuillez essayer plus tard.",
        typMsg: "error",
        typReply: "OkOnly",
        async handleOk() {
          return;
        },
      });
      return;
    }
    if (entete?.Matricule !== Agent?.Matricule) {
      await msgBox({
        titre: "Supprimer",
        msg: "Vous ne pouvez pas supprimer une demande d'un autre matricule.",
        typMsg: "error",
        typReply: "OkOnly",
        async handleOk() {
          return;
        },
      });
      return;
    }
    if (["SG", "RJ", "SP", "VA"].includes(entete?.Statut || "")) {
      if (
        (await msgBox({
          titre: "Supprimer",
          msg: "Demande traitée. Suppression impossible",
          typMsg: "warning",
          typReply: "OkOnly",
          async handleCancel() {
            return;
          },
        })) === "Cancel"
      )
        return;
    }
    const rslSave = await myAxios("delete_demande_conge", {
      Num_Conge: entete.Num_Conge,
    });
    if (rslSave.data.result) {
      setCurrentNum("");
      alert({
        titre: "Suppression",
        msg: "Demande supprimée.",
        typMsg: "success",
        timeOut: -1,
      });
    } else {
      alert({
        titre: "Suppression",
        msg: `Erreur. Suppression impossible veuillez réessayer.`,
        typMsg: "error",
        timeOut: -10,
      });
    }
  }, [entete, currentNum]);
  useEffect(() => {
    const _canSave =
      isAccessible.canModify &&
      (entete
        ? entete?.Statut === "" && entete?.Matricule === Agent?.Matricule
        : true);
    setCanSave(_canSave);
    settbnMenu([
      {
        name: "Accessible",
        disabled: false,
        libelle: "Accessible",
        action: NonAccessible,
        icon: <VisibilityOff />,
        visible: !isAccessible?.canModify ? "visible" : "none",
      },
      {
        name: "Enregisrer",
        disabled: !_canSave,
        libelle: "Enregisrer",
        action: Enregistrer,
        icon: <SaveAsOutlined />,
      },
      {
        name: "Nouveau",
        disabled: false,
        libelle: "Nouveau",
        action: Nouveau,
        icon: <Add />,
      },
      {
        name: "Supprimer",
        disabled: !_canSave,
        libelle: "Supprimer",
        action: Supprimer,
        icon: <DeleteOutline />,
      },
      {
        name: "Imprimer",
        disabled: false,
        libelle: "Imprimer",
        action: () =>
          navigate("/viewer", {
            state: {
              reportName: "DemandeConge",
              params: { NumConge: currentNum },
            } as TReport,
          }),
        icon: <PrintOutlined />,
      },
      {
        name: "SS",
        disabled: false,
        libelle:
          !entete?.Statut || entete?.Statut === "" || entete?.Statut === "NSS"
            ? "Soumettre pour signature"
            : findRubrique("Statut_Signature", entete.Statut),
        action: SoumettreEnSignature,
        icon: <DrawOutlined />,
      },
      {
        name: "PJ",
        disabled: false,
        libelle: "Pièces jointes",
        action: () => {
          if (currentNum) {
            setGEDprops({
              name_ecran: "RH_Demande_Conge",
              valeur_index: currentNum,
            });
            setShowGED(true);
          }
        },
        icon: <AttachFileOutlined />,
      },
    ]);
  }, [
    isAccessible.canModify,
    entete?.Statut,
    entete?.Matricule,
    Enregistrer,
    Nouveau,
    currentNum,
  ]);
  useEffect(() => console.log(ligne), [ligne]);
  return (
    <>
      <GroupBox
        label="Demande de congé"
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px 5px 5px",
            width: "90vw",
            maxWidth: "1200px",
            minHeight: "10em",
          },
        }}
      >
        <>
          <Grid container spacing={2}>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextZoom
                numZoom="MS019"
                nomControle="Num_Conge"
                label="N° demande"
                valeur={entete?.Num_Conge}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextZoom
                readonly={true}
                numZoom="MS067"
                nomControle="Matricule"
                label="Matricule"
                valeur={entete?.Matricule}
                findlibelle={{
                  champs: "Nom_Agent+ ' ' +Prenom_Agent",
                  code: "Matricule",
                  tblName: "RH_Agent",
                }}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <ComboBox
                label="Type de congé"
                nomControle="Typ_Conge"
                valeur={entete?.Typ_Conge || "CAD"}
                onchange={stateChange}
                numZoom="MS165"
                style={{
                  width: "100%",
                }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="Commentaire"
                label="Commentaire"
                type="text"
                valeur={entete?.Commentaire || ""}
                style={{ width: "100%" }}
                onchange={stateChange}
              />
            </Grid>
            <Grid
              xs={12}
              sm={12}
              lg={6}
              xl={6}
              sx={{ display: "flex", gap: "3px" }}
            >
              <CalendarZoom
                nomControle="Dat_Deb_Conge"
                label="Du"
                valeur={entete?.Dat_Deb_Conge}
                onchange={stateChange}
                sx={{
                  width: "60%",
                  "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                }}
                onClear={() => stateChange("Dat_Deb_Conge", "")}
              />
              <ComboBox
                label="AM/PM"
                nomControle="Dat_Deb_am_pm"
                valeur={entete?.Dat_Deb_am_pm || "am"}
                onchange={stateChange}
                rubrique="am_pm"
                style={{
                  width: "45%",
                }}
              />
            </Grid>
            <Grid
              xs={12}
              sm={12}
              lg={6}
              xl={6}
              sx={{ display: "flex", gap: "3px" }}
            >
              <CalendarZoom
                nomControle="Dat_Fin_Conge"
                label="Au"
                valeur={entete?.Dat_Fin_Conge}
                onchange={stateChange}
                sx={{
                  width: "60%",
                  "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                }}
                onClear={() => stateChange("Dat_Fin_Conge", "")}
              />
              <ComboBox
                label="AM/PM"
                nomControle="Dat_Fin_am_pm"
                valeur={entete?.Dat_Fin_am_pm || "am"}
                onchange={stateChange}
                rubrique="am_pm"
                style={{
                  width: "45%",
                }}
              />
            </Grid>
            <Grid xs={6} sm={6} lg={3} xl={3}>
              <TextBox
                nomControle="Duree_Globale"
                label="Durée"
                type="number"
                valeur={entete?.Duree_Globale || 0}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={6} sm={6} lg={3} xl={3}>
              <TextBox
                nomControle="Repos_Hebdomadaire"
                label="Repos hebdomadaire"
                type="number"
                valeur={entete?.Repos_Hebdomadaire || 0}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={6} sm={6} lg={3} xl={3}>
              <TextBox
                nomControle="Jours_Feries"
                label="Jours fériés"
                type="number"
                valeur={entete?.Jours_Feries || 0}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={6} sm={6} lg={3} xl={3}>
              <TextBox
                nomControle="Duree_Conge"
                label="A déduire du congé"
                type="number"
                valeur={entete?.Duree_Conge || 0}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={4} sm={4} lg={4} xl={4}>
              <TextBox
                nomControle="Solde_Conge"
                readonly={true}
                label="Solde de congé"
                type="number"
                valeur={droitsConge?.Solde_Conge}
                style={{ width: "90%" }}
              />
            </Grid>

            <Box
              sx={{
                margin: "auto",
                padding: "5px",
                width: {
                  xs: "96vw",
                  sm: "96vw",
                  md: "80vw",
                },
                overflow: "scroll",
              }}
            >
              <Grille
                readonly={true}
                dataSource={ligne}
                Colonnes={Colonnes}
                className="laGrille"
                onclick={(e) => console.log("first", e)}
              />
            </Box>
          </Grid>
        </>
      </GroupBox>
    </>
  );
};

export default RH_Demande_Conge;
type TEntete = {
  Num_Conge: string;
  Matricule: string;
  Dat_Deb_Conge?: Date;
  Dat_Fin_Conge?: Date;
  Dat_Deb_am_pm?: string;
  Dat_Fin_am_pm?: string;
  Cod_Plan_Paie?: string;
  JourPaie?: number;
  Duree_Globale?: number;
  Repos_Hebdomadaire?: number;
  Jours_Feries?: number;
  LastDatePaie?: Date;
  Duree_Conge?: number;
  Commentaire?: string;
  Typ_Conge?: string;
  Statut?: string;
};
type TConge = {
  Conge_Annuel: number;
  Acquis_Anciennete: number;
  Droit_Conge: number;
  Reliquat_Anterieurs: number;
  Conge_Pris: number;
  Solde_Conge: number;
  Cod_Poste: string;
  Cod_Grade: string;
  Cod_Entite: string;
  Titre: string;
  Cod_Plan_Paie: string;
  Jours_Feries?: number;
  LastDatePaie?: Date;
};
const iniConge: TConge = {
  Conge_Annuel: 0,
  Acquis_Anciennete: 0,
  Droit_Conge: 0,
  Reliquat_Anterieurs: 0,
  Conge_Pris: 0,
  Solde_Conge: 0,
  Cod_Poste: "",
  Cod_Grade: "",
  Cod_Entite: "",
  Titre: "",
  Cod_Plan_Paie: "",
  Jours_Feries: 1,
};
const iniEntete: TEntete = {
  Num_Conge: "",
  Matricule: Agent?.Matricule || "",
  Dat_Deb_Conge: new Date(),
  Dat_Fin_Conge: new Date(),
  Dat_Deb_am_pm: "am",
  Dat_Fin_am_pm: "am",
  Cod_Plan_Paie: "",
  JourPaie: 1,
  Duree_Globale: 0,
  Repos_Hebdomadaire: 0,
  Jours_Feries: 0,
  Duree_Conge: 0,
  Commentaire: "",
  Typ_Conge: "CAD",
  Statut: "",
};
type TLigDemande = {
  Dat_Deb: Date;
  Dat_Fin: Date;
  Duree_Globale: number;
  Repos_Hebdomadaire: number;
  Jours_Feries: number;
  Duree_Conge: number;
};
