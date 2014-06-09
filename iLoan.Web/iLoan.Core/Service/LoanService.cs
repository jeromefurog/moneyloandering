using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iLoan.Core.Model;
using System.Data;

namespace iLoan.Core.Service
{
    public class LoanService
    {
        AppUserEntity appUsr = new AppUserEntity();

        public LoanService() 
        {
            appUsr = GlobalObjects.AppUser;
        
        }

        public void Save(ActionType type, LoanEntity ent)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    int ret = 0;
                    string sql = "";
                    string[] asParams;
                    DbType[] atParamTypes;
                    object[] aoValues;

                    if (type == ActionType.Create)
                    {
                        sql = @"SaveLoan";

                        asParams = new string[] {   "@amount", 
                                                    "@period", 
                                                    "@termid", 
                                                    "@date", 
                                                    "@interest", 
                                                    "@borrowerid", 
                                                    "@notes", 
                                                    "@collateralid", 
                                                    "@collateraldetails", 
                                                    "@comakerid",
                                                    "@status", 
                                                    "@createdby", 
                                                    "@createddate", 
                                                    "@updatedby", 
                                                    "@updateddate"};
                        atParamTypes = new DbType[] {   DbType.Decimal, 
                                                        DbType.Int32, 
                                                        DbType.Int32, 
                                                        DbType.DateTime, 
                                                        DbType.Decimal, 
                                                        DbType.Int32, 
                                                        DbType.String, 
                                                        DbType.Int32, 
                                                        DbType.String, 
                                                        DbType.Int32, 
                                                        DbType.Int32, 
                                                        DbType.String,
                                                        DbType.DateTime, 
                                                        DbType.String, 
                                                        DbType.DateTime };
                        aoValues = new object[] {   ent.Amount, 
                                                    ent.Period, 
                                                    ent.Termid, 
                                                    ent.Loandate, 
                                                    ent.Interest, 
                                                    ent.Borrowerid, 
                                                    ent.Notes, 
                                                    ent.CollateralId, 
                                                    ent.CollateralDetails, 
                                                    ent.Comakerid,
                                                    ent.Status,
                                                    appUsr.UserName, 
                                                    DateTime.Now, 
                                                    appUsr.UserName, 
                                                    DateTime.Now, 
                                                     };

                    }
                    else
                    {
                        sql = @"UpdateLoan";

                        asParams = new string[] {  "@notes", 
                                                    "@collateralid", 
                                                    "@collateraldetails", 
                                                    "@comakerid",
                                                    "@updatedby", 
                                                    "@updateddate",
                                                    "@id"};
                        atParamTypes = new DbType[] {   DbType.String, 
                                                        DbType.Int32,
                                                        DbType.String,
                                                        DbType.Int32,
                                                        DbType.String, 
                                                        DbType.DateTime,
                                                        DbType.Int32};
                        aoValues = new object[] { ent.Notes, ent.CollateralId, ent.CollateralDetails, ent.Comakerid, appUsr.UserName, DateTime.Now, ent.ID };
                    }

