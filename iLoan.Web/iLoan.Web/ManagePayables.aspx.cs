using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iLoan.Core;
using iLoan.Core.Model;
using iLoan.Core.Service;
using System.Data;

namespace iLoan.Web
{
    public partial class ManagePayables : System.Web.UI.Page
    {
        PayableEntity newEntity = null;
        PayableService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Page.Title + " - " + "Manage Payables";

            newEntity = new PayableEntity();
            newService = new PayableService();

            if (!IsPostBack)
            {
                PopulateCurrentGrid();
                PopulatePreviousGrid();
                PopulateNextGrid();
            }

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

        private void PopulatePreviousGrid()
        {

            DataTable dtVw = newService.GetPreviousPayables();
            if (dtVw != null)
            {
                grdViewPrevious.DataSource = dtVw;
                grdViewPrevious.DataBind();

            }


        }

        private void PopulateNextGrid()
        {

            DataTable dtVw = newService.GetNextPayables();
            if (dtVw != null)
            {
                grdViewNext.DataSource = dtVw;
                grdViewNext.DataBind();

            }


        }

        protected void CurrentPay(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdViewCurrent.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("AddCutoffPay.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }

        protected void PreviousPay(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdViewPrevious.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("AddCutoffPay.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }

        protected void NextPay(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdViewNext.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("AddCutoffPay.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }

        protected void grdViewCurrent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
            {

                int colNo = Utility.GetColumnID("edit", grdViewCurrent);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grdViewCurrent.Columns[colNo].Visible = false;
                }

            }
        }

        protected void grdViewPrevious_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
            {

                int colNo = Utility.GetColumnID("edit", grdViewPrevious);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grdViewPrevious.Columns[colNo].Visible = false;
                }

            }
        }

        protected void grdViewNext_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
            {

                int colNo = Utility.GetColumnID("edit", grdViewNext);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grdViewNext.Columns[colNo].Visible = false;
                }

            }
        }

        
        protected void grdViewCurrent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdViewCurrent.PageIndex = e.NewPageIndex;
            PopulateCurrentGrid();
        }

        protected void grdViewPrevious_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdViewPrevious.PageIndex = e.NewPageIndex;
            PopulatePreviousGrid();
        }

        protected void grdViewNext_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdViewNext.PageIndex = e.NewPageIndex;
            PopulateNextGrid();
        }
       
    }
}