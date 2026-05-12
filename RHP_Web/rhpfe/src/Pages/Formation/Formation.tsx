import React, { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
    Box,
    Button,
    Chip,
    Divider,
    Grid,
    IconButton,
    InputAdornment,
    MenuItem,
    Tab,
    Tabs,
    TextField,
    Typography,
    Radio,
    RadioGroup,
    FormControlLabel,
    FormControl,
    FormLabel
} from "@mui/material";
import { Add, Delete, Save, CheckCircle, Cancel, Person, AttachFileOutlined } from "@mui/icons-material";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { cntX } from "../../Menu/MenuMain";
import TextBox from "../../components/TextBox/TextBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import TextZoom from "../../components/TextZoom/TextZoom";
import { Agent, colorBase } from "../../modules/module_general";
import { parseRtfToText, toRTF } from "../../modules/module_formats";
import useCombo from "../../hooks/useCombo";
import GroupBox from "../../components/GroupBox/GroupBox";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";

interface IEntete {
    Cod_Formation: string;
    Lib_Formation: string;
    Dat_Du: string;
    Dat_Au: string;
    Statut_Formation: string;
    Budget: number;
    Nature_Formation: number; // 1=Interne, 2=Externe
    Typ_Lieu: number; // 1=Salle, 2=Externe, 3=Distance
    Lieu: string;
    Cod_Cabinet: string;
    Cod_Formateur: string;
    Action_Formation: string;
    Genre_Formation: string;
    Contenu: string;
    [key: string]: any;
}

const defaultEntete: IEntete = {
    Cod_Formation: "",
    Lib_Formation: "",
    Dat_Du: new Date().toISOString().split('T')[0],
    Dat_Au: new Date().toISOString().split('T')[0],
    Statut_Formation: "Planifiee",
    Budget: 0,
    Nature_Formation: 2, // Default Externe
    Typ_Lieu: 2,
    Lieu: "",
    Cod_Cabinet: "",
    Cod_Formateur: "",
    Action_Formation: "",
    Genre_Formation: "",
    Contenu: ""
};

