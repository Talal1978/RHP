import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

/**
 * Configuration personnalisée du tableau de bord du portail (widgets + sections).
 *
 * Stockage : table Portail_Dashboard_Config (migration
 * sql/Dashboard/001_Portail_Dashboard_Config.sql) :
 * - Typ_Config 'U' : configuration personnelle (Cle_Config = Matricule,
 *   id_Societe = société de l'agent) — écrite ici à chaque enregistrement ;
 * - Typ_Config 'P' : modèle par défaut d'un profil (Cle_Config = Cod_Profile,
 *   id_Societe = -1) — alimenté par l'écran desktop Admin_Dashboard_Config ;
 * - Typ_Config 'G' : modèle global (Cle_Config = '*', id_Societe = -1).
 *
 * Sécurité :
 * - L'identité (Matricule, id_Societe, codProfile) provient exclusivement du
 *   token JWT validé (req.params), jamais du corps de la requête : un
 *   utilisateur ne lit et n'écrit que SA propre ligne 'U'.
 * - Résolution à la lecture : U (matricule + société) > P (profil) > G
 *   (globale) ; "source" indique au client le niveau appliqué (une
 *   configuration issue d'un modèle devient personnelle au premier
 *   enregistrement de l'utilisateur).
 */

interface DashboardConfig {
  widgets: any[];
  sections: any[];
}

const MAX_CONFIG_LEN = 200000; // garde-fou de taille (JSON widgets + sections)

const parseConfig = (raw: any): DashboardConfig | null => {
  try {
    const cfg = JSON.parse(String(raw ?? ""));
    if (cfg && Array.isArray(cfg.widgets) && Array.isArray(cfg.sections)) {
      return { widgets: cfg.widgets, sections: cfg.sections };
    }
  } catch {
    /* JSON corrompu : traité comme une absence de configuration */
  }
  return null;
};

export const getDashboardConfig = async (req: Request, res: Response) => {
  const { processId, ...theAgent } = req.params;
  const Matricule = String(theAgent?.Matricule || "");
  const id_Societe = Number(theAgent?.id_Societe || 0);
  const codProfile = String(theAgent?.codProfile ?? "");

  if (!Matricule || isNaN(id_Societe) || id_Societe <= 0) {
    return res.status(400).send({ result: false, message: "Identité invalide" });
  }

  try {
    const rsl = await lireSql(
      `select top 1 Typ_Config, Config_Json
       from Portail_Dashboard_Config
       where (Typ_Config='U' and Cle_Config=@mat and id_Societe=@soc)
          or (Typ_Config='P' and Cle_Config=@profil and id_Societe in (@soc,-1))
          or (Typ_Config='G' and id_Societe in (@soc,-1))
       order by case Typ_Config when 'U' then 0 when 'P' then 1 else 2 end,
                id_Societe desc`,
      [
        { param: "mat", sqlType: NVarChar, valeur: Matricule },
        { param: "soc", sqlType: Int, valeur: id_Societe },
        { param: "profil", sqlType: NVarChar, valeur: codProfile },
      ]
    );
    if (!rsl.result) {
      return res.send({ result: false, message: "Erreur de lecture de la configuration" });
    }
    const row = rsl.data?.[0];
    const config = row ? parseConfig(row.Config_Json) : null;
    if (!row || !config) {
      return res.send({ result: true, data: { source: null, config: null } });
    }
    return res.send({ result: true, data: { source: String(row.Typ_Config), config } });
  } catch (error: any) {
    return res.send({ result: false, message: error.message });
  }
};

export const saveDashboardConfig = async (req: Request, res: Response) => {
  const { processId, ...theAgent } = req.params;
  const Matricule = String(theAgent?.Matricule || "");
  const id_Societe = Number(theAgent?.id_Societe || 0);
  const login = String(theAgent?.Login || "");

  if (!Matricule || isNaN(id_Societe) || id_Societe <= 0) {
    return res.status(400).send({ result: false, message: "Identité invalide" });
  }

  const config = { widgets: req.body?.widgets, sections: req.body?.sections };
  if (!Array.isArray(config.widgets) || !Array.isArray(config.sections)) {
    return res.status(400).send({ result: false, message: "Configuration invalide" });
  }
  const json = JSON.stringify(config);
  if (json.length > MAX_CONFIG_LEN) {
    return res.send({ result: false, message: "Configuration trop volumineuse" });
  }

  try {
    const rsl = await lireSql(
      `merge into Portail_Dashboard_Config as tbl
       using (values ('U', @mat, @soc, @json, @login)) as src
              (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By)
       on tbl.Typ_Config = src.Typ_Config and tbl.Cle_Config = src.Cle_Config
          and tbl.id_Societe = src.id_Societe
       when matched then
         update set Config_Json = src.Config_Json, Dat_Modif = getdate(),
                    Modified_By = src.Modified_By
       when not matched then
         insert (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By)
         values (src.Typ_Config, src.Cle_Config, src.id_Societe,
                 src.Config_Json, src.Modified_By);`,
      [
        { param: "mat", sqlType: NVarChar, valeur: Matricule },
        { param: "soc", sqlType: Int, valeur: id_Societe },
        { param: "json", sqlType: NVarChar, valeur: json },
        { param: "login", sqlType: NVarChar, valeur: login },
      ]
    );
    if (!rsl.result) {
      return res.send({ result: false, message: "Erreur d'enregistrement de la configuration" });
    }
    return res.send({ result: true });
  } catch (error: any) {
    return res.send({ result: false, message: error.message });
  }
};
