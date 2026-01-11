import React, { useEffect, useState } from "react";
import {
    Box,
    Card,
    CardContent,
    Grid,
    Typography,
    Avatar,
    IconButton,
    Button,
    useTheme,
    Divider,
    Paper,
    Stack,
    Chip,
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    CardMedia,
} from "@mui/material";
import {
    NotificationsOutlined,
    CalendarMonth,
    DescriptionOutlined,
    AccountBalanceWalletOutlined,
    ArrowForward,
    WavingHand,
    MedicalServicesOutlined,
    SchoolOutlined,
    AttachMoneyOutlined,
    BeachAccessOutlined,
    RateReviewOutlined,
    CreateOutlined,
    WbSunnyOutlined,
    ThermostatOutlined,
    WorkOutline,
    Close,
    Refresh
} from "@mui/icons-material";
import { Agent, colorBase } from "../../modules/module_general";
import { useNavigate } from "react-router-dom";
import useAxiosPost from "../../hooks/useAxiosPost";
import { GetMenuIcon } from "../../Menu/MenuIcons";

const extractFirstImage = (html: string) => {
    if (!html) return null;
    const match = html.match(/<img[^>]+src\s*=\s*["']([^"']+)["']/i);
    return match ? match[1] : null;
};

const Dashboard = () => {
    const theme = useTheme();
    const navigate = useNavigate();
    const myAxiosPost = useAxiosPost();
    const [soldeConge, setSoldeConge] = useState<string>("...");
    const [notifications, setNotifications] = useState<any[]>([]);
    const [blogs, setBlogs] = useState<any[]>([]);


    const [weather, setWeather] = useState<{ temp: number, code: number, wind: number, humidity: number } | null>(null);

    const fetchData = async () => {
        // Fetch Dashboard Data
        const resp = await myAxiosPost("dashboard", {});
        if (resp && resp.data.result) {
            const { signatures, insights, blogs } = resp.data.data;
            const newNotifs: any[] = [];
            let idCounter = 1;

            if (blogs) setBlogs(blogs);

            // Process Signatures
            if (signatures && signatures.length > 0) {
                signatures.forEach((sig: any) => {
                    newNotifs.push({
                        id: idCounter++,
                        title: "Document à signer",
                        desc: `${sig.Intitule} - ${sig.Valeur_Index}`,
                        time: "",
                        type: "signature",
                        link: "/myspace/Parapheur/Parapheur"
                    });
                });
            }

            // Process Insights (Formations, Evaluations, Recrutement)
            if (insights && insights.length > 0) {
                insights.forEach((item: any) => {
                    let type = "info";
                    let link = "#";
                    let title = item.Evenement;

                    // Determine Type and Link
                    if (item.Evenement === "Formation") {
                        type = "formation";
                        // Assuming a route exists or keeping generic
                        link = "/myspace/Header_Formation/Formation";
                    } else if (item.Evenement === "Evaluation à effectuer" || item.Evenement === "Evaluation") {
                        type = "evaluation";
                        link = "/myspace/Evaluation_Liste/Consultation des évaluations";
                    } else if (item.Evenement === "Recrutement") {
                        type = "recrutement";
                        link = "/myspace/Recrutement_Demande_Liste/Demandes de recrutement";
                    }

                    newNotifs.push({
                        id: idCounter++,
                        title: title, // e.g. "Formation"
                        desc: item.Libelle || item.Description || "Nouvel événement",
                        time: item.Date ? formatDate(item.Date) : "",
                        type: type,
                        link: link
                    });
                });
            }

            setNotifications(newNotifs);
        }
    };

    const fetchWeather = async () => {
        try {
            // Casablanca coordinates
            const lat = 33.5731;
            const lon = -7.5898;
            const response = await fetch(`https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current_weather=true&hourly=relativehumidity_2m`);
            const data = await response.json();

            if (data.current_weather) {
                // Get approximate humidity from hourly data (closest hour)
                const hourIndex = new Date().getHours();
                const humidity = data.hourly?.relativehumidity_2m?.[hourIndex] || 45;

                setWeather({
                    temp: data.current_weather.temperature,
                    code: data.current_weather.weathercode,
                    wind: data.current_weather.windspeed,
                    humidity: humidity
                });
            }
        } catch (error) {
            console.error("Weather fetch error:", error);
        }
    };

    const handleRefresh = () => {
        setNotifications([]);
        setBlogs([]);
        setWeather(null);
        fetchData();
        fetchWeather();
    };

    useEffect(() => {
        fetchData();
        fetchWeather();
        setSoldeConge("18.5");
    }, []);

    const formatDate = (dateStr: string) => {
        if (!dateStr) return "";
        const d = new Date(dateStr);
        return d.toLocaleDateString('fr-FR');
    }

    const [shortcuts, setShortcuts] = useState<any[]>([]);

    useEffect(() => {
        const loadShortcuts = () => {
            const saved = localStorage.getItem("MYSPACE_SHORTCUTS");
            if (saved) {
                try {
                    setShortcuts(JSON.parse(saved));
                } catch (e) {
                    console.error("Error parsing shortcuts", e);
                }
            } else {
                setShortcuts(menuShortcuts); // Default fallbacks
            }
        };

        loadShortcuts();

        const handleShortcutsUpdate = () => loadShortcuts();
        window.addEventListener("portal-shortcuts-updated", handleShortcutsUpdate);

        return () => {
            window.removeEventListener("portal-shortcuts-updated", handleShortcutsUpdate);
        };
    }, []);

    const menuShortcuts = [
        {
            label: "Poser un congé",
            img: "BeachAccess",
            link: "/myspace/RH_Demande_Conge_Liste/Demandes de congé",
            color: "#e3f2fd",
        },
        {
            label: "Mes Bulletins",
            img: "DescriptionOutlined", // Note: Need to handle generic icons if string doesn't match
            link: "/myspace/RH_Bulletin_Liste/Edition de bulletins de paie",
            color: "#e8f5e9",
        },
        {
            label: "Déclarer un accident",
            img: "MedicalServices",
            link: "/myspace/RH_Declaration_AT_Liste/Accidents de travail",
            color: "#fff3e0",
        },
        {
            label: "Demande de Prêt",
            img: "AttachMoney",
            link: "/myspace/RH_Demande_Pret_Liste/Demandes de prêts",
            color: "#f3e5f5",
        },
    ].map(s => ({ ...s, name_ecran: s.img })); // Map img to name_ecran for GetMenuIcon

    const getIcon = (type: string) => {
        switch (type) {
            case "signature": return <CreateOutlined />;
            case "evaluation": return <RateReviewOutlined />;
            case "formation": return <SchoolOutlined />;
            case "recrutement": return <WorkOutline />;
            default: return <NotificationsOutlined />;
        }
    }

    const getColor = (type: string, index: number) => {
        const isDark = theme.palette.mode === 'dark';
        switch (type) {
            case "signature": return {
                bg: isDark ? "rgba(255, 152, 0, 0.2)" : "#ffeebb",
                color: isDark ? "#ffb74d" : "#f57c00"
            };
            case "evaluation": return {
                bg: isDark ? "rgba(76, 175, 80, 0.2)" : "#e8f5e9",
                color: isDark ? "#81c784" : "#2e7d32"
            };
            case "formation": return {
                bg: isDark ? "rgba(33, 150, 243, 0.2)" : "#e3f2fd",
                color: isDark ? "#64b5f6" : "#1976d2"
            };
            case "recrutement": return {
                bg: isDark ? "rgba(156, 39, 176, 0.2)" : "#f3e5f5",
                color: isDark ? "#ba68c8" : "#8e24aa"
            };
            default: return {
                bg: isDark ? "rgba(255, 255, 255, 0.1)" : "#f5f5f5",
                color: isDark ? "#bdbdbd" : "#757575"
            };
        }
    }

    const getWeatherDesc = (code: number) => {
        if (code === 0) return "Ciel dégagé";
        if (code >= 1 && code <= 3) return "Nuageux";
        if (code >= 45 && code <= 48) return "Brouillard";
        if (code >= 51 && code <= 67) return "Pluvieux";
        if (code >= 71) return "Neige";
        if (code >= 95) return "Orage";
        return "Tendance variable";
    }

    return (
        <Box sx={{ p: 3, backgroundColor: "background.default", minHeight: "100vh" }}>
            {/* Welcome Header */}
            <Box sx={{ mb: 4, display: "flex", alignItems: "center", justifyContent: "space-between" }}>
                <Box>
                    <Typography variant="h4" fontWeight="bold" sx={{ color: "text.primary", display: "flex", alignItems: "center", gap: 1 }}>
                        Bonjour, {Agent.Nom?.split(" ")[0]} <WavingHand sx={{ color: "#ffc107" }} />
                    </Typography>
                    <Typography variant="body1" color="text.secondary">
                        Bon retour sur votre espace collaborateur. Voici ce qui se passe aujourd'hui.
                    </Typography>
                </Box>
                <Stack direction="row" spacing={2} alignItems="center">
                    <Box sx={{ display: { xs: "none", md: "block" } }}>
                        <Typography variant="h6" color="text.secondary">
                            {new Date().toLocaleDateString("fr-FR", { weekday: "long", day: "numeric", month: "long" })}
                        </Typography>
                    </Box>
                    <IconButton onClick={handleRefresh} color="primary" sx={{ bgcolor: 'background.paper', boxShadow: 1 }}>
                        <Refresh />
                    </IconButton>
                </Stack>
            </Box>

            <Grid container spacing={3}>
                {/* Left Column: Profile & Stats */}
                <Grid item xs={12} md={4}>
                    {/* ... Profile Card & Leave ... */}
                    {/* Assuming these are unchanged, skipping for brevity in replacement if scope allows, 
                        but effectively we are replacing the render part below for shortcuts */}
                    <Card sx={{ mb: 3, borderRadius: 4, boxShadow: theme.shadows[3] }}>
                        <CardContent sx={{ textAlign: "center", py: 4 }}>
                            <Avatar
                                sx={{
                                    width: 80,
                                    height: 80,
                                    bgcolor: colorBase.colorBase01,
                                    fontSize: 32,
                                    mx: "auto",
                                    mb: 2,
                                    border: `4px solid ${colorBase.colorBase04}`,
                                }}
                            >
                                {Agent.Nom?.charAt(0)}
                            </Avatar>
                            <Typography variant="h6" fontWeight="bold" color="text.primary">
                                {Agent.Nom}
                            </Typography>
                            <Typography variant="body2" color="text.secondary" sx={{ mb: 2 }}>
                                {Agent.Typ_Role === "Admin" ? "Administrateur" : "Collaborateur"} | {Agent.Matricule}
                            </Typography>
                            <Button
                                variant="outlined"
                                startIcon={<AccountBalanceWalletOutlined />}
                                onClick={() => navigate("/myspace/RH_Agent/Fiche agent")}
                                sx={{ borderRadius: 20, textTransform: "none" }}
                            >
                                Voir mon profil
                            </Button>
                        </CardContent>
                    </Card>

                    <Card sx={{ borderRadius: 4, boxShadow: theme.shadows[3], background: `linear-gradient(135deg, ${colorBase.colorBase01} 0%, ${theme.palette.mode === 'dark' ? '#0d1b2a' : '#1a3e72'} 100%)`, color: "white" }}>
                        <CardContent>
                            <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "flex-start" }}>
                                <Box>
                                    <Typography variant="body2" sx={{ opacity: 0.8, mb: 1 }}>
                                        Solde de congés
                                    </Typography>
                                    <Typography variant="h3" fontWeight="bold">
                                        {soldeConge} <Typography component="span" variant="h6">Jours</Typography>
                                    </Typography>
                                </Box>
                                <CalendarMonth sx={{ fontSize: 40, opacity: 0.8 }} />
                            </Box>
                            <Button
                                sx={{ mt: 2, color: "white", borderColor: "rgba(255,255,255,0.3)", borderRadius: 20 }}
                                variant="outlined"
                                size="small"
                                onClick={() => navigate("/myspace/RH_Demande_Conge_Liste/Demandes de congé")}
                            >
                                Poser un congé
                            </Button>
                        </CardContent>
                    </Card>

                    {weather ? (
                        <Paper sx={{ mt: 3, p: 3, borderRadius: 4, background: "linear-gradient(to right, #FF9800, #FFC107)", color: "white", boxShadow: theme.shadows[3] }}>
                            <Stack direction="row" justifyContent="space-between" alignItems="center">
                                <Box>
                                    <Stack direction="row" alignItems="center" spacing={1}>
                                        <WbSunnyOutlined sx={{ fontSize: 40 }} />
                                        <Typography variant="h3" fontWeight="bold">{weather.temp}°C</Typography>
                                    </Stack>
                                    <Typography variant="subtitle1" fontWeight="bold">{getWeatherDesc(weather.code)}</Typography>
                                    <Typography variant="body2" sx={{ opacity: 0.9 }}>Casablanca, Maroc</Typography>
                                </Box>
                                <Box sx={{ textAlign: "right" }}>
                                    <ThermostatOutlined sx={{ fontSize: 32, opacity: 0.8, mb: 1 }} />
                                    <Typography variant="caption" display="block">Humidité: {weather.humidity}%</Typography>
                                    <Typography variant="caption" display="block">Vent: {weather.wind} km/h</Typography>
                                </Box>
                            </Stack>
                        </Paper>
                    ) : (
                        <Paper sx={{ mt: 3, p: 3, borderRadius: 4, bgcolor: "background.paper", boxShadow: theme.shadows[3] }}>
                            <Typography>Chargement météo...</Typography>
                        </Paper>
                    )}
                </Grid>

                {/* Right Column: Actions & Notifications */}
                <Grid item xs={12} md={8}>
                    {/* Quick Actions Grid */}
                    <Typography variant="h6" fontWeight="bold" sx={{ mb: 2, color: "text.primary" }}>
                        Accès Rapide
                    </Typography>
                    <Grid container spacing={2} sx={{ mb: 4 }}>
                        {shortcuts.map((item, index) => (
                            <Grid item xs={6} sm={3} key={index}>
                                <Paper
                                    elevation={0}
                                    sx={{
                                        p: 2,
                                        textAlign: "center",
                                        borderRadius: 3,
                                        bgcolor: "background.paper",
                                        cursor: "pointer",
                                        transition: "transform 0.2s, box-shadow 0.2s",
                                        border: 1,
                                        borderColor: "divider",
                                        height: "100%", // Force equal height
                                        display: "flex",
                                        flexDirection: "column",
                                        justifyContent: "center",
                                        alignItems: "center",
                                        "&:hover": {
                                            transform: "translateY(-4px)",
                                            boxShadow: theme.shadows[4],
                                        },
                                    }}
                                    onClick={() => navigate(item.link || item.name_ecran)} // Fallback if link not pre-constructed
                                >
                                    <Box sx={{ mb: 1 }}>
                                        <GetMenuIcon name_ecran={item.img || item.name_ecran || ""} sx={{ fontSize: 40, color: colorBase.colorBase01 }} />
                                    </Box>
                                    <Typography variant="subtitle2" fontWeight="600" color="text.secondary">
                                        {item.label || item.text_ecran}
                                    </Typography>
                                </Paper>
                            </Grid>
                        ))}
                    </Grid>

                    {/* Notifications / To-Do */}
                    <Typography variant="h6" fontWeight="bold" sx={{ mb: 2, color: "text.primary" }}>
                        À faire & Notifications
                    </Typography>
                    <Card sx={{ borderRadius: 4, boxShadow: theme.shadows[3] }}>
                        <CardContent sx={{ p: 0 }}>
                            {notifications.length === 0 ? (
                                <Box sx={{ p: 3, textAlign: "center" }}>
                                    <Typography color="text.secondary">Chargement...</Typography>
                                </Box>
                            ) : (
                                notifications.map((notif, index) => {
                                    const style = getColor(notif.type, index);
                                    return (
                                        <Box key={notif.id} onClick={() => notif.link && notif.link !== "#" && navigate(notif.link)}>
                                            <Box
                                                sx={{
                                                    p: 2,
                                                    display: "flex",
                                                    alignItems: "center",
                                                    "&:hover": { bgcolor: "action.hover", cursor: "pointer" },
                                                }}
                                            >
                                                <Avatar sx={{ bgcolor: style.bg, color: style.color, mr: 2 }}>
                                                    {getIcon(notif.type)}
                                                </Avatar>
                                                <Box sx={{ flexGrow: 1 }}>
                                                    <Typography variant="subtitle2" fontWeight="bold" color="text.primary">
                                                        {notif.title}
                                                    </Typography>
                                                    <Typography variant="body2" color="text.secondary">
                                                        {notif.desc}
                                                    </Typography>
                                                </Box>
                                                <Typography variant="caption" color="text.secondary" fontWeight="bold">
                                                    {notif.time}
                                                </Typography>
                                                {notif.link && notif.link !== "#" &&
                                                    <IconButton size="small">
                                                        <ArrowForward fontSize="small" />
                                                    </IconButton>
                                                }
                                            </Box>
                                            {index < notifications.length - 1 && <Divider />}
                                        </Box>
                                    );
                                })
                            )}
                        </CardContent>
                    </Card>
                </Grid>
            </Grid>

            {/* Blogs / News Section */}
            <Box sx={{ mt: 4 }}>
                <Typography variant="h6" fontWeight="bold" sx={{ mb: 2, color: "text.primary" }}>
                    Actualités RH
                </Typography>
                <Grid container spacing={3}>
                    {blogs.length === 0 ? (
                        <Grid item xs={12}>
                            <Typography variant="body2" color="text.secondary">Aucune actualité pour le moment.</Typography>
                        </Grid>
                    ) : (
                        blogs.map((blog: any) => {
                            const imageUrl = extractFirstImage(blog.Contenus);
                            return (
                                <Grid item xs={12} sm={6} md={4} key={blog.Num_Blog}>
                                    {imageUrl ? (
                                        <Card sx={{
                                            borderRadius: 3,
                                            height: '100%',
                                            display: 'flex',
                                            flexDirection: 'column',
                                            cursor: "pointer",
                                            transition: "transform 0.2s",
                                            boxShadow: theme.shadows[3],
                                            "&:hover": { transform: "translateY(-4px)", boxShadow: theme.shadows[6] }
                                        }}
                                            onClick={() => navigate(`/myspace/Communication_Blog/Blog/${blog.Num_Blog}`)}
                                        >
                                            <CardMedia
                                                component="img"
                                                height="140"
                                                image={imageUrl}
                                                alt={blog.Titre_Blog}
                                            />
                                            <CardContent sx={{ flexGrow: 1, display: 'flex', flexDirection: 'column', justifyContent: 'space-between' }}>
                                                <Typography variant="h6" fontWeight="bold" sx={{ mb: 1, fontSize: '1rem', lineHeight: 1.3 }}>
                                                    {blog.Titre_Blog}
                                                </Typography>
                                                <Stack direction="row" justifyContent="space-between" alignItems="center" sx={{ mt: 'auto' }}>
                                                    <Typography variant="caption" color="text.secondary">{formatDate(blog.Dat_Crea)}</Typography>
                                                    <Chip label={blog.Categorie || "Info"} size="small" color="primary" variant="outlined" />
                                                </Stack>
                                            </CardContent>
                                        </Card>
                                    ) : (
                                        <Paper
                                            sx={{
                                                p: 3,
                                                height: '100%',
                                                borderRadius: 3,
                                                background: theme.palette.mode === 'dark' ? "linear-gradient(to right, #1a237e, #283593)" : "linear-gradient(to right, #2196f3, #21cbf3)",
                                                color: "white",
                                                cursor: "pointer",
                                                transition: "transform 0.2s",
                                                "&:hover": { transform: "translateY(-4px)" },
                                                display: 'flex',
                                                flexDirection: 'column',
                                                justifyContent: 'center'
                                            }}
                                            onClick={() => navigate(`/myspace/Communication_Blog/Blog/${blog.Num_Blog}`)}
                                        >
                                            <Stack direction="row" spacing={2} alignItems="center">
                                                <SchoolOutlined fontSize="large" color="inherit" />
                                                <Box>
                                                    <Typography variant="h6" fontWeight="bold" sx={{ fontSize: '1rem', lineHeight: 1.3 }}>{blog.Titre_Blog}</Typography>
                                                    <Typography variant="caption" sx={{ opacity: 0.8 }}>{formatDate(blog.Dat_Crea)}</Typography>
                                                    <Chip label={blog.Categorie || "Info"} size="small" sx={{ ml: 1, bgcolor: "rgba(255,255,255,0.2)", color: "white" }} />
                                                </Box>
                                            </Stack>
                                        </Paper>
                                    )}
                                </Grid>
                            );
                        })
                    )}
                </Grid>
            </Box>

        </Box>

    );
};

export default Dashboard;
