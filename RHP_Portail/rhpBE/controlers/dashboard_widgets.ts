import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

/**
 * Données des widgets du tableau de bord.
 *
 * Sécurité / droits d'accès :
 * - L'identité (Matricule), la société et le rôle proviennent exclusivement du
 *   token JWT validé (req.params), jamais du corps de la requête.
 * - Liste blanche fermée des widgetId : aucune requête arbitraire
 *   (objet/champ/filtre) envoyée par le client n'est exécutée.
 * - scope "own"       : données personnelles, filtrées sur le matricule du JWT.
 * - scope "aggregate" : uniquement des comptages/agrégats sans donnée individuelle.
 * - scope "admin"     : données sensibles (paie), réservées au rôle Admin ;
 *   un agent non autorisé reçoit result:false.
 */

type WidgetScope = "own" | "aggregate" | "admin";

const WIDGET_SCOPES: Record<string, WidgetScope> = {
  "kpi-effectif": "aggregate",
  "kpi-absenteisme": "own",
  "kpi-conges-attente": "own",
  "kpi-prets-attente": "own",
  "chart-repartition-dept": "aggregate",
  "chart-evolution-absences": "own",
  "chart-top-rubriques": "admin",
  "chart-effectif-mois": "aggregate",
  "table-conges-recents": "own",
  "table-agents-recents": "aggregate",
};

const MOIS_FR = ["Jan", "Fév", "Mar", "Avr", "Mai", "Juin", "Juil", "Août", "Sep", "Oct", "Nov", "Déc"];

interface MonthlyRow {
  an: number;
  mois: number;
  value: number;
}

const buildMonthlySeries = (rows: MonthlyRow[], nbMois: number) => {
  const valuesByKey = new Map<string, number>();
  rows.forEach((r) => valuesByKey.set(`${r.an}-${r.mois}`, Number(r.value) || 0));

  const labels: string[] = [];
  const data: number[] = [];
  const now = new Date();
  for (let i = nbMois - 1; i >= 0; i--) {
    const dRef = new Date(now.getFullYear(), now.getMonth() - i, 1);
    labels.push(MOIS_FR[dRef.getMonth()]);
    data.push(valuesByKey.get(`${dRef.getFullYear()}-${dRef.getMonth() + 1}`) ?? 0);
  }
  return { labels, data };
};

