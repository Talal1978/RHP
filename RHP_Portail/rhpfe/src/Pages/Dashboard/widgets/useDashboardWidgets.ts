import { useCallback, useEffect, useState } from "react";
import type { UserDashboardWidget, WidgetDefinition } from "./types";
import { MOCK_AVAILABLE_WIDGETS } from "./mocks";

const STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGETS_V2";

export const useDashboardWidgets = () => {
  const [availableWidgets] = useState<WidgetDefinition[]>(MOCK_AVAILABLE_WIDGETS);
  const [userWidgets, setUserWidgets] = useState<UserDashboardWidget[]>([]);
  const [isLoaded, setIsLoaded] = useState(false);

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
    setIsLoaded(true);
  }, []);

  useEffect(() => {
    if (isLoaded) {
      localStorage.setItem(STORAGE_KEY, JSON.stringify(userWidgets));
    }
  }, [userWidgets, isLoaded]);

  const saveWidgets = useCallback((widgets: UserDashboardWidget[]) => {
    setUserWidgets(widgets.map((w, index) => ({ ...w, position: index })));
  }, []);

  return {
    availableWidgets,
    userWidgets,
    isLoaded,
    saveWidgets,
  };
};
