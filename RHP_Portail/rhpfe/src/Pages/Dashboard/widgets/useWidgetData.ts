import { useEffect, useState } from "react";
import useAxiosPost from "../../../hooks/useAxiosPost";
import type { ChartData, KpiData, TableData, WidgetDefinition } from "./types";

export type WidgetData = KpiData | ChartData | TableData;

interface WidgetDataState {
  data: WidgetData | null;
  loading: boolean;
  error: string | null;
}

export const useWidgetData = (definition: WidgetDefinition, enabled: boolean): WidgetDataState => {
  const myAxiosPost = useAxiosPost();
  const [data, setData] = useState<WidgetData | null>(null);
  const [loading, setLoading] = useState<boolean>(enabled);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!enabled) return;
    let cancelled = false;
    setLoading(true);
    setError(null);

    // sourceType "query" : requête Param_Query exécutée par le backend avec
    // les paramètres du contexte JWT ; "backend" : requêtes fixes en liste blanche.
    const endpoint = definition.sourceType === "query" ? "dashboard_widget_exec" : "dashboard_widget";

    myAxiosPost(endpoint, { widgetId: definition.id })
      .then((resp) => {
        if (cancelled) return;
        const payload = resp?.data;
        if (payload?.result) {
          setData(payload.data);
        } else {
          setError(payload?.message || "Données indisponibles");
        }
      })
      .catch(() => {
        if (!cancelled) setError("Données indisponibles");
      })
      .finally(() => {
        if (!cancelled) setLoading(false);
      });

    return () => {
      cancelled = true;
    };
  }, [definition.id, definition.sourceType, enabled, myAxiosPost]);

  return { data, loading, error };
};
