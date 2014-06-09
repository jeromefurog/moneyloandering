using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanMac.Core.Model
{
    [Serializable]
    public class UserEntity
    {
        private int _id;
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNo;
        private string _notes;        
        private bool _isAdmin;
        private Byte[] _picture;
        private int _status;

        public UserEntity()
        {
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public Byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }   

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
