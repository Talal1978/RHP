/* ============================================================================
   RHP - Module SP_ : deploiement des duplicatas des pages standards du portail
   ----------------------------------------------------------------------------
   Demande        : DUP-PAGES-2026-08
   Objet          : creer, dans la section "Pages specifiques", un duplicata de
                    chaque page document standard du portail, produit
                    EXCLUSIVEMENT avec les mecanismes du Designer de pages
                    (module SP_) - les pages standards et leurs tables ne sont
                    ni touchees ni alterees :
                      1. DUP_CONGE           (miroir RH_Demande_Conge)
                      2. DUP_NOTE_FRAIS      (miroir Note_Frais)
                      3. DUP_DECLARATION_AT  (miroir RH_Declaration_AT)
                      4. DUP_DOSSIER_MALADIE (miroir RH_Dossier_Maladie)
                      5. DUP_AVANCE          (miroir Demande_Avance)
                      6. DUP_PRET            (miroir Demande_Pret)
                    Chaque duplicata possede ses propres tables metier
                    (SP_X**_Ent / _Det_), ses propres codes document (X**) et
                    ses propres circuits de signature (miroir des circuits
                    standards dans les societes ou ceux-ci existent).
   ----------------------------------------------------------------------------
   Mode           : @DryRun = 1 => ROLLBACK final (aucun changement persiste)
                    @DryRun = 0 => COMMIT final
   Idempotent     : oui - re-executable sans erreur (tous les ordres gardes ;
                    une page existante est mise a jour sur ses colonnes
                    mutables et ses collections filles re-inserees).
   Reversible     : oui - voir 002_rollback.sql.
   Cible          : SQL Server 2019 (base RHP). Une seule transaction.
   ============================================================================ */

SET XACT_ABORT ON;
SET NOCOUNT ON;

/* --------------------------------------------------------------------------
   0. Parametres du deploiement
   -------------------------------------------------------------------------- */
DECLARE @DryRun      bit          = 1;   -- 1 = dry-run (defaut), 0 = execution reelle
DECLARE @Login       nvarchar(50) = 'SCRIPT';
DECLARE @ChangeRef   nvarchar(50) = 'DUP-PAGES-2026-08';

BEGIN TRANSACTION;
BEGIN TRY

/* --------------------------------------------------------------------------
   1. Preconditions bloquantes
   -------------------------------------------------------------------------- */
    -- 1.a Niveau de schema SP_ attendu : SP3
    IF OBJECT_ID('dbo.SP_Page', 'U') IS NULL
        RAISERROR('SP_ metadata absentes : executer 001_SP_Designer_Metadata.sql d''abord.', 16, 1);
    IF COL_LENGTH('dbo.SP_Page', 'Acces_Personnalise') IS NULL
        RAISERROR('Niveau SP2 requis : colonne SP_Page.Acces_Personnalise absente.', 16, 1);
    IF COL_LENGTH('dbo.SP_Page_Champ', 'estCritere') IS NULL
        RAISERROR('Niveau SP3 requis : colonne SP_Page_Champ.estCritere absente.', 16, 1);
    IF COL_LENGTH('dbo.SP_Page', 'Figer_Statuts') IS NULL
       OR COL_LENGTH('dbo.SP_Page_Table', 'Source_Metier') IS NULL
       OR COL_LENGTH('dbo.SP_Page_Champ', 'Zoom_Condition') IS NULL
        RAISERROR('Niveau SP4 requis : executer 006_SP_Designer_Evolutions.sql d''abord.', 16, 1);

    -- 1.b Cod_Document non utilise par une AUTRE page
    IF EXISTS (SELECT 1 FROM dbo.SP_Page
               WHERE Cod_Document IN ('XCG','XNF','XAT','XDM','XAV','XDP')
                 AND Cod_Page NOT IN ('DUP_CONGE','DUP_NOTE_FRAIS','DUP_DECLARATION_AT',
                                      'DUP_DOSSIER_MALADIE','DUP_AVANCE','DUP_PRET'))
        RAISERROR('Un Cod_Document X** est deja utilise par une autre page : arret.', 16, 1);

    -- 1.c Objets references (zooms / rubriques / fonctions / procs / tables)
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Zoom WHERE Num_Zoom = 'MS067')
        RAISERROR('Zoom inexistant : MS067', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Zoom WHERE Num_Zoom = 'MS165')
        RAISERROR('Zoom inexistant : MS165', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Zoom WHERE Num_Zoom = 'MS023')
        RAISERROR('Zoom inexistant : MS023', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Rubriques WHERE Nom_Controle = 'am_pm')
        RAISERROR('Rubrique inexistante : am_pm', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Rubriques WHERE Nom_Controle = 'Typ_Frais')
        RAISERROR('Rubrique inexistante : Typ_Frais', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Rubriques WHERE Nom_Controle = 'Typ_Maladie')
        RAISERROR('Rubrique inexistante : Typ_Maladie', 16, 1);
    IF OBJECT_ID('dbo.Sys_Rh_Conge', 'IF') IS NULL AND OBJECT_ID('dbo.Sys_Rh_Conge', 'TF') IS NULL
        RAISERROR('Fonction introuvable : dbo.Sys_Rh_Conge', 16, 1);
    IF OBJECT_ID('dbo.Sys_JourFeries', 'IF') IS NULL AND OBJECT_ID('dbo.Sys_JourFeries', 'TF') IS NULL
        RAISERROR('Fonction introuvable : dbo.Sys_JourFeries', 16, 1);
    IF OBJECT_ID('dbo.Sys_Conge_CheckPeriode', 'FN') IS NULL
        RAISERROR('Fonction introuvable : dbo.Sys_Conge_CheckPeriode', 16, 1);
    IF OBJECT_ID('dbo.Sys_Workflow_Signature', 'P') IS NULL
        RAISERROR('Procedure introuvable : dbo.Sys_Workflow_Signature', 16, 1);
    IF OBJECT_ID('dbo.RH_Paie_Avance', 'U') IS NULL OR OBJECT_ID('dbo.RH_Pret_Demande', 'U') IS NULL
       OR OBJECT_ID('dbo.RH_Preparation_Paie_Detail', 'U') IS NULL OR OBJECT_ID('dbo.RH_Param_Plan_Paie', 'U') IS NULL
       OR OBJECT_ID('dbo.RH_Conge_Type', 'U') IS NULL OR OBJECT_ID('dbo.Param_General', 'U') IS NULL
       OR OBJECT_ID('dbo.Param_Societe', 'U') IS NULL
        RAISERROR('Une table referencee par les sources est introuvable : arret.', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Profile WHERE Cod_Profile = '1')
        RAISERROR('Profil inexistant : 1', 16, 1);

/* --------------------------------------------------------------------------
   2. Section du menu portail "Pages specifiques" + rubrique "Le malade"
   -------------------------------------------------------------------------- */
    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Rubriques
                   WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = 'PagesSpecifiques')
        INSERT INTO dbo.Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Champs02, Dat_Crea, Created_By)
        VALUES ('SP_Menu_Portail', 'PagesSpecifiques', N'Pages spécifiques', 11, 'S', 'FolderSpecial', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Param_Rubriques SET Membre = N'Pages spécifiques', Rang = 11, Champs02 = 'FolderSpecial',
               Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = 'PagesSpecifiques';

    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Rubriques WHERE Nom_Controle = 'SP_Lien_Malade')
        INSERT INTO dbo.Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By)
        VALUES ('SP_Lien_Malade', 'A', N'L''agent lui même', 1, 'S', GETDATE(), @Login),
               ('SP_Lien_Malade', 'L', N'Un membre de la famille', 2, 'S', GETDATE(), @Login);
    ELSE
    BEGIN
        UPDATE dbo.Param_Rubriques SET Membre = N'L''agent lui même', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Nom_Controle = 'SP_Lien_Malade' AND Valeur = 'A';
        UPDATE dbo.Param_Rubriques SET Membre = N'Un membre de la famille', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Nom_Controle = 'SP_Lien_Malade' AND Valeur = 'L';
    END

/* --------------------------------------------------------------------------
   3. Sources metier (catalogue partage SP_Page_Source : insertion si absente,
      jamais d'ecrasement). Lectures seules parametrees ; @id_Societe est
      injecte par le serveur (jamais declare).
      Convention dates : les parametres date arrivent en chaine ISO ; le canon
      "+ 12 h" retablit la lecture d'horloge locale quel que soit le fuseau.
   -------------------------------------------------------------------------- */
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_solde_conge_date')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_solde_conge_date', N'Solde de congé de l''agent à une date (miroir get_conge_droits)', 'SQL',
                N'select isnull(min(c.Solde_Conge), 0) as Solde_Conge
from (select convert(date, dateadd(hour, 12, convert(datetimeoffset, @DatRef))) as DatRef) d
cross apply dbo.Sys_Rh_Conge(@id_Societe, d.DatRef) c
where c.Matricule = @Matricule',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true},{"Nom":"DatRef","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_periode_cloturee')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_periode_cloturee', N'Contrôle période de paie clôturée (miroir save_demande_conge)', 'SQL',
                N'select isnull(dbo.Sys_Conge_CheckPeriode(@id_Societe, d.Deb, d.Deb), 0) as nb
from (select convert(smalldatetime, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb) d',
                '[{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_controle_paie')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_controle_paie', N'Contrôle "congé postérieur à la dernière paie" (miroir save_demande_conge)', 'SQL',
                N'select case
  when (select top 1 Valeur from dbo.Param_General where Cod_Param = ''Autoriser_SaisieCongeApresPaie'') = ''O'' then 1
  when p.DatDernierePaie is null then 1
  when d.Deb > convert(date, p.DatDernierePaie) then 1
  else 0 end as ok
from (select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb) d
outer apply (select top 1 c.Cod_Plan_Paie
             from dbo.Sys_Rh_Conge(@id_Societe, d.Deb) c
             where c.Matricule = @Matricule) c
outer apply (select top 1 pp.DatDernierePaie
             from dbo.RH_Param_Plan_Paie pp
             where pp.id_Societe = @id_Societe and pp.Cod_Plan_Paie = c.Cod_Plan_Paie) p',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true},{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_repos')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_repos', N'Nombre de jours de repos hebdomadaire sur la période (miroir calcul_conge)', 'SQL',
                N'with d as (
  select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb,
         convert(date, dateadd(hour, 12, convert(datetimeoffset, @Fin))) as Fin
),
j as (
  select d.Deb as Jour from d
  union all
  select dateadd(day, 1, j.Jour) from j join d on j.Jour < d.Fin
),
agg as (
  select isnull(sum(case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = ''0'' then 1 else 0 end), 0) as Repos
  from j
  cross join (select isnull(JourOuvrables, replace(''1.1.1.1.1.1.0'', ''.'', char(59))) as JourOuvrables
              from dbo.Param_Societe where id_Societe = @id_Societe) s
)
select convert(int, a.Repos * case when isnull(t.ded, 1) = 1 then 1 else 0 end) as nb
from agg a
outer apply (select top 1 convert(int, isnull(deductibleDuConge, 1)) as ded
             from dbo.RH_Conge_Type where Typ_Conge = @Typ) t
