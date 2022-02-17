
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2022 23:58:38
-- Generated from EDMX file: C:\Users\murat\Desktop\TV\TVMODELFİRST\TVMODELFİRST\TV.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TV];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'kanal'
CREATE TABLE [dbo].[kanal] (
    [kanalid] int IDENTITY(1,1) NOT NULL,
    [kanaladi] nvarchar(max)  NOT NULL,
    [ciro] decimal(18,0)  NOT NULL,
    [adres] nvarchar(max)  NOT NULL,
    [reyting] float  NOT NULL
);
GO

-- Creating table 'yayin'
CREATE TABLE [dbo].[yayin] (
    [yayinid] int IDENTITY(1,1) NOT NULL,
    [yayinadi] nvarchar(max)  NOT NULL,
    [yayintarihi] nvarchar(max)  NOT NULL,
    [reyting] float  NOT NULL,
    [kanalid] int  NOT NULL
);
GO

-- Creating table 'sorumlu'
CREATE TABLE [dbo].[sorumlu] (
    [sorumluid] int IDENTITY(1,1) NOT NULL,
    [adsoyad] nvarchar(max)  NOT NULL,
    [gorevi] nvarchar(max)  NOT NULL,
    [maas] decimal(18,0)  NOT NULL,
    [gorevsayisi] int  NOT NULL,
    [yayinid] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [kanalid] in table 'kanal'
ALTER TABLE [dbo].[kanal]
ADD CONSTRAINT [PK_kanal]
    PRIMARY KEY CLUSTERED ([kanalid] ASC);
GO

-- Creating primary key on [yayinid] in table 'yayin'
ALTER TABLE [dbo].[yayin]
ADD CONSTRAINT [PK_yayin]
    PRIMARY KEY CLUSTERED ([yayinid] ASC);
GO

-- Creating primary key on [sorumluid] in table 'sorumlu'
ALTER TABLE [dbo].[sorumlu]
ADD CONSTRAINT [PK_sorumlu]
    PRIMARY KEY CLUSTERED ([sorumluid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [kanalid] in table 'yayin'
ALTER TABLE [dbo].[yayin]
ADD CONSTRAINT [FK_kanalyayin]
    FOREIGN KEY ([kanalid])
    REFERENCES [dbo].[kanal]
        ([kanalid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_kanalyayin'
CREATE INDEX [IX_FK_kanalyayin]
ON [dbo].[yayin]
    ([kanalid]);
GO

-- Creating foreign key on [yayinid] in table 'sorumlu'
ALTER TABLE [dbo].[sorumlu]
ADD CONSTRAINT [FK_yayinsorumlu]
    FOREIGN KEY ([yayinid])
    REFERENCES [dbo].[yayin]
        ([yayinid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_yayinsorumlu'
CREATE INDEX [IX_FK_yayinsorumlu]
ON [dbo].[sorumlu]
    ([yayinid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------