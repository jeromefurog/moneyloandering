<%@ Page Title="Money Loandering - Create/Edit Investments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewInvestor.aspx.cs" Inherits="ezLend.NewInvestor" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">


        $(document).ready(function () {

            var id = $('#<%=hdId.ClientID%>').val();

            if (id != null && id < 0) {

            } else {

                $('#liStat').text('Edit Investment');
                $('#<%=ddlUser.ClientID%>').attr("disabled", "true");
                $('#<%=txtAmount.ClientID%>').attr("readonly", "true");
            };            

        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Investment Information</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li><a href="ManageInvestors.aspx">Investments</a></li>
            <li id='liStat' class="active">Create Investment</li>
		</ol>
	</div>
    <div class="cl-mcont">
        <div class="row">
            <div class="col-md-12">
                <div class="block-flat">
                    <div class="header">							
                        <h3>Investment Form</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
                            
                            <div class="form-group">
                                <label class="col-sm-3 control-label">User</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlUser" runat="server" class="select2">
                                    </asp:DropDownList>
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
                                </div>
                            </div>
                      
                        </div>

                        
                    </div>
                </div>
            
            </div>
        
        </div>
    
    </div>

    

    
</asp:Content>
