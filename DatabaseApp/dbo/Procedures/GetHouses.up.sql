CREATE OR ALTER PROCEDURE [dbo].[GetHouses](@user_id AS INT)
AS
BEGIN
    SELECT 
    [dbo].[Houses].[Id], 
    [dbo].[Houses].[Owner], 
    [dbo].[Houses].[Name], 
    [dbo].[Houses].[GiftType]
    FROM [dbo].[Houses]
    LEFT JOIN [dbo].[Invites] ON [dbo].[Invites].[House] = [dbo].[Houses].[Id]
    WHERE [dbo].[Houses].[Owner] = @user_id OR ( [dbo].[Invites].[User] = @user_id AND [dbo].[Invites].[Status] = 1 )
END;