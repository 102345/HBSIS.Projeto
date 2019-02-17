USE [Livraria]
GO

/****** Object:  Table [dbo].[Livro]    Script Date: 17/02/2019 11:55:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Livro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [varchar](50) NULL,
	[titulo] [varchar](50) NULL,
	[descricao] [varchar](50) NULL,
	[autor] [varchar](50) NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


