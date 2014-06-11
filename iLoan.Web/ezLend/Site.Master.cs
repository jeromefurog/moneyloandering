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
using System.Data;

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
                    liExpenses.Visible = false;
                }

                if (GlobalObjects.User.Picture != null)
                {
                    imgPic.Src = string.Format("~/ShowImage.ashx?id={0}", GlobalObjects.User.ID.ToString());
                }
                else
                {
                    
                    imgPic.Src = "~/images/default_pic.png";
                }

                CreateAlerts();

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

        private void CreateAlerts()
        {
            PayableService ser = new PayableService();
            dvAlerts.InnerHtml = string.Empty;
            bool hasOverdue = false;

            // overdue 
            DataTable tb = new DataTable();;
            tb = ser.GetAlerts(1, GlobalObjects.User.ID);

            int counter = 0;
            foreach (DataRow dtRow in tb.Rows)
            {
                counter = counter + 1;

                string loanid = string.Empty;
                string amt = string.Empty;
                string dt = string.Empty;
                string formt = string.Empty;

                hasOverdue = true;

                // on all table's columns
                foreach (DataColumn dc in tb.Columns)
                {
                    if (dc.ColumnName == "loan_id")
                    {
                        loanid = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "amount")
                    {
                        amt = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "date")
                    {
                        dt = dtRow[dc].ToString();
                    }

                }

//                formt = String.Format(@"<div class='alert alert-danger'>
//							    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
//							    <i class='fa fa-warning sign'></i><strong>Warning!</strong> Please settle your overdue payment of <strong>{0}</strong> for Loan:<strong>{1}</strong> on last <strong>{2}</strong> immediately.
//						    </div>", amt, loanid, dt);
                formt = String.Format(@"<li><a href='ViewLoan.aspx?id={3}'><i class='fa fa-warning sign'></i>You have an overdue payment</br>of <b>{0}</b>for Loan:<b>{1}</b><span class='date'>please pay immediately</span></a></li>", amt, loanid, dt, Utility.EncryptQueryString(HttpUtility.UrlEncode(loanid)));
                dvAlerts.InnerHtml = dvAlerts.InnerHtml + formt;
            }

            // thank you
            if (!hasOverdue)
            {
                tb = new DataTable();
                tb = ser.GetAlerts(0, GlobalObjects.User.ID);
                foreach (DataRow dtRow in tb.Rows)
                {
                    counter = counter + 1;

                    string loanid = string.Empty;
                    string amt = string.Empty;
                    string dt = string.Empty;
                    string formt = string.Empty;

                    // on all table's columns
                    foreach (DataColumn dc in tb.Columns)
                    {
                        if (dc.ColumnName == "loan_id")
                        {
                            loanid = dtRow[dc].ToString();
                        }

                        if (dc.ColumnName == "amount")
                        {
                            amt = dtRow[dc].ToString();
                        }

                        if (dc.ColumnName == "date")
                        {
                            dt = dtRow[dc].ToString();
                        }

                    }

//                    formt = String.Format(@"<div class='alert alert-success'>
//							    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button> 
//							    <i class='fa fa-check sign'></i><strong>Thank You!</strong> Your last payment of <strong>{0}</strong> for Loan:<strong>{1}</strong> on <strong>{2}</strong> was received.
//						    </div>", amt, loanid, dt);
                    formt = String.Format(@"<li><a href='ViewLoan.aspx?id={3}'><i class='fa fa-check sign'></i>Thank you for your payment</br>of <b>{0}</b> for Loan:<b>{1}</b><span class='date'>received last {2}</span></a></li>", amt, loanid, dt, Utility.EncryptQueryString(HttpUtility.UrlEncode(loanid)));
                    dvAlerts.InnerHtml = dvAlerts.InnerHtml + formt;
                }

            }


            // next 
            tb = new DataTable();
            tb = ser.GetAlerts(2, GlobalObjects.User.ID);
            foreach (DataRow dtRow in tb.Rows)
            {
                counter = counter + 1;

                string loanid = string.Empty;
                string amt = string.Empty;
                string dt = string.Empty;
                string formt = string.Empty;

                // on all table's columns
                foreach (DataColumn dc in tb.Columns)
                {
                    if (dc.ColumnName == "loan_id")
                    {
                        loanid = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "amount")
                    {
                        amt = dtRow[dc].ToString();
                    }

                    if (dc.ColumnName == "date")
                    {
                        dt = dtRow[dc].ToString();
                    }

                }

//                formt = String.Format(@"<div class='alert alert-info'>
//							    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
//							    <i class='fa fa-info-circle sign'></i><strong>Info!</strong> Your next payment of <strong>{0}</strong> for Loan:<strong>{1}</strong> is due on <strong>{2}</strong>.
//						    </div>", amt, loanid, dt);
                formt = String.Format(@"<li><a href='ViewLoan.aspx?id={3}'><i class='fa fa-info-circle sign'></i>Your next payment for</br>Loan:<b>{1}</b> is <b>{0}</b><span class='date'>due on {2}</span></a></li>", amt, loanid, dt, Utility.EncryptQueryString(HttpUtility.UrlEncode(loanid)));

                dvAlerts.InnerHtml = dvAlerts.InnerHtml + formt;
            }

            if (counter > 0) { lblCount.Text = counter.ToString(); } else { ulAlerts.Visible = false; }
            

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