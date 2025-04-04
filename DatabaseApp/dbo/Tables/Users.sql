CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 

    [AuthId] VARCHAR(64) NOT NULL,

    [Email] VARCHAR(320) NOT NULL,

    [Name] VARCHAR(64) NULL
)

GO

CREATE INDEX [IX_Users_AuthId] ON [dbo].[Users] ([AuthId])
