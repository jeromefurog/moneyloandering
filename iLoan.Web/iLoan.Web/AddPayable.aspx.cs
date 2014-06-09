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
using System.Web.Security;

namespace iLoan.Web
{
    public partial class AddPayable : System.Web.UI.Page
    {
        private int id = 0;

        LoanEntity newEntity = null;
        LoanService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
                {
                    Response.Redirect("Default.aspx");

                }

                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }


                Page.Title = Page.Title + " - " + "Payables";
                this.lblTitle.Text = "Loan Payables";

                newEntity = new LoanEntity();
                newService = new LoanService();

                if (!IsPostBack)
                {

                    LoadBorrower();
                    LoadLoanTerm();
                    LoadCollateral();
                    ddlComaker.Items.Insert(0, new ListItem("-- Select --", "0"));
                    PopulateFields(id);
                    

                }

            }
            catch (Exception ex) { throw ex; }
        }

        private void LoadBorrower()
        {
            DataTable oTable = BorrowerService.GetBorrowers();
            ddlBorrower.DataSource = oTable;
            ddlBorrower.DataTextField = "name";
            ddlBorrower.DataValueField = "id";
            ddlBorrower.DataBind();

            ddlBorrower.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlBorrower.SelectedIndex = 0;

        }

        private void LoadComaker(int id)
        {
            DataTable oTable = ComakerService.GetComakers(id);
            ddlComaker.DataSource = oTable;
            ddlComaker.DataTextField = "name";
            ddlComaker.DataValueField = "id";
            ddlComaker.DataBind();

            ddlComaker.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlComaker.SelectedIndex = 0;

        }

        private void LoadLoanTerm()
        {
            DataTable oTable = newService.GetLoanTerms();
            ddlLoanTerm.DataSource = oTable;
            ddlLoanTerm.DataTextField = "name";
            ddlLoanTerm.DataValueField = "id";
            ddlLoanTerm.DataBind();

            ddlLoanTerm.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlLoanTerm.SelectedIndex = 0;

        }

        private void LoadCollateral()
        {
            DataTable oTable = newService.GetCollateral();
            ddlCollateral.DataSource = oTable;
            ddlCollateral.DataTextField = "name";
            ddlCollateral.DataValueField = "id";
            ddlCollateral.DataBind();

            ddlCollateral.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlCollateral.SelectedIndex = 0;

        }

        protected void ddlBorrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlBorrower.SelectedValue);

            LoadComaker(id);

        }

        private void PopulateFields(int id)
        {


            newEntity = new LoanEntity();
            newEntity = newService.GetSpecific(id);

            txtLoanId.Text = newEntity.ID.ToString();
            ddlBorrower.SelectedValue = newEntity.Borrowerid.ToString();
            ddlLoanTerm.SelectedValue = newEntity.Termid.ToString();
            txtPeriod.Text = newEntity.Period.ToString();
            ddlCollateral.SelectedIndex = newEntity.CollateralId;
            txtCollateralDetails.Text = newEntity.CollateralDetails;
            txtInterest.Text = newEntity.Interest.ToString();
            txtDate.Text = newEntity.Loandate.ToString("M/d/yyyy");
            txtNotes.Text = newEntity.Notes;
            txtAmount.Text = newEntity.Amount.ToString();
            txtTotalPayableAmount.Text = newEntity.TotalPayableAmount.ToString();
            

            LoadComaker(newEntity.Borrowerid);
            ddlComaker.SelectedValue = newEntity.Comakerid.ToString();

            txtLoanId.Enabled = false;
            ddlBorrower.Enabled = false;
            ddlLoanTerm.Enabled = false;
            ddlBorrower.Enabled = false;
            txtPeriod.Enabled = false;
            ddlCollateral.Enabled = false;
            txtCollateralDetails.Enabled = false;
            txtInterest.Enabled = false;
            txtDate.Enabled = false;
            txtAmount.Enabled = false;
            ddlComaker.Enabled = false;
            txtNotes.Enabled = false;
            txtTotalPayableAmount.Enabled = false;

            PopulateGrid();
            

        }

        private void PopulateGrid()
        {
            PayableService serv = new PayableService();
            DataTable dtVw = serv.GetSpecific(id);
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

            Response.Redirect(string.Format("AddCutoffPay.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.Text))));

        }
        
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            // Set PDF Column
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label id = (Label)e.Row.FindControl("lblstatus");
                bool isPaid = Convert.ToBoolean(Convert.ToInt32(id.Text));

                Button bPay = (Button)e.Row.FindControl("btnPay");

                if (isPaid) {
                    bPay.CssClass = "btn btn-small btn-success";
                    bPay.Text = "Paid / Edit";
                    
               }
                else
                {
                    bPay.CssClass = "btn btn-small btn-danger";
                    bPay.Text = "Pay Amount";
                    
                }
            }


        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            PopulateGrid();
        }

                
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageLoan.aspx");
        }
    }
}