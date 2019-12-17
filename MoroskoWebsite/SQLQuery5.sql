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

CREATE TABLE [dbo].[UserCourse] (
    [aspnetusersId] NVARCHAR (128) NOT NULL,
    [courseId]      INT            NOT NULL,
    CONSTRAINT [PK_UserContact] PRIMARY KEY CLUSTERED ([aspnetusersId] ASC, [courseId] ASC),
    CONSTRAINT [FK_aspnetusersId] FOREIGN KEY ([aspnetusersId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_courseId] FOREIGN KEY ([courseId]) REFERENCES [dbo].[Course] ([Id])
);



