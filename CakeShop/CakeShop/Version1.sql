CREATE TABLE Cake(
	Id INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(255) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	AvailableQuantity INT NOT NULL,
	ImagePath NVARCHAR(MAX) NOT NULL,
	CategoryId INT NOT NULL,
)
GO

ALTER TABLE Cake
	ADD CONSTRAINT PK_Cake PRIMARY KEY CLUSTERED (Id)
GO

CREATE TABLE Category(
    Id   INT IDENTITY (1, 1) NOT NULL,
    Nume NVARCHAR (255) NOT NULL,
    CONSTRAINT PK_Category PRIMARY KEY CLUSTERED (Id ASC)
)
GO

CREATE TABLE Cart (
    RecordId  INT            IDENTITY (1, 1) NOT NULL,
    CartId    NVARCHAR (MAX) NULL,
    CakeId    INT            NOT NULL,
    Cantitate INT            NOT NULL,
    CONSTRAINT PK_Cart PRIMARY KEY CLUSTERED ([RecordId] ASC),
    CONSTRAINT FK_Carts_Cake_CakeId FOREIGN KEY ([CakeId]) REFERENCES Cake ([Id]) ON DELETE CASCADE
)
GO

CREATE NONCLUSTERED INDEX [IX_CakeId]
    ON Cart([CakeId] ASC);
GO

CREATE TABLE [Order](
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Username]   NVARCHAR (MAX)  NULL,
    [FirstName]  NVARCHAR (160)  NOT NULL,
    [LastName]   NVARCHAR (160)  NOT NULL,
    [Address]    NVARCHAR (70)   NOT NULL,
    [PostalCode] NVARCHAR (10)   NOT NULL,
    [Phone]      NVARCHAR (24)   NOT NULL,
    [Email]      NVARCHAR (MAX)  NOT NULL,
    [Total]      DECIMAL (18, 2) NOT NULL,
    [OrderDate]  DATETIME        NOT NULL,
    [City]       NVARCHAR (40)   DEFAULT ('') NOT NULL,
    [County]      NVARCHAR (40)   DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE OrderDetail (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT             NOT NULL,
    [CakeId]    INT             NOT NULL,
    [Quantity]  INT             NOT NULL,
    [UnitPrice] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetail.Cake_CakeId] FOREIGN KEY ([CakeId]) REFERENCES [Cake] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetail_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE
)
GO


CREATE NONCLUSTERED INDEX [IX_OrderId]
    ON [OrderDetail]([OrderId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_CakeId]
    ON [OrderDetail]([CakeId] ASC);


