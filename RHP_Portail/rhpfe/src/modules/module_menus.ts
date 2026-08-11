import { loadJSON } from "./module_filesNfolders";
import { Num_Version } from "./module_general";

export interface controleMenusInterface {
  name_ecran: string;
  text_ecran: string;
  typ_ecran: "MNU" | "RPT" | "ECR" | "QRY";
  parent: string;
  rang: number;
  img?: "";
}
export const controleMenus: controleMenusInterface[] = await loadJSON(
  `${import.meta.env.BASE_URL}menus.json?v=${Num_Version}`
)
  .then((dt: any) => {
    if (Array.isArray(dt["menus"])) return dt["menus"];
    else return [];
  })
  .catch((err) => {
    return [];
  });

/**
 * Fusionne les entrées de menu des pages dynamiques publiées (module SP_)
 * avec le menu statique menus.json. Les anciennes entrées dynamiques
 * (préfixe SPPL_) sont remplacées à chaque appel.
 */
export function fusionnerMenusDynamiques(entrees: controleMenusInterface[]) {
  for (let i = controleMenus.length - 1; i >= 0; i--) {
    if (controleMenus[i].name_ecran.startsWith("SPPL_")) controleMenus.splice(i, 1);
  }
  controleMenus.push(...entrees);
}
