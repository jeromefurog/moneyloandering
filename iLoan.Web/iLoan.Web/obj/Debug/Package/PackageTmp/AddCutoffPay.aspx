<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCutoffPay.aspx.cs" Inherits="iLoan.Web.AddCutoffPay" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {

            $('#<%= txtCutoffDate.ClientID %>').datepicker({ dateFormat: 'mm/dd/yy' });
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
                            <asp:Label ID="Label2" class="control-label" runat="server" Text="Cut-off Date"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtCutoffDate" runat="server" required class="input-xlarge focused" ></asp:TextBox>
                               &nbsp;&nbsp;<span style="color: Red;">*</span>                      
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label3" class="control-label" runat="server" Text="Amount"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtAmount" runat="server" required type="number" step="any" min="0" class="input-xlarge focused" ></asp:TextBox>
                                
                            &nbsp;&nbsp;<span style="color: Red;">*</span>                            
							</div>
						</div> 
                        <div class="control-group">		
                            <asp:Label ID="lblFirstName" class="control-label" runat="server" Text="Notes"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="400px" Height="100px" class="input-xlarge focused" ></asp:TextBox>                                                       
							</div>
						</div>
                                               
                        <div class="control-group">		
                            <asp:Label ID="Label4" runat="server" class="control-label" Text="Status"></asp:Label>
							<div class="controls">							
                                 <asp:DropDownList ID="ddlStatus" runat="server" Width="170px">
                                    <asp:ListItem Value="1">Paid</asp:ListItem>
                                    <asp:ListItem Value="0">Not Paid</asp:ListItem>
                                </asp:DropDownList> 
                                &nbsp;&nbsp;<span style="color: Red;">*</span>          
							</div>
						</div>       
                        <div class="control-group">
                            <div class="controls">
                                <div id='dvError' class="alert alert-error" runat='server' visible='false'>	        
						        </div> 
                                <asp:HiddenField ID="hdLoanId" runat="server" />
                            </div>							
						</div> 
                        <div class="form-actions" >
							<asp:Button ID="btnSave" runat="server" class="btn btn-primary" 
                                EnableTheming="False" Text="Save" onclick="btnSave_Click"/>

                            
                            <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" 
                                EnableTheming="False" Text="Cancel" formnovalidate onclick="btnCancel_Click"/>

                                                         

						</div>

                        
                                
                    </fieldset>
                        
                </div>
                            
                
            </div>
            
		</div>
    </div>

    
        
</asp:Content>