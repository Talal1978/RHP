/* ============================================================================
   RHP - Module SP_ : controles PRE-VOL pour les duplicatas des pages standards
   ----------------------------------------------------------------------------
   Demande        : DUP-PAGES-2026-08
   Objet          : creation de 6 pages duplicatas (demande de conge, note de
                    frais, declaration AT, dossier medical, demande d'avance,
                    demande de pret) dans la section "Pages specifiques",
                    pour eprouver le Designer de pages portail (module SP_).
   100 % lecture seule. A executer AVANT le deploiement ; joindre le resultat
   au dossier de changement. Toute ligne "KO" est bloquante.
   ============================================================================ */
SET NOCOUNT ON;

/* A. Niveau de schema SP_ (SP3 = estCritere present) ------------------------ */
SELECT 'A. Niveau schema SP_' AS Controle,
       CASE WHEN OBJECT_ID('dbo.Controle_Designer','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_Table','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_Colonne','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_Champ','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_Validation','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_Source','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_Droit','U') IS NOT NULL
             AND OBJECT_ID('dbo.Controle_Designer_DDL_Log','U') IS NOT NULL
             AND COL_LENGTH('dbo.Controle_Designer','Acces_Personnalise') IS NOT NULL
             AND COL_LENGTH('dbo.Controle_Designer_Champ','estCritere') IS NOT NULL
            THEN 'OK (SP3)' ELSE 'KO' END AS Resultat;

/* B1. Codes pages / documents encore libres ---------------------------------- */
SELECT 'B1. Codes pages existants' AS Controle, Cod_Page, Statut_Page
FROM dbo.Controle_Designer
WHERE Cod_Page IN ('DUP_CONGE','DUP_NOTE_FRAIS','DUP_DECLARATION_AT',
                   'DUP_DOSSIER_MALADIE','DUP_AVANCE','DUP_PRET');
-- Attendu : 0 ligne (sinon le deploiement mettra a jour la page existante).

SELECT 'B2. Cod_Document deja pris' AS Controle, Cod_Page, Cod_Document
FROM dbo.Controle_Designer
WHERE Cod_Document IN ('XCG','XNF','XAT','XDM','XAV','XDP')
  AND Cod_Page NOT IN ('DUP_CONGE','DUP_NOTE_FRAIS','DUP_DECLARATION_AT',
                       'DUP_DOSSIER_MALADIE','DUP_AVANCE','DUP_PRET');
-- Attendu : 0 ligne. Toute ligne = KO bloquant.

/* B3. Tables physiques cibles ----------------------------------------------- */
SELECT 'B3. Tables physiques cibles deja presentes' AS Controle, t.name AS Resultat
FROM sys.tables t
WHERE t.name IN ('SP_XCG_Ent','SP_XNF_Ent','SP_XNF_Det_LIGNES',
                 'SP_XAT_Ent','SP_XAT_Det_CERTIFS','SP_XDM_Ent',
                 'SP_XAV_Ent','SP_XDP_Ent');
-- Attendu : 0 ligne. Toute ligne = verifier qu'elle appartient bien a la page
-- (Controle_Designer_Table.Nom_Physique), sinon KO.

/* C1. Section cible + rubriques --------------------------------------------- */
SELECT 'C1a. Section "PagesSpecifiques"' AS Controle, Valeur, Membre
FROM dbo.Param_Rubriques
WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = 'PagesSpecifiques';
-- 0 ligne : la section sera creee par le deploiement (non bloquant).

SELECT 'C1b. Rubriques referencees' AS Controle, Nom_Controle, COUNT(*) AS Nb
FROM dbo.Param_Rubriques
WHERE Nom_Controle IN ('am_pm','Typ_Frais','Typ_Maladie','SP_Lien_Malade')
GROUP BY Nom_Controle;
-- Attendu : am_pm, Typ_Frais, Typ_Maladie presentes (SP_Lien_Malade sera creee).

