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
    public partial class PayLoan : System.Web.UI.Page
    {
        int id = 0;
        PayableEntity newEntity = new PayableEntity();
        PayableService newService = new PayableService();

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

                    if (id != -1)
                    {
                        PopulateFields(id);
                    }


                }



            }
            catch (Exception ex) { throw ex; }

        }



        private void PopulateFields(int id)
        {


            newEntity = new PayableEntity();
            newEntity = newService.GetOne(id);

            txtLoanId.Text = newEntity.LoanId.ToString();
            txtAmount.Text = "Php " + newEntity.Amount.ToString();
            txtDate.Text = newEntity.PayDate.ToString("yyyy-MM-dd");
            txtNotes.Text = newEntity.Notes;
            ddlStatus.SelectedValue = newEntity.Status.ToString();

            if (newEntity.Status == 1)
            {
                
                //ddlStatus.Enabled = false;
            }


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
            Response.Redirect(string.Format("ViewLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(txtLoanId.Text))));
        }

        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (string.IsNullOrEmpty(this.txtDate.Text))
            {
                errorMsg = errorMsg + "Cut-off Date is required";
                retVal = false;
            }
            else
            {
                if (!Utility.DateValidator(txtDate.Text.Trim()))
                {
                    errorMsg = errorMsg + "Cut-off Date should be valid";
                    retVal = false;
                }
                else
                {

                    if (newService.DoesCutoffExist(id, Convert.ToInt32(txtLoanId.Text), Convert.ToDateTime(txtDate.Text)))
                    {
                        errorMsg = errorMsg + "Cut-off date already exists";
                        retVal = false;
                    }
                }

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

        private void SetMessage(string msg)
        {

            HiddenField hdField = (HiddenField)Master.FindControl("hdError");
            if (hdField != null)
            {
                hdField.Value = msg;
            }
        }


        private void Update()
        {
            newEntity = new PayableEntity();
            newEntity.ID = id;
            newEntity.Notes = txtNotes.Text;
            newEntity.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            newEntity.PayDate = Convert.ToDateTime(txtDate.Text);

            newService.Save(ActionType.Update, newEntity);

            Response.Redirect(string.Format("ViewLoan.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(txtLoanId.Text))));

        }  
    }
}