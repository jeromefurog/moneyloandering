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
    public partial class ManageUser : System.Web.UI.Page
    {
        AppUserEntity newEntity = null;
        UserService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Page.Title + " - " + "Manage Users";

                newEntity = new AppUserEntity();
                newService = new UserService();

                if (!IsPostBack)
                {
                    PopulateGrid();
                    HideNonViewerObjects();
                    
                }

            }
            catch (Exception ex) { throw ex; }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("AddUser.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode("-1"))));
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

        protected void editRecord(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdView.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("AddUser.aspx?id={0}",Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        private void HideNonViewerObjects()
        {

            if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Administrator)
            {

                dvFormActions.Visible = true;
            }
            else {
                dvFormActions.Visible = false;
            }
            

        }
    }
}