CREATE PROCEDURE [dbo].[spClassList]
AS
	SELECT cs.Id, cs.ClassName, cs.ClassStartDate, cs.ClassEndDate, cs.ClassStartTime,
			cs.ClassEndTime, cs.ClassAddress, cs.ClassHost, cs.ClassInformation 
	FROM ClassSchedule cs
