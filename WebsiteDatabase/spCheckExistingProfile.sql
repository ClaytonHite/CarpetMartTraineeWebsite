CREATE PROCEDURE [dbo].[spCheckExistingProfile]
	@MSId varchar(200)
AS
	SELECT ui.Id, ui.MSId, ui.FirstName, ui.MiddleName, ui.LastName,
	ui.AddressLine1, ui.AddressLine2, ui.City, ui.State, ui.Zip,
	ui.Phone, ui.Email
	FROM Users ui
	WHERE ui.MSId = @MSId
