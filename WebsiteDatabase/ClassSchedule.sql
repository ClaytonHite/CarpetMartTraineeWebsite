CREATE TABLE [dbo].[ClassSchedule]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClassName] VARCHAR(200) NULL, 
    [ClassStartDate] VARCHAR(20) NULL, 
    [ClassEndDate] VARCHAR(20) NULL, 
    [ClassStartTime] VARCHAR(20) NULL, 
    [ClassEndTime] VARCHAR(20) NULL, 
    [ClassInformation] VARCHAR(2000) NULL, 
    [ClassHost] VARCHAR(100) NULL, 
    [ClassAddress] VARCHAR(100) NULL
)
