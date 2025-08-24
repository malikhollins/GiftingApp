CREATE OR ALTER PROCEDURE [CreateInvite]
	@house_id int,
	@user_id int
AS
BEGIN
	INSERT INTO [dbo].[Invites]([User], [House], [Status])
	VALUES (@user_id, @house_id, 0) 
END;
