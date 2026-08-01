import type { WidgetDefinition, KpiData, ChartData, TableData } from "./types";

export const MOCK_AVAILABLE_WIDGETS: WidgetDefinition[] = [
  // KPIs
  {
    id: "kpi-effectif",
    title: "Effectif total",
    type: "kpi",
    sourceType: "backend",
    icon: "Groups",
    color: "#2e7d32",
    defaultSpan: 3,
    description: "Nombre total de collaborateurs actifs",
    dataConfig: { objectName: "agents", field: "id", aggregation: "count" },
  },
  {
    id: "kpi-absenteisme",
    title: "Taux d'absentéisme",
    type: "kpi",
    sourceType: "backend",
    icon: "TrendingUp",
    color: "#f57c00",
    defaultSpan: 3,
    description: "Taux d'absentéisme du mois en cours",
    dataConfig: { objectName: "absences", field: "id", aggregation: "count" },
  },
  {
    id: "kpi-conges-attente",
    title: "Congés en attente",
    type: "kpi",
    sourceType: "backend",
    icon: "PendingActions",
    color: "#1976d2",
    defaultSpan: 3,
    description: "Nombre de demandes de congé en attente de validation",
    dataConfig: { objectName: "conges", field: "id", aggregation: "count", filters: { statut: "En attente" } },
  },
  {
    id: "kpi-prets-attente",
    title: "Demandes de prêt",
    type: "kpi",
    sourceType: "backend",
    icon: "AccountBalance",
    color: "#8e24aa",
    defaultSpan: 3,
    description: "Nombre de demandes de prêt en attente",
    dataConfig: { objectName: "prets", field: "id", aggregation: "count", filters: { statut: "En attente" } },
  },
  // Charts
  {
    id: "chart-repartition-dept",
    title: "Répartition par département",
    type: "chart",
    chartType: "pie",
    sourceType: "backend",
    icon: "PieChart",
    color: "#1976d2",
    defaultSpan: 6,
    description: "Répartition des effectifs par département",
    dataConfig: { objectName: "agents", field: "id", aggregation: "count", groupBy: "departement" },
  },
  {
    id: "chart-evolution-absences",
    title: "Évolution des absences",
    type: "chart",
    chartType: "line",
    sourceType: "backend",
    icon: "ShowChart",
    color: "#f57c00",
    defaultSpan: 6,
    description: "Évolution du nombre d'absences par mois",
    dataConfig: { objectName: "absences", field: "id", aggregation: "count", groupBy: "mois" },
  },
  {
    id: "chart-top-rubriques",
    title: "Top 5 rubriques de paie",
    type: "chart",
    chartType: "bar",
    sourceType: "backend",
    icon: "BarChart",
    color: "#2e7d32",
    defaultSpan: 6,
    description: "Les 5 rubriques de paie les plus élevées",
    dataConfig: { objectName: "bulletins", field: "montant", aggregation: "sum", groupBy: "rubrique" },
  },
  {
    id: "chart-effectif-mois",
    title: "Effectif par mois",
    type: "chart",
    chartType: "area",
    sourceType: "backend",
    icon: "Timeline",
    color: "#8e24aa",
    defaultSpan: 6,
    description: "Évolution de l'effectif sur les 12 derniers mois",
    dataConfig: { objectName: "agents", field: "id", aggregation: "count", groupBy: "mois" },
  },
  // Tables
  {
    id: "table-conges-recents",
    title: "Dernières demandes de congé",
    type: "table",
    sourceType: "backend",
    icon: "TableChart",
    color: "#1976d2",
    defaultSpan: 12,
    description: "Tableau des 5 dernières demandes de congé",
    dataConfig: { objectName: "conges", field: "id", aggregation: "count" },
  },
  {
    id: "table-agents-recents",
    title: "Nouveaux arrivants",
    type: "table",
    sourceType: "backend",
    icon: "TableChart",
    color: "#2e7d32",
    defaultSpan: 6,
    description: "Tableau des derniers agents recrutés",
    dataConfig: { objectName: "agents", field: "id", aggregation: "count" },
  },
  // Lists
  {
    id: "list-blogs",
    title: "Actualités RH",
    type: "list",
    sourceType: "standard",
    standardId: "blogs",
    icon: "Newspaper",
    color: "#1976d2",
    defaultSpan: 12,
    description: "Liste des actualités RH",
  },
  {
    id: "list-notifications",
    title: "À faire & Notifications",
    type: "list",
    sourceType: "standard",
    standardId: "notifications",
    icon: "NotificationsOutlined",
    color: "#8e24aa",
    defaultSpan: 6,
    description: "Liste des notifications et tâches",
  },
];

