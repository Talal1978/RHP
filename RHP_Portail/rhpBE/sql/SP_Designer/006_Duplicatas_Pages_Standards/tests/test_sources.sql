/* Test unitaire des 10 sources du package duplicatas - lecture seule */
SET NOCOUNT ON;
DECLARE @id_Societe int = 3068;
DECLARE @Matricule nvarchar(20) = 'D0002';
DECLARE @Deb nvarchar(50) = '2026-08-03T00:00:00.000Z';   -- lundi 03/08/2026
DECLARE @Fin nvarchar(50) = '2026-08-14T00:00:00.000Z';   -- vendredi 14/08/2026
DECLARE @DebPm nvarchar(2) = 'am';
DECLARE @FinPm nvarchar(2) = 'pm';
DECLARE @Typ nvarchar(10) = 'CAD';
DECLARE @DatRef nvarchar(50) = @Deb;

print '--- sp_cng_repos ---';
with d as (
  select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb,
         convert(date, dateadd(hour, 12, convert(datetimeoffset, @Fin))) as Fin
),
j as (
  select d.Deb as Jour from d
  union all
  select dateadd(day, 1, j.Jour) from j join d on j.Jour < d.Fin
),
agg as (
  select isnull(sum(case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = '0' then 1 else 0 end), 0) as Repos
  from j
  cross join (select isnull(JourOuvrables, '1;1;1;1;1;1;0') as JourOuvrables
              from dbo.Param_Societe where id_Societe = @id_Societe) s
)
select convert(int, a.Repos * case when isnull(t.ded, 1) = 1 then 1 else 0 end) as nb
from agg a
outer apply (select top 1 convert(int, isnull(deductibleDuConge, 1)) as ded
             from dbo.RH_Conge_Type where Typ_Conge = @Typ) t
option (maxrecursion 0);

print '--- sp_cng_feries ---';
with d as (
  select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb,
         convert(date, dateadd(hour, 12, convert(datetimeoffset, @Fin))) as Fin
),
j as (
  select d.Deb as Jour from d
  union all
  select dateadd(day, 1, j.Jour) from j join d on j.Jour < d.Fin
),
jf as (
  select convert(date, f.DatDeb) as d1, convert(date, f.DatFin) as d2
  from dbo.Sys_JourFeries((select Deb from d), @id_Societe) f
  union
  select convert(date, f.DatDeb), convert(date, f.DatFin)
  from dbo.Sys_JourFeries((select Fin from d), @id_Societe) f
),
j2 as (
  select j.Jour,
         case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = '0' then 1 else 0 end as EstRepos,
         case when exists (select 1 from jf where j.Jour between jf.d1 and jf.d2) then 1 else 0 end as EstFerie
  from j
  cross join (select isnull(JourOuvrables, '1;1;1;1;1;1;0') as JourOuvrables
              from dbo.Param_Societe where id_Societe = @id_Societe) s
),
agg as (
  select isnull(sum(case when j2.EstRepos = 1 then 0 else j2.EstFerie end), 0) as Feries
  from j2
)
select convert(int, a.Feries * case when isnull(t.ded, 1) = 1 then 1 else 0 end) as nb
from agg a
outer apply (select top 1 convert(int, isnull(deductibleDuConge, 1)) as ded
             from dbo.RH_Conge_Type where Typ_Conge = @Typ) t
option (maxrecursion 0);

print '--- sp_cng_duree ---';
with d as (
  select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb,
         convert(date, dateadd(hour, 12, convert(datetimeoffset, @Fin))) as Fin
),
j as (
  select d.Deb as Jour from d
  union all
  select dateadd(day, 1, j.Jour) from j join d on j.Jour < d.Fin
),
jf as (
  select convert(date, f.DatDeb) as d1, convert(date, f.DatFin) as d2
  from dbo.Sys_JourFeries((select Deb from d), @id_Societe) f
  union
  select convert(date, f.DatDeb), convert(date, f.DatFin)
  from dbo.Sys_JourFeries((select Fin from d), @id_Societe) f
),
j2 as (
  select j.Jour,
         case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = '0' then 1 else 0 end as EstRepos,
         case when exists (select 1 from jf where j.Jour between jf.d1 and jf.d2) then 1 else 0 end as EstFerie
  from j
  cross join (select isnull(JourOuvrables, '1;1;1;1;1;1;0') as JourOuvrables
              from dbo.Param_Societe where id_Societe = @id_Societe) s
),
agg as (
  select datediff(day, d.Deb, d.Fin) + 1
           - case when @DebPm = 'pm' then 0.5 else 0 end
           - case when @FinPm = 'am' then 0.5 else 0 end as Glob,
         isnull(sum(j2.EstRepos), 0) as Repos,
         isnull(sum(case when j2.EstRepos = 1 then 0 else j2.EstFerie end), 0) as Feries
  from j2 cross join d
  group by d.Deb, d.Fin
)
select convert(float, case when isnull(t.ded, 1) = 0 then 0
                           when a.Glob - a.Repos - a.Feries < 0 then 0
                           else a.Glob - a.Repos - a.Feries end) as nb
