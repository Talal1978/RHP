import { useCallback, useEffect, useMemo, useState } from "react";
import type { UserDashboardWidget, WidgetDefinition, WidgetSection } from "./types";
import { MOCK_AVAILABLE_WIDGETS } from "./mocks";
import useAxiosPost from "../../../hooks/useAxiosPost";

const STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGETS_V2";
const SECTIONS_STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGET_SECTIONS_V1";
// Migration : les anciennes sections fixes (Accès Rapide, Notifications,
// Actualités RH) sont devenues des widgets standards amovibles.
const STD_MIGRATION_KEY = "MYSPACE_DASHBOARD_STD_WIDGETS_V1";
const STD_WIDGET_IDS = ["list-quickactions", "list-notifications", "list-blogs"];

export const useDashboardWidgets = () => {
  const myAxiosPost = useAxiosPost();
  const [queryWidgets, setQueryWidgets] = useState<WidgetDefinition[]>([]);
  const [userWidgets, setUserWidgets] = useState<UserDashboardWidget[]>([]);
  const [userSections, setUserSections] = useState<WidgetSection[]>([]);
  const [isLoaded, setIsLoaded] = useState(false);

  // Catalogue dynamique : requêtes Param_Query déclarées widgets,
  // filtrées par le backend selon le profil de l'utilisateur (Controle_Droit).
  useEffect(() => {
    let cancelled = false;
    myAxiosPost("dashboard_widget_catalog", {})
      .then((resp) => {
        if (!cancelled && resp?.data?.result && Array.isArray(resp.data.data)) {
          setQueryWidgets(resp.data.data);
        }
      })
      .catch(() => {
        /* catalogue dynamique indisponible : le catalogue statique suffit */
      });
    return () => {
      cancelled = true;
    };
  }, [myAxiosPost]);

  const availableWidgets = useMemo(
    () => [...MOCK_AVAILABLE_WIDGETS, ...queryWidgets],
    [queryWidgets]
  );

  useEffect(() => {
    const stored = localStorage.getItem(STORAGE_KEY);
    let loaded: UserDashboardWidget[] = [];
    if (stored) {
      try {
        loaded = JSON.parse(stored) as UserDashboardWidget[];
      } catch {
        loaded = [];
      }
    }

    // Migration unique : conversion des sections fixes en widgets standards.
    // L'utilisateur peut ensuite les retirer (le drapeau évite toute ré-injection).
    if (!localStorage.getItem(STD_MIGRATION_KEY)) {
      const missing = MOCK_AVAILABLE_WIDGETS.filter(
        (d) => STD_WIDGET_IDS.includes(d.id) && !loaded.some((w) => w.widgetId === d.id)
      );
      if (missing.length > 0) {
        loaded = [
          ...loaded,
          ...missing.map((d, i) => ({
            instanceId: `widget_${Date.now()}_${i}_${Math.random().toString(36).substr(2, 9)}`,
            widgetId: d.id,
            title: d.title,
            type: d.type,
            chartType: d.chartType,
            icon: d.icon,
            color: d.color,
            span: d.defaultSpan,
            position: loaded.length + i,
            sourceType: d.sourceType,
            standardId: d.standardId,
            dataConfig: d.dataConfig,
          })),
        ];
      }
      localStorage.setItem(STD_MIGRATION_KEY, "1");
    }
    setUserWidgets(loaded);

    const storedSections = localStorage.getItem(SECTIONS_STORAGE_KEY);
    if (storedSections) {
      try {
        const parsed = JSON.parse(storedSections) as WidgetSection[];
        setUserSections(Array.isArray(parsed) ? parsed : []);
      } catch {
        setUserSections([]);
      }
    } else {
      setUserSections([]);
    }
    setIsLoaded(true);
  }, []);

  useEffect(() => {
    if (isLoaded) {
      localStorage.setItem(STORAGE_KEY, JSON.stringify(userWidgets));
      localStorage.setItem(SECTIONS_STORAGE_KEY, JSON.stringify(userSections));
    }
  }, [userWidgets, userSections, isLoaded]);

  const saveWidgets = useCallback((widgets: UserDashboardWidget[]) => {
    setUserWidgets(widgets.map((w, index) => ({ ...w, position: index })));
  }, []);

  const saveSections = useCallback((sections: WidgetSection[]) => {
    setUserSections(sections.map((s, index) => ({ ...s, position: index })));
  }, []);

  return {
    availableWidgets,
    userWidgets,
    userSections,
    isLoaded,
    saveWidgets,
    saveSections,
  };
};
