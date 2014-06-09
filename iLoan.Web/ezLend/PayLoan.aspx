<%@ Page Title="Money Loandering - Pay Loan" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayLoan.aspx.cs" Inherits="ezLend.PayLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {

            $('#<%=txtLoanId.ClientID%>').attr('readonly', 'true');
            $('#<%=txtAmount.ClientID%>').attr('readonly', 'true');
            $('#<%=txtDate.ClientID%>').attr('readonly', 'true');
                
          
        });

        
    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Payment Information</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li><a href="Manageloans.aspx">Loans</a></li>
            <li id='liStat' class="active">Pay Loan</li>
		</ol>
	</div>
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">
                <div class="block-flat">
                    <div class="header">							
                        <h3>Payment Form</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
                            
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Loan ID</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtLoanId" readonly class="form-control" runat="server" placeholder="Loan Id"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Amount</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Php</span>
                                        <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                                     </div>                                    
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Cut-off Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtDate" type='date' required class="form-control" runat="server" placeholder="Cut-off Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Status</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" >
                                        <asp:ListItem Value="1">Paid</asp:ListItem>
                                        <asp:ListItem Value="0">Not Paid</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Notes</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtNotes" runat="server" class="form-control" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-sm-3 control-label"></label>
                                <div class="col-sm-6">
                                    
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" onclick="btnSave_Click"/>                    
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                                    <asp:HiddenField ID="hdId" runat="server" />
                                </div>
                            </div>
                      
                        </div>

                        
                    </div>
                </div>
            
            </div>
        
        </div>
    
    </div>

    

    
</asp:Content>