export const getDashboardWidgetData = async (req: Request, res: Response) => {
  const { processId, ...theAgent } = req.params;
  const Matricule = theAgent?.Matricule || "";
  const id_Societe = Number(theAgent?.id_Societe || 0);
  const isAdmin = String(theAgent?.Typ_Role || "").toLowerCase() === "admin";
  const widgetId = String(req.body?.widgetId || "");

  if (isNaN(id_Societe) || id_Societe <= 0) {
    return res.status(400).send({ result: false, message: "id_Societe invalide" });
  }

  const scope = WIDGET_SCOPES[widgetId];
  if (!scope) {
    return res.send({ result: false, message: "Widget non pris en charge" });
  }
  if (scope === "admin" && !isAdmin) {
    return res.send({ result: false, message: "Accès non autorisé à ce widget" });
  }

  const paramsSoc = [{ param: "idSoc", sqlType: Int, valeur: id_Societe }];
  const paramsOwn = [...paramsSoc, { param: "Mat", sqlType: NVarChar, valeur: Matricule }];

  try {
    switch (widgetId) {
      case "kpi-effectif": {
        const rsl = await lireSql(
          `select count(*) as value from RH_Agent where id_Societe=@idSoc and Dat_Sortie is null`,
          paramsSoc
        );
        return res.send({ result: true, data: { value: rsl.data?.[0]?.value ?? 0, label: "collaborateurs" } });
      }

      case "kpi-absenteisme": {
        const rsl = await lireSql(
          `select isnull(sum(Duree_Conge),0) as value from RH_Conge_Suivi
           where id_Societe=@idSoc and Matricule=@Mat and isnull(Statut,'') not in ('','RJ')
             and month(Dat_Deb_Conge)=month(getdate()) and year(Dat_Deb_Conge)=year(getdate())`,
          paramsOwn
        );
        return res.send({ result: true, data: { value: rsl.data?.[0]?.value ?? 0, label: "jours ce mois" } });
      }

      case "kpi-conges-attente": {
        const rsl = await lireSql(
          `select count(*) as value from RH_Conge_Suivi where id_Societe=@idSoc and Matricule=@Mat and Statut='SS'`,
          paramsOwn
        );
        return res.send({ result: true, data: { value: rsl.data?.[0]?.value ?? 0, label: "demandes" } });
      }

      case "kpi-prets-attente": {
        const rsl = await lireSql(
          `select count(*) as value from RH_Pret_Demande where id_Societe=@idSoc and Matricule=@Mat and Statut='SS'`,
          paramsOwn
        );
        return res.send({ result: true, data: { value: rsl.data?.[0]?.value ?? 0, label: "demandes" } });
      }

      case "chart-repartition-dept": {
        const rsl = await lireSql(
          `select top 8 isnull(nullif(e.Lib_Entite,''),'Non affecté') as label, count(*) as value
           from RH_Agent a
           left join Org_Entite e on e.id_Societe=a.id_Societe and e.Cod_Entite=a.Cod_Entite
           where a.id_Societe=@idSoc and a.Dat_Sortie is null
           group by e.Lib_Entite order by value desc`,
          paramsSoc
        );
        const rows = rsl.data || [];
        return res.send({
          result: true,
          data: {
            labels: rows.map((r: any) => r.label),
            series: [{ label: "Effectifs", data: rows.map((r: any) => r.value) }],
          },
        });
      }

      case "chart-evolution-absences": {
        const rsl = await lireSql(
          `select year(Dat_Deb_Conge) as an, month(Dat_Deb_Conge) as mois, isnull(sum(Duree_Conge),0) as value
           from RH_Conge_Suivi
           where id_Societe=@idSoc and Matricule=@Mat and isnull(Statut,'') not in ('','RJ')
             and Dat_Deb_Conge >= dateadd(month, -5, datefromparts(year(getdate()), month(getdate()), 1))
           group by year(Dat_Deb_Conge), month(Dat_Deb_Conge)`,
          paramsOwn
        );
        const { labels, data } = buildMonthlySeries(rsl.data || [], 6);
        return res.send({ result: true, data: { labels, series: [{ label: "Jours d'absence", data }] } });
      }

      case "chart-effectif-mois": {
        const rsl = await lireSql(
          `with mois as (select 0 as n union all select n+1 from mois where n < 11)
           select year(dateadd(month,-n,datefromparts(year(getdate()),month(getdate()),1))) as an,
                  month(dateadd(month,-n,datefromparts(year(getdate()),month(getdate()),1))) as mois,
             (select count(*) from RH_Agent a where a.id_Societe=@idSoc
                and a.Dat_Entree < dateadd(month, 1-n, datefromparts(year(getdate()),month(getdate()),1))
                and (a.Dat_Sortie is null or a.Dat_Sortie >= dateadd(month, 1-n, datefromparts(year(getdate()),month(getdate()),1)))) as value
           from mois`,
          paramsSoc
        );
        const { labels, data } = buildMonthlySeries(rsl.data || [], 12);
        return res.send({ result: true, data: { labels, series: [{ label: "Effectif", data }] } });
      }

      case "chart-top-rubriques": {
        // Données de paie sensibles : déjà restreintes au rôle Admin ci-dessus.
        const periode = await lireSql(
          `select top 1 Annee_Paie, Mois_Paie from RH_Preparation_Paie where id_Societe=@idSoc order by Annee_Paie desc, Mois_Paie desc`,
          paramsSoc
        );
        const an = periode.data?.[0]?.Annee_Paie;
        const mois = periode.data?.[0]?.Mois_Paie;
        if (!an || !mois) {
          return res.send({ result: true, data: { labels: [], series: [{ label: "Montant", data: [] }] } });
        }
        const rsl = await lireSql(
          `select top 5 isnull(r.Lib_Rubrique, d.Cod_Rubrique) as label, sum(d.Valeur) as value
           from RH_Preparation_Paie_Detail d
           left join RH_Paie_Rubrique r on r.id_Societe=d.id_Societe and r.Cod_Rubrique=d.Cod_Rubrique
           where d.id_Societe=@idSoc and d.Annee_Paie=@an and d.Mois_Paie=@mois and isnull(r.Gain_Retenue,'G')='G'
             and r.Bulletin = 1 and d.Cod_Rubrique not like '%Cumul%'
           group by r.Lib_Rubrique, d.Cod_Rubrique order by value desc`,
          [...paramsSoc, { param: "an", sqlType: Int, valeur: an }, { param: "mois", sqlType: Int, valeur: mois }]
        );
        const rows = rsl.data || [];
        return res.send({
          result: true,
          data: {
            labels: rows.map((r: any) => r.label),
            series: [{ label: "Montant", data: rows.map((r: any) => Math.round(r.value)) }],
          },
        });
      }

      case "table-conges-recents": {
        const rsl = await lireSql(
          `select top 5
             isnull(nullif(dbo.FindRubrique('Typ_Conge', Typ_Conge),''), Typ_Conge) as type,
             convert(nvarchar(10), Dat_Deb_Conge, 103) as debut,
             convert(nvarchar(10), Dat_Fin_Conge, 103) as fin,
             isnull(nullif(dbo.FindRubrique('Statut_Signature', Statut),''), 'Brouillon') as statut
           from RH_Conge_Suivi
           where id_Societe=@idSoc and Matricule=@Mat
           order by Dat_Crea desc`,
          paramsOwn
        );
        return res.send({
          result: true,
          data: {
            columns: [
              { field: "type", header: "Type" },
              { field: "debut", header: "Début" },
              { field: "fin", header: "Fin" },
              { field: "statut", header: "Statut" },
            ],
            rows: rsl.data || [],
          },
        });
      }

      case "table-agents-recents": {
        const rsl = await lireSql(
          `select top 5 Nom_Agent + ' ' + Prenom_Agent as agent, isnull(e.Lib_Entite,'') as departement,
             convert(nvarchar(10), a.Dat_Entree, 103) as dateEmbauche
           from RH_Agent a
           left join Org_Entite e on e.id_Societe=a.id_Societe and e.Cod_Entite=a.Cod_Entite
           where a.id_Societe=@idSoc and a.Dat_Entree is not null
           order by a.Dat_Entree desc`,
          paramsSoc
        );
        return res.send({
          result: true,
          data: {
            columns: [
              { field: "agent", header: "Agent" },
              { field: "departement", header: "Département" },
              { field: "dateEmbauche", header: "Date d'embauche" },
            ],
            rows: rsl.data || [],
          },
        });
      }

      default:
        return res.send({ result: false, message: "Widget non pris en charge" });
    }
  } catch (error: any) {
    return res.send({ result: false, message: error.message });
  }
};
