<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBorrower.aspx.cs" Inherits="iLoan.Web.AddBorrower" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $('#<%= txtBirthDay.ClientID %>').datepicker({ dateFormat: 'mm/dd/yy' });

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
                            <asp:Label ID="Label5" class="control-label" runat="server" Text=""></asp:Label>
							<div class="controls">	
                                <asp:Image class="dashboard-avatar" ID="imgPicture" runat="server" style="width:170px; height:auto;" />						
                                                        
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblUpload" class="control-label" runat="server" Text="Upload Picture"></asp:Label>
							<div class="controls">	
                                <asp:FileUpload ID="fuImage" runat="server" />                        
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblNm" class="control-label" runat="server" Text="First Name"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtFirstName" runat="server" required class="input-xlarge focused"></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div>  
                        <div class="control-group">		
                            <asp:Label ID="Label2" class="control-label" runat="server" Text="Last Name"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtLastName" runat="server" required="required" class="input-xlarge focused" ></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div> 
                        <div class="control-group">		
                            <asp:Label ID="Label3" class="control-label" runat="server" Text="Birthday"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtBirthDay" runat="server" required="required" class="input-xlarge focused" ></asp:TextBox>
                                &nbsp;&nbsp;<span style="color: Red;">*</span>                                                    
							</div>
						</div> 
                        <div class="control-group">		
                            <asp:Label ID="lblFirstName" class="control-label" runat="server" Text="Email"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtEmail" type="email" runat="server" class="input-xlarge focused" ></asp:TextBox>                                                       
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblLastName" class="control-label" runat="server" Text="Home Address"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtAddress" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                 
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblEmail" class="control-label" runat="server" Text="Phone Number"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtPhoneNo" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                       
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label1" class="control-label" runat="server" Text="Company"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtCompany" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                       
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblRole" runat="server" class="control-label" Text="Company Address"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtCompanyAddress" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                        
							</div>
						</div>                                   
                        <div class="control-group">		
                            <asp:Label ID="lblStatus" runat="server" class="control-label" Text="Company Phone No"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtCompanyPhoneNo" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                        
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label4" runat="server" class="control-label" Text="Status"></asp:Label>
							<div class="controls">							
                                 <asp:DropDownList ID="ddlStatus" runat="server" Width="170px">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">In Active</asp:ListItem>
                                </asp:DropDownList>   
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

                            <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" 
                            EnableTheming="False" Text="Delete" formnovalidate onclick="btnDelete_Click" OnClientClick = "return confirm('Are you sure you want to delete?');"/>

                            <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" 
                                EnableTheming="False" Text="Cancel" onclick="btnCancel_Click" formnovalidate/>

                                                         

						</div>

                        
                                
                    </fieldset>
                        
                </div>
                            
                
            </div>
            
		</div>
    </div>

    
        
</asp:Content>