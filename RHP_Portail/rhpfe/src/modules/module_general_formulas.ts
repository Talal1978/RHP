import { ObjetGenerique } from "../types";

export function Arrondi(nombre: number, nbDecimal: number) {
  return Math.round(nombre * 10 ** nbDecimal) / 10 ** nbDecimal;
}
export function Monetaire(nombre: number, monnaie = "") {
  const paramNumber: ObjetGenerique = { minimumFractionDigits: 2 };
  if (monnaie !== "") {
    paramNumber["style"] = "currency";
    paramNumber["currency"] = "monnaie";
  }
  return new Intl.NumberFormat("fr-FR", paramNumber).format(nombre);
}
