CREATE PROCEDURE [dbo].[CreateHouse]
		@user_id int,
		@name varchar(30)
AS
DECLARE @house_id INT;
BEGIN
	INSERT INTO [dbo].[Houses]([Owner],[Name])
	VALUES (@user_id, @name);
	SELECT @house_id = SCOPE_IDENTITY();

	INSERT INTO [dbo].[UserToHouse]([User],[House])
	VALUES (@user_id, @house_id)

	RETURN @house_id
END;
