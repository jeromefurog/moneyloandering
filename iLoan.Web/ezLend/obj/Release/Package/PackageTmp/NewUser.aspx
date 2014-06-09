<%@ Page Title="Money Loandering - Create/Edit User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="ezLend.NewUser" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">


        $(document).ready(function () {

            var id = $('#<%=hdId.ClientID%>').val();

            if (id != null && id > 0) {

                $('#<%=txtUserName.ClientID%>').attr("readonly", "true");
                $('#<%=txtFirstName.ClientID%>').attr("readonly", "true");
                $('#<%=txtLastName.ClientID%>').attr("readonly", "true");

                $('#<%=txtPassword.ClientID%>').parent().parent().hide();
                $('#<%=txtConfirmPassword.ClientID%>').parent().parent().hide();
                $('#<%=txtPassword.ClientID%>').removeAttr("required");
                $('#<%=txtConfirmPassword.ClientID%>').removeAttr("required");

                var admin = $('#<%=hdAdmin.ClientID%>').val();
                if (admin != null && admin > 0) { $('#<%=chkAdmin.ClientID%>').parent().parent().parent().parent().hide(); }


                $('#liStat').text('Edit User');

            } else {

                $('#<%=btnChangePassword.ClientID%>').hide();
                $('#<%=btnDelete.ClientID%>').hide();
            };

            
            
        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>User Information</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li><a href="ManageUsers.aspx">Users</a></li>
            <li id='liStat' class="active">Create User</li>
		</ol>
	</div>
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">
                <div class="block-flat">
                    <div class="header">							
                        <h3>User Form</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Picture</label>
                                <div class="col-sm-6">
                                    <asp:FileUpload ID="fuImage" runat="server" class="form-control"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">User Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtUserName" required runat="server" class="form-control" autocomplete="off" placeholder="User Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Input Password</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtPassword" required type='password' class="form-control" autocomplete="off" runat="server" placeholder="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Confirm Password</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtConfirmPassword" required type='password' class="form-control" runat="server" placeholder="Confirm Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">First Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtFirstName" required runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Last Name</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtLastName" required runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Email</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" parsley-type="email" placeholder="Enter a valid e-mail"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Mobile</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Notes</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtNotes" runat="server" class="form-control" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Admin</label>
                                <div class="col-sm-6">
                                    <div class="switch">
                                        <asp:CheckBox ID="chkAdmin" runat="server" />
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label"></label>
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" onclick="btnSave_Click"/>
                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" formnovalidate onclick="btnDelete_Click"  OnClientClick = "return confirm('Are you sure you want to delete?');" />
                                    <asp:Button ID="btnChangePassword" runat="server" class="btn btn-primary" Text="Change Password" formnovalidate onclick="btnChangePassword_Click"  />
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                                    <asp:HiddenField ID="hdId" runat="server" />
                                    <asp:HiddenField ID="hdAdmin" runat="server" />
                                </div>
                            </div>
                      
                        </div>

                        
                    </div>
                </div>
            
            </div>
        
        </div>
    
    </div>

    

    
</asp:Content>
