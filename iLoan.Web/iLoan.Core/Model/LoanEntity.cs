using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLoan.Core.Model
{
    [Serializable]
    public class LoanEntity
    {
        public LoanEntity()
        { 
        
        }

        private int id;
        private decimal amount;
        private int period;
        private int termid;
        private DateTime loandate;
        private decimal interest;
        private string notes;
        private int borrowerid;
        private int comakerid;
        private int collateralid;
        private string collateraldetails;
        private decimal totalpayableamount;
        private int status;

        
        public int ID { get { return id; } set { id = value; } }
        public decimal Amount { get { return amount; } set { amount = value; } }
        public int Termid { get { return termid; } set { termid = value; } }
        public int Period { get { return period; } set { period = value; } }
        public DateTime Loandate { get { return loandate; } set { loandate = value; } }
        public decimal Interest { get { return interest; } set { interest = value; } }
        public string Notes { get { return notes; } set { notes = value; } }
        public int Borrowerid { get { return borrowerid; } set { borrowerid = value; } }
        public int Comakerid { get { return comakerid; } set { comakerid = value; } }
        public int CollateralId { get { return collateralid; } set { collateralid = value; } }
        public string CollateralDetails { get { return collateraldetails; } set { collateraldetails = value; } }
        public decimal TotalPayableAmount { get { return totalpayableamount; } set { totalpayableamount = value; } }
        public int Status { get { return status; } set { status = value; } }

       
    }
}
