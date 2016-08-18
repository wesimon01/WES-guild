
--Author
create procedure AuthorGetAll
AS
SELECT *
  FROM [dbo].[Author]

GO

create procedure AuthorGetByID
(
	@AuthorID int
) AS

SELECT *
  FROM [dbo].[Author]
  Where AuthorID = @AuthorID
GO

create procedure AuthorInsert
(
	@AuthorName varchar(50)
) AS

INSERT INTO [dbo].[Author]
           ([AuthorName])
     VALUES
           (@AuthorName)
GO

create procedure AuthorUpdate
(
	@AuthorID int,
	@AuthorName varchar(50)
) AS

UPDATE [dbo].[Author]
   SET [AuthorName] = @AuthorName
 WHERE AuthorID = @AuthorID
GO

create procedure AuthorDelete
(
	@AuthorID int
) AS

DELETE FROM [dbo].[Author]
      WHERE AuthorID = @AuthorID
GO

--Hashtag
create procedure HashtagGetAll
AS
SELECT *
  FROM Hashtag

GO

create procedure HashtagGetByID
(
	@HashtagID int
) AS

SELECT *
  FROM Hashtag
  Where HashtagID = @HashtagID
GO

create procedure HashtagInsert
(
	@HashtagName varchar(50)
) AS

INSERT INTO Hashtag
           ([HashtagName])
     VALUES
           (@HashtagName)
GO

create procedure HashtagUpdate
(
	@HashtagID int,
	@HashtagName varchar(50)
) AS

UPDATE Hashtag
   SET [HashtagName] = @HashtagName
 WHERE HashtagID = @HashtagID
GO

create procedure HashtagDelete
(
	@HashtagID int
) AS

DELETE FROM Hashtag
      WHERE HashtagID = @HashtagID
GO

--Page
create procedure PageGetAll
AS
SELECT *
  FROM [Page]

GO

create procedure PageGetByID
(
	@PageID int
) AS

SELECT *
  FROM [Page]
  Where PageID = @PageID
GO

create procedure PageInsert
(
	@Title varchar(50),
	@PageContent varchar(max)
) AS

INSERT INTO [dbo].[Page]
           ([Title]
           ,[PageContent])
     VALUES
           (@Title,@PageContent)
GO

create procedure PageUpdate
(
	@PageID int,
	@Title varchar(50),
	@PageContent varchar(max)
) AS

UPDATE [dbo].[Page]
   SET [Title] = @Title,
		[PageContent] = @PageContent
 WHERE PageID = @PageID
GO

create procedure PageDelete
(
	@PageID int
) AS

DELETE FROM [dbo].[Page]
      WHERE PageID = @PageID
GO

--Post
create procedure PostGetAll
as

select *
from Post
 go
  
create procedure PostGetByID
(
	@PostID int
) AS

SELECT *
  FROM Post
  Where PostID = @PostID
GO

create procedure PostInsert
(
	@Title varchar(50),
	@AuthorID int,
	@PublishDate date,
	@ExpireDate date,
	@IsApproved bit,
	@PostContent varchar(max)
) AS

INSERT INTO [dbo].[Post]
           ([Title]
           ,[AuthorID]
           ,[PublishDate]
           ,[ExpireDate]
           ,[IsApproved]
           ,[PostContent])
     VALUES
           (@Title,@AuthorID,@PublishDate,@ExpireDate,@IsApproved,@PostContent)
GO

create procedure PostUpdate
(
	@PostID int,
	@Title varchar(50),
	@AuthorID int,
	@PublishDate date,
	@ExpireDate date,
	@IsApproved bit,
	@PostContent varchar(max)
) AS
UPDATE [dbo].[Post]
   SET [Title] = @Title
      ,[AuthorID] = @AuthorID
      ,[PublishDate] = @PublishDate
      ,[ExpireDate] = @ExpireDate
      ,[IsApproved] = @IsApproved
      ,[PostContent] = @PostContent
 WHERE PostID = @PostID
GO

create procedure PostDelete
(
	@PostID int
) AS

DELETE FROM [dbo].[Post]
       WHERE PostID = @PostID
GO

create procedure PostGetByHashtagID
(
	@HashtagID int
)AS

select p.*
from Post p
join PostHash ph on ph.PostID = p.PostID
join Hashtag h on h.HashtagID = ph.HashtagID
where h.HashtagID = @HashtagID
go

--PostHash
create procedure PostHashInsert
(
	@PostID int,
	@HashtagID int	
) AS

INSERT INTO [dbo].[PostHash]
           ([PostID]
           ,[HashtagID])
     VALUES
           (@PostID
           ,@HashtagID)
GO