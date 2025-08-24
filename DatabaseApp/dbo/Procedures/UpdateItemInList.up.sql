CREATE OR ALTER PROCEDURE [dbo].[UpdateItemInList]
(
@item_id AS INT,
@name AS varchar(225), 
@description AS varchar(225),
@link as varchar(225),
@price as varchar(225))
AS
BEGIN
	UPDATE [dbo].[ItemsInList]
	SET [dbo].[ItemsInList].[Name] = @name,
	[dbo].[ItemsInList].[Description] = @description,
	[dbo].[ItemsInList].[Price] = @price,
	[dbo].[ItemsInList].[Link] = @link
	WHERE @item_id = [dbo].[ItemsInList].[Id]
END;
