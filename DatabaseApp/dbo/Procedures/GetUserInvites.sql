CREATE PROCEDURE [dbo].[GetUserInvites]
	@user_id int
AS
BEGIN
	SELECT [dbo].[UserToHouse].[House], [dbo].[Houses].[Owner], [dbo].[UserToHouse].[Status]
	FROM [dbo].[UserToHouse]
	JOIN [dbo].[Houses] ON [dbo].[Houses].[Id] = [dbo].[UserToHouse].[House]
	WHERE [User] = @user_id 
END;