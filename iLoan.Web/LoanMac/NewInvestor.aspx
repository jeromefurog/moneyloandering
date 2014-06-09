<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="NewInvestor.aspx.cs" Inherits="LoanMac.Web.NewInvestor" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liInvestments").addClass("menu-item-divided pure-menu-selected");


            var id = $('#<%=hdId.ClientID%>').val();

            if (id != null && id < 0) {
                
            } else {
                $('h1').html('Edit Investment');
                $('h2').html('Fill the necessary details to edit new investment');
                $('#<%=ddlUser.ClientID%>').attr("disabled", "true");
                $('#<%=txtAmount.ClientID%>').attr("readonly", "true");
            };

        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>New Investment</h1>
        <h2>Fill the necessary details to add new investment</h2>
    </div>

    <div class="content">
        <div class="pure-form pure-form-aligned">
            <fieldset>
                <br />
                
                <div class="pure-control-group">
                    <label for="name">User</label>                    
                    <asp:DropDownList ID="ddlUser" runat="server" class="pure-input-1-3">
                    </asp:DropDownList>
                </div>
                <div class="pure-control-group">
                    <label for="name">Amount</label>                    
                    <asp:TextBox ID="txtAmount" required type="number" step="any" min="1" class="pure-input-1-3" runat="server" placeholder="Amount"></asp:TextBox>
                </div>
                                
                <div class="pure-control-group">
                    <label for="email">Notes</label>
                    <asp:TextBox ID="txtNotes" runat="server" class="pure-input-1-3" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>
                </div>              
                               
                
                <div class="pure-controls">                    

                    <asp:Button ID="btnSave" runat="server" class="pure-button pure-button-primary" Text="Save" onclick="btnSave_Click"/>                    
                    <asp:Button ID="btnCancel" runat="server" class="pure-button pure-button-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                </div>

                <asp:HiddenField ID="hdId" runat="server" />
            </fieldset>
        </div>        
    </div>
</asp:Content>
