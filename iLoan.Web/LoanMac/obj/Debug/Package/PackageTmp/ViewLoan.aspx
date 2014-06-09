<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ViewLoan.aspx.cs" Inherits="LoanMac.Web.ViewLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liLoans").addClass("menu-item-divided pure-menu-selected");

        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>Loan Viewer</h1>
        <h2>Loan details and payable list</h2>
    </div>

    <div class="content">        
        <br />
        <div class="pure-form pure-form-stacked">
            <fieldset>
                <div class="pure-g">
                    <div class="pure-u-1 pure-u-med-1-3">
                        <asp:HyperLink ID="hlBorrower" style="font-size:larger;" runat="server"></asp:HyperLink>                        
                        <label for="lblBorrower" style='font-style:italic;font-size:small'>Borrower</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                       
                        
                        <asp:HyperLink ID="hlComaker" style="font-size:larger;" runat="server"></asp:HyperLink>
                        <label for="lblComaker" style='font-style:italic;font-size:small'>Co-maker</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">    
                        <asp:HyperLink ID="hlInvestor" style="font-size:larger;" runat="server"></asp:HyperLink>                   
                       
                        <label for="lblInvestor" style='font-style:italic;font-size:small'>Investor</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblTerm" style='font-size:larger;' runat='server'></label>
                        <label for="lblTerm" style='font-style:italic;font-size:small'>Term</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblPeriod" style='font-size:larger;' runat='server'></label>
                        <label for="lblPeriod" style='font-style:italic;font-size:small'>Period</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblInterest" style='font-size:larger;' runat='server'></label>
                        <label for="lblInterest" style='font-style:italic;font-size:small'>Interest</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblDate" style='font-size:larger;' runat='server'></label>
                        <label for="lblDate" style='font-style:italic;font-size:small'>Loan Date</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblCollateral" style='font-size:larger;' runat='server'></label>
                        <label for="lblCollateral" style='font-style:italic;font-size:small'>Collateral</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblCollateralDetails" style='font-size:larger;' runat='server'></label>
                        <label for="lblCollateralDetails" style='font-style:italic;font-size:small'>Collateral Details</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">
                        <label id="lblAmount" style='font-size:larger;' runat='server'></label>
                        <label for="lblAmount" style='font-style:italic;font-size:small'>Amount</label>
                    </div>
                    <div class="pure-u-1 pure-u-med-1-3">                        
                        <label id="lblNotes" style='font-size:larger;' runat='server'></label>
                        <label for="lblNotes" style='font-style:italic;font-size:small'>Notes</label>
                    </div>
                </div>

                <br />
                
                <asp:Button ID="btnEdit" class="pure-button pure-button-primary" runat="server" Text="Edit Loan" onclick="btnEdit_Click" />
                <asp:Button ID="btnCancel" class="pure-button pure-button-primary" runat="server" Text="Cancel" onclick="btnCancel_Click" />
            </fieldset>                  
                           
            
        </div>

        <h2 class="content-subhead">List of Payables</h2>
        <asp:GridView ID="grdView" runat="server" AllowPaging="True" OnRowDataBound="grid_RowDataBound" OnPageIndexChanging="grid_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" class="pure-table" PageSize="15">                      
            <alternatingrowstyle CssClass="pure-table-odd" />
            <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />
            <Columns>                 
                <%--<asp:TemplateField HeaderText="Loan Id" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlId" runat="server" 
                            NavigateUrl='<%# string.Format("~/PayLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>' 
                            Text='<%# Eval("id") %>'></asp:HyperLink>                                    
                    </ItemTemplate>
                </asp:TemplateField>--%>
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
                        <asp:Button ID="btnPay" OnClick= "Pay" runat="server" Text="" style='width:120px;' class=""/>                                                                                                              
                    </ItemTemplate>
                </asp:TemplateField> 
                              
            </Columns>
        </asp:GridView>
        

        
    </div>
</asp:Content>
