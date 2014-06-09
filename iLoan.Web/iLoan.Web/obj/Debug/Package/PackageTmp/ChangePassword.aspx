<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="iLoan.Web.ChangePassword" %>


<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {


        });

    </script>

    
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ScriptContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="PageContent">
         
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
			<div class="box-header well">
				<h2><i class="icon-th"></i> <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
				<div class="box-icon">					
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>					
				</div>
			</div>
			
            <div class="box-content"> 
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">		
                            <asp:Label ID="lblNm" class="control-label" runat="server" Text="Current Password"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtCurrentPassword" runat="server" autocomplete="off" TextMode="Password" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div>  
                        <div class="control-group" id='dvPass1' runat="server">		
                            <asp:Label ID="Label2" class="control-label" runat="server" Text="New Password"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtPassword1" runat="server" autocomplete="off" TextMode="Password" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div> 
                        <div class="control-group" id='dvPass2' runat="server">		
                            <asp:Label ID="Label3" class="control-label" runat="server" Text="Re-type Password"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtPassword2" runat="server" autocomplete="off" TextMode="Password" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div> 
                        
                        <div class="control-group">
                            <div class="controls">
                                <div id='dvError' class="alert alert-error" runat='server' visible='false'>	        
						        </div> 
                            </div>							
						</div>                        
                                
                        <div class="form-actions" >
							<asp:Button ID="btnSave" runat="server" class="btn btn-primary" 
                                EnableTheming="False" Text="Save" onclick="btnSave_Click"/>

                            
                            <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" 
                                EnableTheming="False" Text="Cancel" onclick="btnCancel_Click"/>

                            
						</div>

                        
                                
                    </fieldset>
                        
                </div>
                            
                
            </div>
            
		</div>
    </div>
    
        
</asp:Content>
