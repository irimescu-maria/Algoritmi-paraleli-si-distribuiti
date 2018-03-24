CREATE TABLE Cakes(
	Id INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(255) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	AvailableQuantity INT NOT NULL,
	ImagePath NVARCHAR(MAX) NOT NULL,
	CategoryId INT NOT NULL
)  
GO
drop table Cakes
drop table Categories
drop table Carts
drop table Orders
drop table OrderDetails

ALTER TABLE Cakes
			ADD CONSTRAINT [Cakes_Categories_CategoryId] FOREIGN KEY 
			([CategoryId]) REFERENCES Categories ([Id]) ON DELETE CASCADE

GO

ALTER TABLE Cakes
	ADD CONSTRAINT PK_Cakes PRIMARY KEY CLUSTERED (Id)
GO

CREATE TABLE Categories(
    Id   INT IDENTITY (1, 1) NOT NULL,
    Nume NVARCHAR (255) NOT NULL,
    CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED (Id ASC)
)
GO

CREATE TABLE Carts (
    RecordId  INT            IDENTITY (1, 1) NOT NULL,
    CartId    NVARCHAR (MAX) NULL,
    CakeId    INT            NOT NULL,
    Cantitate INT            NOT NULL,
    CONSTRAINT PK_Carts PRIMARY KEY CLUSTERED ([RecordId] ASC),
    CONSTRAINT FK_Carts_Cakes_CakeId FOREIGN KEY ([CakeId]) REFERENCES Cakes ([Id]) ON DELETE CASCADE
)
GO

CREATE NONCLUSTERED INDEX [IX_CakeId]
    ON Carts([CakeId] ASC);
GO

CREATE TABLE Orders(
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
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE OrderDetails (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT             NOT NULL,
    [CakeId]    INT             NOT NULL,
    [Quantity]  INT             NOT NULL,
    [UnitPrice] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetails.Cakes_CakeId] FOREIGN KEY ([CakeId]) REFERENCES [Cakes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
)
GO


CREATE NONCLUSTERED INDEX [IX_OrderId]
    ON [OrderDetails]([OrderId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_CakeId]
    ON [OrderDetails]([CakeId] ASC);




