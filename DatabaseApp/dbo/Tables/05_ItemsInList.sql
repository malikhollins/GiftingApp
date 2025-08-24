CREATE TABLE [dbo].[ItemsInList]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 

    [List] INT NOT NULL,

    [Name] VARCHAR(250) NOT NULL, 

    [Description] VARCHAR(250) NULL, 

    [Price] DECIMAL(10, 2) NULL, 

    [Link] VARCHAR(2048) NULL, 

    [Favorite] BIT NULL,

    [Buyer] INT NULL, 

    CONSTRAINT [FK_ListItems_ToLists] FOREIGN KEY ([List]) REFERENCES [Lists]([Id]),

    CONSTRAINT [FK_ListItems_ToUsers] FOREIGN KEY ([Buyer]) REFERENCES [Users]([Id])
)

GO

CREATE INDEX [IX_ItemsInList_List] ON [dbo].[ItemsInList] ([List])
