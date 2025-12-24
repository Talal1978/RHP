import { Box, Chip, Divider, Grid, Rating, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import { cntX } from "../../Menu/MenuMain";
import TextBox from "../../components/TextBox/TextBox";
import { Agent, colorBase } from "../../modules/module_general";
import "./Org_Poste.scss";
import useCombo from "../../hooks/useCombo";
import TextZoom from "../../components/TextZoom/TextZoom";

// Reusing Competence component logic but inline or adapted if needed.
// Competence component expects { competence, intitule, note, showNote }
// The VB code parses strings like "Skill;Skill2" or "Comp$Note;Comp2$Note2".

interface IPoste {
    Cod_Poste: string;
    Lib_Poste: string;
    Cod_Grade: string;
    Soft_Skills: string;
    Domaines_Competence: string;
    Background_Academique: string;
    nb_Annees_Experience: number;
    Mission: string;
    TachesAttributions: string;
    Responsabilites: string;
    Dependance_Hierarchique: string;
    Dependance_fonctionnelle: string;
}

const Org_Poste = () => {
    const myAxios = useAxiosPost();
    const { isSmall } = useContext(cntX);
    const [poste, setPoste] = useState<IPoste | null>(null);
    const domaines_competences = useCombo("domaines_competences");
    const grade = useCombo("grade");
    const postes = useCombo("postes");
    const background_academique = useCombo("Niveau");
    console.log("Niveau", background_academique);
    useEffect(() => {
        if (Agent.Cod_Poste) {
            loadPoste(Agent.Cod_Poste);
        }
    }, [Agent.Cod_Poste]);

    const loadPoste = (code: string) => {
        myAxios("getPoste", { cod_poste: code })
            .then((res) => {
                if (res.data.result && res.data.data.length > 0) {
                    setPoste(res.data.data[0]);
                } else {
                    console.log("No data found for poste: " + code);
                }
            })
            .catch((err) => console.error(err));
    };

    const parseChips = (str: string) => {
        if (!str) return [];
        return str.split(";").filter((s) => s.trim() !== "");
    };

    const parseCompetences = (str: string) => {
        if (!str) return [];
        return str.split(";").filter((s) => s.trim() !== "").map(s => {
            const parts = s.split("$");
            return { name: parts[0], rating: parts.length > 1 ? parseFloat(parts[1]) : 0 };
        });
    };

    if (!poste) return <Typography>Aucune donnée à afficher</Typography>;

    return (
        <Box className="org-poste-container">
            <Typography variant="h6" gutterBottom sx={{ color: colorBase.colorBase02 }}>Poste</Typography>
            <Grid container spacing={2}>
                <Grid item xs={12} sm={3}>
                    <TextZoom
                        numZoom="MS016"
                        nomControle="Cod_Poste"
                        label="Code poste"
                        valeur={poste?.Cod_Poste || Agent.Cod_Poste}
                        onchange={(_: string, valeur: any) => loadPoste(valeur)}
                        style={{ width: "100%", color: colorBase.colorBase01 }}
                    />
                </Grid>
                <Grid item xs={12} sm={9}>
                    <Typography variant="h5" gutterBottom sx={{ fontWeight: "bold", color: colorBase.colorBase01, display: "flex", alignItems: "center", justifyContent: "flex-start", paddingTop: "15px" }}>
                        {poste.Lib_Poste} ({poste.Cod_Poste})
                    </Typography>
                </Grid>
            </Grid>
            <Divider sx={{ my: 2 }} />
            <Grid container spacing={2}>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom sx={{ color: colorBase.colorBase01 }}><span style={{ fontWeight: "bold" }}>Grade : </span>{grade.find((g) => g.value === poste.Cod_Grade)?.label || poste.Cod_Grade}</Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom sx={{ color: colorBase.colorBase01 }}><span style={{ fontWeight: "bold" }}>Expérience minimum : </span>{poste.nb_Annees_Experience === 1 ? poste.nb_Annees_Experience + ' an' : poste.nb_Annees_Experience + ' ans'}</Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom sx={{ color: colorBase.colorBase01 }}><span style={{ fontWeight: "bold" }}>Background Académique : </span>{background_academique.find((g) => g.value === poste.Background_Academique)?.label || poste.Background_Academique}</Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom sx={{ color: colorBase.colorBase01 }}><span style={{ fontWeight: "bold" }}>Dépendance Hiérarchique : </span>{postes.find((g) => g.value === poste.Dependance_Hierarchique)?.label || poste.Dependance_Hierarchique}</Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom sx={{ color: colorBase.colorBase01 }}><span style={{ fontWeight: "bold" }}>Dépendance fonctionnelle : </span>{postes.find((g) => g.value === poste.Dependance_fonctionnelle)?.label || poste.Dependance_fonctionnelle}</Typography>
                </Grid>
            </Grid>

            <Divider sx={{ my: 2 }} />

            <Typography variant="h6" gutterBottom sx={{ color: colorBase.colorBase02 }}>Mission</Typography>
            <div style={{ whiteSpace: 'pre-wrap', wordBreak: 'break-word', overflowWrap: 'break-word', textAlign: 'justify', lineHeight: '1.5', fontSize: '0.9rem', color: '#333', padding: '1rem', width: '100%' }}>{poste.Mission}</div>

            <Divider sx={{ my: 2 }} />
            <Typography variant="h6" gutterBottom sx={{ color: colorBase.colorBase02 }}>Attributions</Typography>
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1 }}>
                {parseChips(poste.TachesAttributions).map((t, i) => (
                    <Chip key={i} label={t} sx={{ bgcolor: colorBase.colorBase04, color: '#333' }} />
                ))}
            </Box>
            <Divider sx={{ my: 2 }} />
            <Typography variant="h6" gutterBottom sx={{ color: colorBase.colorBase02 }}>Responsabilités</Typography>
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1 }}>
                {parseChips(poste.Responsabilites).map((t, i) => (
                    <Chip key={i} label={t} sx={{ bgcolor: colorBase.colorBase04, color: '#333' }} />
                ))}
            </Box>
            <Divider sx={{ my: 2 }} />
            <Typography variant="h6" gutterBottom sx={{ color: colorBase.colorBase02 }}>Compétences Techniques</Typography>
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1 }}>
                {parseCompetences(poste.Domaines_Competence).map((c, i) => (
                    <Box key={i} sx={{
                        bgcolor: colorBase.colorBase04,
                        borderRadius: '16px',
                        px: 2, py: 0.5,
                        display: 'flex',
                        alignItems: 'center',
                        gap: 1
                    }}>
                        <Typography variant="body2">{domaines_competences.find((d) => d.value === c.name)?.label || c.name}</Typography>
                        <Rating value={c.rating} readOnly size="small" precision={0.5} />
                    </Box>
                ))}
            </Box>

            <Divider sx={{ my: 2 }} />

            <Typography variant="h6" gutterBottom sx={{ color: colorBase.colorBase02 }}>Soft Skills</Typography>
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1 }}>
                {parseChips(poste.Soft_Skills).map((t, i) => (
                    <Chip key={i} label={t.replace(/^#/, '')} variant="outlined" sx={{ borderColor: colorBase.colorBase01, color: colorBase.colorBase01 }} />
                ))}
            </Box>

        </Box>
    );
};

export default Org_Poste;
