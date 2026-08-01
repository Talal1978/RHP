import { Request, Response } from "express";
import {
  checkDateFormat,
  estDate,
  toSqlDateFormat,
} from "../modules/module_format";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
import { Societes, TSociete } from "../src/types";
import { getParam, IsNull } from "../modules/module_general";

export async function demande_conge_liste(req: Request, res: Response) {
  let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
  if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
  if (controleInjection(Cod_Entite).result === false) return res.send({ result: false, message: "Injection détectée dans Entité" });
  if (controleInjection(Statut).result === false) return res.send({ result: false, message: "Injection détectée dans Statut" });

  const { processId, ...theAgent } = req.params;
  const TblRef = "RH_Conge_Suivi";
  const idSocNum = Number(theAgent?.id_Societe || 0);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  let isOwn = false;
  // MatriculeWhere supprimé (code mort, la requête utilise directement @Matricule et @id_Societe)
  if (String(theAgent.TeamLeader).toLowerCase() !== "true") {
    Matricule = theAgent.Matricule;
    Cod_Entite = theAgent.Cod_Entite;
    isOwn = true;
  }

  Dat_Du = estDate(Dat_Du)
    ? toSqlDateFormat(Dat_Du)
    : toSqlDateFormat(new Date(1900, 0, 1));
  Dat_Au = estDate(Dat_Au)
    ? toSqlDateFormat(Dat_Au)
    : toSqlDateFormat(new Date(2045, 11, 31));
  Statut = Statut || "";

  let sqlStr = `select TOP 50 Num_Conge 'N° demande', ${isOwn ? "Matricule,Nom, " : ""}
    dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_Deb_Conge as 'Du', Dat_Fin_Conge as 'Au', 
Duree_Globale 'Durée totale', Repos_Hebdomadaire 'Repos hebdo.', 
Jours_Feries 'Jours fériés', Duree_Conge 'Congé' ${!isOwn ? ", isnull(o.Entité,'') as 'Entité'" : ""}, Commentaire
 from RH_Conge_Suivi c
 outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=c.id_Societe and Matricule=c.Matricule) r
 outer apply (select Lib_Entite as Entité from Org_Entite where id_Societe=c.id_Societe and Cod_Entite=c.Cod_Entite) o
where id_Societe=@id_Societe and Matricule like '%'+@Matricule and Dat_Deb_Conge between @Dat_Du and @Dat_Au and isnull(Statut,'') like @StatutPrefix Order by [Du] desc`;

  const rsl = await lireSql(sqlStr, [
    { param: "id_Societe", sqlType: Int, valeur: idSocNum },
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "StatutPrefix", sqlType: NVarChar, valeur: Statut + "%" },
    { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ...(isOwn ? [] : [{ param: "Cod_Entite", sqlType: NVarChar, valeur: Cod_Entite }]),
    ...(isOwn ? [] : [{ param: "AgentMatricule", sqlType: NVarChar, valeur: theAgent.Matricule }]),
  ]);
  res.send(rsl);
}

export async function get_conge_droits(req: Request, res: Response) {
  const { Dat_Deb_Conge, Matricule } = req.body;
  const { id_Societe } = req.params;

  const idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  let dateValue: Date;
  if (typeof Dat_Deb_Conge === 'string' && Dat_Deb_Conge.includes('/')) {
    const [d, m, y] = Dat_Deb_Conge.split('/');
    dateValue = new Date(Number(y), Number(m) - 1, Number(d));
  } else {
    dateValue = new Date(Dat_Deb_Conge);
  }

  const sqlStr = `select p.JourPaie,p.DatDernierePaie,c.* from dbo.Sys_Rh_Conge(@id_Societe,@Dat_Deb_Conge) c 
  outer apply(select top 1 * from RH_Param_Plan_Paie  where id_Societe=@id_Societe and Cod_Plan_Paie=c.Cod_Plan_Paie)p
  where Matricule=@Matricule`;
  const rsl = await lireSql(sqlStr, [
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "Dat_Deb_Conge", sqlType: SmallDateTime, valeur: dateValue },
    { param: "id_Societe", sqlType: Int, valeur: idSocNum },
  ]);
  return res.send(rsl);
}

