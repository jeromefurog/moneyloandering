
/****** Object:  StoredProcedure [dbo].[SaveLoan]    Script Date: 6/8/2014 2:56:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaveLoan] 
	-- Add the parameters for the stored procedure here
	@actiontype bit,
	@id int,
	@amount money,
	@period int,
	@termid int,
	@date datetime,
	@interest decimal,
	@collateralid int,
	@collateraldetails nvarchar(500),
	@comakerid int,   
	@investorid int,     
	@borrowerid int,
	@notes nvarchar(500),
	@penalty money,
	@penaltydetails nvarchar(500),
	@status int,
	@createdby nvarchar(50),
	@createddate datetime,
	@updatedby nvarchar(50),
	@updateddate datetime
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN TRY
       BEGIN TRANSACTION
       
		IF (@actiontype = 0) 
		BEGIN
		
			DECLARE @interestid int
			SET @interestid = (SELECT TOP 1 d.id FROM [DeductibleInterest] d ORDER BY d.id)
			
			-- Insert statements for procedure here
			INSERT INTO [Loans]
				   ([amount]
				   ,[period]
				   ,[term_id]
				   ,[date]
				   ,[interest]
				   ,[collateral_id]
				   ,[collateral_details]
				   ,[comaker_id]
				   ,[investor_id]
				   ,[borrower_id]
				   ,[notes]
				   ,[penalty]
				   ,[penalty_details]
				   ,[status]
				   ,[interest_id]
				   ,[created_by]
				   ,[created_date]
				   ,[updated_by]
				   ,[updated_date])
			 VALUES
				   (@amount
				   ,@period
				   ,@termid
				   ,@date
				   ,@interest
				   ,@collateralid
				   ,@collateraldetails
				   ,@comakerid
				   ,@investorid
				   ,@borrowerid
				   ,@notes
				   ,@penalty
				   ,@penaltydetails
				   ,@status
				   ,@interestid
				   ,@createdby
				   ,@createddate
				   ,@updatedby
				   ,@updateddate)
					
			DECLARE @newid INT
			SELECT @newid = SCOPE_IDENTITY()
			
			EXEC [InsertLoanDates] @termid, @date, @period, @amount, @interest, @newid, @createdby, @createddate, @updatedby, @updateddate
			

			
		
		END
		ELSE
		BEGIN

			UPDATE [Loans] SET
					[notes] = @notes,                           
					[collateral_id] = @collateralid,
					[collateral_details] = @collateraldetails,
					[penalty] = @penalty,
					[penalty_details] = @penaltydetails,
					[updated_by] = @updatedby,
					[updated_date] = @updateddate
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
