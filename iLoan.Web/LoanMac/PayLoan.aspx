<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="PayLoan.aspx.cs" Inherits="LoanMac.Web.PayLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liPayables").addClass("menu-item-divided pure-menu-selected");

            
        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>Pay Loan</h1>
        <h2>Fill the necessary details to pay loan</h2>
    </div>

    <div class="content">
        <div class="pure-form pure-form-aligned">
            <fieldset>
                <br />
                
                <div class="pure-control-group">
                    <label for="name">Loan Id</label> 
                    <asp:TextBox ID="txtLoanId" readonly class="pure-input-1-3" runat="server" placeholder="Loan Id"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Amount</label>                    
                    <asp:TextBox ID="txtAmount" readonly class="pure-input-1-3" runat="server" placeholder="Amount"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Cut-off Date</label> 
                    <asp:TextBox ID="txtDate" type='date' required class="pure-input-1-3" runat="server" placeholder="Cut-off Date"></asp:TextBox>
                </div>              
                <div class="pure-control-group">
                    <label for="email">Status</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" class="pure-input-1-3" >
                        <asp:ListItem Value="1">Paid</asp:ListItem>
                        <asp:ListItem Value="0">Not Paid</asp:ListItem>
                    </asp:DropDownList>
                </div>    
                <div class="pure-control-group">
                    <label for="email">Notes</label>
                    <asp:TextBox ID="txtNotes" runat="server" class="pure-input-1-3" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>
                </div> 
                                                            
                               
                
                <div class="pure-controls">                    

                    <asp:Button ID="btnSave" runat="server" class="pure-button pure-button-primary" Text="Save" onclick="btnSave_Click"/>                    
                    <asp:Button ID="btnCancel" runat="server" class="pure-button pure-button-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                </div>
                                                
            </fieldset>
        </div>        
        <asp:HiddenField ID="hdLoanId" runat="server" />
    </div>
</asp:Content>
