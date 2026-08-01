import { loadJSON } from "./module_filesNfolders";
import { SvgIconProps, SvgIconTypeMap } from "@mui/material";

export interface controleMenusInterface {
  name_ecran: string;
  text_ecran: string;
  typ_ecran: "MNU" | "RPT" | "ECR" | "QRY";
  parent: string;
  rang: number;
  img?: "";
}
export const controleMenus: controleMenusInterface[] = await loadJSON(
  `${process.env.PUBLIC_URL}/menus.json`
)
  .then((dt: any) => {
    if (Array.isArray(dt["menus"])) return dt["menus"];
    else return [];
  })
  .catch((err) => {
    return [];
  });
