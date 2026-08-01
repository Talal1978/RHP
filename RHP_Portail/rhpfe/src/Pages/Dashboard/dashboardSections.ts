import dashboardSectionsJson from "./dashboardSections.json";

export type DashboardSectionId =
  | "welcome"
  | "profile"
  | "leaveBalance"
  | "weather"
  | "quickActions"
  | "notifications"
  | "news";

export interface DashboardSectionDefinition {
  id: DashboardSectionId;
  label: string;
  visible: boolean;
  desktopSpan: number;
}

export interface DashboardSectionPreference {
  id: DashboardSectionId;
  visible: boolean;
}

export const DASHBOARD_SECTIONS_STORAGE_KEY = "MYSPACE_DASHBOARD_SECTIONS";
export const DASHBOARD_SECTIONS_UPDATED_EVENT = "portal-dashboard-sections-updated";

export const DASHBOARD_SECTION_DEFINITIONS =
  dashboardSectionsJson as DashboardSectionDefinition[];

export const DEFAULT_DASHBOARD_SECTION_PREFERENCES: DashboardSectionPreference[] =
  DASHBOARD_SECTION_DEFINITIONS.map(({ id, visible }) => ({ id, visible }));

const SECTION_IDS = new Set<DashboardSectionId>(
  DASHBOARD_SECTION_DEFINITIONS.map((section) => section.id)
);

export const DASHBOARD_SECTION_DEFINITION_MAP = Object.fromEntries(
  DASHBOARD_SECTION_DEFINITIONS.map((section) => [section.id, section])
) as Record<DashboardSectionId, DashboardSectionDefinition>;

const isDashboardSectionId = (value: unknown): value is DashboardSectionId =>
  typeof value === "string" && SECTION_IDS.has(value as DashboardSectionId);

export const normalizeDashboardSectionPreferences = (
  rawValue: unknown
): DashboardSectionPreference[] => {
  if (!Array.isArray(rawValue)) {
    return DEFAULT_DASHBOARD_SECTION_PREFERENCES;
  }

  const orderedIds: DashboardSectionId[] = [];
  const visibilityById = new Map<DashboardSectionId, boolean>();

  rawValue.forEach((entry) => {
    if (!entry || typeof entry !== "object") {
      return;
    }

    const { id, visible } = entry as {
      id?: unknown;
      visible?: unknown;
    };

    if (!isDashboardSectionId(id) || visibilityById.has(id)) {
      return;
    }

    orderedIds.push(id);
    visibilityById.set(
      id,
      typeof visible === "boolean"
        ? visible
        : DASHBOARD_SECTION_DEFINITION_MAP[id].visible
    );
  });

  DASHBOARD_SECTION_DEFINITIONS.forEach((section) => {
    if (!visibilityById.has(section.id)) {
      orderedIds.push(section.id);
      visibilityById.set(section.id, section.visible);
    }
  });

  return orderedIds.map((id) => ({
    id,
    visible: visibilityById.get(id) ?? DASHBOARD_SECTION_DEFINITION_MAP[id].visible,
  }));
};

export const loadDashboardSectionPreferences = (): DashboardSectionPreference[] => {
  const saved = localStorage.getItem(DASHBOARD_SECTIONS_STORAGE_KEY);
  if (!saved) {
    return DEFAULT_DASHBOARD_SECTION_PREFERENCES;
  }

  try {
    return normalizeDashboardSectionPreferences(JSON.parse(saved));
  } catch (error) {
    console.error("Error parsing dashboard sections", error);
    return DEFAULT_DASHBOARD_SECTION_PREFERENCES;
  }
};

export const saveDashboardSectionPreferences = (
  preferences: DashboardSectionPreference[]
) => {
  const normalized = normalizeDashboardSectionPreferences(preferences);
  localStorage.setItem(DASHBOARD_SECTIONS_STORAGE_KEY, JSON.stringify(normalized));
  window.dispatchEvent(new Event(DASHBOARD_SECTIONS_UPDATED_EVENT));
};

export const resetDashboardSectionPreferences = () => {
  saveDashboardSectionPreferences(DEFAULT_DASHBOARD_SECTION_PREFERENCES);
};
