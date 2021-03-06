
/****** Object:  StoredProcedure [dbo].[GetWithdrawals]    Script Date: 6/6/2014 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetWithdrawals] 
	-- Add the parameters for the stored procedure here
	@query NVARCHAR(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		
	
	SELECT 
	w.id,
	u.first_name + ' ' + u.last_name name,
	w.user_id,
	'Php ' + CONVERT(nvarchar(50), w.amount) amount, 
	CONVERT(VARCHAR(11),w.[date],101) [date],
	w.notes,
	w.[type],
	w.status
	FROM [Withdrawals] w, Users u
	WHERE w.status = 1 AND u.status = 1
	AND w.user_id = u.id
	AND (
			UPPER(u.first_name) LIKE '%' + UPPER(@query) + '%' OR
			UPPER(u.last_name) LIKE '%' + UPPER(@query) + '%' OR
			UPPER(w.notes) LIKE '%' + UPPER(@query) + '%'
		)	
	ORDER BY w.date DESC
	
	
	
	
END
