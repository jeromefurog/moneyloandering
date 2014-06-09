using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Configuration;
using iLoan.Core.Model;

namespace iLoan.Core
{
    public static class GlobalObjects
    {
        public static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["iLoan"].ConnectionString;
        private static bool isAdmin = false;
        private static string sessionKey = string.Empty;
        private static AppUserEntity appUser;

        public static bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
        public static string SessionKey { get { return sessionKey; } set { sessionKey = value; } }
        public static AppUserEntity AppUser { get { return appUser; } set { appUser = value; } }

        public enum Role
        {
            User = 1,
            Administrator = 3,
            Viewer = 4
        }

        public static Role SetRole(int roleId)
        {
            if (roleId == 1) { return Role.User; } else if (roleId == 3) { return Role.Administrator; } else { return Role.Viewer; }
        }
    }
}
