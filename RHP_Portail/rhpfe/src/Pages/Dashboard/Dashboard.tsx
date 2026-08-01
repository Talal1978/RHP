import React, { useEffect, useMemo, useState } from "react";
import { Box, Grid, Paper, Stack, Typography } from "@mui/material";
import {
  NotificationsOutlined,
  WbSunnyOutlined,
  RateReviewOutlined,
  SchoolOutlined,
  WidgetsOutlined,
  WorkOutline,
  CreateOutlined,
} from "@mui/icons-material";
import { useDashboardWidgets } from "./widgets/useDashboardWidgets";
import { WidgetBuilder } from "./widgets/WidgetBuilder";
import { WidgetRenderer } from "./widgets/WidgetRenderer";
import { Agent, colorBase } from "../../modules/module_general";
import { useNavigate } from "react-router-dom";
import useAxiosPost from "../../hooks/useAxiosPost";
import {
  DASHBOARD_SECTION_DEFINITION_MAP,
  DASHBOARD_SECTIONS_UPDATED_EVENT,
  loadDashboardSectionPreferences,
  type DashboardSectionId,
  type DashboardSectionPreference,
} from "./dashboardSections";
import {
  DASHBOARD_SHORTCUTS_UPDATED_EVENT,
  loadDashboardShortcuts,
  type DashboardShortcutItem,
} from "./dashboardShortcuts";
import { dashboardSectionRegistry } from "./dashboardSectionRegistry";
import type {
  DashboardNotification,
  DashboardWeather,
  DashboardNotificationColorGetter,
  DashboardNotificationIconGetter,
} from "./sections/SectionTypes";

const TOP_SECTION_IDS: DashboardSectionId[] = ["welcome", "profile", "leaveBalance", "weather"];

