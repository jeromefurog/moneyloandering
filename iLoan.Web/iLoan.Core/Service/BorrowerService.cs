using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iLoan.Core.Model;
using System.Data;

namespace iLoan.Core.Service
{
    public class BorrowerService
    {
        AppUserEntity appUsr = new AppUserEntity();
        
        public BorrowerService() 
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
                    sql = "EXEC [GetAllBorrower]";
                    oTable = db.Fetch(sql);

                    return oTable.DefaultView;
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
                        if (entry.Key == "status") { if (entry.Value == "-1") { pars.Append(" status IN (0,1) "); } else { pars.AppendFormat(" status = {0} ", entry.Value); } }
                        if (entry.Key == "first_name") { pars.AppendFormat(" AND UPPER(first_name) LIKE '%{0}%' ", entry.Value.ToUpper()); }
                        if (entry.Key == "last_name") { pars.AppendFormat(" AND UPPER(last_name) LIKE '%{0}%' ", entry.Value.ToUpper()); }
                        
                    }

                    db.Open();
                    string sql;
                    string sqlparams = pars.ToString();
                    sql = @"SELECT id, first_name, last_name, CONVERT(VARCHAR(10), birth_day, 101) birth_day, home_address, home_no, email, company, company_address, company_no, CASE WHEN status = 1 THEN 'Active' ELSE 'In Active' END 'status' 
	                        FROM dbo.Borrowers 
	                        WHERE " + sqlparams;
                    DataTable oTable = db.Fetch(sql);

                    return oTable;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public BorrowerEntity GetSpecific(int id)
        {
            try
            {

                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "GetBorrower";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);
                    DataRow oRow = oTable.Rows[0];

                    BorrowerEntity ent = new BorrowerEntity();
                    ent.ID = Convert.ToInt32(oRow["id"]);
                    ent.FirstName = oRow["first_name"].ToString();
                    ent.LastName = oRow["last_name"].ToString();
                    ent.BirthDay = Convert.ToDateTime(oRow["birth_day"]);
                    ent.HomeAddress = oRow["home_address"].ToString();
                    ent.HomePhoneNo = oRow["home_no"].ToString();
                    ent.Email = oRow["email"].ToString();
                    ent.Company = oRow["company"].ToString();
                    ent.CompanyAddress = oRow["company_address"].ToString();
                    ent.CompanyPhoneNo = oRow["company_no"].ToString();
                    ent.Status = Convert.ToInt32(oRow["status"]);

                    if (oRow["picture"] != DBNull.Value) { ent.Picture = (Byte[])oRow["picture"]; }
                    
                    

                    return ent;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(ActionType type, BorrowerEntity ent)
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

                        if (ent.Picture == null)
                        {

                            sql = @"INSERT INTO [Borrowers] (                            
                            first_name,
                            last_name,
                            birth_day,
                            email,
                            home_address,
                            home_no,
                            company,
                            company_address,
                            company_no,                            
                            created_by,
                            created_date,
                            updated_by,
                            updated_date,                            
                            status) 
                        VALUES (
                            @firstname,
                            @lastname,
                            @birthday,
                            @email,
                            @homeaddress,
                            @homeno,
                            @company,
                            @companyaddress,
                            @companyno,                            
                            @createdby,
                            @createddate,
                            @updatedby,
                            @updateddate,
                            @status)";

                            asParams = new string[] { "@firstname", "@lastname", "@birthday", "@email", "@homeaddress", "@homeno", "@company", "@companyaddress", "@companyno", "@createdby", "@createddate", "@updatedby", "@updateddate", "@status" };
                            atParamTypes = new DbType[] { DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.DateTime, DbType.Int32 };
                            aoValues = new object[] { ent.FirstName, ent.LastName, ent.BirthDay, ent.Email, ent.HomeAddress, ent.HomePhoneNo, ent.Company, ent.CompanyAddress, ent.CompanyPhoneNo, appUsr.UserName, DateTime.Now, appUsr.UserName, DateTime.Now, ent.Status };

                        }
                        else
                        {

                            sql = @"INSERT INTO [Borrowers] (                            
                            first_name,
                            last_name,
                            birth_day,
                            email,
                            home_address,
                            home_no,
                            company,
                            company_address,
                            company_no,                            
                            created_by,
                            created_date,
                            updated_by,
                            updated_date,                            
                            status,
                            picture) 
                        VALUES (
                            @firstname,
                            @lastname,
                            @birthday,
                            @email,
                            @homeaddress,
                            @homeno,
                            @company,
                            @companyaddress,
                            @companyno,                            
                            @createdby,
                            @createddate,
                            @updatedby,
                            @updateddate,
                            @status,
                            @picture)";

