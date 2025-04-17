CREATE TABLE [dbo].[UserToHouse]
(
    [Id] INT NOT NULL PRIMARY KEY,

    [User] INT NOT NULL,

    [House] INT NOT NULL, 

    -- Status is an enum for the state of the user invitation
    -- ( currently, 0 for pending, 1 for accepted, 2 for rejected ).

    [Status] INT NOT NULL,

    CONSTRAINT [FK_UserToHouse_Users] FOREIGN KEY ([User]) REFERENCES [Users]([Id]),

    CONSTRAINT [FK_UserToHouse_House] FOREIGN KEY ([House]) REFERENCES [Houses]([Id])
)

GO

CREATE INDEX [IX_UserToHouse_UserHouse] ON [dbo].[UserToHouse] ([User], [House])

GO

CREATE INDEX [IX_UserToHouse_HouseUser] ON [dbo].[UserToHouse] ([House], [User])