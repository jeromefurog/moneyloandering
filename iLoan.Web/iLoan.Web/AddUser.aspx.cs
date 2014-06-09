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
    public partial class AddUser : System.Web.UI.Page
    {
        private int id = 0;

        AppUserEntity newEntity = null;
        UserService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                if (GlobalObjects.AppUser.Role != GlobalObjects.Role.Administrator && id == -1)
                {
                    Response.Redirect("Default.aspx");

                }

                if (id == -1) { Page.Title = Page.Title + " - " + "Create Users"; }
                else { Page.Title = Page.Title + " - " + "Update Users"; }

                newEntity = new AppUserEntity();
                newService = new UserService();

                if (!IsPostBack)
                {
                    LoadRoles();
                    
                    if (id == -1)
                    {
                        this.lblTitle.Text = "Create User";
                        this.btnDelete.Visible = false;
                        this.btnChangePassword.Visible = false;
                        this.dvPass1.Visible = true;
                        this.dvPass2.Visible = true;
                    }
                    else
                    {
                        this.lblTitle.Text = "Edit User";
                        this.btnDelete.Visible = true;
                        this.btnChangePassword.Visible = true;
                        this.dvPass1.Visible = false;
                        this.dvPass2.Visible = false;

                        PopulateFields(id);

                    }


                }

            }
            catch (Exception ex) { throw ex; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
                {
                    
                    if (!UserService.DoesUserExist(this.txtUserName.Text.Trim()))
                    {
                        Create();
                    }
                    else
                    {

                        dvError.Visible = true;
                        dvError.InnerHtml = "Cannot add user. User Name already exists.";
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
            newService.DeleteUser(this.id);

            if (this.id == GlobalObjects.AppUser.UserID)
            {
                FormsAuthentication.SignOut();
                this.Session.Clear();
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("ManageUser.aspx");
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ChangePassword.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(this.id.ToString()))));
        }

        private void Create()
        {

            newEntity = new AppUserEntity();
            newEntity.UserName = this.txtUserName.Text.Trim();
            newEntity.Password = this.txtPassword1.Text.Trim();
            newEntity.FirstName = txtFirstName.Text.Trim();
            newEntity.LastName = txtLastName.Text.Trim();
            newEntity.Email = txtEmail.Text.Trim();
            newEntity.Role = GlobalObjects.SetRole(Convert.ToInt32(ddlUserRole.SelectedValue));
            newEntity.PhoneNo = txtPhoneNo.Text.Trim();
            newEntity.Status = Convert.ToInt32(ddlStatus.SelectedValue);

            newService.Save(ActionType.Create, newEntity);

            ClearFields();

            ClientScript.RegisterStartupScript(this.GetType(), "Create User", "alert('User is successfully created.');", true);
        }

        private void Update()
        {
            newEntity = new AppUserEntity();
            newEntity.UserID = this.id;
            newEntity.FirstName = txtFirstName.Text.Trim();
            newEntity.LastName = txtLastName.Text.Trim();
            newEntity.Email = txtEmail.Text.Trim();
            newEntity.Role = GlobalObjects.SetRole(Convert.ToInt32(ddlUserRole.SelectedValue));
            newEntity.PhoneNo = txtPhoneNo.Text.Trim();
            newEntity.Status = Convert.ToInt32(ddlStatus.SelectedValue);

            newService.Save(ActionType.Update, newEntity);

            ClientScript.RegisterStartupScript(this.GetType(), "Update User", "alert('User is successfully updated.');", true);

            if (this.id == GlobalObjects.AppUser.UserID && newEntity.Status == 0)
            {
                FormsAuthentication.SignOut();
                this.Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }

        private void ClearFields()
        {
            txtUserName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword1.Text = string.Empty;
            txtPassword2.Text = string.Empty;
            ddlUserRole.SelectedIndex = 0;
            txtPhoneNo.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;

            dvError.Visible = false;
            dvError.InnerHtml = string.Empty;
        }

        private void LoadRoles()
        {

            DataTable oTable = UserService.GetRoles();
            ddlUserRole.DataSource = oTable;
            ddlUserRole.DataTextField = "desc";
            ddlUserRole.DataValueField = "id";
            ddlUserRole.DataBind();
            ddlUserRole.Items.Insert(0, new ListItem("-- Select --", "0"));

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUser.aspx");
        }

        private void PopulateFields(int id)
        {
            this.txtUserName.Enabled = false;

            newEntity = new AppUserEntity();
            newEntity = newService.GetSpecificUser(id);

            txtUserName.Text = newEntity.UserName;
            txtFirstName.Text = newEntity.FirstName;
            txtLastName.Text = newEntity.LastName;
            txtEmail.Text = newEntity.Email;
            txtPhoneNo.Text = newEntity.PhoneNo;
            ddlUserRole.SelectedValue = ((int)newEntity.Role).ToString();
            ddlStatus.SelectedValue = newEntity.Status.ToString();

        }

        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (txtUserName.Text == string.Empty)
            {
                errorMsg = errorMsg + "User Name is required" + "<br />";
                retVal = false;
            }

            if (id == -1)
            {
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

                if (isValid) {
                    if (txtPassword1.Text.Trim() != txtPassword2.Text.Trim())
                    {
                        errorMsg = errorMsg + "Password does not match" + "<br />";
                        retVal = false;                        
                    }
                
                }
               
            }
            

            if (txtFirstName.Text == string.Empty)
            {
                errorMsg = errorMsg + "First Name is required" + "<br />";
                retVal = false;
            }

            if (txtEmail.Text == string.Empty)
            {
                errorMsg = errorMsg + "Email is required" + "<br />";
                retVal = false;
            }
            else
            {
                if (!Utility.EmailValidator(txtEmail.Text.ToString().Trim()))
                {
                    errorMsg = errorMsg + "Email is not valid" + "<br />";
                    retVal = false;
                }

            }

            if (this.txtPhoneNo.Text == string.Empty)
            {
                errorMsg = errorMsg + "Phone No is required" + "<br />";
                retVal = false;
            }

            if (ddlUserRole.SelectedIndex < 1)
            {
                errorMsg = errorMsg + "Please select User Role" + "<br />";
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
    }
}