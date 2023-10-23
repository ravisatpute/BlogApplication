USE [BlogApp]
GO

/****** Object: Table [dbo].[Comment] Script Date: 10/23/2023 7:10:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Comment];


GO
CREATE TABLE [dbo].[Comment] (
    [CommentId]   INT           IDENTITY (1, 1) NOT NULL,
    [BlogId]      INT           NULL,
    [UserId]      INT           NULL,
    [Description] VARCHAR (MAX) NULL,
    [DateTime]    DATETIME      NULL
);


