
-- Table Entête Déclaration Accident de Travail
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='RH_Declaration_AT' AND xtype='U')
BEGIN
    CREATE TABLE RH_Declaration_AT (
        Num_Declaration VARCHAR(20) NOT NULL,
        id_Societe INT NOT NULL,
        Matricule VARCHAR(20) NOT NULL,
        Dat_Accident DATETIME NULL,
        Heure_Accident VARCHAR(5) NULL,
        Lieu_Accident VARCHAR(200) NULL,
        Circonstances TEXT NULL,
        Nature_Lesion VARCHAR(50) NULL, -- Code Rubrique
        Siege_Lesion VARCHAR(50) NULL, -- Code Rubrique
        Temoins VARCHAR(200) NULL,
        Tiers_Responsable VARCHAR(200) NULL,
        Num_Assurance VARCHAR(50) NULL,
        Salaire_Reference DECIMAL(18, 2) DEFAULT 0,
        Statut VARCHAR(5) DEFAULT 'CR', -- CR: Créé, VA: Validé, CL: Clôturé
        Commentaire TEXT NULL,
        
        Dat_Crea DATETIME DEFAULT GETDATE(),
        Created_By VARCHAR(50) NULL,
        Dat_Modif DATETIME NULL,
        Modified_By VARCHAR(50) NULL,
        
        CONSTRAINT PK_RH_Declaration_AT PRIMARY KEY (Num_Declaration, id_Societe)
    )
END
GO

-- Table Détail Certificats Médicaux
IF NOT EXISTS (SELECT * FROM syso/****** Object:  Table [dbo].[RH_Declaration_AT_Detail]    Script Date: 01/01/2026 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RH_Declaration_AT_Detail](
    [RowId] [int] IDENTITY(1,1) NOT NULL,
    [Num_Declaration] [varchar](20) NOT NULL,
    [id_Societe] [int] NOT NULL,
    [Typ_Certificat] [varchar](50) NULL,
    [Dat_Certificat] [datetime] NULL,
    [Dat_Debut_Arret] [datetime] NULL,
    [Dat_Fin_Arret] [datetime] NULL,
    [Nbr_Jours] [int] DEFAULT 0,
    [Valide] [bit] NULL DEFAULT 0,
    [Commentaire] [varchar](max) NULL,
    
    CONSTRAINT [PK_RH_Declaration_AT_Detail] PRIMARY KEY CLUSTERED 
    (
        [RowId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RH_Declaration_AT_Detail]  WITH CHECK ADD  CONSTRAINT [FK_RH_Declaration_AT_Detail] FOREIGN KEY([Num_Declaration], [id_Societe])
REFERENCES [dbo].[RH_Declaration_AT] ([Num_Declaration], [id_Societe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RH_Declaration_AT_Detail] CHECK CONSTRAINT [FK_RH_Declaration_AT_Detail]
GO-- INSERT INTO Params_Rubriques ...
