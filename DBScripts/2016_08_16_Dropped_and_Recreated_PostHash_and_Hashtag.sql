USE [BlogEngine]
GO

/****** Object:  Table [dbo].[PostHash]    Script Date: 8/16/2016 9:28:27 AM ******/
DROP TABLE [dbo].[PostHash]
GO

/****** Object:  Table [dbo].[PostHash]    Script Date: 8/16/2016 9:28:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PostHash](
	[PostID] [int] NOT NULL,
	[HashtagID] [int] NOT NULL
) ON [PRIMARY]

GO


USE [BlogEngine]
GO

/****** Object:  Table [dbo].[Hashtag]    Script Date: 8/16/2016 9:28:37 AM ******/
DROP TABLE [dbo].[Hashtag]
GO

/****** Object:  Table [dbo].[Hashtag]    Script Date: 8/16/2016 9:28:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Hashtag](
	[HashtagID] [int] IDENTITY(1,1) NOT NULL,
	[HashtagName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Hashtag] PRIMARY KEY CLUSTERED 
(
	[HashtagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

