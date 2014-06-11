using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LoanMac.Core.Model;

namespace LoanMac.Core.Service
{
    public class LoanService
    {
        UserEntity appUsr = new UserEntity();

        public LoanService()
        {
            appUsr = GlobalObjects.User;
        }

        private LoanEntity SetData(DataRow oRow)
        {

            try
            {
                LoanEntity ent = new LoanEntity();
                ent.ID = Convert.ToInt32(oRow["id"]);                
                ent.Amount = Convert.ToDecimal(oRow["amount"]);
                ent.Period = Convert.ToInt32(oRow["period"]);
                ent.TermId = Convert.ToInt32(oRow["term_id"]);
                ent.Date = Convert.ToDateTime(oRow["date"]);
                ent.Interest = Convert.ToDecimal(oRow["interest"]);
                ent.CollateralId = Convert.ToInt32(oRow["collateral_id"]);
                ent.CollateralDetails = oRow["collateral_details"].ToString();
                ent.ComakerId = Convert.ToInt32(oRow["comaker_id"]);
                ent.BorrowerId = Convert.ToInt32(oRow["borrower_id"]);
                ent.InvestorId = Convert.ToInt32(oRow["investor_id"]);
                ent.Notes = oRow["notes"].ToString();
                ent.Penalty = Convert.ToDecimal(oRow["penalty"]);
                ent.PenaltyDetails = oRow["penalty_details"].ToString();
                ent.Status = Convert.ToInt32(oRow["status"]);

                return ent;
            
            }
            catch (Exception ex) { throw ex; }           

        }

        private LoanEntity SetApplyLoanData(DataRow oRow)
        {

            try
            {
                LoanEntity ent = new LoanEntity();
                ent.ID = Convert.ToInt32(oRow["id"]);
                ent.Amount = Convert.ToDecimal(oRow["amount"]);
                ent.Period = Convert.ToInt32(oRow["period"]);              
                
                ent.CollateralId = Convert.ToInt32(oRow["collateral_id"]);
                ent.CollateralDetails = oRow["collateral_details"].ToString();
                
                ent.BorrowerId = Convert.ToInt32(oRow["borrower_id"]);
                
                ent.Notes = oRow["notes"].ToString();               
                

                return ent;

            }
            catch (Exception ex) { throw ex; }

        }

        public DataTable GetBorrowers(int id)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetBorrowers";
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

        public DataTable GetLoanTerms()
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "EXEC GetLoanTerms";
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
                    sql = "EXEC GetCollateral";
                    oTable = db.Fetch(sql);

