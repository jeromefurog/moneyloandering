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
    public partial class Default : System.Web.UI.Page
    {
        DashboardService newService = new DashboardService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (!IsPostBack)
                {
                    PopulateInvestments();

                }

            }
            catch (Exception ex) { throw ex; }
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
    }
}