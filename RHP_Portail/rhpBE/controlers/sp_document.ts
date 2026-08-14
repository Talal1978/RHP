/* ============================================================================
   Module SP_ - Endpoints d'exécution des pages dynamiques du portail
   ----------------------------------------------------------------------------
   Le client n'envoie JAMAIS de nom de table/colonne : seulement Cod_Page et
   des données. Tout est résolu depuis les métadonnées publiées (SP_Page*).
   ============================================================================ */
import { Request, Response } from "express";
import sql from "mssql";
import { lireSql } from "../modules/module_sqlRW";
import {
  chargerMetaPage, verifierDroit, lireDocument, enregistrerDocument,
  supprimerDocument, executerValidations, recalculer, executerSource,
  qn, colonnesMetier, tableEnt, TSpContexte, TSpMeta,
} from "../modules/module_sp_engine";

function agentDepuis(req: Request) {
  const { Login, Matricule, id_Societe, codProfile, TeamLeader } = req.params;
  return {
    Login: String(Login ?? Matricule ?? ""),
    Matricule: String(Matricule ?? ""),
    id_Societe: String(id_Societe ?? ""),
    codProfile: String(codProfile ?? ""),
    TeamLeader: String(TeamLeader ?? ""),
  };
}
const refus = (res: Response, message: string) =>
  res.send({ result: false, data: [], fields: [], sort: message, message });

/** Charge la méta d'une page PUBLIÉE en vérifiant le droit d'accès. */
async function metaPubliee(req: Request, action: "Consulter" | "Creer" | "Modifier" | "Supprimer" | "Valider" | "Imprimer" | "GED") {
  const agent = agentDepuis(req);
  const codPage = String(req.body?.codPage ?? req.query?.codPage ?? "");
  const meta = await chargerMetaPage(codPage);
  if (!meta) return { erreur: "Page introuvable", agent, meta: null as TSpMeta | null };
  if (meta.page.Statut_Page !== "PUBLIE") {
    return { erreur: "Cette page n'est pas publiée.", agent, meta: null };
  }
  const ok = await verifierDroit(codPage, agent.codProfile, action);
  if (!ok) return { erreur: "Vous n'êtes pas autorisé à effectuer cette action.", agent, meta: null };
  return { erreur: null as string | null, agent, meta };
}

/* -------------------------------------------------------------------------- */
/* Menu du portail : entrées des pages publiées (fusionnées à menus.json)     */
/* -------------------------------------------------------------------------- */
export async function sp_menu_portail(req: Request, res: Response) {
  const { codProfile } = req.params;
  const rsl = await lireSql(
    `select p.Cod_Page, p.Nom_Page, p.Menu_Parent, p.Rang, p.Icone
     from SP_Page p
     where p.Statut_Page='PUBLIE'
       and ( @p_pr = '1'
              or isnull(p.Acces_Personnalise,'true')='false'   -- consultation ouverte à tous
              or exists (select 1 from SP_Page_Droit d
                         where d.Cod_Page=p.Cod_Page and d.Cod_Profile=@p_pr
                           and isnull(d.Consulter,'false')='true') )
     order by p.Menu_Parent, p.Rang`,
    [{ param: "p_pr", sqlType: sql.NVarChar, valeur: String(codProfile ?? "") }]
  );
  if (!rsl.result) return refus(res, "Erreur de chargement du menu");
  const menus = (rsl.data ?? []).map((p: any) => ({
    name_ecran: `SPPL_${p.Cod_Page}`,          // liste dynamique
    text_ecran: p.Nom_Page,
    typ_ecran: "ECR",
    parent: p.Menu_Parent,
    rang: p.Rang,
    img: p.Icone ?? "",
  }));
  // Sections créées depuis le Designer (rubrique SP_Menu_Portail) : racines du
  // menu latéral. Seules les sections contenant au moins une page publiée visible
  // par le profil sont retournées (une section vide ne mène nulle part). Marquées
  // dyn:true pour que le client puisse les distinguer des sections de menus.json.
  // L'icône MUI choisie à la création est stockée dans la colonne libre Champs02.
  const rslSections = await lireSql(
    `select r.Valeur, r.Membre, r.Rang, isnull(r.Champs02,'') as Icone
     from Param_Rubriques r
     where r.Nom_Controle='SP_Menu_Portail'
       and exists (select 1 from SP_Page p
                   where p.Menu_Parent = r.Valeur and p.Statut_Page='PUBLIE'
                     and ( @p_pr = '1'
                           or isnull(p.Acces_Personnalise,'true')='false'
                           or exists (select 1 from SP_Page_Droit d
                                      where d.Cod_Page=p.Cod_Page and d.Cod_Profile=@p_pr
                                        and isnull(d.Consulter,'false')='true') ))
     order by r.Rang, r.Membre`,
    [{ param: "p_pr", sqlType: sql.NVarChar, valeur: String(codProfile ?? "") }]
  );
  const sections = (rslSections.data ?? []).map((s: any) => ({
    name_ecran: String(s.Valeur ?? ""),
    text_ecran: String(s.Membre ?? ""),
    typ_ecran: "MNU",
    parent: "",
    rang: s.Rang ?? 99,
    img: String(s.Icone ?? ""),
    dyn: true,
  }));
  return res.send({ result: true, data: [...sections, ...menus], fields: [], sort: "succès" });
}

