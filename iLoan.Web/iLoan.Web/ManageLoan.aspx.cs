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
    public partial class ManageLoan : System.Web.UI.Page
    {
        LoanEntity newEntity = null;
        LoanService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Page.Title + " - " + "Manage Loans";

                newEntity = new LoanEntity();
                newService = new LoanService();

                if (!IsPostBack)
                {
                    PopulateGrid();
                    HideNonViewerObjects();

                }

            }
            catch (Exception ex) { throw ex; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BuildSearchString();
        }

        private void BuildSearchString()
        {

            Dictionary<string, string> query = new Dictionary<string, string>();

            

            if (!string.IsNullOrEmpty(this.txtFormId.Text.Trim()))
            {
                query.Add("form_id", this.txtFormId.Text.Trim());
            }

            if (!string.IsNullOrEmpty(this.txtBorrower.Text.Trim()))
            {
                query.Add("borrower", txtBorrower.Text.Trim());
            }

            if (!string.IsNullOrEmpty(this.txtComaker.Text.Trim()))
            {
                query.Add("comaker", txtComaker.Text.Trim());
            }

            if (!string.IsNullOrEmpty(this.txtDate.Text.Trim()))
            {
                query.Add("loan_date", txtDate.Text.Trim());
            }

            if (Convert.ToInt32(this.ddlPayStatus.SelectedValue) >= 0)
            {
                query.Add("pay_status", ddlPayStatus.SelectedValue);
            }

            DataTable dtVw = newService.Search(query);
            if (dtVw != null)
            {
                grdView.DataSource = dtVw;
                grdView.DataBind();

            }
        }

        private void PopulateGrid()
        {
            DataView dtVw = newService.GetAll();
            if (dtVw != null)
            {
                grdView.DataSource = dtVw;
                grdView.DataBind();

            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("AddLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode("-1"))));
        }

        protected void editRecord(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdView.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("AddLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));
        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Hide Edit Column if ECO
            if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
            {

                int colNo = Utility.GetColumnID("edit", grdView);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grdView.Columns[colNo].Visible = false;
                }

            }
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

        private void HideNonViewerObjects()
        {

            if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
            {

                this.btnAdd.Visible = false;
            }
            else
            {
                this.btnAdd.Visible = true;
            }


        }
    }
}