USE [BlogEngine]
GO
/****** Object:  StoredProcedure [dbo].[PostUpdate]    Script Date: 8/17/2016 9:19:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[PostUpdate]
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

 SELECT CONVERT(int, SCOPE_IDENTITY()) as PostID