                    db.ExecuteCommandNonQuery(sql, asParams, atParamTypes, aoValues, out ret, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteUser(int id)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "DeleteFromTable";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@tablename", "@id" },
                        new DbType[] { DbType.String, DbType.Int32 },
                        new object[] { "Loans", id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataView GetAll()
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "EXEC [GetAllLoan]";
                    oTable = db.Fetch(sql);

                    return oTable.DefaultView;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LoanEntity GetSpecific(int id)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetLoan";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    DataRow oRow = oTable.Rows[0];

                    LoanEntity ent = new LoanEntity();
                    ent.ID = Convert.ToInt32(oRow["id"]);
                    ent.Amount = Convert.ToDecimal(oRow["amount"]);
                    ent.Borrowerid = Convert.ToInt32(oRow["borrower_id"]);
                    ent.CollateralDetails = oRow["collateral_details"].ToString();
                    ent.CollateralId = Convert.ToInt32(oRow["collateral_id"]);
                    ent.Comakerid = Convert.ToInt32(oRow["comaker_id"]);
                    ent.Interest = Convert.ToDecimal(oRow["interest"]);
                    ent.Loandate = Convert.ToDateTime(oRow["date"]);
                    ent.Notes = oRow["notes"].ToString();
                    ent.Period = Convert.ToInt32(oRow["period"]); ;
                    ent.Termid = Convert.ToInt32(oRow["term_id"]);
                    ent.TotalPayableAmount = Convert.ToDecimal(oRow["total_payable_amount"]);
                    

                    return ent;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLoanTerms()
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "SELECT id, [desc] name FROM dbo.LoanTerms WHERE status = 1";
                    oTable = db.Fetch(sql);

                    return oTable;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable GetCollateral()
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "SELECT id, [desc] name FROM dbo.CollateralTypes WHERE status = 1";
                    oTable = db.Fetch(sql);

                    return oTable;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable Search(Dictionary<string, string> query)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    StringBuilder pars = new StringBuilder(string.Empty);

                    foreach (KeyValuePair<string, string> entry in query)
                    {
                        if (entry.Key == "form_id") { pars.AppendFormat(" AND l.id = {0} ", entry.Value.ToUpper()); }
                        if (entry.Key == "borrower") { pars.AppendFormat(" AND (UPPER(b.first_name) LIKE '%{0}%' OR UPPER(b.last_name) LIKE '%{0}%') ", entry.Value.ToUpper()); }
                        if (entry.Key == "comaker") { pars.AppendFormat(" AND (UPPER(c.first_name) LIKE '%{0}%' OR UPPER(c.last_name) LIKE '%{0}%') ", entry.Value.ToUpper()); }
                        if (entry.Key == "loan_date") { pars.AppendFormat(" AND l.[date] = '{0}' ", entry.Value.ToUpper()); }
                        if (entry.Key == "pay_status") { pars.AppendFormat(" AND dbo.fnIsFullyPaid(l.id) = {0} ", entry.Value.ToUpper()); }

                    }

                    db.Open();
                    string sql;
                    string sqlparams = pars.ToString();
                    sql = @"SELECT l.id, 
	                        'Php ' + CONVERT(nvarchar(50), l.amount) amount, 
	                        l.term_id, 
	                        t.[desc] term,
	                        CONVERT(VARCHAR(11),l.[date],106) [date],
	                        CONVERT(nvarchar(50), l.interest) + '%' interest,
	                        l.borrower_id,
	                        'Php ' + CONVERT(nvarchar(50), dbo.fnTotalPayableAmount(l.amount,l.interest,l.period) ) total_payable_amount,
	                        'Php ' + CONVERT(nvarchar(50), CONVERT(decimal(38,2),dbo.fnTotalPayableAmount(l.amount,l.interest,l.period) / l.period) ) monthly_payable_amount,
	                        b.first_name + ' ' + b.last_name borrower,
	                        c.first_name + ' ' + c.last_name comaker,
	                        l.notes,
	                        l.period,
	                        (CASE WHEN (SELECT SUM(p.amount) FROM dbo.Payables p WHERE p.status = 1 AND p.loan_id = l.id) IS NULL THEN 'Php 0' ELSE (SELECT 'Php ' + CONVERT(nvarchar(50), SUM(p.amount)) FROM dbo.Payables p WHERE p.status = 1 AND p.loan_id = l.id) END) paid_amount,
	                        CASE WHEN dbo.fnIsFullyPaid(l.id) = 1 THEN 'FULLY PAID' ELSE 'NOT FULLY PAID' END [status] 
	                        FROM dbo.Loans l, dbo.LoanTerms t, dbo.Borrowers b, dbo.Borrowers c 
	                        WHERE l.status = 1 AND t.status = 1 AND b.status = 1 AND c.status = 1
	                        AND l.term_id = t.id AND l.borrower_id = b.id AND c.id = l.comaker_id " + sqlparams;
                    DataTable oTable = db.Fetch(sql);

                    return oTable;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
