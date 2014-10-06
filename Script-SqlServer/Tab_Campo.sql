USE [BD_P3IMAGE]
GO

/****** Object:  Table [dbo].[Tab_Campo]    Script Date: 10/06/2014 13:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tab_Campo](
	[idcampo] [int] IDENTITY(1,1) NOT NULL,
	[idsubcategoria] [int] NOT NULL,
	[ordem] [int] NOT NULL,
	[descricao] [varchar](100) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[lista] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcampo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Tab_Campo]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Tab_Campo_1] FOREIGN KEY([idsubcategoria])
REFERENCES [dbo].[Tab_Subcategoria] ([idsubcategoria])
GO

ALTER TABLE [dbo].[Tab_Campo] CHECK CONSTRAINT [FK_dbo_Tab_Campo_1]
GO


