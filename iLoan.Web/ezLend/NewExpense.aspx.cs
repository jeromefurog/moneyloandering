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
    public partial class NewExpense : System.Web.UI.Page
    {
        int id = 0;
        WithdrawalEntity newEntity = new WithdrawalEntity();
        WithdrawalService newService = new WithdrawalService();

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


            newEntity = new WithdrawalEntity();
            newEntity = newService.GetOne(id);


            this.txtDate.Text = newEntity.Date.ToString("yyyy-MM-dd");
            this.txtNotes.Text = newEntity.Notes;
            this.txtAmount.Text = newEntity.Amount.ToString();


            

            //ddlInvestor.Enabled = false;
            //txtDate.Enabled = false;
            //this.txtAmount.Enabled = false;


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



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageExpenses.aspx");
        }

                

        private void Create()
        {

            newEntity = new WithdrawalEntity();

            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text.Trim());
            newEntity.Date = Convert.ToDateTime(this.txtDate.Text.Trim());
            newEntity.Userid = GlobalObjects.User.ID;
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Status = 1;

            newService.Save(ActionType.Create, newEntity,1);

            Response.Redirect("ManageExpenses.aspx");

        }

        private void Update()
        {
            newEntity = new WithdrawalEntity();

            newEntity.ID = id;
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Date = Convert.ToDateTime(txtDate.Text);
            newService.Save(ActionType.Update, newEntity);

            Response.Redirect("ManageExpenses.aspx");

        }


        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

                       

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