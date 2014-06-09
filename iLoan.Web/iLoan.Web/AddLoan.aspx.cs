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
    public partial class AddLoan : System.Web.UI.Page
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
                                

                if (id == -1) { Page.Title = Page.Title + " - " + "Create Loan"; }
                else { Page.Title = Page.Title + " - " + "Update Loan"; }

                newEntity = new LoanEntity();
                newService = new LoanService();

                if (!IsPostBack)
                {

                    LoadBorrower();
                    LoadLoanTerm();
                    LoadCollateral();
                    ddlComaker.Items.Insert(0, new ListItem("-- Select --", "0"));

                    if (id == -1)
                    {
                        this.lblTitle.Text = "Create Loan";
                        this.btnDelete.Visible = false;
                        
                    }
                    else
                    {
                        this.lblTitle.Text = "Edit Loan";
                        this.btnDelete.Visible = true;
                        
                        PopulateFields(id);

                    }


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

            ddlBorrower.SelectedIndex = newEntity.Borrowerid;            
            ddlLoanTerm.SelectedIndex = newEntity.Termid;
            txtPeriod.Text = newEntity.Period.ToString();
            ddlCollateral.SelectedIndex = newEntity.CollateralId;
            txtCollateralDetails.Text = newEntity.CollateralDetails;
            txtInterest.Text = newEntity.Interest.ToString();
            txtDate.Text = newEntity.Loandate.ToString("M/d/yyyy");
            txtNotes.Text = newEntity.Notes;
            txtAmount.Text = newEntity.Amount.ToString();
            

            LoadComaker(newEntity.Borrowerid);
            ddlComaker.SelectedValue = newEntity.Comakerid.ToString();

            ddlBorrower.Enabled = false;
            ddlLoanTerm.Enabled = false;
            ddlBorrower.Enabled = false;
            txtPeriod.Enabled = false;
            txtInterest.Enabled = false;
            txtDate.Enabled = false;
            txtAmount.Enabled = false;
            ddlComaker.Enabled = false;
            

        }

        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (Convert.ToInt32(this.ddlBorrower.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Borrower is required" + "<br />";
                retVal = false;
            }

            if (Convert.ToInt32(this.ddlComaker.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Co-maker is required" + "<br />";
                retVal = false;
            }

            if (Convert.ToInt32(this.ddlLoanTerm.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Loan Term is required" + "<br />";
                retVal = false;
            }

            if (this.txtPeriod.Text == string.Empty)
            {
                errorMsg = errorMsg + "Period is required" + "<br />";
                retVal = false;
            }
            else {
                if (!Utility.NumberValidator(txtPeriod.Text.Trim()))
                {
                    errorMsg = errorMsg + "Period should be valid" + "<br />";
                    retVal = false;
                }
            }

            if (Convert.ToInt32(this.ddlCollateral.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Collateral is required" + "<br />";
                retVal = false;
            }

            if (string.IsNullOrEmpty(this.txtInterest.Text))
            {
                errorMsg = errorMsg + "Interest is required" + "<br />";
                retVal = false;
            }
            else {
                if (!Utility.DecimalValidator(txtInterest.Text.Trim()))
                {
                    errorMsg = errorMsg + "Interest should be valid" + "<br />";
                    retVal = false;
                }
            
            }

            if (string.IsNullOrEmpty(this.txtAmount.Text))
            {
                errorMsg = errorMsg + "Amount is required" + "<br />";
                retVal = false;
            }
            else
            {
                if (!Utility.DecimalValidator(txtAmount.Text.Trim()))
                {
                    errorMsg = errorMsg + "Amount should be valid" + "<br />";
                    retVal = false;
                }

            }

            if (string.IsNullOrEmpty(this.txtDate.Text))
            {
                errorMsg = errorMsg + "Loan Date is required" + "<br />";
                retVal = false;
            }
            else
            {
                if (!Utility.DateValidator(txtDate.Text.Trim()))
                {
                    errorMsg = errorMsg + "Loan Date should be valid" + "<br />";
                    retVal = false;
                }

            }
                      
            
            if (!retVal)
            {
                dvError.Visible = true;
                dvError.InnerHtml = errorMsg;
            }
            else
            {
                dvError.Visible = false;
                dvError.InnerHtml = string.Empty;
                errorMsg = string.Empty;
            }

            return retVal;
        }

        private void ClearFields()
        {
            ddlBorrower.SelectedIndex = 0;
            ddlComaker.SelectedIndex = 0;
            ddlLoanTerm.SelectedIndex = 0;
            txtPeriod.Text = string.Empty;
            ddlCollateral.SelectedIndex = 0;
            txtCollateralDetails.Text = string.Empty;
            txtInterest.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtAmount.Text = string.Empty;
            
            
            dvError.Visible = false;
            dvError.InnerHtml = string.Empty;
        }

        private void Create()
        {

            newEntity = new LoanEntity();
            newEntity.Borrowerid = Convert.ToInt32(ddlBorrower.SelectedValue);
            newEntity.Comakerid = Convert.ToInt32(ddlComaker.SelectedValue);
            newEntity.Termid = Convert.ToInt32(ddlLoanTerm.SelectedValue);
            newEntity.Period = Convert.ToInt32(txtPeriod.Text.Trim());
            newEntity.CollateralId = Convert.ToInt32(ddlCollateral.SelectedValue);
            newEntity.CollateralDetails = this.txtCollateralDetails.Text.Trim();
            newEntity.Comakerid = Convert.ToInt32(ddlComaker.SelectedValue);
            newEntity.Interest = Convert.ToDecimal(this.txtInterest.Text.Trim());
            newEntity.Loandate = Convert.ToDateTime(this.txtDate.Text.Trim());
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text.Trim());
            newEntity.Status = 1;
                       
            newService.Save(ActionType.Create, newEntity);

            ClearFields();

            ClientScript.RegisterStartupScript(this.GetType(), "Create Loan", "alert('Loan is successfully created.');", true);
        }

        private void Update()
        {
            newEntity = new LoanEntity();
            newEntity.CollateralId = Convert.ToInt32(ddlCollateral.SelectedValue);
            newEntity.CollateralDetails = this.txtCollateralDetails.Text.Trim();
            newEntity.Comakerid = Convert.ToInt32(ddlComaker.SelectedValue);
            newEntity.Notes = this.txtNotes.Text.Trim();

            newService.Save(ActionType.Update, newEntity);

            ClientScript.RegisterStartupScript(this.GetType(), "Update Loan", "alert('Loan is successfully updated.');", true);
                        
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
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
            newService.DeleteUser(this.id);
            Response.Redirect("ManageLoan.aspx");
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageLoan.aspx");
        }
    }
}