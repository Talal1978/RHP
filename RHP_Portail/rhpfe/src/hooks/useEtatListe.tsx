import { isValidElement, useEffect, useRef, useState } from "react";
import { TColonneCollection } from "../components/Grille/Grille";
import { Agent } from "../modules/module_general";
import { ObjetGenerique } from "../types";

type TEtatListe<TCriteres> = {
  criteres: TCriteres;
  ds: ObjetGenerique[];
  dsFields: TColonneCollection;
};

// Date sérialisée en JSON (ex. "2026-08-07T00:00:00.000Z")
const rgDateISO = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{3})?Z$/;

// Les critères contiennent des objets Date (CalendarZoom) : après une
// sérialisation JSON, on les réanime pour rendre le bon type aux contrôles.
const revivreDatesCriteres = (criteres: any) => {
  if (!criteres || typeof criteres !== "object") return criteres;
  for (const cle of Object.keys(criteres)) {
    const v = criteres[cle];
    if (typeof v === "string" && rgDateISO.test(v)) {
      const d = new Date(v);
      if (!isNaN(d.getTime())) criteres[cle] = d;
    }
  }
  return criteres;
};

// Certaines listes injectent des icônes React dans les lignes : ce n'est
// pas sérialisable (et non re-renderisable), on les remplace par null.
const remplacerElementsReact = (_cle: string, valeur: any) =>
  isValidElement(valeur) ? null : valeur;

/**
 * Persiste l'état d'une page de liste (critères + résultats) dans
 * sessionStorage : au retour depuis la consultation d'un document, la
 * liste est restaurée telle qu'elle était, sans re-saisie des critères
 * ni nouveau clic sur "Interroger".
 */
const useEtatListe = <TCriteres extends object>(
  cleEcran: string,
  initialiserCriteres: TCriteres
) => {
  // La clé inclut le matricule pour ne pas restaurer l'état d'un autre
  // utilisateur qui se connecterait sur le même navigateur.
  const cleStorage = `etat_liste_${Agent.Matricule}_${cleEcran}`;

  // Lazy initializer : lecture unique du cache au montage du composant
  const [etatCache] = useState<TEtatListe<TCriteres> | null>(() => {
    try {
      const brut = sessionStorage.getItem(cleStorage);
      if (!brut) return null;
      const etat = JSON.parse(brut) as TEtatListe<TCriteres>;
      etat.criteres = revivreDatesCriteres(etat.criteres);
      return etat;
    } catch {
      return null;
    }
  });

  const [criteres, setCriteres] = useState<TCriteres>(
    etatCache?.criteres ?? initialiserCriteres
  );
  const [ds, setDs] = useState<ObjetGenerique[]>(etatCache?.ds ?? []);
  const [dsFields, setDsFields] = useState<TColonneCollection>(
    etatCache?.dsFields ?? {}
  );

  const stateChange = (champs: string, valeur: any) => {
    setCriteres((crt: TCriteres) => ({ ...crt, [champs]: valeur }));
  };

  // Vide la grille uniquement quand l'utilisateur modifie les critères
  // (pas au montage : les résultats restaurés doivent être conservés).
  const criteresJson = JSON.stringify(criteres);
  const criteresPrecedents = useRef(criteresJson);
  useEffect(() => {
    if (criteresPrecedents.current === criteresJson) return;
    criteresPrecedents.current = criteresJson;
    setDs([]);
  }, [criteresJson]);

  // Persiste critères + résultats à chaque changement
  useEffect(() => {
    try {
      sessionStorage.setItem(
        cleStorage,
        JSON.stringify({ criteres, ds, dsFields }, remplacerElementsReact)
      );
    } catch {
      try {
        // Quota dépassé : on persiste au moins les critères
        sessionStorage.setItem(
          cleStorage,
          JSON.stringify({ criteres, ds: [], dsFields: {} })
        );
      } catch {
        // sessionStorage indisponible : la page fonctionne sans persistance
      }
    }
  }, [cleStorage, criteresJson, ds, dsFields]);

  return { criteres, setCriteres, stateChange, ds, setDs, dsFields, setDsFields };
};

export default useEtatListe;
