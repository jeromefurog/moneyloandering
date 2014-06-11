using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;
using System.Data;

namespace ezLend
{
    public partial class AdminDefault : System.Web.UI.Page
    {
        DashboardService newService = new DashboardService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (!IsPostBack)
                {
                    PopulateInvestments();
                    PopulateApplyLoans();

                }

            }
            catch (Exception ex) { throw ex; }
        }

        protected void Approve(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdView1.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblLoanId");

            Response.Redirect(string.Format("ApproveLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }

        public string GetJson(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new

            System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows =
              new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName.Trim(), dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        private void PopulateInvestments()
        {

            
            //DataTable dtVw = newService.GetInvestments(0);
            //if (dtVw != null)
            //{
            //    lstInvestments.DataSource = dtVw;
            //    lstInvestments.DataBind();

                

            //}

            //dtVw = newService.GetWithdrawals(0);
            //if (dtVw != null)
            //{
            //    lstWithdrawals.DataSource = dtVw;
            //    lstWithdrawals.DataBind();

            //}

            //dtVw = newService.GetLoanedForUser(0);
            //if (dtVw != null)
            //{
            //    lstLoaned.DataSource = dtVw;
            //    lstLoaned.DataBind();

            //}

            lblTotalInvestments.Text = newService.TotalInvestments(0);
            lblTotalWithdrawals.Text = newService.TotalWithdrawals(0);
            lblEarnings.Text = newService.TotalEarnings(0);
            lblCashOnHand.Text = newService.TotalCashOnHand(0);
            lblTotalLoan.Text = newService.TotalLoanedAmount(0);
            lblTotalCollectable.Text = newService.TotalCollectableAmount(0);

            hdInvestmentChart.Value = GetJson(newService.GetInvestments(-999));
        }

        protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView1.PageIndex = e.NewPageIndex;
            PopulateApplyLoans();
        }

        private void PopulateApplyLoans()
        {

            LoanService loanService = new LoanService();
            DataView dtVw = loanService.GetApplyLoans(0, string.Empty);
            if (dtVw != null)
            {
                grdView1.DataSource = dtVw;
                grdView1.DataBind();

            }
        }
    }
}