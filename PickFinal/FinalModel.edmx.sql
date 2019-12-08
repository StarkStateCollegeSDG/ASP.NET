
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2019 16:03:38
-- Generated from EDMX file: C:\Git\ASP.NET\PickFinal\FinalModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StarkState];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__aspnet_Me__Appli__75A278F5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__Appli__75A278F5];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Me__UserI__76969D2E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__76969D2E];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pr__UserI__160F4887]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__160F4887];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Ro__Appli__1F98B2C1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK__aspnet_Ro__Appli__1F98B2C1];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__Appli__6754599E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK__aspnet_Us__Appli__6754599E];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__RoleI__245D67DE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__245D67DE];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__UserI__236943A5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__236943A5];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdvVB]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvVB];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Applications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Applications];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Membership];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Profile];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Roles];
GO
IF OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_SchemaVersions];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Users];
GO
IF OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_UsersInRoles];
GO
IF OBJECT_ID(N'[dbo].[login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[login];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdvVBs'
CREATE TABLE [dbo].[AdvVBs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [projectname] varchar(100)  NULL,
    [description] varchar(max)  NULL,
    [studentname] varchar(100)  NULL
);
GO

-- Creating table 'aspnet_Applications'
CREATE TABLE [dbo].[aspnet_Applications] (
    [ApplicationName] nvarchar(256)  NOT NULL,
    [LoweredApplicationName] nvarchar(256)  NOT NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'aspnet_Membership'
CREATE TABLE [dbo].[aspnet_Membership] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordFormat] int  NOT NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [MobilePIN] nvarchar(16)  NULL,
    [Email] nvarchar(256)  NULL,
    [LoweredEmail] nvarchar(256)  NULL,
    [PasswordQuestion] nvarchar(256)  NULL,
    [PasswordAnswer] nvarchar(128)  NULL,
    [IsApproved] bit  NOT NULL,
    [IsLockedOut] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [LastPasswordChangedDate] datetime  NOT NULL,
    [LastLockoutDate] datetime  NOT NULL,
    [FailedPasswordAttemptCount] int  NOT NULL,
    [FailedPasswordAttemptWindowStart] datetime  NOT NULL,
    [FailedPasswordAnswerAttemptCount] int  NOT NULL,
    [FailedPasswordAnswerAttemptWindowStart] datetime  NOT NULL,
    [Comment] nvarchar(max)  NULL
);
GO

-- Creating table 'aspnet_Profile'
CREATE TABLE [dbo].[aspnet_Profile] (
    [UserId] uniqueidentifier  NOT NULL,
    [PropertyNames] nvarchar(max)  NOT NULL,
    [PropertyValuesString] nvarchar(max)  NOT NULL,
    [PropertyValuesBinary] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'aspnet_Roles'
CREATE TABLE [dbo].[aspnet_Roles] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL,
    [LoweredRoleName] nvarchar(256)  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'aspnet_SchemaVersions'
CREATE TABLE [dbo].[aspnet_SchemaVersions] (
    [Feature] nvarchar(128)  NOT NULL,
    [CompatibleSchemaVersion] nvarchar(128)  NOT NULL,
    [IsCurrentVersion] bit  NOT NULL
);
GO

-- Creating table 'aspnet_Users'
CREATE TABLE [dbo].[aspnet_Users] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [LoweredUserName] nvarchar(256)  NOT NULL,
    [MobileAlias] nvarchar(16)  NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL
);
GO

-- Creating table 'logins'
CREATE TABLE [dbo].[logins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] varchar(30)  NULL,
    [password] varchar(30)  NULL,
    [email] varchar(256)  NULL
);
GO

