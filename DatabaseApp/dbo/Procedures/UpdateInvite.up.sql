CREATE OR ALTER  PROCEDURE [UpdateInvite]
	@user_id int,
	@house_id int,
	@status int
AS
BEGIN
	UPDATE [dbo].[Invites]
	SET [Status] = @status
	WHERE @user_id = [User] AND @house_id = [House]
END;