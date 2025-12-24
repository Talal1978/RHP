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
    Rating,
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
import { Add, Delete, Save, CheckCircle, Cancel, Person } from "@mui/icons-material";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { cntX } from "../../Menu/MenuMain";
import TextBox from "../../components/TextBox/TextBox";
import TextZoom from "../../components/TextZoom/TextZoom";
import { Agent, colorBase } from "../../modules/module_general";
import useCombo from "../../hooks/useCombo";
import GroupBox from "../../components/GroupBox/GroupBox";
import { RTFParser } from "rtf-parser";

interface IEntete {
    Num_DR: string;
    Lib_DR: string;
    Matricule: string;
    Titre: string;
    Cod_Poste: string;
    Cod_Grade: string;
    Cod_Entite: string;
    Titre_DR: string;
    Cod_Poste_DR: string;
    Cod_Grade_DR: string;
    Cod_Entite_DR: string;
    Dat_DR: string;
    Duree_Indeterminee: boolean;
    Duree_Du: string;
    Duree_Au: string;
    Nb_Personne: number;
    Buget_Salaire: number;
    Sexe: string; // 'H', 'F', or empty for indifferent
    Age_Determine: boolean;
    Age_Du: number;
    Age_Au: number;
    Niveau: string;
    Etablissement: string;
    Experience: number;
    Parcours: string;
    Domaines_Competence: string;
    Narratif: string;
    Motif_DR: string;
    Statut: string;
    [key: string]: any;
}

const defaultEntete: IEntete = {
    Num_DR: "",
    Lib_DR: "",
    Matricule: "",
    Titre: "",
    Cod_Poste: "",
    Cod_Grade: "",
    Cod_Entite: "",
    Titre_DR: "",
    Cod_Poste_DR: "",
    Cod_Grade_DR: "",
    Cod_Entite_DR: "",
    Dat_DR: new Date().toISOString().split('T')[0],
    Duree_Indeterminee: true,
    Duree_Du: "",
    Duree_Au: "",
    Nb_Personne: 1,
    Buget_Salaire: 0,
    Sexe: "",
    Age_Determine: false,
    Age_Du: 18,
    Age_Au: 59,
    Niveau: "B0",
    Etablissement: "",
    Experience: 0,
    Parcours: "",
    Domaines_Competence: "",
    Narratif: "",
    Motif_DR: "N",
    Statut: ""
};

