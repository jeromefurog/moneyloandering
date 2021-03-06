/****** Object:  StoredProcedure [dbo].[Dashboard_TotalCashOnHand]    Script Date: 6/7/2014 6:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPassword] 
	-- Add the parameters for the stored procedure here
	@email nvarchar(max),
	@password nvarchar(max) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		
	SELECT @password = u.password
		FROM Users u 
		WHERE u.status = 1
		AND LOWER(LTRIM(RTRIM(u.email))) = LOWER(LTRIM(RTRIM(@email)))
	
			
	SET @password = CASE WHEN @password IS NULL OR @password = '' THEN '' ELSE @password END
	
	
	
	
	
END



