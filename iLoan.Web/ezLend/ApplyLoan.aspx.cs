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
    public partial class ApplyLoan : System.Web.UI.Page
    {
        int userid;
        int loanid;
        LoanEntity newEntity = new LoanEntity();
        LoanService newService = new LoanService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null || Request.QueryString["loanid"] == null) { 
                    Response.Redirect("Default.aspx"); 
                } else {
                    this.userid = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"])));
                    this.loanid = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["loanid"]))); 
                }

                if (loanid == -1)
                {
                    btnDelete.Visible = false;

                }

                if (!IsPostBack)
                {
                    LoadCollateral();

                    if (loanid != -1)
                    {
                        PopulateFields(loanid);
                    }
                }



            }
            catch (Exception ex) { throw ex; }

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
            newEntity = newService.GetApplyLoan(id);

            txtPeriod.Text = newEntity.Period.ToString();
            //ddlLoanTerm.SelectedValue = newEntity.TermId.ToString();
            //this.txtDate.Text = newEntity.Date.ToString("yyyy-MM-dd");
            //this.txtInterest.Text = newEntity.Interest.ToString();
            ddlCollateral.SelectedValue = newEntity.CollateralId.ToString();
            this.txtCollateralDetails.Text = newEntity.CollateralDetails;
            //ddlBorrower.SelectedValue = newEntity.BorrowerId.ToString();
            this.txtNotes.Text = newEntity.Notes;
            this.txtAmount.Text = newEntity.Amount.ToString();
            //this.txtPenalty.Text = newEntity.Penalty.ToString();
            //this.txtPenaltyDetails.Text = newEntity.PenaltyDetails;

            //LoadComaker(newEntity.BorrowerId);
            //ddlComaker.SelectedValue = newEntity.ComakerId.ToString();

            //LoadInvestors(-1);
            //ddlInvestor.SelectedValue = newEntity.InvestorId.ToString();

            //ddlLoanTerm.Enabled = false;
            //ddlComaker.Enabled = false;
            //ddlBorrower.Enabled = false;
            //ddlInvestor.Enabled = false;
            //txtDate.Enabled = false;
            //txtInterest.Enabled = false;
            //this.txtAmount.Enabled = false;
            //txtPeriod.Enabled = false;


        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.loanid == -1)
                {

                    Create();

                }
                else
                {
                    Update();
                }

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            newService.DeleteUser(loanid);


            if (this.userid >= 0) { Response.Redirect("Default.aspx"); } else { Response.Redirect("AdminDefault.aspx"); }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.userid >= 0) { Response.Redirect("Default.aspx"); } else { Response.Redirect("AdminDefault.aspx"); }
            
        }

        

        private void Create()
        {

            newEntity = new LoanEntity();

            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text.Trim());
            newEntity.Period = Convert.ToInt32(txtPeriod.Text.Trim());
            newEntity.TermId = 0;
            newEntity.Date = DateTime.Now;
            newEntity.Interest = 6;
            newEntity.CollateralId = Convert.ToInt32(ddlCollateral.SelectedValue);
            newEntity.CollateralDetails = this.txtCollateralDetails.Text.Trim();
            newEntity.ComakerId = 0;
            newEntity.BorrowerId = this.userid;
            newEntity.InvestorId = 0;
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Penalty = 0;
            newEntity.PenaltyDetails = string.Empty;
            newEntity.Status = 0;

            newService.SaveApplyLoan(ActionType.Create, newEntity);

            Response.Redirect("Default.aspx"); 

        }

        private void Update()
        {
            newEntity = new LoanEntity();
            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text.Trim());
            newEntity.Period = Convert.ToInt32(txtPeriod.Text.Trim());
            newEntity.ID = loanid;
            newEntity.CollateralId = Convert.ToInt32(ddlCollateral.SelectedValue);
            newEntity.CollateralDetails = this.txtCollateralDetails.Text.Trim();
            newEntity.ComakerId = 0;
            newEntity.Date = DateTime.Now; //set dummy value to prevent error
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Penalty = 0;
            newEntity.PenaltyDetails = string.Empty;

            newService.SaveApplyLoan(ActionType.Update, newEntity);

            if (this.userid >= 0) { Response.Redirect("Default.aspx"); } else { Response.Redirect("AdminDefault.aspx"); }

        }


        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (this.userid == -1)
            {
                

                if (Convert.ToDecimal(this.txtAmount.Text) <= 0)
                {
                    errorMsg = errorMsg + "Amount should be greater that zero. ";
                    retVal = false;
                }
            }

            if (Convert.ToInt32(this.ddlCollateral.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Collateral is required. ";
                retVal = false;
            }

            //if (Math.Floor(Convert.ToDecimal(this.txtPeriod.Text)) > 0 && Convert.ToInt32(this.ddlLoanTerm.SelectedValue) == 2)
            //{
            //    errorMsg = errorMsg + "For Period with decimal value, please select Bi-Monthly for the loan term. ";
            //    retVal = false;
            //}

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

        private void SetMessage(string msg)
        {

            HiddenField hdField = (HiddenField)Master.FindControl("hdError");
            if (hdField != null)
            {
                hdField.Value = msg;
            }
        }
    }
}