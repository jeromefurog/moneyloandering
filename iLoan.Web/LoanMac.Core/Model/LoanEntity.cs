using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanMac.Core.Model
{
    [Serializable]
    public class LoanEntity
    {
        private int _id;
        private decimal _amount;
        private int _period;
        private int _termId;
        private DateTime _date;
        private decimal _interest;
        private int _collateralId;
        private string _collateralDetails;        
        private int _comakerId;
        private int _borrowerId;
        private int _investorId;
        private string _notes;
        private decimal _penalty;
        private string _penaltyDetails;
        private int _status;

        public LoanEntity()
        {
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public int Period
        {
            get { return _period; }
            set { _period = value; }
        }
        public int TermId
        {
            get { return _termId; }
            set { _termId = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public decimal Interest
        {
            get { return _interest; }
            set { _interest = value; }
        }
        public int CollateralId
        {
            get { return _collateralId; }
            set { _collateralId = value; }
        }
        public string CollateralDetails
        {
            get { return _collateralDetails; }
            set { _collateralDetails = value; }
        }
        public int ComakerId
        {
            get { return _comakerId; }
            set { _comakerId = value; }
        }
        public int BorrowerId
        {
            get { return _borrowerId; }
            set { _borrowerId = value; }
        }
        public int InvestorId
        {
            get { return _investorId; }
            set { _investorId = value; }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        public decimal Penalty
        {
            get { return _penalty; }
            set { _penalty = value; }
        }
        public string PenaltyDetails
        {
            get { return _penaltyDetails; }
            set { _penaltyDetails = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
