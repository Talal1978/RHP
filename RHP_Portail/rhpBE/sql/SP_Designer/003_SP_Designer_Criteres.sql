/* ============================================================================
   RHP - Module SP_ : paramétrage des critères de sélection des pages Liste
   - Migration non destructive : Controle_Designer_Champ.estCritere + Rang_Critere
   - Exemple FRAIS_KM : Matricule et Dat_Demande deviennent critères
   ============================================================================ */

IF COL_LENGTH('dbo.Controle_Designer_Champ', 'estCritere') IS NULL
    ALTER TABLE dbo.Controle_Designer_Champ ADD estCritere nvarchar(5) NOT NULL
        CONSTRAINT DF_SPChamp_Critere DEFAULT ('false');
GO
IF COL_LENGTH('dbo.Controle_Designer_Champ', 'Rang_Critere') IS NULL
    ALTER TABLE dbo.Controle_Designer_Champ ADD Rang_Critere int NULL;
GO

-- Exemple : critères de la liste "Frais kilométriques"
UPDATE Controle_Designer_Champ SET estCritere = 'true', Rang_Critere = 1
WHERE Cod_Page = 'FRAIS_KM' AND Cod_Champ = 'Matricule';
UPDATE Controle_Designer_Champ SET estCritere = 'true', Rang_Critere = 2
WHERE Cod_Page = 'FRAIS_KM' AND Cod_Champ = 'Dat_Demande';
GO
