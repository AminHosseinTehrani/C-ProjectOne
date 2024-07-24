
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/25/2023 11:23:10
-- Generated from EDMX file: F:\Comp212_Programming\assignment4\301225212HosseinTehrani_Ass4\Assignment4DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyAssignmentFourDatabase];
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

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [NameStyle] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [SalesPerson] nvarchar(max)  NOT NULL,
    [EmailAddress] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerAddresses'
CREATE TABLE [dbo].[CustomerAddresses] (
    [AddressType] nvarchar(max)  NOT NULL,
    [ModifedDate] nvarchar(max)  NOT NULL,
    [CustomerID] int  NOT NULL,
    [AddressID] int  NOT NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Department] nvarchar(max)  NOT NULL,
    [PhoneNr] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressID] int IDENTITY(1,1) NOT NULL,
    [AddressLine1] nvarchar(max)  NOT NULL,
    [AddressLine2] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [StateProvince] nvarchar(max)  NOT NULL,
    [CountryRegion] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [CustomerID], [AddressID] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [PK_CustomerAddresses]
    PRIMARY KEY CLUSTERED ([CustomerID], [AddressID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [AddressID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [FK_CustomerCustomerAddress]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AddressID] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [FK_AddressCustomerAddress]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Addresses]
        ([AddressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressCustomerAddress'
CREATE INDEX [IX_FK_AddressCustomerAddress]
ON [dbo].[CustomerAddresses]
    ([AddressID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------