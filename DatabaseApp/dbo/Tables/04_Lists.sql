CREATE TABLE [dbo].[Lists]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,

    [House] INT NOT NULL,

    [Owner] INT NOT NULL,
    
    [Name] VARCHAR(30) NULL,

    CONSTRAINT [FK_Lists_ToUsers] FOREIGN KEY ([Owner]) REFERENCES [Users]([Id]),

    CONSTRAINT [FK_Lists_ToHouses] FOREIGN KEY ([House]) REFERENCES [Houses]([Id])
)

GO

CREATE INDEX [IX_Lists_House] ON [dbo].[Lists] ([House], [Owner])

