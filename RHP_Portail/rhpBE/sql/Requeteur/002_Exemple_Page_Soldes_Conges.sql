/* ============================================================================
   RHP - Requêteur : EXEMPLE de page de consultation portail
   ----------------------------------------------------------------------------
   « Soldes de congés » (R_Soldes_Conges) : requête Param_Query exposée comme
   page de consultation (Param_Query_Widget.estPortail) dans la section
   'mesConsultations' (« Consultations »), rang 10.
   Démonstration des conventions d'une page-requête :
     - @idSoc     : critère AUTO-ALIMENTÉ par le JWT (jamais demandé) ;
     - @Annee     : critère saisi (int) — vide => NULL => toutes les années ;
     - @Mat       : critère saisi (fragment de matricule) — nommé volontairement
                    AUTREMENT que @Matricule : ce dernier fait partie de la
                    liste blanche JWT et serait toujours alimenté avec
                    l'identité connectée (la page n'afficherait que ses données) ;
     - requête en lecture seule (SELECT mono-instruction), filtrée par société.
   Visibilité : profil '1' (bypass) ; autres profils : droit 'Actif' sur
   'R_Soldes_Conges' via l'écran des profils (Controle_Droit).
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM Param_Query WHERE Cod_Query = 'R_Soldes_Conges')
    INSERT INTO Param_Query (Cod_Query, Nom_Query, Cod_Sql, HeaderVisible, Resume, estPivot,
                             Typ_Query, Nature_Query, Typ_Graphe, Afficher_Graphe_Valeur, Afficher3D,
                             ColonneSomme, Typ_ExportFormat, Separateur, Largeur_Fixe, Dat_Crea, Created_By)
    VALUES ('R_Soldes_Conges', N'Soldes de congés',
            N'select c.Matricule, isnull(a.Nom_Agent, '''') + '' '' + isnull(a.Prenom_Agent, '''') as Nom_Agent, c.Annee, c.Droit_Conge, c.Conge_Pris, c.Solde_Conge from RH_Conge c left join RH_Agent a on a.id_Societe = c.id_Societe and a.Matricule = c.Matricule where c.id_Societe = @idSoc and (@Annee is null or c.Annee = @Annee) and (@Mat is null or c.Matricule like ''%'' + @Mat + ''%'') order by c.Annee desc, c.Matricule',
            1, 0, 1, 'U', 'QRY', 0, 0, 0, '', 'SP', ';', '', GETDATE(), 'SCRIPT');

IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Soldes_Conges' AND Critere = '@idSoc')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Soldes_Conges', '@idSoc', N'Société', 'int', '', '0', 'SCRIPT', GETDATE());

IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Soldes_Conges' AND Critere = '@Annee')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Soldes_Conges', '@Annee', N'Année', 'int', '', '1', 'SCRIPT', GETDATE());

IF NOT EXISTS (SELECT 1 FROM Param_Query_Criteres WHERE Cod_Query = 'R_Soldes_Conges' AND Critere = '@Mat')
    INSERT INTO Param_Query_Criteres (Cod_Query, Critere, Lib_Critere, Typ_Critere, Default_Value, Rang, Created_By, Dat_Crea)
    VALUES ('R_Soldes_Conges', '@Mat', N'Matricule (ou fragment)', 'nvarchar(40)', '', '2', 'SCRIPT', GETDATE());

IF NOT EXISTS (SELECT 1 FROM Param_Query_Widget WHERE Cod_Query = 'R_Soldes_Conges')
    INSERT INTO Param_Query_Widget (Cod_Query, estWidget, Widget_Type, Widget_ChartType, Icone, Couleur,
                                    DefaultSpan, Description, estPortail, Menu_Parent, Rang, Created_By, Dat_Crea)
    VALUES ('R_Soldes_Conges', 0, 'table', 'pie', 'TableChart', '#1976d2',
            6, N'Soldes de congés par agent et année', 1, 'mesConsultations', 10, 'SCRIPT', GETDATE());
ELSE
    UPDATE Param_Query_Widget
    SET estPortail = 1, Menu_Parent = 'mesConsultations', Rang = 10,
        Modified_By = 'SCRIPT', Dat_Modif = GETDATE()
    WHERE Cod_Query = 'R_Soldes_Conges';

COMMIT TRANSACTION;
GO

SELECT q.Cod_Query, q.Nom_Query, w.estPortail, w.Menu_Parent, w.Rang,
       (SELECT count(*) FROM Param_Query_Criteres c WHERE c.Cod_Query = q.Cod_Query) AS Nb_Criteres
FROM Param_Query q
JOIN Param_Query_Widget w ON w.Cod_Query = q.Cod_Query
WHERE q.Cod_Query = 'R_Soldes_Conges';
GO