/* C2. Zooms references ------------------------------------------------------- */
SELECT 'C2. Zooms' AS Controle, Num_Zoom
FROM dbo.Controle_Def_Zoom
WHERE Num_Zoom IN ('MS067','MS165','MS023');
-- Attendu : 3 lignes. Toute absence = KO.

/* C3. Profils (droits octroyes a tous les profils actifs) -------------------- */
SELECT 'C3. Profils actifs' AS Controle, Cod_Profile, Lib_Profile
FROM dbo.Controle_Profile
WHERE ISNULL(Actif, 1) = 1;
-- Attendu : au moins le profil 1.

/* C4. Objets SQL references par les sources metier --------------------------- */
SELECT 'C4. Objets SQL' AS Controle, Objet,
       CASE Trouve WHEN 1 THEN 'OK' ELSE 'KO' END AS Resultat
FROM (VALUES
    ('dbo.Sys_Rh_Conge (IF/TF)',       CASE WHEN OBJECT_ID('dbo.Sys_Rh_Conge','IF') IS NOT NULL
                                           OR OBJECT_ID('dbo.Sys_Rh_Conge','TF') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.Sys_JourFeries (IF/TF)',     CASE WHEN OBJECT_ID('dbo.Sys_JourFeries','IF') IS NOT NULL
                                           OR OBJECT_ID('dbo.Sys_JourFeries','TF') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.Sys_Conge_CheckPeriode(FN)', CASE WHEN OBJECT_ID('dbo.Sys_Conge_CheckPeriode','FN') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.Param_Societe (U)',          CASE WHEN OBJECT_ID('dbo.Param_Societe','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.RH_Conge_Type (U)',          CASE WHEN OBJECT_ID('dbo.RH_Conge_Type','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.RH_Param_Plan_Paie (U)',     CASE WHEN OBJECT_ID('dbo.RH_Param_Plan_Paie','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.RH_Paie_Avance (U)',         CASE WHEN OBJECT_ID('dbo.RH_Paie_Avance','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.RH_Pret_Demande (U)',        CASE WHEN OBJECT_ID('dbo.RH_Pret_Demande','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.RH_Preparation_Paie_Detail', CASE WHEN OBJECT_ID('dbo.RH_Preparation_Paie_Detail','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.Param_General (U)',          CASE WHEN OBJECT_ID('dbo.Param_General','U') IS NOT NULL THEN 1 ELSE 0 END),
    ('dbo.Sys_Workflow_Signature (P)', CASE WHEN OBJECT_ID('dbo.Sys_Workflow_Signature','P') IS NOT NULL THEN 1 ELSE 0 END)
) v(Objet, Trouve);

/* C5. Circuits de signature standards (miroir pour les duplicatas) ----------- */
SELECT 'C5. Circuits sources (standard)' AS Controle, Typ_Document, id_Societe,
       Typ_Signature, Actif, ISNULL(Signataire_Defaut,'') AS Signataire_Defaut
FROM dbo.Workflow_Signatures
WHERE Typ_Document IN ('C','NF','AV','DP','DM')
ORDER BY Typ_Document, id_Societe;
-- Les circuits duplicatas (XCG/XNF/XAV/XDP/XDM) sont generes par miroir de
-- ces lignes (table SP_xxx_Ent et Num_Doc substitutes). Societes couvertes :
-- celles ou le circuit standard existe.

/* C6. Sources metier duplicatas deja presentes ------------------------------- */
SELECT 'C6. Sources SP_ existantes' AS Controle, Cod_Source, Actif
FROM dbo.Controle_Designer_Source
WHERE Cod_Source IN ('sp_solde_conge_date','sp_cng_periode_cloturee',
                     'sp_cng_controle_paie','sp_cng_repos','sp_cng_feries',
                     'sp_cng_duree','sp_avances_encours','sp_prets_encours',
                     'sp_dernier_salaire_av','sp_dernier_salaire_pr');
-- Attendu : 0 ligne (elles sont inserees si absentes, jamais ecrasees).
GO