const Formation = () => {
    const myAxios = useAxiosPost();
    const { settbnMenu, isSmall, setShowGED, setGEDprops } = useContext(cntX);
    const msgbox = useMsgBox();
    const { num } = useParams();
    const [entete, setEntete] = useState<IEntete>(defaultEntete);
    const [tabIndex, setTabIndex] = useState(0);
    const [contenuDisplay, setContenuDisplay] = useState("");

    // RTF Helpers


    useEffect(() => {
        if (!entete.Contenu) {
            setContenuDisplay("");
            return;
        }
        if (!entete.Contenu.startsWith("{\\rtf")) {
            setContenuDisplay(entete.Contenu);
            return;
        }
        setContenuDisplay(parseRtfToText(entete.Contenu));
    }, [entete.Contenu]);

    // Child Tables
    const [participants, setParticipants] = useState<any[]>([]);
    const [modules, setModules] = useState<any[]>([]);
    const [financement, setFinancement] = useState<any[]>([]);

    // Grid Configurations
    const participantCols: TColonneCollection = {
        Matricule: { columnName: "Matricule", headerText: "Matricule", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 100 } },
        Nom_Complet: { columnName: "Nom_Complet", headerText: "Nom", dataType: "nvarchar", visible: true, readOnly: true },
        Present: { columnName: "Present", headerText: "Présent", dataType: "nvarchar", visible: true, sx: { width: "80px", minWidth: "80px", maxWidth: "80px", textAlign: "center", color: colorBase.colorBase01 }, readOnly: true },
        Statut_Evaluation: { columnName: "Statut_Evaluation", headerText: "Evalué", dataType: "nvarchar", visible: true, sx: { width: "80px", minWidth: "80px", maxWidth: "80px", textAlign: "center", color: colorBase.colorBase01 }, readOnly: true }
    };

    const moduleCols: TColonneCollection = {
        Domaines_Competence: { columnName: "Domaines_Competence", headerText: "Code", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 80 } },
        Lib_Domaines_Competence: { columnName: "Lib_Domaines_Competence", headerText: "Module / Compétence", dataType: "nvarchar", visible: true, readOnly: true },
        Lib_Typ_Formation: { columnName: "Lib_Typ_Formation", headerText: "Type Formation", dataType: "nvarchar", visible: true, readOnly: true }
    };

    const finCols: TColonneCollection = {
        Organisme: { columnName: "Organisme", headerText: "Organisme", dataType: "nvarchar", visible: true, readOnly: true },
        Montant: { columnName: "Montant", headerText: "Montant", dataType: "float", visible: true, readOnly: true }
    };

    const isLocked = ["Validee", "Cloturee", "Annulee"].includes(entete.Statut_Formation);
    const canSave = !isLocked;

    // Combos
    const genreCombo = useCombo("Genre_Formation");

    // Menu logic
    useEffect(() => {
        settbnMenu([
            {
                name: "Nouveau",
                libelle: "Nouveau",
                icon: <Add />,
                action: nouveau,
                disabled: false
            },
            {
                name: "PJ",
                disabled: false,
                libelle: "Pièces jointes",
                action: () => {
                    if (entete.Cod_Formation) {
                        setGEDprops({ name_ecran: "Formation", valeur_index: entete.Cod_Formation });
                        setShowGED(true);
                    } else {
                        msgbox({ msg: "Veuillez d'abord sélectionner une formation.", typMsg: "warning", typReply: "OkOnly" });
                    }
                },
                icon: <AttachFileOutlined />,
            }
        ]);
        return () => settbnMenu([]);
    }, [isLocked, entete.Cod_Formation, canSave, entete, participants, modules, financement]);

    useEffect(() => {
        if (num && num !== "new") {
            loadFormation(num);
        } else if (!entete.Cod_Formation) {
            // New Mode
        }
    }, [num]);

    const handleChange = (name: string, value: any) => {
        setEntete((prev) => ({ ...prev, [name]: value }));
    };

    const loadFormation = (code: string) => {
        if (!code) return;
        myAxios("get_formation", { Cod_Formation: code })
            .then((res) => {
                if (res.data.result) {
                    if (res.data.data.length > 0) {
                        const d = res.data.data[0];
                        if (d.Dat_Du) d.Dat_Du = d.Dat_Du.split("T")[0];
                        if (d.Dat_Au) d.Dat_Au = d.Dat_Au.split("T")[0];
                        setEntete(d);
                        setParticipants(d.Participants || []);
                        setModules(d.Modules || []);
                        setFinancement(d.Financement || []);
                    } else {
                        msgbox({ msg: "Formation introuvable", typMsg: "warning", typReply: "OkOnly" });
                    }
                } else {
                    msgbox({ msg: res.data.message, typMsg: "error", typReply: "OkOnly" });
                }
            });
    };
    const nouveau = () => {
        setEntete(defaultEntete);
        setParticipants([]);
        setModules([]);
        setFinancement([]);
    };

    return (
        <GroupBox
            label={`Fiche Formation ${entete.Cod_Formation ? "- " + entete.Cod_Formation : ""}`}
            showBorders={!isSmall}
            showTitre={true}
            sx={{
                "& > .grpDiv": {
                    padding: "2em 5px 5px 5px",
                    width: "90vw",
                    maxWidth: "1200px",
                    minHeight: "10em",
                },
            }}
        >
            <Grid container spacing={2}>
                <Grid item xs={12} sm={3}>
                    <TextBox nomControle="Cod_Formation" label="Code" valeur={entete.Cod_Formation} readonly />
                </Grid>
                <Grid item xs={12} sm={6}>
                    <TextBox nomControle="Lib_Formation" label="Intitulé" valeur={entete.Lib_Formation} onchange={handleChange} readonly={isLocked} />
                </Grid>
                <Grid item xs={12} sm={3} sx={{ display: "flex", alignItems: "flex-end" }}>
                    <Chip label={entete.Statut_Formation} color={entete.Statut_Formation === 'Validee' ? "success" : "default"} />
                </Grid>

                <Grid item xs={12}><Divider /></Grid>

                <Grid item xs={12} sm={3}>
                    <TextBox nomControle="Dat_Du" label="Du" type="date" valeur={entete.Dat_Du} onchange={handleChange} readonly={isLocked} />
                </Grid>
                <Grid item xs={12} sm={3}>
                    <TextBox nomControle="Dat_Au" label="Au" type="date" valeur={entete.Dat_Au} onchange={handleChange} readonly={isLocked} />
                </Grid>
                <Grid item xs={12} sm={3}>
                    <TextBox nomControle="Budget" label="Budget" type="number" valeur={entete.Budget} onchange={handleChange} readonly={isLocked} />
                </Grid>
                <Grid item xs={12} sm={3}>
                    <TextField
                        select
                        label="Genre"
                        value={entete.Genre_Formation || ""}
                        onChange={(e) => handleChange("Genre_Formation", e.target.value)}
                        fullWidth
                        variant="standard"
                        disabled={isLocked}
                    >
                        {genreCombo.map((opt) => <MenuItem key={opt.value} value={opt.value}>{opt.label}</MenuItem>)}
                    </TextField>
                </Grid>

                <Grid item xs={12} sm={6}>
                    <FormControl component="fieldset">
                        <FormLabel component="legend">Nature</FormLabel>
                        <RadioGroup row value={entete.Nature_Formation} onChange={(e) => handleChange("Nature_Formation", parseInt(e.target.value))}>
                            <FormControlLabel value={1} control={<Radio />} label="Interne" disabled={isLocked} />
                            <FormControlLabel value={2} control={<Radio />} label="Externe" disabled={isLocked} />
                        </RadioGroup>
                    </FormControl>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <FormControl component="fieldset">
                        <FormLabel component="legend">Lieu</FormLabel>
                        <RadioGroup row value={entete.Typ_Lieu} onChange={(e) => handleChange("Typ_Lieu", parseInt(e.target.value))}>
                            <FormControlLabel value={1} control={<Radio />} label="Salle" disabled={isLocked} />
                            <FormControlLabel value={2} control={<Radio />} label="Externe" disabled={isLocked} />
                            <FormControlLabel value={3} control={<Radio />} label="Distance" disabled={isLocked} />
                        </RadioGroup>
                    </FormControl>
                </Grid>

                {entete.Nature_Formation === 2 && (
                    <Grid item xs={12} sm={6}>
                        <TextZoom numZoom="MS150" nomControle="Cod_Cabinet" label="Cabinet" valeur={entete.Cod_Cabinet} onchange={handleChange} readonly={isLocked} />
                    </Grid>
                )}
                <Grid item xs={12} sm={6}>
                    <TextZoom
                        numZoom={entete.Nature_Formation === 1 ? "MS152" : "MS153"}
                        nomControle="Cod_Formateur"
                        label="Formateur"
                        valeur={entete.Cod_Formateur}
                        onchange={handleChange}
                        readonly={isLocked}
                    />
                </Grid>

                <Grid item xs={12}>
                    <Tabs
                        value={tabIndex}
                        onChange={(_, v) => setTabIndex(v)}
                        sx={{ mb: 1, borderBottom: 1, borderColor: "divider" }}
                        variant="scrollable"
                        scrollButtons="auto"
                        allowScrollButtonsMobile
                    >
                        <Tab label="Modules / Compétences" />
                        <Tab label="Participants" />
                        <Tab label="Financement" />
                        <Tab label="Contenu" />
                    </Tabs>
                </Grid>

                {/* Modules Tab */}
                <Grid item xs={12} sx={{ display: tabIndex === 0 ? "block" : "none" }}>
                    <GroupBox label="Modules">
                        {/* Placeholder for Add Module Button */}
                        <Grille dataSource={modules} Colonnes={moduleCols} className="laGrille" />
                    </GroupBox>
                </Grid>

                {/* Participants Tab */}
                <Grid item xs={12} sx={{ display: tabIndex === 1 ? "block" : "none" }}>
                    <GroupBox label="Participants">
                        {/* Placeholder for Add Participant Button */}
                        <Grille dataSource={participants} Colonnes={participantCols} className="laGrille" />
                    </GroupBox>
                </Grid>

                {/* Financement Tab */}
                <Grid item xs={12} sx={{ display: tabIndex === 2 ? "block" : "none" }}>
                    <GroupBox label="Financement">
                        {/* Placeholder for Add Finance Button */}
                        <Grille dataSource={financement} Colonnes={finCols} className="laGrille" />
                    </GroupBox>
                </Grid>

                {/* Contenu Tab */}
                <Grid item xs={12} sx={{ display: tabIndex === 3 ? "block" : "none" }}>
                    <GroupBox label="Contenu de la formation">
                        <TextBox
                            nomControle="Contenu"
                            label=""
                            multiline
                            minRows={isSmall ? 5 : 10}
                            valeur={contenuDisplay}
                            onchange={(name, val) => {
                                setContenuDisplay(val);
                                handleChange(name, toRTF(val));
                            }}
                            readonly={isLocked}
                            fullWidth
                        />
                    </GroupBox>
                </Grid>
            </Grid>
        </GroupBox>
    );
};

export default Formation;
