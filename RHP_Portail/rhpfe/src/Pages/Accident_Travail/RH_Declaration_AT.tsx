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
import { Box } from "@mui/material";
import Grille, {
    TColonneCollection,
} from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
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

const RH_Declaration_AT = () => {
    const navigate = useNavigate();
    const {
        settbnMenu,
        isSmall,
        isXs,
        isSm,
        isLg,
        isXl,
        setShowGED,
        setGEDprops,
    } = useContext(cntX);

    const { num } = useParams();
    const [currentNum, setCurrentNum] = useState(num);

    useEffect(() => {
        setCurrentNum(num);
    }, [num]);

    const [entete, setEntete] = useState<TEntete>(iniEntete);
    const [detail, setDetail] = useState<TDetail[]>([]);

    const Colonnes = useMemo<TColonneCollection>(
        () => ({
            Typ_Certificat: {
                columnName: "Typ_Certificat",
                dataType: "nvarchar",
                readOnly: true,
                visible: true,
                headerText: "Type Certificat",
                typeColonne: "Text",
                sx: { minWidth: "10em" },
            },
            Dat_Certificat: {
                columnName: "Dat_Certificat",
                dataType: "smalldatetime",
                readOnly: true,
                visible: true,
                headerText: "Date Certificat",
                typeColonne: "Calendar",
                sx: { maxWidth: "8em" },
            },
            Dat_Debut_Arret: {
                columnName: "Dat_Debut_Arret",
                dataType: "smalldatetime",
                readOnly: true,
                visible: true,
                headerText: "Début Arrêt",
                typeColonne: "Calendar",
                sx: { maxWidth: "8em" },
            },
            Dat_Fin_Arret: {
                columnName: "Dat_Fin_Arret",
                dataType: "smalldatetime",
                readOnly: true,
                visible: true,
                headerText: "Fin Arrêt",
                typeColonne: "Calendar",
                sx: { maxWidth: "8em" },
            },
            Nbr_Jours: {
                columnName: "Nbr_Jours",
                dataType: "int",
                readOnly: true,
                visible: true,
                headerText: "Nbr Jours",
                typeColonne: "Text",
                sx: { maxWidth: "5em" },
            },
            Comment: {
                columnName: "Comment",
                dataType: "nvarchar",
                readOnly: true,
                visible: true,
                headerText: "Commentaire",
                typeColonne: "Text",
                sx: { minWidth: "20em" },
            },
        }),
        []
    );

    const myAxios = useAxiosPost();

    const loadData = useCallback(async () => {
        if (currentNum && currentNum !== "new") {
            await myAxios("get_declaration_at", { num_declaration: currentNum })
                .then((dt) => {
                    if (dt.data && dt.data?.result) {
                        setEntete(dt.data.entete);
                        setDetail(dt.data.detail);
                    } else {
                        setEntete(iniEntete);
                        setDetail([]);
                    }
                })
                .catch((err) => {
                    setEntete(iniEntete);
                    setDetail([]);
                });
        }
    }, [currentNum]);

    useEffect(() => {
        loadData();
    }, [loadData]);

    useEffect(() => {
        settbnMenu([
            {
                name: "Imprimer",
                disabled: false,
                libelle: "Imprimer",
                action: () =>
                    navigate("/viewer", {
                        state: {
                            reportName: "DeclarationAT",
                            params: { NumDeclaration: currentNum },
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
                        setGEDprops({ name_ecran: "RH_Declaration_AT", valeur_index: currentNum });
                        setShowGED(true);
                    }
                },
                icon: <AttachFileOutlined />,
            },
        ]);
    }, [currentNum, navigate, settbnMenu, setGEDprops, setShowGED]);

    return (
        <>
            <GroupBox
                label="Déclaration Accident de Travail"
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
                                numZoom="AT001"
                                nomControle="Num_Declaration"
                                label="N° Déclaration"
                                valeur={entete?.Num_Declaration}
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
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={6} lg={3} xl={3}>
                            <CalendarZoom
                                readOnly={true}
                                nomControle="Dat_Accident"
                                label="Date Accident"
                                valeur={entete?.Dat_Accident}
                                sx={{
                                    width: "100%",
                                    "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                                }}
                            />
                        </Grid>
                        <Grid xs={12} sm={6} lg={3} xl={3}>
                            <TextBox
                                readonly={true}
                                nomControle="Heure_Accident"
                                label="Heure"
                                valeur={entete?.Heure_Accident || ""}
                                style={{ width: "100%" }}
                            />
                        </Grid>

                        <Grid xs={12} sm={12} lg={6} xl={6}>
                            <TextBox
                                readonly={true}
                                nomControle="Lieu_Accident"
                                label="Lieu"
                                valeur={entete?.Lieu_Accident || ""}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={12} lg={6} xl={6}>
                            <ComboBox
                                readOnly={true}
                                rubrique="Statut_AT"
                                nomControle="Statut"
                                label="Statut"
                                valeur={entete?.Statut || ""}
                                style={{ width: "100%" }}
                            />
                        </Grid>

                        <Grid xs={12}>
                            <TextBox
                                readonly={true}
                                nomControle="Circonstances"
                                label="Circonstances"
                                multiline={true}
                                rows={2}
                                valeur={entete?.Circonstances || ""}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                    </Grid>
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
                    readonly={true}
                    dataSource={detail}
                    Colonnes={Colonnes}
                    className="laGrille"
                />
            </Box>
        </>
    );
};

export default RH_Declaration_AT;

type TEntete = {
    Num_Declaration: string;
    Matricule?: string;
    Dat_Accident?: Date;
    Heure_Accident?: string;
    Lieu_Accident?: string;
    Circonstances?: string;
    Statut?: string;
};

export const iniEntete: TEntete = {
    Num_Declaration: "",
    Matricule: Agent?.Matricule,
    Dat_Accident: undefined,
    Heure_Accident: "",
    Lieu_Accident: "",
    Circonstances: "",
    Statut: "",
};

type TDetail = {
    Typ_Certificat?: string;
    Dat_Certificat?: Date;
    Dat_Debut_Arret?: Date;
    Dat_Fin_Arret?: Date;
    Nbr_Jours?: number;
    Comment?: string;
    RowId?: number;
};
