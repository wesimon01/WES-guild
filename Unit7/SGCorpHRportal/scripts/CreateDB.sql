use SGCorpHRPortal
go

if exists(select * from sys.tables where name = 'Category')
drop table Category
go

if exists(select * from sys.tables where name = 'Policy')
drop table [Policy]
go

if exists(select * from sys.tables where name = 'Employee')
drop table Employee
go

create table Category
(
CategoryName nvarchar(128),
CategoryId int
primary key(CategoryName, CategoryId)
)
go

create table [Policy] 
(
PolicyId int identity(1,1) primary key,
PolicyName nvarchar(128),
Content nvarchar(500),
)
go

create table Employee
(
EmployeeId int identity(1,1) primary key,
FirstName nvarchar(128),
LastName nvarchar(128),
HireDate datetime
)
go
