using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLoan.Core.Model
{
    [Serializable]
    public class BorrowerEntity
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateTime birthDay;
        private string homeAddress;
        private string homePhoneNo;
        private string email;
        private string company;
        private string companyAddress;
        private string companyPhoneNo;
        private Byte[] picture;
        private int status;

        public BorrowerEntity() { 
        
        }

        public Byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        public string HomePhoneNo
        {
            get { return homePhoneNo; }
            set { homePhoneNo = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string CompanyAddress
        {
            get { return companyAddress; }
            set { companyAddress = value; }
        }

        public string CompanyPhoneNo
        {
            get { return companyPhoneNo; }
            set { companyPhoneNo = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
