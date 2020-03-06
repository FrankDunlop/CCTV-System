
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/03/2020 18:05:46
-- Generated from EDMX file: C:\Dev\Digital Video Recorder HR\DAL\EF\DVRModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DVR];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CamSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CamSettings];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CamSettings'
CREATE TABLE [dbo].[CamSettings] (
    [CamNum] int IDENTITY(1,1) NOT NULL,
    [CamName] nvarchar(10)  NULL,
    [BlackTest] bit  NOT NULL,
    [TextBottom] bit  NOT NULL,
    [LowRes] bit  NULL,
    [MotionDetectEnabled] bit  NOT NULL,
    [RecOnMotion] bit  NOT NULL,
    [RecSeconds] int  NOT NULL,
    [Sensitivity] int  NOT NULL,
    [PrivacyEnabled] bit  NOT NULL,
    [PrivacySelected] bit  NOT NULL,
    [ShowTimeDate] bit  NOT NULL,
    [FPS] int  NOT NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Message] nchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CamNum] in table 'CamSettings'
ALTER TABLE [dbo].[CamSettings]
ADD CONSTRAINT [PK_CamSettings]
    PRIMARY KEY CLUSTERED ([CamNum] ASC);
GO

-- Creating primary key on [ID] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------