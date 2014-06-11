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
    public partial class ForgetPassword : System.Web.UI.Page
    {
        UserService serv = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            serv = new UserService();

            string email = txtEmail.Text.Trim();
            string password = serv.GetPassword(email);

            if (String.IsNullOrEmpty(password))
            {
                ClientScript.RegisterStartupScript(GetType(), "UserMsg", "<script>alert('Oooppss, email does not exist yet...');if(alert){ window.location='ForgetPassword.aspx';}</script>");
                
                
            } else {
                string body = string.Format(@"<p>Hi there old champ,</p> 
                            <p>Here is you precious password that you seem to forgot: <strong>{0}</strong></p> 
                            <p>Please don't forget it again, ok? Good, have a nice day!</p>
                            <p>Thanks!</p>", password);

                Utility.Send("MoneyLoandering.com - Forgot Password", body, email, true);

                ClientScript.RegisterStartupScript(GetType(), "UserMsg", "<script>alert('Password Successfully Sent. Please check your email for the password.');if(alert){ window.location='Login.aspx';}</script>");
                
                
            }            


        }

        protected void cancel_Click(object sender, EventArgs e)
        {



            //hdError.Value = "You're not authorized to access the portal";
            Response.Redirect("Login.aspx");

        }

        private void RememberMe(string userNm)
        {


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