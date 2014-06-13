


-- Add expense/withdrawal type column
ALTER TABLE [Withdrawals]
ADD type BIT

-- set expense/withdrawal type column default value
update [Withdrawals]
set [type] = 0

-- TODO: -- set existing expense 
update [Withdrawals]
set [type] = 1
where id IN (1012,1013,1014,1015,1016,1017)

-- Run SQL 2 - ALTER PROCEDURE [dbo].[GetWithdrawals]

-- Run SQL 3 - ALTER PROCEDURE [dbo].[SaveWithdrawals] 

-- Run SQL 4 - CREATE PROCEDURE [dbo].[GetLoansByUser] 

-- Run SQL 5 - ALTER PROCEDURE [dbo].[GetCurrentPayable] 

-- Run SQL 6 - CREATE PROCEDURE [dbo].[GetAlerts] 

-- Run SQL 7 - CREATE PROCEDURE [dbo].[GetPassword] 

-- Run SQL 8 - ALTER PROCEDURE [dbo].[GetLoans] 

-- Run SQL 9 - ALTER PROCEDURE [dbo].[SaveLoan] 

-- Run SQL 10 - CREATE PROCEDURE [dbo].[GetApplyLoans]

-- Run SQL 11 - CREATE PROCEDURE [dbo].[GetApplyLoan] 

-- Run SQL 12 - CREATE PROCEDURE [dbo].[SaveApplyLoan] 