-- Creating table 'aspnet_UsersInRoles'
CREATE TABLE [dbo].[aspnet_UsersInRoles] (
    [aspnet_Roles_RoleId] uniqueidentifier  NOT NULL,
    [aspnet_Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AdvVBs'
ALTER TABLE [dbo].[AdvVBs]
ADD CONSTRAINT [PK_AdvVBs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ApplicationId] in table 'aspnet_Applications'
ALTER TABLE [dbo].[aspnet_Applications]
ADD CONSTRAINT [PK_aspnet_Applications]
    PRIMARY KEY CLUSTERED ([ApplicationId] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Membership'
ALTER TABLE [dbo].[aspnet_Membership]
ADD CONSTRAINT [PK_aspnet_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Profile'
ALTER TABLE [dbo].[aspnet_Profile]
ADD CONSTRAINT [PK_aspnet_Profile]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'aspnet_Roles'
ALTER TABLE [dbo].[aspnet_Roles]
ADD CONSTRAINT [PK_aspnet_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Feature], [CompatibleSchemaVersion] in table 'aspnet_SchemaVersions'
ALTER TABLE [dbo].[aspnet_SchemaVersions]
ADD CONSTRAINT [PK_aspnet_SchemaVersions]
    PRIMARY KEY CLUSTERED ([Feature], [CompatibleSchemaVersion] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Users'
ALTER TABLE [dbo].[aspnet_Users]
ADD CONSTRAINT [PK_aspnet_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'logins'
ALTER TABLE [dbo].[logins]
ADD CONSTRAINT [PK_logins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [aspnet_Roles_RoleId], [aspnet_Users_UserId] in table 'aspnet_UsersInRoles'
ALTER TABLE [dbo].[aspnet_UsersInRoles]
ADD CONSTRAINT [PK_aspnet_UsersInRoles]
    PRIMARY KEY CLUSTERED ([aspnet_Roles_RoleId], [aspnet_Users_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApplicationId] in table 'aspnet_Membership'
ALTER TABLE [dbo].[aspnet_Membership]
ADD CONSTRAINT [FK__aspnet_Me__Appli__75A278F5]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Me__Appli__75A278F5'
CREATE INDEX [IX_FK__aspnet_Me__Appli__75A278F5]
ON [dbo].[aspnet_Membership]
    ([ApplicationId]);
GO

-- Creating foreign key on [ApplicationId] in table 'aspnet_Roles'
ALTER TABLE [dbo].[aspnet_Roles]
ADD CONSTRAINT [FK__aspnet_Ro__Appli__1F98B2C1]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Ro__Appli__1F98B2C1'
CREATE INDEX [IX_FK__aspnet_Ro__Appli__1F98B2C1]
ON [dbo].[aspnet_Roles]
    ([ApplicationId]);
GO

-- Creating foreign key on [ApplicationId] in table 'aspnet_Users'
ALTER TABLE [dbo].[aspnet_Users]
ADD CONSTRAINT [FK__aspnet_Us__Appli__6754599E]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Us__Appli__6754599E'
CREATE INDEX [IX_FK__aspnet_Us__Appli__6754599E]
ON [dbo].[aspnet_Users]
    ([ApplicationId]);
GO

-- Creating foreign key on [UserId] in table 'aspnet_Membership'
ALTER TABLE [dbo].[aspnet_Membership]
ADD CONSTRAINT [FK__aspnet_Me__UserI__76969D2E]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'aspnet_Profile'
ALTER TABLE [dbo].[aspnet_Profile]
ADD CONSTRAINT [FK__aspnet_Pr__UserI__160F4887]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [aspnet_Roles_RoleId] in table 'aspnet_UsersInRoles'
ALTER TABLE [dbo].[aspnet_UsersInRoles]
ADD CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles]
    FOREIGN KEY ([aspnet_Roles_RoleId])
    REFERENCES [dbo].[aspnet_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [aspnet_Users_UserId] in table 'aspnet_UsersInRoles'
ALTER TABLE [dbo].[aspnet_UsersInRoles]
ADD CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Users]
    FOREIGN KEY ([aspnet_Users_UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_aspnet_UsersInRoles_aspnet_Users'
CREATE INDEX [IX_FK_aspnet_UsersInRoles_aspnet_Users]
ON [dbo].[aspnet_UsersInRoles]
    ([aspnet_Users_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------