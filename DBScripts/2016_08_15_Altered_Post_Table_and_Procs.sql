USE [BlogEngine]
GO

/****** Object:  Table [dbo].[Post]    Script Date: 8/15/2016 2:27:33 PM ******/
DROP TABLE [dbo].[Post]
GO

/****** Object:  Table [dbo].[Post]    Script Date: 8/15/2016 2:27:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Post](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[AuthorName] [varchar](50) NOT NULL,
	[PublishDate] [date] NOT NULL,
	[ExpireDate] [date] NULL,
	[IsApproved] [bit] NOT NULL,
	[PostContent] [varchar](max) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [BlogEngine]
GO
/****** Object:  StoredProcedure [dbo].[PostInsert]    Script Date: 8/15/2016 2:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[PostInsert]
(
	@Title varchar(50),
	@AuthorName varchar(50),
	@PublishDate date,
	@ExpireDate date,
	@IsApproved bit,
	@PostContent varchar(max)
) AS

INSERT INTO [dbo].[Post]
           ([Title]
           ,[AuthorName]
           ,[PublishDate]
           ,[ExpireDate]
           ,[IsApproved]
           ,[PostContent])
     VALUES
           (@Title,@AuthorName,@PublishDate,@ExpireDate,@IsApproved,@PostContent)

GO

USE [BlogEngine]
GO

/****** Object:  StoredProcedure [dbo].[PostUpdate]    Script Date: 8/15/2016 2:30:12 PM ******/
DROP PROCEDURE [dbo].[PostUpdate]
GO

/****** Object:  StoredProcedure [dbo].[PostUpdate]    Script Date: 8/15/2016 2:30:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[PostUpdate]
(
	@PostID int,
	@Title varchar(50),
	@AuthorName varchar(50),
	@PublishDate date,
	@ExpireDate date,
	@IsApproved bit,
	@PostContent varchar(max)
) AS
UPDATE [dbo].[Post]
   SET [Title] = @Title
      ,[AuthorName] = @AuthorName
      ,[PublishDate] = @PublishDate
      ,[ExpireDate] = @ExpireDate
      ,[IsApproved] = @IsApproved
      ,[PostContent] = @PostContent
 WHERE PostID = @PostID

GO

USE [BlogEngine]
GO
/****** Object:  StoredProcedure [dbo].[PostGetAll]    Script Date: 8/15/2016 2:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[PostGetAll]
as

select *
from Post

