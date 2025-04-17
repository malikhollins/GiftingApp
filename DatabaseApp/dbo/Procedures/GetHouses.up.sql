CREATE PROCEDURE [dbo].[GetHouses](@user_id AS INT)
AS
BEGIN
    SELECT [dbo].[Houses].[Id], [dbo].[Houses].[Owner], [Houses].[Name], [Houses].[GiftType]
    FROM [dbo].[Users]
    JOIN [dbo].[UserToHouse] ON [dbo].[Users].[Id] = [dbo].[UserToHouse].[User]
    JOIN [dbo].[Houses] 
    ON [Houses].[Id] = [dbo].[UserToHouse].[House]
    WHERE [dbo].[Users].[Id] = @user_id;
END;