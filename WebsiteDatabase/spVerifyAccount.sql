CREATE PROCEDURE [dbo].[spVerifyAccount] @Username varchar(100), @Password varchar(100)
AS
	SELECT ua.Id, ua.Username, ua.[Password], ua.AccessRights
	FROM UserAccounts ua 
	WHERE ua.Username = @Username AND ua.[Password] = @Password
