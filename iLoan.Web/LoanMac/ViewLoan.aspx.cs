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
    public partial class ViewLoan : System.Web.UI.Page
    {
        int id = 0;
        LoanEntity newEntity = new LoanEntity();
        LoanService newService = new LoanService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                if (!GlobalObjects.IsAdmin)
                {
                    Response.Redirect("Default.aspx");

                }

                if (!IsPostBack)
                {
                    
                    PopulateFields(id);
                    PopulateGrid();

                }

            }
            catch (Exception ex) { throw ex; }
            
        }

        private void PopulateFields(int id)
        {


            newEntity = new LoanEntity();
            newEntity = newService.GetOne(id);

            lblPeriod.InnerText = newEntity.Period.ToString() + " month(s)";
            lblDate.InnerText = newEntity.Date.ToString("M/d/yyyy");
            lblNotes.InnerText = newEntity.Notes;
            lblAmount.InnerText = "Php " + newEntity.Amount.ToString();
            lblInterest.InnerText = newEntity.Interest.ToString() + " %";
            lblCollateralDetails.InnerText = newEntity.CollateralDetails;


            DataTable oTable = newService.GetBorrowers(0);
            oTable.DefaultView.RowFilter = " id = " + newEntity.BorrowerId.ToString();
            if (oTable.DefaultView.ToTable().Rows.Count > 0)
            {
                DataRow oRow = oTable.DefaultView.ToTable().Rows[0];
                
                hlBorrower.Text = oRow["name"].ToString();
                hlBorrower.NavigateUrl = string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(newEntity.BorrowerId.ToString())));
            }

            oTable = newService.GetLoanTerms();
            oTable.DefaultView.RowFilter = " id = " + newEntity.TermId.ToString();
            if (oTable.DefaultView.ToTable().Rows.Count > 0)
            {
                DataRow oRow = oTable.DefaultView.ToTable().Rows[0];
                this.lblTerm.InnerText = oRow["name"].ToString();
            }

            oTable = newService.GetCollateral();
            oTable.DefaultView.RowFilter = " id = " + newEntity.CollateralId.ToString();
            if (oTable.DefaultView.ToTable().Rows.Count > 0)
            {
                DataRow oRow = oTable.DefaultView.ToTable().Rows[0];
                this.lblCollateral.InnerText = oRow["name"].ToString();
            }

            oTable = newService.GetBorrowers(0);
            oTable.DefaultView.RowFilter = " id = " + newEntity.ComakerId.ToString();
            if (oTable.DefaultView.ToTable().Rows.Count > 0)
            {
                DataRow oRow = oTable.DefaultView.ToTable().Rows[0];
                hlComaker.Text = oRow["name"].ToString();
                hlComaker.NavigateUrl = string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(newEntity.ComakerId.ToString())));
            }            

            oTable = newService.GetBorrowers(0);
            oTable.DefaultView.RowFilter = " id = " + newEntity.InvestorId.ToString();
            if (oTable.DefaultView.ToTable().Rows.Count > 0)
            {
                DataRow oRow = oTable.DefaultView.ToTable().Rows[0];
                hlInvestor.Text = oRow["name"].ToString();
                hlInvestor.NavigateUrl = string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(newEntity.InvestorId.ToString())));
            }

                        


        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("NewLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.ToString()))));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageLoans.aspx");
        }

        private void PopulateGrid()
        {
            PayableService serv = new PayableService();

            DataView dtVw = serv.GetAll(id);
            if (dtVw != null)
            {
                grdView.DataSource = dtVw;
                grdView.DataBind();

            }
        }

        protected void Pay(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            TableCell tableCell = (TableCell)imageButton.Parent;
            GridViewRow row = (GridViewRow)tableCell.Parent;
            grdView.SelectedIndex = row.RowIndex;
            Label id = (Label)row.FindControl("lblUsrId");

            Response.Redirect(string.Format("PayLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label id = (Label)e.Row.FindControl("lblstatus");
                bool isPaid = Convert.ToBoolean(Convert.ToInt32(id.Text));

                Button bPay = (Button)e.Row.FindControl("btnPay");

                if (isPaid)
                {
                    bPay.CssClass = "button-success pure-button";
                    bPay.Text = "Paid / Edit";

                }
                else
                {
                    bPay.CssClass = "button-error pure-button";
                    bPay.Text = "Pay Amount";

                }
            }


        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }
    }
}