export async function get_demande_conge(req: Request, res: Response) {
  const { Num_Conge } = req.body;
  const { processId, ...theAgent } = req.params;
  const idSocNum = Number(theAgent?.id_Societe || 0);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  let sqlStr = `SELECT Num_Conge,
  Matricule,
  Dat_Deb_Conge,
  Dat_Fin_Conge,
  isnull(Dat_Deb_am_pm,'am') Dat_Deb_am_pm,
  isnull(Dat_Fin_am_pm,'am') Dat_Fin_am_pm,
  Cod_Plan_Paie,
  isnull(JourPaie,1) as JourPaie,
  isnull(Duree_Globale,0) as Duree_Globale,
  isnull(Repos_Hebdomadaire,0) Repos_Hebdomadaire,
  isnull(Jours_Feries,0) as Jours_Feries,
  isnull(Duree_Conge,0) Duree_Conge,
  isnull(Commentaire,'') Commentaire,
  isnull(Typ_Conge,'CAD') Typ_Conge,
  isnull(Statut,'') Statut
  FROM RH_Conge_Suivi where Num_Conge=@Num_Conge and id_Societe=@id_Societe`;
  const rsl = await lireSql(sqlStr, [
    { param: "Num_Conge", sqlType: NVarChar, valeur: Num_Conge },
    { param: "id_Societe", sqlType: Int, valeur: idSocNum },
  ]);
  return res.send(rsl);
}

export async function save_demande_conge(req: Request, res: Response) {
  const { entete: _entete } = req.body;
  const { id_Societe, Matricule } = req.params;
  let { Num_Conge, ...entete } = _entete;

  const idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  let chk = await lireSql(
    `select dbo.Sys_Conge_CheckPeriode (@id_Societe,@Dat_Deb_Conge,@Dat_Deb_Conge) as nb`,
    [
      { param: "id_Societe", sqlType: Int, valeur: idSocNum },
      { param: "Dat_Deb_Conge", sqlType: SmallDateTime, valeur: entete.Dat_Deb_Conge },
    ]
  );
  if (!chk.result) {
    return res.send({ result: false, data: "Impossible de vérifier la période" });
  } else if (chk.data[0]["nb"] > 0) {
    return res.send({ result: false, data: "Dates de congé correspondant à une période clôturée" });
  }
  const Autoriser_SaisieCongeApresPaie = await getParam("Autoriser_SaisieCongeApresPaie");
  if (Autoriser_SaisieCongeApresPaie !== "O") {
    if (entete.Dat_Deb_Conge <= entete.LastDatePaie) {
      return res.send({
        result: false,
        data: "La date de début du congé doit être postérieure à la date de la dernière paie",
      });
    }
  }
  const detail = await Calcul(entete, idSocNum);

  if (detail.length === 0) {
    return res.send({ result: false, data: "Erreur calcul de congé" });
  }
  const DatDeb = toSqlDateFormat(entete.Dat_Deb_Conge);
  const DatFin = toSqlDateFormat(entete.Dat_Fin_Conge);
  if (!Num_Conge || Num_Conge === "") {
    const rsNum = await lireSql(
      `select 'C'+convert(nvarchar(10),@id_Societe)+'-'+convert(nvarchar(4),year(getdate()))+right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Conge_Suivi 
      outer apply(select RIGHT(Num_Conge,6) as racine)n
      where id_Societe=@id_Societe and year(Dat_Deb_Conge)=year(getdate()))f`,
      [{ param: "id_Societe", sqlType: Int, valeur: idSocNum }]
    );
    Num_Conge = rsNum?.data?.[0]?.racine;
  }

  const Sys_Conge_Check = await lireSql(
    `exec Sys_Conge_Check @Num_Conge,@Dat_Deb_Conge,@Dat_Fin_Conge,@Matricule,@id_Societe`,
    [
      { param: "Num_Conge", sqlType: NVarChar, valeur: Num_Conge },
      { param: "Dat_Deb_Conge", sqlType: SmallDateTime, valeur: DatDeb },
      { param: "Dat_Fin_Conge", sqlType: SmallDateTime, valeur: DatFin },
      { param: "Matricule", sqlType: NVarChar, valeur: entete.Matricule },
      { param: "id_Societe", sqlType: Int, valeur: idSocNum },
    ],
    true
  );
  if (Sys_Conge_Check.result && Sys_Conge_Check.data.length > 0) {
    return res.send({
      result: false,
      data: "Il existe au moins un congé en chevauchement avec cette demande : " + Sys_Conge_Check.data[0]["Num_Conge"],
    });
  }
  const rsEnt = await ecrireSql({
    tableName: "RH_Conge_Suivi",
    fields: { ...entete, Num_Conge, id_Societe: idSocNum },
    joinFields: ["Num_Conge", "id_Societe"],
    excludeFields: [],
    login: Matricule,
  });
  if (rsEnt.result) {
    const flgMaj = Math.floor(Math.random() * 10000);
    for (const d of detail) {
      await ecrireSql({
        tableName: "RH_Conge_Suivi_Detail",
        fields: { ...d, id_Societe: idSocNum, Matricule, Num_Conge, Flag_Maj: flgMaj },
        joinFields: ["Num_Conge", "id_Societe", "Dat_Deb"],
        excludeFields: ["RowId"],
        login: Matricule,
      });
    }

    await lireSql(
      `delete from RH_Conge_Suivi_Detail where id_Societe=@id_Societe and Num_Conge=@Num_Conge and Flag_Maj!=@flgMaj`,
      [
        { param: "id_Societe", sqlType: Int, valeur: idSocNum },
        { param: "Num_Conge", sqlType: NVarChar, valeur: Num_Conge },
        { param: "flgMaj", sqlType: Int, valeur: flgMaj },
      ]
    );
    await lireSql(`exec Sys_Conge_MajConso @Matricule,@id_Societe`, [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "id_Societe", sqlType: Int, valeur: idSocNum },
    ]);
    if (entete.Statut === "SS")
      await sousmettre_signature("C", Num_Conge, String(idSocNum), Matricule);
    return res.send(rsEnt);
  }
}

