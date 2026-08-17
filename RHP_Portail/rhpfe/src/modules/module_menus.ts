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

/* --------------------------------------------------------------------------
   Filtrage des pages standards par profil (référentiel Controle_Menu_Portail
   + Controle_Droit côté serveur, renvoyés par sp_menu_portail) :
   - pagesStandards  : pages visibles par le profil (filtre le menu latéral) ;
   - pagesControlees : tout le référentiel (garde de route dans Ecran.tsx).
   null = référentiel indisponible -> aucun filtrage (fail-open ; la sécurité
   reste assurée par les gardes backend gardePage sur chaque endpoint).
   -------------------------------------------------------------------------- */

/** Copie figée des entrées de menus.json (source de restauration). */
const baseStatique: controleMenusInterface[] = controleMenus.map((mnu) => ({
  ...mnu,
}));

let refPagesStandards: Set<string> | null = null; // tout le référentiel
let okPagesStandards: Set<string> | null = null; // pages autorisées (profil)

/**
 * Mémorise le référentiel et filtre les entrées statiques de controleMenus
 * selon les droits du profil. À appeler APRÈS fusionnerMenusDynamiques (une
 * section statique ne disparaît que si elle n'a plus AUCUN enfant visible,
 * pages dynamiques SPPL_/SPQ_ comprises).
 */
export function filtrerMenusStatiques(
  pagesStandards: string[] | null | undefined,
  pagesControlees: string[] | null | undefined
) {
  refPagesStandards = Array.isArray(pagesControlees)
    ? new Set(pagesControlees)
    : null;
  okPagesStandards = Array.isArray(pagesStandards)
    ? new Set(pagesStandards)
    : null;
  if (!okPagesStandards) return; // référentiel indisponible : pas de filtrage
  // 1) Reconstruire la partie statique depuis la base d'origine, filtrée
  for (let i = controleMenus.length - 1; i >= 0; i--) {
    const mnu = controleMenus[i];
    if (
      mnu.name_ecran.startsWith("SPPL_") ||
      mnu.name_ecran.startsWith("SPQ_") ||
      mnu.dyn === true
    )
      continue;
    controleMenus.splice(i, 1);
  }
  controleMenus.push(
    ...baseStatique
      .filter((mnu) => okPagesStandards!.has(mnu.name_ecran))
      .map((mnu) => ({ ...mnu }))
  );
  // 2) Section statique sans AUCUN enfant visible -> retirée
  for (let i = controleMenus.length - 1; i >= 0; i--) {
    const mnu = controleMenus[i];
    if (mnu.typ_ecran !== "MNU" || mnu.dyn === true) continue;
    if (!controleMenus.some((chd) => chd.parent === mnu.name_ecran))
      controleMenus.splice(i, 1);
  }
}

/**
 * Garde de route client : true si la page peut être affichée.
 * Une page hors référentiel (documents Note_Frais, RH_Demande_Conge..., pages
 * dynamiques SPP_) reste libre côté client : ses endpoints sont de toute façon
 * gardés côté serveur sous le nom de sa page liste.
 */
export function estPageAutorisee(nameEcran: string): boolean {
  if (!refPagesStandards || !okPagesStandards) return true;
  if (!refPagesStandards.has(nameEcran)) return true;
  return okPagesStandards.has(nameEcran);
}
