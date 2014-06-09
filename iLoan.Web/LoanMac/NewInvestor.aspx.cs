using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;
using System.Web.Security;

namespace LoanMac.Web
{
    public partial class NewInvestor : System.Web.UI.Page
    {
        int id = 0;
        InvestorEntity newEntity = new InvestorEntity();
        InvestorService newService = new InvestorService();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null) { Response.Redirect("Default.aspx"); } else { this.id = Convert.ToInt32(Utility.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["id"]))); }

                if (!GlobalObjects.IsAdmin && id == -1)
                {
                    Response.Redirect("Default.aspx");

                }

                if (!IsPostBack)
                { 
                    LoadUsers();

                    if (id != -1)
                    {
                        PopulateFields(id);
                    }

                    hdId.Value = id.ToString();
                }

                

            }
            catch (Exception ex) { throw ex; }
            
        }

        private void LoadUsers()
        {
            UserService usrSrv = new UserService();

            DataTable oTable = usrSrv.GetUsersForDropdown();
            ddlUser.DataSource = oTable;
            ddlUser.DataTextField = "desc";
            ddlUser.DataValueField = "id";
            ddlUser.DataBind();

            ddlUser.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlUser.SelectedIndex = 0;

        }

        private void PopulateFields(int id)
        {

            newEntity = new InvestorEntity();
            newEntity = newService.GetOne(id);

            UserEntity usrEnt = new UserEntity();
            UserService usrSrv = new UserService();
            usrEnt = usrSrv.GetOne(newEntity.UserId);

            txtAmount.Text = newEntity.Amount.ToString();
            txtNotes.Text = newEntity.Notes;
            ddlUser.SelectedValue = newEntity.UserId.ToString();           
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
                {

                    Create();

                }
                else {
                    Update();
                }
                
            }
        }

                        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageInvestors.aspx");
        }

        private void Create()
        {

            newEntity = new InvestorEntity();
            newEntity.UserId = Convert.ToInt32(ddlUser.SelectedValue);
            newEntity.Notes = txtNotes.Text;
            newEntity.Amount = Convert.ToDecimal(txtAmount.Text);
            
            newService.Save(ActionType.Create, newEntity);
            
            Response.Redirect("ManageInvestors.aspx");
            
        }

        private void Update()
        {

            newEntity = new InvestorEntity();
            newEntity.ID = id;
            newEntity.Notes = txtNotes.Text;
            newEntity.Amount = Convert.ToDecimal(txtAmount.Text);

            newService.Save(ActionType.Update, newEntity);

            Response.Redirect("ManageInvestors.aspx");

        }             

        
        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;

            if (id == -1)
            {
                if (Convert.ToInt32(ddlUser.SelectedValue) <= 0)
                {
                    errorMsg = errorMsg + "Please select user";
                    retVal = false;
                }     
            }                  

            if (!retVal)
            {

                SetMessage(errorMsg);
            }
            else
            {
                SetMessage(string.Empty);
            }
            
            return retVal;
        }

        private void SetMessage(string msg) {

            HiddenField hdField = (HiddenField)Master.FindControl("hdError");
            if (hdField != null)
            {
                hdField.Value = msg;
            }   
        }

        
    }
}
