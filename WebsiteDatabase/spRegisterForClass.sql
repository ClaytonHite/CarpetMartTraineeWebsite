CREATE PROCEDURE [dbo].[spRegisterForClass]
	@ClassName varchar(200),
	@MSId varchar(200)
AS
	DECLARE @UserID int
	DECLARE @ClassID int

	SET @UserID = (SELECT us.Id FROM Users us WHERE us.MSId = @MSId)
	SET @ClassID = (SELECT cs.Id FROM ClassSchedule cs WHERE cs.ClassName = @ClassName)

	INSERT INTO TraineesRegisteredForClasses (ClassId, UserId)
	VALUES (@ClassID, @UserID)
