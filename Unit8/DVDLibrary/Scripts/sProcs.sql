use [DVDLibrary]
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'DVDGetAll')
		  drop procedure DVDGetAll
go

create procedure DVDGetAll as
begin
	SELECT Id, Title, ReleaseDate, MPAARating, DirectorName, Studio, UserRating, UserNotes, ActorsInMovie, IsBorrowed
	FROM DVD
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'DVDGetById')
		  drop procedure DVDGetById
go

create procedure DVDGetById (
@Id int
) as
begin
	SELECT Id, Title, ReleaseDate, MPAARating, DirectorName, Studio, UserRating, UserNotes, ActorsInMovie, IsBorrowed
	FROM  DVD
	where Id = @Id
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'DVDGetByTitle')
		  drop procedure DVDGetByTitle
go

create procedure DVDGetByTitle (
@title nvarchar(128)
) as
begin
	SELECT Id, Title, ReleaseDate, MPAARating, DirectorName, Studio, UserRating, UserNotes, ActorsInMovie, IsBorrowed
	FROM DVD
	where Title = @title
end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'DVDInsert')
		  drop procedure DVDInsert
go

create procedure DVDInsert (
@Id int output, 
@Title nvarchar(128),
@ReleaseDate datetime,
@MPAARating int,
@DirectorName nvarchar(128),
@Studio nvarchar(50),
@UserRating decimal(7,2),
@UserNotes nvarchar(2000),
@ActorsInMovie nvarchar(2000),
@IsBorrowed bit
) as
begin
insert into DVD (Title, ReleaseDate, MPAARating, DirectorName, Studio, UserRating, UserNotes, ActorsInMovie, IsBorrowed)
 values (@Title, @ReleaseDate, @MPAARating, @DirectorName, @Studio, @UserRating, @UserNotes, @ActorsInMovie, @IsBorrowed)
 
 set @Id = SCOPE_IDENTITY()
 end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'DVDUpdate')
		  drop procedure DVDUpdate
go

create procedure DVDUpdate (
@Id int, 
@Title nvarchar(128),
@ReleaseDate datetime,
@MPAARating int,
@DirectorName nvarchar(128),
@Studio nvarchar(50),
@UserRating decimal(7,2),
@UserNotes nvarchar(2000),
@ActorsInMovie nvarchar(2000),
@IsBorrowed bit
) as
begin

Update DVD 
set 
Title = @Title,
ReleaseDate = @ReleaseDate,
MPAARating = @MPAARating,
DirectorName = @DirectorName,
Studio = @Studio,
UserRating = @UserRating,
UserNotes = @UserNotes,
ActorsInMovie = @ActorsInMovie,
IsBorrowed = @IsBorrowed
where Id = @Id

end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'DVDRemove')
		  drop procedure DVDRemove
go

create procedure DVDRemove (
@Id int
) as
begin
	begin transaction
		Delete from Borrower where DVDBorrowedId = @Id
		Delete from DVD where Id = @Id
	commit transaction
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	      where ROUTINE_NAME = 'BorrowerGetAll')
		  drop procedure BorrowerGetAll
go

create procedure BorrowerGetAll as
begin
	SELECT BorrowerId, BorrowerName, DVDBorrowedId, DateBorrowed, DateReturned
	FROM  Borrower
end
go