export const MOCK_KPI_DATA: Record<string, KpiData> = {
  kpi_effectif: { value: 125, label: "collaborateurs", trend: 3.2 },
  kpi_absenteisme: { value: "4.2 %", label: "ce mois", trend: -0.5 },
  kpi_conges_attente: { value: 8, label: "demandes", trend: 2 },
  kpi_prets_attente: { value: 3, label: "demandes", trend: 0 },
};

export const MOCK_CHART_DATA: Record<string, ChartData> = {
  chart_repartition_dept: {
    labels: ["RH", "Commercial", "Production", "Finance", "IT"],
    series: [{ label: "Effectifs", data: [25, 35, 40, 15, 10] }],
  },
  chart_evolution_absences: {
    labels: ["Jan", "Fév", "Mar", "Avr", "Mai", "Juin"],
    series: [{ label: "Absences", data: [12, 18, 15, 22, 14, 19] }],
  },
  chart_top_rubriques: {
    labels: ["Salaire net", "CNSS", "AMO", "IGR", "Indemnités"],
    series: [{ label: "Montant", data: [450000, 65000, 28000, 52000, 120000] }],
  },
  chart_effectif_mois: {
    labels: ["Juil", "Août", "Sep", "Oct", "Nov", "Déc", "Jan", "Fév", "Mar", "Avr", "Mai", "Juin"],
    series: [{ label: "Effectif", data: [112, 115, 118, 120, 121, 122, 123, 124, 125, 126, 125, 125] }],
  },
};

export const MOCK_TABLE_DATA: Record<string, TableData> = {
  table_conges_recents: {
    columns: [
      { field: "agent", header: "Agent" },
      { field: "type", header: "Type" },
      { field: "debut", header: "Début" },
      { field: "fin", header: "Fin" },
      { field: "statut", header: "Statut" },
    ],
    rows: [
      { agent: "AIT OURAJDAL MOUNIR", type: "Congé payé", debut: "15/07/2026", fin: "22/07/2026", statut: "En attente" },
      { agent: "BENALI SAMIRA", type: "RTT", debut: "20/07/2026", fin: "21/07/2026", statut: "Validé" },
      { agent: "CHRAIBI KARIM", type: "Congé sans solde", debut: "01/08/2026", fin: "10/08/2026", statut: "En attente" },
      { agent: "DAHBI FATIMA", type: "Congé payé", debut: "10/08/2026", fin: "24/08/2026", statut: "Validé" },
      { agent: "EL FASSI YOUNES", type: "RTT", debut: "05/09/2026", fin: "06/09/2026", statut: "En attente" },
    ],
  },
  table_agents_recents: {
    columns: [
      { field: "agent", header: "Agent" },
      { field: "departement", header: "Département" },
      { field: "dateEmbauche", header: "Date d'embauche" },
    ],
    rows: [
      { agent: "AIT OURAJDAL MOUNIR", departement: "IT", dateEmbauche: "15/03/2024" },
      { agent: "BENALI SAMIRA", departement: "RH", dateEmbauche: "02/01/2024" },
      { agent: "CHRAIBI KARIM", departement: "Commercial", dateEmbauche: "20/11/2023" },
    ],
  },
  // Variantes pour démontrer 1, 2, 3 colonnes
  table_one_col: {
    columns: [{ field: "agent", header: "Agent" }],
    rows: [
      { agent: "AIT OURAJDAL MOUNIR" },
      { agent: "BENALI SAMIRA" },
      { agent: "CHRAIBI KARIM" },
    ],
  },
  table_two_cols: {
    columns: [
      { field: "agent", header: "Agent" },
      { field: "statut", header: "Statut" },
    ],
    rows: [
      { agent: "AIT OURAJDAL MOUNIR", statut: "Actif" },
      { agent: "BENALI SAMIRA", statut: "Actif" },
      { agent: "CHRAIBI KARIM", statut: "En congé" },
    ],
  },
  table_three_cols: {
    columns: [
      { field: "agent", header: "Agent" },
      { field: "departement", header: "Département" },
      { field: "statut", header: "Statut" },
    ],
    rows: [
      { agent: "AIT OURAJDAL MOUNIR", departement: "IT", statut: "Actif" },
      { agent: "BENALI SAMIRA", departement: "RH", statut: "Actif" },
      { agent: "CHRAIBI KARIM", departement: "Commercial", statut: "En congé" },
    ],
  },
};
