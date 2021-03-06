USE [BlogEngine]
GO
/****** Object:  StoredProcedure [dbo].[PostInsert]    Script Date: 8/16/2016 10:19:33 AM ******/
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

Select CONVERT(int, SCOPE_IDENTITY()) AS PostID

GO
/****** Object:  StoredProcedure [dbo].[HashtagInsert]    Script Date: 8/16/2016 10:23:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[HashtagInsert]
(
	@HashtagName varchar(50)
) AS

INSERT INTO Hashtag
           ([HashtagName])
     VALUES
           (@HashtagName)

Select CONVERT(int, SCOPE_IDENTITY()) AS HashtagID

GO
