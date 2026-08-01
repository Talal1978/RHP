export interface DashboardShortcutItem {
  label: string;
  img: string;
  link: string;
  color: string;
  name_ecran: string;
}

export const DEFAULT_DASHBOARD_SHORTCUTS: DashboardShortcutItem[] = [
  {
    label: "Poser un congé",
    img: "BeachAccess",
    link: "/myspace/RH_Demande_Conge_Liste/Demandes de congé",
    color: "#e3f2fd",
    name_ecran: "RH_Demande_Conge_Liste",
  },
  {
    label: "Mes Bulletins",
    img: "DescriptionOutlined",
    link: "/myspace/RH_Bulletin_Liste/Edition de bulletins de paie",
    color: "#e8f5e9",
    name_ecran: "RH_Bulletin_Liste",
  },
  {
    label: "Déclarer un accident",
    img: "MedicalServices",
    link: "/myspace/RH_Declaration_AT_Liste/Accidents de travail",
    color: "#fff3e0",
    name_ecran: "RH_Declaration_AT_Liste",
  },
  {
    label: "Demande de Prêt",
    img: "AttachMoney",
    link: "/myspace/RH_Demande_Pret_Liste/Demandes de prêts",
    color: "#f3e5f5",
    name_ecran: "RH_Demande_Pret_Liste",
  },
];

export const DASHBOARD_SHORTCUTS_STORAGE_KEY = "MYSPACE_SHORTCUTS";
export const DASHBOARD_SHORTCUTS_UPDATED_EVENT = "portal-shortcuts-updated";

export const loadDashboardShortcuts = (): DashboardShortcutItem[] => {
  const saved = localStorage.getItem(DASHBOARD_SHORTCUTS_STORAGE_KEY);
  if (!saved) {
    return DEFAULT_DASHBOARD_SHORTCUTS;
  }

  try {
    return JSON.parse(saved);
  } catch (error) {
    console.error("Error parsing shortcuts", error);
    return DEFAULT_DASHBOARD_SHORTCUTS;
  }
};
