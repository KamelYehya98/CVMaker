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

CREATE TABLE [Users] (
    [UserID] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [PasswordConfirm] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
);
GO

CREATE TABLE [ResumeInfos] (
    [ResumeInfoID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Profession] nvarchar(max) NOT NULL,
    [AboutMe] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Image] nvarchar(max) NULL,
    [UserID] int NOT NULL,
    CONSTRAINT [PK_ResumeInfos] PRIMARY KEY ([ResumeInfoID]),
    CONSTRAINT [FK_ResumeInfos_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Experiences] (
    [ExperienceID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Text] nvarchar(max) NOT NULL,
    [ResumeInfoID] int NOT NULL,
    CONSTRAINT [PK_Experiences] PRIMARY KEY ([ExperienceID]),
    CONSTRAINT [FK_Experiences_ResumeInfos_ResumeInfoID] FOREIGN KEY ([ResumeInfoID]) REFERENCES [ResumeInfos] ([ResumeInfoID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Languages] (
    [LanguageID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Proficiency] int NOT NULL,
    [ResumeInfoID] int NOT NULL,
    CONSTRAINT [PK_Languages] PRIMARY KEY ([LanguageID]),
    CONSTRAINT [FK_Languages_ResumeInfos_ResumeInfoID] FOREIGN KEY ([ResumeInfoID]) REFERENCES [ResumeInfos] ([ResumeInfoID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Skills] (
    [SkillID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Proficiency] int NOT NULL,
    [ResumeInfoID] int NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([SkillID]),
    CONSTRAINT [FK_Skills_ResumeInfos_ResumeInfoID] FOREIGN KEY ([ResumeInfoID]) REFERENCES [ResumeInfos] ([ResumeInfoID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Experiences_ResumeInfoID] ON [Experiences] ([ResumeInfoID]);
GO

CREATE INDEX [IX_Languages_ResumeInfoID] ON [Languages] ([ResumeInfoID]);
GO

CREATE INDEX [IX_ResumeInfos_UserID] ON [ResumeInfos] ([UserID]);
GO

CREATE INDEX [IX_Skills_ResumeInfoID] ON [Skills] ([ResumeInfoID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210604081413_FirstMigration', N'5.0.6');
GO

COMMIT;
GO

