<%@ Page Title="Money Loandering - Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ezLend.Default" %>
<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("table .label").each(function (index) {
                //console.log(index + ": " + $(this).text());

                var value = $(this).html();

                if (value == 'No') {
                    $(this).addClass("label-danger");
                } else {
                    $(this).addClass("label-success");
                }

            });

        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id='dvHead' runat='server' class="page-head">
      <asp:DropDownList ID="drpUser" runat="server" style='width:50%;' class="select2" AutoPostBack="true" OnSelectedIndexChanged="drpUser_SelectedIndexChanged">
        </asp:DropDownList>
        
    </div>
    <div class="cl-mcont">
       
       <div class="row">
            <div class="col-md-12">  
                <div class="block-flat">
                    <div class="header">							
                        <h3>Your Loans</h3>
                    </div>
                    <div class="content">
                        <div id="dvAlert" runat="server">                            

                        </div>
                        
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
              
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch"  runat="server" placeholder="Search..." class="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" Text="Search" onclick="btnSearch_Click" />
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
                                                NavigateUrl='<%# string.Format("~/ViewLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>' 
                                                Text='<%# Eval("id") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    
                                    <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Interest" DataField="interest">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Period" DataField="period">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>                
                                    <asp:BoundField Visible="true" HeaderText="Date" DataField="date">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Visible="true" HeaderText="Penalty" DataField="penalty">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>    
                                    <asp:TemplateField HeaderText="Progress" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>   
                                            <div class="progress">
							                  <div class="progress-bar progress-bar-info" style="width: <%# Eval("Progress") %>%"><%# Eval("total_paid") %>/<%# Eval("total_payments") %></div>
							                </div>                                 
                                        </ItemTemplate>
                                    </asp:TemplateField>                                                               
                                    <asp:TemplateField HeaderText="Fully Paid" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                            
                                                <span class="label "><%# Eval("fully_paid") %></span></td>                                 
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
                        <h3>Loans Applied</h3>
                    </div>
                    <div class="content">
                        <div class="form-horizontal group-border-dashed" action="#" style="border-radius: 0px;">
              
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        
                                        <span class="input-group-btn">
                                            <asp:HiddenField ID="hdId" runat="server" />
                                            <asp:Button ID="btnNew" class="btn btn btn-success" runat="server" Text="Apply Loan" onclick="btnNew_Click" />
                                        </span>
                                    </div>
                                </div>  
                                
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="grdView1" runat="server" AllowPaging="True" OnPageIndexChanging="grid1_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />                               
                                <Columns>                 
                                    <asp:TemplateField HeaderText="Loan Id" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlId" runat="server" 
                                                NavigateUrl='<%# string.Format("~/ApplyLoan.aspx?id={0}&loanid={1}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode("0")),LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>' 
                                                Text='<%# Eval("id") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    
                                    <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>                                    
                                    <asp:BoundField Visible="true" HeaderText="Months" DataField="period">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>                
                                    <asp:BoundField Visible="true" HeaderText="Date" DataField="date">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                                                                                  
                                    <%--<asp:TemplateField HeaderText="Fully Paid" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                            
                                                <span class="label "><%# Eval("fully_paid") %></span></td>                                 
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
