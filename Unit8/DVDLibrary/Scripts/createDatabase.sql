use master 
go 

if exists(select * from sys.databases where name = 'DVDLibrary')
drop database DVDLibrary
go

create database DVDLibrary
go

