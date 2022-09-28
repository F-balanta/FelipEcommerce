IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Dni] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [PurshacePrice] decimal(18,2) NOT NULL,
    [SellingPrice] decimal(18,2) NOT NULL,
    [Code] nvarchar(max) NULL,
    [Minimum] int NOT NULL,
    [Maximum] int NOT NULL,
    [Type] nvarchar(max) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NULL,
    [UserName] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Inventory] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [Qty] int NOT NULL,
    [InventoryDate] datetime2 NOT NULL,
    [Type] nvarchar(max) NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Inventory_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Invoices] (
    [Id] int NOT NULL IDENTITY,
    [InvoiceNumber] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [UserId] int NOT NULL,
    [InvoiceDate] datetime2 NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [Isv] int NOT NULL,
    [Discount] int NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Invoices_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Invoices_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [InvoiceDetail] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [Qty] int NOT NULL,
    [InvoiceId] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InvoiceDetail_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InvoiceDetail_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Inventory_ProductId] ON [Inventory] ([ProductId]);
GO

CREATE UNIQUE INDEX [IX_InvoiceDetail_InvoiceId] ON [InvoiceDetail] ([InvoiceId]);
GO

CREATE INDEX [IX_InvoiceDetail_ProductId] ON [InvoiceDetail] ([ProductId]);
GO

CREATE INDEX [IX_Invoices_ClientId] ON [Invoices] ([ClientId]);
GO

CREATE INDEX [IX_Invoices_UserId] ON [Invoices] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928211146_InitialCreate', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'SellingPrice');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Products] ALTER COLUMN [SellingPrice] decimal(18,5) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'PurshacePrice');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Products] ALTER COLUMN [PurshacePrice] decimal(18,5) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoices]') AND [c].[name] = N'Total');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Invoices] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Invoices] ALTER COLUMN [Total] decimal(18,5) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoices]') AND [c].[name] = N'SubTotal');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Invoices] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Invoices] ALTER COLUMN [SubTotal] decimal(18,5) NOT NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InvoiceDetail]') AND [c].[name] = N'Price');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [InvoiceDetail] ALTER COLUMN [Price] decimal(18,5) NOT NULL;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Dni', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] ON;
INSERT INTO [Clients] ([Id], [Address], [Dni], [FirstName], [LastName], [Phone])
VALUES (1, N'XXX', N'1X2X3X', N'Gina', N'Balanta', N'123456789');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Dni', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FullName', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [FullName], [Password], [UserName])
VALUES (1, N'Juan Felipe Balanta Rentería', N'felipe123', N'felipe');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FullName', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928212535_SeedInitialData', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Maximum', N'Minimum', N'Name', N'PurshacePrice', N'SellingPrice', N'Type') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Code], [Maximum], [Minimum], [Name], [PurshacePrice], [SellingPrice], [Type])
VALUES (1, N'das54a5da', 708, 50, N'Televisor', 1500000.0, 1700000.0, N'XDXDXD');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Maximum', N'Minimum', N'Name', N'PurshacePrice', N'SellingPrice', N'Type') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928212920_SeedDataProduct', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClientId', N'Discount', N'InvoiceDate', N'InvoiceNumber', N'Isv', N'SubTotal', N'Total', N'UserId') AND [object_id] = OBJECT_ID(N'[Invoices]'))
    SET IDENTITY_INSERT [Invoices] ON;
INSERT INTO [Invoices] ([Id], [ClientId], [Discount], [InvoiceDate], [InvoiceNumber], [Isv], [SubTotal], [Total], [UserId])
VALUES (1, 1, 19, '2022-09-28T16:31:52.6808033-05:00', NULL, 0, 1000.0, 10000.0, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClientId', N'Discount', N'InvoiceDate', N'InvoiceNumber', N'Isv', N'SubTotal', N'Total', N'UserId') AND [object_id] = OBJECT_ID(N'[Invoices]'))
    SET IDENTITY_INSERT [Invoices] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928213153_SeedDataInvoice', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InvoiceId', N'Price', N'ProductId', N'Qty') AND [object_id] = OBJECT_ID(N'[InvoiceDetail]'))
    SET IDENTITY_INSERT [InvoiceDetail] ON;
INSERT INTO [InvoiceDetail] ([Id], [InvoiceId], [Price], [ProductId], [Qty])
VALUES (1, 1, 5000.0, 1, 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InvoiceId', N'Price', N'ProductId', N'Qty') AND [object_id] = OBJECT_ID(N'[InvoiceDetail]'))
    SET IDENTITY_INSERT [InvoiceDetail] OFF;
GO

UPDATE [Invoices] SET [InvoiceDate] = '2022-09-28T16:33:36.4584513-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928213336_SeedDataInvoiceDetail', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InventoryDate', N'ProductId', N'Qty', N'Type') AND [object_id] = OBJECT_ID(N'[Inventory]'))
    SET IDENTITY_INSERT [Inventory] ON;
INSERT INTO [Inventory] ([Id], [InventoryDate], [ProductId], [Qty], [Type])
VALUES (1, '2022-09-28T16:35:04.7676661-05:00', 1, 50, N'XD');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InventoryDate', N'ProductId', N'Qty', N'Type') AND [object_id] = OBJECT_ID(N'[Inventory]'))
    SET IDENTITY_INSERT [Inventory] OFF;
GO

UPDATE [Invoices] SET [InvoiceDate] = '2022-09-28T16:35:04.7666121-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928213505_SeedDataInventory', N'5.0.17');
GO

COMMIT;
GO

