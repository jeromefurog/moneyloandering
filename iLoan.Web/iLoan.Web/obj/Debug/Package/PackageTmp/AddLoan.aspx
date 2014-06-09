<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLoan.aspx.cs" Inherits="iLoan.Web.AddLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $('#<%= txtDate.ClientID %>').datepicker({ dateFormat: 'mm/dd/yy' });

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
                            <asp:Label ID="lblNm" class="control-label" runat="server" Text="Borrower"></asp:Label>
							<div class="controls">							
                                <asp:DropDownList ID="ddlBorrower" AutoPostBack="true" OnSelectedIndexChanged="ddlBorrower_SelectedIndexChanged"  runat="server" Width="300px">                                    
                                </asp:DropDownList>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div>                           
                        <div class="control-group">		
                            <asp:Label ID="Label5" class="control-label" runat="server" Text="Co-maker"></asp:Label>
							<div class="controls">							
                                <asp:DropDownList ID="ddlComaker" runat="server" Width="300px">                                    
                                </asp:DropDownList>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label6" class="control-label" runat="server" Text="Loan Term"></asp:Label>
							<div class="controls">							
                                <asp:DropDownList ID="ddlLoanTerm" runat="server" Width="300px">                                    
                                </asp:DropDownList>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label2" class="control-label" runat="server" Text="Period"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtPeriod" runat="server" type="number" min="1" required class="input-xlarge focused" ></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>
                                <p class="help-block">Number of months</p>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label3" class="control-label" runat="server" Text="Collateral"></asp:Label>
							<div class="controls">							
                                <asp:DropDownList ID="ddlCollateral" runat="server" Width="300px">                                    
                                </asp:DropDownList>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div> 
                        <div class="control-group">		
                            <asp:Label ID="lblFirstName" class="control-label" runat="server" Text="Collateral Details"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtCollateralDetails" runat="server" TextMode="MultiLine" Width="400px" Height="100px" class="input-xlarge focused" ></asp:TextBox>                                                       
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label7" class="control-label" runat="server" Text="Amount"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtAmount" runat="server" type="number" min="1" required class="input-xlarge focused"></asp:TextBox>
                                &nbsp;&nbsp;<span style="color: Red;">*</span>                                                         
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblLastName" class="control-label" runat="server" Text="Interest"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtInterest" runat="server" type="number" min="1" step="any" required class="input-xlarge focused"></asp:TextBox>
                                &nbsp;&nbsp;<span style="color: Red;">*</span> 
                                <p class="help-block">In percentage (%)</p>                         
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblEmail" class="control-label" runat="server" Text="Loan Date"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtDate" runat="server" required class="input-xlarge focused"></asp:TextBox>
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label1" class="control-label" runat="server" Text="Notes"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="400px" Height="100px" class="input-xlarge focused"></asp:TextBox>
                                                  
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
                                EnableTheming="False" Text="Cancel" formnovalidate onclick="btnCancel_Click"/>

                                                         

						</div>

                        
                                
                    </fieldset>
                        
                </div>
                            
                
            </div>
            
		</div>
    </div>

    
        
</asp:Content>