/* -------------------------------------------------------------------------- */
/* Métadonnées publiées d'une page (moteur de rendu)                          */
/* -------------------------------------------------------------------------- */
export async function sp_page_meta(req: Request, res: Response) {
  const { erreur, agent, meta } = await metaPubliee(req, "Consulter");
  if (erreur || !meta) return refus(res, erreur ?? "Page introuvable");
  // Droits du profil courant (pour l'activation des boutons côté client)
  const droits: { [a: string]: boolean } = {};
  for (const a of ["Consulter", "Creer", "Modifier", "Supprimer", "Valider", "Imprimer", "GED"] as const) {
    droits[a] = await verifierDroit(meta.page.Cod_Page, agent.codProfile, a);
  }
  // On ne publie jamais les requêtes des sources métier au client
  const champs = meta.champs.map((c) => ({ ...c }));
  return res.send({
    result: true,
    data: [{
      page: meta.page,
      tables: meta.tables,
      colonnes: meta.colonnes,
      champs,
      validations: meta.validations,
      droits,
    }],
    fields: [],
    sort: "succès",
  });
}

/* -------------------------------------------------------------------------- */
/* Liste paginée des documents                                                */
/* -------------------------------------------------------------------------- */
export async function sp_document_liste(req: Request, res: Response) {
  const { erreur, agent, meta } = await metaPubliee(req, "Consulter");
  if (erreur || !meta) return refus(res, erreur ?? "Page introuvable");
  const tEnt = tableEnt(meta);
  const cols = colonnesMetier(meta, "ENT");
  const nomsOk = new Set(cols.map((c) => c.Nom_Colonne));
  // Colonnes affichées : champs d'entête visibles en grille + techniques
  const visibles = meta.champs
    .filter((c) => c.Cod_Table === "ENT" && c.Visible_Grille === "true" && c.Nom_Colonne && nomsOk.has(c.Nom_Colonne))
    .sort((a, b) => a.Rang_Grille - b.Rang_Grille)
    .map((c) => `t.${qn(c.Nom_Colonne!)} as [${c.Libelle.replace(/]/g, "]]")}]`);
  // Nom de l'agent (comme les listes standards) : jointure dès qu'un champ
  // Matricule est visible, inséré juste après la colonne Matricule.
  const avecAgent = nomsOk.has("Matricule");
  if (avecAgent) {
    const idx = visibles.findIndex((v) => v.startsWith("t.[Matricule]"));
    visibles.splice(idx >= 0 ? idx + 1 : 0, 0, `isnull(ag.Nom,'') as [Nom]`);
  }
  const selectCols = [
    "t.[Num_Doc] as [N°]",
    "dbo.FindRubrique('Statut_Signature', isnull(t.[Statut],'')) as [Statut]",
    ...visibles,
    "t.[Dat_Crea] as [Créé le]",
    "t.[Created_By] as [Créé par]",
  ].join(", ");
  // Filtres : uniquement sur colonnes déclarées, valeurs paramétrées et typées.
  //   <col>__Du / <col>__Au : plage de dates sur une colonne date déclarée ;
  //   Statut               : critère technique (prefix match) si un champ
  //                          d'entête lié à Statut est déclaré critère.
  const statutCritere = meta.champs.some(
    (c) => c.Cod_Table === "ENT" && c.Nom_Colonne === "Statut" && c.estCritere === "true"
  );
  const filtres: { [k: string]: any } = req.body?.filtres ?? {};
  const wheres: string[] = ["t.[id_Societe]=@p_idSoc"];
  const params: { param: string; sqlType: any; valeur: any }[] = [
    { param: "p_idSoc", sqlType: sql.Int, valeur: Number(agent.id_Societe) },
  ];
  let i = 0;
  for (const [nom, val] of Object.entries(filtres)) {
    if (val === undefined || val === null || String(val) === "") continue;
    // Plage de dates : <col>__Du / <col>__Au
    const mPlage = /^(.+)__(Du|Au)$/.exec(nom);
    if (mPlage && nomsOk.has(mPlage[1])) {
      const col = cols.find((c) => c.Nom_Colonne === mPlage[1])!;
      if (!["date", "datetime", "smalldatetime"].includes(col.Typ_Sql.toLowerCase())) continue;
      const d = new Date(val);
      if (isNaN(d.getTime())) continue;
      i++;
      wheres.push(`convert(date, t.${qn(col.Nom_Colonne)}) ${mPlage[2] === "Du" ? ">=" : "<="} @p_f${i}`);
      params.push({ param: `p_f${i}`, sqlType: sql.Date, valeur: d });
      continue;
    }
    // Critère technique Statut (déclaré critère par un champ lié)
    if (nom === "Statut" && statutCritere) {
      i++;
      wheres.push(`isnull(t.[Statut],'') like @p_f${i} + '%'`);
      params.push({ param: `p_f${i}`, sqlType: sql.NVarChar, valeur: String(val) });
      continue;
    }
    if (!nomsOk.has(nom)) continue;
    const col = cols.find((c) => c.Nom_Colonne === nom)!;
    i++;
    const typ = col.Typ_Sql.toLowerCase();
    if (["date", "datetime", "smalldatetime"].includes(typ)) {
      // Critère date : égalité sur le jour (la valeur arrive en ISO du DatePicker)
      const d = new Date(val);
      if (isNaN(d.getTime())) continue;
      wheres.push(`convert(date, t.${qn(nom)}) = @p_f${i}`);
      params.push({ param: `p_f${i}`, sqlType: sql.Date, valeur: d });
    } else if (["int", "bigint", "float", "decimal"].includes(typ) &&
               !isNaN(Number(String(val).replace(",", ".")))) {
      wheres.push(`t.${qn(nom)} = @p_f${i}`);
      params.push({ param: `p_f${i}`, sqlType: sql.Float, valeur: Number(String(val).replace(",", ".")) });
    } else {
      wheres.push(`t.${qn(nom)} like @p_f${i}`);
      params.push({ param: `p_f${i}`, sqlType: sql.NVarChar, valeur: `%${String(val)}%` });
    }
  }
  // Cloisonnement : un non-TeamLeader ne voit que ses documents (si Matricule existe)
  if (nomsOk.has("Matricule") && agent.TeamLeader !== "true" && String(agent.codProfile) !== "1") {
    wheres.push("t.[Matricule]=@p_mat");
    params.push({ param: "p_mat", sqlType: sql.NVarChar, valeur: agent.Matricule });
  }
  const page = Math.max(1, Number(req.body?.page ?? 1) || 1);
  const pageSize = Math.min(200, Math.max(1, Number(req.body?.pageSize ?? 50) || 50));
  const jointureAgent = avecAgent
    ? ` outer apply (select Nom_Agent + ' ' + Prenom_Agent as Nom from dbo.RH_Agent a
       where a.id_Societe = t.id_Societe and a.Matricule = t.Matricule) ag`
    : "";
  const rsl = await lireSql(
    `select ${selectCols} from ${qn(tEnt.Nom_Physique)} t${jointureAgent}
     where ${wheres.join(" and ")}
     order by t.[Dat_Crea] desc
     offset @p_off rows fetch next @p_ps rows only`,
    [
      ...params,
      { param: "p_off", sqlType: sql.Int, valeur: (page - 1) * pageSize },
      { param: "p_ps", sqlType: sql.Int, valeur: pageSize },
    ]
  );
  if (!rsl.result) return refus(res, "Erreur de chargement de la liste");
  return res.send({ ...rsl, page, pageSize });
}

