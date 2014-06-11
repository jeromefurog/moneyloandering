using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;
using System.Web.Security;

namespace ezLend
{
    public partial class NewUser : System.Web.UI.Page
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

                if (!GlobalObjects.IsAdmin)
                {
                    hdAdmin.Value = "1";
                    Response.Redirect("Default.aspx");

                }
                else {
                    hdAdmin.Value = "0";                    
                }

                if (!IsPostBack)
                {

                    if (id != -1)
                    {
                        PopulateFields(id);
                    }
                    else
                    {
                        //imPicture.ImageUrl = "~/img/default_pic.png";
                    }

                    hdId.Value = id.ToString();
                }



            }
            catch (Exception ex) { throw ex; }

        }

        private void PopulateFields(int id)
        {

            newEntity = new UserEntity();
            newEntity = newService.GetOne(id);

            txtUserName.Text = newEntity.UserName;
            chkAdmin.Checked = newEntity.IsAdmin;
            txtFirstName.Text = newEntity.FirstName;
            txtLastName.Text = newEntity.LastName;
            txtEmail.Text = newEntity.Email;
            txtMobile.Text = newEntity.PhoneNo;
            txtNotes.Text = newEntity.Notes;

            if (newEntity.Picture != null)
            {
                //imPicture.ImageUrl = string.Format("~/ShowImage.ashx?id={0}", id.ToString());
            }
            else
            {
                //imPicture.ImageUrl = "~/img/default_pic.png";
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
                {

                    if (!newService.DoesUserExist(this.txtUserName.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim()))
                    {
                        Create();
                    }
                    else
                    {

                        SetMessage("Cannot add user. User Name, First Name or Last Name already exists.");
                    }


                }
                else
                {
                    Update();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (newService.CanDelete(id))
            {
                newService.DeleteUser(id);

                if (id == GlobalObjects.User.ID)
                {
                    FormsAuthentication.SignOut();
                    this.Session.Clear();
                    Response.Redirect("Login.aspx");
                }

                Response.Redirect("ManageUsers.aspx");
            }
            else
            {
                SetMessage("Cannot delete user. User is used in other records.");
            }


        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ChangePassword.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(this.id.ToString()))));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUsers.aspx");
        }

        private void Create()
        {

            newEntity = new UserEntity();
            newEntity.UserName = this.txtUserName.Text.Trim();
            newEntity.Password = this.txtPassword.Text.Trim();
            newEntity.FirstName = txtFirstName.Text.Trim();
            newEntity.LastName = txtLastName.Text.Trim();
            newEntity.Email = txtEmail.Text.Trim();
            newEntity.Notes = txtNotes.Text.Trim();
            newEntity.PhoneNo = this.txtMobile.Text.Trim();
            newEntity.IsAdmin = chkAdmin.Checked;

            if (this.fuImage.HasFile && fuImage.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = fuImage.PostedFile;
                //Create byte Array with file len
                newEntity.Picture = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(newEntity.Picture, 0, File.ContentLength);
            }

            newService.Save(ActionType.Create, newEntity);

            SetMessage("User successfully added");
            ClearFields();
            //Response.Redirect("ManageUsers.aspx");

        }

        private void Update()
        {

            newEntity = new UserEntity();
            newEntity.ID = id;
            newEntity.UserName = string.Empty;
            newEntity.Password = string.Empty;
            newEntity.FirstName = string.Empty;
            newEntity.LastName = string.Empty;
            newEntity.Email = txtEmail.Text.Trim();
            newEntity.Notes = txtNotes.Text.Trim();
            newEntity.PhoneNo = this.txtMobile.Text.Trim();
            newEntity.IsAdmin = chkAdmin.Checked;

            if (this.fuImage.HasFile && fuImage.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = fuImage.PostedFile;
                //Create byte Array with file len
                newEntity.Picture = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(newEntity.Picture, 0, File.ContentLength);
            }

            newService.Save(ActionType.Update, newEntity);

            SetMessage("User successfully updated");
            //Response.Redirect("ManageUsers.aspx");

        }

        private void ClearFields()
        {

            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNotes.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            chkAdmin.Checked = false;

        }

        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (this.fuImage.HasFile && fuImage.PostedFile != null)
            {
                if (!Utility.PictureValidator(fuImage.FileName))
                {
                    errorMsg = errorMsg + "Image is not valid" + "<br />";
                    retVal = false;
                }
            }

            if (id == -1)
            {
                bool isValid = true;
                if (txtPassword.Text == string.Empty)
                {

                    isValid = false;
                }


                if (txtConfirmPassword.Text == string.Empty)
                {

                    isValid = false;
                }

                if (isValid)
                {
                    if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
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