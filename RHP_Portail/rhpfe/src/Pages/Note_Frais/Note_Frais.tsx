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
import { Box } from "@mui/material";
import Grille, {
  TColonneCollection,
  TGrilleAction,
} from "../../components/Grille/Grille";
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
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate, useParams } from "react-router-dom";
import TextBox from "../../components/TextBox/TextBox";
import { cntX } from "../../Menu/MenuMain";
import { Arrondi, Monetaire } from "../../modules/module_general_formulas";
import styled from "styled-components";
import useMsgBox from "../../hooks/useMsgBox";
import isEqual from "lodash.isequal";
import { findRubrique, listRubriques } from "../../modules/module_rubriques";
import useAlert from "../../hooks/useAlert";
import { TReport } from "../../Report/ReportViewer";
const TotalFrais = styled.div`
  padding: 1em;
  font-size: inherit;
  font-weight: bold;
  width: 100%;
  text-align: center;
  color: ${colorBase.colorBase01};
`;
const Note_Frais = () => {
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
  const [action, setAction] = useState<TGrilleAction>("");
  const { num } = useParams();
  const [isAccessible, setAccessible] = useState<{
    canModify: boolean;
    Taken_By_User: string;
    Process_Id: string;
  }>({ canModify: true, Taken_By_User: "", Process_Id: "" });
  const [currentNum, setCurrentNum] = useState(num);
  const [entete, setEntete] = useState<TEntete>(iniEntete);
  const [canSave, setCanSave] = useState(false);
  const [detail, setDetail] = useState<TDetail[]>([iniDetail]);
  const enteteRef = useRef<TEntete>();
  const detailRef = useRef<TDetail[]>();
  const [natureFrais, setNatureFrais] = useState<ObjetGenerique[]>([]);
  async function ondelete(e: { rowIndex: number; row: ObjetGenerique }) {
    const rsl = await msgBox({
      titre: "Suppression",
      typMsg: "stop",
      typReply: "OKCancel",
      msg: "Etes-vous sûr de vouloir supprimer  cette ligne?",
      async handleOk() {
        setDetail((prv: TDetail[]) => {
          const newArr = [...prv];
          newArr.splice(e.rowIndex, 1);
          return newArr;
        });
      },
      async handleCancel() {
        setAction("");
      },
    });
  }
  const totalFrais = useMemo<number>(() => {
    return detail.reduce((total, val) => (total = total + (val?.Mnt ?? 0)), 0);
  }, [detail]);
  const Colonnes = useMemo<TColonneCollection>(
    () => ({
      Typ_Frais: {
        columnName: "Typ_Frais",
        dataType: "nvarchar",
        readOnly: false,
        visible: true,
        headerText: "Frais",
        dataSource: natureFrais,
        typeColonne: "Combo",
        sx: { minWidth: "10em" },
      },
      Base: {
        columnName: "Base",
        dataType: "float",
        readOnly: false,
        visible: true,
        headerText: "Base",
        typeColonne: "Text",
        sx: { maxWidth: "4em" },
      },
      Tx: {
        columnName: "Tx",
        dataType: "float",
        readOnly: false,
        visible: true,
        headerText: "Taux",
        typeColonne: "Text",
        sx: { maxWidth: "4em" },
      },
      Mnt: {
        columnName: "Mnt",
        dataType: "float",
        readOnly: true,
        visible: true,
        headerText: "Montant",
        typeColonne: "Text",
        sx: { maxWidth: "4em" },
      },
      Comment: {
        columnName: "Comment",
        dataType: "nvarchar",
        readOnly: false,
        visible: true,
        headerText: "Commentaire",
        typeColonne: "Text",
        sx: { minWidth: "20em" },
      },
      RowId: {
        columnName: "RowId",
        dataType: "int",
        readOnly: false,
        visible: false,
        headerText: "RowId",
        typeColonne: "Text",
      },
    }),
    [natureFrais]
  );
  function stateChange(champs: string, valeur: any) {
    if (champs === "Num_NF" && currentNum !== valeur) {
      setCurrentNum(valeur);
    }
    setEntete((prv: TEntete) => {
      const newState = { ...prv, [champs]: valeur };
      return newState;
    });
  }
  const myAxios = useAxiosPost();
  const { isXs, isSm, isLg, isXl } = useContext(cntX);
  useEffect(() => {
    setNatureFrais(listRubriques("Typ_Frais"));
  }, []);
  const Request = useCallback(async () => {
    if (currentNum !== "" && currentNum !== "new") {
      await myAxios("get_note_frais", { num_nf: currentNum })
        .then((dt) => {
          if (dt.data && dt.data?.result) {
            setEntete(dt.data.entete);
            setDetail(dt.data.detail);
            enteteRef.current = dt.data.entete;
            detailRef.current = dt.data.detail;
          } else {
            setEntete(iniEntete);
            setDetail([iniDetail]);
            enteteRef.current = iniEntete;
            detailRef.current = [iniDetail];
          }
        })
        .catch((err) => {
          console.log("Erreur ", err);
          setEntete(iniEntete);
          setDetail([iniDetail]);
          enteteRef.current = iniEntete;
          detailRef.current = [iniDetail];
        });
    } else {
      setEntete(iniEntete);
      setDetail([iniDetail]);
    }
    if (canSave) {
      if (currentNum !== "" && currentNum !== "new") {
        await myAxios("check_accessible", {
          nameEcran: "Note_Frais",
          idEcran: currentNum,
        }).then((dt) => {
          setAccessible(dt.data);
        });
      } else {
        await myAxios("release_accessible", {
          nameEcran: "Note_Frais",
          idEcran: currentNum,
        });
      }
    }
  }, [currentNum, canSave]);

  useEffect(() => {
    Request();
    setSignatureProps({ typ_document: "NF", valeur_index: currentNum || "" });
    return () => {
      if (currentNum !== "" && currentNum !== "new") {
        myAxios("release_accessible", {
          nameEcran: "Note_Frais",
          idEcran: currentNum,
        });
      }
    };
  }, [Request]);
  function onChange(obj: {
    rowIndex: number;
    columnName: string;
    valeur: any;
  }) {
    const _detail = [...detail];
    let _row = {
      ..._detail[obj.rowIndex],
      [obj.columnName]: obj.valeur,
    };
    if (obj.columnName === "Tx" || obj.columnName === "Base") {
      _row = {
        ..._row,
        Mnt: Arrondi((_row?.["Tx"] || 0) * (_row?.["Base"] || 0), 2),
      };
    }
    _detail[obj.rowIndex] = {
      ..._row,
    };
    setDetail(_detail);
  }
  const Enregistrer = useCallback(
    async (Statut: "NSS" | "SS" | "SG" | "RJ" | "SP" | "" = "") => {
      if (["SG", "RJ", "SP", "VA"].includes(entete?.Statut || "")) {
        await msgBox({
          titre: "Enregistrer",
          msg: "Note de frais traitée. Modification impossible.",
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
          msg: "Vous ne pouvez pas saisir une note de frais pour un autre matricule.",
          typMsg: "error",
          typReply: "OkOnly",
          async handleOk() {
            return;
          },
        });
        return;
      }
      if (totalFrais === 0) {
        if (
          (await msgBox({
            titre: "Enregistrer",
            msg: "Le Total des frais engagés est null. Voulez-vous continuer?",
            typMsg: "warning",
            typReply: "OKCancel",
            async handleCancel() {
              return;
            },
          })) === "Cancel"
        )
          return;
      }
      let _entete = { ...entete, Mnt_NF: totalFrais };
      if (Statut === "SS") _entete = { ..._entete, Statut };
      const rslSave = await myAxios("save_note_frais", {
        entete: _entete,
        detail,
      });
      if (rslSave.data.result) {
        const numN = rslSave.data.data[0].Num_NF;
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
    [entete, detail]
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
    if (
      !isEqual(entete, enteteRef.current) ||
      !isEqual(detail, detailRef.current)
    ) {
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
  }, [entete, detail]);
  const SoumettreEnSignature = useCallback(async () => {
    if (!currentNum) return;
    if (entete.Statut === "" || entete.Statut === "NSS") {
      if (
        (await msgBox({
          titre: "Signature",
          msg: "Êtes-vous sûr de vouloir soumettre cette note de frais en signature?",
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
    if (entete?.Num_NF) {
      if (
        (await msgBox({
          titre: "Supprimer",
          msg: "Êtes-vous sûr de vouloir supprimer cette note de frais?",
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
        msg: "Vous ne pouvez pas supprimer une note de frais d'un autre matricule.",
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
          msg: "Note de frais traitée. Suppression impossible",
          typMsg: "warning",
          typReply: "OkOnly",
          async handleCancel() {
            return;
          },
        })) === "Cancel"
      )
        return;
    }
    const rslSave = await myAxios("delete_note_frais", {
      Num_NF: entete.Num_NF,
    });
    if (rslSave.data.result) {
      setCurrentNum("");
      alert({
        titre: "Suppression",
        msg: "Note de frais supprimée.",
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
  }, [entete, detail, currentNum]);
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
              reportName: "NoteFrais",
              params: { NumNF: currentNum },
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
            setGEDprops({ name_ecran: "Note_Frais", valeur_index: currentNum });
            setShowGED(true);
          }
        },
        icon: <AttachFileOutlined />,
      },
    ]);
  }, [
    totalFrais,
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
        label="Note de frais"
        showBorders={!isSmall}
        showTitre={true}
        sx={{
          "& .grpDiv": {
            padding: "2em 5px 5px 5px",
            width: "90vw",
            minHeight: "10em",
          },
        }}
      >
        <>
          <Grid container spacing={2}>
            <Grid xs={12} sm={12} lg={4} xl={3}>
              <TextZoom
                readonly={true}
                numZoom="MS091"
                nomControle="Num_NF"
                label="N° demande"
                valeur={entete?.Num_NF}
                onchange={stateChange}
                style={{ width: "100%" }}
              />
            </Grid>
            <Grid xs={12} sm={12} lg={4} xl={3}>
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
            <Grid xs={12} sm={6} lg={3} xl={3}>
              <CalendarZoom
                nomControle="Dat_NF"
                label="Date"
                valeur={entete?.Dat_NF || new Date()}
                onchange={stateChange}
                sx={{
                  width: "100%",
                  "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                }}
                onClear={() => stateChange("Dat_Du", "")}
              />
            </Grid>
            <Grid xs={12} sm={6} lg={3} xl={3}>
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
          <div
            style={{
              maxWidth: isXl || isLg ? "30vw" : "100%",
              width: isXl || isLg ? "30vw" : "100%",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              gap: "1em",
              margin: "3em auto 0.5em auto",
            }}
          >
            <Bouton
              disabled={!canSave}
              iconOnly={isXs || isSm}
              variant={isXs || isSm ? "contained" : "outlined"}
              sx={{ flexGrow: 1 }}
              label="Ajouter"
              startIcon={<Add />}
              onClick={() => {
                setDetail((prv: TDetail[]) => [...prv, iniDetail]);
              }}
            />
            <Bouton
              disabled={!canSave}
              sx={{ flexGrow: 1 }}
              variant="contained"
              color="error"
              iconOnly={isXs || isSm}
              label="Supprimer"
              startIcon={<DeleteOutline />}
              onClick={() => {
                setAction((prv: string) => (prv === "" ? "supprimer" : ""));
              }}
            />
          </div>
        </>
      </GroupBox>
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
          readonly={false}
          dataSource={detail}
          Colonnes={Colonnes}
          className="laGrille"
          onchange={onChange}
          action={action}
          ondelete={ondelete}
        />
        <TotalFrais>
          Total des frais engagés : {Monetaire(totalFrais)}
        </TotalFrais>
      </Box>
      {/* <Signature /> */}
    </>
  );
};

export default Note_Frais;
type TEntete = {
  Num_NF: string;
  Lib_NF?: string;
  Matricule?: string;
  Dat_NF?: Date;
  Mnt_NF?: number;
  Commentaire?: string;
  Statut?: string;
};
export const iniEntete: TEntete = {
  Num_NF: "",
  Lib_NF: "",
  Matricule: Agent?.Matricule,
  Dat_NF: new Date(),
  Mnt_NF: 0,
  Commentaire: "",
  Statut: "",
};
type TDetail = {
  Typ_Frais?: string;
  Base?: number;
  Tx?: number;
  Mnt?: number;
  Comment?: string;
  RowId?: number;
};
export const iniDetail: TDetail = {
  Typ_Frais: "HEB",
  Base: 0,
  Tx: 0,
  Mnt: 0,
  Comment: "",
  RowId: 0,
};
