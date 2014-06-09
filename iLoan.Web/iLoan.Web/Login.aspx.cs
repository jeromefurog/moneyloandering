using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iLoan.Core;
using iLoan.Core.Service;
using iLoan.Core.Model;

namespace iLoan.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string name = string.Empty;
            string password = string.Empty;

            if (txtLoginId.Text == string.Empty)
            {
                dvError.Visible = true;
                lblError.Text = "Username is required";
                return;
            }
            else
            {
                dvError.Visible = false;
                lblError.Text = string.Empty;
                name = txtLoginId.Text.Trim();
            }

            if (txtUserPass.Text == string.Empty)
            {
                lblError.Text = "Password is required";
                dvError.Visible = true;
                return;
            }
            else
            {
                dvError.Visible = false;
                lblError.Text = string.Empty;
                password = txtUserPass.Text.Trim();
            }



            AppUserEntity user = UserService.Authenticate(name, password);
            if (user.UserID > 0)
            {
                GlobalObjects.SessionKey = System.Guid.NewGuid().ToString();

                Session["userid"] = user.UserID;
                Session["sessionkey"] = GlobalObjects.SessionKey;

                Response.Redirect("default.aspx");

                dvError.Visible = false;
                lblError.Text = string.Empty;
            }
            else
            {

                dvError.Visible = true;
                lblError.Text = "You're not authorized to access the portal";
            }
            

        }
    }
}
