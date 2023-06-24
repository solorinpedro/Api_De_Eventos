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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230606161758_Inicial')
BEGIN
    CREATE TABLE [Eventos] (
        [EventoId] int NOT NULL IDENTITY,
        [Fecha] datetime2 NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Lugar] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Eventos] PRIMARY KEY ([EventoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230606161758_Inicial')
BEGIN
    CREATE TABLE [Tickets] (
        [TicketId] int NOT NULL IDENTITY,
        [Precio] int NOT NULL,
        [CantidadTicket] int NOT NULL,
        [Agotado] bit NOT NULL,
        [Disponible] bit NOT NULL,
        [Area] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Tickets] PRIMARY KEY ([TicketId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230606161758_Inicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230606161758_Inicial', N'7.0.5');
END;
GO

COMMIT;
GO

