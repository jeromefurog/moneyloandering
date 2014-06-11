<%@ Page Title="Money Loandering - Apply Loan" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplyLoan.aspx.cs" Inherits="ezLend.ApplyLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">


        $(document).ready(function () {
               

        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Apply Loan</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>
            <li id='liStat' class="active">Apply Loan</li>
		</ol>
	</div>
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">
                <div class="block-flat">
                    <div class="header">							
                        <h3>Loan Form</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
                            
                            <%--<div class="form-group">
                                <label class="col-sm-3 control-label">Borrower</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlBorrower" class="select2" AutoPostBack="true" OnSelectedIndexChanged="ddlBorrower_SelectedIndexChanged"  runat="server">                                    
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Co-Maker</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlComaker" class="select2" runat="server">                                    
                                    </asp:DropDownList>                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Term</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlLoanTerm" class="form-control" runat="server">                                    
                                    </asp:DropDownList>                                   
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Amount</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Php</span>
                                        <asp:TextBox ID="txtAmount" required type="number" step="any" min="1" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                     </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Period</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-addon"># of Month</span>
                                        <asp:TextBox ID="txtPeriod" required type="number" min="1" step='1' class="form-control" runat="server" placeholder="Period"></asp:TextBox>
                                     </div>                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Collateral</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlCollateral" class="form-control" runat="server">                                    
                                    </asp:DropDownList>                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Collateral Details</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtCollateralDetails" TextMode="MultiLine" Height="100px" class="form-control" runat="server" placeholder="Details"></asp:TextBox>                                   
                                </div>
                            </div>
                            <%--<div class="form-group">
                                <label class="col-sm-3 control-label">Interest</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">%</span>
                                        <asp:TextBox ID="txtInterest" required type="number" step="any" min="1" class="form-control" runat="server" placeholder="Interest"></asp:TextBox>
                                     </div>                                
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Loan Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtDate" required type='date' class="form-control" runat="server" placeholder="Loan Date"></asp:TextBox>                                
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Investor</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlInvestor" AutoPostBack="true" OnSelectedIndexChanged="ddlInvestor_SelectedIndexChanged" class="select2" runat="server">                                    
                                    </asp:DropDownList>                                
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Amount Source</label>
                                <div class="col-sm-6">
                                    <label id='slideAmount' class="" style="width:100%;"></label>                                
                                </div>
                            </div>--%>
                            
                            <%--<div class="form-group">
                                <label class="col-sm-3 control-label">Penalty</label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Php</span>
                                        <asp:TextBox ID="txtPenalty" type="number" step="any" min="0" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                     </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Penalty Details</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtPenaltyDetails" runat="server" class="form-control" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>                                    
                                </div>
                            </div>--%>
                            
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
                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" formnovalidate onclick="btnDelete_Click" OnClientClick = "return confirm('Are you sure you want to delete?');" />
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                                    <asp:HiddenField ID="hdId" runat="server" />
                                    <asp:HiddenField ID="hdTotalAmount" runat="server" />
                                    <asp:HiddenField ID="hdAmount" runat="server" />
                                </div>
                            </div>
                      
                        </div>

                        
                    </div>
                </div>
            
            </div>
        
        </div>
    
    </div>

    

    
</asp:Content>