export async function delete_demande_conge(req: Request, res: Response) {
  const { Num_Conge } = req.body;
  const { id_Societe } = req.params;

  const idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  const rsl = await lireSql(
    `delete from RH_Conge_Suivi where Num_Conge=@Num_Conge and id_Societe=@id_Societe`,
    [
      { param: "Num_Conge", sqlType: NVarChar, valeur: Num_Conge },
      { param: "id_Societe", sqlType: Int, valeur: idSocNum },
    ]
  );
  if (rsl.result) {
    return res.send({ result: true, data: Num_Conge });
  } else return res.send({ result: false, data: rsl.sort });
}

type TEntete = {
  Num_Conge: string;
  Matricule: string;
  Dat_Deb_Conge: Date;
  Dat_Fin_Conge: Date;
  Dat_Deb_am_pm: string;
  Dat_Fin_am_pm: string;
  Cod_Plan_Paie: string;
  JourPaie: number;
  Duree_Globale?: number;
  Repos_Hebdomadaire?: number;
  Jours_Feries?: number;
  LastDatePaie?: Date;
  Duree_Conge?: number;
  Commentaire?: string;
  Typ_Conge?: string;
  Statut?: string;
};

type ligDemande = {
  Dat_Deb: Date;
  Dat_Fin: Date;
  Duree_Globale: number;
  Repos_Hebdomadaire: number;
  Jours_Feries: number;
  Duree_Conge: number;
};

export async function calcul_conge(req: Request, res: Response) {
  const { entete } = req.body;
  const { id_Societe } = req.params;

  const idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }

  const lignes = await Calcul(entete, idSocNum);
  return res.send({ lignes, entete });
}

