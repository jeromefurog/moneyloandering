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
    public partial class Profile : System.Web.UI.Page
    {
        int id = 0;
        UserEntity newEntity = new UserEntity();
        UserService newService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                
                if (id == -1)
                {
                    Response.Redirect("Default.aspx");

                }

                if (!IsPostBack)
                {

                    PopulateFields(id);
                }

                                

            }
            catch (Exception ex) { throw ex; }

        }

        private void PopulateFields(int id)
        {

            newEntity = new UserEntity();
            newEntity = newService.GetOne(id);

            lblUserName.Text = "(" + newEntity.UserName + ")";
            lblName.Text = newEntity.FirstName + " " + newEntity.LastName;            
            lblEmail.Text = newEntity.Email;
            lblMobile.Text = newEntity.PhoneNo;
            //txtNotes.Text = newEntity.Notes;

            if (newEntity.Picture != null)
            {
                imPicture.ImageUrl = string.Format("~/ShowImage.ashx?id={0}", id.ToString());
            }
            else
            {
                imPicture.ImageUrl = "~/images/default_pic.png";
            }

            if (GlobalObjects.IsAdmin)
            {
                btnEdit.Visible = true;
            }
            else {
                btnEdit.Visible = false;
            }

        }
               

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("NewUser.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(this.id.ToString()))));
        }

        
    }
}