const Recrutement_Demande = () => {
    const myAxios = useAxiosPost();
    const msg = useMsgBox();
    const alert = useAlert();
    const { num } = useParams();
    const [entete, setEntete] = useState<IEntete>(defaultEntete);
    const [tabIndex, setTabIndex] = useState(0);
    const [newCompetence, setNewCompetence] = useState("");
    const [narratifDisplay, setNarratifDisplay] = useState("");

    // Helper to strip RTF tags for display
    const stripRTF = (rtf: string) => {
        if (!rtf) return "";
        // Basic RTF stripping 
        return rtf
            .replace(/\\par[d]?\s*/g, "\n") // Newlines
            .replace(/\{\\*?\\[^{}]+}|[{}]|\\\n?[A-Za-z]+\n?(?:-?\d+)?[ ]?/g, "") // Tags and braces
            .trim();
    };

    const toRTF = (text: string) => {
        if (!text) return "";
        const escaped = text.replace(/\\/g, '\\\\').replace(/{/g, '\\{').replace(/}/g, '\\}');
        const withNewlines = escaped.replace(/\n/g, '\\par\n');
        return `{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1036{\\fonttbl{\\f0\\fnil\\fcharset0 Calibri;}}\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1\n\\pard\\sa200\\sl276\\slmult1\\f0\\fs22\\lang12 ${withNewlines}\\par\n}`;
    };

    useEffect(() => {
        if (!entete.Narratif) {
            setNarratifDisplay("");
            return;
        }
        if (!entete.Narratif.startsWith("{\\rtf")) {
            setNarratifDisplay(entete.Narratif);
            return;
        }
        setNarratifDisplay(stripRTF(entete.Narratif));
    }, [entete.Narratif]);

    // Combos
    const niveauCombo = useCombo("Niveau");
    const motifCombo = useCombo("Motif_DR");

    const isLocked = entete.Statut === "VA" || entete.Statut === "SS" || entete.Statut === "SG" || entete.Statut === "RJ";
    const canSave = !isLocked;

    // Menu logic
    const { settbnMenu, isSmall } = useContext(cntX);

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
                name: "Enregistrer",
                libelle: "Enregistrer",
                icon: <Save />,
                action: () => saveDemande(""),
                disabled: !canSave
            },
            {
                name: "Valider",
                libelle: "Valider",
                icon: <CheckCircle />,
                action: () => saveDemande("VA"),
                disabled: !canSave,
                color: "success.main"
            },
            {
                name: "Supprimer",
                libelle: "Supprimer",
                icon: <Delete />,
                action: deleteDemande,
                disabled: entete.Num_DR === "" || !canSave,
                color: "error.main"
            }
        ]);
        return () => settbnMenu([]);
    }, [isLocked, entete.Num_DR, canSave, entete]);

    useEffect(() => {
        if (num && num !== "new") {
            loadDemande(num);
        } else if (entete.Num_DR === "" && entete.Matricule === "") {
            setEntete(prev => ({ ...prev, Matricule: Agent.Matricule }));
            loadAgentInfo(Agent.Matricule);
        }
    }, [num]);

    const handleChange = (name: string, value: any) => {
        setEntete((prev) => ({ ...prev, [name]: value }));
    };

    const handleBooleanChange = (name: string, value: boolean) => {
        setEntete((prev) => ({ ...prev, [name]: value }));
    };

    const loadAgentInfo = async (matricule: string) => {
        if (!matricule) return;
        myAxios("rh_agent", { Matricule: matricule })
            .then(res => {
                if (res.data && res.data.length > 0) {
                    const agt = res.data[0];
                    setEntete(prev => ({
                        ...prev,
                        Matricule: matricule,
                        Titre: agt.Titre || "",
                        Cod_Poste: agt.Cod_Poste || "",
                        Cod_Grade: agt.Cod_Grade || "",
                        Cod_Entite: agt.Cod_Entite || ""
                    }));
                }
            });
    };

    const loadDemande = (numDR: string) => {
        if (!numDR) return;
        myAxios("get_recrutement_demande", { Num_DR: numDR })
            .then((res) => {
                if (res.data.result && res.data.data.length > 0) {
                    setEntete(res.data.data[0]);
                } else {
                    msg({ msg: "Demande introuvable", typMsg: "warning", typReply: "OkOnly" });
                    // Optional: Reset or keep as new
                }
            });
    };

    const saveDemande = (statut: string = "") => {
        const enteteToSend = { ...entete, Statut: statut === "" ? entete.Statut : statut };

        myAxios("save_recrutement_demande", { entete: enteteToSend })
            .then((res) => {
                if (res.data.result) {
                    setEntete(prev => ({ ...prev, Num_DR: res.data.data, Statut: statut !== "" ? statut : prev.Statut }));
                    alert({ msg: res.data.message || "Enregistré avec succès", typMsg: "success" });
                } else {
                    msg({ msg: res.data.message || "Erreur lors de l'enregistrement", typMsg: "error", typReply: "OkOnly" });
                }
            });
    };

    const deleteDemande = () => {
        msg({
            msg: "Êtes-vous sûr de vouloir supprimer cette demande ?",
            typMsg: "question",
            typReply: "YesNoCancel"
        }).then((result) => {
            if (result === "Yes") {
                myAxios("delete_recrutement_demande", { Num_DR: entete.Num_DR })
                    .then((res) => {
                        if (res.data.result) {
                            alert({ msg: "Supprimé avec succès", typMsg: "success" });
                            setEntete(defaultEntete);
                            loadAgentInfo(Agent.Matricule);
                        } else {
                            msg({ msg: res.data.message || "Erreur lors de la suppression", typMsg: "error", typReply: "OkOnly" });
                        }
                    });
            }
        });
    };

    const nouveau = () => {
        setEntete(defaultEntete);
        loadAgentInfo(Agent.Matricule);
    };

    // Competence Logic
    const parseCompetences = (str: string) => {
        if (!str) return [];
        return str.split(";").filter((s) => s.trim() !== "").map(s => {
            const parts = s.split("$");
            return { name: parts[0], rating: parts.length > 1 ? parseFloat(parts[1]) : 1 };
        });
    };

    const competencesList = parseCompetences(entete.Domaines_Competence);

    const addCompetence = () => {
        if (!newCompetence.trim()) return;
        if (competencesList.some(c => c.name.toLowerCase() === newCompetence.trim().toLowerCase())) {
            msg({ msg: "Compétence déjà présente", typMsg: "warning", typReply: "OkOnly" });
            return;
        }
        const updated = [...competencesList, { name: newCompetence.trim(), rating: 1 }];
        updateCompetencesString(updated);
        setNewCompetence("");
    };

    const removeCompetence = (name: string) => {
        const updated = competencesList.filter(c => c.name !== name);
        updateCompetencesString(updated);
    };

    const updateCompetenceRating = (name: string, rating: number | null) => {
        const updated = competencesList.map(c => c.name === name ? { ...c, rating: rating || 1 } : c);
        updateCompetencesString(updated);
    }

    const updateCompetencesString = (list: { name: string, rating: number }[]) => {
        const str = list.map(c => `${c.name}$${c.rating}`).join(";");
        handleChange("Domaines_Competence", str);
    };

    const loadCompetencesFromPoste = () => {
        if (!entete.Cod_Poste_DR) {
            msg({ msg: "Veuillez sélectionner un poste demandé d'abord", typMsg: "warning", typReply: "OkOnly" });
            return;
        }
        myAxios("getPoste", { cod_poste: entete.Cod_Poste_DR })
            .then(res => {
                if (res.data.result && res.data.data.length > 0) {
                    const poste = res.data.data[0];
                    const newComps = poste.Domaines_Competence ? poste.Domaines_Competence.split(";").filter((s: string) => s.trim() !== "") : [];
                    // Logic: append new ones
                    let currentList = [...competencesList];
                    let added = false;
                    newComps.forEach((s: string) => {
                        const parts = s.split("$");
                        const name = parts[0];
                        const note = parts.length > 1 ? parseFloat(parts[1]) : 5; // Default goal
                        if (!currentList.some(c => c.name === name)) {
                            currentList.push({ name, rating: note });
                            added = true;
                        }
                    });

                    if (added) {
                        updateCompetencesString(currentList);
                        alert({ msg: "Compétences chargées du poste", typMsg: "success" });
                    } else {
                        alert({ msg: "Aucune nouvelle compétence à charger", typMsg: "info" });
                    }
                }
            });
    }

    return (
        <GroupBox
            label={`Demande de Recrutement ${entete.Num_DR ? "- " + entete.Num_DR : ""}`}
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
                <Grid item xs={12} sm={3}>
                    <TextZoom
                        numZoom="MS162"
                        nomControle="Num_DR"
                        label="N° Demande"
                        valeur={entete.Num_DR}
                        onchange={(_, val) => loadDemande(val)}
                    />
                </Grid>
                <Grid item xs={12} sm={3}>
                    <TextBox nomControle="Dat_DR" label="Date Demande" valeur={entete.Dat_DR} type="date" onchange={handleChange} readonly={isLocked} />
                </Grid>
                <Grid item xs={12} sm={3} sx={{ display: "flex", alignItems: "flex-end" }}>
                    <Typography variant="subtitle1" sx={{ fontWeight: 'bold', color: colorBase.colorBase01 }}>
                        Statut: {entete.Statut || "Brouillon"}
                    </Typography>
                </Grid>

                <Grid item xs={12}>
                    <Divider sx={{ my: 1 }}><Chip label="Demandeur" /></Divider>
                </Grid>

                <Grid item xs={12} sm={4}>
                    <TextZoom
                        numZoom="MS018"
                        nomControle="Matricule"
                        label="Matricule"
                        valeur={entete.Matricule}
                        onchange={(_, val) => { handleChange("Matricule", val); loadAgentInfo(val); }}
                        readonly={entete.Num_DR !== ""}
                    />
                </Grid>
                <Grid item xs={12} sm={4}>
                    <TextBox nomControle="Titre" label="Titre" valeur={entete.Titre} readonly />
                </Grid>
                <Grid item xs={12} sm={4}>
                    <TextBox nomControle="Cod_Entite" label="Entité" valeur={entete.Cod_Entite} readonly />
                </Grid>

                <Grid item xs={12}>
                    <Divider sx={{ my: 1 }} />
                    <Tabs value={tabIndex} onChange={(_, v) => setTabIndex(v)} indicatorColor="primary" textColor="primary">
                        <Tab label="Description du Poste" />
                        <Tab label="Profil Recherché" />
                        <Tab label="Narratif & Motif" />
                    </Tabs>
                </Grid>

                {tabIndex === 0 && (
                    <Grid item xs={12} container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <TextBox nomControle="Titre_DR" label="Intitulé du poste demandé" valeur={entete.Titre_DR} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextZoom numZoom="MS016" nomControle="Cod_Poste_DR" label="Poste Type" valeur={entete.Cod_Poste_DR} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextZoom numZoom="MS015" nomControle="Cod_Grade_DR" label="Grade" valeur={entete.Cod_Grade_DR} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextZoom numZoom="MS010" nomControle="Cod_Entite_DR" label="Entité d'affectation" valeur={entete.Cod_Entite_DR} onchange={handleChange} readonly={isLocked} />
                        </Grid>

                        <Grid item xs={12}><Divider sx={{ my: 1 }} /></Grid>

                        <Grid item xs={12} sm={4}>
                            <FormControl component="fieldset">
                                <FormLabel component="legend">Durée</FormLabel>
                                <RadioGroup row value={entete.Duree_Indeterminee ? "Indeterminee" : "Determinee"} onChange={(e) => handleBooleanChange("Duree_Indeterminee", e.target.value === "Indeterminee")}>
                                    <FormControlLabel value="Indeterminee" control={<Radio />} label="Indéterminée" disabled={isLocked} />
                                    <FormControlLabel value="Determinee" control={<Radio />} label="Déterminée" disabled={isLocked} />
                                </RadioGroup>
                            </FormControl>
                        </Grid>
                        {!entete.Duree_Indeterminee && (
                            <>
                                <Grid item xs={12} sm={4}>
                                    <TextBox nomControle="Duree_Du" label="Du" type="date" valeur={entete.Duree_Du} onchange={handleChange} readonly={isLocked} />
                                </Grid>
                                <Grid item xs={12} sm={4}>
                                    <TextBox nomControle="Duree_Au" label="Au" type="date" valeur={entete.Duree_Au} onchange={handleChange} readonly={isLocked} />
                                </Grid>
                            </>
                        )}

                        <Grid item xs={12}><Divider sx={{ my: 1 }} /></Grid>

                        <Grid item xs={12} sm={6}>
                            <TextBox nomControle="Nb_Personne" label="Nombre de personnes" type="number" valeur={entete.Nb_Personne} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextBox nomControle="Buget_Salaire" label="Budget Salaire (Est.)" type="number" valeur={entete.Buget_Salaire} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                    </Grid>
                )}

                {tabIndex === 1 && (
                    <Grid item xs={12} container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <FormControl component="fieldset">
                                <FormLabel component="legend">Sexe</FormLabel>
                                <RadioGroup row value={entete.Sexe || ""} onChange={(e) => handleChange("Sexe", e.target.value)}>
                                    <FormControlLabel value="" control={<Radio />} label="Indifférent" disabled={isLocked} />
                                    <FormControlLabel value="H" control={<Radio />} label="Homme" disabled={isLocked} />
                                    <FormControlLabel value="F" control={<Radio />} label="Femme" disabled={isLocked} />
                                </RadioGroup>
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <FormControl component="fieldset">
                                <FormLabel component="legend">Age</FormLabel>
                                <RadioGroup row value={entete.Age_Determine ? "Determine" : "Indifferent"} onChange={(e) => handleBooleanChange("Age_Determine", e.target.value === "Determine")}>
                                    <FormControlLabel value="Indifferent" control={<Radio />} label="Indifférent" disabled={isLocked} />
                                    <FormControlLabel value="Determine" control={<Radio />} label="Déterminé" disabled={isLocked} />
                                </RadioGroup>
                            </FormControl>
                        </Grid>
                        {entete.Age_Determine && (
                            <>
                                <Grid item xs={12} sm={3}>
                                    <TextBox nomControle="Age_Du" label="Age Min" type="number" valeur={entete.Age_Du} onchange={handleChange} readonly={isLocked} />
                                </Grid>
                                <Grid item xs={12} sm={3}>
                                    <TextBox nomControle="Age_Au" label="Age Max" type="number" valeur={entete.Age_Au} onchange={handleChange} readonly={isLocked} />
                                </Grid>
                            </>
                        )}

                        <Grid item xs={12}><Divider sx={{ my: 1 }} /></Grid>

                        <Grid item xs={12} sm={4}>
                            <TextField
                                select
                                label="Niveau d'étude"
                                value={entete.Niveau || ""}
                                onChange={(e) => handleChange("Niveau", e.target.value)}
                                fullWidth
                                variant="standard"
                                disabled={isLocked}
                            >
                                {niveauCombo.map((opt) => (
                                    <MenuItem key={opt.value} value={opt.value}>
                                        {opt.label}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xs={12} sm={4}>
                            <TextBox nomControle="Experience" label="Expérience (Années)" type="number" valeur={entete.Experience} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                        <Grid item xs={12} sm={4}>
                            <TextBox nomControle="Etablissement" label="Etablissement cible" valeur={entete.Etablissement} onchange={handleChange} readonly={isLocked} />
                        </Grid>
                        <Grid item xs={12}>
                            <TextBox nomControle="Parcours" label="Parcours / Diplôme" multiline maxRows={2} valeur={entete.Parcours} onchange={handleChange} readonly={isLocked} />
                        </Grid>

                        <Grid item xs={12}><Divider sx={{ my: 2 }} /></Grid>

                        <Grid item xs={12}>
                            <Typography variant="h6" gutterBottom>Compétences Requises</Typography>
                            <Box sx={{ display: 'flex', gap: 1, alignItems: 'center', mb: 1 }}>
                                <TextField
                                    label="Nouvelle compétence"
                                    variant="outlined"
                                    size="small"
                                    value={newCompetence}
                                    onChange={(e) => setNewCompetence(e.target.value)}
                                    disabled={isLocked}
                                />
                                <Button variant="contained" size="small" onClick={addCompetence} disabled={isLocked}><Add /></Button>
                                <Button variant="outlined" size="small" onClick={loadCompetencesFromPoste} disabled={isLocked}>Charger du poste</Button>
                            </Box>

                            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1, mt: 1, p: 1, border: '1px dashed #ccc', borderRadius: 1 }}>
                                {competencesList.map((c, i) => (
                                    <Box key={i} sx={{ display: 'flex', alignItems: 'center', bgcolor: 'action.hover', borderRadius: 4, px: 2, py: 0.5, gap: 1 }}>
                                        <Typography variant="body2">{c.name}</Typography>
                                        <Rating
                                            value={c.rating}
                                            precision={0.5}
                                            size="small"
                                            readOnly={isLocked}
                                            onChange={(_, val) => updateCompetenceRating(c.name, val)}
                                        />
                                        {!isLocked && <IconButton size="small" onClick={() => removeCompetence(c.name)}><Cancel fontSize="small" /></IconButton>}
                                    </Box>
                                ))}
                            </Box>
                        </Grid>
                    </Grid>
                )}

                {tabIndex === 2 && (
                    <Grid item xs={12} container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                select
                                label="Motif du recrutement"
                                value={entete.Motif_DR || ""}
                                onChange={(e) => handleChange("Motif_DR", e.target.value)}
                                fullWidth
                                variant="standard"
                                disabled={isLocked}
                            >
                                <MenuItem value="N">Aucun</MenuItem>
                                {motifCombo.map((opt) => (
                                    <MenuItem key={opt.value} value={opt.value}>
                                        {opt.label}
                                    </MenuItem>
                                ))}
                            </TextField>
                        </Grid>
                        <Grid item xs={12}>
                            <TextBox
                                nomControle="Narratif"
                                label="Narratif / Justification"
                                multiline
                                minRows={4}
                                valeur={narratifDisplay}
                                onchange={(name, val) => {
                                    setNarratifDisplay(val);
                                    handleChange(name, toRTF(val));
                                }}
                                readonly={isLocked}
                            />
                        </Grid>
                    </Grid>
                )}
            </Grid>
        </GroupBox>
    );
};

export default Recrutement_Demande;
