using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iLoan.Core;
using iLoan.Core.Model;
using iLoan.Core.Service;
using System.Web.Security;

namespace iLoan.Web
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private int id = 0;
        private string password = string.Empty;

        AppUserEntity newEntity = null;
        UserService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                if (id <= 0) { Response.Redirect("Default.aspx"); }

                Page.Title = Page.Title + " - " + "Change Password";

                newEntity = new AppUserEntity();
                newService = new UserService();


                this.lblTitle.Text = "Change Password";

                PopulateFields(id);

            }
            catch (Exception ex) { throw ex; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Update();
            }
        }

        private void Update()
        {
            newEntity = new AppUserEntity();
            newEntity.UserID = this.id;
            newEntity.Password = this.txtPassword1.Text.Trim();

            newService.UpdatePassword(newEntity);

            ClientScript.RegisterStartupScript(this.GetType(), "Update Password", "alert('Password is successfully updated.');", true);

            if (this.id == GlobalObjects.AppUser.UserID)
            {
                FormsAuthentication.SignOut();
                this.Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }

        private void PopulateFields(int id)
        {
            
            newEntity = new AppUserEntity();
            newEntity = newService.GetSpecificUser(id);

            password = newEntity.Password;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUser.aspx");
        }


        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (this.txtCurrentPassword.Text == string.Empty)
            {
                errorMsg = errorMsg + "Current Password is required" + "<br />";
                retVal = false;
                
            }

            bool isValid = true;
            if (txtPassword1.Text == string.Empty)
            {
                errorMsg = errorMsg + "Password is required" + "<br />";
                retVal = false;
                isValid = false;
            }


            if (txtPassword2.Text == string.Empty)
            {
                errorMsg = errorMsg + "Please re-type password" + "<br />";
                retVal = false;
                isValid = false;
            }

            if (isValid)
            {
                if (txtPassword1.Text.Trim() != txtPassword2.Text.Trim())
                {
                    errorMsg = errorMsg + "Password does not match" + "<br />";
                    retVal = false;
                }
                else {

                    if (this.txtCurrentPassword.Text != this.password)
                    {
                        errorMsg = errorMsg + "Current Password is not valid." + "<br />";
                        retVal = false;
                        isValid = false;
                    }
                    else {

                        if (txtPassword1.Text == newEntity.Password)
                        {
                            errorMsg = errorMsg + "Password should be different from the existing password." + "<br />";
                            retVal = false;
                            isValid = false;
                        }
                    }
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
    }
}