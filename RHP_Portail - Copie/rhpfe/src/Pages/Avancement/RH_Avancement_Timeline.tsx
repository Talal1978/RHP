import { useContext, useEffect, useMemo, useState } from "react";
import { cntX } from "../../Menu/MenuMain";
import { useLocation } from "react-router-dom";
import { Box, Typography, Divider, Card, CardContent, Chip, CircularProgress, createTheme, ThemeProvider, CssBaseline } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import BusinessCenterIcon from '@mui/icons-material/BusinessCenter';
import StarIcon from '@mui/icons-material/Star';
import ApartmentIcon from '@mui/icons-material/Apartment';
import EventIcon from '@mui/icons-material/Event';
import { format } from "date-fns";
import { fr } from "date-fns/locale";
import useAxiosPost from "../../hooks/useAxiosPost";
import useAlert from "../../hooks/useAlert";
import TextZoom from "../../components/TextZoom/TextZoom";
import { Agent, colorBase } from "../../modules/module_general";
import { parentCntX } from "../../Context/GlobalContext";

interface TimelineData {
    Dat_Effet: string;
    Nouveau_Poste: string;
    Nouveau_Grade: string;
    Nouvelle_Entite: string;
    Motif: string;
    Mission: string;
    Type_Avancement: string;
    Cod_Avancement: string;
    Lib_Type_Avancement: string;
}

