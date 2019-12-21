
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2019 18:35:35
-- Generated from EDMX file: C:\Git\ASP.NET\MoroskoWebsite\Models\Default.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-MoroskoWebsite-20191210062258];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Courses_dbo_Finals_finalId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_dbo_Courses_dbo_Finals_finalId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UserCourses_dbo_Courses_courseId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCourses] DROP CONSTRAINT [FK_dbo_UserCourses_dbo_Courses_courseId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AdvCPPs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvCPPs];
GO
IF OBJECT_ID(N'[dbo].[AdvVBs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvVBs];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoleAspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoleAspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Finals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Finals];
GO
IF OBJECT_ID(N'[dbo].[UserCourses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserCourses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AdvVBs'
CREATE TABLE [dbo].[AdvVBs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [projectname] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [studentname] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [coursename] varchar(100)  NULL,
    [coursegrade] varchar(10)  NULL,
    [finalId] int  NOT NULL
);
GO

-- Creating table 'Finals'
CREATE TABLE [dbo].[Finals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [finalname] varchar(100)  NULL,
    [finalgrade] varchar(10)  NULL
);
GO

-- Creating table 'UserCourses'
CREATE TABLE [dbo].[UserCourses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [aspnetusersId] nvarchar(128)  NOT NULL,
    [courseId] int  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AspNetRoleAspNetUsers'
CREATE TABLE [dbo].[AspNetRoleAspNetUsers] (
    [AspNetRole_Id] nvarchar(128)  NOT NULL,
    [AspNetUser_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Courses1'
CREATE TABLE [dbo].[Courses1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [coursename] nvarchar(max)  NULL,
    [coursegrade] nvarchar(max)  NULL,
    [finalId] int  NOT NULL
);
GO

-- Creating table 'Final1'
CREATE TABLE [dbo].[Final1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [finalname] nvarchar(max)  NULL,
    [finalgrade] nvarchar(max)  NULL
);
GO

-- Creating table 'UserCourses1'
CREATE TABLE [dbo].[UserCourses1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [aspnetusersId] nvarchar(max)  NULL,
    [courseId] int  NOT NULL,
    [AspNetUser_Id] nvarchar(128)  NULL
);
GO

-- Creating table 'AdvCPPs'
CREATE TABLE [dbo].[AdvCPPs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [projectname] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [studentname] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AdvVBs'
ALTER TABLE [dbo].[AdvVBs]
ADD CONSTRAINT [PK_AdvVBs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Finals'
ALTER TABLE [dbo].[Finals]
ADD CONSTRAINT [PK_Finals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [aspnetusersId], [courseId] in table 'UserCourses'
ALTER TABLE [dbo].[UserCourses]
ADD CONSTRAINT [PK_UserCourses]
    PRIMARY KEY CLUSTERED ([aspnetusersId], [courseId] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [AspNetRole_Id], [AspNetUser_Id] in table 'AspNetRoleAspNetUsers'
ALTER TABLE [dbo].[AspNetRoleAspNetUsers]
ADD CONSTRAINT [PK_AspNetRoleAspNetUsers]
    PRIMARY KEY CLUSTERED ([AspNetRole_Id], [AspNetUser_Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses1'
ALTER TABLE [dbo].[Courses1]
ADD CONSTRAINT [PK_Courses1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Final1'
ALTER TABLE [dbo].[Final1]
ADD CONSTRAINT [PK_Final1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserCourses1'
ALTER TABLE [dbo].[UserCourses1]
ADD CONSTRAINT [PK_UserCourses1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdvCPPs'
ALTER TABLE [dbo].[AdvCPPs]
ADD CONSTRAINT [PK_AdvCPPs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [finalId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_finalId]
    FOREIGN KEY ([finalId])
    REFERENCES [dbo].[Finals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_finalId'
CREATE INDEX [IX_FK_finalId]
ON [dbo].[Courses]
    ([finalId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [aspnetusersId] in table 'UserCourses'
ALTER TABLE [dbo].[UserCourses]
ADD CONSTRAINT [FK_aspnetusersId]
    FOREIGN KEY ([aspnetusersId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [courseId] in table 'UserCourses'
ALTER TABLE [dbo].[UserCourses]
ADD CONSTRAINT [FK_courseId]
    FOREIGN KEY ([courseId])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_courseId'
CREATE INDEX [IX_FK_courseId]
ON [dbo].[UserCourses]
    ([courseId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [finalId] in table 'Courses1'
ALTER TABLE [dbo].[Courses1]
ADD CONSTRAINT [FK_dbo_Courses_dbo_Finals_finalId]
    FOREIGN KEY ([finalId])
    REFERENCES [dbo].[Final1]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Courses_dbo_Finals_finalId'
CREATE INDEX [IX_FK_dbo_Courses_dbo_Finals_finalId]
ON [dbo].[Courses1]
    ([finalId]);
GO

-- Creating foreign key on [courseId] in table 'UserCourses1'
ALTER TABLE [dbo].[UserCourses1]
ADD CONSTRAINT [FK_dbo_UserCourses_dbo_Courses_courseId]
    FOREIGN KEY ([courseId])
    REFERENCES [dbo].[Courses1]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_UserCourses_dbo_Courses_courseId'
CREATE INDEX [IX_FK_dbo_UserCourses_dbo_Courses_courseId]
ON [dbo].[UserCourses1]
    ([courseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------