/* ============================================================================
   Droits d'accès aux pages STANDARDS du portail par profil (Controle_Profile)
   ----------------------------------------------------------------------------
   Référentiel : Controle_Menu_Portail (miroir de menus.json, alimenté par la
   migration sql/Securite/001_Profil_Portail_Agents.sql) — source de l'onglet
   "Portail" de l'écran desktop Admin_Profile et de la garde de route client.
   Droits      : Controle_Droit (Cod_Profile, Name_Ecran = 'PRT_' + nom de la
   page — le préfixe PRT_ isole les droits portail des écrans desktop de mêmes
   noms, ex. Note_Frais_Liste —, Visible = affichage dans le menu, Actif =
   accès à la page).

   Règles (conventions RHP) :
   - profil '1' : bypass total ;
   - le contrôle est PAR PROFIL : sans ligne Controle_Droit POUR CE PROFIL sur
     la page, celle-ci est NON CONTRÔLÉE pour lui -> accès libre. Ainsi rien ne
     change pour les profils non traités (déploiement progressif) ; dès qu'un
     profil est enregistré dans l'onglet Portail d'Admin_Profile, une ligne est
     écrite pour CHAQUE page (l'écran desktop enregistre toute la matrice) et
     le profil obtient exactement ce qui a été coché ;
   - référentiel indisponible (migration non appliquée) : fail-open, la
     sécurité des données reste assurée par le cloisonnement existant.
   ============================================================================ */
import { NextFunction, Request, Response } from "express";
import { NVarChar } from "mssql";
import { lireSql } from "./module_sqlRW";

export interface TDroitPage {
  /** true si le profil a une ligne Controle_Droit explicite sur la page. */
  controlee: boolean;
  visible: boolean;
  actif: boolean;
}

/** Droits d'une page standard du portail pour un profil. */
export const droitsPage = async (
  codProfile: string,
  nameEcran: string
): Promise<TDroitPage> => {
  const pr = String(codProfile ?? "");
  if (pr === "1") return { controlee: false, visible: true, actif: true };
  const rsl = await lireSql(
    `select d.Visible as Visible, d.Actif as Actif
       from Controle_Menu_Portail m
       left join Controle_Droit d
         on d.Name_Ecran = 'PRT_' + m.Name_Ecran and d.Cod_Profile = @pr
      where m.Name_Ecran = @ecr`,
    [
      { param: "ecr", sqlType: NVarChar, valeur: String(nameEcran ?? "") },
      { param: "pr", sqlType: NVarChar, valeur: pr },
    ]
  );
  // Référentiel indisponible ou page non référencée -> non contrôlée
  if (!rsl.result || !rsl.data?.length)
    return { controlee: false, visible: true, actif: true };
  const row = rsl.data[0];
  // Pas de ligne de droit pour ce profil -> non contrôlée pour lui
  if (row.Visible === null && row.Actif === null)
    return { controlee: false, visible: true, actif: true };
  return {
    controlee: true,
    visible: row.Visible === true || String(row.Visible) === "true",
    actif: row.Actif === true || String(row.Actif) === "true",
  };
};

/** true si le profil peut ACCÉDER à la page (Actif). */
export const peutAccederPage = async (codProfile: string, nameEcran: string) =>
  (await droitsPage(codProfile, nameEcran)).actif;

/**
 * Pages standards VISIBLES dans le menu pour le profil : toute page du
 * référentiel sans ligne de droit pour ce profil, ou avec Visible = 'true'.
 * Retourne null si le référentiel est indisponible (-> aucun filtrage côté
 * client, fail-open) ; un profil '1' voit tout le référentiel.
 */
export const pagesMenuAutorisees = async (
  codProfile: string
): Promise<string[] | null> => {
  const pr = String(codProfile ?? "");
  const rsl = await lireSql(
    `select m.Name_Ecran,
            (select count(*) from Controle_Droit d
              where d.Name_Ecran = 'PRT_' + m.Name_Ecran and d.Cod_Profile = @pr
                and isnull(d.Visible,'false') = 'true') as nbVis,
            (select count(*) from Controle_Droit d
              where d.Name_Ecran = 'PRT_' + m.Name_Ecran and d.Cod_Profile = @pr) as nbLig
       from Controle_Menu_Portail m`,
    [{ param: "pr", sqlType: NVarChar, valeur: pr }]
  );
  if (!rsl.result) return null;
  return (rsl.data ?? [])
    .filter(
      (r: any) => pr === "1" || Number(r.nbLig) === 0 || Number(r.nbVis) > 0
    )
    .map((r: any) => String(r.Name_Ecran));
};

/**
 * Toutes les pages du référentiel (contrôlées ou non) : utilisé par la garde
 * de route du client pour distinguer une page contrôlée refusée d'une page
 * hors référentiel (documents, pages techniques...). null si indisponible.
 */
export const pagesReferenciees = async (): Promise<string[] | null> => {
  const rsl = await lireSql(`select m.Name_Ecran from Controle_Menu_Portail m`, []);
  if (!rsl.result) return null;
  return (rsl.data ?? []).map((r: any) => String(r.Name_Ecran));
};

/**
 * Middleware Express : refuse l'accès à l'endpoint si le profil du JWT n'a
 * pas le droit Actif sur la page (à placer APRÈS validate).
 * Ex. : mainRooting.post("/note_frais_liste", validate, gardePage("Note_Frais_Liste"), noteFraisListe)
 */
export const gardePage =
  (nameEcran: string) =>
  async (req: Request, res: Response, next: NextFunction) => {
    const ok = await peutAccederPage(String(req.params?.codProfile ?? ""), nameEcran);
    if (!ok)
      return res.send({
        result: false,
        data: [],
        message: "Vous n'êtes pas autorisé à accéder à cette page.",
      });
    next();
  };
