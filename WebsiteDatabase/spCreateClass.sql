CREATE PROCEDURE [dbo].[spCreateClass]
@ClassName varchar(200),
@ClassStartDate varchar(20),
@ClassEndDate varchar(20),
@ClassStartTime varchar(20),
@ClassEndTime varchar(20),
@ClassInformation varchar(2000),
@ClassHost varchar(100),
@ClassAddress varchar(100)
AS
	INSERT INTO ClassSchedule (ClassName, ClassStartDate, ClassEndDate, ClassStartTime, ClassEndTime, ClassInformation, ClassHost, ClassAddress)
	VALUES (@ClassName, @ClassStartDate, @ClassEndDate, @ClassStartTime, @ClassEndTime, @ClassInformation, @ClassHost, @ClassAddress)
