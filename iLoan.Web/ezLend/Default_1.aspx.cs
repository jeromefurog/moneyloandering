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
    public partial class Default_1 : System.Web.UI.Page
    {
        DashboardService newService = new DashboardService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (!IsPostBack)
                {

                    PopulateUser(GlobalObjects.User.ID);

                    if (GlobalObjects.IsAdmin)
                    {
                        dvHead.Visible = true;
                        PopulateUserDropdown();
                    }
                    else {
                        dvHead.Visible = false;
                        
                    }

                    

                }

            }
            catch (Exception ex) { throw ex; }
        }

        protected void drpUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(drpUser.SelectedValue);

            PopulateUser(id);
        }

        private void PopulateUserDropdown() {
            LoanService usrv = new LoanService();

            drpUser.DataSource = usrv.GetBorrowers(0);
            drpUser.DataTextField = "name";
            drpUser.DataValueField = "id";
            drpUser.DataBind();

            drpUser.SelectedValue = GlobalObjects.User.ID.ToString();
        }

        private void PopulateUser(int id)
        {


            DataTable dtVw = newService.GetInvestments(id);
            if (dtVw != null)
            {
                lstInvestments.DataSource = dtVw;
                lstInvestments.DataBind();

            }

            dtVw = newService.GetWithdrawals(id);
            if (dtVw != null)
            {
                lstWithdrawals.DataSource = dtVw;
                lstWithdrawals.DataBind();

            }

            dtVw = newService.GetLoanedForUser(id);
            if (dtVw != null)
            {
                lstLoaned.DataSource = dtVw;
                lstLoaned.DataBind();

            }

            lblTotalInvestments.Text = newService.TotalInvestments(id);
            lblTotalWithdrawals.Text = newService.TotalWithdrawals(id);
            lblEarnings.Text = newService.TotalEarnings(id);
            lblCashOnHand.Text = newService.TotalCashOnHand(id);
            lblTotalLoan.Text = newService.TotalLoanedAmount(id);
        }
    }
}