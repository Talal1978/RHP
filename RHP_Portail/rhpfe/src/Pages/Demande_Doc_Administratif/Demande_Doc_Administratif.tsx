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
import styled from "styled-components";
import useMsgBox from "../../hooks/useMsgBox";
import isEqual from "lodash.isequal";
import { findRubrique, listRubriques } from "../../modules/module_rubriques";
import useAlert from "../../hooks/useAlert";
import { TReport } from "../../Report/ReportViewer";

const Demande_Doc_Administratif = () => {
    const navigate = useNavigate();
    const alert = useAlert();
    const {
        settbnMenu,
        isSmall,
        setShowSignature,
        setSignatureProps,
        isXs,
        isSm,
        isLg,
        isXl,
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

    useEffect(() => {
        setCurrentNum(num);
        setAccessible({ canModify: true, Taken_By_User: "", Process_Id: "" });
    }, [num]);

    const [entete, setEntete] = useState<TEntete>(iniEntete);
    const [canSave, setCanSave] = useState(false);
    const [detail, setDetail] = useState<TDetail[]>([iniDetail]);
    const enteteRef = useRef<TEntete | undefined>(undefined);
    const detailRef = useRef<TDetail[] | undefined>(undefined);
    const [docTypes, setDocTypes] = useState<ObjetGenerique[]>([]);

    async function ondelete(e: { rowIndex: number; row: ObjetGenerique }) {
        const rsl = await msgBox({
            titre: "Suppression",
            typMsg: "stop",
            typReply: "OKCancel",
            msg: "Etes-vous sûr de vouloir supprimer cette ligne?",
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

    const Colonnes = useMemo<TColonneCollection>(
        () => ({
            Typ_Doc: {
                columnName: "Typ_Doc",
                dataType: "nvarchar",
                readOnly: false,
                visible: true,
                headerText: "Type Document",
                dataSource: docTypes,
                typeColonne: "Combo",
                sx: { minWidth: "15em" },
            },
            Nbr_Exemplaire: {
                columnName: "Nbr_Exemplaire",
                dataType: "int",
                readOnly: false,
                visible: true,
                headerText: "Nbr Ex.",
                typeColonne: "Text",
                sx: { maxWidth: "5em" },
            },
            Dat_Du: {
                columnName: "Dat_Du",
                dataType: "date",
                readOnly: false,
                visible: true,
                headerText: "Du",
                typeColonne: "Calendar",
                sx: { minWidth: "10em" },
            },
            Dat_Au: {
                columnName: "Dat_Au",
                dataType: "date",
                readOnly: false,
                visible: true,
                headerText: "Au",
                typeColonne: "Calendar",
                sx: { minWidth: "10em" },
            },
            Commentaire: {
                columnName: "Commentaire",
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
        [docTypes]
    );

    function stateChange(champs: string, valeur: any) {
        if (champs === "Num_Demande" && currentNum !== valeur) {
            setCurrentNum(valeur);
        }
        setEntete((prv: TEntete) => {
            const newState = { ...prv, [champs]: valeur };
            return newState;
        });
    }

    const myAxios = useAxiosPost();

    useEffect(() => {
        setDocTypes(listRubriques("Typ_Doc_Admin"));
    }, []);

    const loadData = useCallback(async () => {
        if (currentNum !== "" && currentNum !== "new") {
            await myAxios("get_demande_doc_admin", { num_demande: currentNum })
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
                    setEntete(iniEntete);
                    setDetail([iniDetail]);
                    enteteRef.current = iniEntete;
                    detailRef.current = [iniDetail];
                });
        } else {
            setEntete(iniEntete);
            setDetail([iniDetail]);
        }
    }, [currentNum]);

    const manageAccess = useCallback(async () => {
        if (canSave) {
            if (currentNum !== "" && currentNum !== "new") {
                await myAxios("check_accessible", {
                    nameEcran: "Demande_Doc_Admin",
                    idEcran: currentNum,
                }).then((dt) => {
                    setAccessible(dt.data);
                });
            } else {
                await myAxios("release_accessible", {
                    nameEcran: "Demande_Doc_Admin",
                    idEcran: currentNum,
                });
            }
        }
    }, [currentNum, canSave]);

    useEffect(() => {
        loadData();
        setSignatureProps({ typ_document: "DD", valeur_index: currentNum || "" });
        return () => {
            if (currentNum !== "" && currentNum !== "new") {
                myAxios("release_accessible", {
                    nameEcran: "Demande_Doc_Admin",
                    idEcran: currentNum,
                });
            }
        };
    }, [loadData]);

    useEffect(() => {
        manageAccess();
    }, [manageAccess]);

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
                    msg: "Demande traitée. Modification impossible.",
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

            let _entete = { ...entete };
            if (Statut === "SS") _entete = { ..._entete, Statut };
            const rslSave = await myAxios("save_demande_doc_admin", {
                entete: _entete,
                detail,
            });
            if (rslSave.data.result) {
                const numN = rslSave.data.data[0].Num_Demande;
                if (numN !== currentNum) {
                    setCurrentNum(numN);
                } else {
                    await loadData();
                }
                alert({
                    titre: "Enregistrer",
                    msg: "Enregistré avec succès",
                    typMsg: "success",
                    timeOut: -1,
                });
            } else {
                alert({
                    titre: "Erreur",
                    msg: rslSave.data.message || "Erreur lors de l'enregistrement",
                    typMsg: "error",
                });
            }
        },
        [entete, detail, currentNum]
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
        if (currentNum !== "" && currentNum !== "new") {
            await myAxios("release_accessible", {
                nameEcran: "Demande_Doc_Admin",
                idEcran: currentNum,
            });
        }
        navigate("/myspace/Demande_Doc_Administratif/Demande Documents/new");
    }, [entete, detail, currentNum]);

    const SoumettreEnSignature = useCallback(async () => {
        if (!currentNum) return;
        if (entete.Statut === "" || entete.Statut === "NSS") {
            if (
                (await msgBox({
                    titre: "Signature",
                    msg: "Êtes-vous sûr de vouloir soumettre cette demande en signature?",
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
    }, [Enregistrer, currentNum, entete.Statut]);

    const Supprimer = useCallback(async () => {
        if (entete?.Num_Demande) {
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
        const rslSave = await myAxios("delete_demande_doc_admin", {
            Num_Demande: entete.Num_Demande,
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
    }, [entete]);

    useEffect(() => {
        const _canSave =
            isAccessible.canModify &&
            (entete
                ? (!entete?.Statut || entete?.Statut === "") && entete?.Matricule === Agent?.Matricule
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
                name: "Enregistrer",
                disabled: !_canSave,
                libelle: "Enregistrer",
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
                color: "error.main",
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
                        setGEDprops({ name_ecran: "Demande_Doc_Admin", valeur_index: currentNum });
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
                label="Demande Document"
                showBorders={!isSmall}
                showTitre={true}
                sx={{
                    "& .grpDiv": {
                        padding: "2em 5px 5px 5px",
                        width: "100%",
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
                                nomControle="Num_Demande"
                                label="N° demande"
                                valeur={entete?.Num_Demande}
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
                        <Grid xs={12} sm={6} lg={3} xl={3}>
                            <TextBox
                                readonly={true}
                                nomControle="Etat_Traitement"
                                label="Etat Traitement"
                                valeur={entete?.Etat_Traitement || ""}
                                onchange={stateChange}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12}>           </Grid>
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
                                setDetail((prv: TDetail[]) => {
                                    const usedTypes = prv.map((d) => d.Typ_Doc);
                                    let availableType = "";
                                    for (const type of docTypes) {
                                        if (!usedTypes.includes(type.valeur)) {
                                            availableType = type.valeur;
                                            break;
                                        }
                                    }
                                    // If all types are used, fallback to the first one or empty string
                                    if (!availableType && docTypes.length > 0) {
                                        availableType = String(docTypes[0].valeur);
                                    }

                                    const newDetail: TDetail = {
                                        ...iniDetail,
                                        Dat_Du: new Date(),
                                        Dat_Au: new Date(),
                                        Typ_Doc: String(availableType),
                                    };
                                    return [...prv, newDetail];
                                });
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
            </Box>
        </>
    );
};

export default Demande_Doc_Administratif;

type TEntete = {
    Num_Demande: string;
    Lib_Demande?: string;
    Matricule?: string;
    Dat_Demande?: Date;
    Commentaire?: string;
    Statut?: string;
    Etat_Traitement?: string;
};

export const iniEntete: TEntete = {
    Num_Demande: "",
    Lib_Demande: "",
    Matricule: Agent?.Matricule,
    Dat_Demande: new Date(),
    Commentaire: "",
    Statut: "",
    Etat_Traitement: "",
};

type TDetail = {
    Typ_Doc?: string;
    Nbr_Exemplaire?: number;
    Dat_Du?: Date | null;
    Dat_Au?: Date | null;
    Commentaire?: string;
    RowId?: number;
};
export const iniDetail: TDetail = {
    Typ_Doc: "",
    Nbr_Exemplaire: 1,
    Dat_Du: new Date(),
    Dat_Au: new Date(),
    Commentaire: "",
    RowId: 0,
};