option (maxrecursion 0)',
                '[{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true},{"Nom":"Fin","Typ":"nvarchar","Obligatoire":true},{"Nom":"Typ","Typ":"nvarchar","Obligatoire":false}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_feries')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_feries', N'Nombre de jours fériés (hors repos) sur la période (miroir calcul_conge)', 'SQL',
                N'with d as (
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
         case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = ''0'' then 1 else 0 end as EstRepos,
         case when exists (select 1 from jf where j.Jour between jf.d1 and jf.d2) then 1 else 0 end as EstFerie
  from j
  cross join (select isnull(JourOuvrables, replace(''1.1.1.1.1.1.0'', ''.'', char(59))) as JourOuvrables
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
option (maxrecursion 0)',
                '[{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true},{"Nom":"Fin","Typ":"nvarchar","Obligatoire":true},{"Nom":"Typ","Typ":"nvarchar","Obligatoire":false}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_duree')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_duree', N'Durée de congé à déduire (miroir calcul_conge : globale - repos - fériés)', 'SQL',
                N'with d as (
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
         case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = ''0'' then 1 else 0 end as EstRepos,
         case when exists (select 1 from jf where j.Jour between jf.d1 and jf.d2) then 1 else 0 end as EstFerie
  from j
  cross join (select isnull(JourOuvrables, replace(''1.1.1.1.1.1.0'', ''.'', char(59))) as JourOuvrables
              from dbo.Param_Societe where id_Societe = @id_Societe) s
),
agg as (
  select datediff(day, d.Deb, d.Fin) + 1
           - case when @DebPm = ''pm'' then 0.5 else 0 end
           - case when @FinPm = ''am'' then 0.5 else 0 end as Glob,
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
option (maxrecursion 0)',
                '[{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true},{"Nom":"Fin","Typ":"nvarchar","Obligatoire":true},{"Nom":"DebPm","Typ":"nvarchar","Obligatoire":false},{"Nom":"FinPm","Typ":"nvarchar","Obligatoire":false},{"Nom":"Typ","Typ":"nvarchar","Obligatoire":false}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_avances_encours')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_avances_encours', N'Montant des avances en cours de l''agent (miroir get_mnt_avances_encours)', 'SQL',
                N'select isnull(sum(isnull(Montant_Avance, 0) - isnull(Reglement, 0)), 0) as mnt
from dbo.RH_Paie_Avance
where id_Societe = @id_Societe and Matricule = @Matricule',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_prets_encours')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_prets_encours', N'Montant des prêts en cours de l''agent (miroir get_mnt_prets_encours)', 'SQL',
                N'select isnull(sum(isnull(Montant_Pret, 0) - isnull(Reglement, 0)), 0) as mnt
