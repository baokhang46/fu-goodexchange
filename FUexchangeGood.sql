USE [master]
GO

-- Create the FUgoodexchange database if it does not exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FUgoodexchange')
BEGIN
    CREATE DATABASE [FUgoodexchange];
END
GO

USE [FUgoodexchange]
GO


-- Create Account Table
CREATE TABLE [dbo].[Account] (
    [AccountId] INT IDENTITY(1,1) NOT NULL,
    [Username] NVARCHAR(255) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    [Role] NVARCHAR(50) NOT NULL,  -- Add the Role column
    PRIMARY KEY CLUSTERED ([AccountId] ASC)
);
GO

-- Create User Table
CREATE TABLE [dbo].[User] (
    [UserId] INT IDENTITY(1,1) NOT NULL,
    [AccountId] INT NOT NULL,
    [FirstName] NVARCHAR(255) NULL,
    [LastName] NVARCHAR(255) NULL,
    [Address] NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Account] FOREIGN KEY ([AccountId])
        REFERENCES [dbo].[Account] ([AccountId])
);
GO

-- Create Buyer Table
CREATE TABLE [dbo].[Buyer] (
    [BuyerID] INT IDENTITY(1,1) NOT NULL,
    [UserID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([BuyerID] ASC),
    CONSTRAINT [FK_Buyer_User] FOREIGN KEY ([UserID])
        REFERENCES [dbo].[User] ([UserId])
);
GO

-- Create Seller Table
CREATE TABLE [dbo].[Seller] (
    [SellerID] INT IDENTITY(1,1) NOT NULL,
    [UserID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([SellerID] ASC),
    CONSTRAINT [FK_Seller_User] FOREIGN KEY ([UserID])
        REFERENCES [dbo].[User] ([UserId])
);
GO

-- Create Category Table
CREATE TABLE [dbo].[Category] (
    [CategoryID] INT IDENTITY(1,1) NOT NULL,
    [CategoryName] NVARCHAR(255) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);
GO

-- Create Product Table
CREATE TABLE [dbo].[Product] (
    [ProductID] INT IDENTITY(1,1) NOT NULL,
    [SellerID] INT NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Price] MONEY NULL,
    [Quantity] INT NULL,
    [CategoryID] INT NULL,
    [DatePosted] DATETIME NULL,
    [Status] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Product_Seller] FOREIGN KEY ([SellerID])
        REFERENCES [dbo].[Seller] ([SellerID]),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryID])
        REFERENCES [dbo].[Category] ([CategoryID])
);
GO

-- Create Report Table
CREATE TABLE [dbo].[Report] (
    [ReportID] INT IDENTITY(1,1) NOT NULL,
    [BuyerID] INT NOT NULL,
    [SellerID] INT NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [ReportDate] DATE NULL,
    [Status] BIT NULL,
    PRIMARY KEY CLUSTERED ([ReportID] ASC),
    CONSTRAINT [FK_Report_Buyer] FOREIGN KEY ([BuyerID])
        REFERENCES [dbo].[Buyer] ([BuyerID]),
    CONSTRAINT [FK_Report_Seller] FOREIGN KEY ([SellerID])
        REFERENCES [dbo].[Seller] ([SellerID])
);
GO

-- Create Cart Table
CREATE TABLE [dbo].[Cart] (
    [CartId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CartId] ASC),
    CONSTRAINT [FK_Cart_User] FOREIGN KEY ([UserId])
        REFERENCES [dbo].[User] ([UserId])
);
GO

-- Create CartItem Table with a 1-1 relationship with Product
CREATE TABLE [dbo].[CartItem] (
    [CartItemId] INT IDENTITY(1,1) NOT NULL,
    [CartId] INT NOT NULL,
    [ProductId] INT NOT NULL UNIQUE,  -- Ensure 1-1 relationship
    [Quantity] INT NULL,
    PRIMARY KEY CLUSTERED ([CartItemId] ASC),
    CONSTRAINT [FK_CartItem_Cart] FOREIGN KEY ([CartId])
        REFERENCES [dbo].[Cart] ([CartId]),
    CONSTRAINT [FK_CartItem_Product] FOREIGN KEY ([ProductId])
        REFERENCES [dbo].[Product] ([ProductID])
);
GO

-- Create Order Table with a 1-1 relationship with Product
CREATE TABLE [dbo].[Order] (
    [OrderID] INT IDENTITY(1,1) NOT NULL,
    [ProductID] INT NOT NULL UNIQUE,  -- Ensure 1-1 relationship
    [Quantity] INT NULL,
    [TotalPrice] MONEY NULL,
    [BuyerID] INT NOT NULL,
    [SellerID] INT NOT NULL,
    [TransactionID] NVARCHAR(255) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductID])
        REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_Order_Buyer] FOREIGN KEY ([BuyerID])
        REFERENCES [dbo].[Buyer] ([BuyerID]),
    CONSTRAINT [FK_Order_Seller] FOREIGN KEY ([SellerID])
        REFERENCES [dbo].[Seller] ([SellerID])
);
GO

-- Create Transaction Table
CREATE TABLE [dbo].[Transaction] (
    [TransactionID] NVARCHAR(255) NOT NULL,
    [BuyerID] INT NOT NULL,
    [SellerID] INT NOT NULL,
    [ProductID] INT NOT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    PRIMARY KEY ([TransactionID]),
    CONSTRAINT [FK_Transaction_Buyer] FOREIGN KEY ([BuyerID])
        REFERENCES [dbo].[Buyer] ([BuyerID]),
    CONSTRAINT [FK_Transaction_Seller] FOREIGN KEY ([SellerID])
        REFERENCES [dbo].[Seller] ([SellerID]),
    CONSTRAINT [FK_Transaction_Product] FOREIGN KEY ([ProductID])
        REFERENCES [dbo].[Product] ([ProductID])
);
GO
