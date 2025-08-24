CREATE OR ALTER PROCEDURE [dbo].[UpdateBuyerInItem]
	@item_id INT,
	@buyer_id INT
AS
BEGIN
	UPDATE [dbo].[ItemsInList]
	SET [Buyer] = @buyer_id
	WHERE @item_id = [dbo].[ItemsInList].[Id]
END;
