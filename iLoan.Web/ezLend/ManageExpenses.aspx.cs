﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;


namespace ezLend
{
    public partial class ManageExpenses : System.Web.UI.Page
    {
        WithdrawalService newService = new WithdrawalService();

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
            Response.Redirect(string.Format("NewExpense.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode("-1"))));
        }

        private void PopulateGrid()
        {

            string query = this.txtSearch.Text.Trim();

            DataView dtVw = newService.GetAll(query,1);
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