async function Calcul(entete: TEntete, id_Societe: number): Promise<ligDemande[]> {
  if (entete.Statut !== "" && entete.Statut !== "SS") return [];

  const Societe: TSociete = Societes.find((s) => s.id_Societe === id_Societe)!;
  const lig: ligDemande[] = [];

  entete.Duree_Globale = 0;
  entete.Repos_Hebdomadaire = 0;
  entete.Jours_Feries = 0;
  entete.Duree_Conge = 0;

  const datDeb = new Date(entete.Dat_Deb_Conge);
  const datFin = new Date(entete.Dat_Fin_Conge);

  if (isNaN(entete.JourPaie)) entete.JourPaie = 1;
  if (!checkDateFormat(datDeb)) return [];
  if (!checkDateFormat(datFin)) return [];

  const jourPaieDate = new Date(datDeb.getFullYear(), datDeb.getMonth(), entete.JourPaie);
  if (!checkDateFormat(jourPaieDate)) return [];

  let DureeGlobal = 0;
  let DureeDetail = 0;
  if (datDeb > datFin) return [];

  DureeGlobal = Math.floor((datFin.getTime() - datDeb.getTime()) / (1000 * 3600 * 24)) + 1;

  if (entete.Dat_Deb_am_pm === "pm") DureeGlobal -= 0.5;
  if (entete.Dat_Fin_am_pm === "am") DureeGlobal -= 0.5;

  const JoursOuvres = Societe.JourOuvrables.split(";").map(Number);
  let nbrp = 0;
  let nbfr = 0;

  const jrs = await lireSql(
    `SELECT * FROM dbo.Sys_JourFeries(@datDeb, @id_Societe)`,
    [
      { param: "datDeb", sqlType: NVarChar, valeur: datDeb.toISOString().split('T')[0] },
      { param: "id_Societe", sqlType: Int, valeur: Societe.id_Societe },
    ]
  );

  const TblJourFeries: {
    Lib_Jour: string;
    DatDeb: Date;
    DatFin: Date;
    WeekEnds: number;
    JourFeries: number;
    Duree: number;
    Hijir: number;
  }[] = jrs.data.map((jf: any) => ({
    ...jf,
    DatDeb: new Date(jf.DatDeb),
    DatFin: new Date(jf.DatFin)
  }));

  let DatFinPaie = new Date(datDeb);
  DatFinPaie.setMonth(DatFinPaie.getMonth() + 1);
  DatFinPaie.setDate(entete.JourPaie);
  DatFinPaie.setDate(DatFinPaie.getDate() - 1);

  let DatDebPaie = new Date(datDeb);
  let k = 0;

  const Tbl_RH_Conge_Type = await lireSql(
    `SELECT * FROM RH_Conge_Type WHERE Typ_Conge = @Typ_Conge`,
    [{ param: "Typ_Conge", sqlType: NVarChar, valeur: entete.Typ_Conge }]
  );

  let deductibleDuConge = true;
  if (Tbl_RH_Conge_Type.result && Tbl_RH_Conge_Type.data.length > 0) {
    deductibleDuConge = IsNull(Tbl_RH_Conge_Type.data[0]["deductibleDuConge"], true);
  }

  while (DatFinPaie.getTime() >= DatDebPaie.getTime() && DatFinPaie.getTime() < datFin.getTime()) {
    const isFirstPeriodPM = DatDebPaie.getTime() === datDeb.getTime() && entete.Dat_Deb_am_pm === "pm";
    const duree = Math.floor((DatFinPaie.getTime() - DatDebPaie.getTime()) / (1000 * 3600 * 24)) + (isFirstPeriodPM ? 0.5 : 1);

    lig.push({
      Dat_Deb: new Date(DatDebPaie),
      Dat_Fin: new Date(DatFinPaie),
      Duree_Globale: duree,
      Repos_Hebdomadaire: 0,
      Jours_Feries: 0,
      Duree_Conge: 0,
    });

    DureeDetail += lig[k].Duree_Globale;
    DatDebPaie = new Date(DatFinPaie);
    DatDebPaie.setDate(DatDebPaie.getDate() + 1);
    DatFinPaie = new Date(DatDebPaie);
    DatFinPaie.setMonth(DatFinPaie.getMonth() + 1);
    DatFinPaie.setDate(DatFinPaie.getDate() - 1);
    k++;
  }

  lig.push({
    Dat_Deb: new Date(DatDebPaie),
    Dat_Fin: new Date(datFin),
    Duree_Globale: DureeGlobal - DureeDetail,
    Repos_Hebdomadaire: 0,
    Jours_Feries: 0,
    Duree_Conge: 0,
  });

  const normalizeDate = (d: Date): number => {
    return new Date(d.getFullYear(), d.getMonth(), d.getDate()).getTime();
  };

  for (let i = 0; i < lig.length; i++) {
    const lng = lig[i];
    let oDate = new Date(lng.Dat_Deb);
    const finTime = normalizeDate(lng.Dat_Fin);

    while (normalizeDate(oDate) <= finTime) {
      let estJourRepos = false;
      let estJourFerie = false;

      if (JoursOuvres.length === 7) {
        const indexJour = oDate.getDay() === 0 ? 6 : oDate.getDay() - 1;
        if (JoursOuvres[indexJour] === 0) {
          estJourRepos = true;
        }
      }

      const oDateTime = normalizeDate(oDate);
      if (TblJourFeries.some((jf) => oDateTime >= normalizeDate(jf.DatDeb) && oDateTime <= normalizeDate(jf.DatFin))) {
        estJourFerie = true;
      }

      if (estJourRepos) {
        lng.Repos_Hebdomadaire++;
        nbrp++;
      } else if (estJourFerie) {
        lng.Jours_Feries++;
        nbfr++;
      }

      oDate.setDate(oDate.getDate() + 1);
    }

    lng.Duree_Conge = Math.max(0, lng.Duree_Globale - lng.Jours_Feries - lng.Repos_Hebdomadaire);
  }

  entete.Duree_Globale = DureeGlobal;
  entete.Repos_Hebdomadaire = deductibleDuConge ? nbrp : 0;
  entete.Jours_Feries = deductibleDuConge ? nbfr : 0;
  entete.Duree_Conge = deductibleDuConge ? Math.max(0, DureeGlobal - nbrp - nbfr) : 0;

  return lig;
}
