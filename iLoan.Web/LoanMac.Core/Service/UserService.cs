﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LoanMac.Core.Model;
using System.Data.SqlClient;

namespace LoanMac.Core.Service
{
    public class UserService
    {
        UserEntity appUsr = new UserEntity();

        public UserService()
        {
            appUsr = GlobalObjects.User;
        }

        private UserEntity SetData(DataRow oRow) {

            try
            {
                UserEntity ent = new UserEntity();
                ent.ID = Convert.ToInt32(oRow["id"]);
                ent.UserName = oRow["user_name"].ToString();
                ent.Password = oRow["password"].ToString();
                ent.FirstName = Utility.FormalFormat(oRow["first_name"].ToString());
                ent.LastName = Utility.FormalFormat(oRow["last_name"].ToString());
                ent.PhoneNo = oRow["phone_no"].ToString();
                ent.Email = oRow["email"].ToString();
                ent.Notes = oRow["notes"].ToString();
                if (oRow["picture"] != DBNull.Value) { ent.Picture = (Byte[])oRow["picture"]; }
                ent.IsAdmin = Convert.ToBoolean(Convert.ToInt32(oRow["is_admin"]));
                ent.Status = Convert.ToInt32(oRow["status"]);

                return ent;
            
            }
            catch (Exception ex) { throw ex; }           

        }

        public string GetPassword(string email)
        {

            try
            {


                using (SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    string ret = string.Empty;

                    using (SqlCommand cmd = new SqlCommand("GetPassword", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parm2 = new SqlParameter("@email", SqlDbType.NVarChar);
                        parm2.Value = email;
                        parm2.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(parm2);


                        SqlParameter parm3 = new SqlParameter("@password", SqlDbType.NVarChar);
                        parm3.Direction = ParameterDirection.Output;
                        parm3.Size = 100;
                        cmd.Parameters.Add(parm3);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = cmd.Parameters["@password"].Value.ToString();


                        return ret;
                    }

                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public DataTable GetUsersForDropdown()
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "EXEC [GetUserForDropdown]";
                    oTable = db.Fetch(sql);                    

                    return oTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanDelete(int id) {

            try
            {
                                
                
                using(SqlConnection sqlConnection = new SqlConnection(GlobalObjects.CONNECTION_STRING))
                {
                    int ret = 0;
                    
                    using(SqlCommand cmd = new SqlCommand("CanDelete", sqlConnection))
                    {
                        cmd.CommandType=CommandType.StoredProcedure;

                        SqlParameter parm=new SqlParameter("@entity", SqlDbType.VarChar); 
                        parm.Value="USER";
                        parm.Direction =ParameterDirection.Input ; 
                        cmd.Parameters.Add(parm); 

                        SqlParameter parm2=new SqlParameter("@id",SqlDbType.Int); 
                        parm2.Value = id;
                        parm2.Direction=ParameterDirection.Input;
                        cmd.Parameters.Add(parm2); 


                        SqlParameter parm3 = new SqlParameter("@count",SqlDbType.Int);
                        parm3.Direction=ParameterDirection.Output; 
                        cmd.Parameters.Add(parm3); 

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();

                        ret = Convert.ToInt32(cmd.Parameters["@count"].Value); //This will 1 or 0

                        if (ret > 0)
                        {
                            return false;
                        }

                        return true;
                   }

                }

            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        public UserEntity GetOne(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetUser";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    
                    UserEntity user = new UserEntity();
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

        public void Save(ActionType type, UserEntity user)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    int ret = 0;
                    int hasPic = 0;
                    int typ = (int)type;
                    string sql = "SaveUser";
                    string[] asParams;
                    DbType[] atParamTypes;
                    object[] aoValues;

                    Byte[] dummyPic;
                    if (user.Picture != null)
                    {
                        hasPic = 1;
                        dummyPic = user.Picture;
                    }
                    else {
                        dummyPic = new byte[1000 * 1000 * 3];
                    }
                    
                    asParams = new string[] {   "@actiontype",
                                                "@haspic",
                                                "@id",
                                                "@username", 
                                                "@password", 
                                                "@firstname", 
                                                "@lastname", 
                                                "@email", 
                                                "@phoneno", 
                                                "@notes", 
                                                "@isadmin",
                                                "@picture",
                                                "@createdby", 
                                                "@createddate", 
                                                "@updatedby", 
                                                "@updateddate"};

                    atParamTypes = new DbType[] {   
                                                    DbType.Int16,
                                                    DbType.Int16,
                                                    DbType.Int32,
                                                    DbType.String, 
                                                    DbType.String, 
                                                    DbType.String, 
                                                    DbType.String, 
                                                    DbType.String, 
                                                    DbType.String, 
                                                    DbType.String, 
                                                    DbType.Int16,  
                                                    DbType.Binary,    
                                                    DbType.String, 
                                                    DbType.DateTime, 
                                                    DbType.String, 
                                                    DbType.DateTime };

                    aoValues = new object[] {   
                                                typ,
                                                hasPic,
                                                user.ID,
                                                user.UserName, 
                                                user.Password, 
                                                user.FirstName, 
                                                user.LastName, 
                                                user.Email, 
                                                user.PhoneNo, 
                                                user.Notes, 
                                                user.IsAdmin, 
                                                dummyPic, 
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
                        new object[] { "Users", id, appUsr.UserName },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void SetPassword(int id, string password)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "UpdatePassword";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@password", "@id", "@updatedby" },
                        new DbType[] { DbType.String, DbType.Int32, DbType.String },
                        new object[] { password, id, appUsr.UserName },
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
                    string sql = "GetUsers";
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

        public bool DoesUserExist(string userName, string firstname, string lastname)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "DoesUserExists";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@username", "@firstname", "@lastname" },
                        new DbType[] { DbType.String, DbType.String, DbType.String },
                        new object[] { userName, firstname, lastname },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    if (oTable.Rows.Count > 0) { return true; }

                    return false;
                }
            }
            catch (Exception ex) { throw ex; }

        }
        
        public UserEntity Authenticate(string systemID, string password)
        {
            try
            {

                UserEntity user = new UserEntity();
                int ret = 0;
                DataTable oTable = new DataTable();

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();

                    string sql = "AuthenticateUser";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@username", "@password" },
                        new DbType[] { DbType.String, DbType.String },
                        new object[] { systemID, password },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                    if (oTable.Rows.Count > 0)
                    {
                        DataRow oRow = oTable.Rows[0];
                        user = SetData(oRow);
                        
                    }
                }

                return user;
            }
            catch (Exception ex) { throw ex; }

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
