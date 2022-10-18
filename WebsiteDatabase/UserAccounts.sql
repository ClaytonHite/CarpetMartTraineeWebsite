CREATE TABLE [dbo].[UserAccounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] VARCHAR(100) NULL, 
    [Password] VARCHAR(100) NULL, 
    [AccessRights] INT NULL 
)
