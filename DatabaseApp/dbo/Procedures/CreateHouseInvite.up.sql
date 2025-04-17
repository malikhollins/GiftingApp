CREATE PROCEDURE [CreateHouseInvite]
	@house_id int,
	@invited_id int
AS
BEGIN
	INSERT INTO [dbo].[UserToHouse]([User], [House], [Status])
	VALUES (@house_id, @invited_id, 0) 
END;
