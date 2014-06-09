using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;
using System.Data;


namespace ezLend
{
    public partial class NewWithdrawal : System.Web.UI.Page
    {
        int id = 0;
        WithdrawalEntity newEntity = new WithdrawalEntity();
        WithdrawalService newService = new WithdrawalService();

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
                    LoadInvestors(0);

                    if (id != -1)
                    {
                        PopulateFields(id);
                    }

                    hdId.Value = id.ToString();
                }



            }
            catch (Exception ex) { throw ex; }

        }

        private void LoadInvestors(int id)
        {

            DataTable oTable = newService.GetInvestors(id);

            if (id == 0)
            {

                oTable.DefaultView.RowFilter = " amount > 0 ";
            }

            ddlInvestor.DataSource = oTable.DefaultView;
            ddlInvestor.DataTextField = "name";
            ddlInvestor.DataValueField = "id";
            ddlInvestor.DataBind();

            ddlInvestor.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlInvestor.SelectedIndex = 0;

        }


        private void PopulateFields(int id)
        {


            newEntity = new WithdrawalEntity();
            newEntity = newService.GetOne(id);


            this.txtDate.Text = newEntity.Date.ToString("yyyy-MM-dd");
            this.txtNotes.Text = newEntity.Notes;
            this.txtAmount.Text = newEntity.Amount.ToString();


            LoadInvestors(-1);
            ddlInvestor.SelectedValue = newEntity.Userid.ToString();


            //ddlInvestor.Enabled = false;
            //txtDate.Enabled = false;
            //this.txtAmount.Enabled = false;


        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (this.id == -1)
                {

                    Create();

                }
                else
                {
                    Update();
                }

            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageWithdrawals.aspx");
        }


        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlInvestor.SelectedValue);

            if (id > 0)
            {
                DataTable oTable = newService.GetInvestors(id);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    string amt = oRow["amount"].ToString();
                    hdTotalAmount.Value = string.Format("{0}", amt);
                }
            }
            else
            {

                hdTotalAmount.Value = string.Empty;
                txtAmount.Text = string.Empty;
            }
        }

        private void Create()
        {

            newEntity = new WithdrawalEntity();

            newEntity.Amount = Convert.ToDecimal(this.txtAmount.Text.Trim());
            newEntity.Date = Convert.ToDateTime(this.txtDate.Text.Trim());
            newEntity.Userid = Convert.ToInt32(ddlInvestor.SelectedValue);
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Status = 1;

            newService.Save(ActionType.Create, newEntity);

            Response.Redirect("ManageWithdrawals.aspx");

        }

        private void Update()
        {
            newEntity = new WithdrawalEntity();

            newEntity.ID = id;
            newEntity.Notes = this.txtNotes.Text.Trim();
            newEntity.Date = Convert.ToDateTime(txtDate.Text);
            newService.Save(ActionType.Update, newEntity);

            Response.Redirect("ManageWithdrawals.aspx");

        }


        private bool ValidateFields()
        {
            bool retVal = true;
            string errorMsg = string.Empty;


            if (Convert.ToInt32(this.ddlInvestor.SelectedValue) == 0)
            {
                errorMsg = errorMsg + "Investor is required. ";
                retVal = false;
            }

            if (Convert.ToDecimal(this.txtAmount.Text) <= 0)
            {
                errorMsg = errorMsg + "Amount should be greater that zero. ";
                retVal = false;
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

        private void SetMessage(string msg)
        {

            HiddenField hdField = (HiddenField)Master.FindControl("hdError");
            if (hdField != null)
            {
                hdField.Value = msg;
            }
        }
    }
}