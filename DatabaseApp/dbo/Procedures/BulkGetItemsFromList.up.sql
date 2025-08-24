CREATE OR ALTER PROCEDURE [dbo].[BulkGetItemsFromList]
	@list_id INT
AS
BEGIN
	SELECT 
	[dbo].[ItemsInList].[Id],
	[dbo].[ItemsInList].[List],
	[dbo].[ItemsInList].[Name],
	[dbo].[ItemsInList].[Description],
	[dbo].[ItemsInList].[Price],
	[dbo].[ItemsInList].[Link],
	[dbo].[ItemsInList].[Favorite],
	[dbo].[ItemsInList].[Buyer]
	FROM [dbo].[ItemsInList]
	WHERE [dbo].[ItemsInList].[List] = @list_id;
END
