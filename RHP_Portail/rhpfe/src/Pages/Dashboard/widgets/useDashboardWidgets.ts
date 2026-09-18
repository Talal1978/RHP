import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import type { UserDashboardWidget, WidgetDefinition, WidgetSection } from "./types";
import { MOCK_AVAILABLE_WIDGETS } from "./mocks";
import useAxiosPost from "../../../hooks/useAxiosPost";

const STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGETS_V2";
const SECTIONS_STORAGE_KEY = "MYSPACE_DASHBOARD_WIDGET_SECTIONS_V1";
// Migration : les anciennes sections fixes (Accès Rapide, Notifications,
// Actualités RH) sont devenues des widgets standards amovibles.
const STD_MIGRATION_KEY = "MYSPACE_DASHBOARD_STD_WIDGETS_V1";
const STD_WIDGET_IDS = ["list-quickactions", "list-notifications", "list-blogs"];

/**
 * Configuration des widgets du tableau de bord.
 *
 * Persistance : la configuration (widgets + sections) est enregistrée en base
 * (table Portail_Dashboard_Config via dashboard_config_get/save) — résolution
 * côté serveur : configuration personnelle (U) > modèle du profil (P) >
 * modèle global (G). Le localStorage reste utilisé comme cache immédiat et
 * repli hors-ligne ; à la première connexion sans configuration serveur, la
 * configuration locale existante est "adoptée" (poussée en base) pour ne
 * rien perdre des personnalisations antérieures.
 */
export const useDashboardWidgets = () => {
  const myAxiosPost = useAxiosPost();
  const [queryWidgets, setQueryWidgets] = useState<WidgetDefinition[]>([]);
  const [userWidgets, setUserWidgets] = useState<UserDashboardWidget[]>([]);
  const [userSections, setUserSections] = useState<WidgetSection[]>([]);
  const [isLoaded, setIsLoaded] = useState(false);
  // Refs synchronisées : accès aux valeurs courantes depuis les callbacks
  // (persistance serveur) sans dépendre des closures.
  const widgetsRef = useRef<UserDashboardWidget[]>([]);
  const sectionsRef = useRef<WidgetSection[]>([]);
  // Drapeau : l'utilisateur a modifié sa configuration — une réponse tardive
  // du chargement serveur ne doit pas écraser sa saisie.
  const dirtyRef = useRef(false);

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

  // Chargement de la configuration depuis la base (prioritaire sur le
  // localStorage) : U (personnelle) > P (modèle du profil) > G (globale).
  // Sans configuration serveur, la configuration locale est adoptée (poussée
  // en base) pour conserver les personnalisations antérieures.
  useEffect(() => {
    let cancelled = false;
    myAxiosPost("dashboard_config_get", {})
      .then((resp) => {
        if (cancelled || !resp?.data?.result) return;
        const { source, config } = resp.data?.data || {};
        const configValide =
          config && Array.isArray(config.widgets) && Array.isArray(config.sections);
        if (configValide) {
          // L'utilisateur a déjà modifié sa configuration entre-temps :
          // sa saisie prime sur la réponse tardive.
          if (dirtyRef.current) return;
          setUserWidgets(config.widgets as UserDashboardWidget[]);
          setUserSections(config.sections as WidgetSection[]);
        } else if (!source) {
          // Aucune configuration en base : adoption de la configuration
          // locale existante (première connexion après mise en place de la
          // persistance SQL), sans rien écraser côté serveur sinon.
          if (widgetsRef.current.length > 0 || sectionsRef.current.length > 0) {
            myAxiosPost("dashboard_config_save", {
              widgets: widgetsRef.current,
              sections: sectionsRef.current,
            }).catch(() => {
              /* adoption différée : le prochain enregistrement persistera */
            });
          }
        }
      })
      .catch(() => {
        /* serveur indisponible : le localStorage (déjà chargé) fait foi */
      });
    return () => {
      cancelled = true;
    };
  }, [myAxiosPost]);

  useEffect(() => {
    if (isLoaded) {
      localStorage.setItem(STORAGE_KEY, JSON.stringify(userWidgets));
      localStorage.setItem(SECTIONS_STORAGE_KEY, JSON.stringify(userSections));
    }
  }, [userWidgets, userSections, isLoaded]);

  useEffect(() => {
    widgetsRef.current = userWidgets;
  }, [userWidgets]);

  useEffect(() => {
    sectionsRef.current = userSections;
  }, [userSections]);

  // Persistance serveur (fire-and-forget) : le localStorage conserve un
  // repli immédiat si l'appel échoue.
  const persistServer = useCallback(
    (widgets: UserDashboardWidget[], sections: WidgetSection[]) => {
      myAxiosPost("dashboard_config_save", { widgets, sections }).catch(() => {
        /* persistance serveur indisponible : le localStorage conserve la config */
      });
    },
    [myAxiosPost]
  );

  const saveWidgets = useCallback(
    (widgets: UserDashboardWidget[]) => {
      dirtyRef.current = true;
      const next = widgets.map((w, index) => ({ ...w, position: index }));
      setUserWidgets(next);
      persistServer(next, sectionsRef.current);
    },
    [persistServer]
  );

  const saveSections = useCallback(
    (sections: WidgetSection[]) => {
      dirtyRef.current = true;
      const next = sections.map((s, index) => ({ ...s, position: index }));
      setUserSections(next);
      persistServer(widgetsRef.current, next);
    },
    [persistServer]
  );

  return {
    availableWidgets,
    userWidgets,
    userSections,
    isLoaded,
    saveWidgets,
    saveSections,
  };
};
