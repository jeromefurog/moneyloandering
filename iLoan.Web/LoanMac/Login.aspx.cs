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

namespace LoanMac.Web
{
    public partial class Login : System.Web.UI.Page
    {
        UserService serv = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {


            UserEntity user = serv.Authenticate(this.iUsername.Text.Trim(), this.iPassword.Text.Trim());
            if (user.ID > 0)
            {
                GlobalObjects.SessionKey = System.Guid.NewGuid().ToString();

                Session["userid"] = user.ID;
                Session["sessionkey"] = GlobalObjects.SessionKey;
                                

                if (this.chkRememberMe.Checked)
                {
                    RememberMe(user.UserName);
                }

                
                Response.Redirect("Default.aspx");
            }
            else
            {

                hdError.Value = "You're not authorized to access the portal";
            }


        }

        private void RememberMe(string userNm) {

            
                // Clear any other tickets that are already in the response
                Response.Cookies.Clear();

                // Set the new expiry date - to thirty days from now
                DateTime expiryDate = DateTime.Now.AddDays(1);

                // Create a new forms auth ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, userNm, DateTime.Now, expiryDate, true, String.Empty);

                // Encrypt the ticket
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                // Create a new authentication cookie - and set its expiration date
                HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                authenticationCookie.Expires = ticket.Expiration;

                // Add the cookie to the response.
                Response.Cookies.Add(authenticationCookie);

        
        }
    }

    
}