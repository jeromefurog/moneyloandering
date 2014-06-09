<%@ Page Title="Money Loandering - Create/Edit Withdrawal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewWithdrawal.aspx.cs" Inherits="ezLend.NewWithdrawal" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">


        $(document).ready(function () {

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
                $('#liStat').text('Edit Withdrawal');
                $('#slideAmount').parent().parent().hide();
                $('#<%=ddlInvestor.ClientID%>').attr('disabled', 'disabled');
                $('#<%=txtAmount.ClientID%>').attr('readonly', 'true');
                $('#<%=txtDate.ClientID%>').attr('readonly', 'true');
            };            

        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Withdrawal Information</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li><a href="ManageWithdrawals.aspx">Withdrawals</a></li>
            <li id='liStat' class="active">Create Withdrawal</li>
		</ol>
	</div>
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">
                <div class="block-flat">
                    <div class="header">							
                        <h3>Withdrawal Form</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
                            
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
                                    <label id='slideAmount' style="width:100%;" ></label>                                    
                                </div>
                            </div>
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
                                <label class="col-sm-3 control-label">Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtDate" required type='date' class="form-control" runat="server" placeholder="Loan Date"></asp:TextBox>                                    
                                </div>
                            </div>
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
