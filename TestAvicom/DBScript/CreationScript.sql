USE [master]
GO

CREATE DATABASE [TestAvicom] ON PRIMARY 
(NAME = N'TestAvicom', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TestAvicom.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB)
LOG ON 
(NAME = N'TestAvicom_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TestAvicom.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [TestAvicom]
GO

CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY NOT NULL,
	[Name] [nchar](70) NOT NULL,
	[ContractStatus] [nchar](15) NOT NULL,
CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([ID]),
CONSTRAINT [UK_Company] UNIQUE ([Name]),
CONSTRAINT [CK_Company] CHECK (([ContractStatus] = N'Еще не заключен' OR [ContractStatus] = N'Заключен' OR [ContractStatus] = N'Расторгнут')))
GO

CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Login] [nchar](25) NOT NULL,
	[Password] [nchar](25) NOT NULL,
	[Company_ID] [int] NOT NULL,
CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID]),
CONSTRAINT [UK_User] UNIQUE ([Name]), 
CONSTRAINT [FK_User_Company] FOREIGN KEY([Company_ID]) REFERENCES [dbo].[Company] ([ID]))
GO


