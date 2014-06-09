using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iLoan.Core;
using iLoan.Core.Service;


namespace iLoan.Web.UserControls
{
    public partial class WUCHeader : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.hlUsrName.Text = GlobalObjects.AppUser.FirstName + " " + GlobalObjects.AppUser.LastName + " (" + GlobalObjects.AppUser.UserName + ")";
                this.hlUsrName.NavigateUrl = string.Format("~/AddUser.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(GlobalObjects.AppUser.UserID.ToString())));


                if (GlobalObjects.IsAdmin)
                {
                    lblLogoHeader.Text = "iLoan - Administrator";
                }
                else
                {
                    lblLogoHeader.Text = "iLoan";
                }
            }
            
            
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            this.Session.Clear();
            Response.Redirect("Login.aspx");
        }
        
    }
}