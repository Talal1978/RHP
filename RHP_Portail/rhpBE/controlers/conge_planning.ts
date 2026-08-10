import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import { Societes } from "../src/types";

/**
 * Planning des congés par collaborateur.
 *
 * Retourne, pour une période donnée (typiquement un mois) :
 * - agents  : le collaborateur connecté + (s'il est TeamLeader) les membres de
 *   son équipe (entités de sa branche hiérarchique, même logique que les zooms).
 * - conges  : les congés (hors brouillons et rejetés) chevauchant la période.
 * - feries  : les jours fériés définis sur la fiche société (Sys_JourFeries).
 * - jourOuvrables : semaine type de la société (1 = travaillé, lun..dim).
 */
export async function conge_planning(req: Request, res: Response) {
  let { Matricule, Dat_Du, Dat_Au } = req.body;
  Matricule = Matricule || "";
  if (controleInjection(Matricule).result === false)
    return res.send({ result: false, message: "Injection détectée dans Matricule" });

  const { processId, ...theAgent } = req.params;
  const idSocNum = Number(theAgent?.id_Societe || 0);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  const isTeamLeader = String(theAgent.TeamLeader).toLowerCase() === "true";

  const dateJour = new Date();
  Dat_Du = estDate(Dat_Du)
    ? toSqlDateFormat(Dat_Du)
    : toSqlDateFormat(new Date(dateJour.getFullYear(), dateJour.getMonth(), 1));
  Dat_Au = estDate(Dat_Au)
    ? toSqlDateFormat(Dat_Au)
    : toSqlDateFormat(new Date(dateJour.getFullYear(), dateJour.getMonth() + 1, 0));

  // Périmètre des collaborateurs visibles (alias a = RH_Agent)
  const params: { param: string; sqlType: any; valeur: any }[] = [
    { param: "id_Societe", sqlType: Int, valeur: idSocNum },
    { param: "MatriculeAgent", sqlType: NVarChar, valeur: theAgent.Matricule },
  ];
  let whereAgents = "";
  if (!isTeamLeader) {
    // Collaborateur simple : uniquement son propre planning
    whereAgents = " and a.Matricule = @MatriculeAgent ";
  } else {
    // Manager : lui-même + les agents des entités de sa branche
    whereAgents = ` and (a.Matricule = @MatriculeAgent or a.Cod_Entite in (
      select Cod_Entite from Sys_Org_Entite s
      where ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif(@CodEntiteAgent,''),'8787uhuhunjj')+';%'
      and id_Societe = a.id_Societe)) `;
    params.push({
      param: "CodEntiteAgent",
      sqlType: NVarChar,
      valeur: theAgent.Cod_Entite || "",
    });
    // Filtre éventuel sur un collaborateur précis (reste borné à l'équipe)
    if (Matricule !== "") {
      whereAgents += " and a.Matricule = @Matricule ";
      params.push({ param: "Matricule", sqlType: NVarChar, valeur: Matricule });
    }
  }

  // Collaborateurs du planning (le manager en premier, puis ordre alphabétique)
  const rsAgents = await lireSql(
    `select a.Matricule, a.Nom_Agent, a.Prenom_Agent, isnull(e.Lib_Entite,'') as Entite
     from RH_Agent a
     left join Org_Entite e on e.id_Societe=a.id_Societe and e.Cod_Entite=a.Cod_Entite
     where a.id_Societe=@id_Societe and a.Dat_Sortie is null ${whereAgents}
     order by case when a.Matricule=@MatriculeAgent then 0 else 1 end, a.Nom_Agent, a.Prenom_Agent`,
    params
  );
  if (!rsAgents.result) return res.send(rsAgents);

  // Congés de ces collaborateurs chevauchant la période
  const rsConges = await lireSql(
    `select c.Matricule, c.Num_Conge, c.Dat_Deb_Conge, c.Dat_Fin_Conge,
       isnull(c.Typ_Conge,'CAD') as Typ_Conge,
       isnull(nullif(dbo.FindRubrique('Typ_Conge', c.Typ_Conge),''), isnull(c.Typ_Conge,'CAD')) as Lib_Type,
       isnull(c.Statut,'') as Statut,
       isnull(dbo.FindRubrique('Statut_Signature', c.Statut),'') as Lib_Statut
     from RH_Conge_Suivi c
     where c.id_Societe=@id_Societe
       and isnull(c.Statut,'') not in ('','RJ')
       and c.Dat_Deb_Conge <= @Dat_Au and c.Dat_Fin_Conge >= @Dat_Du
       and exists (select 1 from RH_Agent a where a.id_Societe=c.id_Societe and a.Matricule=c.Matricule ${whereAgents})
     order by c.Dat_Deb_Conge`,
    [
      ...params,
      { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
      { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ]
  );
  if (!rsConges.result) return res.send(rsConges);

  // Jours fériés de la fiche société, bornés à la période affichée
  const rsFeries = await lireSql(
    `select Lib_Jour, DatDeb, DatFin from dbo.Sys_JourFeries(@Dat_Du, @id_Societe)`,
    [
      { param: "id_Societe", sqlType: Int, valeur: idSocNum },
      { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    ]
  );
  const feries = (rsFeries.result ? rsFeries.data : []).filter((jf: any) => {
    const deb = new Date(jf.DatDeb);
    const fin = new Date(jf.DatFin);
    return deb <= new Date(Dat_Au) && fin >= new Date(Dat_Du);
  });

  const jourOuvrables = (
    Societes.find((s) => s.id_Societe === idSocNum)?.JourOuvrables || "1;1;1;1;1;1;0"
  ).split(";");

  return res.send({
    result: true,
    agents: rsAgents.data,
    conges: rsConges.data,
    feries,
    jourOuvrables,
    teamLeader: isTeamLeader,
  });
}