const RH_Avancement_Timeline = () => {
    const { settbnMenu } = useContext(cntX);
    const { themeMode } = useContext(parentCntX);
    const location = useLocation();
    const alert = useAlert();
    const myAxios = useAxiosPost();
    const title = location?.state?.title;
    const [data, setData] = useState<TimelineData[]>([]);
    const [loading, setLoading] = useState(false);
    const [matricule, setMatricule] = useState(Agent.Matricule);
    const [personInfo, setPersonInfo] = useState<{ Nom: string; Prenom: string } | null>(null);

    // Create a local theme based on the global themeMode
    const theme = useMemo(() => createTheme({
        palette: {
            mode: themeMode,
            primary: {
                main: colorBase.colorBase01, // Use app primary color
            },
            background: {
                default: themeMode === 'dark' ? '#121212' : '#f5f7fa',
                paper: themeMode === 'dark' ? '#1e1e1e' : '#ffffff',
            },
            text: {
                primary: themeMode === 'dark' ? '#ffffff' : '#333333',
                secondary: themeMode === 'dark' ? '#aaaaaa' : '#666666',
            }
        },
    }), [themeMode]);

    useEffect(() => {
        settbnMenu([
            {
                libelle: "Fermer",
                name: "fermer",
                action: () => { /* Handle close if needed, or just let menu handle it */ },
                icon: <CloseIcon />,
                disabled: false
            },
        ]);
    }, [settbnMenu]);

    const fetchTimeline = async () => {
        if (!matricule) return;

        setLoading(true);
        try {
            // Fetch Timeline
            const res = await myAxios("get_avancement_timeline", { Matricule: matricule });

            if (res.data && res.data.result) {
                setData(res.data.data);
            } else {
                alert({ msg: res.data?.error || "Aucune donnée trouvée", typMsg: "error" });
                setData([]);
            }
        } catch (error) {
            console.error(error);
            alert({ msg: "Erreur lors du chargement des données", typMsg: "error" });
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchTimeline();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [matricule]);

    const handleMatriculeChange = (name: string, val: any) => {
        const mat = typeof val === 'object' && val?.Matricule ? val.Matricule : val;
        setMatricule(mat);
    };

    return (
        <ThemeProvider theme={theme}>
            {/* CssBaseline ensures background color is applied */}
            <CssBaseline />
            <Box sx={{ p: 2, height: '100%', overflow: 'auto', backgroundColor: 'background.default', color: 'text.primary' }}>
                <Box sx={{ mb: 3, display: 'flex', alignItems: 'center', gap: 2, flexWrap: 'wrap' }}>
                    <Typography variant="h5" sx={{ color: 'primary.main', fontWeight: 'bold' }}>
                        {title || "Chronologie de carrière"}
                    </Typography>
                    <Box sx={{ flexGrow: 1 }} />
                </Box>
                <TextZoom
                    numZoom="MS067"
                    nomControle="Matricule"
                    label="Matricule"
                    valeur={matricule}
                    onchange={handleMatriculeChange}
                    findlibelle={{
                        champs: "Nom_Agent+' '+Prenom_Agent",
                        code: "Matricule",
                        tblName: "RH_Agent"
                    }}
                    style={{ width: "100%" }}
                />
                <Divider sx={{ mb: 4 }} />

                {loading ? (
                    <Box sx={{ display: 'flex', justifyContent: 'center', p: 4 }}>
                        <CircularProgress />
                    </Box>
                ) : data.length === 0 ? (
                    <Card sx={{ p: 2, textAlign: 'center' }}>
                        <Typography>Aucun historique trouvé pour cet agent.</Typography>
                    </Card>
                ) : (
                    <Box sx={{ position: 'relative', maxWidth: '800px', mx: 'auto', p: 2 }}>
                        {/* Vertical Line */}
                        <Box sx={{
                            position: 'absolute',
                            left: { xs: '20px', md: '50%' },
                            top: 0,
                            bottom: 0,
                            width: '2px',
                            bgcolor: 'divider',
                            transform: { md: 'translateX(-50%)' }
                        }} />

                        {data.map((item, index) => (
                            <Box key={index} sx={{
                                display: 'flex',
                                flexDirection: { xs: 'column', md: index % 2 === 0 ? 'row' : 'row-reverse' },
                                mb: 4,
                                position: 'relative'
                            }}>
                                {/* Dot */}
                                <Box sx={{
                                    position: 'absolute',
                                    left: { xs: '20px', md: '50%' },
                                    width: '16px',
                                    height: '16px',
                                    borderRadius: '50%',
                                    bgcolor: 'primary.main',
                                    border: `4px solid`,
                                    borderColor: 'background.paper',
                                    boxShadow: (theme) => `0 0 0 2px ${theme.palette.primary.main}`,
                                    top: '20px',
                                    transform: 'translateX(-50%)',
                                    zIndex: 1
                                }} />

                                {/* Date / Label Side */}
                                <Box sx={{
                                    width: { xs: '100%', md: '50%' },
                                    px: 4,
                                    textAlign: { xs: 'left', md: index % 2 === 0 ? 'right' : 'left' },
                                    mb: { xs: 1, md: 0 },
                                    pl: { xs: '50px', md: index % 2 === 0 ? 0 : 4 },
                                    pr: { xs: 0, md: index % 2 === 0 ? 4 : 0 }
                                }}>
                                    <Chip
                                        label={item.Type_Avancement === 'ACTUEL' ? "Aujourd'hui" : format(new Date(item.Dat_Effet), 'dd MMM yyyy', { locale: fr })}
                                        color={item.Type_Avancement === 'ACTUEL' ? "success" : "primary"}
                                        variant={item.Type_Avancement === 'ACTUEL' ? "filled" : "outlined"}
                                        size="small"
                                        icon={<EventIcon />}
                                    />
                                    <Typography variant="body2" color="text.secondary" sx={{ mt: 1, fontStyle: 'italic' }}>
                                        {item.Lib_Type_Avancement || item.Type_Avancement}
                                    </Typography>
                                </Box>

                                {/* Content Side */}
                                <Box sx={{
                                    width: { xs: '100%', md: '50%' },
                                    pl: { xs: '50px', md: index % 2 === 0 ? 4 : 0 },
                                    pr: { xs: 0, md: index % 2 === 0 ? 0 : 4 },
                                    textAlign: 'left'
                                }}>
                                    <Card elevation={3} sx={{ borderRadius: 2, transition: '0.3s', '&:hover': { transform: 'scale(1.01)', boxShadow: 6 } }}>
                                        <CardContent>
                                            <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mb: 1 }}>
                                                <BusinessCenterIcon fontSize="small" color="action" />
                                                <Typography variant="h6" component="span" sx={{ fontWeight: 'bold' }}>
                                                    {item.Nouveau_Poste}
                                                </Typography>
                                            </Box>

                                            <Divider sx={{ my: 1 }} />

                                            <Box sx={{ display: 'flex', flexDirection: 'column', gap: 1 }}>
                                                {item.Nouveau_Grade && (
                                                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                                                        <StarIcon fontSize="small" sx={{ color: '#ffb400' }} />
                                                        <Typography variant="body2" color="text.secondary">
                                                            Grade: <span style={{ fontWeight: 500, color: 'text.primary' }}>{item.Nouveau_Grade}</span>
                                                        </Typography>
                                                    </Box>
                                                )}

                                                {item.Nouvelle_Entite && (
                                                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                                                        <ApartmentIcon fontSize="small" color="action" />
                                                        <Typography variant="body2" color="text.secondary">
                                                            Entité: <span style={{ fontWeight: 500, color: 'text.primary' }}>{item.Nouvelle_Entite}</span>
                                                        </Typography>
                                                    </Box>
                                                )}
                                            </Box>

                                            {item.Mission && (
                                                <Box sx={{ mt: 2, p: 1.5, backgroundColor: (theme) => theme.palette.mode === 'dark' ? 'rgba(255,255,255,0.05)' : '#f0f4f8', borderRadius: 1 }}>
                                                    <Typography variant="caption" color="text.secondary" sx={{ display: 'block', mb: 0.5, fontWeight: 'bold' }}>
                                                        Mission
                                                    </Typography>
                                                    <Typography variant="body2" sx={{ fontStyle: 'italic', color: 'text.secondary' }}>
                                                        {item.Mission}
                                                    </Typography>
                                                </Box>
                                            )}

                                            {item.Motif && (
                                                <Typography variant="caption" display="block" sx={{ mt: 1, color: 'text.secondary' }}>
                                                    Motif: {item.Motif}
                                                </Typography>
                                            )}
                                        </CardContent>
                                    </Card>
                                </Box>
                            </Box>
                        ))}
                    </Box>
                )}
            </Box>
        </ThemeProvider>
    );
};

export default RH_Avancement_Timeline;
