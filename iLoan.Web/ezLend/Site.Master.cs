using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoanMac.Core;
using LoanMac.Core.Service;
using LoanMac.Core.Model;
using System.Web.Security;

namespace ezLend
{
    public partial class Site : System.Web.UI.MasterPage
    {
        UserEntity ent = new UserEntity();
        UserService serv = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["sessionkey"] == null || Session["sessionkey"].ToString() != GlobalObjects.SessionKey)
            //{
            //    Response.Redirect("Login.aspx");

            //}

            if (Session["userid"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (!IsPostBack)
            {

                spUserName.InnerText = GlobalObjects.User.FirstName + " " + GlobalObjects.User.LastName;

                if (!GlobalObjects.IsAdmin)
                {
                    liUsers.Visible = false;
                    liInvestments.Visible = false;
                    liLoans.Visible = false;
                    liPayables.Visible = false;
                    liWithdrawals.Visible = false;
                    liAdminDashboard.Visible = false;
                }

                if (GlobalObjects.User.Picture != null)
                {
                    imgPic.Src = string.Format("~/ShowImage.ashx?id={0}", GlobalObjects.User.ID.ToString());
                }
                else
                {
                    
                    imgPic.Src = "~/images/default_pic.png";
                }

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {


            if (Session["userid"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                int userId = (int)Session["userid"];

                ent = serv.GetOne(userId);
                GlobalObjects.User = ent;
                if (ent.IsAdmin)
                {
                    GlobalObjects.IsAdmin = true;
                }
                else
                {
                    GlobalObjects.IsAdmin = false;
                }

            }

        }

        protected void aLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            this.Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void aProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Profile.aspx?id={0}", Utility.EncryptQueryString(HttpUtility.UrlEncode(GlobalObjects.User.ID.ToString()))));
        }
    }
}