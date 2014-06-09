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
using System.Web.Security;

namespace LoanMac.Web
{
    public partial class NewLoan : System.Web.UI.Page
    {
        int id = 0;
        LoanEntity newEntity = new LoanEntity();
        LoanService newService = new LoanService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                if (!GlobalObjects.IsAdmin && id == -1)
                {
                    Response.Redirect("Default.aspx");

                }

                if (!IsPostBack)
                {
                    LoadBorrower();
                    LoadInvestors(0);
                    LoadLoanTerm();
                    LoadCollateral();
                    ddlComaker.Items.Insert(0, new ListItem("-- Select --", "0"));

                    if (id != -1)
                    {
                        PopulateFields(id);
                    }

                    hdId.Value = id.ToString();
                }

                

            }
            catch (Exception ex) { throw ex; }
            
        }

        private void LoadInvestors(int id)
        {

            DataTable oTable = newService.GetInvestors(id);

            if (id == 0) {

                oTable.DefaultView.RowFilter = " amount > 0 ";
            }

            ddlInvestor.DataSource = oTable.DefaultView;
            ddlInvestor.DataTextField = "name";
            ddlInvestor.DataValueField = "id";
            ddlInvestor.DataBind();

            ddlInvestor.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlInvestor.SelectedIndex = 0;

        }

        private void LoadBorrower()
        {
            DataTable oTable = newService.GetBorrowers(0);
            ddlBorrower.DataSource = oTable;
            ddlBorrower.DataTextField = "name";
            ddlBorrower.DataValueField = "id";
            ddlBorrower.DataBind();

            ddlBorrower.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlBorrower.SelectedIndex = 0;

        }

        private void LoadComaker(int id)
        {
            DataTable oTable = newService.GetBorrowers(id);
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

        private void PopulateFields(int id)
        {

            
            newEntity = new LoanEntity();
            newEntity = newService.GetOne(id);

            txtPeriod.Text = newEntity.Period.ToString();
            ddlLoanTerm.SelectedValue = newEntity.TermId.ToString();
            this.txtDate.Text = newEntity.Date.ToString("yyyy-MM-dd");
            this.txtInterest.Text = newEntity.Interest.ToString();
            ddlCollateral.SelectedValue = newEntity.CollateralId.ToString();
            this.txtCollateralDetails.Text = newEntity.CollateralDetails;
            ddlBorrower.SelectedValue = newEntity.BorrowerId.ToString();
            this.txtNotes.Text = newEntity.Notes;
            this.txtAmount.Text = newEntity.Amount.ToString();

            LoadComaker(newEntity.BorrowerId);
            ddlComaker.SelectedValue = newEntity.ComakerId.ToString();

            LoadInvestors(-1);
            ddlInvestor.SelectedValue = newEntity.InvestorId.ToString();
            
            ddlLoanTerm.Enabled = false;
            ddlComaker.Enabled = false;
            ddlBorrower.Enabled = false;
            ddlInvestor.Enabled = false;
            txtDate.Enabled = false;
            txtInterest.Enabled = false;
            this.txtAmount.Enabled = false;
            txtPeriod.Enabled = false;
                       
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
                {

                    Create();

                }
                else {
                    Update();
                }
                
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            newService.DeleteUser(id);


            Response.Redirect("ManageLoans.aspx");
        }
                
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageLoans.aspx");
        }

        protected void ddlBorrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlBorrower.SelectedValue);

            LoadComaker(id);
        }

        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlInvestor.SelectedValue);

            if (id > 0)
            {
                DataTable oTable = newService.GetInvestors(id);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    string amt = oRow["amount"].ToString();
                    hdTotalAmount.Value = string.Format("{0}", amt);
                }
            }
            else {

                hdTotalAmount.Value = string.Empty;
                txtAmount.Text = string.Empty;
            }
        }

        private void Create()
        {

            newEntity = new LoanEntity();

            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text.Trim());
            newEntity.Period = Convert.ToInt32(txtPeriod.Text.Trim());
            newEntity.TermId = Convert.ToInt32(ddlLoanTerm.SelectedValue);
            newEntity.Date = Convert.ToDateTime(this.txtDate.Text.Trim());
            newEntity.Interest = Convert.ToDecimal(this.txtInterest.Text.Trim());
            newEntity.CollateralId = Convert.ToInt32(ddlCollateral.SelectedValue);
            newEntity.CollateralDetails = this.txtCollateralDetails.Text.Trim();
            newEntity.ComakerId = Convert.ToInt32(ddlComaker.SelectedValue);
            newEntity.BorrowerId = Convert.ToInt32(ddlBorrower.SelectedValue);
            newEntity.InvestorId = Convert.ToInt32(ddlInvestor.SelectedValue);   
            newEntity.Notes = this.txtNotes.Text.Trim();            
            newEntity.Status = 1;

            newService.Save(ActionType.Create, newEntity);
            
            Response.Redirect("ManageLoans.aspx");
            
        }

        private void Update()
        {
            newEntity = new LoanEntity();
            newEntity.ID = id;
            newEntity.CollateralId = Convert.ToInt32(ddlCollateral.SelectedValue);
            newEntity.CollateralDetails = this.txtCollateralDetails.Text.Trim();
            newEntity.ComakerId = Convert.ToInt32(ddlComaker.SelectedValue);
            newEntity.Date = DateTime.Now; //set dummy value to prevent error
            newEntity.Notes = this.txtNotes.Text.Trim();
            
            newService.Save(ActionType.Update, newEntity);

            Response.Redirect("ManageLoans.aspx");

        }             

        
        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (Convert.ToInt32(this.ddlBorrower.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Borrower is required. ";
                retVal = false;
            }

            if (Convert.ToInt32(this.ddlComaker.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Co-maker is required. ";
                retVal = false;
            }

            if (Convert.ToInt32(this.ddlLoanTerm.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Loan Term is required. ";
                retVal = false;
            }

            if (Convert.ToInt32(this.ddlCollateral.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Collateral is required. ";
                retVal = false;
            }

            if (Convert.ToInt32(this.ddlInvestor.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Investor is required. ";
                retVal = false;
            }

            if (Convert.ToDecimal(this.txtAmount.Text) <= 0)
            {
                errorMsg = errorMsg + "Amount should be greater that zero. ";
                retVal = false;
            }

            if (!retVal)
            {

                SetMessage(errorMsg);
            }
            else
            {
                SetMessage(string.Empty);
            }
            
            return retVal;
        }

        private void SetMessage(string msg) {

            HiddenField hdField = (HiddenField)Master.FindControl("hdError");
            if (hdField != null)
            {
                hdField.Value = msg;
            }   
        }

        
    }
}
