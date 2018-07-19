IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [ProductCategories] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedBy] int NULL,
    [ModifiedDate] datetime2 NULL,
    [Name] nvarchar(255) NOT NULL,
    [ParentId] int NULL,
    [Version] rowversion NULL,
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductCategories_ProductCategories_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [ProductCategories] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ProductCategories_ParentId] ON [ProductCategories] ([ParentId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180405072419_CreateProductCategories', N'2.0.2-rtm-10011');

GO