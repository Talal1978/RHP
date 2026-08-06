import { createContext } from "react";

/**
 * Données des widgets "standard" (Accès Rapide, Notifications, Actualités...),
 * fournies par le dashboard. Clé = standardId du widget ("quickActions",
 * "notifications", "blogs"), valeur = props de la section correspondante.
 * Le provider couvre aussi le WidgetBuilder (aperçu en direct dans le tiroir).
 */
export const StandardWidgetDataContext = createContext<Record<string, Record<string, unknown>>>({});
