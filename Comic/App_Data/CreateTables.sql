USE [ComicsDatabase]
GO

/****** Object:  Table [dbo].[Comics]    Script Date: 5/7/2020 2:42:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comics](
	[ID] [int] IDENTITY NULL,
	[Key] [varchar](50) NULL,
	[Title] [varchar](8000) NULL
) ON [PRIMARY]
GO


