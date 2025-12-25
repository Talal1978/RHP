
import {
    useCallback,
    useContext,
    useEffect,
    useMemo,
    useState,
} from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import {
    AttachFileOutlined,
    PrintOutlined,
} from "@mui/icons-material";
import { Agent } from "../../modules/module_general";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate, useParams } from "react-router-dom";
import TextBox from "../../components/TextBox/TextBox";
import { cntX } from "../../Menu/MenuMain";
import { TReport } from "../../Report/ReportViewer";

const RH_Discipline = () => {
    const navigate = useNavigate();
    const {
        settbnMenu,
        isSmall,
        setShowGED,
        setGEDprops,
    } = useContext(cntX);
    const { num } = useParams();
    const [currentNum, setCurrentNum] = useState(num);

    useEffect(() => {
        setCurrentNum(num);
    }, [num]);

    const [entete, setEntete] = useState<TEntete>(iniEntete);
    const myAxios = useAxiosPost();

    const Request = useCallback(async () => {
        if (currentNum !== "" && currentNum !== "new") {
            await myAxios("get_discipline", { Cod_Sanction: currentNum })
                .then((dt) => {
                    if (dt.data && dt.data?.result) {
                        setEntete(dt.data.data[0]);
                    } else {
                        setEntete(iniEntete);
                    }
                })
                .catch((err) => {
                    setEntete(iniEntete);
                });
        } else {
            setEntete(iniEntete);
        }
    }, [currentNum]);

    useEffect(() => {
        Request();
    }, [Request]);

    useEffect(() => {
        settbnMenu([
            {
                name: "Imprimer",
                disabled: false,
                libelle: "Imprimer",
                action: () =>
                    navigate("/viewer", {
                        state: {
                            reportName: "Discipline",
                            params: { Cod_Sanction: currentNum },
                        } as TReport,
                    }),
                icon: <PrintOutlined />,
            },
            {
                name: "PJ",
                disabled: false,
                libelle: "Pièces jointes",
                action: () => {
                    if (currentNum) {
                        setGEDprops({
                            name_ecran: "RH_Discipline",
                            valeur_index: currentNum,
                        });
                        setShowGED(true);
                    }
                },
                icon: <AttachFileOutlined />,
            },
        ]);
    }, [currentNum]);

    return (
        <>
            <GroupBox
                label="Fiche Discipline"
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
                <Grid container spacing={2}>
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <TextZoom
                            readonly={true}
                            numZoom="MS029"
                            nomControle="Cod_Sanction"
                            label="Code Sanction"
                            valeur={entete?.Cod_Sanction}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <TextZoom
                            readonly={true}
                            numZoom="MS018"
                            nomControle="Matricule"
                            label="Matricule"
                            valeur={entete?.Matricule}
                            findlibelle={{
                                champs: "Nom_Agent+ ' ' +Prenom_Agent",
                                code: "Matricule",
                                tblName: "RH_Agent",
                            }}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <TextBox
                            readonly={true}
                            nomControle="Lib_Sanction"
                            label="Libellé"
                            type="text"
                            valeur={entete?.Lib_Sanction || ""}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <ComboBox
                            readOnly={true}
                            label="Type Sanction"
                            nomControle="Typ_Sanction"
                            valeur={entete?.Typ_Sanction || ""}
                            rubrique="Sanctions"
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <CalendarZoom
                            readOnly={true}
                            nomControle="Dat_Faute"
                            label="Date Faute"
                            valeur={entete?.Dat_Faute}
                            sx={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <CalendarZoom
                            readOnly={true}
                            nomControle="Dat_Decision"
                            label="Date Décision"
                            valeur={entete?.Dat_Decision}
                            sx={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={12} xl={12}>
                        <TextBox
                            readonly={true}
                            nomControle="Motif"
                            label="Motif"
                            multiline={true}
                            rows={3}
                            type="text"
                            valeur={entete?.Motif || ""}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    <Grid xs={12} sm={12} lg={12} xl={12}>
                        <TextBox
                            readonly={true}
                            nomControle="Observation"
                            label="Observation"
                            multiline={true}
                            rows={2}
                            type="text"
                            valeur={entete?.Observation || ""}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    {entete?.Typ_Sanction === "Trsf" && (
                        <>
                            <Grid xs={12} sm={12} lg={6} xl={6}>
                                <TextZoom
                                    readonly={true}
                                    numZoom="MS016"
                                    nomControle="Cod_Poste_Transfert"
                                    label="Poste Transfert"
                                    valeur={entete?.Cod_Poste_Transfert}
                                    findlibelle={{
                                        champs: "Lib_Poste",
                                        code: "Cod_Poste",
                                        tblName: "Org_Poste",
                                    }}
                                    style={{ width: "100%" }}
                                />
                            </Grid>
                            <Grid xs={12} sm={12} lg={6} xl={6}>
                                <ComboBox
                                    readOnly={true}
                                    rubrique="Affectation_1"
                                    nomControle="Affectation_Transfert"
                                    label="Affectation Transfert"
                                    valeur={entete?.Affectation_Transfert || ""}
                                    style={{ width: "100%" }}
                                />
                            </Grid>
                        </>
                    )}

                    {entete?.Typ_Sanction === "MAP" && (
                        <Grid xs={6} sm={6} lg={4} xl={4}>
                            <TextBox
                                readonly={true}
                                nomControle="Duree_Sanction"
                                label="Durée (Mise à pied)"
                                type="number"
                                valeur={entete?.Duree_Sanction || 0}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                    )}
                    <Grid xs={12} sm={12} lg={6} xl={6}>
                        <TextBox
                            readonly={true}
                            nomControle="Ref_PV"
                            label="Réf PV"
                            type="text"
                            valeur={entete?.Ref_PV || ""}
                            style={{ width: "100%" }}
                        />
                    </Grid>

                </Grid>
            </GroupBox>
        </>
    );
};

export default RH_Discipline;

type TEntete = {
    Cod_Sanction: string;
    Matricule: string;
    Lib_Sanction?: string;
    Typ_Sanction?: string;
    Dat_Faute?: Date;
    Dat_Decision?: Date;
    Motif?: string;
    Observation?: string;
    Ref_PV?: string;
    Duree_Sanction?: number;
    Cod_Poste_Transfert?: string;
    Affectation_Transfert?: string;
    Statut?: string;
};

const iniEntete: TEntete = {
    Cod_Sanction: "",
    Matricule: Agent.Matricule,
    Lib_Sanction: "",
    Typ_Sanction: "",
    Dat_Faute: new Date(),
    Dat_Decision: new Date(),
    Motif: "",
    Observation: "",
    Ref_PV: "",
    Duree_Sanction: 0,
    Cod_Poste_Transfert: "",
    Affectation_Transfert: "",
    Statut: ""
};
