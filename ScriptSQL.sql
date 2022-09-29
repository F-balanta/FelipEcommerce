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

BEGIN TRANSACTION;
GO

ALTER TABLE [Clients] ADD [Age] int NOT NULL DEFAULT 0;
GO

UPDATE [Clients] SET [Age] = 34
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Inventory] SET [InventoryDate] = '2022-09-28T19:04:55.1671479-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Invoices] SET [InvoiceDate] = '2022-09-28T19:04:55.1648984-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929000455_SeedDataClientAge and added AgeColumn', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'SellingPrice');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Products] ALTER COLUMN [SellingPrice] decimal(18,2) NOT NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'PurshacePrice');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Products] ALTER COLUMN [PurshacePrice] decimal(18,2) NOT NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoices]') AND [c].[name] = N'Total');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Invoices] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Invoices] ALTER COLUMN [Total] decimal(18,2) NOT NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoices]') AND [c].[name] = N'SubTotal');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Invoices] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Invoices] ALTER COLUMN [SubTotal] decimal(18,2) NOT NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoices]') AND [c].[name] = N'InvoiceDate');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Invoices] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Invoices] ALTER COLUMN [InvoiceDate] Date NOT NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InvoiceDetail]') AND [c].[name] = N'Price');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [InvoiceDetail] ALTER COLUMN [Price] decimal(18,2) NOT NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Inventory]') AND [c].[name] = N'InventoryDate');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Inventory] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Inventory] ALTER COLUMN [InventoryDate] Date NOT NULL;
GO

UPDATE [Inventory] SET [InventoryDate] = '2022-09-28T00:00:00.0000000-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Invoices] SET [InvoiceDate] = '2022-09-28T00:00:00.0000000-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929002950_Change DateTime type by Only Date type', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [FK_InvoiceDetail_Invoices_InvoiceId];
GO

ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [FK_InvoiceDetail_Products_ProductId];
GO

ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [PK_InvoiceDetail];
GO

EXEC sp_rename N'[InvoiceDetail]', N'InvoicesDetail';
GO

EXEC sp_rename N'[InvoicesDetail].[IX_InvoiceDetail_ProductId]', N'IX_InvoicesDetail_ProductId', N'INDEX';
GO

EXEC sp_rename N'[InvoicesDetail].[IX_InvoiceDetail_InvoiceId]', N'IX_InvoicesDetail_InvoiceId', N'INDEX';
GO

ALTER TABLE [InvoicesDetail] ADD CONSTRAINT [PK_InvoicesDetail] PRIMARY KEY ([Id]);
GO

ALTER TABLE [InvoicesDetail] ADD CONSTRAINT [FK_InvoicesDetail_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [InvoicesDetail] ADD CONSTRAINT [FK_InvoicesDetail_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929042246_Adding InvoicesDetail', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Inventory] SET [InventoryDate] = '2022-09-29T00:00:00.0000000-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Invoices] SET [InvoiceDate] = '2022-09-29T00:00:00.0000000-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929061347_Fixing name Invoices', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Clients] SET [Address] = N'2246 Joy Lane Burbank CA 91502', [Age] = 65, [Dni] = N'548875445', [FirstName] = N'Heather', [LastName] = N' K. Garcia', [Phone] = N'818-567-4835'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Age', N'Dni', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] ON;
INSERT INTO [Clients] ([Id], [Address], [Age], [Dni], [FirstName], [LastName], [Phone])
VALUES (2, N'1323 Merivale Road Ottawa, ON K2P 0K1', 76, N'370 670 952', N'Quintin P.', N'Evans', N'613-380-4940'),
(24, N'Victoria, BC V8Z 2J8', 45, N'106 469 133', N'Mili', N'Arriaga Lozada', N'250-881-7583'),
(23, N'Minburn, AB T0B 3B0', 23, N'479 099 640', N'Ona Negrete', N'Arenas', N'780-593-0182'),
(22, N'Nobel, ON P0G 1G0', 50, N'064 667 884', N'Aimée', N'Fernández Gracia', N'705-342-5282'),
(21, N'Montreal, QC H4J 1M9', 80, N'445 737 539', N'Amir', N'Sevilla Gamez', N'514-377-1176'),
(20, N'Rocky Mountain House, AB T0M 1T1', 66, N'652 341 447', N'Elijah', N'Ceja Caballero', N'403-846-2441'),
(19, N'Bouchette, QC H0H 0H0', 42, N'757 081 815', N'Edelira', N'Rodrígez Muñoz', N'819-465-9142'),
(17, N'Edmonton, AB T5C 2L2', 29, N'460 547 342', N'Crisóstomo Raya', N'Cantú', N'780-475-8399'),
(16, N'Quebec, QC G1V 3V5', 63, N'079 929 295', N'Justiniano Vigil', N'Castellanos', N'418-569-7055'),
(15, N'Mission, BC V2V 1J7', 23, N'116 625 781', N'Tibalt Alejandro', N'Velásquez', N'604-814-7305'),
(14, N'St Catharines, ON L2N 1S8', 63, N'081 465 452', N'Debra Tirado', N'Trejo', N'289-228-2329'),
(18, N'Ottawa, ON K1P 5M7', 37, N'716 623 541', N'Palemon', N'Peres Vega', N'613-978-8428'),
(12, N'Toronto, ON M3H 4J1', 68, N'554 687 665', N'Inalén Medrano', N'Lebrón', N'416-378-8701'),
(11, N'Fort Erie, ON L2A 1P3', 45, N'342 233 863', N'Achill Magana', N'Pedroza', N'289-321-0566'),
(10, N'Cobourg, ON K9A 1J1', 36, N'201 756 269', N'Fabrizio Vázquez', N'Cepeda', N'905-373-3704'),
(9, N'Calgary, AB T2V 2W2', 26, N'544 769 607', N'Carissa Gutiérrez', N'Sarabia', N'403-861-4303'),
(8, N'Calgary, AB T2P 0H3', 77, N'234 463 297', N'Ezequías Regalado', N'Henríquez', N'403-473-8979'),
(7, N'Alexandra, PE C1B 0N7', 34, N'038 970 604', N'Randall Laureano', N'Rodrígez', N'902-368-0646'),
(6, N'Windsor, ON N8Y 4V1', 25, N'451 591 119', N'David M.', N'Yang', N'519-981-6925'),
(5, N'Cranbrook, BC V1C 2R9', 65, N'598 123 990', N'Hugh A.', N'Logan', N'250-417-7243'),
(4, N'Nanaimo, BC V9R 3A8', 38, N'328 840 673', N'Stephanie F.', N'Fahey', N'250-816-8363'),
(3, N'Lakeview Heights, BC V1Z 1K2', 18, N'667 962 229', N'Ruby C.', N'Crawford', N'416-609-6578'),
(13, N'Tingwick, QC J0A 1L0', 45, N'490 494 556', N'Petronio Dueñas', N'Galindo', N'819-359-4816');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Age', N'Dni', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] OFF;
GO

