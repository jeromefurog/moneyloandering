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
    public partial class AddBorrower : System.Web.UI.Page
    {
        private int id = 0;

        BorrowerEntity newEntity = null;
        BorrowerService newService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (GlobalObjects.AppUser.Role == GlobalObjects.Role.Viewer)
                {
                    Response.Redirect("Default.aspx");

                }

                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }
                                

                if (id == -1) { Page.Title = Page.Title + " - " + "Create Borrower"; }
                else { Page.Title = Page.Title + " - " + "Update Borrower"; }

                newEntity = new BorrowerEntity();
                newService = new BorrowerService();

                if (!IsPostBack)
                {
                    
                    if (id == -1)
                    {
                        this.lblTitle.Text = "Create User";
                        this.btnDelete.Visible = false;

                        imgPicture.ImageUrl = "~/img/default_pic.png";
                    }
                    else
                    {
                        this.lblTitle.Text = "Edit User";
                        this.btnDelete.Visible = true;
                        
                        PopulateFields(id);

                    }


                }

            }
            catch (Exception ex) { throw ex; }
        }

        private void PopulateFields(int id)
        {
            this.txtFirstName.Enabled = false;
            this.txtLastName.Enabled = false;

            newEntity = new BorrowerEntity();
            newEntity = newService.GetSpecific(id);

            this.txtFirstName.Text = newEntity.FirstName;            
            txtLastName.Text = newEntity.LastName;
            this.txtBirthDay.Text = newEntity.BirthDay.ToString("MM/dd/yyyy");       
            txtEmail.Text = newEntity.Email;
            this.txtAddress.Text = newEntity.HomeAddress;
            this.txtPhoneNo.Text = newEntity.HomePhoneNo;
            this.txtCompany.Text = newEntity.Company;
            this.txtCompanyAddress.Text = newEntity.CompanyAddress;
            this.txtCompanyPhoneNo.Text = newEntity.CompanyPhoneNo;            
            ddlStatus.SelectedValue = newEntity.Status.ToString();

            if (newEntity.Picture != null)
            {
                imgPicture.ImageUrl = string.Format("~/ShowImage.ashx?id={0}", id.ToString());
            }
            else {
                imgPicture.ImageUrl = "~/img/default_pic.png";
            }

        }

        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (this.fuImage.HasFile && fuImage.PostedFile != null)
            {
                if (!Utility.PictureValidator(fuImage.FileName)) {
                    errorMsg = errorMsg + "Image is not valid" + "<br />";
                    retVal = false;
                }
            }

            if (this.txtFirstName.Text == string.Empty)
            {
                errorMsg = errorMsg + "First Name is required" + "<br />";
                retVal = false;
            }

            if (this.txtLastName.Text == string.Empty)
            {
                errorMsg = errorMsg + "Last Name is required" + "<br />";
                retVal = false;
            }

            if (this.txtAddress.Text == string.Empty)
            {
                errorMsg = errorMsg + "Home Address is required" + "<br />";
                retVal = false;
            }

            if (string.IsNullOrEmpty(this.txtBirthDay.Text))
            {
                errorMsg = errorMsg + "Bithday is required" + "<br />";
                retVal = false;
            }
            else
            {
                if (!Utility.DateValidator(txtBirthDay.Text.Trim()))
                {
                    errorMsg = errorMsg + "Bithday should be valid" + "<br />";
                    retVal = false;
                }

            }

            if (this.txtPhoneNo.Text == string.Empty)
            {
                errorMsg = errorMsg + "Home Phone No is required" + "<br />";
                retVal = false;
            }

            if (this.txtCompany.Text == string.Empty)
            {
                errorMsg = errorMsg + "Company is required" + "<br />";
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

        private void ClearFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBirthDay.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtCompanyAddress.Text = string.Empty;
            txtCompanyPhoneNo.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;

            dvError.Visible = false;
            dvError.InnerHtml = string.Empty;
        }

        private void Create()
        {

            newEntity = new BorrowerEntity();
            newEntity.FirstName = this.txtFirstName.Text.Trim();
            newEntity.LastName = this.txtLastName.Text.Trim();
            newEntity.BirthDay = Convert.ToDateTime(this.txtBirthDay.Text.Trim());
            newEntity.Email = txtEmail.Text.Trim();
            newEntity.HomeAddress = this.txtAddress.Text.Trim();
            newEntity.HomePhoneNo = this.txtPhoneNo.Text.Trim();
            newEntity.Company = this.txtCompany.Text.Trim();
            newEntity.CompanyAddress = this.txtCompanyAddress.Text.Trim();
            newEntity.CompanyPhoneNo = this.txtCompanyPhoneNo.Text.Trim();
            newEntity.Status = Convert.ToInt32(ddlStatus.SelectedValue);

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

            ClearFields();

            ClientScript.RegisterStartupScript(this.GetType(), "Create Borrower", "alert('Borrower is successfully created.');", true);
        }

        private void Update()
        {
            newEntity = new BorrowerEntity();
            newEntity.ID = this.id;
            newEntity.FirstName = this.txtFirstName.Text.Trim();
            newEntity.LastName = this.txtLastName.Text.Trim();
            newEntity.BirthDay = Convert.ToDateTime(this.txtBirthDay.Text.Trim());
            newEntity.Email = txtEmail.Text.Trim();
            newEntity.HomeAddress = this.txtAddress.Text.Trim();
            newEntity.HomePhoneNo = this.txtPhoneNo.Text.Trim();
            newEntity.Company = this.txtCompany.Text.Trim();
            newEntity.CompanyAddress = this.txtCompanyAddress.Text.Trim();
            newEntity.CompanyPhoneNo = this.txtCompanyPhoneNo.Text.Trim();
            newEntity.Status = Convert.ToInt32(ddlStatus.SelectedValue);

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

            ClientScript.RegisterStartupScript(this.GetType(), "Update Borrower", "alert('Borrower is successfully updated.');", true);
                        
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
                {

                    if (!BorrowerService.DoesBorrowerExist(this.txtFirstName.Text.Trim(),this.txtLastName.Text.Trim()))
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
            if (BorrowerService.IsBorrowerUtilized(this.id))
            {
                dvError.Visible = true;
                dvError.InnerHtml = "Cannot delete borrower. borrower is used by other records.";
            }
            else
            {

                newService.DeleteUser(this.id);
                Response.Redirect("ManageBorrower.aspx");

            }

            
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBorrower.aspx");
        }
    }
}