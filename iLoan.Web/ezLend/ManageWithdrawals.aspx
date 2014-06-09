<%@ Page Title="Money Loandering - Manage Withdrawals" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageWithdrawals.aspx.cs" Inherits="ezLend.ManageWithdrawals" %>
<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
//        $(function () {


//        });

    </script>
     
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Manage Withdrawals</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li class="active">Withdrawals</li>
		</ol>
	</div>		
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Search Withdrawals</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
              
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch"  runat="server" placeholder="Search..." class="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" Text="Search" onclick="btnSearch_Click" />
                                        </span>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnNew" class="btn btn-default" runat="server" Text="New" onclick="btnNew_Click" />
                                        </span>
                                    </div>
                                </div>  
                                
                            </div>
                        </div>

                        <div class="table-responsive">
                            <asp:GridView ID="grdView" runat="server" AllowPaging="True" OnPageIndexChanging="grid_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
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
                                                NavigateUrl='<%# string.Format("~/Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("user_id").ToString()))) %>' 
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
                                <pagerstyle cssclass="CustomePaging"></pagerstyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
    </div>
    
</asp:Content>