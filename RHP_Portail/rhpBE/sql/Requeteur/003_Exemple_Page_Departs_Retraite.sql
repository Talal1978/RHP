/* ============================================================================
   RHP - Requêteur : EXEMPLE de page de consultation portail
   ----------------------------------------------------------------------------
   « Départs en retraite » (R_Departs_Retraite) : requête Param_Query exposée
   comme page de consultation (Param_Query_Widget.estPortail) dans la section
   'PagesPersonnalisees' (« Pages personnalisées »), rang 10.
   Liste des agents actifs atteignant l'âge légal de la retraite (60 ans,
   convention CNSS) au plus tard à la date saisie :
     - @idSoc        : critère AUTO-ALIMENTÉ par le JWT (jamais demandé) ;
     - @DatRetraite  : date — Fonction 'Calender' (calendrier) — vide => tous ;
     - @Entite       : Fonction 'Appel_Zoom' (« Menu Local », zoom long) sur
                     Org_Entite (Cod_Entite / Lib_Entite) — vide => toutes ;
     - @Grade        : Fonction 'Appel_Zoom' sur Org_Grade (Cod_Grade /
                     Lib_Grade) — vide => tous.
   Le portail respecte la Fonction_Critere déclarée, comme l'écran
   d'exécution desktop Param_Query_Saisi : TextBox => saisie libre,
   Calender => calendrier, Boolean => case à cocher, Appel_Zoom / Combo =>
   liste de choix alimentée (endpoint sp_query_zoom).
   (Ces critères portent volontairement des noms HORS liste blanche JWT —
   @Matricule, @CodEntite, ... y seraient auto-alimentés par l'identité
   connectée et ne seraient jamais demandés.)
   Affichage : Matricule, Nom Prénom, Date d'embauche, Poste (littéral),
   Grade (littéral), Âge. Requête en lecture seule (SELECT mono-instruction),
   filtrée par société.
   Visibilité : profil '1' (bypass) ; autres profils : droit 'Actif' sur
   'R_Departs_Retraite' via l'écran des profils (Controle_Droit).
   Idempotent : ré-exécutable sans erreur (déclarations des critères mises
   à jour à chaque exécution).
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM Param_Query WHERE Cod_Query = 'R_Departs_Retraite')
    INSERT INTO Param_Query (Cod_Query, Nom_Query, Cod_Sql, HeaderVisible, Resume, estPivot,
                             Typ_Query, Nature_Query, Typ_Graphe, Afficher_Graphe_Valeur, Afficher3D,
                             ColonneSomme, Typ_ExportFormat, Separateur, Largeur_Fixe, Dat_Crea, Created_By)
    VALUES ('R_Departs_Retraite', N'Départs en retraite',
            N'select a.Matricule, isnull(a.Nom_Agent, '''') + '' '' + isnull(a.Prenom_Agent, '''') as Nom_Agent, a.Dat_Entree as Date_Embauche, isnull(p.Lib_Poste, a.Cod_Poste) as Poste, isnull(g.Lib_Grade, a.Cod_Grade) as Grade, datediff(year, a.Dat_Naissance, getdate()) - case when dateadd(year, datediff(year, a.Dat_Naissance, getdate()), a.Dat_Naissance) > getdate() then 1 else 0 end as Age from RH_Agent a left join Org_Poste p on p.id_Societe = a.id_Societe and p.Cod_Poste = a.Cod_Poste left join Org_Grade g on g.id_Societe = a.id_Societe and g.Cod_Grade = a.Cod_Grade where a.id_Societe = @idSoc and a.Dat_Sortie is null and a.Dat_Naissance is not null and (@DatRetraite is null or dateadd(year, 60, a.Dat_Naissance) <= @DatRetraite) and (@Entite is null or a.Cod_Entite = @Entite) and (@Grade is null or a.Cod_Grade = @Grade) order by dateadd(year, 60, a.Dat_Naissance), a.Matricule',
            1, 0, 1, 'U', 'QRY', 0, 0, 0, '', 'SP', ';', '', GETDATE(), 'SCRIPT');

-- Critères : insertion si absents, puis alignement systématique de la
-- déclaration (fonction / table / champs) sur les valeurs de référence.
IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@idSoc')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Departs_Retraite', '@idSoc', N'Société', 'int', '', '0', 'SCRIPT', GETDATE());

IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@DatRetraite')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Departs_Retraite', '@DatRetraite', N'Date de départ au plus tard (vide = tous)', 'date', '', '1', 'SCRIPT', GETDATE());
ELSE
    UPDATE Param_Query_Criteres
    SET Fonction_Critere = 'Calender', Table_Critere = NULL, Champs_01 = NULL, Champs_02 = NULL,
        Modified_By = 'SCRIPT', Dat_Modif = GETDATE()
    WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@DatRetraite';

IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@Entite')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Fonction_Critere, Table_Critere, Champs_01, Champs_02, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Departs_Retraite', '@Entite', N'Entité (vide = toutes)', 'nvarchar(max)', 'Appel_Zoom', 'Org_Entite', 'Cod_Entite', 'Lib_Entite', '', '2', 'SCRIPT', GETDATE());
ELSE
    UPDATE Param_Query_Criteres
    SET Fonction_Critere = 'Appel_Zoom', Table_Critere = 'Org_Entite', Champs_01 = 'Cod_Entite', Champs_02 = 'Lib_Entite',
        Modified_By = 'SCRIPT', Dat_Modif = GETDATE()
    WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@Entite';

IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@Grade')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Fonction_Critere, Table_Critere, Champs_01, Champs_02, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Departs_Retraite', '@Grade', N'Grade (vide = tous)', 'nvarchar(max)', 'Appel_Zoom', 'Org_Grade', 'Cod_Grade', 'Lib_Grade', '', '3', 'SCRIPT', GETDATE());
ELSE
    UPDATE Param_Query_Criteres
    SET Fonction_Critere = 'Appel_Zoom', Table_Critere = 'Org_Grade', Champs_01 = 'Cod_Grade', Champs_02 = 'Lib_Grade',
        Modified_By = 'SCRIPT', Dat_Modif = GETDATE()
    WHERE Cod_Query = 'R_Departs_Retraite' AND Critere = '@Grade';

IF NOT EXISTS (SELECT 1 FROM Param_Query_Widget WHERE Cod_Query = 'R_Departs_Retraite')
    INSERT INTO Param_Query_Widget (Cod_Query, estWidget, Widget_Type, Widget_ChartType, Icone, Couleur,
                                    DefaultSpan, Description, estPortail, Menu_Parent, Rang, Created_By, Dat_Crea)
    VALUES ('R_Departs_Retraite', 0, 'table', 'pie', 'Work', '#1976d2',
            6, N'Agents actifs atteignant l''âge de la retraite (60 ans) au plus tard à la date saisie', 1, 'PagesPersonnalisees', 10, 'SCRIPT', GETDATE());
ELSE
    UPDATE Param_Query_Widget
    SET estPortail = 1, Menu_Parent = 'PagesPersonnalisees', Rang = 10,
        Modified_By = 'SCRIPT', Dat_Modif = GETDATE()
    WHERE Cod_Query = 'R_Departs_Retraite';

COMMIT TRANSACTION;
GO

SELECT q.Cod_Query, q.Nom_Query, w.estPortail, w.Menu_Parent, w.Rang,
       (SELECT count(*) FROM Param_Query_Criteres c WHERE c.Cod_Query = q.Cod_Query) AS Nb_Criteres
FROM Param_Query q
JOIN Param_Query_Widget w ON w.Cod_Query = q.Cod_Query
WHERE q.Cod_Query = 'R_Departs_Retraite';
GO
