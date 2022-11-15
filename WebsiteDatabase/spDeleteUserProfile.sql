CREATE PROCEDURE [dbo].[spDeleteUserProfile]
	@MSId int
AS
	DELETE FROM Users
	WHERE Users.MSId = @MSId
RETURN 0
