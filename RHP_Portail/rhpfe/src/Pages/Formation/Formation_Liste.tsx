import { useContext, useEffect, useState } from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grid from "@mui/material/Unstable_Grid2";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import { Box } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
import { CloudSyncOutlined, NoteAddOutlined } from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate } from "react-router-dom";
import { cntX } from "../../Menu/MenuMain";

const Formation_Liste = () => {
    const navigate = useNavigate();
    const [criteres, setCriteres] = useState<TCriteres>(initialiserCriteres);
    const [ds, setDs] = useState<ObjetGenerique[]>([]);
    const [dsFields, setDsFields] = useState<TColonneCollection>({});
    const { isSmall, isXs, isSm, isMd, isLg, isXl } = useContext(cntX);

    function stateChange(champs: string, valeur: any) {
        setCriteres((crt: TCriteres) => {
            return { ...crt, [champs]: valeur };
        });
    }

    const date = new Date();
    const myAxios = useAxiosPost();

    useEffect(() => {
        setDs([]);
        // Define columns manually if backend doesn't provide them yet or to ensure order
        setDsFields({
            Cod_Formation: { columnName: "Cod_Formation", headerText: "Code", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 100 } },
            Lib_Formation: { columnName: "Lib_Formation", headerText: "Intitulé", dataType: "nvarchar", visible: true, readOnly: true },
            Dat_Du: { columnName: "Dat_Du", headerText: "Du", dataType: "smalldatetime", visible: true, readOnly: true, sx: { width: 100 } },
            Dat_Au: { columnName: "Dat_Au", headerText: "Au", dataType: "smalldatetime", visible: true, readOnly: true, sx: { width: 100 } },
            Statut_Formation: { columnName: "Statut_Formation", headerText: "Statut", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 100 } },
            Budget: { columnName: "Budget", headerText: "Budget", dataType: "float", visible: true, readOnly: true, sx: { width: 100 } }
        });
    }, []);

    return (
        <>
            <GroupBox
                label="Critères Formation"
                showBorders={!isSmall}
                showTitre={true}
                sx={{
                    "& > .grpDiv": {
                        padding: "2em 5px",
                        width: "100%",
                        minHeight: "10em",
                    },
                }}
            >
                <>
                    <Grid container spacing={5}>
                        <Grid xs={12} sm={12} lg={4} xl={3}>
                            <TextZoom
                                numZoom="MS155"
                                nomControle="Matricule"
                                label="Formateur (Interne)"
                                valeur={criteres?.Matricule}
                                findlibelle={{
                                    champs: "Nom_Agent+ ' ' +Prenom_Agent",
                                    code: "Matricule",
                                    tblName: "RH_Agent",
                                }}
                                onchange={stateChange}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={8} sm={12} lg={3} xl={2}>
                            <ComboBox
                                rubrique="Statut_Formation"
                                nomControle="Statut_Formation"
                                label="Statut"
                                valeur={criteres?.Statut_Formation || ""}
                                onchange={stateChange}
                                style={{ width: "100%" }}
                            />
                        </Grid>
                        <Grid xs={12} sm={12} lg={6} xl={4}>
                            <Box
                                sx={{
                                    display: "flex",
                                    flexWrap: { xs: "wrap", sm: "nowrap" },
                                    paddingRight: "5px",
                                    gap: { xs: "5px", sm: "1em", md: "1.5em", lg: "2em" },
                                }}
                            >
                                <CalendarZoom
                                    nomControle="Date_Du"
                                    label="Du"
                                    valeur={
                                        criteres?.Date_Du ||
                                        new Date(
                                            date.getFullYear(),
                                            date.getMonth() - 6,
                                            date.getDate()
                                        )
                                    }
                                    onchange={stateChange}
                                    sx={{
                                        width: "100%",
                                        "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                                    }}
                                    onClear={() => stateChange("Date_Du", "")}
                                />
                                <CalendarZoom
                                    nomControle="Date_Au"
                                    label="Au"
                                    valeur={criteres?.Date_Au || date}
                                    onchange={stateChange}
                                    sx={{
                                        width: "100%",
                                        "& input": { fontSize: { xs: "0.85em", sm: "1em" } },
                                    }}
                                    onClear={() => stateChange("Date_Au", "")}
                                />
                            </Box>
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
                            onClick={() => {
                                myAxios("get_formation_liste", criteres)
                                    .then((dt) => {
                                        if (dt.data && dt.data?.result) {
                                            setDs(dt.data.data);
                                            // setDsFields(dt.data.fields); // Using manual fields for now
                                        } else {
                                            setDs([]);
                                        }
                                    })
                                    .catch((err) => {
                                        setDs([]);
                                    });
                            }}
                        />
                        <Bouton
                            label="Nouveau"
                            iconOnly={isXs || isSm}
                            sx={{ flexGrow: 1 }}
                            startIcon={<NoteAddOutlined />}
                            onClick={() => {
                                navigate(`/myspace/Formation/Formation/new`);
                            }}
                        />
                    </div>
                </>
            </GroupBox>
            <Box
                sx={{
                    margin: "auto",
                    padding: "2em 5px",
                    width: "100%",
                    overflow: "scroll",
                }}
            >
                <Grille
                    readonly={true}
                    dataSource={ds}
                    Colonnes={dsFields}
                    className="laGrille"
                    onclick={({ colIndex, value }) => {
                        if (colIndex === 0) {
                            navigate(`/myspace/Formation/Formation/${value}`);
                        }
                    }}
                    sx={{
                        "& .cl0": {
                            width: "100px !important",
                            cursor: "pointer !important",
                            "&:hover": {
                                color: colorBase.colorBase02,
                                fontStyle: "bold",
                                textDecoration: "underline",
                            },
                        },
                    }}
                />
            </Box>
        </>
    );
};

export default Formation_Liste;

type TCriteres = {
    Matricule?: string;
    Statut_Formation?: string;
    Date_Du?: Date | null;
    Date_Au?: Date | null;
};

const initialiserCriteres: TCriteres = {
    Matricule: "",
    Statut_Formation: "",
    Date_Du: null,
    Date_Au: null,
};
