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
import useAxiosGet from "../../hooks/useAxiosGet";
import { useNavigate, useParams } from "react-router-dom";
import TextBox from "../../components/TextBox/TextBox";
import { cntX } from "../../Menu/MenuMain";
import useMsgBox from "../../hooks/useMsgBox";
import isEqual from "lodash.isequal";
import { findRubrique, listRubriques } from "../../modules/module_rubriques";
import useAlert from "../../hooks/useAlert";
import { TReport } from "../../Report/ReportViewer";

const Outillage_Mouvement = () => {
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
        setShowLoading,
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
    const [detail, setDetail] = useState<TDetail[]>([]);
    const enteteRef = useRef<TEntete | undefined>(undefined);
    const savingRef = useRef(false); // anti double-soumission (clics multiples)
    const detailRef = useRef<TDetail[] | undefined>(undefined);
    const [agentInfo, setAgentInfo] = useState<{ Cod_Poste?: string; Cod_Entite?: string }>({});
    const [codOutillageSel, setCodOutillageSel] = useState("");
    const [typMouvementOptions, setTypMouvementOptions] = useState<ObjetGenerique[]>([]);
    const myAxios = useAxiosPost();
    const myAxiosGet = useAxiosGet();

    useEffect(() => {
        const local = listRubriques("Typ_Mouvement_Outillage");
        if (local.length > 0) {
            setTypMouvementOptions(local);
        } else {
            myAxiosGet({ apiStr: "rubrique?rubrique=Typ_Mouvement_Outillage" })
                .then((dt: any) => {
                    if (dt.data?.result && dt.data.data?.length > 0) {
                        setTypMouvementOptions(
                            dt.data.data.map((item: any) => ({
                                valeur: item.value,
                                membre: item.label,
                            }))
                        );
                    }
                })
                .catch(() => {});
        }
    }, []);

    // Renseigne automatiquement Poste et Entité dès que le matricule est connu
    // (saisie manuelle, matricule pré-rempli de l'agent connecté, ou chargement d'un mouvement)
    useEffect(() => {
        setAgentInfo({});
        if (!entete?.Matricule) return;
        myAxios("rh_agent", { Matricule: entete.Matricule })
            .then((dt) => {
                if (dt.data?.result && dt.data.data?.agent?.length > 0) {
                    const a = dt.data.data.agent[0];
                    setAgentInfo({
                        Cod_Poste: a.Cod_Poste || "",
                        Cod_Entite: a.Cod_Entite || "",
                    });
                }
            })
            .catch(() => {});
    }, [entete?.Matricule]);

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

    const qteDispoHeader = useMemo(() => {
        return entete?.Typ_Mouvement === "R" ? "Qté détenue" : "Qté disponible";
    }, [entete?.Typ_Mouvement]);

    const Colonnes = useMemo<TColonneCollection>(
        () => ({
            Cod_Outillage: {
                columnName: "Cod_Outillage",
                dataType: "nvarchar",
                readOnly: true,
                visible: true,
                headerText: "Code Outillage",
                typeColonne: "Text",
                sx: { minWidth: "8em" },
            },
            Lib_Outillage: {
                columnName: "Lib_Outillage",
                dataType: "nvarchar",
                readOnly: true,
                visible: true,
                headerText: "Libellé",
                typeColonne: "Text",
                sx: { minWidth: "15em" },
            },
            Typ_Outillage: {
                columnName: "Typ_Outillage",
                dataType: "nvarchar",
                readOnly: true,
                visible: true,
                headerText: "Type",
                typeColonne: "Text",
                sx: { minWidth: "8em" },
            },
            Num_Serie: {
                columnName: "Num_Serie",
                dataType: "nvarchar",
                readOnly: true,
                visible: true,
                headerText: "N° Série",
                typeColonne: "Text",
                sx: { minWidth: "8em" },
            },
            Qte_Dispo: {
                columnName: "Qte_Dispo",
                dataType: "float",
                readOnly: true,
                visible: true,
                headerText: qteDispoHeader,
                typeColonne: "Text",
                sx: { maxWidth: "6em" },
            },
            Qte: {
                columnName: "Qte",
                dataType: "float",
                readOnly: false,
                visible: true,
                headerText: "Quantité",
                typeColonne: "Text",
                sx: { maxWidth: "6em" },
            },
            RowId: {
                columnName: "RowId",
                dataType: "int",
                readOnly: true,
                visible: false,
                headerText: "RowId",
                typeColonne: "Text",
            },
        }),
        [qteDispoHeader]
    );

    function stateChange(champs: string, valeur: any) {
        if (champs === "Num_Mouvement" && currentNum !== valeur) {
            setCurrentNum(valeur);
        }
        if (champs === "Matricule" && (!currentNum || currentNum === "new")) {
            if (entete?.Typ_Mouvement === "R") {
                setDetail([]);
            }
        }
        if (champs === "Typ_Mouvement" && valeur !== entete?.Typ_Mouvement) {
            if (detail.length > 0) {
                msgBox({
                    titre: "Type de mouvement",
                    typMsg: "warning",
                    typReply: "OKCancel",
                    msg: "Le changement du type de mouvement efface les lignes saisies. Continuer?",
                    async handleOk() {
                        setDetail([]);
                        setEntete((prv: TEntete) => ({ ...prv, [champs]: valeur }));
                    },
                    async handleCancel() {
                        return;
                    },
                });
                return;
            }
        }
        setEntete((prv: TEntete) => {
            const newState = { ...prv, [champs]: valeur };
            return newState;
        });
    }

    const loadData = useCallback(async () => {
        setShowLoading(true);
        try {
            if (currentNum !== "" && currentNum !== "new") {
                await myAxios("get_outillage_mouvement", { num_mouvement: currentNum })
                    .then((dt) => {
                        if (dt.data && dt.data?.result) {
                            setEntete(dt.data.entete);
                            setDetail(dt.data.detail);
                            enteteRef.current = dt.data.entete;
                            detailRef.current = dt.data.detail;
                        } else {
                            setEntete(iniEntete);
                            setDetail([]);
                            enteteRef.current = iniEntete;
                            detailRef.current = [];
                        }
                    })
                    .catch((err) => {
                        setEntete(iniEntete);
                        setDetail([]);
                        enteteRef.current = iniEntete;
                        detailRef.current = [];
                    });
            } else {
                setEntete(iniEntete);
                setDetail([]);
                enteteRef.current = iniEntete;
                detailRef.current = [];
            }
        } finally {
            setShowLoading(false);
        }
    }, [currentNum]);

    const manageAccess = useCallback(async () => {
        if (canSave) {
            if (currentNum !== "" && currentNum !== "new") {
                await myAxios("check_accessible", {
                    nameEcran: "RH_Outillage_Mouvement",
                    idEcran: currentNum,
                }).then((dt) => {
                    if (dt?.data && typeof dt.data === "object") setAccessible(dt.data);
                });
            } else {
                await myAxios("release_accessible", {
                    nameEcran: "RH_Outillage_Mouvement",
                    idEcran: currentNum,
                });
            }
        }
    }, [currentNum, canSave]);

    useEffect(() => {
        loadData();
        setSignatureProps({ typ_document: "OTM", valeur_index: currentNum || "" });
        return () => {
            if (currentNum !== "" && currentNum !== "new") {
                myAxios("release_accessible", {
                    nameEcran: "RH_Outillage_Mouvement",
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
        let _row = { ..._detail[obj.rowIndex], [obj.columnName]: obj.valeur };
        // Validation quantité
        if (obj.columnName === "Qte") {
            const qteVal = parseFloat(obj.valeur);
            if (isNaN(qteVal) || qteVal <= 0) {
                _row.Qte = "" as any;
            } else if (qteVal > (_row.Qte_Dispo || 0)) {
                _row.Qte = _row.Qte_Dispo;
            }
        }
        _detail[obj.rowIndex] = _row;
        setDetail(_detail);
    }

    const ajouterLigne = useCallback(async () => {
        if (!entete?.Typ_Mouvement) {
            await msgBox({
                titre: "Outillage",
                msg: "Sélectionnez d'abord le type de mouvement.",
                typMsg: "error",
                typReply: "OkOnly",
            });
            return;
        }
        if (!entete?.Matricule) {
            await msgBox({
                titre: "Outillage",
                msg: "Sélectionnez d'abord un agent.",
                typMsg: "error",
                typReply: "OkOnly",
            });
            return;
        }
        if (!codOutillageSel) return;

        // Vérifier si déjà présent
        if (detail.some((d) => d.Cod_Outillage === codOutillageSel)) {
            await msgBox({
                titre: "Outillage",
                msg: "Cet outillage est déjà dans la liste.",
                typMsg: "warning",
                typReply: "OkOnly",
            });
            return;
        }

        const rsl = await myAxios("get_outillage_info", {
            cod_outillage: codOutillageSel,
            typ_mouvement: entete.Typ_Mouvement,
            matricule: entete.Matricule,
        });
        if (rsl.data?.result && rsl.data.data.length > 0) {
            const o = rsl.data.data[0];
            const qteDefaut = entete.Typ_Mouvement === "R" ? (o.Qte_Ref || 0) : 1;
            const newLigne: TDetail = {
                Cod_Outillage: o.Cod_Outillage,
                Lib_Outillage: o.Lib_Outillage || "",
                Typ_Outillage: o.Typ_Outillage || "",
                Num_Serie: o.Num_Serie || "",
                Qte_Dispo: o.Qte_Ref || 0,
                Qte: qteDefaut,
                RowId: 0,
            };
            setDetail((prv) => [...prv, newLigne]);
            setCodOutillageSel("");
        } else {
            await msgBox({
                titre: "Outillage",
                msg: "Outillage introuvable pour ce type de mouvement.",
                typMsg: "error",
                typReply: "OkOnly",
            });
        }
    }, [entete, detail, codOutillageSel]);

    const Enregistrer = useCallback(
        async (Statut: "NSS" | "SS" | "SG" | "RJ" | "SP" | "VA" | "" = "") => {
            if (["SG", "RJ", "SP", "VA"].includes(entete?.Statut || "")) {
                await msgBox({
                    titre: "Enregistrer",
                    msg: "Mouvement traité. Modification impossible.",
                    typMsg: "error",
                    typReply: "OkOnly",
                    async handleOk() { return; },
                });
                return;
            }
            if (!entete?.Matricule) {
                await msgBox({
                    titre: "Enregistrer",
                    msg: "Veuillez renseigner le matricule.",
                    typMsg: "error",
                    typReply: "OkOnly",
                    async handleOk() { return; },
                });
                return;
            }
            if (!entete?.Typ_Mouvement) {
                await msgBox({
                    titre: "Enregistrer",
                    msg: "Veuillez sélectionner le type de mouvement.",
                    typMsg: "error",
                    typReply: "OkOnly",
                    async handleOk() { return; },
                });
                return;
            }
            if (!entete?.Dat_Mouvement) {
                await msgBox({
                    titre: "Enregistrer",
                    msg: "Veuillez renseigner la date du mouvement.",
                    typMsg: "error",
                    typReply: "OkOnly",
                    async handleOk() { return; },
                });
                return;
            }
            if (detail.length === 0) {
                await msgBox({
                    titre: "Enregistrer",
                    msg: "Aucune ligne d'outillage saisie.",
                    typMsg: "error",
                    typReply: "OkOnly",
                    async handleOk() { return; },
                });
                return;
            }
            // Regroupement quantités
            const dict: { [key: string]: number } = {};
            for (const d of detail) {
                if (!d.Cod_Outillage) continue;
                const q = parseFloat(String(d.Qte)) || 0;
                if (q <= 0) {
                    await msgBox({
                        titre: "Enregistrer",
                        msg: "Quantité invalide pour l'outillage : " + d.Cod_Outillage,
                        typMsg: "error",
                        typReply: "OkOnly",
                    });
                    return;
                }
                dict[d.Cod_Outillage] = (dict[d.Cod_Outillage] || 0) + q;
            }
            // Contrôle des quantités par rapport au stock hors document
            for (const cod of Object.keys(dict)) {
                const qteTotale = dict[cod];
                const lignes = detail.filter((d) => d.Cod_Outillage === cod);
                const qteDispo = lignes[0]?.Qte_Dispo || 0;
                if (qteTotale > qteDispo) {
                    await msgBox({
                        titre: "Enregistrer",
                        msg: entete.Typ_Mouvement === "R"
                            ? `Quantité retirée supérieure à la quantité détenue pour : ${cod}`
                            : `Quantité affectée supérieure à la quantité disponible pour : ${cod}`,
                        typMsg: "error",
                        typReply: "OkOnly",
                    });
                    return;
                }
            }

            let _entete = { ...entete };
            if (Statut === "SS" || Statut === "VA") _entete = { ..._entete, Statut };
            if (savingRef.current) return; // une sauvegarde est déjà en cours
            savingRef.current = true;
            const rslSave = await myAxios("save_outillage_mouvement", {
                entete: _entete,
                detail,
            }).finally(() => {
                savingRef.current = false;
            });
            if (rslSave.data.result) {
                const numN = rslSave.data.data[0].Num_Mouvement;
                if (numN !== currentNum) {
                    // Met à jour l'URL avec le n° attribué : sinon l'URL reste sur /new
                    // et le bouton "Nouveau" (qui navigue vers /new) ne déclenche rien.
                    navigate(`/myspace/Outillage_Mouvement/Mouvement Outillage/${numN}`, { replace: true });
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
                    async handleCancel() { return; },
                })) === "Cancel"
            )
                return;
        }
        if (currentNum !== "" && currentNum !== "new") {
            await myAxios("release_accessible", {
                nameEcran: "RH_Outillage_Mouvement",
                idEcran: currentNum,
            });
        }
        navigate("/myspace/Outillage_Mouvement/Mouvement Outillage/new");
    }, [entete, detail, currentNum]);

    const Valider = useCallback(async () => {
        if (!currentNum) return;
        if (
            (await msgBox({
                titre: "Validation",
                msg: "Etes-vous sûr de vouloir valider ce mouvement?",
                typMsg: "warning",
                typReply: "OKCancel",
                async handleCancel() { return; },
            })) === "Cancel"
        )
            return;
        await Enregistrer("VA");
    }, [Enregistrer, currentNum]);

    const SoumettreEnSignature = useCallback(async () => {
        if (!currentNum) return;
        if (entete.Statut === "" || entete.Statut === "NSS") {
            if (
                (await msgBox({
                    titre: "Signature",
                    msg: "Êtes-vous sûr de vouloir soumettre ce mouvement en signature?",
                    typMsg: "warning",
                    typReply: "OKCancel",
                    async handleCancel() { return; },
                })) === "Ok"
            )
                await Enregistrer("SS");
        } else {
            setShowSignature(true);
        }
    }, [Enregistrer, currentNum, entete.Statut]);

    const Supprimer = useCallback(async () => {
        if (!entete?.Num_Mouvement) {
            // Document non enregistré : "Supprimer" abandonne la saisie en cours
            if (
                (!isEqual(entete, enteteRef.current) || !isEqual(detail, detailRef.current)) &&
                (await msgBox({
                    titre: "Supprimer",
                    msg: "Document non enregistré. Voulez-vous abandonner la saisie en cours?",
                    typMsg: "warning",
                    typReply: "OKCancel",
                    async handleCancel() { return; },
                })) === "Cancel"
            )
                return;
            await loadData();
            return;
        }
        if (
            (await msgBox({
                titre: "Supprimer",
                msg: "Etes-vous sûr de vouloir supprimer ce mouvement?",
                typMsg: "warning",
                typReply: "OKCancel",
                async handleCancel() { return; },
            })) === "Cancel"
        )
            return;
        if (["SG", "RJ", "SP", "VA"].includes(entete?.Statut || "")) {
            await msgBox({
                titre: "Supprimer",
                msg: "Mouvement traité. Suppression impossible",
                typMsg: "warning",
                typReply: "OkOnly",
            });
            return;
        }
        const rslSave = await myAxios("delete_outillage_mouvement", {
            Num_Mouvement: entete.Num_Mouvement,
        });
        if (rslSave.data.result) {
            setCurrentNum("");
            alert({
                titre: "Suppression",
                msg: "Mouvement supprimé.",
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
                action: () => Enregistrer(""),
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
                name: "Valider",
                disabled: !_canSave || !currentNum,
                libelle: "Valider",
                action: Valider,
                icon: <DrawOutlined />,
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
                        setGEDprops({ name_ecran: "RH_Outillage_Mouvement", valeur_index: currentNum });
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
                label="Mouvement Outillage"
                showBorders={!isSmall}
                showTitre={true}
                sx={{
                    width: "100%",
                    marginInline: "auto",
                    "& .grpDiv": {
                        padding: "2em 5px 5px 5px",
                        width: "100%",
                        minHeight: "10em",
                        marginInline: "auto",
                    },
                }}
            >
                <>
                    <Grid container spacing={2}>
                        <Grid xs={12} sm={12} lg={4} xl={3}>
                            <TextZoom
                                readonly={true}
                                numZoom="MS213"
                                nomControle="Num_Mouvement"
                                label="N° Mouvement"
                                valeur={entete?.Num_Mouvement}
                                onchange={stateChange}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={12} lg={4} xl={3}>
                            <TextZoom
                                readonly={!!currentNum && currentNum !== "new"}
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
                        <Grid xs={12} sm={6} lg={4} xl={3}>
                            <TextZoom
                                readonly={true}
                                numZoom=""
                                nomControle="Cod_Poste"
                                label="Poste"
                                valeur={agentInfo.Cod_Poste || ""}
                                findlibelle={{
                                    champs: "Lib_Poste",
                                    code: "Cod_Poste",
                                    tblName: "Org_Poste",
                                }}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={6} lg={4} xl={3}>
                            <TextZoom
                                readonly={true}
                                numZoom=""
                                nomControle="Cod_Entite"
                                label="Entité"
                                valeur={agentInfo.Cod_Entite || ""}
                                findlibelle={{
                                    champs: "Lib_Entite",
                                    code: "Cod_Entite",
                                    tblName: "Org_Entite",
                                }}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={6} lg={4} xl={3}>
                            <CalendarZoom
                                nomControle="Dat_Mouvement"
                                label="Date Mouvement"
                                valeur={entete?.Dat_Mouvement || new Date()}
                                onchange={stateChange}
                                sx={{
                                    width: "100%",
                                    "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                                }}
                                onClear={() => stateChange("Dat_Mouvement", "")}
                            />
                        </Grid>
                        <Grid xs={12} sm={6} lg={4} xl={3}>
                            <ComboBox
                                readOnly={!!currentNum && currentNum !== "new"}
                                rubrique="Typ_Mouvement_Outillage"
                                dataSource={typMouvementOptions}
                                nomControle="Typ_Mouvement"
                                label="Type Mouvement"
                                valeur={entete?.Typ_Mouvement || ""}
                                onchange={stateChange}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={12} lg={12} xl={6}>
                            <TextBox
                                nomControle="Commentaire"
                                label="Commentaire"
                                multiline={true}
                                rows={isXs || isSm ? 3 : 2}
                                valeur={entete?.Commentaire || ""}
                                onchange={stateChange}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                    </Grid>

                    <Box
                        sx={{
                            display: "flex",
                            flexWrap: { xs: "wrap", sm: "nowrap" },
                            gap: 2,
                            alignItems: "flex-end",
                            mt: 2,
                            mb: 1,
                        }}
                    >
                        <TextZoom
                            numZoom={entete?.Typ_Mouvement === "R" ? "MS212" : "MS211"}
                            nomControle="Cod_Outillage_Sel"
                            label="Outillage"
                            valeur={codOutillageSel}
                            findlibelle={{
                                champs: "Lib_Outillage",
                                code: "Cod_Outillage",
                                tblName: "RH_Outillage",
                            }}
                            onchange={(champ: string, val: any) => setCodOutillageSel(val)}
                            style={{ flex: 1, minWidth: 200 }}
                        />
                        <Bouton
                            disabled={!canSave || !codOutillageSel}
                            variant="contained"
                            label="Ajouter"
                            startIcon={<Add />}
                            onClick={ajouterLigne}
                        />
                        <Bouton
                            disabled={!canSave}
                            variant="outlined"
                            color="error"
                            label="Supprimer ligne"
                            startIcon={<DeleteOutline />}
                            onClick={() => {
                                setAction((prv: string) => (prv === "" ? "supprimer" : ""));
                            }}
                        />
                    </Box>
                </>
            </GroupBox>
            <Box
                sx={{
                    margin: "auto",
                    padding: "5px",
                    width: "100%",
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

export default Outillage_Mouvement;

type TEntete = {
    Num_Mouvement: string;
    Matricule?: string;
    Dat_Mouvement?: Date;
    Typ_Mouvement?: string;
    Commentaire?: string;
    Statut?: string;
};

const iniEntete: TEntete = {
    Num_Mouvement: "",
    Matricule: Agent?.Matricule,
    Dat_Mouvement: new Date(),
    Typ_Mouvement: "A", // Affectation par défaut
    Commentaire: "",
    Statut: "",
};

type TDetail = {
    Cod_Outillage: string;
    Lib_Outillage?: string;
    Typ_Outillage?: string;
    Num_Serie?: string;
    Qte_Dispo?: number;
    Qte?: number;
    RowId?: number;
};
