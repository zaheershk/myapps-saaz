
--drop
DROP TABLE [DBO].[CATALOGITEM];
DROP TABLE [DBO].[CATALOGTYPE];
DROP TABLE [DBO].[CATALOGBRAND];
DROP TABLE [DBO].[CATALOGSUBCATEGORY];
DROP TABLE [DBO].[CATALOGCATEGORY];
GO

--create
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATALOGTYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [DBO].[CATALOGTYPE]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[TYPENAME] VARCHAR(100) NOT NULL,
	[CREATEDATE] DATETIME NOT NULL,
	[CREATEBY] VARCHAR(10) NOT NULL,
	[UPDATEDATE] DATETIME NULL,
	[UPDATEBY] VARCHAR(10) NULL,
	[ISDELETED] BIT DEFAULT 0 NOT NULL 
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATALOGBRAND]') AND type in (N'U'))
BEGIN
CREATE TABLE [DBO].[CATALOGBRAND]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[BRANDNAME] VARCHAR(100) NOT NULL,
	[CREATEDATE] DATETIME NOT NULL,
	[CREATEBY] VARCHAR(10) NOT NULL,
	[UPDATEDATE] DATETIME NULL,
	[UPDATEBY] VARCHAR(10) NULL,
	[ISDELETED] BIT DEFAULT 0 NOT NULL 
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATALOGCATEGORY]') AND type in (N'U'))
BEGIN
CREATE TABLE [DBO].[CATALOGCATEGORY]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[CATEGORYNAME] VARCHAR(100) NOT NULL,
	[CREATEDATE] DATETIME NOT NULL,
	[CREATEBY] VARCHAR(10) NOT NULL,
	[UPDATEDATE] DATETIME NULL,
	[UPDATEBY] VARCHAR(10) NULL,
	[ISDELETED] BIT DEFAULT 0 NOT NULL 
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATALOGSUBCATEGORY]') AND type in (N'U'))
BEGIN
CREATE TABLE [DBO].[CATALOGSUBCATEGORY]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[CATEGORYID] INT NOT NULL CONSTRAINT FK_CSC_CATEGORYID REFERENCES CATALOGCATEGORY(ID),
	[SUBCATEGORYNAME] VARCHAR(100) NOT NULL,
	[CREATEDATE] DATETIME NOT NULL,
	[CREATEBY] VARCHAR(10) NOT NULL,
	[UPDATEDATE] DATETIME NULL,
	[UPDATEBY] VARCHAR(10) NULL,
	[ISDELETED] BIT DEFAULT 0 NOT NULL 
)
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATALOGITEM]') AND type in (N'U'))
BEGIN
CREATE TABLE [DBO].[CATALOGITEM]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[TYPEID] INT NOT NULL CONSTRAINT FK_CI_TYPEID REFERENCES CATALOGTYPE(ID),
	[BRANDID] INT NOT NULL CONSTRAINT FK_CI_BRANDID REFERENCES CATALOGBRAND(ID),
	[CATEGORYID] INT NOT NULL CONSTRAINT FK_CI_CATEGORYID REFERENCES CATALOGCATEGORY(ID),
	[SUBCATEGORYID] INT NULL CONSTRAINT FK_CI_SUBCATEGORYID REFERENCES CATALOGSUBCATEGORY(ID),
	[ITEMNAME] VARCHAR(100) NOT NULL,
	[ITEMDESC] VARCHAR(250) NULL,
	[PRICE] NUMERIC(10,2) NULL,
	[PICTUREFILENAME] VARCHAR(100) NULL,
	[PICTUREURI] VARCHAR(500) NULL,
	[AVAILABLESTOCK] INT NULL,
	[RESTOCKTHRESHOLD] INT NULL,
	[MAXSTOCKTHRESHOLD] INT NULL,	
	[CREATEDATE] DATETIME NOT NULL,
	[CREATEBY] VARCHAR(10) NOT NULL,
	[UPDATEDATE] DATETIME NULL,
	[UPDATEBY] VARCHAR(10) NULL,
	[ISDELETED] BIT DEFAULT 0 NOT NULL 
)
END
GO
