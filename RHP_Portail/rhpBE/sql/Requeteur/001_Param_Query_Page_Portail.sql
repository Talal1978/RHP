/* ============================================================================
   RHP - Requêteur : pages de consultation portail (Param_Query)
   ----------------------------------------------------------------------------
   Extension de Param_Query_Widget (table d'exposition portail d'une requête,
   déjà utilisée pour les widgets du tableau de bord) :
     - estPortail  : la requête devient une PAGE DE CONSULTATION du portail,
                     affichée directement depuis le menu (entrée SPQ_<Cod_Query>,
                     sans page liste) : critères saisis + grille de résultats ;
     - Menu_Parent : section du menu portail (rubrique SP_Menu_Portail) ;
     - Rang        : ordre dans la section.
   Règles d'une page-requête (appliquées par le backend portail) :
     - visibilité et exécution filtrées par Controle_Droit (Name_Ecran =
       Cod_Query, Actif) — profil '1' bypass (convention RHP) ; la section ne
       remonte que si elle contient au moins une page visible par le profil ;
     - garde-fou lecture seule (select / with / exec Sys_*, mono-instruction) ;
     - paramètres de contexte (@idSoc, @Matricule, @Login, ...) alimentés
       exclusivement par le JWT ; les autres critères déclarés
       (Param_Query_Criteres) sont saisis par l'utilisateur, typés par
       Typ_Critere ; Default_Value (constante ou GV_*) pré-remplit.
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.Param_Query_Widget', 'estPortail') IS NULL
    ALTER TABLE dbo.Param_Query_Widget
        ADD estPortail bit NOT NULL
            CONSTRAINT DF_PQW_estPortail DEFAULT (0) WITH VALUES;

IF COL_LENGTH('dbo.Param_Query_Widget', 'Menu_Parent') IS NULL
    ALTER TABLE dbo.Param_Query_Widget
        ADD Menu_Parent nvarchar(60) NOT NULL
            CONSTRAINT DF_PQW_MenuParent DEFAULT ('') WITH VALUES;

IF COL_LENGTH('dbo.Param_Query_Widget', 'Rang') IS NULL
    ALTER TABLE dbo.Param_Query_Widget
        ADD Rang int NOT NULL
            CONSTRAINT DF_PQW_Rang DEFAULT (99) WITH VALUES;

COMMIT TRANSACTION;
GO

SELECT 'Param_Query_Widget.estPortail' AS Colonne,
       CASE WHEN COL_LENGTH('dbo.Param_Query_Widget','estPortail') IS NULL THEN 'KO' ELSE 'OK' END AS Etat
UNION ALL SELECT 'Param_Query_Widget.Menu_Parent',
       CASE WHEN COL_LENGTH('dbo.Param_Query_Widget','Menu_Parent') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'Param_Query_Widget.Rang',
       CASE WHEN COL_LENGTH('dbo.Param_Query_Widget','Rang') IS NULL THEN 'KO' ELSE 'OK' END;
GO