from dbo.RH_Pret_Demande
where id_Societe = @id_Societe and Matricule = @Matricule',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_dernier_salaire_av')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_dernier_salaire_av', N'Dernier salaire net (rubriques SalNet+Avance du plan de paie)', 'SQL',
                N'select isnull(sn.DernierSalaire, 0) as dernier_salaire
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
               and (d1.Cod_Rubrique = isnull(p.SalNet, '''') or d1.Cod_Rubrique = isnull(p.Avance, ''''))
               and d1.Cod_Preparation = lp.LastPaie) sn
where a.id_Societe = @id_Societe and a.Matricule = @Matricule',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_dernier_salaire_pr')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_dernier_salaire_pr', N'Dernier salaire net (rubriques SalNet+Pret du plan de paie)', 'SQL',
                N'select isnull(sn.DernierSalaire, 0) as dernier_salaire
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
               and (d1.Cod_Rubrique = isnull(p.SalNet, '''') or d1.Cod_Rubrique = isnull(p.Pret, ''''))
               and d1.Cod_Preparation = lp.LastPaie) sn
where a.id_Societe = @id_Societe and a.Matricule = @Matricule',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    -- Controle d'appartenance : @Matricule (utilisateur connecte) est injecte par
    -- le moteur ; @Doc_Matricule est mappe depuis le champ Matricule du document.
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_check_proprietaire')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_check_proprietaire', N'Contrôle "document de l''agent connecté" (miroir contrôle client des pages standards)', 'SQL',
                N'select case when @Doc_Matricule = @Matricule then 1 else 0 end as ok',
                '[{"Nom":"Doc_Matricule","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    -- Chevauchement de conges : miroir exact de dbo.Sys_Conge_Check, sur la table
    -- du duplicata, AVEC exclusion du document courant (@Num_Doc expose aux
    -- validations depuis le niveau SP4). Statut 'RJ' (rejete) ignore.
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_chevauchement')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_chevauchement', N'Contrôle de chevauchement des congés (miroir Sys_Conge_Check, document courant exclu)', 'SQL',
                N'with d as (
  select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb,
         convert(date, dateadd(hour, 12, convert(datetimeoffset, @Fin))) as Fin
)
select count(*) as nb
from dbo.SP_XCG_Ent c, d
where c.id_Societe = @id_Societe
  and c.Matricule = @Matricule
  and c.Num_Doc <> @Num_Doc
  and isnull(c.Statut, '''') <> ''RJ''
  and ((d.Fin between c.Dat_Deb_Conge and dateadd(day, -1, c.Dat_Fin_Conge))
       or (d.Deb between c.Dat_Deb_Conge and dateadd(day, -1, c.Dat_Fin_Conge))
       or (c.Dat_Deb_Conge between d.Deb and dateadd(day, -1, d.Fin))
       or (dateadd(day, -1, c.Dat_Fin_Conge) between d.Deb and dateadd(day, -1, d.Fin)))',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true},{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true},{"Nom":"Fin","Typ":"nvarchar","Obligatoire":true},{"Nom":"Num_Doc","Typ":"nvarchar","Obligatoire":false}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);

    -- Decoupe d'un conge par periode de paie : miroir exact de la fonction Calcul
    -- du backend standard (demande_conge.ts) : bornes de periodes calées sur le
    -- JourPaie du plan de paie de l''agent, demi-journees AM/PM, repos hebdo de la
    -- societe et jours feries. Retour TABLE (detail virtuel, lecture seule).
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'sp_cng_detail')
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('sp_cng_detail', N'Découpe du congé par période de paie (miroir calcul_conge, grille de détail)', 'SQL',
                N'with d as (
  select convert(date, dateadd(hour, 12, convert(datetimeoffset, @Deb))) as Deb,
         convert(date, dateadd(hour, 12, convert(datetimeoffset, @Fin))) as Fin
),
jp as (
  select isnull((select top 1 p.JourPaie
                 from dbo.Sys_Rh_Conge(@id_Societe, (select Deb from d)) c
                 outer apply (select top 1 * from dbo.RH_Param_Plan_Paie p
                              where p.id_Societe = @id_Societe and p.Cod_Plan_Paie = c.Cod_Plan_Paie) p
                 where c.Matricule = @Matricule), 1) as JourPaie
),
per as (
  select d.Deb as PDeb,
         dateadd(day, -1, dateadd(day, (select JourPaie from jp) - 1, dateadd(month, 1, datefromparts(year(d.Deb), month(d.Deb), 1)))) as PFin
  from d
  union all
  select dateadd(day, 1, p.PFin),
         dateadd(day, -1, dateadd(day, (select JourPaie from jp) - 1, dateadd(month, 1, datefromparts(year(dateadd(day, 1, p.PFin)), month(dateadd(day, 1, p.PFin)), 1))))
  from per p
  where p.PFin < (select Fin from d)
),
per2 as (
  select PDeb, case when PFin > (select Fin from d) then (select Fin from d) else PFin end as PFin
  from per
  where PDeb <= (select Fin from d)
),
per3 as (
  select PDeb, PFin,
         row_number() over (order by PDeb) as rn,
         count(*) over () as n,
         datediff(day, PDeb, PFin) as Dj
  from per2
),
g as (
  select datediff(day, d.Deb, d.Fin) + 1
         - case when @DebPm = ''pm'' then 0.5 else 0 end
         - case when @FinPm = ''am'' then 0.5 else 0 end as Glob
  from d
),
per4 as (
  select PDeb, PFin, rn, n,
         case when rn < n then Dj + case when rn = 1 and @DebPm = ''pm'' then 0.5 else 1.0 end end as DureeLig,
         (select Glob from g) as Glob
  from per3
),
per5 as (
  select PDeb, PFin,
         case when rn < n then DureeLig
              else Glob - isnull((select sum(DureeLig) from per4 x where x.rn < per4.n), 0) end as Duree_Globale
  from per4
),
jf as (
  select convert(date, f.DatDeb) as d1, convert(date, f.DatFin) as d2
  from dbo.Sys_JourFeries((select Deb from d), @id_Societe) f
  union
  select convert(date, f.DatDeb), convert(date, f.DatFin)
  from dbo.Sys_JourFeries((select Fin from d), @id_Societe) f
),
j as (
  select per5.PDeb, per5.PFin, per5.Duree_Globale, per5.PDeb as Jour
  from per5
  union all
  select j.PDeb, j.PFin, j.Duree_Globale, dateadd(day, 1, j.Jour)
  from j where j.Jour < j.PFin
),
j2 as (
  select j.PDeb, j.PFin, j.Duree_Globale, j.Jour,
         case when substring(s.JourOuvrables, 2 * (datediff(day, 0, j.Jour) % 7) + 1, 1) = ''0'' then 1 else 0 end as EstRepos,
         case when exists (select 1 from jf where j.Jour between jf.d1 and jf.d2) then 1 else 0 end as EstFerie
  from j
  cross join (select isnull(JourOuvrables, ''1;1;1;1;1;1;0'') as JourOuvrables
              from dbo.Param_Societe where id_Societe = @id_Societe) s
)
select PDeb as Dat_Deb, PFin as Dat_Fin,
       Duree_Globale,
       sum(EstRepos) as Repos_Hebdomadaire,
       sum(case when EstRepos = 1 then 0 else EstFerie end) as Jours_Feries,
       case when Duree_Globale - sum(EstRepos) - sum(case when EstRepos = 1 then 0 else EstFerie end) < 0 then 0
            else Duree_Globale - sum(EstRepos) - sum(case when EstRepos = 1 then 0 else EstFerie end) end as Duree_Conge
from j2
group by PDeb, PFin, Duree_Globale
order by PDeb
option (maxrecursion 0)',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true},{"Nom":"Deb","Typ":"nvarchar","Obligatoire":true},{"Nom":"Fin","Typ":"nvarchar","Obligatoire":true},{"Nom":"DebPm","Typ":"nvarchar","Obligatoire":false},{"Nom":"FinPm","Typ":"nvarchar","Obligatoire":false}]',
                'TABLE', '', 'true', GETDATE(), @Login);

    -- Rafraichissement des libelles des nouvelles sources
    UPDATE dbo.SP_Page_Source SET Libelle = N'Contrôle "document de l''agent connecté" (miroir contrôle client des pages standards)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_check_proprietaire';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Contrôle de chevauchement des congés (miroir Sys_Conge_Check, document courant exclu)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_chevauchement';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Découpe du congé par période de paie (miroir calcul_conge, grille de détail)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_detail';

    -- Rafraichissement des libelles des sources du package (le SQL metier
    -- (Code_Sql/Parametres) n'est JAMAIS ecrase : seul le libelle est realigne)
    UPDATE dbo.SP_Page_Source SET Libelle = N'Solde de congé de l''agent à une date (miroir get_conge_droits)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_solde_conge_date';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Contrôle période de paie clôturée (miroir save_demande_conge)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_periode_cloturee';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Contrôle "congé postérieur à la dernière paie" (miroir save_demande_conge)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_controle_paie';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Nombre de jours de repos hebdomadaire sur la période (miroir calcul_conge)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_repos';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Nombre de jours fériés (hors repos) sur la période (miroir calcul_conge)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_feries';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Durée de congé à déduire (miroir calcul_conge : globale - repos - fériés)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_cng_duree';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Montant des avances en cours de l''agent (miroir get_mnt_avances_encours)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_avances_encours';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Montant des prêts en cours de l''agent (miroir get_mnt_prets_encours)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_prets_encours';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Dernier salaire net (rubriques SalNet+Avance du plan de paie)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_dernier_salaire_av';
    UPDATE dbo.SP_Page_Source SET Libelle = N'Dernier salaire net (rubriques SalNet+Pret du plan de paie)', Dat_Modif = GETDATE(), Modified_By = @Login WHERE Cod_Source = 'sp_dernier_salaire_pr';

/* ##########################################################################
   PAGE 1/6 : DUP_CONGE (XCG) - duplicata de "Demande de conge"
   ########################################################################## */
    DECLARE @CP1 nvarchar(30) = 'DUP_CONGE';

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP1)
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, Figer_Statuts, Dat_Crea, Created_By)
        VALUES (@CP1, 'XCG', N'Duplicata - Demande de congé (test Designer)', N'Congé (SP)', N'Demande de congé (SP)',
            'PagesSpecifiques', 1, 'BeachAccess', 'BROUILLON', 'SP_XCG_Ent', 'XCG',
            'true', NULL, 'true', NULL, 'false',
            'true', 'true', 'true', 'false', 'true', 'SS,SG,RJ,SP,VA', GETDATE(), @Login);
    ELSE
        UPDATE dbo.SP_Page
        SET Libelle = N'Duplicata - Demande de congé (test Designer)', Libelle_Court = N'Congé (SP)',
            Nom_Page = N'Demande de congé (SP)', Menu_Parent = 'PagesSpecifiques', Rang = 1, Icone = 'BeachAccess',
            Workflow_Actif = 'true', GED_Actif = 'true',
            Act_Enregistrer = 'true', Act_Soumettre = 'true', Act_Imprimer = 'true', Act_Exporter = 'false',
            Acces_Personnalise = 'true', Figer_Statuts = 'SS,SG,RJ,SP,VA', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP1;

    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP1;
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP1;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP1;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP1;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP1;

    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping, Dat_Crea, Created_By)
    VALUES (@CP1, 'ENT', 'SP_XCG_Ent', 'ENT', N'Entête', 0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login),
           -- PERIODES : détail VIRTUEL alimenté par la source sp_cng_detail
           -- (découpe par période de paie, miroir de la grille calculée du standard)
           (@CP1, 'PERIODES', 'SP_XCG_Virt_PERIODES', 'DET', N'Détail par période de paie', 1, 'false', 'false', 'false', 'false', NULL, 'CASCADE',
            'sp_cng_detail',
            '{"Matricule":{"ref":"Matricule"},"Deb":{"ref":"Dat_Deb_Conge"},"Fin":{"ref":"Dat_Fin_Conge"},"DebPm":{"ref":"Dat_Deb_am_pm"},"FinPm":{"ref":"Dat_Fin_am_pm"}}',
            GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP1, 'ENT', 'Matricule',          N'Matricule',           'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Typ_Conge',          N'Type de congé',       'nvarchar', 10,   NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Commentaire',        N'Commentaire',         'nvarchar', 300,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Dat_Deb_Conge',      N'Début du congé',      'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 4,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Dat_Fin_Conge',      N'Fin du congé',        'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 5,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Dat_Deb_am_pm',      N'Début AM/PM',         'nvarchar', 2,    NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 6,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Dat_Fin_am_pm',      N'Fin AM/PM',           'nvarchar', 2,    NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 7,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Duree_Globale',      N'Durée globale',       'decimal',  NULL, 6,    1,    'true',  NULL, 'false', 'false', 'false', 8,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Repos_Hebdomadaire', N'Repos hebdomadaire',  'decimal',  NULL, 6,    1,    'true',  NULL, 'false', 'false', 'false', 9,  GETDATE(), @Login),
        (@CP1, 'ENT', 'Jours_Feries',       N'Jours fériés',        'decimal',  NULL, 6,    1,    'true',  NULL, 'false', 'false', 'false', 10, GETDATE(), @Login),
        (@CP1, 'ENT', 'Duree_Conge',        N'Congé à déduire',     'decimal',  NULL, 6,    1,    'true',  NULL, 'false', 'false', 'false', 11, GETDATE(), @Login),
        -- Colonnes du détail virtuel PERIODES : descriptif de la sortie de la
        -- source sp_cng_detail (aucune table physique n'est créée)
        (@CP1, 'PERIODES', 'Dat_Deb',           N'Du',             'date',  NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP1, 'PERIODES', 'Dat_Fin',           N'Au',             'date',  NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP1, 'PERIODES', 'Duree_Globale',     N'Durée globale',  'float', NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP1, 'PERIODES', 'Repos_Hebdomadaire',N'Repos',          'float', NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP1, 'PERIODES', 'Jours_Feries',      N'Jours fériés',   'float', NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 5, GETDATE(), @Login),
        (@CP1, 'PERIODES', 'Duree_Conge',       N'Congé',          'float', NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 6, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Regle_Visibilite, Regle_Activation,
        Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP1, 'Num_Doc',       'ENT', '',                 N'N° demande',         'TEXT',     1,  1, 1, 6, NULL,           'false', 'R', NULL,    NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 1,  NULL, 'false', NULL, N'Numéro attribué à l''enregistrement', GETDATE(), @Login),
        (@CP1, 'Matricule',     'ENT', 'Matricule',        N'Matricule',          'ZOOM',     2,  1, 2, 6, 'GV_MATRICULE', 'true',  'R', NULL,    'MS067', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1,  NULL, 'true',  1,    N'Agent connecté (zoom MS067)', GETDATE(), @Login),
        (@CP1, 'Typ_Conge',     'ENT', 'Typ_Conge',        N'Type de congé',      'COMBO',    3,  2, 1, 6, 'CAD',          'true',  'S', NULL,    'MS165', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  2,  NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'Commentaire',   'ENT', 'Commentaire',      N'Commentaire',        'TEXT',     4,  2, 2, 6, NULL,           'false', 'S', NULL,    NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  9,  NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'Dat_Deb_Conge', 'ENT', 'Dat_Deb_Conge',    N'Du',                 'DATE',     5,  3, 1, 4, 'GV_NOW',       'true',  'S', NULL,    NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  3,  NULL, 'true',  2,    NULL, GETDATE(), @Login),
        (@CP1, 'Dat_Deb_am_pm', 'ENT', 'Dat_Deb_am_pm',    N'AM/PM',              'RUBRIQUE', 6,  3, 2, 2, 'am',           'true',  'S', 'am_pm', NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 4,  NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'Dat_Fin_Conge', 'ENT', 'Dat_Fin_Conge',    N'Au',                 'DATE',     7,  3, 3, 4, 'GV_NOW',       'true',  'S', NULL,    NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  5,  NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'Dat_Fin_am_pm', 'ENT', 'Dat_Fin_am_pm',    N'AM/PM',              'RUBRIQUE', 8,  3, 4, 2, 'am',           'true',  'S', 'am_pm', NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 6,  NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'Duree_Globale', 'ENT', 'Duree_Globale',    N'Durée',              'CALCULE',  9,  4, 1, 3, NULL,           'false', 'A', NULL,    NULL,    NULL,
            '{"op":"SUB","args":[{"op":"ADD","args":[{"op":"DATEDIFF","unite":"J","args":[{"ref":"Dat_Fin_Conge"},{"ref":"Dat_Deb_Conge"}]},{"const":1}]},{"op":"ADD","args":[{"op":"COND","args":[{"op":"EQ","args":[{"ref":"Dat_Deb_am_pm"},{"const":"pm"}]},{"const":0.5},{"const":0}]},{"op":"COND","args":[{"op":"EQ","args":[{"ref":"Dat_Fin_am_pm"},{"const":"am"}]},{"const":0.5},{"const":0}]}]}]}',
            'true', 'NUM', 1, NULL, NULL, 'true', 7, NULL, 'false', NULL, N'Jours calendaires entre les deux dates (+1, -0,5 par demi-journée)', GETDATE(), @Login),
        (@CP1, 'Repos_Hebdomadaire', 'ENT', 'Repos_Hebdomadaire', N'Repos hebdomadaire', 'SOURCE', 10, 4, 2, 3, NULL,      'false', 'A', NULL,    NULL,    'sp_cng_repos',
            '{"source":"sp_cng_repos","mapping":{"Deb":{"ref":"Dat_Deb_Conge"},"Fin":{"ref":"Dat_Fin_Conge"},"Typ":{"ref":"Typ_Conge"}}}',
            'true', 'NUM', 0, NULL, NULL, 'true', 8, NULL, 'false', NULL, N'Jours de repos hebdomadaire de la société sur la période (x coefficient du type de congé)', GETDATE(), @Login),
        (@CP1, 'Jours_Feries',  'ENT', 'Jours_Feries',     N'Jours fériés',       'SOURCE',   11, 4, 3, 3, NULL,           'false', 'A', NULL,    NULL,    'sp_cng_feries',
            '{"source":"sp_cng_feries","mapping":{"Deb":{"ref":"Dat_Deb_Conge"},"Fin":{"ref":"Dat_Fin_Conge"},"Typ":{"ref":"Typ_Conge"}}}',
            'true', 'NUM', 0, NULL, NULL, 'true', 9, NULL, 'false', NULL, N'Jours fériés (hors repos) sur la période', GETDATE(), @Login),
        (@CP1, 'Duree_Conge',   'ENT', 'Duree_Conge',      N'A déduire du congé', 'SOURCE',   12, 4, 4, 3, NULL,           'false', 'A', NULL,    NULL,    'sp_cng_duree',
            '{"source":"sp_cng_duree","mapping":{"Deb":{"ref":"Dat_Deb_Conge"},"Fin":{"ref":"Dat_Fin_Conge"},"DebPm":{"ref":"Dat_Deb_am_pm"},"FinPm":{"ref":"Dat_Fin_am_pm"},"Typ":{"ref":"Typ_Conge"}}}',
            'true', 'NUM', 1, NULL, NULL, 'true', 10, NULL, 'false', NULL, N'Durée globale - repos - fériés (si type de congé déductible)', GETDATE(), @Login),
        (@CP1, 'Solde_Conge',   'ENT', '',                 N'Solde de congé',     'SOURCE',   13, 5, 1, 3, NULL,           'false', 'A', NULL,    NULL,    'sp_solde_conge_date',
            '{"source":"sp_solde_conge_date","mapping":{"Matricule":{"ref":"Matricule"},"DatRef":{"ref":"Dat_Deb_Conge"}}}',
            'false', 'NUM', 1, NULL, NULL, 'false', 11, NULL, 'false', NULL, N'Solde de congé de l''agent à la date de début', GETDATE(), @Login),
        -- Grille du détail virtuel PERIODES (miroir de la grille calculée du standard)
        (@CP1, 'P_Dat_Deb',  'PERIODES', 'Dat_Deb',           N'Du',             'DATE', 1, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 1, 6, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'P_Dat_Fin',  'PERIODES', 'Dat_Fin',           N'Au',             'DATE', 2, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 2, 8, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'P_Duree_Globale', 'PERIODES', 'Duree_Globale', N'Durée globale', 'DEC',  3, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, 1, NULL, NULL, 'true', 3, 6, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'P_Repos',    'PERIODES', 'Repos_Hebdomadaire', N'Repos',         'DEC',  4, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, 0, NULL, NULL, 'true', 4, 6, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'P_Jours_Feries', 'PERIODES', 'Jours_Feries',   N'Jrs fériés',    'DEC',  5, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, 0, NULL, NULL, 'true', 5, 6, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP1, 'P_Duree_Conge',  'PERIODES', 'Duree_Conge',    N'Congé',         'DEC',  6, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, 1, NULL, NULL, 'true', 6, 6, 'false', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ,
        Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
    VALUES
        (@CP1, 'V00_PROPRIETAIRE', 'CHAMP', 'ENT', 'Matricule',     'SOURCE',
            '{"source":"sp_check_proprietaire","mapping":{"Doc_Matricule":{"ref":"Matricule"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":1}]}}', NULL,
            N'Vous ne pouvez pas saisir une demande pour un autre matricule.', 'B', 0, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V01_MATRICULE', 'CHAMP',    'ENT', 'Matricule',     'REQUIRED', NULL, NULL,
            N'Veuillez renseigner le matricule.', 'B', 1, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V02_DAT_DEB',   'CHAMP',    'ENT', 'Dat_Deb_Conge', 'REQUIRED', NULL, NULL,
            N'Erreur de date (début).', 'B', 2, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V03_DAT_FIN',   'CHAMP',    'ENT', 'Dat_Fin_Conge', 'REQUIRED', NULL, NULL,
            N'Erreur de date (fin).', 'B', 3, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V04_ORDRE',     'DOCUMENT', 'ENT', NULL,            'EXPR',
            '{"expr":{"op":"LT","args":[{"ref":"Dat_Deb_Conge"},{"ref":"Dat_Fin_Conge"}]}}', NULL,
            N'Incohérence dates début et fin de congé.', 'B', 4, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V05_DUREE',     'CHAMP',    'ENT', 'Duree_Conge',   'COMPARE', '{"operateur":"GT","constante":0}', NULL,
            N'Aucune durée de congé n''est renseignée.', 'B', 5, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V06_PERIODE',   'DOCUMENT', 'ENT', NULL,            'SOURCE',
            '{"source":"sp_cng_periode_cloturee","mapping":{"Deb":{"ref":"Dat_Deb_Conge"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":0}]}}', NULL,
            N'Dates de congé correspondant à une période clôturée.', 'B', 6, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V07_PAIE',      'DOCUMENT', 'ENT', NULL,            'SOURCE',
            '{"source":"sp_cng_controle_paie","mapping":{"Matricule":{"ref":"Matricule"},"Deb":{"ref":"Dat_Deb_Conge"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":1}]}}', NULL,
            N'La date de début du congé doit être postérieure à la date de la dernière paie.', 'B', 7, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V08_CHEVAUCHEMENT', 'DOCUMENT', 'ENT', NULL,        'SOURCE',
            '{"source":"sp_cng_chevauchement","mapping":{"Matricule":{"ref":"Matricule"},"Deb":{"ref":"Dat_Deb_Conge"},"Fin":{"ref":"Dat_Fin_Conge"},"Num_Doc":{"ref":"Num_Doc"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":0}]}}', NULL,
            N'Il existe au moins un congé en chevauchement avec cette demande.', 'B', 8, 'SAVE', 'true', GETDATE(), @Login),
        (@CP1, 'V09_CALCUL',    'DETAIL',   'PERIODES', NULL,       'NB_LIGNES', '{"min":1}', NULL,
            N'Erreur calcul de congé.', 'B', 9, 'SAVE', 'true', GETDATE(), @Login);

    -- Droits : tous les profils actifs (comme les pages standards, ouvertes a tout utilisateur connecte)
    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    SELECT @CP1, p.Cod_Profile, 'true', 'true', 'true', 'true', 'true', 'true', 'true', GETDATE(), @Login
    FROM dbo.Controle_Profile p WHERE ISNULL(p.Actif, 1) = 1;

    IF OBJECT_ID('dbo.SP_XCG_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XCG_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_XCG_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_XCG_Ent_Matricule] DEFAULT (''),
            [Typ_Conge] nvarchar(10) NULL,
            [Commentaire] nvarchar(300) NULL,
            [Dat_Deb_Conge] date NULL,
            [Dat_Fin_Conge] date NULL,
            [Dat_Deb_am_pm] nvarchar(2) NULL,
            [Dat_Fin_am_pm] nvarchar(2) NULL,
            [Duree_Globale] decimal(6,1) NULL,
            [Repos_Hebdomadaire] decimal(6,1) NULL,
            [Jours_Feries] decimal(6,1) NULL,
            [Duree_Conge] decimal(6,1) NULL,
            CONSTRAINT [PK_SP_XCG_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP1 AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP1, 'CREATE', 'CREATE TABLE SP_XCG_Ent (script duplicata DUP-PAGES-2026-08)', 'true',
                N'Table créée par le script duplicata', @Login, GETDATE());

    -- Publication (controles prealables - miroir SP_Page_Designer.Publier)
    IF OBJECT_ID('dbo.SP_XCG_Ent', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XCG_Ent', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Matricule'),('Typ_Conge'),('Commentaire'),('Dat_Deb_Conge'),
               ('Dat_Fin_Conge'),('Dat_Deb_am_pm'),('Dat_Fin_am_pm'),('Duree_Globale'),
               ('Repos_Hebdomadaire'),('Jours_Feries'),('Duree_Conge')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_XCG_Ent', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_XCG_Ent', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP1 AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP1 AND Statut_Page <> 'PUBLIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'SPP_DUP_CONGE')
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES ('SPP_DUP_CONGE', 'SP_XCG_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = 'SP_XCG_Ent', PJ = 'true' WHERE Name_Ecran = 'SPP_DUP_CONGE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = 'XCG')
        INSERT INTO dbo.Param_Workflow_Typ_Document
            (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
        VALUES ('XCG', N'Duplicata - Demande de congé (SP)', 'SP_XCG_Ent', 'Num_Doc', 'false', 'SPP_DUP_CONGE', 'Num_Doc', 'Created_By', -1);
    ELSE
        UPDATE dbo.Param_Workflow_Typ_Document
        SET Intitule = N'Duplicata - Demande de congé (SP)', Table_Ref = 'SP_XCG_Ent', Name_Ecran = 'SPP_DUP_CONGE'
        WHERE Typ_Document = 'XCG';

/* ##########################################################################
   PAGE 2/6 : DUP_NOTE_FRAIS (XNF) - duplicata de "Note de frais"
   ########################################################################## */
    DECLARE @CP2 nvarchar(30) = 'DUP_NOTE_FRAIS';

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP2)
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, Figer_Statuts, Dat_Crea, Created_By)
        VALUES (@CP2, 'XNF', N'Duplicata - Note de frais (test Designer)', N'Note de frais (SP)', N'Note de frais (SP)',
            'PagesSpecifiques', 2, 'Receipt', 'BROUILLON', 'SP_XNF_Ent', 'XNF',
            'true', NULL, 'true', NULL, 'false',
            'true', 'true', 'true', 'false', 'true', 'SS,SG,RJ,SP,VA', GETDATE(), @Login);
    ELSE
        UPDATE dbo.SP_Page
        SET Libelle = N'Duplicata - Note de frais (test Designer)', Libelle_Court = N'Note de frais (SP)',
            Nom_Page = N'Note de frais (SP)', Menu_Parent = 'PagesSpecifiques', Rang = 2, Icone = 'Receipt',
            Workflow_Actif = 'true', GED_Actif = 'true',
            Act_Enregistrer = 'true', Act_Soumettre = 'true', Act_Imprimer = 'true', Act_Exporter = 'false',
            Acces_Personnalise = 'true', Figer_Statuts = 'SS,SG,RJ,SP,VA', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP2;

    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP2;
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP2;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP2;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP2;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP2;

    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping, Dat_Crea, Created_By)
    VALUES
        (@CP2, 'ENT',    'SP_XNF_Ent',        'ENT', N'Entête',        0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login),
        (@CP2, 'LIGNES', 'SP_XNF_Det_LIGNES', 'DET', N'Frais engagés', 1, 'true',  'true',  'true',  'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP2, 'ENT',    'Matricule',   N'Matricule',      'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP2, 'ENT',    'Dat_NF',      N'Date',           'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP2, 'ENT',    'Mnt_NF',      N'Montant total',  'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP2, 'ENT',    'Commentaire', N'Commentaire',    'nvarchar', 500,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP2, 'LIGNES', 'Typ_Frais',   N'Type de frais',  'nvarchar', 20,   NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP2, 'LIGNES', 'Base',        N'Base',           'float',    NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP2, 'LIGNES', 'Tx',          N'Taux',           'float',    NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP2, 'LIGNES', 'Mnt',         N'Montant',        'float',    NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP2, 'LIGNES', 'Comment',     N'Commentaire',    'nvarchar', 200,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 5, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Regle_Visibilite, Regle_Activation,
        Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP2, 'Num_Doc',     'ENT', '',              N'N° demande',    'TEXT',     1, 1, 1, 3,  NULL,           'false', 'R', NULL,        NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 1, NULL, 'false', NULL, N'Numéro attribué à l''enregistrement', GETDATE(), @Login),
        (@CP2, 'Matricule',   'ENT', 'Matricule',     N'Matricule',     'ZOOM',     2, 1, 2, 3,  'GV_MATRICULE', 'true',  'R', NULL,        'MS067', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1, NULL, 'true',  1,    N'Agent connecté (zoom MS067)', GETDATE(), @Login),
        (@CP2, 'Dat_NF',      'ENT', 'Dat_NF',        N'Date',          'DATE',     3, 1, 3, 3,  'GV_NOW',       'true',  'S', NULL,        NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  2, NULL, 'true',  2,    NULL, GETDATE(), @Login),
        (@CP2, 'Statut',      'ENT', 'Statut',        N'Statut',        'RUBRIQUE', 4, 1, 4, 3,  NULL,           'false', 'R', 'Statut_Signature', NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 10, NULL, 'true', 3,    N'Statut du circuit de signature (colonne technique)', GETDATE(), @Login),
        (@CP2, 'Mnt_NF',      'ENT', 'Mnt_NF',        N'Montant total', 'CALCULE',  4, 1, 4, 3,  NULL,           'false', 'I', NULL,        NULL,    NULL,
            '{"op":"SUM","table":"LIGNES","colonne":"Mnt"}', 'true', 'MNT', 2, NULL, NULL, 'true', 3, NULL, 'false', NULL, N'Total des frais (persisté, affiché en liste)', GETDATE(), @Login),
        (@CP2, 'Commentaire', 'ENT', 'Commentaire',   N'Commentaire',   'MEMO',     5, 2, 1, 12, NULL,           'false', 'S', NULL,        NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  4, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP2, 'L_Typ_Frais', 'LIGNES', 'Typ_Frais',  N'Frais',         'RUBRIQUE', 1, NULL, NULL, NULL, 'HEB',  'false', 'S', 'Typ_Frais', NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1, 10, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP2, 'L_Base',      'LIGNES', 'Base',       N'Base',          'DEC',      2, NULL, NULL, NULL, '0',    'false', 'S', NULL,        NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  2, 8,  'false', NULL, NULL, GETDATE(), @Login),
        (@CP2, 'L_Tx',        'LIGNES', 'Tx',         N'Taux',          'DEC',      3, NULL, NULL, NULL, '0',    'false', 'S', NULL,        NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  3, 8,  'false', NULL, NULL, GETDATE(), @Login),
        (@CP2, 'L_Mnt',       'LIGNES', 'Mnt',        N'Montant',       'CALCULE',  4, NULL, NULL, NULL, NULL,  'false', 'A', NULL,        NULL,    NULL,
            '{"op":"ROUND","args":[{"op":"MUL","args":[{"ref":"Base"},{"ref":"Tx"}]},{"const":2}]}', 'true', NULL, 2, NULL, NULL, 'true', 4, 8, 'false', NULL, N'Montant = Base x Taux', GETDATE(), @Login),
        (@CP2, 'L_Comment',   'LIGNES', 'Comment',    N'Commentaire',   'TEXT',     5, NULL, NULL, NULL, NULL,  'false', 'S', NULL,        NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  5, 20, 'false', NULL, NULL, GETDATE(), @Login),
        -- Pied de grille : champ calcule rattache au detail SANS colonne physique
        (@CP2, 'Pied_Total',  'LIGNES', '',           N'Total des frais engagés', 'CALCULE', 6, NULL, NULL, NULL, NULL, 'false', 'A', NULL, NULL, NULL,
            '{"op":"SUM","table":"LIGNES","colonne":"Mnt"}', 'false', 'MNT', 2, NULL, NULL, 'false', 6, NULL, 'false', NULL, N'Pied de grille : somme des montants', GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ,
        Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
    VALUES
        (@CP2, 'V00_PROPRIETAIRE', 'CHAMP', 'ENT', 'Matricule', 'SOURCE',
            '{"source":"sp_check_proprietaire","mapping":{"Doc_Matricule":{"ref":"Matricule"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":1}]}}', NULL,
            N'Vous ne pouvez pas saisir une note de frais pour un autre matricule.', 'B', 0, 'SAVE', 'true', GETDATE(), @Login),
        (@CP2, 'V01_MATRICULE', 'CHAMP',    'ENT', 'Matricule', 'REQUIRED', NULL, NULL,
            N'Veuillez renseigner le matricule.', 'B', 1, 'SAVE', 'true', GETDATE(), @Login),
        (@CP2, 'V02_TOTAL_NUL', 'DOCUMENT', 'ENT', NULL,        'EXPR',
            '{"expr":{"op":"NE","args":[{"ref":"Mnt_NF"},{"const":0}]}}', NULL,
            N'Le Total des frais engagés est nul.', 'W', 2, 'SAVE', 'true', GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    SELECT @CP2, p.Cod_Profile, 'true', 'true', 'true', 'true', 'true', 'true', 'true', GETDATE(), @Login
    FROM dbo.Controle_Profile p WHERE ISNULL(p.Actif, 1) = 1;

    IF OBJECT_ID('dbo.SP_XNF_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XNF_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_XNF_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_XNF_Ent_Matricule] DEFAULT (''),
            [Dat_NF] date NULL,
            [Mnt_NF] decimal(18,2) NULL,
            [Commentaire] nvarchar(500) NULL,
            CONSTRAINT [PK_SP_XNF_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END

    IF OBJECT_ID('dbo.SP_XNF_Det_LIGNES', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XNF_Det_LIGNES] (
            [RowId] int IDENTITY(1,1) NOT NULL,
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [Typ_Frais] nvarchar(20) NULL,
            [Base] float NULL,
            [Tx] float NULL,
            [Mnt] float NULL,
            [Comment] nvarchar(200) NULL,
            CONSTRAINT [PK_SP_XNF_Det_LIGNES] PRIMARY KEY ([RowId])
        );
    END

    IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SP_XNF_Det_LIGNES_Ent')
        ALTER TABLE dbo.[SP_XNF_Det_LIGNES] WITH NOCHECK ADD CONSTRAINT [FK_SP_XNF_Det_LIGNES_Ent]
            FOREIGN KEY ([Num_Doc], [id_Societe]) REFERENCES dbo.[SP_XNF_Ent] ([Num_Doc], [id_Societe]) ON DELETE CASCADE;

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP2 AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP2, 'CREATE', 'CREATE TABLE SP_XNF_Ent / SP_XNF_Det_LIGNES + FK (script duplicata DUP-PAGES-2026-08)', 'true',
                N'Tables créées par le script duplicata', @Login, GETDATE());

    IF OBJECT_ID('dbo.SP_XNF_Ent', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XNF_Ent', 16, 1);
    IF OBJECT_ID('dbo.SP_XNF_Det_LIGNES', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XNF_Det_LIGNES', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Matricule'),('Dat_NF'),('Mnt_NF'),('Commentaire')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_XNF_Ent', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_XNF_Ent', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Typ_Frais'),('Base'),('Tx'),('Mnt'),('Comment')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_XNF_Det_LIGNES', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_XNF_Det_LIGNES', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP2 AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP2 AND Statut_Page <> 'PUBLIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'SPP_DUP_NOTE_FRAIS')
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES ('SPP_DUP_NOTE_FRAIS', 'SP_XNF_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = 'SP_XNF_Ent', PJ = 'true' WHERE Name_Ecran = 'SPP_DUP_NOTE_FRAIS';

    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = 'XNF')
        INSERT INTO dbo.Param_Workflow_Typ_Document
            (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
        VALUES ('XNF', N'Duplicata - Note de frais (SP)', 'SP_XNF_Ent', 'Num_Doc', 'false', 'SPP_DUP_NOTE_FRAIS', 'Num_Doc', 'Created_By', -1);
    ELSE
        UPDATE dbo.Param_Workflow_Typ_Document
        SET Intitule = N'Duplicata - Note de frais (SP)', Table_Ref = 'SP_XNF_Ent', Name_Ecran = 'SPP_DUP_NOTE_FRAIS'
        WHERE Typ_Document = 'XNF';

/* ##########################################################################
   PAGE 3/6 : DUP_DECLARATION_AT (XAT) - duplicata de "Declaration AT"
   (miroir strict de la page portail standard : CONSULTATION SEULE + PJ ;
    la saisie des declarations reste l'apanage du Desktop, comme le standard)
   ########################################################################## */
    DECLARE @CP3 nvarchar(30) = 'DUP_DECLARATION_AT';

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP3)
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, Figer_Statuts, Dat_Crea, Created_By)
        VALUES (@CP3, 'XAT', N'Duplicata - Déclaration d''accident de travail (test Designer)', N'Déclaration AT (SP)', N'Déclaration AT (SP)',
            'PagesSpecifiques', 3, 'Healing', 'BROUILLON', 'SP_XAT_Ent', 'XAT',
            'false', NULL, 'true', NULL, 'false',
            'false', 'false', 'true', 'false', 'true', 'SG,RJ,SP,VA', GETDATE(), @Login);
    ELSE
        UPDATE dbo.SP_Page
        SET Libelle = N'Duplicata - Déclaration d''accident de travail (test Designer)', Libelle_Court = N'Déclaration AT (SP)',
            Nom_Page = N'Déclaration AT (SP)', Menu_Parent = 'PagesSpecifiques', Rang = 3, Icone = 'Healing',
            Workflow_Actif = 'false', GED_Actif = 'true',
            Act_Enregistrer = 'false', Act_Soumettre = 'false', Act_Imprimer = 'true', Act_Exporter = 'false',
            Acces_Personnalise = 'true', Figer_Statuts = 'SG,RJ,SP,VA', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP3;

    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP3;
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP3;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP3;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP3;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP3;

    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping, Dat_Crea, Created_By)
    VALUES
        (@CP3, 'ENT',     'SP_XAT_Ent',         'ENT', N'Entête',               0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'SP_XAT_Det_CERTIFS', 'DET', N'Certificats médicaux', 1, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP3, 'ENT',     'Matricule',       N'Matricule',           'nvarchar', 20,   NULL, NULL, 'true', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP3, 'ENT',     'Dat_Accident',    N'Date de l''accident', 'date',     NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP3, 'ENT',     'Heure_Accident',  N'Heure',               'nvarchar', 5,    NULL, NULL, 'true', NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP3, 'ENT',     'Lieu_Accident',   N'Lieu',                'nvarchar', 200,  NULL, NULL, 'true', NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP3, 'ENT',     'Circonstances',   N'Circonstances',       'nvarchar', 1000, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 5, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'Typ_Certificat',  N'Type de certificat',  'nvarchar', 50,   NULL, NULL, 'true', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'Dat_Certificat',  N'Date du certificat',  'date',     NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'Dat_Debut_Arret', N'Début de l''arrêt',   'date',     NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'Dat_Fin_Arret',   N'Fin de l''arrêt',     'date',     NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'Nbr_Jours',       N'Nombre de jours',     'int',      NULL, NULL, NULL, 'true', NULL, 'false', 'false', 'false', 5, GETDATE(), @Login),
        (@CP3, 'CERTIFS', 'Comment',         N'Commentaire',         'nvarchar', 300,  NULL, NULL, 'true', NULL, 'false', 'false', 'false', 6, GETDATE(), @Login);

    -- Tous les champs en lecture seule ('R') : la page standard portail est une consultation
    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Regle_Visibilite, Regle_Activation,
        Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP3, 'Num_Doc',          'ENT', '',                N'N° déclaration',  'TEXT', 1, 1, 1, 3,  NULL, 'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 1, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'Matricule',        'ENT', 'Matricule',       N'Matricule',       'ZOOM', 2, 1, 2, 3,  NULL, 'false', 'R', NULL, 'MS067', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1, NULL, 'true',  1,    NULL, GETDATE(), @Login),
        (@CP3, 'Dat_Accident',     'ENT', 'Dat_Accident',    N'Date Accident',   'DATE', 3, 1, 3, 3,  NULL, 'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  2, NULL, 'true',  2,    NULL, GETDATE(), @Login),
        (@CP3, 'Heure_Accident',   'ENT', 'Heure_Accident',  N'Heure',           'TEXT', 4, 1, 4, 3,  NULL, 'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  3, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'Lieu_Accident',    'ENT', 'Lieu_Accident',   N'Lieu',            'TEXT', 5, 2, 1, 6,  NULL, 'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  4, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'Circonstances',    'ENT', 'Circonstances',   N'Circonstances',   'MEMO', 6, 3, 1, 12, NULL, 'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 5, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'C_Typ_Certificat', 'CERTIFS', 'Typ_Certificat',  N'Type Certificat', 'TEXT', 1, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 1, 10, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'C_Dat_Certificat', 'CERTIFS', 'Dat_Certificat',  N'Date Certificat', 'DATE', 2, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 2, 8,  'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'C_Dat_Debut_Arret','CERTIFS', 'Dat_Debut_Arret', N'Début Arrêt',     'DATE', 3, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 3, 8,  'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'C_Dat_Fin_Arret',  'CERTIFS', 'Dat_Fin_Arret',   N'Fin Arrêt',       'DATE', 4, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 4, 8,  'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'C_Nbr_Jours',      'CERTIFS', 'Nbr_Jours',       N'Nbr Jours',       'INT',  5, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 5, 5,  'false', NULL, NULL, GETDATE(), @Login),
        (@CP3, 'C_Comment',        'CERTIFS', 'Comment',         N'Commentaire',     'TEXT', 6, NULL, NULL, NULL, NULL, 'false', 'R', NULL, NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true', 6, 20, 'false', NULL, NULL, GETDATE(), @Login);

    -- Consultation + pieces jointes uniquement (comme la page portail standard)
    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    SELECT @CP3, p.Cod_Profile, 'true', 'false', 'false', 'false', 'false', 'false', 'true', GETDATE(), @Login
    FROM dbo.Controle_Profile p WHERE ISNULL(p.Actif, 1) = 1;

    IF OBJECT_ID('dbo.SP_XAT_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XAT_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_XAT_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NULL,
            [Dat_Accident] date NULL,
            [Heure_Accident] nvarchar(5) NULL,
            [Lieu_Accident] nvarchar(200) NULL,
            [Circonstances] nvarchar(1000) NULL,
            CONSTRAINT [PK_SP_XAT_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END

    IF OBJECT_ID('dbo.SP_XAT_Det_CERTIFS', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XAT_Det_CERTIFS] (
            [RowId] int IDENTITY(1,1) NOT NULL,
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [Typ_Certificat] nvarchar(50) NULL,
            [Dat_Certificat] date NULL,
            [Dat_Debut_Arret] date NULL,
            [Dat_Fin_Arret] date NULL,
            [Nbr_Jours] int NULL,
            [Comment] nvarchar(300) NULL,
            CONSTRAINT [PK_SP_XAT_Det_CERTIFS] PRIMARY KEY ([RowId])
        );
    END

    IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SP_XAT_Det_CERTIFS_Ent')
        ALTER TABLE dbo.[SP_XAT_Det_CERTIFS] WITH NOCHECK ADD CONSTRAINT [FK_SP_XAT_Det_CERTIFS_Ent]
            FOREIGN KEY ([Num_Doc], [id_Societe]) REFERENCES dbo.[SP_XAT_Ent] ([Num_Doc], [id_Societe]) ON DELETE CASCADE;

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP3 AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP3, 'CREATE', 'CREATE TABLE SP_XAT_Ent / SP_XAT_Det_CERTIFS + FK (script duplicata DUP-PAGES-2026-08)', 'true',
                N'Tables créées par le script duplicata', @Login, GETDATE());

    IF OBJECT_ID('dbo.SP_XAT_Ent', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XAT_Ent', 16, 1);
    IF OBJECT_ID('dbo.SP_XAT_Det_CERTIFS', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XAT_Det_CERTIFS', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP3 AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP3 AND Statut_Page <> 'PUBLIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'SPP_DUP_DECLARATION_AT')
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES ('SPP_DUP_DECLARATION_AT', 'SP_XAT_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = 'SP_XAT_Ent', PJ = 'true' WHERE Name_Ecran = 'SPP_DUP_DECLARATION_AT';

    /* Pas de Param_Workflow_Typ_Document : la page standard portail est en
       consultation seule (pas de soumission en signature cote portail). */

    /* -- OPTIONNEL (test) : document d'exemple. Decommenter si besoin. ------
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_XAT_Ent WHERE Num_Doc = 'XAT-TEST' AND id_Societe = 3068)
    BEGIN
        INSERT INTO dbo.SP_XAT_Ent (Num_Doc, id_Societe, Statut, Matricule, Dat_Accident, Heure_Accident,
            Lieu_Accident, Circonstances, Dat_Crea, Created_By, Dat_Modif, Modified_By)
        VALUES ('XAT-TEST', 3068, '', 'A0001', '2026-08-01', '10:30', N'Atelier',
                N'Chute de plain-pied (document d''exemple pour test du Designer).', GETDATE(), @Login, GETDATE(), @Login);
        INSERT INTO dbo.SP_XAT_Det_CERTIFS (Num_Doc, id_Societe, Typ_Certificat, Dat_Certificat,
            Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Comment, Dat_Crea, Created_By)
        VALUES ('XAT-TEST', 3068, 'Initial', '2026-08-01', '2026-08-02', '2026-08-15', 14, N'Certificat initial', GETDATE(), @Login),
               ('XAT-TEST', 3068, 'Prolongation', '2026-08-16', '2026-08-16', '2026-08-31', 16, N'Prolongation', GETDATE(), @Login);
    END
    -------------------------------------------------------------------------- */

/* ##########################################################################
   PAGE 4/6 : DUP_DOSSIER_MALADIE (XDM) - duplicata de "Dossier de maladie"
   ########################################################################## */
    DECLARE @CP4 nvarchar(30) = 'DUP_DOSSIER_MALADIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP4)
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, Figer_Statuts, Dat_Crea, Created_By)
        VALUES (@CP4, 'XDM', N'Duplicata - Dossier de remboursement maladie (test Designer)', N'Dossier maladie (SP)', N'Dossier de maladie (SP)',
            'PagesSpecifiques', 4, 'MedicalInformation', 'BROUILLON', 'SP_XDM_Ent', 'XDM',
            'true', NULL, 'true', NULL, 'false',
            'true', 'true', 'true', 'false', 'true', 'SS,SG,RJ,SP,VA', GETDATE(), @Login);
    ELSE
        UPDATE dbo.SP_Page
        SET Libelle = N'Duplicata - Dossier de remboursement maladie (test Designer)', Libelle_Court = N'Dossier maladie (SP)',
            Nom_Page = N'Dossier de maladie (SP)', Menu_Parent = 'PagesSpecifiques', Rang = 4, Icone = 'MedicalInformation',
            Workflow_Actif = 'true', GED_Actif = 'true',
            Act_Enregistrer = 'true', Act_Soumettre = 'true', Act_Imprimer = 'true', Act_Exporter = 'false',
            Acces_Personnalise = 'true', Figer_Statuts = 'SS,SG,RJ,SP,VA', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP4;

    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP4;
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP4;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP4;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP4;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP4;

    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping, Dat_Crea, Created_By)
    VALUES (@CP4, 'ENT', 'SP_XDM_Ent', 'ENT', N'Entête', 0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP4, 'ENT', 'Matricule',         N'Matricule',         'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP4, 'ENT', 'Lien',              N'Lien du malade',    'nvarchar', 1,    NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP4, 'ENT', 'Nom_Malade',        N'Nom du malade',     'nvarchar', 100,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP4, 'ENT', 'Typ_Maladie',       N'Type de maladie',   'nvarchar', 30,   NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP4, 'ENT', 'Dat_Dossier',       N'Date',              'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 5, GETDATE(), @Login),
        (@CP4, 'ENT', 'Mnt_Engage',        N'Montant engagé',    'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 6, GETDATE(), @Login),
        (@CP4, 'ENT', 'Envoye_Le',         N'Envoyé le',         'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 7, GETDATE(), @Login),
        (@CP4, 'ENT', 'Rembourse_Le',      N'Remboursé le',      'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 8, GETDATE(), @Login),
        (@CP4, 'ENT', 'Mnt_Remboursement', N'Montant remboursé', 'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 9, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Regle_Visibilite, Regle_Activation,
        Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP4, 'Num_Doc',       'ENT', '',                 N'N° dossier',    'TEXT',     1,  1, 1, 6, NULL,           'false', 'R', NULL,             NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 1, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP4, 'Matricule',     'ENT', 'Matricule',        N'Matricule',     'ZOOM',     2,  1, 2, 6, 'GV_MATRICULE', 'true',  'R', NULL,             'MS067', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1, NULL, 'true',  1,    NULL, GETDATE(), @Login),
        (@CP4, 'Lien',          'ENT', 'Lien',             N'Le malade',     'RADIO',    3,  2, 1, 6, 'A',            'true',  'S', 'SP_Lien_Malade', NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 2, NULL, 'false', NULL, N'Agent lui-même ou membre de la famille', GETDATE(), @Login),
        (@CP4, 'Nom_Malade',    'ENT', 'Nom_Malade',       N'Le malade',     'COMBO',    4,  2, 2, 6, NULL,           'false', 'S', NULL,             'MS023', NULL, NULL, 'false', NULL, NULL,
            '{"op":"EQ","args":[{"ref":"Lien"},{"const":"L"}]}', NULL, 'true', 2, NULL, 'false', NULL, N'Membre de la famille de l''agent (zoom MS023)', GETDATE(), @Login),
        (@CP4, 'Typ_Maladie',   'ENT', 'Typ_Maladie',      N'Maladie',       'RUBRIQUE', 5,  3, 1, 6, NULL,           'false', 'S', 'Typ_Maladie',    NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  3, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP4, 'Dat_Dossier',   'ENT', 'Dat_Dossier',      N'Date',          'DATE',     6,  3, 2, 6, 'GV_NOW',       'true',  'S', NULL,             NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  4, NULL, 'true',  2,    NULL, GETDATE(), @Login),
        (@CP4, 'Mnt_Engage',    'ENT', 'Mnt_Engage',       N'Montant',       'MNT',      7,  4, 1, 6, '0',            'true',  'S', NULL,             NULL,    NULL, NULL, 'false', 'MNT', 2, NULL, NULL, 'true',  5, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP4, 'Envoye_Le',     'ENT', 'Envoye_Le',        N'Envoyé le',     'DATE',     8,  4, 2, 6, NULL,           'false', 'R', NULL,             NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  6, NULL, 'false', NULL, N'Renseigné par le gestionnaire', GETDATE(), @Login),
        (@CP4, 'Rembourse_Le',  'ENT', 'Rembourse_Le',     N'Remboursé le',  'DATE',     9,  5, 1, 6, NULL,           'false', 'R', NULL,             NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  7, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP4, 'Mnt_Remboursement', 'ENT', 'Mnt_Remboursement', N'Montant remboursé', 'MNT', 10, 5, 2, 6, '0',        'false', 'R', NULL,             NULL,    NULL, NULL, 'false', 'MNT', 2, NULL, NULL, 'true',  8, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP4, 'Taux_Remboursement', 'ENT', '',            N'Taux de remboursement', 'CALCULE', 11, 6, 1, 6, NULL,    'false', 'A', NULL,             NULL,    NULL,
            '{"op":"DIVSAFE","args":[{"ref":"Mnt_Remboursement"},{"ref":"Mnt_Engage"}]}', 'false', 'PCT', 2, NULL, NULL, 'false', 9, NULL, 'false', NULL, N'Montant remboursé / Montant engagé', GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ,
        Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
    VALUES
        (@CP4, 'V00_PROPRIETAIRE', 'CHAMP', 'ENT', 'Matricule',  'SOURCE',
            '{"source":"sp_check_proprietaire","mapping":{"Doc_Matricule":{"ref":"Matricule"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":1}]}}', NULL,
            N'Vous ne pouvez pas saisir un dossier pour un autre matricule.', 'B', 0, 'SAVE', 'true', GETDATE(), @Login),
        (@CP4, 'V01_MATRICULE', 'CHAMP', 'ENT', 'Matricule',  'REQUIRED', NULL, NULL,
            N'Veuillez renseigner le matricule.', 'B', 1, 'SAVE', 'true', GETDATE(), @Login),
        (@CP4, 'V02_MNT',       'CHAMP', 'ENT', 'Mnt_Engage', 'COMPARE', '{"operateur":"GT","constante":0}', NULL,
            N'Aucun montant engagé n''est renseigné.', 'B', 2, 'SAVE', 'true', GETDATE(), @Login);

    -- Zoom conditionnel (P5) : le combo "Le malade" est filtré par le matricule
    UPDATE dbo.SP_Page_Champ SET Zoom_Condition = 'Matricule=''{Matricule}'''
    WHERE Cod_Page = @CP4 AND Cod_Champ = 'Nom_Malade';

    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    SELECT @CP4, p.Cod_Profile, 'true', 'true', 'true', 'true', 'true', 'true', 'true', GETDATE(), @Login
    FROM dbo.Controle_Profile p WHERE ISNULL(p.Actif, 1) = 1;

    IF OBJECT_ID('dbo.SP_XDM_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XDM_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_XDM_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_XDM_Ent_Matricule] DEFAULT (''),
            [Lien] nvarchar(1) NULL,
            [Nom_Malade] nvarchar(100) NULL,
            [Typ_Maladie] nvarchar(30) NULL,
            [Dat_Dossier] date NULL,
            [Mnt_Engage] decimal(18,2) NULL,
            [Envoye_Le] date NULL,
            [Rembourse_Le] date NULL,
            [Mnt_Remboursement] decimal(18,2) NULL,
            CONSTRAINT [PK_SP_XDM_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP4 AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP4, 'CREATE', 'CREATE TABLE SP_XDM_Ent (script duplicata DUP-PAGES-2026-08)', 'true',
                N'Table créée par le script duplicata', @Login, GETDATE());

    IF OBJECT_ID('dbo.SP_XDM_Ent', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XDM_Ent', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Matricule'),('Lien'),('Nom_Malade'),('Typ_Maladie'),('Dat_Dossier'),
               ('Mnt_Engage'),('Envoye_Le'),('Rembourse_Le'),('Mnt_Remboursement')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_XDM_Ent', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_XDM_Ent', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP4 AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP4 AND Statut_Page <> 'PUBLIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'SPP_DUP_DOSSIER_MALADIE')
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES ('SPP_DUP_DOSSIER_MALADIE', 'SP_XDM_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = 'SP_XDM_Ent', PJ = 'true' WHERE Name_Ecran = 'SPP_DUP_DOSSIER_MALADIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = 'XDM')
        INSERT INTO dbo.Param_Workflow_Typ_Document
            (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
        VALUES ('XDM', N'Duplicata - Dossier de maladie (SP)', 'SP_XDM_Ent', 'Num_Doc', 'false', 'SPP_DUP_DOSSIER_MALADIE', 'Num_Doc', 'Created_By', -1);
    ELSE
        UPDATE dbo.Param_Workflow_Typ_Document
        SET Intitule = N'Duplicata - Dossier de maladie (SP)', Table_Ref = 'SP_XDM_Ent', Name_Ecran = 'SPP_DUP_DOSSIER_MALADIE'
        WHERE Typ_Document = 'XDM';

/* ##########################################################################
   PAGE 5/6 : DUP_AVANCE (XAV) - duplicata de "Demande d'avance"
   ########################################################################## */
    DECLARE @CP5 nvarchar(30) = 'DUP_AVANCE';

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP5)
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, Figer_Statuts, Dat_Crea, Created_By)
        VALUES (@CP5, 'XAV', N'Duplicata - Demande d''avance (test Designer)', N'Avance (SP)', N'Demande d''avance (SP)',
            'PagesSpecifiques', 5, 'Payments', 'BROUILLON', 'SP_XAV_Ent', 'XAV',
            'true', NULL, 'true', NULL, 'false',
            'true', 'true', 'true', 'false', 'true', 'SS,SG,RJ,SP,VA', GETDATE(), @Login);
    ELSE
        UPDATE dbo.SP_Page
        SET Libelle = N'Duplicata - Demande d''avance (test Designer)', Libelle_Court = N'Avance (SP)',
            Nom_Page = N'Demande d''avance (SP)', Menu_Parent = 'PagesSpecifiques', Rang = 5, Icone = 'Payments',
            Workflow_Actif = 'true', GED_Actif = 'true',
            Act_Enregistrer = 'true', Act_Soumettre = 'true', Act_Imprimer = 'true', Act_Exporter = 'false',
            Acces_Personnalise = 'true', Figer_Statuts = 'SS,SG,RJ,SP,VA', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP5;

    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP5;
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP5;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP5;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP5;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP5;

    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping, Dat_Crea, Created_By)
    VALUES (@CP5, 'ENT', 'SP_XAV_Ent', 'ENT', N'Entête', 0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP5, 'ENT', 'Matricule',       N'Matricule',            'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP5, 'ENT', 'Dat_Demande',     N'Date de demande',      'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP5, 'ENT', 'Montant_Avance',  N'Montant de l''avance', 'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP5, 'ENT', 'Dernier_Salaire', N'Dernier salaire',      'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP5, 'ENT', 'Commentaire',     N'Commentaire',          'nvarchar', 500,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 5, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Regle_Visibilite, Regle_Activation,
        Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP5, 'Num_Doc',         'ENT', '',                N'N° demande',       'TEXT',   1, 1, 1, 6,  NULL,           'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 1, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP5, 'Matricule',       'ENT', 'Matricule',       N'Matricule',        'ZOOM',   2, 1, 2, 6,  'GV_MATRICULE', 'true',  'R', NULL, 'MS067', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1, NULL, 'true',  1,    NULL, GETDATE(), @Login),
        (@CP5, 'Dat_Demande',     'ENT', 'Dat_Demande',     N'Date',             'DATE',   3, 2, 1, 6,  'GV_NOW',       'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  2, NULL, 'true',  2,    NULL, GETDATE(), @Login),
        (@CP5, 'Montant_Avance',  'ENT', 'Montant_Avance',  N'Montant',          'MNT',    4, 2, 2, 6,  '0',            'true',  'S', NULL, NULL,    NULL, NULL, 'false', 'MNT', 2, NULL, NULL, 'true',  3, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP5, 'Avances_Encours', 'ENT', '',                N'Avances en cours', 'SOURCE', 5, 3, 1, 6,  NULL,           'false', 'A', NULL, NULL,    'sp_avances_encours',
            '{"source":"sp_avances_encours","mapping":{"Matricule":{"ref":"Matricule"}}}',
            'false', 'MNT', 2, NULL, NULL, 'false', 4, NULL, 'false', NULL, N'Montant des avances en cours (toutes demandes de l''agent)', GETDATE(), @Login),
        (@CP5, 'Dernier_Salaire', 'ENT', 'Dernier_Salaire', N'Dernier salaire',  'SOURCE', 6, 3, 2, 6,  NULL,           'false', 'A', NULL, NULL,    'sp_dernier_salaire_av',
            '{"source":"sp_dernier_salaire_av","mapping":{"Matricule":{"ref":"Matricule"}}}',
            'true', 'MNT', 2, NULL, NULL, 'true', 5, NULL, 'false', NULL, N'Dernier salaire net (rubriques du plan de paie)', GETDATE(), @Login),
        (@CP5, 'Statut',          'ENT', 'Statut',          N'Statut',           'RUBRIQUE', 7, 4, 1, 6, NULL,           'false', 'R', 'Statut_Signature', NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 7, NULL, 'true', 3, N'Statut du circuit de signature (colonne technique)', GETDATE(), @Login),
        (@CP5, 'Commentaire',     'ENT', 'Commentaire',     N'Commentaire',      'MEMO',   8, 5, 1, 12, NULL,           'false', 'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  6, NULL, 'false', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ,
        Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
    VALUES
        (@CP5, 'V00_PROPRIETAIRE', 'CHAMP', 'ENT', 'Matricule', 'SOURCE',
            '{"source":"sp_check_proprietaire","mapping":{"Doc_Matricule":{"ref":"Matricule"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":1}]}}', NULL,
            N'Vous ne pouvez pas saisir une Demande pour un autre matricule.', 'B', 0, 'SAVE', 'true', GETDATE(), @Login),
        (@CP5, 'V01_MATRICULE', 'CHAMP', 'ENT', 'Matricule', 'REQUIRED', NULL, NULL,
            N'Veuillez renseigner le matricule.', 'B', 1, 'SAVE', 'true', GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    SELECT @CP5, p.Cod_Profile, 'true', 'true', 'true', 'true', 'true', 'true', 'true', GETDATE(), @Login
    FROM dbo.Controle_Profile p WHERE ISNULL(p.Actif, 1) = 1;

    IF OBJECT_ID('dbo.SP_XAV_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XAV_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_XAV_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_XAV_Ent_Matricule] DEFAULT (''),
            [Dat_Demande] date NULL,
            [Montant_Avance] decimal(18,2) NULL,
            [Dernier_Salaire] decimal(18,2) NULL,
            [Commentaire] nvarchar(500) NULL,
            CONSTRAINT [PK_SP_XAV_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP5 AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP5, 'CREATE', 'CREATE TABLE SP_XAV_Ent (script duplicata DUP-PAGES-2026-08)', 'true',
                N'Table créée par le script duplicata', @Login, GETDATE());

    IF OBJECT_ID('dbo.SP_XAV_Ent', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XAV_Ent', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Matricule'),('Dat_Demande'),('Montant_Avance'),('Dernier_Salaire'),('Commentaire')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_XAV_Ent', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_XAV_Ent', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP5 AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP5 AND Statut_Page <> 'PUBLIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'SPP_DUP_AVANCE')
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES ('SPP_DUP_AVANCE', 'SP_XAV_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = 'SP_XAV_Ent', PJ = 'true' WHERE Name_Ecran = 'SPP_DUP_AVANCE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = 'XAV')
        INSERT INTO dbo.Param_Workflow_Typ_Document
            (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
        VALUES ('XAV', N'Duplicata - Demande d''avance (SP)', 'SP_XAV_Ent', 'Num_Doc', 'false', 'SPP_DUP_AVANCE', 'Num_Doc', 'Created_By', -1);
    ELSE
        UPDATE dbo.Param_Workflow_Typ_Document
        SET Intitule = N'Duplicata - Demande d''avance (SP)', Table_Ref = 'SP_XAV_Ent', Name_Ecran = 'SPP_DUP_AVANCE'
        WHERE Typ_Document = 'XAV';

/* ##########################################################################
   PAGE 6/6 : DUP_PRET (XDP) - duplicata de "Demande de pret"
   ########################################################################## */
    DECLARE @CP6 nvarchar(30) = 'DUP_PRET';

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP6)
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, Figer_Statuts, Dat_Crea, Created_By)
        VALUES (@CP6, 'XDP', N'Duplicata - Demande de prêt (test Designer)', N'Prêt (SP)', N'Demande de prêt (SP)',
            'PagesSpecifiques', 6, 'Handshake', 'BROUILLON', 'SP_XDP_Ent', 'XDP',
            'true', NULL, 'true', NULL, 'false',
            'true', 'true', 'true', 'false', 'true', 'SS,SG,RJ,SP,VA', GETDATE(), @Login);
    ELSE
        UPDATE dbo.SP_Page
        SET Libelle = N'Duplicata - Demande de prêt (test Designer)', Libelle_Court = N'Prêt (SP)',
            Nom_Page = N'Demande de prêt (SP)', Menu_Parent = 'PagesSpecifiques', Rang = 6, Icone = 'Handshake',
            Workflow_Actif = 'true', GED_Actif = 'true',
            Act_Enregistrer = 'true', Act_Soumettre = 'true', Act_Imprimer = 'true', Act_Exporter = 'false',
            Acces_Personnalise = 'true', Figer_Statuts = 'SS,SG,RJ,SP,VA', Dat_Modif = GETDATE(), Modified_By = @Login
        WHERE Cod_Page = @CP6;

    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP6;
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP6;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP6;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP6;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP6;

    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping, Dat_Crea, Created_By)
    VALUES (@CP6, 'ENT', 'SP_XDP_Ent', 'ENT', N'Entête', 0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP6, 'ENT', 'Matricule',         N'Matricule',          'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP6, 'ENT', 'Dat_Demande',       N'Date de demande',    'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP6, 'ENT', 'Montant_Pret',      N'Montant du prêt',    'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP6, 'ENT', 'Nb_Echeance',       N'Durée en mois',      'int',      NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP6, 'ENT', 'Premiere_Echeance', N'Première échéance',  'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 5, GETDATE(), @Login),
        (@CP6, 'ENT', 'Commentaire',       N'Commentaire',        'nvarchar', 500,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 6, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Regle_Visibilite, Regle_Activation,
        Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP6, 'Num_Doc',           'ENT', '',                  N'N° demande',      'TEXT',   1, 1, 1, 6,  NULL,           'false', 'R', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 1, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP6, 'Matricule',         'ENT', 'Matricule',         N'Matricule',       'ZOOM',   2, 1, 2, 6,  'GV_MATRICULE', 'true',  'R', NULL, 'MS067', NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  1, NULL, 'true',  1,    NULL, GETDATE(), @Login),
        (@CP6, 'Dat_Demande',       'ENT', 'Dat_Demande',       N'Date',            'DATE',   3, 2, 1, 6,  'GV_NOW',       'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  2, NULL, 'true',  2,    NULL, GETDATE(), @Login),
        (@CP6, 'Montant_Pret',      'ENT', 'Montant_Pret',      N'Montant',         'MNT',    4, 2, 2, 6,  '0',            'true',  'S', NULL, NULL,    NULL, NULL, 'false', 'MNT', 2, NULL, NULL, 'true',  3, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP6, 'Nb_Echeance',       'ENT', 'Nb_Echeance',       N'Durée en mois',   'INT',    5, 3, 1, 6,  '12',           'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  4, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP6, 'Premiere_Echeance', 'ENT', 'Premiere_Echeance', N'1ère échéance',   'DATE',   6, 3, 2, 6,  'GV_NOW',       'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 5, NULL, 'false', NULL, NULL, GETDATE(), @Login),
        (@CP6, 'Prets_Encours',     'ENT', '',                  N'Prets en cours',  'SOURCE', 7, 4, 1, 6,  NULL,           'false', 'A', NULL, NULL,    'sp_prets_encours',
            '{"source":"sp_prets_encours","mapping":{"Matricule":{"ref":"Matricule"}}}',
            'false', 'MNT', 2, NULL, NULL, 'false', 6, NULL, 'false', NULL, N'Montant des prêts en cours (toutes demandes de l''agent)', GETDATE(), @Login),
        (@CP6, 'Dernier_Salaire',   'ENT', '',                  N'Dernier salaire', 'SOURCE', 8, 4, 2, 6,  NULL,           'false', 'A', NULL, NULL,    'sp_dernier_salaire_pr',
            '{"source":"sp_dernier_salaire_pr","mapping":{"Matricule":{"ref":"Matricule"}}}',
            'false', 'MNT', 2, NULL, NULL, 'false', 7, NULL, 'false', NULL, N'Dernier salaire net (rubriques du plan de paie)', GETDATE(), @Login),
        (@CP6, 'Statut',            'ENT', 'Statut',            N'Statut',          'RUBRIQUE', 9, 5, 1, 6, NULL,           'false', 'R', 'Statut_Signature', NULL, NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'false', 9, NULL, 'true', 3, N'Statut du circuit de signature (colonne technique)', GETDATE(), @Login),
        (@CP6, 'Commentaire',       'ENT', 'Commentaire',       N'Commentaire',     'MEMO',   10, 6, 1, 12, NULL,           'false', 'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, NULL, NULL, 'true',  8, NULL, 'false', NULL, NULL, GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ,
        Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
    VALUES
        (@CP6, 'V00_PROPRIETAIRE', 'CHAMP', 'ENT', 'Matricule', 'SOURCE',
            '{"source":"sp_check_proprietaire","mapping":{"Doc_Matricule":{"ref":"Matricule"}},"cond":{"op":"EQ","args":[{"ref":"@result"},{"const":1}]}}', NULL,
            N'Vous ne pouvez pas saisir une Demande pour un autre matricule.', 'B', 0, 'SAVE', 'true', GETDATE(), @Login),
        (@CP6, 'V01_MATRICULE', 'CHAMP', 'ENT', 'Matricule', 'REQUIRED', NULL, NULL,
            N'Veuillez renseigner le matricule.', 'B', 1, 'SAVE', 'true', GETDATE(), @Login);

    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    SELECT @CP6, p.Cod_Profile, 'true', 'true', 'true', 'true', 'true', 'true', 'true', GETDATE(), @Login
    FROM dbo.Controle_Profile p WHERE ISNULL(p.Actif, 1) = 1;

    IF OBJECT_ID('dbo.SP_XDP_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_XDP_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_XDP_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_XDP_Ent_Matricule] DEFAULT (''),
            [Dat_Demande] date NULL,
            [Montant_Pret] decimal(18,2) NULL,
            [Nb_Echeance] int NULL,
            [Premiere_Echeance] date NULL,
            [Commentaire] nvarchar(500) NULL,
            CONSTRAINT [PK_SP_XDP_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP6 AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP6, 'CREATE', 'CREATE TABLE SP_XDP_Ent (script duplicata DUP-PAGES-2026-08)', 'true',
                N'Table créée par le script duplicata', @Login, GETDATE());

    IF OBJECT_ID('dbo.SP_XDP_Ent', 'U') IS NULL RAISERROR('Table physique inexistante : SP_XDP_Ent', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Matricule'),('Dat_Demande'),('Montant_Pret'),('Nb_Echeance'),('Premiere_Echeance'),('Commentaire')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_XDP_Ent', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_XDP_Ent', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP6 AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP6 AND Statut_Page <> 'PUBLIE';

    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'SPP_DUP_PRET')
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES ('SPP_DUP_PRET', 'SP_XDP_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = 'SP_XDP_Ent', PJ = 'true' WHERE Name_Ecran = 'SPP_DUP_PRET';

    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = 'XDP')
        INSERT INTO dbo.Param_Workflow_Typ_Document
            (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
        VALUES ('XDP', N'Duplicata - Demande de prêt (SP)', 'SP_XDP_Ent', 'Num_Doc', 'false', 'SPP_DUP_PRET', 'Num_Doc', 'Created_By', -1);
    ELSE
        UPDATE dbo.Param_Workflow_Typ_Document
        SET Intitule = N'Duplicata - Demande de prêt (SP)', Table_Ref = 'SP_XDP_Ent', Name_Ecran = 'SPP_DUP_PRET'
        WHERE Typ_Document = 'XDP';

/* --------------------------------------------------------------------------
   4. Circuits de signature des duplicatas (miroir des circuits standards :
      memes societes, memes lignes, memes regles de signataires ; seules la
      table et la cle du document sont substituees - tables SP_X**_Ent et
      Num_Doc. Les circuits des types standards ne sont jamais modifies.)
   -------------------------------------------------------------------------- */
    -- 4.1 En-tetes de circuit (copie conforme du type standard associe)
    INSERT INTO dbo.Workflow_Signatures (Typ_Document, id_Societe, Typ_Signature, Table_Ref, Table_Index,
        Actif, Signataire_Defaut, Dat_Crea, Created_By)
    SELECT m.CodDup, w.id_Societe, w.Typ_Signature, m.TableDup, 'Num_Doc',
           w.Actif, w.Signataire_Defaut, GETDATE(), @Login
    FROM dbo.Workflow_Signatures w
    JOIN (VALUES ('C',  'XCG', 'SP_XCG_Ent'),
                 ('NF', 'XNF', 'SP_XNF_Ent'),
                 ('AV', 'XAV', 'SP_XAV_Ent'),
                 ('DP', 'XDP', 'SP_XDP_Ent'),
                 ('DM', 'XDM', 'SP_XDM_Ent')) m(CodStd, CodDup, TableDup)
      ON m.CodStd = w.Typ_Document
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Workflow_Signatures x
                      WHERE x.Typ_Document = m.CodDup AND x.id_Societe = w.id_Societe);

    -- 4.2 Lignes de circuit (Traitement / regles de signataires substitues)
    INSERT INTO dbo.Workflow_Signatures_Detail (Typ_Document, id_Societe, Num_Ligne, Lib_Ligne,
        Operande_Signature, Dans_Ordre, Condition, Traitement, Typ_Liste, Query_Sigantaire,
        Sql_Signataires, RegrouperSignataires)
    SELECT m.CodDup, d.id_Societe, d.Num_Ligne, d.Lib_Ligne,
           d.Operande_Signature, d.Dans_Ordre, d.Condition,
           REPLACE(REPLACE(d.Traitement, m.TableStd, m.TableDup), m.PkStd, 'Num_Doc'),
           d.Typ_Liste,
           REPLACE(REPLACE(d.Query_Sigantaire, m.TableStd, m.TableDup), m.PkStd, 'Num_Doc'),
           REPLACE(REPLACE(d.Sql_Signataires, m.TableStd, m.TableDup), m.PkStd, 'Num_Doc'),
           d.RegrouperSignataires
    FROM dbo.Workflow_Signatures_Detail d
    JOIN (VALUES ('C',  'XCG', 'RH_Conge_Suivi',     'SP_XCG_Ent', 'Num_Conge'),
                 ('NF', 'XNF', 'Rh_Note_Frais',     'SP_XNF_Ent', 'Num_NF'),
                 ('AV', 'XAV', 'RH_Paie_Avance',    'SP_XAV_Ent', 'Num_Avance'),
                 ('DP', 'XDP', 'RH_Pret_Demande',   'SP_XDP_Ent', 'Num_Demande_Pret'),
                 ('DM', 'XDM', 'RH_Dossier_Maladie','SP_XDM_Ent', 'Num_Dossier')) m(CodStd, CodDup, TableStd, TableDup, PkStd)
      ON m.CodStd = d.Typ_Document
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Workflow_Signatures_Detail x
                      WHERE x.Typ_Document = m.CodDup AND x.id_Societe = d.id_Societe AND x.Num_Ligne = d.Num_Ligne);

    -- 4.3 Signataires fixes (copie des listes explicites du standard)
    INSERT INTO dbo.Workflow_Signatures_Signataires (Typ_Document, id_Societe, Num_Ligne, Signataire, Peut_Annuler)
    SELECT m.CodDup, s.id_Societe, s.Num_Ligne, s.Signataire, s.Peut_Annuler
    FROM dbo.Workflow_Signatures_Signataires s
    JOIN (VALUES ('C','XCG'),('NF','XNF'),('AV','XAV'),('DP','XDP'),('DM','XDM')) m(CodStd, CodDup)
      ON m.CodStd = s.Typ_Document
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Workflow_Signatures_Signataires x
                      WHERE x.Typ_Document = m.CodDup AND x.id_Societe = s.id_Societe
                        AND x.Num_Ligne = s.Num_Ligne AND x.Signataire = s.Signataire);

    -- 4.4 Garde-fou : ligne de type "liste" (Typ_Liste='L') sans aucun signataire
    --     => le signataire par defaut de l'en-tete est ajoute (sinon la demande
    --     resterait "soumise" sans jamais pouvoir etre signee).
    INSERT INTO dbo.Workflow_Signatures_Signataires (Typ_Document, id_Societe, Num_Ligne, Signataire)
    SELECT h.Typ_Document, h.id_Societe, d.Num_Ligne, h.Signataire_Defaut
    FROM dbo.Workflow_Signatures h
    JOIN dbo.Workflow_Signatures_Detail d
      ON d.Typ_Document = h.Typ_Document AND d.id_Societe = h.id_Societe
    WHERE h.Typ_Document IN ('XCG','XNF','XAV','XDP','XDM')
      AND ISNULL(d.Typ_Liste, 'L') = 'L'
      AND ISNULL(h.Signataire_Defaut, '') <> ''
      AND NOT EXISTS (SELECT 1 FROM dbo.Workflow_Signatures_Signataires s
                      WHERE s.Typ_Document = d.Typ_Document AND s.id_Societe = d.id_Societe
                        AND s.Num_Ligne = d.Num_Ligne);

/* --------------------------------------------------------------------------
   5. Verification finale + issue de transaction
   -------------------------------------------------------------------------- */
    SELECT Cod_Page, Cod_Document, Statut_Page, Menu_Parent, Rang, Version_Page
    FROM dbo.SP_Page
    WHERE Cod_Page IN ('DUP_CONGE','DUP_NOTE_FRAIS','DUP_DECLARATION_AT',
                       'DUP_DOSSIER_MALADIE','DUP_AVANCE','DUP_PRET')
    ORDER BY Rang;

    SELECT Cod_Page,
           (SELECT COUNT(*) FROM dbo.SP_Page_Table t      WHERE t.Cod_Page = p.Cod_Page) AS Nb_Tables,
           (SELECT COUNT(*) FROM dbo.SP_Page_Colonne c    WHERE c.Cod_Page = p.Cod_Page) AS Nb_Colonnes,
           (SELECT COUNT(*) FROM dbo.SP_Page_Champ ch     WHERE ch.Cod_Page = p.Cod_Page) AS Nb_Champs,
           (SELECT COUNT(*) FROM dbo.SP_Page_Validation v WHERE v.Cod_Page = p.Cod_Page) AS Nb_Validations,
           (SELECT COUNT(*) FROM dbo.SP_Page_Droit d      WHERE d.Cod_Page = p.Cod_Page) AS Nb_Droits
    FROM dbo.SP_Page p
    WHERE Cod_Page IN ('DUP_CONGE','DUP_NOTE_FRAIS','DUP_DECLARATION_AT',
                       'DUP_DOSSIER_MALADIE','DUP_AVANCE','DUP_PRET')
    ORDER BY Cod_Page;

    SELECT Typ_Document, id_Societe, Typ_Signature, Actif, Signataire_Defaut
    FROM dbo.Workflow_Signatures
    WHERE Typ_Document IN ('XCG','XNF','XAV','XDP','XDM')
    ORDER BY Typ_Document, id_Societe;

    IF @DryRun = 1
    BEGIN
        PRINT '*** DRY-RUN : ROLLBACK - aucune modification persistee. ***';
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Deploiement des duplicatas termine (DUP-PAGES-2026-08).';
    END
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    DECLARE @Msg nvarchar(1000) = LEFT(ERROR_MESSAGE(), 1000);
    PRINT 'Echec deploiement duplicatas : ' + @Msg;
    ;THROW;
END CATCH;
GO


