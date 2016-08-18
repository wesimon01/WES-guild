USE [BlogEngine]
GO
/****** Object:  StoredProcedure [dbo].[PostGetAll]    Script Date: 8/12/2016 12:27:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[PostGetAll]
as

select post.*, a.AuthorName
from Post
join Author a on a.AuthorID = post.AuthorID

