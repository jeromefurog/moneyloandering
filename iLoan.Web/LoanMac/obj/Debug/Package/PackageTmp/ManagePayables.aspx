<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ManagePayables.aspx.cs" Inherits="LoanMac.Web.ManagePayables" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liPayables").addClass("menu-item-divided pure-menu-selected");

        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>Manage Payables</h1>
        
    </div>

    <div class="content">
        
        <br />
        <h2 class="content-subhead">Current</h2>
        <asp:GridView ID="grdViewCurrent" runat="server" AllowPaging="True" OnRowDataBound="grdViewCurrent_RowDataBound" OnPageIndexChanging="grdViewCurrent_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" class="pure-table" PageSize="10">                      
            <alternatingrowstyle CssClass="pure-table-odd" />
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
                            NavigateUrl='<%# string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
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
                        <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="Pay Loan" class="button-error pure-button"/>                                                                                                              
                    </ItemTemplate>
                </asp:TemplateField>   
                              
            </Columns>
        </asp:GridView>

        <h2 class="content-subhead">Over Due</h2>
        <asp:GridView ID="grdViewOverDue" runat="server" AllowPaging="True" OnRowDataBound="grdViewOverDue_RowDataBound" OnPageIndexChanging="grdViewOverDue_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" class="pure-table" PageSize="10">                      
            <alternatingrowstyle CssClass="pure-table-odd" />
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
                            NavigateUrl='<%# string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
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
                        <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="Pay Loan" class="button-error pure-button"/>                                                                                                              
                    </ItemTemplate>
                </asp:TemplateField>   
                              
            </Columns>
        </asp:GridView>
        
        
        <h2 class="content-subhead">Pending</h2>
        <asp:GridView ID="grdViewPending" runat="server" AllowPaging="True" OnRowDataBound="grdViewPending_RowDataBound" OnPageIndexChanging="grdViewPending_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" class="pure-table" PageSize="10">                      
            <alternatingrowstyle CssClass="pure-table-odd" />
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
                            NavigateUrl='<%# string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
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
                        <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="Pay Loan" class="button-error pure-button"/>                                                                                                              
                    </ItemTemplate>
                </asp:TemplateField>   
                              
            </Columns>
        </asp:GridView>
        

        
    </div>
</asp:Content>
