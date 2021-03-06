
/****** Object:  StoredProcedure [dbo].[GetOverDuePayable]    Script Date: 6/7/2014 2:36:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAlerts] 
	-- Add the parameters for the stored procedure here
	@type INT,
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	
	DECLARE @dateCutoff datetime, @day INT
	
	
	IF (@type = 0)
	BEGIN

		-- Thank You
		SET @dateCutoff = GETDATE()
		SELECT @day = DATEPART(d,@dateCutoff)
			
		IF (@day > 15)
		BEGIN
			SELECT @dateCutoff = DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, @dateCutoff) + 1, 0))
		END
		ELSE 
		BEGIN
			SELECT @dateCutoff = DATEADD(DAY, 14, DATEADD(MONTH, DATEDIFF(MONTH, 0, @dateCutoff), 0));
		END

	
		SELECT TOP 1 p.id, 	
		p.loan_id, 
		b.first_name + ' ' + b.last_name name,
		l.borrower_id,
		'Php ' + CONVERT(nvarchar(50), p.amount) amount, 
		CONVERT(VARCHAR(12), p.[date], 100) [date], 
		p.notes, 
		p.amount realamount,
		p.[status]
		FROM dbo.Payables p, dbo.Loans l, dbo.Users b
		WHERE p.status = 1 AND l.status = 1 AND b.status = 1
		AND l.id = p.loan_id AND l.borrower_id = b.id
		--AND p.[date] NOT BETWEEN GETDATE() AND @dateCutoff
		--AND p.[date] < @dateCutoff
		AND l.borrower_id = @id
		ORDER BY p.[date] DESC
	
	END

	IF (@type = 1)
	BEGIN

		-- OVER DUE
		SET @dateCutoff = GETDATE()
		SELECT @day = DATEPART(d,@dateCutoff)
			
		IF (@day > 15)
		BEGIN
			SELECT @dateCutoff = DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, @dateCutoff) + 1, 0))
		END
		ELSE 
		BEGIN
			SELECT @dateCutoff = DATEADD(DAY, 14, DATEADD(MONTH, DATEDIFF(MONTH, 0, @dateCutoff), 0));
		END

	
		SELECT p.id, 	
		p.loan_id, 
		b.first_name + ' ' + b.last_name name,
		l.borrower_id,
		'Php ' + CONVERT(nvarchar(50), p.amount) amount, 
		CONVERT(VARCHAR(12), p.[date], 100) [date],
		p.notes, 
		p.amount realamount,
		p.[status]
		FROM dbo.Payables p, dbo.Loans l, dbo.Users b
		WHERE p.status = 0 AND l.status = 1 AND b.status = 1
		AND l.id = p.loan_id AND l.borrower_id = b.id
		AND p.[date] NOT BETWEEN GETDATE() AND @dateCutoff
		AND p.[date] < @dateCutoff
		AND l.borrower_id = @id

	END

	IF (@type = 2)
	BEGIN

		SET @dateCutoff = GETDATE()
		SELECT @day = DATEPART(d,@dateCutoff)
			
		IF (@day > 15)
		BEGIN
			SELECT @dateCutoff = DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, @dateCutoff) + 1, 0))
		
		
		END
		ELSE 
		BEGIN
			SELECT @dateCutoff = DATEADD(DAY, 14, DATEADD(MONTH, DATEDIFF(MONTH, 0, @dateCutoff), 0));
		END
 
		IF (CAST(@dateCutoff AS DATE) = CAST(GETDATE() AS DATE))
		   BEGIN 
		
		
				SELECT p.id, 
			   p.loan_id, 
			   b.first_name + ' ' + b.last_name name,
			   l.borrower_id,
			   'Php ' + CONVERT(nvarchar(50), p.amount) amount, 
			   CONVERT(VARCHAR(12), p.[date], 100) [date],
			   p.notes, 
			   p.amount realamount,
			   p.[status]
			   FROM dbo.Payables p, dbo.Loans l, dbo.Users b
			   WHERE p.status = 0 AND l.status = 1 AND b.status = 1
			   AND l.id = p.loan_id AND l.borrower_id = b.id
			   AND p.[date] BETWEEN DATEADD(d, -1,@dateCutoff) AND @dateCutoff
			   AND l.borrower_id = @id
		
		   END
		   ELSE
		   BEGIN
				SELECT p.id, 
			   p.loan_id, 
			   b.first_name + ' ' + b.last_name name,
			   l.borrower_id,
			   'Php ' + CONVERT(nvarchar(50), p.amount) amount, 
			   CONVERT(VARCHAR(12), p.[date], 100) [date],
			   p.notes, 
			   p.amount realamount,
			   p.[status]
			   FROM dbo.Payables p, dbo.Loans l, dbo.Users b
			   WHERE p.status = 0 AND l.status = 1 AND b.status = 1
			   AND l.id = p.loan_id AND l.borrower_id = b.id
			   AND p.[date] BETWEEN GETDATE() AND @dateCutoff
			   AND l.borrower_id = @id
		   END
		   			


		END

END

