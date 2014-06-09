using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iLoan.Core.Model;
using System.Data;

namespace iLoan.Core.Service
{
    public class ComakerService
    {
        AppUserEntity appUsr = new AppUserEntity();

        public ComakerService() 
        {
            appUsr = GlobalObjects.AppUser;
        
        }

        
        public static DataTable GetComakers(int id)
        {
            try
            {
                using (Database db = new Database(GlobalObjects.CONNECTION_STRING))
                {

                    db.Open();
                    string sql;
                    int ret = 0;
                    DataTable oTable = new DataTable();
                    sql = "SELECT id, first_name + ' ' + last_name name FROM Borrowers WHERE status = 1 AND id <> @id";
                    db.ExecuteCommandReader(sql,
                        new string[] { "@id" },
                        new DbType[] { DbType.Int32 },
                        new object[] { id },
                        out ret, ref oTable, CommandTypeEnum.Text);

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
