using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iLoan.Core.Model;

namespace iLoan.Core.Service
{
    public class UserService
    {
        AppUserEntity appUsr = new AppUserEntity();

        public UserService()
        {
            appUsr = GlobalObjects.AppUser;
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
                    sql = "EXEC [GetAllUser]";
                    oTable = db.Fetch(sql);

                    return Utility.FilterDataTable(oTable, " id = " + GlobalObjects.AppUser.UserID.ToString());
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
                        new string[] { "@tablename","@id" },
                        new DbType[] { DbType.String, DbType.Int32},
                        new object[] { "AppUsers" , id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                                        
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Save(ActionType type, AppUserEntity user)
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
                        sql = @"INSERT INTO [AppUsers] (
                            user_name,
                            password,
                            first_name,
                            last_name,
                            email,
                            role_id,
                            phone_no,                            
                            created_by,
                            created_date,
                            updated_by,
                            updated_date,                            
                            status) 
                        VALUES (
                            @userName,
                            @password,
                            @firstName,
                            @lastName,
                            @email,
                            @userRoleID,
                            @phoneNo,                            
                            @createdby,
                            @createddate,
                            @updatedby,
                            @updateddate,
                            @status)";

                        asParams = new string[] { "@userName", "@password", "@firstName", "@lastName", "@email", "@userRoleID", "@phoneNo", "@createdby", "@createddate", "@updatedby", "@updateddate", "@status" };
                        atParamTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.DateTime, DbType.Int32 };
                        aoValues = new object[] { user.UserName, user.Password, user.FirstName, user.LastName, user.Email, Convert.ToInt32(user.Role), user.PhoneNo, appUsr.UserName, DateTime.Now, appUsr.UserName, DateTime.Now, user.Status };

                    }
                    else
                    {
                        sql = @"UPDATE [AppUsers] SET
                            first_name = @firstName,
                            last_name = @lastName,
                            email = @email,
                            role_id = @userRoleID,
                            phone_no = @phoneNo,
                            updated_by = @updatedBy,
                            updated_date = @updatedDate,                            
                            status = @status
                        WHERE id = @userId";

                        asParams = new string[] { "@firstName", "@lastName", "@email", "@userRoleID", "@phoneNo", "@updatedBy", "@updatedDate", "@status", "@userId" };
                        atParamTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.String, DbType.String, DbType.DateTime, DbType.Int32, DbType.Int32 };
                        aoValues = new object[] { user.FirstName, user.LastName, user.Email, Convert.ToInt32(user.Role), user.PhoneNo, appUsr.UserName, DateTime.Now, user.Status, user.UserID };
                    }

                    db.ExecuteCommandNonQuery(sql, asParams, atParamTypes, aoValues, out ret, CommandTypeEnum.Text);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdatePassword(AppUserEntity user)
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

                    
                        sql = @"UPDATE [AppUsers] SET
                            password = @password
                        WHERE id = @userId";

                        asParams = new string[] { "@password", "@userId" };
                        atParamTypes = new DbType[] { DbType.String, DbType.Int32 };
                        aoValues = new object[] { user.Password, user.UserID };
                    
                    db.ExecuteCommandNonQuery(sql, asParams, atParamTypes, aoValues, out ret, CommandTypeEnum.Text);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AppUserEntity GetSpecificUser(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetAppUser";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    DataRow oRow = oTable.Rows[0];

                    AppUserEntity user = new AppUserEntity();
                    user.UserID = Convert.ToInt32(oRow["id"]);
                    user.Password = oRow["password"].ToString();
                    user.UserName = oRow["user_name"].ToString();
                    user.FirstName = oRow["first_name"].ToString();
                    user.LastName = oRow["last_name"].ToString();
                    user.Email = oRow["email"].ToString();
                    user.PhoneNo = oRow["phone_no"].ToString();
                    user.Status = Convert.ToInt32(oRow["status"]);
                    user.Role = GlobalObjects.SetRole(Convert.ToInt32(oRow["role_id"].ToString()));

                    return user;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetRoles()
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();

                    return db.Fetch("EXEC GetRoles");

                }
            }
            catch (Exception ex) { throw ex; }


        }

        public static bool DoesUserExist(string userName)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "SELECT * FROM AppUsers WHERE status IN (0,1) AND UPPER(user_name) = UPPER(@userName)";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@userName" },
                        new DbType[] { DbType.String },
                        new object[] { userName },
                        out ret, ref oTable, CommandTypeEnum.Text);

                    if (oTable.Rows.Count > 0) { return true; }

                    return false;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        public static AppUserEntity GetAppUser(int userId)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetAppUser";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { userId },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    DataRow oRow = oTable.Rows[0];

                    AppUserEntity user = new AppUserEntity();
                    user.UserID = Convert.ToInt32(oRow["id"]);
                    user.UserName = oRow["user_name"].ToString();
                    user.FirstName = oRow["first_name"].ToString();
                    user.LastName = oRow["last_name"].ToString();
                    user.Email = oRow["email"].ToString();
                    user.Role = GlobalObjects.SetRole(Convert.ToInt32(oRow["role_id"].ToString()));

                    return user;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AppUserEntity Authenticate(string systemID, string password)
        {
            try
            {

                AppUserEntity user = new AppUserEntity();
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
                        user.UserID = Convert.ToInt32(oRow["id"]);
                        user.FirstName = oRow["first_name"].ToString();
                        user.LastName = oRow["last_name"].ToString();
                        user.UserName = oRow["user_name"].ToString();
                        user.Email = oRow["email"].ToString();
                        user.Role = GlobalObjects.SetRole(Convert.ToInt32(oRow["role_id"]));

                    }
                }

                return user;
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
