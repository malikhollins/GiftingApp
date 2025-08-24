CREATE OR ALTER PROCEDURE [dbo].[BulkGetLists]
	@house_id INT
AS
BEGIN
	SELECT 
	[dbo].[Lists].[Id],
	[dbo].[Lists].[House],
	[dbo].[Lists].[Owner],
	[dbo].[Lists].[Name]
	FROM [dbo].[Lists]
	WHERE [dbo].[Lists].[House] = @house_id;
END;