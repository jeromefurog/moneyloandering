using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLoan.Core.Model
{
    [Serializable]
    public class PayableEntity
    {
        private int id;
        private int loanid;
        private decimal amount;
        private DateTime paydate;
        private string notes;
        private int status;

        public PayableEntity()
        { 
        
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int LoanId
        {
            get { return loanid; }
            set { loanid = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PayDate
        {
            get { return paydate; }
            set { paydate = value; }
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
