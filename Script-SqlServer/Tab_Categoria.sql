USE [BD_P3IMAGE]
GO

/****** Object:  Table [dbo].[Tab_Categoria]    Script Date: 10/06/2014 13:45:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tab_Categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](100) NOT NULL,
	[slug] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


