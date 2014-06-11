using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LoanMac.Core.Model;
using System.Data.SqlClient;

namespace LoanMac.Core.Service
{
    public class InvestorService
    {
        UserEntity appUsr = new UserEntity();

        public InvestorService()
        {
            appUsr = GlobalObjects.User;
        }

        private InvestorEntity SetData(DataRow oRow)
        {

            try
            {
                InvestorEntity ent = new InvestorEntity();
                ent.ID = Convert.ToInt32(oRow["id"]);
                ent.UserId = Convert.ToInt32(oRow["user_id"]);
                ent.Amount = Convert.ToDecimal(oRow["amount"]);
                ent.Notes = oRow["notes"].ToString();                
                ent.Status = Convert.ToInt32(oRow["status"]);

                return ent;
            
            }
            catch (Exception ex) { throw ex; }           

        }

        
        public InvestorEntity GetOne(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetInvestment";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    InvestorEntity user = new InvestorEntity();
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

        public void Save(ActionType type, InvestorEntity ent)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    int ret = 0;
                    int typ = (int)type;
                    string sql = "SaveInvestment";
                    string[] asParams;
                    DbType[] atParamTypes;
                    object[] aoValues;

                                        
                    asParams = new string[] {   "@actiontype",
                                                "@id",
                                                "@userid", 
                                                "@amount",                                                 
                                                "@notes",                                                 
                                                "@createdby", 
                                                "@createddate", 
                                                "@updatedby", 
                                                "@updateddate"};

                    atParamTypes = new DbType[] {   
                                                    DbType.Int16,
                                                    DbType.Int32,
                                                    DbType.Int32,
                                                    DbType.Decimal, 
                                                    DbType.String,                                                      
                                                    DbType.String, 
                                                    DbType.DateTime, 
                                                    DbType.String, 
                                                    DbType.DateTime };

                    aoValues = new object[] {   
                                                typ,
                                                ent.ID,
                                                ent.UserId, 
                                                ent.Amount, 
                                                ent.Notes,                                                 
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
                        new object[] { "Investors", id, appUsr.UserName },
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
                    string sql = "GetInvestors";
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
