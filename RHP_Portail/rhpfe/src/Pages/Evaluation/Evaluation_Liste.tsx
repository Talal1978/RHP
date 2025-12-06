
import { useContext, useEffect, useState } from "react";
import { RectangleEllipsis } from "lucide-react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import { Box, FormControl, FormControlLabel, FormLabel, Radio, RadioGroup } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
import { CloudSyncOutlined, PrintOutlined } from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import { useNavigate } from "react-router-dom";
import { cntX } from "../../Menu/MenuMain";
import ComboBox from "../../components/ComboBox/ComboBox";

const Evaluation_Liste = () => {
    const navigate = useNavigate();
    const alert = useAlert();
    const [criteres, setCriteres] = useState<TCriteres>(initialiserCriteres);
    const [ds, setDs] = useState<ObjetGenerique[]>([]);
    const [dsFields, setDsFields] = useState<TColonneCollection>({});
    const { isSmall, isXs, isSm, isLg, isXl } = useContext(cntX);
    const date = new Date();

    function stateChange(champs: string, valeur: any) {
        setCriteres((crt: TCriteres) => {
            return { ...crt, [champs]: valeur };
        });
    }

    const myAxios = useAxiosPost();

    useEffect(() => {
        // Optional: Clear grid when criteria changes, similar to RH_Bulletin_Liste
        setDs([]);
    }, [JSON.stringify(criteres)]);

    const handleSearch = () => {
        if (!criteres.Evalue && !criteres.Evaluateur) {
            alert({
                msg: "Veuillez renseigner l'évalué ou l'évaluateur.",
                typMsg: "warning",
            });
            return;
        }
        myAxios("evaluation_liste", criteres)
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
                                backgroundColor: "background.paper",
                            },
                        },
                        ...dt.data.fields,
                    };

                    // Helper to hide columns case-insensitively
                    const hideColumns = (targets: string[]) => {
                        Object.keys(fields).forEach(key => {
                            if (targets.some(t => key.toLowerCase() === t.toLowerCase())) {
                                fields[key].visible = false;
                            }
                        });
                    };

                    // Optimisation d'affichage
                    if (criteres.Cod_Evaluation) {
                        hideColumns(["Evaluation", "Description"]);
                    }
                    if (criteres.Evalue) {
                        // "Nom" is typically the user's name in this context
                        hideColumns(["Matricule", "Nom"]);
                    }
                    if (criteres.Evaluateur) {
                        hideColumns(["Evaluateur", "Nom évaluateur"]);
                    }
                    if (criteres.Cod_Entite) {
                        hideColumns(["Entité"]);
                    }
                    if (criteres.Cod_Grade) {
                        hideColumns(["Grade"]);
                    }
                    setDs(data);
                    setDsFields(fields);
                } else {
                    setDs([]);
                    setDsFields({});
                }
            })
            .catch((err) => {
                setDs([]);
                setDsFields({});
            });
    };

    return (
        <>
            <GroupBox
                label="Critères"
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
                    {/* Evaluateur */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS018"
                            nomControle="Evaluateur"
                            label="Evaluateur"
                            valeur={criteres?.Evaluateur}
                            findlibelle={{
                                champs: "Nom",
                                code: "Matricule",
                                tblName: "Sys_RH_Preparation_Paie_Agent",
                            }}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>
                    {/* Evalue */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS018"
                            nomControle="Evalue"
                            label="Evalué"
                            valeur={criteres?.Evalue}
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

                    {/* Grade */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS015"
                            nomControle="Cod_Grade"
                            label="Grade"
                            valeur={criteres?.Cod_Grade}
                            findlibelle={{
                                champs: "Lib_Grade",
                                code: "Cod_Grade",
                                tblName: "Org_Grade",
                            }}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>

                    {/* Evaluation */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <TextZoom
                            numZoom="MS158"
                            nomControle="Cod_Evaluation"
                            label="Evaluation"
                            valeur={criteres?.Cod_Evaluation}
                            findlibelle={{
                                champs: "Description",
                                code: "Cod_Evaluation",
                                tblName: "Evaluation",
                            }}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>

                    {/* Statut */}
                    <Grid xs={12} sm={6} lg={4} xl={3}>
                        <ComboBox
                            nomControle="Statut_Evaluation"
                            label="Statut"
                            rubrique="Statut_Evaluation"
                            valeur={criteres.Statut_Evaluation}
                            onchange={stateChange}
                            style={{ width: "100%" }}
                        />
                    </Grid>

                    {/* Dates */}
                    <Grid xs={12} sm={12} lg={6} xl={4}>
                        <Box
                            sx={{
                                display: "flex",
                                paddingRight: "5px",
                                gap: { xs: "5px", sm: "1em", md: "1.5em", lg: "2em" },
                            }}
                        >
                            <CalendarZoom
                                nomControle="Dat_Du"
                                label="Du"
                                valeur={
                                    criteres?.Dat_Du ||
                                    new Date(date.getFullYear(), date.getMonth() - 1, date.getDate())
                                }
                                onchange={(name: string, val: any) => {
                                    // Logic to ensure Dat_Au >= Dat_Du
                                    let newAu = criteres.Dat_Au;
                                    if (newAu && val && new Date(newAu) < new Date(val)) {
                                        newAu = new Date(new Date(val).setDate(new Date(val).getDate() + 7));
                                        stateChange("Dat_Au", newAu);
                                    }
                                    stateChange(name, val);
                                }}
                                sx={{
                                    width: "100%",
                                    "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                                }}
                                onClear={() => stateChange("Dat_Du", "")}
                            />
                            <CalendarZoom
                                nomControle="Dat_Au"
                                label="Au"
                                valeur={criteres?.Dat_Au || date}
                                onchange={stateChange}
                                sx={{
                                    width: "100%",
                                    "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                                }}
                                onClear={() => stateChange("Dat_Au", "")}
                            />
                        </Box>
                    </Grid>

                    {/* Statut EffectuÃ© (Radio) */}
                    <Grid xs={12} sm={12} lg={6} xl={4}>
                        <FormControl>
                            <FormLabel id="statut-effectue-label">Etat</FormLabel>
                            <RadioGroup
                                row
                                aria-labelledby="statut-effectue-label"
                                name="Statut_Effectue"
                                value={criteres.Statut_Effectue || "Tous"}
                                onChange={(e) => stateChange("Statut_Effectue", e.target.value)}
                            >
                                <FormControlLabel value="Tous" control={<Radio />} label="Tous" />
                                <FormControlLabel value="NonEffectuee" control={<Radio />} label="Non Effectuée" />
                                <FormControlLabel value="Effectuee" control={<Radio />} label="Effectuée" />
                            </RadioGroup>
                        </FormControl>
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
                    <Bouton
                        iconOnly={isXs || isSm}
                        variant={isXs || isSm ? "contained" : "outlined"}
                        sx={{ flexGrow: 1 }}
                        label="Imprimer"
                        startIcon={<PrintOutlined />}
                        onClick={() => {
                            // Logic for printing if needed
                        }}
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
                            navigate("/evaluation", {
                                state: {
                                    Cod_Evaluation: row["Evaluation"],
                                    Description: row["Description"],
                                    Evaluateur: row["Evaluateur"],
                                    Nom_Evaluateur: row["Nom_evaluateur"],
                                    Evalue: row["Matricule"],
                                    Nom_Evalue: row["Nom"]
                                }
                            });
                        }
                    }}
                    sx={{
                        // Sticky column styles
                        "& .cl0": {
                            cursor: "pointer",
                            position: "sticky",
                            left: 0,
                            zIndex: 1,
                            backgroundColor: "background.paper",
                            boxShadow: "2px 0 5px -2px rgba(0,0,0,0.1)",
                        },
                        // Sticky header styles (targeting first th effectively)
                        "& thead th:first-of-type, & .MuiDataGrid-columnHeader--moving": {
                            position: "sticky",
                            left: 0,
                            zIndex: 3, // Higher index for header
                            backgroundColor: "background.paper",
                            boxShadow: "2px 0 5px -2px rgba(0,0,0,0.1)",
                        }
                    }}
                />
            </Box>
        </>
    );
};

export default Evaluation_Liste;

type TCriteres = {
    Evaluateur?: string;
    Evalue?: string;
    Cod_Entite?: string;
    Cod_Grade?: string;
    Cod_Evaluation?: string;
    Statut_Evaluation?: string;
    Dat_Du?: Date | null;
    Dat_Au?: Date | null;
    Statut_Effectue?: string;
};

const initialiserCriteres: TCriteres = {
    Evaluateur: Agent.Typ_Role === "Agent" && Agent.TeamLeader ? Agent.Matricule : "",
    Evalue: Agent.Typ_Role === "Agent" && !Agent.TeamLeader ? Agent.Matricule : "",
    Cod_Entite: "",
    Cod_Grade: "",
    Cod_Evaluation: "",
    Statut_Evaluation: "",
    Dat_Du: null,
    Dat_Au: null,
    Statut_Effectue: "Tous",
};
