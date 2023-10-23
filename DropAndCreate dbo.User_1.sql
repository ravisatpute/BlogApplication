USE [BlogApp]
GO

/****** Object: Table [dbo].[User] Script Date: 10/23/2023 7:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[User];


GO
CREATE TABLE [dbo].[User] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (MAX) NULL,
    [Email]    VARCHAR (MAX) NULL,
    [Password] VARCHAR (MAX) NULL,
    [Address]  VARCHAR (MAX) NULL,
    [DateTime] DATETIME      NULL
);


