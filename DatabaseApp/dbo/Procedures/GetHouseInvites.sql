CREATE OR ALTER PROCEDURE [dbo].[GetHouseInvites]
	@house_id int
AS
BEGIN
	SELECT 
	[dbo].[Users].[Id], 
	[dbo].[Users].[Name],
	[dbo].[Invites].[Status]
	FROM [dbo].[Invites]
	JOIN [dbo].[Users] ON [dbo].[Users].[Id] = [dbo].[Invites].[User]
	WHERE @house_id = [dbo].[Invites].[House]
END;