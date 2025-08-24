CREATE OR ALTER  PROCEDURE [dbo].[CreateHouse](@user_id int, @name varchar(30))
AS
DECLARE @house_id INT;
BEGIN
	INSERT INTO [dbo].[Houses]([Owner],[Name],[GiftType])
	VALUES (@user_id, @name, 0);
	SET @house_id = SCOPE_IDENTITY();

	SElECT @house_id AS Id, @name As Name, @user_id As Owner, 0 As GiftType
END;
