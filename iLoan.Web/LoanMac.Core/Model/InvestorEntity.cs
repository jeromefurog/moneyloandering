using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanMac.Core.Model
{
    [Serializable]
    public class InvestorEntity
    {
        private int _id;
        private int _userId;
        private decimal _amount;        
        private string _notes; 
        private int _status;

        public InvestorEntity()
        {
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }      
          
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
