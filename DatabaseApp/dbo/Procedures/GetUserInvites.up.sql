CREATE OR ALTER  PROCEDURE [dbo].[GetUserInvites]
	@user_id int
AS
BEGIN
	SELECT 
	[dbo].[Houses].[Id], 
	[dbo].[Houses].[Owner], 
	[dbo].[Houses].[Name], 
	[dbo].[Invites].[Status]
	FROM [dbo].[Invites]
	JOIN [dbo].[Houses] ON [dbo].[Houses].[Id] = [dbo].[Invites].[House]
	WHERE @user_id = [dbo].[Invites].[User]
END
