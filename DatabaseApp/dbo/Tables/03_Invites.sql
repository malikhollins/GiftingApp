CREATE TABLE [dbo].[Invites]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,

    [User] INT NOT NULL,

    [House] INT NOT NULL, 

    -- Status is an enum for the state of the user invitation
    -- ( currently, 0 for pending, 1 for accepted, 2 for rejected ).

    [Status] INT NOT NULL,

    CONSTRAINT [FK_Invites_Users] FOREIGN KEY ([User]) REFERENCES [Users]([Id]),

    CONSTRAINT [FK_Invites_House] FOREIGN KEY ([House]) REFERENCES [Houses]([Id])
)

GO

CREATE INDEX [IX_Invites_UserHouse] ON [dbo].[Invites] ([User], [House])

GO

CREATE INDEX [IX_Invites_HouseUser] ON [dbo].[Invites] ([House], [User])