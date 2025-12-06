import { useCallback, useContext, useEffect, useRef, useState } from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import { ObjetGenerique, TMenuBtn } from "../../types";
import {
  Add,
  AttachFileOutlined,
  DeleteOutline,
  DrawOutlined,
  PrintOutlined,
  SaveAsOutlined,
  VisibilityOff,
} from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate, useParams } from "react-router-dom";
import TextBox from "../../components/TextBox/TextBox";
import { cntX } from "../../Menu/MenuMain";
import useMsgBox from "../../hooks/useMsgBox";
import isEqual from "lodash.isequal";
import { findRubrique } from "../../modules/module_rubriques";
import useAlert from "../../hooks/useAlert";
import { TReport } from "../../Report/ReportViewer";

const Demande_Avance = () => {
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
  const [info, setInfo] = useState<TInfo>(initInfo);
  const { num } = useParams();
  const [isAccessible, setAccessible] = useState<{
    canModify: boolean;
    Taken_By_User: string;
    Process_Id: string;
  }>({ canModify: true, Taken_By_User: "", Process_Id: "" });
  const [currentNum, setCurrentNum] = useState(num);
  const [entete, setEntete] = useState<TEntete>(iniEntete);
  const [canSave, setCanSave] = useState(false);
  const enteteRef = useRef<TEntete>();
  const myAxios = useAxiosPost();
  const { isXs, isSm, isLg, isXl } = useContext(cntX);
  useEffect(() => {
    myAxios("get_mnt_avances_encours", { Matricule: entete?.Matricule })
      .then((dt) => {
        if (dt.data.result) {
          setInfo(dt.data.data[0]);
        } else {
          setInfo(initInfo);
        }
      })
      .catch((err) => {

        setInfo(initInfo);
      });
  }, [entete?.Matricule, currentNum]);
  function stateChange(champs: string, valeur: any) {
    if (champs === "Num_Avance" && currentNum !== valeur) {
      setCurrentNum(valeur);
    } else
      setEntete((prv: TEntete) => {
        const newState = { ...prv, [champs]: valeur };
        return newState;
      });
  }
  const Request = useCallback(async () => {
    if (currentNum !== "" && currentNum !== "new") {
      await myAxios("get_demande_avance", { num_avance: currentNum })
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
    }
    if (canSave) {
      if (currentNum !== "" && currentNum !== "new") {
        await myAxios("check_accessible", {
          nameEcran: "Demande_Avance",
          idEcran: currentNum,
        }).then((dt) => {
          setAccessible(dt.data);
        });
      } else {
        await myAxios("release_accessible", {
          nameEcran: "Demande_Avance",
          idEcran: currentNum,
        });
      }
    }
  }, [currentNum, canSave]);

  useEffect(() => {
    Request();
    setSignatureProps({ typ_document: "AV", valeur_index: currentNum ?? "" });
    return () => {
      if (currentNum !== "" && currentNum !== "new") {
        myAxios("release_accessible", {
          nameEcran: "Demande_Avance",
          idEcran: currentNum,
        });
      }
    };
  }, [Request]);
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
          msg: "Vous ne pouvez pas saisir une Demande pour un autre matricule.",
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
      const rslSave = await myAxios("save_demande_avance", {
        entete: _entete,
      });
      if (rslSave.data.result) {
        const numN = rslSave.data.data[0].Num_Avance;
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
    if (entete?.Num_Avance) {
      if (
        (await msgBox({
          titre: "Supprimer",
          msg: "Êtes-vous sûr de vouloir supprimer cette Demande?",
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
        msg: "Vous ne pouvez pas supprimer une Demande d'un autre matricule.",
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
    const rslSave = await myAxios("delete_Demande_Avance", {
      num_avance: entete.Num_Avance,
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
              reportName: "DemandeAvance",
              params: { NumAvance: currentNum },
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
              name_ecran: "RH_Demande_Avance",
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
  return (
    <>
      <GroupBox
        label="Demande d'avance"
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px 5px 5px",
            width: "90vw",
            maxWidth: "1000px",
            minHeight: "10em",
          },
        }}
      >
        <>
          <Grid container spacing={2}>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextZoom
                numZoom="MS020"
                nomControle="Num_Avance"
                label="N° demande"
                valeur={entete?.Num_Avance}
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
              <CalendarZoom
                nomControle="Dat_Demande"
                label="Date"
                valeur={entete?.Dat_Demande || new Date()}
                onchange={stateChange}
                sx={{
                  width: "100%",
                  "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                }}
                onClear={() => stateChange("Dat_Demande", "")}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="Montant_Avance"
                label="Montant"
                type="number"
                valeur={entete?.Montant_Avance || 0}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="montant_avances_encours"
                disabled={true}
                label="Avances en cours"
                type="number"
                valeur={info?.montant_avances_encours ?? 0}
                //onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="dernier_salaire"
                disabled={true}
                label="Dernier salaire"
                type="number"
                valeur={info?.dernier_salaire ?? 0}
                //onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <ComboBox
                readOnly={true}
                rubrique="Statut"
                nomControle="Statut"
                label="Statut"
                valeur={entete?.Statut || ""}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12}>
              <TextBox
                nomControle="Commentaire"
                label="Commentaire"
                multiline={true}
                rows={isXs || isSm ? 4 : 2}
                valeur={entete?.Commentaire || ""}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
          </Grid>
        </>
      </GroupBox>
    </>
  );
};

export default Demande_Avance;
type TEntete = {
  Num_Avance: string;
  Matricule?: string;
  Dat_Demande?: Date;
  Montant_Avance?: number;
  Dernier_Salaire?: number;
  Commentaire?: string;
  Statut?: string;
};
export const iniEntete: TEntete = {
  Num_Avance: "",
  Matricule: Agent?.Matricule,
  Dat_Demande: new Date(),
  Montant_Avance: 0,
  Dernier_Salaire: 0,
  Commentaire: "",
  Statut: "",
};

type TInfo = { montant_avances_encours: number; dernier_salaire: number };
const initInfo: TInfo = { montant_avances_encours: 0, dernier_salaire: 0 };
