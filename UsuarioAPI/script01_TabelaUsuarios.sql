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
CREATE TABLE [TB_USUARIOS] (
    [Rm] int NOT NULL IDENTITY,
    [Nome] Varchar(200) NOT NULL,
    [Email] Varchar(200) NOT NULL,
    [Telefone] Varchar(200) NOT NULL,
    [IdTipoPerfil] int NOT NULL,
    [Senha] int NOT NULL,
    [ChamadosAbertos] Varchar(200) NOT NULL,
    [ChamadosConcluidos] Varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Rm])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Rm', N'ChamadosAbertos', N'ChamadosConcluidos', N'Email', N'IdTipoPerfil', N'Nome', N'Senha', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Rm], [ChamadosAbertos], [ChamadosConcluidos], [Email], [IdTipoPerfil], [Nome], [Senha], [Telefone])
VALUES (123090, '1', '2', 'Maria@gmail.com', 3, 'Maria', 123456, '11 988871234'),
(123980, '5', '1', 'João@gmail.com', 2, 'João', 180805, '11 911876543'),
(150570, '0', '3', 'Marcela@gmail.com', 3, 'Marcela', 30505, '11 955478756'),
(201190, '2', '5', 'Eduardo@gmail.com', 1, 'Eduardo', 567890, '11 908879876'),
(339090, '3', '2', 'Claudia@gmail.com', 3, 'Claudia', 456321, '11 989971774');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Rm', N'ChamadosAbertos', N'ChamadosConcluidos', N'Email', N'IdTipoPerfil', N'Nome', N'Senha', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250619181920_InitialCreate', N'9.0.6');

COMMIT;
GO

