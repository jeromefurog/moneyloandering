using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LoanMac.Core.Model;

namespace LoanMac.Core.Service
{
    public class WithdrawalService
    {
        UserEntity appUsr = new UserEntity();

        public WithdrawalService()
        {
            appUsr = GlobalObjects.User;
        }

        private WithdrawalEntity SetData(DataRow oRow)
        {

            try
            {
                WithdrawalEntity ent = new WithdrawalEntity();
                ent.ID = Convert.ToInt32(oRow["id"]);                
                ent.Amount = Convert.ToDecimal(oRow["amount"]);
                ent.Userid = Convert.ToInt32(oRow["user_id"]);
                ent.Date = Convert.ToDateTime(oRow["date"]);                
                ent.Notes = oRow["notes"].ToString();                
                ent.Status = Convert.ToInt32(oRow["status"]);

                return ent;
            
            }
            catch (Exception ex) { throw ex; }           

        }

        public WithdrawalEntity GetOne(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetWithdrawal";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    WithdrawalEntity user = new WithdrawalEntity();
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

        public void Save(ActionType type, WithdrawalEntity ent, int remType = 0)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    int ret = 0;
                    int typ = (int)type;
                    string sql = "SaveWithdrawals";
                    string[] asParams;
                    DbType[] atParamTypes;
                    object[] aoValues;

                                        
                    asParams = new string[] {   "@actiontype",
	                                            "@id",
                                                "@userid",
                                                "@amount",
	                                            "@date",
	                                            "@notes",
                                                "@remType",
	                                            "@status",	                                            
	                                            "@createdby",
	                                            "@createddate",
	                                            "@updatedby",
	                                            "@updateddate"};                    

                    atParamTypes = new DbType[] {   
                                                    DbType.Int16,
                                                    DbType.Int32,  
                                                    DbType.Int32,  
                                                    DbType.Decimal,
                                                    DbType.Date,
                                                    DbType.String, 
                                                    DbType.Int16,
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.DateTime,
                                                    DbType.String, 
                                                    DbType.DateTime };

                    aoValues = new object[] {   
                                                typ,
                                                ent.ID,
                                                ent.Userid,
                                                ent.Amount,
                                                ent.Date, 
                                                ent.Notes,
                                                remType,
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
                        new object[] { "Withdrawals", id, appUsr.UserName },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataView GetAll(string query, int type)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    
                    db.Open();
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    string sql = "GetWithdrawals";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@query" },
                        new DbType[] { DbType.String },
                        new object[] { query },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    return Utility.FilterDataTable(FormalFormatTable(oTable), "type=" + type.ToString());

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable GetInvestors(int id)
        {
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

        
        public DataTable FormalFormatTable(DataTable dt)
        {
            try
            {
                foreach (DataRow row in dt.Rows)
                {


                    row["name"] = Utility.FormalFormat(Convert.ToString(row["name"]));

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
