USE [BlogEngine]
GO
/****** Object:  StoredProcedure [dbo].[AuthorDelete]    Script Date: 8/12/2016 12:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[AuthorDelete]
(
	@AuthorID int
) AS

Delete from Post
	Where AuthorID = @AuthorID

DELETE FROM [dbo].[Author]
    WHERE AuthorID = @AuthorID
