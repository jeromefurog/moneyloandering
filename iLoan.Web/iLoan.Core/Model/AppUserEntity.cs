using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iLoan.Core.Model
{
    [Serializable]
    public class AppUserEntity
    {
        #region variable

        private int _userID;
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNo;
        private GlobalObjects.Role _role;
        private int _lockDay;
        private int _status;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public GlobalObjects.Role Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                _phoneNo = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }        
        public int LockDay
        {
            get
            {
                return _lockDay;
            }
            set
            {
                _lockDay = value;
            }
        }
        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        #endregion variable

        #region User
        public AppUserEntity()
        {
        }

        public AppUserEntity(int userID, string userName, string firstName, string lastName, string email)
        {
            _userID = userID;
            _userName = userName;
            _firstName = firstName;
            _email = email;
        }
        public AppUserEntity(int userID, string userName, string firstName, string lastName, string email, GlobalObjects.Role role)
        {
            _userID = userID;
            _userName = userName;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _role = role;
            
        }
        public AppUserEntity(int userID, string userName, string password, string firstName, string lastName, string email, GlobalObjects.Role role)
        {
            _userID = userID;
            _userName = userName;
            _password = password;
            _firstName = FirstName;
            _lastName = LastName;
            _email = email;
            _role = role;
        }

        public override string ToString()
        {
            return string.Format("userId:{0}|SystemId:{1}|Email:{2}|Role:{3}", _userID.ToString(), _userName, _email, _role);
        }

        

        #endregion AppUser
    }
}
