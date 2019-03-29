use DVDLibrary
go

if exists(select * from sys.tables where name = 'Borrower')
drop table Borrower
go

if exists(select * from sys.tables where name = 'DVD')
drop table DVD
go

if exists(select * from sys.tables where name = 'MPAARating')
drop table MPAARating
go

create table MPAARating 
(
MPAARatingId int identity(1,1) primary key not null,
MPAARatingDescription nvarchar(100) not null
)
go

create table DVD 
(
Id int identity(1,1) primary key not null,
Title nvarchar(128) not null,
ReleaseDate datetime not null,
MPAARating int foreign key references MPAARating(MPAARatingId) not null,
DirectorName nvarchar(128) not null,
Studio nvarchar(50) not null,
UserRating decimal (5,2) not null,
UserNotes nvarchar(2000) not null,
ActorsInMovie nvarchar(2000),
IsBorrowed bit not null
)
go

create table Borrower 
(
BorrowerId int identity(1,1) primary key not null,
BorrowerName nvarchar(100) not null,
DVDBorrowedId int foreign key references DVD(Id) not null,
DateBorrowed datetime,
DateReturned datetime
)
go

insert into MPAARating Values ('G'),
('PG'),
('PG-13'),
('R'),
('NC_17')
go

insert into DVD values
('Tesla', '2016-06-01', 4, 'Goat', 'MGM', 10.0, 'Not as Good as PlanetGoat', 'Andy Kaufmann', 0),
('PlanetGoat', '2016-06-01', 4, 'Goat', 'Fox', 10.0, 'Not as Good as PlanetGoat', 'Andy Kaufmann', 0),
('PlanetEarth', '2016-06-01', 4, 'Goat', 'MGM', 10.0, 'Not as Good as PlanetGoat', 'Andy Kaufmann', 0),
('RoadWarrior', '2016-06-01', 4, 'Goat', 'MGM', 10.0, 'Not as Good as PlanetGoat', 'Andy Kaufmann', 0)
go

insert into Borrower values 
('Beavis',1 ,'2016-07-03','2016-07-05' ),
('Beavis',4 ,'2016-07-03','2016-07-05' ),
('Beavis',4 ,'2016-07-03','2016-07-05' ),
('Beavis',2 ,'2016-07-03', '2016-07-05' ),
('Beavis',1 ,'2016-07-03','2016-07-05' ),
('Beavis',2 ,'2016-07-03','2016-07-05' ),
('Beavis',3 ,'2016-07-03','2016-07-05' )
go