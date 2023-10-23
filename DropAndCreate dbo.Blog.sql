USE [BlogApp]
GO

/****** Object: Table [dbo].[Blog] Script Date: 10/23/2023 7:09:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Blog];


GO
CREATE TABLE [dbo].[Blog] (
    [BlogId]      INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NULL,
    [Title]       VARCHAR (MAX) NULL,
    [Description] VARCHAR (MAX) NULL,
    [Content]     VARCHAR (MAX) NULL,
    [DateTime]    DATETIME      NULL,
    [isActive]    BIT           NULL
);


