export let rubriques: TRubrique[] = [];
export function setRubriques(rub: TRubrique[]) {
  rubriques = [...rub];
}
export function findRubrique(rubrique: string, valeur: string) {
  return (
    rubriques.find((r) => r.rubrique === rubrique && r.valeur === valeur)
      ?.membre || ""
  );
}
export function listRubriques(rubrique: string) {
  return rubriques
    .filter((r) => r.rubrique === rubrique)
    .sort((a, b) => a.rang - b.rang)
    .map((b) => ({
      valeur: b.valeur,
      membre: b.membre,
    }));
}
export type TRubrique = {
  rubrique: string;
  valeur: string;
  membre: string;
  rang: number;
};
