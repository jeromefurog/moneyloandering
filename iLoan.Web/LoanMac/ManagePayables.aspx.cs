using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;

namespace LoanMac.Web
{
    public partial class ManagePayables : System.Web.UI.Page
    {
        PayableService newService = new PayableService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalObjects.IsAdmin)
                {
                    Response.Redirect("Default.aspx");

                }

                if (!IsPostBack)
                {
                    PopulateCurrentGrid();
                    PopulateOverDueGrid();
                    PopulatePendingGrid();
                }

            }
            catch (Exception ex) { throw ex; }
            
        }

        private void PopulateCurrentGrid()
        {

            DataTable dtVw = newService.GetCurrentPayables();
            if (dtVw != null)
            {
                grdViewCurrent.DataSource = dtVw;
                grdViewCurrent.DataBind();

            }

        }

        private void PopulateOverDueGrid()
        {
            DataTable dtVw = newService.GetOverDuePayables();
            if (dtVw != null)
            {
                grdViewOverDue.DataSource = dtVw;
                grdViewOverDue.DataBind();

            }
            
        }

        private void PopulatePendingGrid()
        {
            DataTable dtVw = newService.GetPendingPayables();
            if (dtVw != null)
            {
                grdViewPending.DataSource = dtVw;
                grdViewPending.DataBind();

            }

        }

        protected void Pay(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdViewCurrent.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("PayLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }

        protected void grdViewCurrent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdViewCurrent.PageIndex = e.NewPageIndex;
            PopulateCurrentGrid();
        }

        protected void grdViewOverDue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdViewOverDue.PageIndex = e.NewPageIndex;
            PopulateOverDueGrid();
        }

        protected void grdViewPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdViewPending.PageIndex = e.NewPageIndex;
            PopulatePendingGrid();
        }

        protected void grdViewCurrent_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            
        }

        protected void grdViewOverDue_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void grdViewPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }
        
        
    }
}
