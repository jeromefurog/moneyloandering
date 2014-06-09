<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="LoanMac.Web.ChangePassword" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liUsers").addClass("menu-item-divided pure-menu-selected");


            
            
        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>Change Password</h1>
        <h2>Please create a secured password</h2>
    </div>

    <div class="content">
        <div class="pure-form pure-form-aligned">
            <fieldset>
                <br />
                
                <div class="pure-control-group">
                    <label for="name">User Name</label>                    
                    <asp:TextBox ID="txtUserName" readonly runat="server" class="pure-input-1-3" autocomplete="off" placeholder="User Name"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Current Password</label>                    
                    <asp:TextBox ID="txtCurrentPassword" required type='password' class="pure-input-1-3" autocomplete="off" runat="server" placeholder="Current Password"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">New Password</label>                    
                    <asp:TextBox ID="txtNewPassword" required type='password' class="pure-input-1-3" runat="server" placeholder="New Password"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Confirm New Password</label>                    
                    <asp:TextBox ID="txtConfirmNewPassword" required type='password' class="pure-input-1-3" runat="server" placeholder="Confirm New Password"></asp:TextBox>
                </div>
                               
                
                <div class="pure-controls">                    

                    <asp:Button ID="btnSave" runat="server" class="pure-button pure-button-primary" Text="Save" onclick="btnSave_Click"/>
                    <asp:Button ID="btnCancel" runat="server" class="pure-button pure-button-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                </div>

                <asp:HiddenField ID="hdId" runat="server" />
            </fieldset>
        </div>        
    </div>
</asp:Content>
