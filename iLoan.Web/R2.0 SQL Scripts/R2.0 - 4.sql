/****** Object:  StoredProcedure [dbo].[GetLoans]    Script Date: 6/7/2014 1:45:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLoansByUser] 
	-- Add the parameters for the stored procedure here
	@query NVARCHAR(max),
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
	t.[desc] term,
	l.term_id,
	CONVERT(VARCHAR(11),l.[date],101) [date],
	CAST(l.interest AS NVARCHAR(50)) + ' %' interest,
	c.[desc] collateral,
	l.collateral_id,
	l.collateral_details,
	cm.first_name + ' ' + cm.last_name comaker,
	l.comaker_id,
	b.first_name + ' ' + b.last_name borrower,
	l.borrower_id,
	i.first_name + ' ' + i.last_name investor,
	l.investor_id,
	CONVERT(varchar, ISNULL(l.penalty, 0), 1) penalty,
	ISNULL(l.penalty_details, '') penalty_details,
	l.notes,
	CASE WHEN (SELECT COUNT(*) FROM Payables pp WHERE pp.status = 0 AND pp.loan_id = l.id) > 0 THEN 'No' ELSE 'Yes' END fully_paid,
	(SELECT COUNT(*) FROM Payables ppp WHERE ppp.status IN (0,1) AND ppp.loan_id = l.id) total_payments,
	(SELECT COUNT(*) FROM Payables ppp WHERE ppp.status IN (1) AND ppp.loan_id = l.id) total_paid,
	(1 - (SELECT CAST(COUNT(*) AS float) FROM Payables ppp WHERE ppp.status = 0 AND ppp.loan_id = l.id) / (SELECT CAST(COUNT(*) AS float) FROM Payables ppp WHERE ppp.status IN (0,1) AND ppp.loan_id = l.id)) * 100 Progress
	FROM dbo.Loans l, dbo.LoanTerms t, dbo.CollateralTypes c, dbo.Users cm, dbo.Users b, dbo.Users i
	WHERE l.status = 1 AND t.status = 1 AND c.status = 1 AND cm.status = 1 AND b.status = 1 AND i.status = 1
	AND l.term_id = t.id AND l.collateral_id = c.id AND l.comaker_id = cm.id AND l.borrower_id = b.id AND l.investor_id = i.id
	AND l.borrower_id = @id
	ORDER BY l.date DESC
	
	
	
END


