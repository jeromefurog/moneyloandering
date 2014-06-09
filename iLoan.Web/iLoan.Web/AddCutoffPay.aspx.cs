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
    public partial class AddCutoffPay : System.Web.UI.Page
    {
        private int id = 0;
        
        PayableEntity newEntity = null;
        PayableService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
                {
                    Response.Redirect("Default.aspx");

                }

                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }


                Page.Title = Page.Title + " - " + "Add Payment on Cut-off";
                this.lblTitle.Text = "Payment on Cut-off";

                newEntity = new PayableEntity();
                newService = new PayableService();

                if (!IsPostBack)
                {

                    PopulateFields(id);

                }

            }
            catch (Exception ex) { throw ex; }
        }

        
        private void PopulateFields(int id)
        {


            newEntity = new PayableEntity();
            newEntity = newService.GetSpecificPayment(id);

            txtCutoffDate.Text = newEntity.PayDate.ToShortDateString();
            txtAmount.Text = newEntity.Amount.ToString();
            txtNotes.Text = newEntity.Notes;
            ddlStatus.SelectedValue = newEntity.Status.ToString();
            hdLoanId.Value = newEntity.LoanId.ToString();

            
            

        }

        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (string.IsNullOrEmpty(this.txtCutoffDate.Text))
            {
                errorMsg = errorMsg + "Cut-off Date is required" + "<br />";
                retVal = false;
            }
            else
            {
                if (!Utility.DateValidator(txtCutoffDate.Text.Trim()))
                {
                    errorMsg = errorMsg + "Cut-off Date should be valid" + "<br />";
                    retVal = false;
                }
                else {

                    if (PayableService.DoesCutoffExist(id, Convert.ToInt32(hdLoanId.Value), Convert.ToDateTime(txtCutoffDate.Text)))
                    {
                        errorMsg = errorMsg + "Cut-off date already exists" + "<br />";
                        retVal = false;
                    }
                }

            }

            
            if (this.txtAmount.Text == string.Empty)
            {
                errorMsg = errorMsg + "Amount is required" + "<br />";
                retVal = false;
            }
            else {
                if (!Utility.DecimalValidator(txtAmount.Text.Trim()))
                {
                    errorMsg = errorMsg + "Amount should be valid" + "<br />";
                    retVal = false;
                }
            }

            if (Convert.ToInt32(this.ddlStatus.SelectedValue) == -1)
            {
                errorMsg = errorMsg + "Status is required" + "<br />";
                retVal = false;
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
               
        

        private void Update()
        {
            newEntity = new PayableEntity();
            newEntity.ID = id;
            newEntity.PayDate = Convert.ToDateTime(this.txtCutoffDate.Text);
            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text);
            newEntity.Status = Convert.ToInt32(this.ddlStatus.SelectedValue);
            newEntity.Notes = this.txtNotes.Text.Trim();
                        
            newService.Save(newEntity);

            ClientScript.RegisterStartupScript(this.GetType(), "Save Payment", "alert('Payment is successfully saved');", true);

            Response.Redirect(string.Format("AddPayable.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(hdLoanId.Value))));
                        
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Update();
            }            
            
        }

        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("AddPayable.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(hdLoanId.Value))));
        }
    }
}