from agg a
outer apply (select top 1 convert(int, isnull(deductibleDuConge, 1)) as ded
             from dbo.RH_Conge_Type where Typ_Conge = @Typ) t
option (maxrecursion 0);

print '--- sp_solde_conge_date ---';
select isnull(min(c.Solde_Conge), 0) as Solde_Conge
from (select convert(date, dateadd(hour, 12, convert(datetimeoffset, @DatRef))) as DatRef) d
cross apply dbo.Sys_Rh_Conge(@id_Societe, d.DatRef) c
where c.Matricule = @Matricule;

print '--- sp_cng_periode_cloturee ---';
select isnull(dbo.Sys_Conge_CheckPeriode(@id_Societe, d.Deb, d.Deb), 0) as nb
from (select convert(smalldatetime, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb) d;

print '--- sp_cng_controle_paie ---';
select case
  when (select top 1 Valeur from dbo.Param_General where Cod_Param = 'Autoriser_SaisieCongeApresPaie') = 'O' then 1
  when p.DatDernierePaie is null then 1
  when d.Deb > convert(date, p.DatDernierePaie) then 1
  else 0 end as ok
from (select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb) d
outer apply (select top 1 c.Cod_Plan_Paie
             from dbo.Sys_Rh_Conge(@id_Societe, d.Deb) c
             where c.Matricule = @Matricule) c
outer apply (select top 1 pp.DatDernierePaie
             from dbo.RH_Param_Plan_Paie pp
             where pp.id_Societe = @id_Societe and pp.Cod_Plan_Paie = c.Cod_Plan_Paie) p;

print '--- sp_avances_encours ---';
select isnull(sum(isnull(Montant_Avance, 0) - isnull(Reglement, 0)), 0) as mnt
from dbo.RH_Paie_Avance
where id_Societe = @id_Societe and Matricule = @Matricule;

print '--- sp_prets_encours ---';
select isnull(sum(isnull(Montant_Pret, 0) - isnull(Reglement, 0)), 0) as mnt
from dbo.RH_Pret_Demande
where id_Societe = @id_Societe and Matricule = @Matricule;

print '--- sp_dernier_salaire_av ---';
select isnull(sn.DernierSalaire, 0) as dernier_salaire
from dbo.RH_Agent a
outer apply (select SalNet, Avance from dbo.RH_Param_Plan_Paie p
             where p.Cod_Plan_Paie = a.Plan_Paie and p.id_Societe = a.id_Societe) p
outer apply (select top 1 d0.Cod_Preparation as LastPaie
             from dbo.RH_Preparation_Paie_Detail d0
             where d0.id_Societe = a.id_Societe and d0.Matricule = a.Matricule
             order by d0.Cod_Preparation desc) lp
outer apply (select sum(d1.Valeur) as DernierSalaire
             from dbo.RH_Preparation_Paie_Detail d1
             where d1.id_Societe = a.id_Societe and d1.Matricule = a.Matricule
               and (d1.Cod_Rubrique = isnull(p.SalNet, '') or d1.Cod_Rubrique = isnull(p.Avance, ''))
               and d1.Cod_Preparation = lp.LastPaie) sn
where a.id_Societe = @id_Societe and a.Matricule = @Matricule;

print '--- sp_dernier_salaire_pr ---';
select isnull(sn.DernierSalaire, 0) as dernier_salaire
from dbo.RH_Agent a
outer apply (select SalNet, Pret from dbo.RH_Param_Plan_Paie p
             where p.Cod_Plan_Paie = a.Plan_Paie and p.id_Societe = a.id_Societe) p
outer apply (select top 1 d0.Cod_Preparation as LastPaie
             from dbo.RH_Preparation_Paie_Detail d0
             where d0.id_Societe = a.id_Societe and d0.Matricule = a.Matricule
             order by d0.Cod_Preparation desc) lp
outer apply (select sum(d1.Valeur) as DernierSalaire
             from dbo.RH_Preparation_Paie_Detail d1
             where d1.id_Societe = a.id_Societe and d1.Matricule = a.Matricule
               and (d1.Cod_Rubrique = isnull(p.SalNet, '') or d1.Cod_Rubrique = isnull(p.Pret, ''))
               and d1.Cod_Preparation = lp.LastPaie) sn
where a.id_Societe = @id_Societe and a.Matricule = @Matricule;
GO
