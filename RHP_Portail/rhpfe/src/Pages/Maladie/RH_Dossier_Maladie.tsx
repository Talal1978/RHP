import { useCallback, useContext, useEffect, useRef, useState } from "react";
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
import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
} from "@mui/material";
import { estDate, formatDateFR } from "../../modules/module_formats";
import { Arrondi } from "../../modules/module_general_formulas";

const RH_Dossier_Maladie = () => {
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
  const [canSave, setCanSave] = useState(false);
  const enteteRef = useRef<TEntete>();
  const myAxios = useAxiosPost();
  const { isXs, isSm, isLg, isXl } = useContext(cntX);
  function stateChange(champs: string, valeur: any) {
    if (champs === "Num_Dossier" && currentNum !== valeur) {
      setCurrentNum(valeur);
    } else
      setEntete((prv: TEntete) => {
        const newState = { ...prv, [champs]: valeur };
        return newState;
      });
  }
  const Request = useCallback(async () => {
    if (currentNum !== "" && currentNum !== "new") {
      await myAxios("get_dossier_maladie", { Num_Dossier: currentNum })
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
          nameEcran: "RH_Dossier_Maladie",
          idEcran: currentNum,
        }).then((dt) => {
          setAccessible(dt.data);
        });
      } else {
        await myAxios("release_accessible", {
          nameEcran: "RH_Dossier_Maladie",
          idEcran: currentNum,
        });
      }
    }
  }, [currentNum, canSave]);

  useEffect(() => {
    Request();
    setSignatureProps({ typ_document: "DM", valeur_index: currentNum ?? "" });
    return () => {
      if (currentNum !== "" && currentNum !== "new") {
        myAxios("release_accessible", {
          nameEcran: "RH_Dossier_Maladie",
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
          msg: "Vous ne pouvez pas saisir un dossier pour un autre matricule.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if ((entete?.Mnt_Engage ?? 0) <= 0) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Aucun montant engagé n'est renseigné.",
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
      const rslSave = await myAxios("save_dossier_maladie", {
        entete: _entete,
      });
      if (rslSave.data.result) {
        const numN = rslSave.data.data[0].Num_Dossier;
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
    if (entete?.Num_Dossier) {
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
    const rslSave = await myAxios("delete_dossier_maladie", {
      Num_Dossier: entete.Num_Dossier,
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
              reportName: "DemandePret",
              params: { NumDemandePret: currentNum },
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
              name_ecran: "RH_Dossier_Maladie",
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
        label="Dossier de remboursement maladie"
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
                numZoom="MS022"
                nomControle="Num_Dossier"
                label="N° dossier"
                valeur={entete?.Num_Dossier}
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
              <FormControl>
                <FormLabel id="demo-row-radio-buttons-group-label">
                  Gender
                </FormLabel>
                <RadioGroup
                  row
                  aria-labelledby="demo-row-radio-buttons-group-label"
                  name="row-radio-buttons-group"
                >
                  <FormControlLabel
                    value="Rd_1"
                    control={
                      <Radio
                        checked={!entete?.Lien}
                        onChange={() =>
                          setEntete((prv: TEntete) => ({
                            ...prv,
                            Lien: "",
                            Nom_Malade: "",
                          }))
                        }
                      />
                    }
                    label="L'agent lui même"
                  />
                  <FormControlLabel
                    value="Rd_2"
                    control={
                      <Radio
                        checked={entete?.Lien ? true : false}
                        onChange={() =>
                          setEntete((prv: TEntete) => ({
                            ...prv,
                            Lien: "L",
                            Nom_Malade: "",
                          }))
                        }
                      />
                    }
                    label="Un membre de la famille"
                  />
                </RadioGroup>
              </FormControl>
            </Grid>
            {entete?.Lien !== "" && (
              <Grid xs={12} sm={12} lg={6} xl={6}>
                <ComboBox
                  label="Le malade"
                  nomControle="Nom_Malade"
                  valeur={entete?.Nom_Malade}
                  onchange={stateChange}
                  numZoom="MS023"
                  conditionZoom={`Matricule='${entete.Matricule}'`}
                />
              </Grid>
            )}{" "}
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <ComboBox
                label="Maladie"
                nomControle="Typ_Maladie"
                valeur={entete?.Typ_Maladie}
                onchange={stateChange}
                rubrique="Typ_Maladie"
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <CalendarZoom
                nomControle="Dat_Dossier"
                label="Date"
                valeur={entete?.Dat_Dossier || new Date()}
                onchange={stateChange}
                sx={{
                  width: "100%",
                  "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                }}
                onClear={() => stateChange("Dat_Dossier", "")}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="Mnt_Engage"
                label="Montant"
                type="number"
                valeur={entete?.Mnt_Engage || 0}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="Envoye_Le"
                label="Envoyé le"
                type="text"
                readonly={true}
                valeur={
                  estDate(entete?.Envoye_Le)
                    ? formatDateFR(entete?.Envoye_Le)
                    : ""
                }
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <TextBox
                nomControle="Rembourse_Le"
                label="Remboursé le"
                type="text"
                readonly={true}
                valeur={entete?.Rembourse_Le}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={6} xl={6}>
              <div
                style={{
                  width: "100%",
                  display: "flex",
                  gap: "1em",
                  alignItems: "center",
                }}
              >
                <TextBox
                  nomControle="Mnt_Remboursement"
                  label="Montant remboursé"
                  type="number"
                  readonly={true}
                  valeur={entete?.Mnt_Remboursement ?? 0}
                  onchange={stateChange}
                  style={{ width: "80%" }}
                />
                <div
                  style={{
                    marginTop: "16px",
                  }}
                >
                  {` ${Arrondi(
                    (entete?.Mnt_Engage ?? 0) > 0
                      ? (entete?.Mnt_Remboursement ?? 0) /
                          (entete!.Mnt_Engage ?? 1)
                      : 0,
                    2
                  )}%`}
                </div>
              </div>
            </Grid>
          </Grid>
        </>
      </GroupBox>
    </>
  );
};

export default RH_Dossier_Maladie;
type TEntete = {
  Num_Dossier: string;
  Matricule?: string;
  Dat_Dossier?: Date;
  Nom_Malade?: string;
  Lien?: string;
  Typ_Maladie?: string;
  Medecin?: string;
  Mnt_Engage?: number;
  Mnt_Remboursement?: number;
  Envoye_Le?: string;
  Rembourse_Le?: string;
  Commentaire?: string;
  Statut?: string;
};
export const iniEntete: TEntete = {
  Num_Dossier: "",
  Matricule: Agent?.Matricule,
  Dat_Dossier: new Date(),
  Nom_Malade: "",
  Lien: "",
  Typ_Maladie: "",
  Medecin: "",
  Mnt_Engage: 0,
  Mnt_Remboursement: 0,
  Envoye_Le: "",
  Rembourse_Le: "",
  Commentaire: "",
  Statut: "",
};
