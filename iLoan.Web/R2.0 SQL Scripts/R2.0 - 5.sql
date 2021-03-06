
/****** Object:  StoredProcedure [dbo].[GetCurrentPayable]    Script Date: 6/7/2014 3:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCurrentPayable] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	
	DECLARE @dateCutoff datetime, @day INT
	
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
	   CONVERT(VARCHAR(10), p.[date], 101) [date], 
	   p.notes, 
	   p.amount realamount,
	   p.[status]
	   FROM dbo.Payables p, dbo.Loans l, dbo.Users b
	   WHERE p.status = 0 AND l.status = 1 AND b.status = 1
	   AND l.id = p.loan_id AND l.borrower_id = b.id
	   AND p.[date] BETWEEN DATEADD(d, -1,@dateCutoff) AND @dateCutoff
		
   END
   ELSE
   BEGIN
		SELECT p.id, 
	   p.loan_id, 
	   b.first_name + ' ' + b.last_name name,
	   l.borrower_id,
	   'Php ' + CONVERT(nvarchar(50), p.amount) amount, 
	   CONVERT(VARCHAR(10), p.[date], 101) [date], 
	   p.notes, 
	   p.amount realamount,
	   p.[status]
	   FROM dbo.Payables p, dbo.Loans l, dbo.Users b
	   WHERE p.status = 0 AND l.status = 1 AND b.status = 1
	   AND l.id = p.loan_id AND l.borrower_id = b.id
	   AND p.[date] BETWEEN GETDATE() AND @dateCutoff
   END

	
	--SELECT p.id, 
	--p.loan_id, 
	--b.first_name + ' ' + b.last_name name,
	--l.borrower_id,
	--'Php ' + CONVERT(nvarchar(50), p.amount) amount, 
	--CONVERT(VARCHAR(10), p.[date], 101) [date], 
	--p.notes, 
	--p.amount realamount,
	--p.[status]
	--FROM dbo.Payables p, dbo.Loans l, dbo.Users b
	--WHERE p.status = 0 AND l.status = 1 AND b.status = 1
	--AND l.id = p.loan_id AND l.borrower_id = b.id
	--AND p.[date] BETWEEN GETDATE() AND @dateCutoff

END