                            asParams = new string[] { "@firstname", "@lastname", "@birthday", "@email", "@homeaddress", "@homeno", "@company", "@companyaddress", "@companyno", "@createdby", "@createddate", "@updatedby", "@updateddate", "@status", "@picture" };
                            atParamTypes = new DbType[] { DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.DateTime, DbType.Int32, DbType.Binary };
                            aoValues = new object[] { ent.FirstName, ent.LastName, ent.BirthDay, ent.Email, ent.HomeAddress, ent.HomePhoneNo, ent.Company, ent.CompanyAddress, ent.CompanyPhoneNo, appUsr.UserName, DateTime.Now, appUsr.UserName, DateTime.Now, ent.Status, ent.Picture };

                        }

                        
                    }
                    else
                    {

                        if (ent.Picture == null) {

                            sql = @"UPDATE [Borrowers] SET
                            first_name = @firstName,
                            last_name = @lastName,
                            birth_day = @birthday,
                            email = @email,
                            home_address = @homeaddress,
                            home_no = @homeno,
                            company = @company,
                            company_address = @companyaddress,
                            company_no = @companyno,
                            updated_by = @updatedBy,
                            updated_date = @updatedDate,                            
                            status = @status
                        WHERE id = @id";

                            asParams = new string[] { "@firstName", "@lastName", "@birthday", "@email", "@homeaddress", "@homeno", "@company", "@companyaddress", "@companyno", "@updatedBy", "@updatedDate", "@status", "@id" };
                            atParamTypes = new DbType[] { DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime, DbType.Int32, DbType.Int32 };
                            aoValues = new object[] { ent.FirstName, ent.LastName, ent.BirthDay, ent.Email, ent.HomeAddress, ent.HomePhoneNo, ent.Company, ent.CompanyAddress, ent.CompanyPhoneNo, appUsr.UserName, DateTime.Now, ent.Status, ent.ID };
                        
                        } else {

                            sql = @"UPDATE [Borrowers] SET
                            first_name = @firstName,
                            last_name = @lastName,
                            birth_day = @birthday,
                            email = @email,
                            home_address = @homeaddress,
                            home_no = @homeno,
                            company = @company,
                            company_address = @companyaddress,
                            company_no = @companyno,
                            updated_by = @updatedBy,
                            updated_date = @updatedDate,                            
                            status = @status,
                            picture = @picture
                        WHERE id = @id";

                            asParams = new string[] { "@firstName", "@lastName", "@birthday", "@email", "@homeaddress", "@homeno", "@company", "@companyaddress", "@companyno", "@updatedBy", "@updatedDate", "@status", "@picture", "@id" };
                            atParamTypes = new DbType[] { DbType.String, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime, DbType.Int32, DbType.Binary, DbType.Int32 };
                            aoValues = new object[] { ent.FirstName, ent.LastName, ent.BirthDay, ent.Email, ent.HomeAddress, ent.HomePhoneNo, ent.Company, ent.CompanyAddress, ent.CompanyPhoneNo, appUsr.UserName, DateTime.Now, ent.Status, ent.Picture, ent.ID };

                        }

                        
                    }

                    db.ExecuteCommandNonQuery(sql, asParams, atParamTypes, aoValues, out ret, CommandTypeEnum.Text);

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
                        new object[] { "Borrowers", id },
                        out ret, ref oTable, CommandTypeEnum.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool DoesBorrowerExist(string firstName, string lastName)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "SELECT * FROM Borrowers WHERE status IN (0,1) AND UPPER(first_name) = UPPER(@firstName) AND UPPER(last_name) = UPPER(@lastName)";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@firstName", "@lastName" },
                        new DbType[] { DbType.String, DbType.String },
                        new object[] { firstName, lastName },
                        out ret, ref oTable, CommandTypeEnum.Text);

                    if (oTable.Rows.Count > 0) { return true; }

                    return false;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        public static DataTable GetBorrowers()
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    string sql;
                    DataTable oTable = new DataTable();
                    sql = "SELECT id, first_name + ' ' + last_name name FROM Borrowers WHERE status = 1";
                    oTable = db.Fetch(sql);

                    return oTable;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool IsBorrowerUtilized(int id)
        {


            try
            {

                // Loans Table
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {
                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "SELECT * FROM [Loans] WHERE [status] = 1 AND (borrower_id = @id OR comaker_id = @id)";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { id },
                        out ret, ref oTable, CommandTypeEnum.Text);

                    if (oTable.Rows.Count > 0) { return true; }


                }

                

                return false;
            }
            catch (Exception ex) { throw ex; }

        }
        
    }
}
