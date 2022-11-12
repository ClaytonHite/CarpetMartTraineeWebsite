CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(100) NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [AddressLine1] VARCHAR(100) NULL, 
    [AddressLine2] VARCHAR(100) NULL, 
    [City] VARCHAR(100) NULL, 
    [State] VARCHAR(100) NULL, 
    [Zip] VARCHAR(100) NULL, 
    [Phone] VARCHAR(100) NULL, 
    [Email] VARCHAR(100) NULL, 
    [MSId] VARCHAR(200) NULL, 
)
