CREATE PROCEDURE [dbo].[spAddUserProfile]
	@MSId varchar(200),
	@FirstName varchar(100),
	@MiddleName varchar(100),
	@Lastname varchar(100),
	@AddressLine1 varchar(100),
	@AddressLine2 varchar(100),
	@City varchar(100),
	@State varchar (100),
	@Zip varchar(100),
	@Phone varchar(100),
	@Email varchar(100)
AS
	INSERT INTO Users (MSId, FirstName, MiddleName, LastName, AddressLine1, AddressLine2, City, [State], Zip, Phone, Email)
	VALUES (@MSId, @FirstName, @MiddleName, @Lastname, @AddressLine1, @AddressLine2, @City, @State, @Zip, @Phone, @Email)
	SELECT ui.Id, ui.MSId, ui.FirstName, ui.MiddleName, ui.LastName,
	ui.AddressLine1, ui.AddressLine2, ui.City, ui.State, ui.Zip,
	ui.Phone, ui.Email
	FROM Users ui
	WHERE ui.MSId = @MSId
