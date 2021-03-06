USE [StudentDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_Student]    Script Date: 5/17/2020 8:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_Student]
	 @StudentId varchar(50)
	,@Name varchar(MAX)	
	,@Roll varchar(6)
	,@OperationType int

AS
BEGIN TRAN
	
	IF(@OperationType = 1) --Insert
	BEGIN
		
		SET @StudentId = (SELECT COUNT(*) FROM Student) + 1

		INSERT INTO Student  (StudentId,	[Name],		Roll)
			           VALUES(@StudentId,	@Name,		@Roll)

		SELECT * FROM Student WHERE StudentId=@StudentId

	END
	ELSE IF(@OperationType = 2) --Update
	BEGIN
		IF (@StudentId = 0)
		BEGIN
			ROLLBACK
				RAISERROR (N'Invalid Student !!!~',16,1);	
			RETURN
		END

		UPDATE Student SET [Name]=@Name
						   ,Roll=@Roll
						WHERE StudentId=@StudentId

		SELECT * FROM Student WHERE StudentId=@StudentId
	END
	ELSE IF(@OperationType = 3) --Delete
	BEGIN
		IF (@StudentId = 0)
		BEGIN
			ROLLBACK
				RAISERROR (N'Invalid Student !!!~',16,1);	
			RETURN
		END

		DELETE FROM Student WHERE StudentId=@StudentId
	END
COMMIT TRAN