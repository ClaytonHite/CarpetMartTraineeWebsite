CREATE PROCEDURE [dbo].[spDeleteUserProfile]
	@MSId varchar(200)
AS
	DELETE FROM Users
	WHERE Users.MSId = @MSId

RETURN 0
