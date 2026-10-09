import { Request, Response } from "express";
import { controleInjection, lireSql } from "./module_sqlRW";
import {
  TablesAvecMatricule,
  Tbl_Controle_Def_Zoom,
} from "./module_initialisation";
import {
  IsNull,
  TablesSQLWithIdSocOuMatricule,
  handleIdSoc,
} from "./module_general";

/* --------------------------------------------------------------------------
 * Identité de l'appelant, lue du JWT (middleware validate) — le SQL du zoom
 * est construit À LA REQUÊTE. Le catalogue global Tbl_Controle_Def_Zoom ne
 * contient que la définition brute : y figer Matricule / id_Societe d'un
 * agent au login imposait l'identité du dernier connecté à toutes les
 * sessions (bug de gestion des sessions).
 * -------------------------------------------------------------------------- */
function agentDepuisReq(req: Request) {
  return {
    Matricule: String(req.params.Matricule ?? ""),
    id_Societe: String(req.params.id_Societe ?? ""),
    Cod_Entite: String(req.params.Cod_Entite ?? ""),
    TeamLeader: String(req.params.TeamLeader).toLowerCase() === "true",
  };
}

const sqlLiteral = (v: unknown) => String(v ?? "").replace(/'/g, "''");

/** Construit le SQL d'un zoom pour l'agent courant : restriction au Matricule
 *  de l'agent (ou à son équipe s'il est TeamLeader) sur les tables portant un
 *  Matricule, puis filtre société sur les tables à id_Societe. */
async function construireSqlZoom(
  def: { [key: string]: string },
  agent: ReturnType<typeof agentDepuisReq>
): Promise<string> {
  const idSoc = Number(agent.id_Societe) || 0;
  let where1 = (def.where1 ?? "") + " @@@condition ";
  const olistMat = await TablesSQLWithIdSocOuMatricule(
    TablesAvecMatricule,
    def.zoomTbl ?? "",
    def.numZoom === "MS067"
  );
  let matriculeWhere = "";
  if (olistMat.length > 0) {
    if (agent.TeamLeader) {
      matriculeWhere = ` ${olistMat[0].alias}.Matricule in (select Matricule from Rh_Agent _agt where id_Societe=${idSoc} and _agt.Cod_Entite in (
        select  Cod_Entite from Sys_Org_Entite s where
                    ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('${sqlLiteral(agent.Cod_Entite)}',''),'8787uhuhunjj')+';%' and id_Societe=_agt.id_Societe))`;
    } else {
      matriculeWhere = `(${olistMat[0].alias}.id_Societe=${idSoc} and ${olistMat[0].alias}.Matricule='${sqlLiteral(agent.Matricule)}')`;
    }
  }
  where1 = where1 + (matriculeWhere ? `and (${matriculeWhere})` : "");
  let sqlStr = `select distinct ${def.codExp} as Code,${def.zoomLib} FROM ${def.zoomTbl} where ${where1}  ${
    def.zoomOrder != "" ? `Order by ${def.zoomOrder} ${def.zoomSens}` : ""
  }`;
  sqlStr = await handleIdSoc(sqlStr, String(idSoc));
  return sqlStr;
}

export const getZoomApi = async (req: Request, res: Response) => {
  let { numZoom, condition, valeurs } = req.body;
  if (controleInjection(condition).result === false) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  if (controleInjection(numZoom).result === false) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  if (controleInjection(valeurs).result === false) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  const oRow = Tbl_Controle_Def_Zoom.filter((z) => z.numZoom === numZoom);
  if (oRow.length === 0) return res.send({ result: false, data: [] });
  let sqlStr = await construireSqlZoom(oRow[0], agentDepuisReq(req));
  sqlStr = sqlStr.replace(
    /@@@condition/gi,
    IsNull(condition, "") != "" ? condition : ""
  );
  for (let i: number = 0; i < valeurs?.length || 0; i++) {
    let rg = new RegExp(`\{${i}\}`, "gi");
    sqlStr = sqlStr.replace(rg, valeurs[i]?.trim());
  }

  const rsl = await lireSql(sqlStr);
  // searchBy : position 1-based de la colonne de recherche par défaut
  // (Controle_Def_Zoom.Search_By) — le panneau zoom du portail y applique
  // le filtrage clavier à l'ouverture.
  return res.send({ ...rsl, searchBy: oRow[0].searchBy ?? "" });
};

/** Retourne le libellé d'une valeur de zoom : la 2e colonne de la déclaration
 *  du zoom dans Controle_Def_Zoom (1ère colonne = Code, 2e = libellé).
 *  Réutilise la requête du zoom en y injectant le filtre sur l'expression du
 *  code (l'alias Code n'est pas utilisable dans le WHERE). */
export const getZoomLibelleApi = async (req: Request, res: Response) => {
  const { numZoom, valeur, valeurs } = req.body;
  if (controleInjection(numZoom).result === false) {
    return res.send("");
  }
  if (controleInjection(valeur).result === false) {
    return res.send("");
  }
  const val = String(IsNull(valeur, "")).trim();
  if (val === "") return res.send("");
  const oRow = Tbl_Controle_Def_Zoom.filter((z) => z.numZoom === numZoom);
  if (oRow.length === 0) return res.send("");
  let sqlStr = await construireSqlZoom(oRow[0], agentDepuisReq(req));
  sqlStr = sqlStr.replace(
    /@@@condition/gi,
    `and (${oRow[0].codExp} = '${val.replace(/'/g, "''")}')`
  );
  for (let i: number = 0; i < valeurs?.length || 0; i++) {
    let rg = new RegExp(`\{${i}\}`, "gi");
    sqlStr = sqlStr.replace(rg, valeurs[i]?.trim());
  }
  const rsl = await lireSql(sqlStr);
  const libelle =
    rsl && rsl.result && rsl.data.length > 0
      ? Object.values(rsl.data[0])[1]
      : "";
  return res.send(String(libelle ?? ""));
};
