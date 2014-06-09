<%@ Page Title="Money Loandering - User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ezLend.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cl-mcont">
    <div class="row">
        <div class="col-md-12">
            <div class="block-flat">
                <div class="header">							
					<h3>User Profile</h3>
				</div>
                <div class="content">
                    <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
                        <div class="form-group">
                            <div class="col-sm-3">
                                
                                <asp:Image ID="imPicture" runat="server" style='width:80%;float:right;padding: 5px;border: 1px solid #EBEBEB;' alt="Avatar" />
                                
                            </div>
                            <div class="col-sm-6">
                                <h5 class="list-group-item-heading"><strong><asp:Label ID='lblName' runat="server"></asp:Label></strong> <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></h5>
								<div><i class="fa fa-mobile-phone"></i> <asp:Label ID='lblMobile' runat="server"></asp:Label></div>
								<div><i class="fa fa-envelope"></i> <asp:Label ID='lblEmail' runat="server"></asp:Label></div>
                                <br />
							    <asp:Button ID="btnEdit" runat="server" class="btn btn-primary" OnClick='btnEdit_Click' Text="Edit User"/>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</div>
</asp:Content>
