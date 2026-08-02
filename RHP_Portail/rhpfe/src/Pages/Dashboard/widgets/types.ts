export type WidgetType = "kpi" | "chart" | "table" | "list";

export type ChartType = "bar" | "line" | "pie" | "area";

export type WidgetSourceType = "standard" | "backend" | "query";

export type StandardWidgetId =
  | "blogs"
  | "weather"
  | "quickActions"
  | "notifications"
  | "recentAccess"
  | "profile"
  | "leaveBalance";

export interface WidgetDataConfig {
  objectName?: string;
  field?: string;
  aggregation?: "count" | "sum" | "avg" | "min" | "max" | "value";
  groupBy?: string;
  filters?: Record<string, string | number | boolean>;
  apiEndpoint?: string;
  hidden?: boolean;
}

export interface WidgetDefinition {
  id: string;
  title: string;
  type: WidgetType;
  chartType?: ChartType;
  sourceType: WidgetSourceType;
  standardId?: StandardWidgetId;
  icon: string;
  color: string;
  defaultSpan: number;
  description?: string;
  dataConfig?: WidgetDataConfig;
}

export interface UserDashboardWidget {
  instanceId: string;
  widgetId: string;
  title: string;
  type: WidgetType;
  chartType?: ChartType;
  icon: string;
  color: string;
  span: number;
  position: number;
  sourceType: WidgetSourceType;
  standardId?: StandardWidgetId;
  dataConfig?: WidgetDataConfig;
  sectionId?: string | null;
}

export interface WidgetSection {
  id: string;
  title: string;
  position: number;
}

export interface KpiData {
  value: number | string;
  label: string;
  trend?: number;
}

export interface ChartDataPoint {
  label: string;
  value: number;
  series?: string;
}

export interface ChartData {
  labels: string[];
  series: { label: string; data: number[] }[];
}

export interface TableColumn {
  field: string;
  header: string;
}

export interface TableData {
  columns: TableColumn[];
  rows: Record<string, unknown>[];
}

export const STANDARD_WIDGET_OPTIONS = [
  { id: "blogs", label: "Actualités RH", icon: "Newspaper", color: "#1976d2" },
  { id: "weather", label: "Météo", icon: "CloudOutlined", color: "#f57c00" },
  { id: "quickActions", label: "Accès Rapide", icon: "Apps", color: "#2e7d32" },
  { id: "notifications", label: "À faire & Notifications", icon: "NotificationsOutlined", color: "#8e24aa" },
  { id: "recentAccess", label: "Accès récents", icon: "History", color: "#d32f2f" },
  { id: "profile", label: "Profil", icon: "AccountCircleOutlined", color: "#1976d2" },
  { id: "leaveBalance", label: "Solde de congés", icon: "BeachAccess", color: "#f57c00" },
] as const;

export const BACKEND_OBJECT_OPTIONS = [
  { id: "conges", label: "Congés", icon: "BeachAccess", color: "#1976d2" },
  { id: "prets", label: "Prêts", icon: "AccountBalance", color: "#2e7d32" },
  { id: "agents", label: "Agents", icon: "Groups", color: "#8e24aa" },
  { id: "bulletins", label: "Bulletins de paie", icon: "Receipt", color: "#f57c00" },
  { id: "absences", label: "Absences", icon: "EventBusy", color: "#d32f2f" },
  { id: "recrutement", label: "Recrutement", icon: "WorkOutline", color: "#1976d2" },
] as const;
