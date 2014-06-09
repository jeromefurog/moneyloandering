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
    public partial class ChangePassword : System.Web.UI.Page
    {
        int id = 0;
        UserEntity newEntity = new UserEntity();
        UserService newService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                if (!GlobalObjects.IsAdmin && id == -1)
                {
                    Response.Redirect("Default.aspx");

                }

                if (id != -1)
                {
                    PopulateFields(id);                    
                }

                hdId.Value = id.ToString();

            }
            catch (Exception ex) { throw ex; }
            
        }

        private void PopulateFields(int id)
        {
            
            newEntity = new UserEntity();
            newEntity = newService.GetOne(id);

            txtUserName.Text = newEntity.UserName;
                        
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                newService.SetPassword(id, txtNewPassword.Text.Trim());

                if (id == GlobalObjects.User.ID)
                {
                    FormsAuthentication.SignOut();
                    this.Session.Clear();
                    Response.Redirect("Login.aspx");
                }

                SetMessage("Password successfully updated.");
                Response.Redirect(string.Format("NewUser.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.ToString()))));
            }
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("NewUser.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(id.ToString()))));
        }
               
        
        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (txtCurrentPassword.Text.Trim() != newEntity.Password)
            {
                errorMsg = errorMsg + "Current password is not correct";
                retVal = false;
            }

            if (txtNewPassword.Text.Trim() == txtCurrentPassword.Text.Trim())
            {
                errorMsg = errorMsg + "New password should not be the same with current password";
                retVal = false;
            
            } else {
                bool isValid = true;
                if (txtNewPassword.Text == string.Empty)
                {

                    isValid = false;
                }


                if (txtConfirmNewPassword.Text == string.Empty)
                {

                    isValid = false;
                }

                if (isValid)
                {
                    if (txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
                    {
                        errorMsg = errorMsg + "Password does not match";
                        retVal = false;
                    }

                }
            }

            


            if (!retVal)
            {

                SetMessage(errorMsg);     
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
