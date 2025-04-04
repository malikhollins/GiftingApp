CREATE PROCEDURE [dbo].[CreateUser](@user_id AS varchar(64), @email AS varchar(320))
AS
BEGIN
	INSERT INTO [dbo].[Users]([AuthId], [Email])
	VALUES (@user_id, @email);
	SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY];  
END;