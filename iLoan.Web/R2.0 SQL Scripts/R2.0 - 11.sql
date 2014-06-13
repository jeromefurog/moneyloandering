
/****** Object:  StoredProcedure [dbo].[GetLoansByUser]    Script Date: 6/8/2014 3:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetApplyLoan] 
	-- Add the parameters for the stored procedure here	
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
	l.id,
	CONVERT(varchar, l.amount, 1) amount,
	l.period,				
	CONVERT(VARCHAR(11),l.[date],101) [date],
	c.[desc] collateral,
	l.collateral_id,
	l.collateral_details,
	b.first_name + ' ' + b.last_name borrower,
	l.borrower_id,		
	l.notes		
	FROM dbo.Loans l, dbo.CollateralTypes c, dbo.Users b
	WHERE l.status = 0 AND c.status = 1 AND b.status = 1 
	AND l.collateral_id = c.id AND l.borrower_id = b.id 
	AND l.id = @id
	ORDER BY l.date DESC

	
	
	
	
END


