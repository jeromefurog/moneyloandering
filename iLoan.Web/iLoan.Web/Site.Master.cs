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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private AppUserEntity appUser = new AppUserEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            if (Session["sessionkey"] == null || Session["sessionkey"].ToString() != GlobalObjects.SessionKey)
            {
                Response.Redirect("Login.aspx");

            }   

        }

        protected void Page_Init(object sender, EventArgs e)
        {


            if (Session["sessionkey"] == null || Session["sessionkey"].ToString() != GlobalObjects.SessionKey)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                int userId = (int)Session["userid"];

                appUser = UserService.GetAppUser(userId);
                GlobalObjects.AppUser = appUser;
                if (appUser.Role == GlobalObjects.Role.Administrator)
                {
                    GlobalObjects.IsAdmin = true;
                }
                else
                {
                    GlobalObjects.IsAdmin = false;
                }

            }

        }
    }
}
