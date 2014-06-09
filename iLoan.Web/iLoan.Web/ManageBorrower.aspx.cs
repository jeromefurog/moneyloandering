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
    public partial class ManageBorrower : System.Web.UI.Page
    {
        BorrowerEntity newEntity = null;
        BorrowerService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Page.Title + " - " + "Manage Users";

                newEntity = new BorrowerEntity();
                newService = new BorrowerService();

                if (!IsPostBack)
                {
                    PopulateGrid();
                    HideNonViewerObjects();

                }

            }
            catch (Exception ex) { throw ex; }

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
            Response.Redirect(string.Format("AddBorrower.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode("-1"))));
        }

        protected void editRecord(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdView.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("AddBorrower.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));
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

                btnAdd.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BuildSearchString();
        }

        private void BuildSearchString()
        {

            Dictionary<string, string> query = new Dictionary<string, string>();

            query.Add("status", ddlStatus.SelectedValue);
            
            if (!string.IsNullOrEmpty(this.txtFirstName.Text.Trim()))
            {
                query.Add("first_name", this.txtFirstName.Text.Trim());
            }

            if (!string.IsNullOrEmpty(this.txtLastName.Text.Trim()))
            {
                query.Add("last_name", txtLastName.Text.Trim());
            }

            
            DataTable dtVw = newService.Search(query);
            if (dtVw != null)
            {
                grdView.DataSource = dtVw;
                grdView.DataBind();

            }
        }
    }
}