use master 
go

if exists(select * from sys.databases where name='SGCorpHRPortal')
drop database SGCorpHRPortal
go

create database SGCorpHRPortal
go