const Dashboard = () => {
  const navigate = useNavigate();
  const myAxiosPost = useAxiosPost();
  const [soldeConge, setSoldeConge] = useState<string>("...");
  const [notifications, setNotifications] = useState<DashboardNotification[]>([]);
  const [blogs, setBlogs] = useState<any[]>([]);
  const [shortcuts, setShortcuts] = useState<DashboardShortcutItem[]>(loadDashboardShortcuts);
  const [sectionPreferences, setSectionPreferences] = useState<DashboardSectionPreference[]>(
    loadDashboardSectionPreferences
  );
  const [weather, setWeather] = useState<DashboardWeather | null>(null);
  const [configOpen, setConfigOpen] = useState(false);
  const { availableWidgets, userWidgets, saveWidgets, isLoaded } = useDashboardWidgets();

  const formatDate = (dateStr: string) => {
    if (!dateStr) return "";
    const d = new Date(dateStr);
    return d.toLocaleDateString("fr-FR");
  };

  const fetchData = async () => {
    const resp = await myAxiosPost("dashboard", {});
    if (resp && resp.data.result) {
      const { signatures, insights, blogs, solde } = resp.data.data;
      const newNotifs: DashboardNotification[] = [];
      let idCounter = 1;

      if (blogs) setBlogs(blogs);
      if (solde !== undefined) setSoldeConge(solde.toString());

      if (signatures && signatures.length > 0) {
        signatures.forEach((sig: any) => {
          newNotifs.push({
            id: idCounter++,
            title: "Document à signer",
            desc: `${sig.Intitule} - ${sig.Valeur_Index}`,
            time: "",
            type: "signature",
            link: "/myspace/Parapheur/Parapheur",
          });
        });
      }

      if (insights && insights.length > 0) {
        insights.forEach((item: any) => {
          let type = "info";
          let link = "#";
          let title = item.Evenement;
          let state: unknown = null;

          if (item.Evenement === "Formation") {
            type = "formation";
            link = "/myspace/Formation_Evaluation/Evaluation de Formation";
            state = {
              cod_evaluation: item.Code,
              lib_evaluation: item.Libelle,
              evaluateur: Agent.Matricule,
              nom_evaluateur: Agent.Nom,
              evalue: item.Code,
              nom_evalue: item.Libelle,
              cod_survey: item.Cod_Survey,
              cod_reply: item.Cod_Reply || -1,
              typ_survey: "F",
              statut: item.Statut_Evaluation || "",
            };
          } else if (
            item.Evenement === "Evaluation à effectuer" ||
            item.Evenement === "Evaluation"
          ) {
            type = "evaluation";
            link = "/myspace/Evaluation_Liste/Consultation des évaluations";
          } else if (item.Evenement === "Recrutement") {
            type = "recrutement";
            link = "/myspace/Recrutement_Demande_Liste/Demandes de recrutement";
          }

          newNotifs.push({
            id: idCounter++,
            title,
            desc: item.Libelle || item.Description || "Nouvel événement",
            time: item.Date ? formatDate(item.Date) : "",
            type,
            link,
            state,
          });
        });
      }

      setNotifications(newNotifs);
    }
  };

  const fetchWeather = async () => {
    try {
      const lat = 33.5731;
      const lon = -7.5898;
      const response = await fetch(
        `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current_weather=true&hourly=relativehumidity_2m`
      );
      const data = await response.json();

      if (data.current_weather) {
        const hourIndex = new Date().getHours();
        const humidity = data.hourly?.relativehumidity_2m?.[hourIndex] || 45;

        setWeather({
          temp: data.current_weather.temperature,
          code: data.current_weather.weathercode,
          wind: data.current_weather.windspeed,
          humidity,
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
  }, []);

  useEffect(() => {
    const loadShortcuts = () => setShortcuts(loadDashboardShortcuts());
    const loadSections = () => setSectionPreferences(loadDashboardSectionPreferences());

    window.addEventListener(DASHBOARD_SHORTCUTS_UPDATED_EVENT, loadShortcuts);
    window.addEventListener(DASHBOARD_SECTIONS_UPDATED_EVENT, loadSections);

    return () => {
      window.removeEventListener(DASHBOARD_SHORTCUTS_UPDATED_EVENT, loadShortcuts);
      window.removeEventListener(DASHBOARD_SECTIONS_UPDATED_EVENT, loadSections);
    };
  }, []);

  const getIcon: DashboardNotificationIconGetter = (type: string) => {
    switch (type) {
      case "signature":
        return <CreateOutlined />;
      case "evaluation":
        return <RateReviewOutlined />;
      case "formation":
        return <SchoolOutlined />;
      case "recrutement":
        return <WorkOutline />;
      default:
        return <NotificationsOutlined />;
    }
  };

  const getColor: DashboardNotificationColorGetter = (type: string) => {
    switch (type) {
      case "signature":
        return { bg: "#ffeebb", color: "#f57c00" };
      case "evaluation":
        return { bg: "#e8f5e9", color: "#2e7d32" };
      case "formation":
        return { bg: "#e3f2fd", color: "#1976d2" };
      case "recrutement":
        return { bg: "#f3e5f5", color: "#8e24aa" };
      default:
        return { bg: "#f5f5f5", color: "#757575" };
    }
  };

  const getWeatherDesc = (code: number) => {
    if (code === 0) return "Ciel dégagé";
    if (code >= 1 && code <= 3) return "Nuageux";
    if (code >= 45 && code <= 48) return "Brouillard";
    if (code >= 51 && code <= 67) return "Pluvieux";
    if (code >= 71) return "Neige";
    if (code >= 95) return "Orage";
    return "Tendance variable";
  };

  const navigateToSection = (path: string, options?: { state?: unknown }) => {
    navigate(path, options);
  };

  const sectionPropsMap = useMemo<Record<DashboardSectionId, Record<string, unknown>>>(
    () => ({
      welcome: {
        firstName: Agent.Nom?.split(" ")[0] || "",
        onRefresh: handleRefresh,
        onOpenConfig: () => setConfigOpen(true),
      },
      profile: {
        fullName: Agent.Nom,
        matricule: Agent.Matricule,
        roleLabel: Agent.Typ_Role === "Admin" ? "Administrateur" : "Collaborateur",
        onOpenProfile: () => navigateToSection("/myspace/RH_Agent/Fiche agent"),
      },
      leaveBalance: {
        soldeConge,
        onOpenLeave: () => navigateToSection("/myspace/RH_Demande_Conge_Liste/Demandes de congé"),
      },
      weather: {
        weather,
        weatherDescription: weather ? getWeatherDesc(weather.code) : "",
      },
      quickActions: {
        shortcuts,
        onNavigate: navigateToSection,
      },
      notifications: {
        notifications,
        getColor,
        getIcon,
        onNavigate: navigateToSection,
      },
      news: {
        blogs,
        formatDate,
        onNavigate: navigateToSection,
      },
    }),
    [blogs, notifications, shortcuts, soldeConge, weather]
  );

  const visibleSections = sectionPreferences.filter((section) => section.visible);

  const hasWidgets = isLoaded && userWidgets.length > 0;
  const lastTopSectionIndex = visibleSections.reduce(
    (lastIndex, section, index) => (TOP_SECTION_IDS.includes(section.id) ? index : lastIndex),
    -1
  );
  const widgetsInsertIndex = hasWidgets ? lastTopSectionIndex + 1 : visibleSections.length;
  const topSections = visibleSections.slice(0, widgetsInsertIndex);
  const bottomSections = visibleSections.slice(widgetsInsertIndex);

  const renderSection = (section: DashboardSectionPreference) => {
    const definition = DASHBOARD_SECTION_DEFINITION_MAP[section.id];
    const SectionComponent = dashboardSectionRegistry[section.id];

    return (
      <Grid item key={section.id} xs={12} md={definition.desktopSpan} sx={{ mb: { xs: 1, sm: 0 }, px: { md: 0.5 } }}>
        <React.Suspense
          fallback={
            <Paper sx={{ p: 3, borderRadius: 2, border: "1px solid", borderColor: "divider", boxShadow: "none", bgcolor: "background.paper" }}>
              <Typography color="text.secondary">Chargement...</Typography>
            </Paper>
          }
        >
          <SectionComponent {...sectionPropsMap[section.id]} />
        </React.Suspense>
      </Grid>
    );
  };

  return (
    <Box
      sx={{
        width: "100%",
        maxWidth: 1500,
        mx: "auto",
        pt: { xs: 1, md: 1.5 },
        pb: { xs: 5, sm: 6 },
        px: { xs: 1, sm: 3, md: 4 },
        backgroundColor: "transparent",
      }}
    >
      <Grid container spacing={{ xs: 1, sm: 3, md: 0 }} rowSpacing={{ md: 4 }} justifyContent="center" alignItems="stretch">
        {topSections.map(renderSection)}
      </Grid>

      {hasWidgets && (
        <>
          <Stack
            direction="row"
            alignItems="center"
            spacing={1}
            sx={{ mt: 4, mb: 2, justifyContent: { xs: "center", sm: "flex-start" } }}
          >
            <WidgetsOutlined sx={{ fontSize: 22, color: colorBase.colorBase01 }} />
            <Typography variant="h6" fontWeight="bold" sx={{ color: colorBase.colorBase01 }}>
              Mes widgets
            </Typography>
          </Stack>
          <Grid container spacing={{ xs: 1, sm: 3, md: 0 }} rowSpacing={{ md: 4 }} justifyContent="center" alignItems="stretch" sx={{ mb: { xs: 1, md: 2 } }}>
            {userWidgets.map((uw) => (
              <Grid item key={uw.instanceId} xs={12} md={uw.span} sx={{ mb: { xs: 1, sm: 0 }, px: { md: 0.5 } }}>
                <WidgetRenderer
                  definition={{
                    id: uw.widgetId,
                    title: uw.title,
                    type: uw.type,
                    chartType: uw.chartType,
                    sourceType: uw.sourceType,
                    standardId: uw.standardId,
                    icon: uw.icon,
                    color: uw.color,
                    defaultSpan: uw.span,
                    dataConfig: uw.dataConfig,
                  }}
                />
              </Grid>
            ))}
          </Grid>
        </>
      )}

      {bottomSections.length > 0 && (
        <Grid container spacing={{ xs: 1, sm: 3, md: 0 }} rowSpacing={{ md: 4 }} justifyContent="center" alignItems="stretch">
          {bottomSections.map(renderSection)}
        </Grid>
      )}

      <WidgetBuilder
        open={configOpen}
        onClose={() => setConfigOpen(false)}
        availableWidgets={availableWidgets}
        userWidgets={userWidgets}
        onSave={(widgets) => {
          saveWidgets(widgets);
          setConfigOpen(false);
        }}
      />
    </Box>
  );
};

export default Dashboard;
