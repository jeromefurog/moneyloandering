<%@ Page Title="Money Loandering - View Loan" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewLoan.aspx.cs" Inherits="ezLend.ViewLoan" %>
<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
//        $(function () {


//        });

    </script>
     
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Loan Information</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>
            <li><a href="ManageLoans.aspx">Loans</a></li>			
			<li class="active">View Loan</li>
		</ol>
	</div>		
    <div class="cl-mcont">
        <div class="row">
            <div class="col-sm-6 col-md-6">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Loan Detail</h3>
                    </div>
                    <div class="content">

                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Loan ID</label>
                                <div class="col-sm-10">
                                    <label id="lblLoanId" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">Borrower</label>
                                <div class="col-sm-10">
                                    <asp:HyperLink ID="hlBorrower" class="form-control" runat="server"></asp:HyperLink>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Co-Maker</label>
                                <div class="col-sm-10">
                                    <asp:HyperLink ID="hlComaker" class="form-control" runat="server"></asp:HyperLink>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Investor</label>
                                <div class="col-sm-10">
                                    <asp:HyperLink ID="hlInvestor" class="form-control" runat="server"></asp:HyperLink>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Term</label>
                                <div class="col-sm-10">
                                    <label id="lblTerm" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Period</label>
                                <div class="col-sm-10">
                                    <label id="lblPeriod" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Interest</label>
                                <div class="col-sm-10">
                                    <label id="lblInterest" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Loan Date</label>
                                <div class="col-sm-10">
                                    <label id="lblDate" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Collateral</label>
                                <div class="col-sm-10">
                                    <label id="lblCollateral" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Collateral Details</label>
                                <div class="col-sm-10">
                                    <label id="lblCollateralDetails" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Amount</label>
                                <div class="col-sm-10">
                                    <label id="lblAmount" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Penalty</label>
                                <div class="col-sm-10">
                                    <label id="lblPenalty" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Penalty Details</label>
                                <div class="col-sm-10">
                                    <label id="lblPenaltyDetails" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Notes</label>
                                <div class="col-sm-10">
                                    <label id="lblNotes" class="form-control" runat='server'></label>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnEdit" class="btn btn-primary" runat="server" Text="Edit Loan" onclick="btnEdit_Click" />
                                    <asp:Button ID="btnCancel" class="btn btn-default" runat="server" Text="Cancel" onclick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
          
                  </div>
                </div>
            </div>
            <div class="col-sm-6 col-md-6">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Payables</h3>
                    </div>
                    <div class="content">
                        <div class="table-responsive">
                            <asp:GridView ID="grdView" runat="server" AllowPaging="True"  OnRowDataBound="grid_RowDataBound" OnPageIndexChanging="grid_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />                               
                                <Columns>                 
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>    
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>      
                                    <asp:BoundField Visible="true" HeaderText="Cut-off" DataField="date">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>                
                                    <asp:TemplateField HeaderText = "Status" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="" style='width:auto;' class=""/>                                                                                                              
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                </Columns>
                                <pagerstyle cssclass="CustomePaging"></pagerstyle>
                            </asp:GridView>
                        
                        </div>
                                  
                  </div>
                </div>
            </div>
        </div> 
    </div>
    
</asp:Content>