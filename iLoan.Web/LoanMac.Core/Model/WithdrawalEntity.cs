using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanMac.Core.Model
{
    [Serializable]
    public class WithdrawalEntity
    {
        private int id;
        private int userid;
        private decimal amount;
        private DateTime date;
        private string notes;
        private int status;

        public WithdrawalEntity()
        {

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
