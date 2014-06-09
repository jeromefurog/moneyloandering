<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="NewUser.aspx.cs" Inherits="LoanMac.Web.NewUser" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liUsers").addClass("menu-item-divided pure-menu-selected");


            var id = $('#<%=hdId.ClientID%>').val();

            if (id != null && id > 0) {

                $('#<%=txtUserName.ClientID%>').attr("readonly", "true");
                $('#<%=txtFirstName.ClientID%>').attr("readonly", "true");
                $('#<%=txtLastName.ClientID%>').attr("readonly", "true");

                $('#<%=txtPassword.ClientID%>').parent().hide();
                $('#<%=txtConfirmPassword.ClientID%>').parent().hide();
                $('#<%=txtPassword.ClientID%>').removeAttr("required");
                $('#<%=txtConfirmPassword.ClientID%>').removeAttr("required");

                $('h1').html("Edit User");
                $('h2').html("Fill the necessary details to edit new user");
            } else {
                
                $('#<%=btnChangePassword.ClientID%>').hide();
                $('#<%=btnDelete.ClientID%>').hide();
            };


            $(":file").jfilestyle();
        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>Create User</h1>
        <h2>Fill the necessary details to add new user</h2>
    </div>

    <div class="content">
        <div class="pure-form pure-form-aligned">
            <fieldset>
                <br />
                <div class="pure-control-group">
                    <label for="name"></label>                    
                    <asp:Image ID="imPicture" class="pure-input-1-4 dashboard-avatar" runat="server" /> 
                </div>
                <div class="pure-control-group">
                    <label for="name">Upload Picture</label>                    
                    <asp:FileUpload ID="fuImage" runat="server" class="jfilestyle"/>
                </div>
                <div class="pure-control-group">
                    <label for="name">User Name</label>                    
                    <asp:TextBox ID="txtUserName" required runat="server" class="pure-input-1-3" autocomplete="off" placeholder="User Name"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Password</label>                    
                    <asp:TextBox ID="txtPassword" required type='password' class="pure-input-1-3" autocomplete="off" runat="server" placeholder="Password"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Confirm Password</label>                    
                    <asp:TextBox ID="txtConfirmPassword" required type='password' class="pure-input-1-3" runat="server" placeholder="Confirm Password"></asp:TextBox>
                </div>                
                <div class="pure-control-group">
                    <label for="name">First Name</label>                    
                    <asp:TextBox ID="txtFirstName" required runat="server" class="pure-input-1-3" placeholder="First Name"></asp:TextBox>
                </div>

                <div class="pure-control-group">
                    <label for="password">Last Name</label>
                    <asp:TextBox ID="txtLastName" required runat="server" class="pure-input-1-3" placeholder="Last Name"></asp:TextBox>
                </div>

                <div class="pure-control-group">
                    <label for="email">Email Address</label>
                    <asp:TextBox ID="txtEmail" runat="server" class="pure-input-1-3" type="email" placeholder="Email"></asp:TextBox>
                </div>

                <div class="pure-control-group">
                    <label for="email">Mobile</label>
                    <asp:TextBox ID="txtMobile" runat="server" class="pure-input-1-3" placeholder="Mobile"></asp:TextBox>
                </div> 
                
                <div class="pure-control-group">
                    <label for="email">Notes</label>
                    <asp:TextBox ID="txtNotes" runat="server" class="pure-input-1-3" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>
                </div>              
                <div class="pure-control-group">
                    <label for="email"></label>                    
                    <asp:CheckBox ID="chkAdmin" runat="server" /> Admin
                </div>
                
                
                <div class="pure-controls">                    

                    <asp:Button ID="btnSave" runat="server" class="pure-button pure-button-primary" Text="Save" onclick="btnSave_Click"/>
                    <asp:Button ID="btnDelete" runat="server" class="pure-button pure-button-primary" Text="Delete" formnovalidate onclick="btnDelete_Click" OnClientClick = "return confirm('Are you sure you want to delete?');" />
                    <asp:Button ID="btnChangePassword" runat="server" class="pure-button pure-button-primary" Text="Change Password" formnovalidate onclick="btnChangePassword_Click" />
                    <asp:Button ID="btnCancel" runat="server" class="pure-button pure-button-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click"/>
                </div>

                <asp:HiddenField ID="hdId" runat="server" />
            </fieldset>
        </div>        
    </div>
</asp:Content>
