CREATE TABLE [dbo].[Houses]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 

    [Owner] INT NOT NULL, 

    [Name] VARCHAR(30) NULL, 

    [GiftType] INT NULL, 
    
    -- GiftingType is an enum for the type of gifting the house uses 
    -- ( currently, 0 for assigning user to list item, 1 for random gifting ).
    -- If we need to, we can expand this to its own table.

    CONSTRAINT [FK_Houses_Users] FOREIGN KEY ([Owner]) REFERENCES Users(Id) 
)
