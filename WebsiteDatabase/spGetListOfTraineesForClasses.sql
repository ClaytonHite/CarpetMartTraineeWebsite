CREATE PROCEDURE [dbo].[spGetListOfTraineesForClasses]
	@ClassName varchar(100)
AS
	SELECT cs.Id, cs.ClassName, cs.ClassStartDate, cs.ClassEndDate, cs.ClassStartTime, cs.ClassEndTime, cs.ClassInformation, cs.ClassHost, cs.ClassAddress,
			us.MSId, us.FirstName, us.MiddleName, us.LastName, us.AddressLine1, us.AddressLine2, us.City, us.[State], us.Zip, us.Phone, us.Email

	FROM ClassSchedule cs
	INNER JOIN TraineesRegisteredForClasses tr ON tr.ClassId = cs.Id
	INNER JOIN Users us ON us.Id = tr.UserId
	WHERE cs.ClassName = @ClassName

