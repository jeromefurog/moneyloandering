using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LoanMac.Core.Model;
using System.Data.SqlClient;

namespace LoanMac.Core.Service
{
    public class DashboardService
    {
        UserEntity appUsr = new UserEntity();

        public DashboardService()
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

        public string TotalInvestments(int id)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("Dashboard_TotalInvestments", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        SqlParameter parm2 = new SqlParameter("@id", SqlDbType.Int);
                        parm2.Value = id;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@amount", SqlDbType.VarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@amount"].Value.ToString(); 

                        
                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string TotalWithdrawals(int id)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("Dashboard_TotalWithdrawals", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parm2 = new SqlParameter("@id", SqlDbType.Int);
                        parm2.Value = id;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@amount", SqlDbType.VarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@amount"].Value.ToString();


                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string TotalEarnings(int id)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("Dashboard_TotalEarnings", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parm2 = new SqlParameter("@id", SqlDbType.Int);
                        parm2.Value = id;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@amount", SqlDbType.VarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@amount"].Value.ToString();


                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string TotalCashOnHand(int id)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("Dashboard_TotalCashOnHand", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parm2 = new SqlParameter("@id", SqlDbType.Int);
                        parm2.Value = id;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@amount", SqlDbType.VarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@amount"].Value.ToString();


                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string TotalLoanedAmount(int id)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("Dashboard_TotalLoanedAmount", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parm2 = new SqlParameter("@id", SqlDbType.Int);
                        parm2.Value = id;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@amount", SqlDbType.VarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@amount"].Value.ToString();


                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string TotalCollectableAmount(int id)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("Dashboard_TotalCollectableAmount", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parm2 = new SqlParameter("@id", SqlDbType.Int);
                        parm2.Value = id;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@amount", SqlDbType.VarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@amount"].Value.ToString();


                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }


        
        public DataTable GetInvestments(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "Dashboard_GetInvestments";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    
                    return oTable;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetWithdrawals(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "Dashboard_GetWithdrawals";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    return oTable;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLoanedForUser(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "Dashboard_GetLoanedForUser";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

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
