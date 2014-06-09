<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ManageWithdrawals.aspx.cs" Inherits="LoanMac.Web.ManageWithdrawals" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liWithdrawals").addClass("menu-item-divided pure-menu-selected");

        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>Manage Withdrawals</h1>
        <h2>Search, create and edit withdrawal</h2>
    </div>

    <div class="content">
        
        <br />
        <div class="pure-form">
            <asp:TextBox ID="txtSearch" runat="server" class="pure-input-rounded pure-input-1-3" placeholder="Search..."></asp:TextBox>
            <asp:Button ID="btnSearch" class="pure-button " runat="server" Text="Search" onclick="btnSearch_Click" />
            <asp:Button ID="btnNew" class="pure-button pure-button-primary" runat="server" Text="New Withdrawal" onclick="btnNew_Click" />
                           
            
        </div>

        <h2 class="content-subhead">Search Result</h2>
        <asp:GridView ID="grdView" runat="server" AllowPaging="True" OnPageIndexChanging="grid_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" class="pure-table" PageSize="10">                      
            <alternatingrowstyle CssClass="pure-table-odd" />
            <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />
            <Columns>                 
                <asp:TemplateField HeaderText="Loan Id" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlId" runat="server" 
                            NavigateUrl='<%# string.Format("~/NewWithdrawal.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>' 
                            Text='<%# Eval("id") %>'></asp:HyperLink>                                    
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Investor" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlInvestor" runat="server" 
                            NavigateUrl='<%# string.Format("~/NewUser.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("user_id").ToString()))) %>' 
                            Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>                
                <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>                
                <asp:BoundField Visible="true" HeaderText="Date" DataField="date">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                
                              
            </Columns>
        </asp:GridView>
        

        
    </div>
</asp:Content>
