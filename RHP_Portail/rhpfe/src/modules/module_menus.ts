import { loadJSON } from "./module_filesNfolders";

export interface controleMenusInterface {
  name_ecran: string;
  text_ecran: string;
  typ_ecran: "MNU" | "RPT" | "ECR" | "QRY";
  parent: string;
  rang: number;
  img?: "";
}
export const controleMenus: controleMenusInterface[] = await loadJSON(
  `${import.meta.env.BASE_URL}menus.json`
)
  .then((dt: any) => {
    if (Array.isArray(dt["menus"])) return dt["menus"];
    else return [];
  })
  .catch((err) => {
    return [];
  });
