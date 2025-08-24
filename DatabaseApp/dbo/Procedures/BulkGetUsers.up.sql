CREATE OR ALTER PROCEDURE [dbo].[BulkGetUsers]
	@email varchar(64)
AS
BEGIN
	SELECT [dbo].[Users].[Id], [dbo].[Users].[Name], [dbo].[Users].[Email]
	FROM [dbo].[Users]
	WHERE CONTAINS([dbo].[Users].[Email], @email) 
END;
