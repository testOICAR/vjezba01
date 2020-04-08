CREATE DATABASE DapperDemoCRUD
GO

USE DapperDemoCRUD
GO

CREATE TABLE Menu
(
	IDMenu int primary key identity(1,1),
	Place nvarchar(50),
	Type nvarchar(50)
)
GO

select * from menu