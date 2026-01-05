USE [RHP_DB_Dev]
GO

/****** Object:  Table [dbo].[RH_Demande_Doc_Admin]    Script Date: 27/12/2025 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RH_Demande_Doc_Admin](
	[Num_Demande] [nvarchar](20) NOT NULL,
	[Matricule] [nvarchar](20) NULL,
	[Dat_Demande] [date] NULL,
	[Commentaire] [nvarchar](max) NULL,
	[Statut] [nvarchar](5) NULL,
	[Etat_Traitement] [nvarchar](20) NULL,
	[id_Societe] [int] NOT NULL,
 CONSTRAINT [PK_RH_Demande_Doc_Admin] PRIMARY KEY CLUSTERED 
(
	[Num_Demande] ASC,
	[id_Societe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RH_Demande_Doc_Admin_Detail]    Script Date: 27/12/2025 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RH_Demande_Doc_Admin_Detail](
	[Num_Demande] [nvarchar](20) NOT NULL,
	[RowId] [int] IDENTITY(1,1) NOT NULL,
	[Typ_Doc] [nvarchar](20) NULL,
	[Nbr_Exemplaire] [int] NULL,
	[Dat_Du] [date] NULL,
	[Dat_Au] [date] NULL,
	[Commentaire] [nvarchar](max) NULL,
	[id_Societe] [int] NOT NULL,
	[Flag_Maj] [int] NULL,
 CONSTRAINT [PK_RH_Demande_Doc_Admin_Detail] PRIMARY KEY CLUSTERED 
(
	[Num_Demande] ASC,
	[RowId] ASC,
	[id_Societe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
