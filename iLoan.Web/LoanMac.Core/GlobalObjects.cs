using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Configuration;
using LoanMac.Core.Model;

namespace LoanMac.Core
{
    public static class GlobalObjects
    {
        public static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["iLoan"].ConnectionString;
        private static bool isAdmin = false;
        private static bool isInvestor = false;
        private static bool isBorrower = false;
        private static string sessionKey = string.Empty;
        private static UserEntity user;

        public static bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
        public static bool IsInvestor { get { return isInvestor; } set { isInvestor = value; } }
        public static bool IsBorrower { get { return isBorrower; } set { isBorrower = value; } }
        public static string SessionKey { get { return sessionKey; } set { sessionKey = value; } }
        public static UserEntity User { get { return user; } set { user = value; } }

        public enum Role
        {
            Investor = 1,
            Borrower = 2
        }

        public static Role GetRoleDesc(int roleId)
        {
            if (roleId == 1) { return Role.Investor; } else { return Role.Borrower; }
        }

        public static int GetRoleId(Role roleDesc)
        {
            if (roleDesc == Role.Investor) { return 1; } else { return 2; }
        }
    }
}
