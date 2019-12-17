CREATE TABLE [dbo].[Final] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [finalname]  VARCHAR (100) NULL,
    [finalgrade] VARCHAR (10)  NULL,
    CONSTRAINT [PK_Final] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Course] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [coursename]  VARCHAR (100) NULL,
    [coursegrade] VARCHAR (10)  NULL,
    [finalId]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_finalId] FOREIGN KEY ([finalId]) REFERENCES [dbo].[Final] ([Id])
);

CREATE TABLE [dbo].[AdvCPP] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [projectname] VARCHAR (100) NULL,
    [description] VARCHAR (MAX) NULL,
    [studentname] VARCHAR (100) NULL,
    CONSTRAINT [PK_AdvCPP] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AdvVBs] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [projectname] VARCHAR (100) NULL,
    [description] VARCHAR (MAX) NULL,
    [studentname] VARCHAR (100) NULL,
    CONSTRAINT [PK_AdvVBs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

