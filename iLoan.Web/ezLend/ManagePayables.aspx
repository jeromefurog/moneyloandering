<%@ Page Title="Money Loandering - Manage Payables" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePayables.aspx.cs" Inherits="ezLend.ManagePayables" %>
<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
//        $(function () {


//        });

    </script>
     
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Manage Payables</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li class="active">Payables</li>
		</ol>
	</div>		
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Current (Php <asp:Label ID="lblCurrent" runat='server'></asp:Label>)</h3>    
                    </div>
                    <div class="content">
                        
                        <div class="table-responsive">
                            <asp:GridView ID="grdViewCurrent" runat="server" AllowPaging="True" OnRowDataBound="grdViewCurrent_RowDataBound" OnPageIndexChanging="grdViewCurrent_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />                               
                                <Columns>                 
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlId" runat="server" 
                                                NavigateUrl='<%# string.Format("~/ViewLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("loan_id").ToString()))) %>' 
                                                Text='<%# Eval("loan_id") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                 
                                    <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlBorrower1" runat="server" 
                                                NavigateUrl='<%# string.Format("~/Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Cut-off Date" DataField="date">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="Pay Loan" class="btn btn-danger"/>                                                                                                              
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

        <div class="row">
            <div class="col-md-12">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Over Due (Php <asp:Label ID="lblOverdue" runat='server'></asp:Label>)</h3>
                    </div>
                    <div class="content">
                        
                        <div class="table-responsive">
                            <asp:GridView ID="grdViewOverDue" runat="server" AllowPaging="True" OnRowDataBound="grdViewOverDue_RowDataBound" OnPageIndexChanging="grdViewOverDue_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />                               
                                <Columns>                 
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlId" runat="server" 
                                                NavigateUrl='<%# string.Format("~/ViewLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("loan_id").ToString()))) %>' 
                                                Text='<%# Eval("loan_id") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                 
                                    <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlBorrower1" runat="server" 
                                                NavigateUrl='<%# string.Format("~/Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Cut-off Date" DataField="date">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="Pay Loan" class="btn btn-danger"/>                                                                                                              
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

        <div class="row">
            <div class="col-md-12">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Pending (Php <asp:Label  ID="lblPending" runat='server'></asp:Label>)</h3>
                    </div>
                    <div class="content">
                        
                        <div class="table-responsive">
                            <asp:GridView ID="grdViewPending" runat="server" AllowPaging="True" OnRowDataBound="grdViewPending_RowDataBound" OnPageIndexChanging="grdViewPending_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />                               
                                <Columns>                 
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlId" runat="server" 
                                                NavigateUrl='<%# string.Format("~/ViewLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("loan_id").ToString()))) %>' 
                                                Text='<%# Eval("loan_id") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                 
                                    <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlBorrower1" runat="server" 
                                                NavigateUrl='<%# string.Format("~/Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Cut-off Date" DataField="date">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="Pay Loan" class="btn btn-danger"/>                                                                                                              
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