UPDATE [Users] SET [FullName] = N'Edwin Trevino', [Password] = N'edwingladiatoryoda123$', [UserName] = N'edwingladiatoryoda'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FullName', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [FullName], [Password], [UserName])
VALUES (4, N'Todd Hobbs', N'Toddroastpeardrumrye', N'Toddthegraduaterye'),
(5, N'Vanessa Leblanc', N'Vanessacowriverpig', N'Vanessagandalftimon'),
(6, N'Reginald Cruz', N'Reginaldngc5195bread', N'Reginaldpomegranate'),
(7, N'John Collins', N'Johnbirthdaycakelog', N'Johnspiralshapeflute'),
(8, N'Juan Ball', N'Juanplatoonfrognet', N'Juanrearwindowbridge'),
(9, N'Brian Henry', N'Brianbatthegoldrush', N'Brianastronoutwine'),
(10, N'Kathleen Ramirez', N'Kathleenhaloakirapig', N'Kathleenxylophonered'),
(3, N'James Taylor', N'jameshippopotamuspie', N'jamescitizenkanewind'),
(2, N'Donald Smith MD', N'Donaldspinachcheetah123$', N'Donaldspinachcheetah');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FullName', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929165116_SeedData Users and Clients', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Maximum');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Products] DROP COLUMN [Maximum];
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Minimum');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Products] DROP COLUMN [Minimum];
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'PurshacePrice');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Products] DROP COLUMN [PurshacePrice];
GO

EXEC sp_rename N'[Products].[Type]', N'UrlImage', N'COLUMN';
GO

EXEC sp_rename N'[Products].[SellingPrice]', N'Price', N'COLUMN';
GO

EXEC sp_rename N'[Products].[Code]', N'Description', N'COLUMN';
GO

UPDATE [Products] SET [Description] = N'Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday', [Name] = N'Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops', [Price] = 497854.0, [UrlImage] = N'https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Price', N'UrlImage') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Description], [Name], [Price], [UrlImage])
VALUES (19, N'100% Polyester, Machine wash, 100% cationic polyester interlock', N'Opna Women''s Short Sleeve Moisture', 35997.0, N'https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_.jpg'),
(18, N'5% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem', N'MBJ Women''s Solid Short Sleeve Boat Neck V', 44600.0, N'https://fakestoreapi.com/img/71z3kpMAYsL._AC_UY879_.jpg'),
(17, N'Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. ', N'Rain Jacket Women Windbreaker Striped Climbing Raincoats', 181075.0, N'https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2.jpg'),
(16, N'00% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER)', N'Lock and Love Women''s Removable Hooded Faux Leather Moto Biker Jacket', 135613.0, N'https://fakestoreapi.com/img/81XH0e8fefL._AC_UY879_.jpg'),
(15, N'Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece', N'BIYLACLESEN Women''s 3-in-1 Snowboard Jacket Winter Coats', 258051.0, N'https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg'),
(14, N'49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY', N'Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED', 4527964.0, N'https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_.jpg'),
(13, N'1. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. ', N'Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin', 2712277.0, N'https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg'),
(12, N'WD NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ', N'WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive', 510721.0, N'https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg'),
(11, N'3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ', N'Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5', 498081.0, N'https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg'),
(10, N'Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive', N'SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s', 496752.0, N'https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg'),
(9, N'https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg', N'WD 2TB Elements Portable External Hard Drive - USB 3.0', 289792.0, N''),
(8, N'Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel', N'Pierced Owl Rose Gold Plated Stainless Steel Double', 49762.0, N'https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg'),
(7, N'Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine''s Day...', N'White Gold Plated Princess', 45234.0, N'https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg'),
(6, N'Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.', N'Solid Gold Petite Micropave', 760705.0, N'https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg'),
(5, N'From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean''s pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.', N'John Hardy Women''s Legends Naga Gold & Silver Dragon Station Chain Bracelet', 3146966.0, N'https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg'),
(4, N'he color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.', N'Mens Casual Slim Fit', 72402.0, N''),
(3, N'great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.', N'Mens Cotton Jacket', 253523.0, N'https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg'),
(20, N'5%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch', N'DANVOUY Womens T Shirt Casual Cotton Short', 90560.0, N'https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg'),
(2, N'Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.', N'Mens Casual Premium Slim Fit T-Shirts', 100974.0, N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Price', N'UrlImage') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929181249_The structure of the Products table is changed and data is seeded to it.', N'5.0.17');
GO

COMMIT;
GO

