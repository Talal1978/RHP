
import { useContext, useEffect, useState } from "react";
import { RectangleEllipsis } from "lucide-react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import { Box } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
import { CloudSyncOutlined } from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import { useNavigate } from "react-router-dom";
import { cntX } from "../../Menu/MenuMain";

const Formation_Evaluation_Liste = () => {
    const navigate = useNavigate();
    const alert = useAlert();
    const [criteres, setCriteres] = useState<TCriteres>(initialiserCriteres);
    const [ds, setDs] = useState<ObjetGenerique[]>([]);
    const [dsFields, setDsFields] = useState<TColonneCollection>({});
    const { isSmall, isXs, isSm, isLg, isXl } = useContext(cntX);

    function stateChange(champs: string, valeur: any) {
        setCriteres((crt: TCriteres) => {
            return { ...crt, [champs]: valeur };
        });
    }

    const myAxios = useAxiosPost();

    useEffect(() => {
        setDs([]);
    }, [JSON.stringify(criteres)]);

    const handleSearch = () => {
        if (!criteres.Cod_Formation && !criteres.Matricule && Agent.Typ_Role !== "Ops") {
            alert({
                msg: "Veuillez renseigner la formation ou le participant.",
                typMsg: "warning",
            });
            return;
        }
        myAxios("formation_evaluation_liste", criteres)
            .then((dt) => {
                if (dt.data && dt.data?.result) {
                    const data = dt.data.data.map((d: any) => ({
                        ...d,
                        Action: <RectangleEllipsis color={colorBase.colorBase01} size={18} />,
                    }));

                    const fields: any = {
                        Action: {
                            columnName: "Action",
                            dataType: "string",
                            readOnly: true,
                            visible: true,
                            headerText: " ",
                            sx: {
                                width: "50px",
                                textAlign: "center",
                                position: "sticky",
                                left: 0,
                                zIndex: 1,
                                backgroundColor: "var(--bg-input)",
                            },
                        },
                        ...dt.data.fields,
                    };

                    setDs(data);
                    setDsFields(fields);
                } else {
                    setDs([]);
                    setDsFields({});
                    alert({
                        msg: dt.data?.message || "Aucun résultat trouvé.",
                        typMsg: "warning",
                    });
                }
            })
            .catch((err) => {
                setDs([]);
                setDsFields({});
                alert({
                    msg: err.message,
                    typMsg: "error",
                });
            });
    };

    return (
        <>
            <GroupBox
                label="Critères d'évaluation formation"
                showBorders={!isSmall}
                showTitre={true}
                sx={{
                    "& .grpDiv": {
                        padding: "2em 5px",
                        width: "90vw",
                        minHeight: "10em",
                    },
                }}
            >
                <Grid container spacing={2}>
                    {/* Formation */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS152"
                            nomControle="Cod_Formation"
                            label="Formation"
                            valeur={criteres?.Cod_Formation}
                            findlibelle={{
                                champs: "Lib_Formation",
                                code: "Cod_Formation",
                                tblName: "Formation",
                            }}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    {/* Participant / Matricule */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS018"
                            nomControle="Matricule"
                            label="Participant"
                            valeur={criteres?.Matricule}

                            findlibelle={{
                                champs: "Nom",
                                code: "Matricule",
                                tblName: "Sys_RH_Preparation_Paie_Agent",
                            }}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    {/* Entite */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS010"
                            nomControle="Cod_Entite"
                            label="Entité"
                            valeur={criteres?.Cod_Entite}
                            findlibelle={{
                                champs: "Lib_Entite",
                                code: "Cod_Entite",
                                tblName: "Org_Entite",
                            }}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                </Grid>

                <div
                    style={{
                        maxWidth: isXl || isLg ? "24vw" : "80%",
                        width: isXl || isLg ? "24vw" : "100%",
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        gap: "1em",
                        margin: "3em auto 0.5em auto",
                    }}
                >
                    <Bouton
                        iconOnly={isXs || isSm}
                        variant={isXs || isSm ? "contained" : "outlined"}
                        sx={{ flexGrow: 1 }}
                        label="Interroger"
                        startIcon={<CloudSyncOutlined />}
                        onClick={handleSearch}
                    />
                </div>
            </GroupBox>

            <Box
                sx={{
                    margin: "auto",
                    padding: "2em 5px",
                    width: {
                        xs: "95vw",
                        sm: "90vw",
                        md: "90vw",
                        lg: "90vw"
                    },
                    overflow: "scroll",
                }}
            >
                <Grille
                    readonly={true}
                    dataSource={ds}
                    Colonnes={dsFields}
                    className="laGrille"
                    onclick={({ colIndex, value, rowIndex }) => {
                        if (colIndex !== undefined && rowIndex !== undefined && ds[rowIndex]) {
                            const row = ds[rowIndex];
                            // Navigate to Detail Page
                            // The backend returns: Cod_Formation, Lib_Formation, Participant, Nom_Participant, Cod_Survey, Cod_Reply, Statut_Reponse
                            navigate("/myspace/Evaluation/Formation_Evaluation", {
                                state: {
                                    cod_evaluation: row["Cod_Formation"],
                                    lib_evaluation: row["Lib_Formation"],
                                    evaluateur: row["Participant"],
                                    nom_evaluateur: row["Nom_Participant"],
                                    evalue: row["Cod_Formation"],
                                    nom_evalue: row["Lib_Formation"],
                                    cod_survey: row["Cod_Survey"],
                                    cod_reply: row["Cod_Reply"] || -1,
                                    typ_survey: "F",
                                    statut: row["Statut_Reponse"] || ""
                                }
                            });
                        }
                    }}
                    sx={{
                        "& .cl0": {
                            cursor: "pointer !important",
                            position: "sticky",
                            left: 0,
                            zIndex: 1,
                            backgroundColor: "var(--bg-input)",
                            boxShadow: "2px 0 5px -2px rgba(0,0,0,0.1)",
                        },
                        "& thead th:first-of-type, & .MuiDataGrid-columnHeader--moving": {
                            position: "sticky",
                            left: 0,
                            zIndex: 3,
                            backgroundColor: "var(--bg-input)",
                            boxShadow: "2px 0 5px -2px rgba(0,0,0,0.1)",
                        }
                    }}
                />
            </Box>
        </>
    );
};

export default Formation_Evaluation_Liste;

type TCriteres = {
    Cod_Formation?: string;
    Matricule?: string;
    Cod_Entite?: string;
};

const initialiserCriteres: TCriteres = {
    Cod_Formation: "",
    Matricule: !Agent.TeamLeader ? Agent.Matricule : "", // Default to self if not team leader? Or allow blank?
    Cod_Entite: "",
};
