CREATE OR ALTER PROCEDURE [dbo].[UpdateFavoriteItem]
	@item_id AS INT,
	@favorited AS BIT
AS
BEGIN
	UPDATE [dbo].[ItemsInList]
	SET [Favorite] = @favorited
	WHERE [dbo].[ItemsInList].[Id] = @item_id
END