/* -------------------------------------------------------------------------- */
/* Chargement d'un document                                                   */
/* -------------------------------------------------------------------------- */
export async function sp_get_document(req: Request, res: Response) {
  const { erreur, agent, meta } = await metaPubliee(req, "Consulter");
  if (erreur || !meta) return refus(res, erreur ?? "Page introuvable");
  const numDoc = String(req.body?.numDoc ?? "");
  const r = await lireDocument(meta, numDoc, agent);
  if (!r.result) return refus(res, r.message ?? "Document introuvable");
  // Recalcul des champs calculés non persistés (affichage toujours à jour)
  const ctx: TSpContexte = { entete: r.entete, details: r.details! };
  recalculer(meta, ctx);
  return res.send({ result: true, entete: ctx.entete, details: ctx.details, fields: [], sort: "succès" });
}

/* -------------------------------------------------------------------------- */
/* Validation serveur sans enregistrement (pré-contrôle du client)            */
/* -------------------------------------------------------------------------- */
export async function sp_validate_document(req: Request, res: Response) {
  const { erreur, agent, meta } = await metaPubliee(req, "Modifier");
  if (erreur || !meta) return refus(res, erreur ?? "Page introuvable");
  const entete = req.body?.entete ?? {};
  const details = req.body?.details ?? {};
  const ctx: TSpContexte = { entete, details };
  recalculer(meta, ctx);
  const v = await executerValidations(meta, ctx, agent);
  return res.send({
    result: v.erreurs.length === 0,
    data: v.erreurs,
    avertissements: v.avertissements,
    fields: [],
    sort: "succès",
  });
}

