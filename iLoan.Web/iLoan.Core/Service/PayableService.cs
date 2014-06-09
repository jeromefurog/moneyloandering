using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iLoan.Core.Model;
using System.Data;

namespace iLoan.Core.Service
{
    public class PayableService
    {
        AppUserEntity appUsr = new AppUserEntity();

        public PayableService() 
        {
            appUsr = GlobalObjects.AppUser;
        
        }

        
        public DataTable GetSpecific(int id)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetPayable";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    

                    return oTable;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCurrentPayables()
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "EXEC GetCurrentCutoffPayable";
                    oTable = db.Fetch(sql);

                    return oTable;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPreviousPayables()
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "EXEC GetPreviousCutoffPayable";
                    oTable = db.Fetch(sql);

                    return oTable;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetNextPayables()
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "EXEC GetNextCutoffPayable";
                    oTable = db.Fetch(sql);

                    return oTable;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DoesCutoffExist(int id, int loan_id, DateTime loandate)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "SELECT * FROM dbo.Payables WHERE status <> 2 AND loan_id = @loanid AND id <> @id AND [date] = @date";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@loanid", "@id", "@date" },
                        new DbType[] { DbType.Int32, DbType.Int32, DbType.Date },
                        new object[] { loan_id, id, loandate },
                        out ret, ref oTable, CommandTypeEnum.Text);

                    if (oTable.Rows.Count > 0) { return true; }

                    return false;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        public PayableEntity GetSpecificPayment(int id)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetPayment";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    DataRow oRow = oTable.Rows[0];

                    PayableEntity ent = new PayableEntity();
                    ent.ID = Convert.ToInt32(oRow["id"]);
                    ent.LoanId = Convert.ToInt32(oRow["loan_id"]);
                    ent.Amount = Convert.ToDecimal(oRow["amount"]);
                    ent.PayDate = Convert.ToDateTime(oRow["date"]);
                    ent.Notes = oRow["notes"].ToString();
                    ent.Status = Convert.ToInt32(oRow["status"]);

                    return ent;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(PayableEntity ent)
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

                    
                    sql = @"UpdatePayment";

                    asParams = new string[] {  "@amount", 
                                                "@notes", 
                                                "@status",                                                     
                                                "@updatedby", 
                                                "@updateddate",
                                                "@id"};
                    atParamTypes = new DbType[] {   DbType.Decimal, 
                                                    DbType.String,
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.DateTime,
                                                    DbType.Int32};
                    aoValues = new object[] { ent.Amount, ent.Notes, ent.Status, appUsr.UserName, DateTime.Now, ent.ID };
                    

                    db.ExecuteCommandNonQuery(sql, asParams, atParamTypes, aoValues, out ret, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
    }
}
