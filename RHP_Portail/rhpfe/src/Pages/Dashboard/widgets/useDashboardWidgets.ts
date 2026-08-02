import { useCallback, useEffect, useMemo, useState } from "react";
import type { UserDashboardWidget, WidgetDefinition, WidgetSection } from "./types";
import { MOCK_AVAILABLE_WIDGETS } from "./mocks";
import useAxiosPost from "../../../hooks/useAxiosPost";

const STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGETS_V2";
const SECTIONS_STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGET_SECTIONS_V1";

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
    if (stored) {
      try {
        const parsed = JSON.parse(stored) as UserDashboardWidget[];
        setUserWidgets(parsed);
      } catch {
        setUserWidgets([]);
      }
    } else {
      setUserWidgets([]);
    }
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
