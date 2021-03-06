
/****** Object:  StoredProcedure [dbo].[SaveWithdrawals]    Script Date: 6/6/2014 11:05:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SaveWithdrawals] 
	-- Add the parameters for the stored procedure here
	@actiontype bit,
	@id int,
	@userid int,
	@amount money,
	@date date,
	@notes nvarchar(500),
	@status int,
	@createdby nvarchar(50),
	@createddate datetime,
	@updatedby nvarchar(50),
	@updateddate datetime,
	@remType bit
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN TRY
       BEGIN TRANSACTION
       
		IF (@actiontype = 0) 
		BEGIN	
			
			INSERT INTO [dbo].[Withdrawals]
				   ([user_id]
				   ,[amount]
				   ,[date]
				   ,[notes]
				   ,[type]
				   ,[status]
				   ,[created_by]
				   ,[created_date]
				   ,[updated_by]
				   ,[updated_date])
			 VALUES
				   (@userid
				   ,@amount
				   ,@date
				   ,@notes
				   ,@remType
				   ,@status
				   ,@createdby 
				   ,@createddate
				   ,@updatedby
				   ,@updateddate)

		END
		ELSE
		BEGIN
		
			UPDATE [dbo].[Withdrawals]
			SET [notes] = @notes			  
			  ,[updated_by] = @updatedby
			  ,[updated_date] = @updateddate
			WHERE id = @id
		
		END		
       

       COMMIT
    END TRY
    BEGIN CATCH
      IF @@TRANCOUNT > 0
         ROLLBACK

      -- Raise an error with the details of the exception
      DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
      SELECT @ErrMsg = ERROR_MESSAGE(),
             @ErrSeverity = ERROR_SEVERITY()

      RAISERROR(@ErrMsg, @ErrSeverity, 1)
    END CATCH

    
	
END



