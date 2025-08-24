CREATE OR ALTER PROCEDURE [dbo].[CreateItemInList]
(
@list_id AS INT,
@name AS varchar(225), 
@description AS varchar(225),
@link as varchar(225),
@price as DECIMAL(10, 2) )
AS
DECLARE @item_id INT;
BEGIN
	INSERT INTO [dbo].[ItemsInList] ([List], [Name], [Description], [Price], [Link] )
	VALUES ( @list_id, @name, @description, @price, @link )
	SET @item_id = SCOPE_IDENTITY();

	SELECT 
	@item_id AS Id, 
	@name AS Name, 
	@description AS Description, 
	@price AS Price, 
	@link AS Link
END;
