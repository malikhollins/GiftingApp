CREATE PROCEDURE [dbo].[BulkGetUsers]
	@email varchar(64),
	@name varchar(320)
AS
BEGIN
	SELECT [dbo].[Users].[Id], [dbo].[Users].[Name], [dbo].[Users].[Email]
	FROM [dbo].[Users]
	WHERE CONTAINS([dbo].[Users].[Email], @email) OR CONTAINS([dbo].[Users].[Name], @name) 
END;