                    return oTable;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable GetInvestors(int id) {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetInvestorForDropdown";
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

        public LoanEntity GetOne(int userId)
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
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    LoanEntity user = new LoanEntity();
                    if (oTable.Rows.Count > 0)
                    {
                        DataRow oRow = oTable.Rows[0];
                        user = SetData(oRow);

                    }

                    return user;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoanEntity GetApplyLoan(int loanid)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetApplyLoan";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { loanid },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    LoanEntity user = new LoanEntity();
                    if (oTable.Rows.Count > 0)
                    {
                        DataRow oRow = oTable.Rows[0];
                        user = SetApplyLoanData(oRow);

                    }

                    return user;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(ActionType type, LoanEntity ent)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    int ret = 0;
                    int typ = (int)type;
                    string sql = "SaveLoan";
                    string[] asParams;
                    DbType[] atParamTypes;
                    object[] aoValues;

                                        
                    asParams = new string[] {   "@actiontype",
	                                            "@id",
	                                            "@amount",
	                                            "@period",
	                                            "@termid",
	                                            "@date",
	                                            "@interest",
	                                            "@collateralid",
	                                            "@collateraldetails",
	                                            "@comakerid",   
	                                            "@investorid",     
	                                            "@borrowerid",
	                                            "@notes",
                                                "@penalty",
                                                "@penaltydetails",
	                                            "@status",
	                                            "@createdby",
	                                            "@createddate",
	                                            "@updatedby",
	                                            "@updateddate"};                    

                    atParamTypes = new DbType[] {   
                                                    DbType.Int16,
                                                    DbType.Int32,                                                    
                                                    DbType.Decimal,
                                                    DbType.Int32, 
                                                    DbType.Int32, 
                                                    DbType.Date,                                                      
                                                    DbType.Decimal, 
                                                    DbType.Int32, 
                                                    DbType.String,
                                                    DbType.Int32,
                                                    DbType.Int32,
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.Decimal,
                                                    DbType.String, 
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.DateTime,
                                                    DbType.String, 
                                                    DbType.DateTime };

                    aoValues = new object[] {   
                                                typ,
                                                ent.ID,
                                                ent.Amount, 
                                                ent.Period, 
                                                ent.TermId, 
                                                ent.Date, 
                                                ent.Interest, 
                                                ent.CollateralId, 
                                                ent.CollateralDetails, 
                                                ent.ComakerId, 
                                                ent.InvestorId,
                                                ent.BorrowerId,
                                                ent.Notes,    
                                                ent.Penalty,
                                                ent.PenaltyDetails,
                                                ent.Status,   
                                                appUsr.UserName, 
                                                DateTime.Now, 
                                                appUsr.UserName, 
                                                DateTime.Now
                                            };                    

                    db.ExecuteCommandNonQuery(sql, asParams, atParamTypes, aoValues, out ret, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SaveApplyLoan(ActionType type, LoanEntity ent)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    int ret = 0;
                    int typ = (int)type;
                    string sql = "SaveApplyLoan";
                    string[] asParams;
                    DbType[] atParamTypes;
                    object[] aoValues;


                    asParams = new string[] {   "@actiontype",
	                                            "@id",
	                                            "@amount",
	                                            "@period",
	                                            "@termid",
	                                            "@date",
	                                            "@interest",
	                                            "@collateralid",
	                                            "@collateraldetails",
	                                            "@comakerid",   
	                                            "@investorid",     
	                                            "@borrowerid",
	                                            "@notes",
                                                "@penalty",
                                                "@penaltydetails",
	                                            "@status",
	                                            "@createdby",
	                                            "@createddate",
	                                            "@updatedby",
	                                            "@updateddate"};

                    atParamTypes = new DbType[] {   
                                                    DbType.Int16,
                                                    DbType.Int32,                                                    
                                                    DbType.Decimal,
                                                    DbType.Int32, 
                                                    DbType.Int32, 
                                                    DbType.Date,                                                      
                                                    DbType.Decimal, 
                                                    DbType.Int32, 
                                                    DbType.String,
                                                    DbType.Int32,
                                                    DbType.Int32,
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.Decimal,
                                                    DbType.String, 
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.DateTime,
                                                    DbType.String, 
                                                    DbType.DateTime };

                    aoValues = new object[] {   
                                                typ,
                                                ent.ID,
                                                ent.Amount, 
                                                ent.Period, 
                                                ent.TermId, 
                                                ent.Date, 
                                                ent.Interest, 
                                                ent.CollateralId, 
                                                ent.CollateralDetails, 
                                                ent.ComakerId, 
                                                ent.InvestorId,
                                                ent.BorrowerId,
                                                ent.Notes,    
                                                ent.Penalty,
                                                ent.PenaltyDetails,
                                                ent.Status,   
                                                appUsr.UserName, 
                                                DateTime.Now, 
                                                appUsr.UserName, 
                                                DateTime.Now
                                            };

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
                        new string[] { "@tablename", "@id", "@updatedby" },
                        new DbType[] { DbType.String, DbType.Int32, DbType.String },
                        new object[] { "Loans", id, appUsr.UserName },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataView GetAll(string query)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    
                    db.Open();
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    string sql = "GetLoans";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@query" },
                        new DbType[] { DbType.String },
                        new object[] { query },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    return FormalFormatTable(oTable).DefaultView;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataView GetAllByUser(int id, string query)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    string sql = "GetLoansByUser";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@query", "@id" },
                        new DbType[] { DbType.String, DbType.Int32 },
                        new object[] { query, id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    return FormalFormatTable(oTable).DefaultView;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataView GetApplyLoans(int id, string query)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    string sql = "GetApplyLoans";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@query", "@id" },
                        new DbType[] { DbType.String, DbType.Int32 },
                        new object[] { query, id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    return FormalFormatTable2(oTable).DefaultView;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
        public DataTable FormalFormatTable(DataTable dt)
        {
            try
            {
                foreach (DataRow row in dt.Rows)
                {


                    row["comaker"] = Utility.FormalFormat(Convert.ToString(row["comaker"]));
                    row["borrower"] = Utility.FormalFormat(Convert.ToString(row["borrower"]));
                    row["investor"] = Utility.FormalFormat(Convert.ToString(row["investor"]));
                    row.EndEdit();
                    dt.AcceptChanges();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable FormalFormatTable2(DataTable dt)
        {
            try
            {
                foreach (DataRow row in dt.Rows)
                {


                    row["borrower"] = Utility.FormalFormat(Convert.ToString(row["borrower"]));
                    row.EndEdit();
                    dt.AcceptChanges();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

                
        
    }
}
