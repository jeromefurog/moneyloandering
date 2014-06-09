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
    public partial class ManageLoans : System.Web.UI.Page
    {
        LoanService newService = new LoanService();

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
                    PopulateGrid();

                }

            }
            catch (Exception ex) { throw ex; }
            
        }

        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("NewLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode("-1"))));
        }

        private void PopulateGrid()
        {

            string query = this.txtSearch.Text.Trim();              

            DataView dtVw = newService.GetAll(query);
            if (dtVw != null)
            {
                grdView.DataSource = dtVw;
                grdView.DataBind();

            }
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }
    }
}
