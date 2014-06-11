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
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    id = GlobalObjects.User.ID;
                    PopulateUser();

                    if (GlobalObjects.IsAdmin)
                    {
                        dvHead.Visible = true;
                        PopulateUserDropdown();
                    }
                    else {
                        dvHead.Visible = false;
                        
                    }

                    hdId.Value = id.ToString();

                }

            }
            catch (Exception ex) { throw ex; }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {

            Response.Redirect(string.Format("ApplyLoan.aspx?id={0}&loanid={1}", Utility.EncryptQueryString(HttpUtility.UrlEncode(hdId.Value.ToString())), Utility.EncryptQueryString(HttpUtility.UrlEncode("-1"))));
        }

        protected void drpUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Convert.ToInt32(drpUser.SelectedValue);
            hdId.Value = id.ToString();

            PopulateUser();
        }

        private void CreateAlerts()
        {
            PayableService ser = new PayableService();
            dvAlert.InnerHtml = string.Empty;
            bool hasOverdue = false;

            // overdue 
            DataTable tb = new DataTable();
            tb = ser.GetAlerts(1, id);
            foreach (DataRow dtRow in tb.Rows)
            {
                string loanid = string.Empty;
                string amt = string.Empty;
                string dt = string.Empty;
                string formt = string.Empty;

                hasOverdue = true;

                // on all table's columns
                foreach (DataColumn dc in tb.Columns)
                {
                    if (dc.ColumnName == "loan_id")
                    {
                        loanid = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "amount")
                    {
                        amt = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "date")
                    {
                        dt = dtRow[dc].ToString();
                    }

                }

                formt = String.Format(@"<div class='alert alert-danger'>
							    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
							    <i class='fa fa-warning sign'></i><strong>Warning!</strong> Please settle your overdue payment of <strong>{0}</strong> for Loan:<strong>{1}</strong> on last <strong>{2}</strong> immediately.
						    </div>", amt, loanid, dt);
                dvAlert.InnerHtml = dvAlert.InnerHtml + formt;
            }

            // thank you
            if (!hasOverdue) {
                tb = new DataTable();
                tb = ser.GetAlerts(0, id);
                foreach (DataRow dtRow in tb.Rows)
                {
                    string loanid = string.Empty;
                    string amt = string.Empty;
                    string dt = string.Empty;
                    string formt = string.Empty;

                    // on all table's columns
                    foreach (DataColumn dc in tb.Columns)
                    {
                        if (dc.ColumnName == "loan_id")
                        {
                            loanid = dtRow[dc].ToString();
                        }

                        if (dc.ColumnName == "amount")
                        {
                            amt = dtRow[dc].ToString();
                        }

                        if (dc.ColumnName == "date")
                        {
                            dt = dtRow[dc].ToString();
                        }

                    }

                    formt = String.Format(@"<div class='alert alert-success'>
							    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button> 
							    <i class='fa fa-check sign'></i><strong>Thank You!</strong> Your last payment of <strong>{0}</strong> for Loan:<strong>{1}</strong> on <strong>{2}</strong> was received.
						    </div>", amt, loanid, dt);
                    dvAlert.InnerHtml = dvAlert.InnerHtml + formt;
                }

            }

            
            // next 
            tb = new DataTable();
            tb = ser.GetAlerts(2, id);
            foreach (DataRow dtRow in tb.Rows)
            {
                string loanid = string.Empty;
                string amt = string.Empty;
                string dt = string.Empty;
                string formt = string.Empty;

                // on all table's columns
                foreach (DataColumn dc in tb.Columns)
                {
                    if (dc.ColumnName == "loan_id")
                    {
                        loanid = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "amount")
                    {
                        amt = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "date")
                    {
                        dt = dtRow[dc].ToString();
                    }

                }

                formt = String.Format(@"<div class='alert alert-info'>
							    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
							    <i class='fa fa-info-circle sign'></i><strong>Info!</strong> Your next payment of <strong>{0}</strong> for Loan:<strong>{1}</strong> is due on <strong>{2}</strong>.
						    </div>", amt, loanid, dt);
                dvAlert.InnerHtml = dvAlert.InnerHtml + formt;
            }


        }



        private void PopulateUserDropdown() {
            LoanService usrv = new LoanService();

            drpUser.DataSource = FormalFormatTable(usrv.GetBorrowers(0));
            drpUser.DataTextField = "name";
            drpUser.DataValueField = "id";
            drpUser.DataBind();

            drpUser.SelectedValue = GlobalObjects.User.ID.ToString();
        }

        public DataTable FormalFormatTable(DataTable dt)
        {
            try
            {
                foreach (DataRow row in dt.Rows)
                {


                    row["name"] = Utility.FormalFormat(Convert.ToString(row["name"]));

                    row.EndEdit();
                    dt.AcceptChanges();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        private void PopulateUser()
        {

            PopulateGrid();
            PopulateApplyLoans();
            //CreateAlerts();
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {

            string query = this.txtSearch.Text.Trim();
            LoanService loanService = new LoanService();
            DataView dtVw = loanService.GetAllByUser(id,query);
            if (dtVw != null)
            {
                grdView.DataSource = dtVw;
                grdView.DataBind();

            }
        }

        private void PopulateApplyLoans()
        {

            string query = this.txtSearch.Text.Trim();
            LoanService loanService = new LoanService();
            DataView dtVw = loanService.GetApplyLoans(id, query);
            if (dtVw != null)
            {
                grdView1.DataSource = dtVw;
                grdView1.DataBind();

            }
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

        protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView1.PageIndex = e.NewPageIndex;
            PopulateApplyLoans();
        }
    }
}