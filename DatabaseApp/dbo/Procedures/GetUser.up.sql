CREATE OR ALTER PROCEDURE [dbo].[GetUser](@user_id AS varchar(64))
AS
BEGIN
	SELECT [dbo].[Users].[Id], [dbo].[Users].[Email], [dbo].[Users].[Name] FROM [dbo].[Users]
	WHERE [dbo].[Users].[AuthId] = @user_id;
END;