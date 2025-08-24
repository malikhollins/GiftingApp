CREATE OR ALTER PROCEDURE [dbo].[CreateList]
	@house_id INT,
	@user_id INT,
	@name varchar(250)
AS
DECLARE @list_id INT;
BEGIN
	INSERT INTO [dbo].[Lists]([House],[Owner],[Name])
	VALUES (@house_id, @user_id, @name)
	SET @list_id = SCOPE_IDENTITY();

	SElECT @list_id AS Id, @house_id AS House, @user_id AS Owner, @name As Name
END
