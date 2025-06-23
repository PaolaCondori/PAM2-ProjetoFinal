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
    [TipoPerfil] Varchar(200) NOT NULL,
    [Senha] Varchar(200) NOT NULL,
    [ChamadosAbertos] Varchar(200) NOT NULL,
    [ChamadosConcluidos] Varchar(200) NOT NULL,
    [SenhaHash] varbinary(max) NULL,
    [SenhaSalt] varbinary(max) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Rm])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Rm', N'ChamadosAbertos', N'ChamadosConcluidos', N'Email', N'Nome', N'Senha', N'SenhaHash', N'SenhaSalt', N'Telefone', N'TipoPerfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Rm], [ChamadosAbertos], [ChamadosConcluidos], [Email], [Nome], [Senha], [SenhaHash], [SenhaSalt], [Telefone], [TipoPerfil])
VALUES (123090, '1', '2', 'Maria@gmail.com', 'Maria', '123456', NULL, NULL, '11 988871234', 'Funcionario'),
(123980, '5', '1', 'João@gmail.com', 'João', '180805', NULL, NULL, '11 911876543', 'GestorDepartamento'),
(150570, '0', '3', 'Marcela@gmail.com', 'Marcela', '030505', NULL, NULL, '11 955478756', 'Funcionario'),
(201190, '2', '5', 'Eduardo@gmail.com', 'Eduardo', '567890', NULL, NULL, '11 908879876', 'GestorGeral'),
(339090, '3', '2', 'Claudia@gmail.com', 'Claudia', '456321', NULL, NULL, '11 989971774', 'Funcionário');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Rm', N'ChamadosAbertos', N'ChamadosConcluidos', N'Email', N'Nome', N'Senha', N'SenhaHash', N'SenhaSalt', N'Telefone', N'TipoPerfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250623022318_InitialCreate', N'9.0.6');

COMMIT;
GO