/* -------------------------------------------------------------------------- */
/* Enregistrement transactionnel (entête + détails)                           */
/* -------------------------------------------------------------------------- */
export async function sp_save_document(req: Request, res: Response) {
  const statutDemande = String(req.body?.statut ?? "");
  // Droit : création si pas de Num_Doc, sinon modification ; soumission = Valider
  const numDoc = String(req.body?.entete?.Num_Doc ?? "").trim();
  const action = statutDemande === "SS" ? "Valider" : numDoc === "" ? "Creer" : "Modifier";
  const { erreur, agent, meta } = await metaPubliee(req, action);
  if (erreur || !meta) return refus(res, erreur ?? "Page introuvable");
  if (meta.page.Act_Enregistrer !== "true" && action !== "Valider") {
    return refus(res, "L'enregistrement est désactivé pour cette page.");
  }
  if (statutDemande === "SS" && meta.page.Act_Soumettre !== "true") {
    return refus(res, "La soumission est désactivée pour cette page.");
  }
  const r = await enregistrerDocument(
    meta,
    req.body?.entete ?? {},
    req.body?.details ?? {},
    statutDemande || null,
    agent
  );
  return res.send({ ...r, fields: [], sort: r.result ? "succès" : r.message });
}

/* -------------------------------------------------------------------------- */
/* Suppression d'un document                                                  */
/* -------------------------------------------------------------------------- */
export async function sp_delete_document(req: Request, res: Response) {
  const { erreur, agent, meta } = await metaPubliee(req, "Supprimer");
  if (erreur || !meta) return refus(res, erreur ?? "Page introuvable");
  const numDoc = String(req.body?.numDoc ?? "");
  if (!numDoc) return refus(res, "Numéro de document manquant");
  const r = await supprimerDocument(meta, numDoc, agent);
  return res.send({ ...r, data: [], fields: [], sort: r.result ? "succès" : r.message });
}

/* -------------------------------------------------------------------------- */
/* Exécution d'une source métier autorisée (champ SOURCE / ComboBox dynamique)*/
/* -------------------------------------------------------------------------- */
export async function sp_exec_source(req: Request, res: Response) {
  const agent = agentDepuis(req);
  const codSource = String(req.body?.codSource ?? "");
  const r = await executerSource(codSource, req.body?.params ?? {}, agent);
  if (!r.ok) return refus(res, r.message ?? "Erreur de la source");
  return res.send({
    result: true,
    data: r.typRetour === "TABLE" ? r.data : [{ valeur: r.valeur }],
    fields: [],
    sort: "succès",
  });
}
