--drop database StudentDB
create database StudentDB
use StudentDB
create table Student(
StudentId int not null primary key,
name varchar(50),
roll varchar(50),
); 
CREATE PROCEDURE dbo.SP_Student
AS
