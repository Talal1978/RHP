import { loadJSON } from "./module_filesNfolders";
import { Num_Version } from "./module_general";

export interface controleMenusInterface {
  name_ecran: string;
  text_ecran: string;
  typ_ecran: "MNU" | "RPT" | "ECR" | "QRY";
  parent: string;
  rang: number;
  img?: "";
  /** Section racine ajoutée dynamiquement (rubrique SP_Menu_Portail, Designer) */
  dyn?: boolean;
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
 * Fusionne les entrées de menu des pages dynamiques publiées (module SP_ :
 * listes SPPL_, pages-requêtes SPQ_ du requêteur) avec le menu statique
 * menus.json. Les anciennes entrées dynamiques (pages préfixe SPPL_/SPQ_ et
 * sections marquées dyn) sont remplacées à chaque appel.
 * Une section racine déjà déclarée dans menus.json n'est jamais dupliquée.
 */
export function fusionnerMenusDynamiques(entrees: controleMenusInterface[]) {
  for (let i = controleMenus.length - 1; i >= 0; i--) {
    if (
      controleMenus[i].name_ecran.startsWith("SPPL_") ||
      controleMenus[i].name_ecran.startsWith("SPQ_") ||
      controleMenus[i].dyn === true
    )
      controleMenus.splice(i, 1);
  }
  for (const entree of entrees) {
    if (
      entree.parent === "" &&
      controleMenus.some(
        (mnu) => mnu.parent === "" && mnu.name_ecran === entree.name_ecran
      )
    )
      continue;
    controleMenus.push(entree);
  }
}
