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

        public void Save(ActionType type, WithdrawalEntity ent)
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

        public DataView GetAll(string query)
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

                    return FormalFormatTable(oTable).DefaultView;

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

        public string FormalFormat(string inString)
        {
            string outString = string.Empty;
            string _ErrorMessage = string.Empty;
            try
            {
                // Formal Format is made for names and addresses to assure 
                // proper formatting and capitalization
                if (string.IsNullOrEmpty(inString))
                {
                    return string.Empty;
                }
                inString = inString.Trim();
                if (string.IsNullOrEmpty(inString))
                {
                    return string.Empty;
                }
                // see if this is a word or a series of words
                //if(inString.IndexOf(" ") > 0)
                //{
                // Break out each word in the string. 
                char[] charSep = { ' ' };
                string[] aWords = inString.Split(charSep);
                int i = 0;
                int CapAfterHyphen = 0;
                for (i = 0; i < aWords.Length; i++)
                {

                    string Word = aWords[i].Trim();
                    CapAfterHyphen = Word.IndexOf("-");
                    char[] chars = Word.ToCharArray();
                    if (chars.Length > 3)
                    {
                        if (Char.IsLower(chars[1]) && Char.IsUpper(chars[2]))
                        {
                            Word = Word.Substring(0, 1).ToUpper() + Word.Substring(1, 1).ToLower() + Word.Substring(2, 1).ToUpper() + Word.Substring(3).ToLower();
                        }
                        else
                        {
                            Word = Word.Substring(0, 1).ToUpper() + Word.Substring(1).ToLower();
                        }
                    }
                    if (CapAfterHyphen > 0)
                    {
                        Word = Word.Substring(0, CapAfterHyphen + 1) + Word.Substring(CapAfterHyphen + 1, 1).ToUpper() + Word.Substring(CapAfterHyphen + 2);
                    }
                    if (i > 0)
                    {
                        outString += " " + Word;
                    }
                    else
                    {
                        outString = Word;
                    }
                }
            }
            catch (Exception e)
            {
                outString = inString;
                _ErrorMessage = e.Message;
            }
            return outString;
        }

        public DataTable FormalFormatTable(DataTable dt)
        {
            try
            {
                foreach (DataRow row in dt.Rows)
                {


                    row["name"] = FormalFormat(Convert.ToString(row["name"]));

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
