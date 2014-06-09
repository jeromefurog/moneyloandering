<%@ Page Title="LoanMac - Manage User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="NewLoan.aspx.cs" Inherits="LoanMac.Web.NewLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#liLoans").addClass("menu-item-divided pure-menu-selected");

            var id = $('#<%=hdId.ClientID%>').val();

            $('#slideAmount').css("background", "#1f8dd6");

            if (id != null && id < 0) {

                var amount = $('#<%=hdTotalAmount.ClientID%>').val();
                if (amount == '') { amount = 1; $('#slideAmount').attr('disabled', 'disabled'); $('#<%=txtAmount.ClientID%>').attr('readonly', 'true'); }

                $('#slideAmount').noUiSlider({
                    range: [0, amount]
	                , start: 0
	                , handles: 1
                    , connect: "lower"
                    , serialization: {
	                    resolution: 1
		                , to: $('#<%=txtAmount.ClientID%>')
	                }
	            });
                	            

            } else {
                $('h1').html('Edit Loan');
                $('h2').html('Fill the necessary details to edit new loan');
                $('#slideAmount').parent().hide();
            };





        });

    </script>

    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <h1>New Loan</h1>
        <h2>Fill the necessary details to add new loan</h2>
    </div>

    <div class="content">
        <div class="pure-form pure-form-aligned">
            <fieldset>
                <br />
                
                <div class="pure-control-group">
                    <label for="name">Borrower</label> 
                    <asp:DropDownList ID="ddlBorrower" class="pure-input-1-3" AutoPostBack="true" OnSelectedIndexChanged="ddlBorrower_SelectedIndexChanged"  runat="server">                                    
                    </asp:DropDownList>
                </div>
                <div class="pure-control-group">
                    <label for="name">Co-Maker</label> 
                    <asp:DropDownList ID="ddlComaker" class="pure-input-1-3" runat="server">                                    
                    </asp:DropDownList>
                </div>
                <div class="pure-control-group">
                    <label for="name">Term</label> 
                    <asp:DropDownList ID="ddlLoanTerm" class="pure-input-1-3" runat="server">                                    
                    </asp:DropDownList>
                </div>
                <div class="pure-control-group">
                    <label for="name">Period</label> 
                    <asp:TextBox ID="txtPeriod" required type="number" min="1" class="pure-input-1-3" runat="server" placeholder="Period"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Collateral</label> 
                    <asp:DropDownList ID="ddlCollateral" class="pure-input-1-3" runat="server">                                    
                    </asp:DropDownList>
                </div>
                <div class="pure-control-group">
                    <label for="name">Collateral Details</label> 
                    <asp:TextBox ID="txtCollateralDetails" TextMode="MultiLine" Height="100px" class="pure-input-1-3" runat="server" placeholder="Details"></asp:TextBox>
                </div>                
                <div class="pure-control-group">
                    <label for="name">Interest</label>                    
                    <asp:TextBox ID="txtInterest" required type="number" step="any" min="1" class="pure-input-1-3" runat="server" placeholder="Interest"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Loan Date</label>                    
                    <asp:TextBox ID="txtDate" required type='date' class="pure-input-1-3" runat="server" placeholder="Loan Date"></asp:TextBox>
                </div>
                <div class="pure-control-group">
                    <label for="name">Investor</label> 
                    <asp:DropDownList ID="ddlInvestor" AutoPostBack="true" OnSelectedIndexChanged="ddlInvestor_SelectedIndexChanged" class="pure-input-1-3" runat="server">                                    
                    </asp:DropDownList>
                </div>
                <div class="pure-control-group">
                    <label for="name">Amount Source</label> 
                    <label id='slideAmount' class="" style="width:245px;"></label>
                </div>    
                <div class="pure-control-group">
                    <label for="name">Amount</label>                    
                    <asp:TextBox ID="txtAmount" type="number" step="any" min="0" class="pure-input-1-3" runat="server" placeholder="Amount"></asp:TextBox>
                </div>    
                <div class="pure-control-group">
                    <label for="email">Notes</label>
                    <asp:TextBox ID="txtNotes" runat="server" class="pure-input-1-3" TextMode="MultiLine" Height="100px" placeholder="Notes"></asp:TextBox>
                </div>              
                               
                
                <div class="pure-controls">                    

                    <asp:Button ID="btnSave" runat="server" class="pure-button pure-button-primary" Text="Save" onclick="btnSave_Click"/>
                    <%--<asp:Button ID="btnDelete" runat="server" class="pure-button pure-button-primary" Text="Delete" formnovalidate onclick="btnDelete_Click" OnClientClick = "return confirm('Are you sure you want to delete?');" />--%>
                    <asp:Button ID="btnCancel" runat="server" class="pure-button pure-button-primary" Text="Cancel" formnovalidate onclick="btnCancel_Click" />
                </div>

                <asp:HiddenField ID="hdId" runat="server" />
                <asp:HiddenField ID="hdTotalAmount" runat="server" />
                <asp:HiddenField ID="hdAmount" runat="server" />
            </fieldset>
        </div>        
    </div>
</asp:Content>
