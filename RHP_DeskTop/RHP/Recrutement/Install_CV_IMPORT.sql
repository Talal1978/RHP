-- =============================================================================
-- IMPORT DE CV DANS LA CVTHEQUE (analyse IA)
-- Enregistre le bouton « Importer un CV » dans la barre d'outils de l'écran
-- CVTheque (barre latérale) : déclenche la méthode Importer_CV de l'écran
-- (CallByName via ud_btn) qui analyse un fichier CV (PDF, Word, image) avec le
-- modèle IA par défaut (AI_Modeles), remplit la fiche candidat et rapproche
-- les compétences du référentiel GPEC.
-- A exécuter UNE SEULE FOIS sur CHAQUE base client concernée (ex. RHP,
-- RHP_METAFY... — le bouton est enregistré par base), puis recharger
-- l'application (Tbl_Controle_Def_Ecran_Button est chargée au login).
-- =============================================================================
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button
               WHERE Name_Ecran = 'CVTheque' AND Cod_Button = 'ImportCV_D')
BEGIN
    INSERT INTO Controle_Def_Ecran_Button
        (Name_Ecran, Cod_Button, ProcName, Lib_Button, Typ_Button, Img, Rang, Width, Height)
    VALUES
        ('CVTheque', 'ImportCV_D', 'Importer_CV', 'Importer un CV (analyse IA)', 'STD', 'btn_import', 7, 25, 25);
END
GO
