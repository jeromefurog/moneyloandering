<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ManageLoan.aspx.cs" Inherits="iLoan.Web.ManageLoan" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $('#<%= txtDate.ClientID %>').datepicker({ dateFormat: 'mm/dd/yy' });

        });

    </script>

    
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ScriptContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="PageContent">
         
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
			<div class="box-header well">
				<h2><i class="icon-th"></i> Manage Loans</h2>
				<div class="box-icon">					
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>					
				</div>
			</div>
			
            <div class="box-content"> 

                <div class="form-horizontal">
                    <fieldset>
                          
                        <div class="control-group">		
                            <asp:Label ID="Label7" class="control-label" runat="server" Text="Form Id"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtFormId" runat="server" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label5" class="control-label" runat="server" Text="Borrower Name"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtBorrower" runat="server" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label1" class="control-label" runat="server" Text="Co-maker"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtComaker" runat="server" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label2" class="control-label" runat="server" Text="Loan Date"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtDate" runat="server" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblStatus" runat="server" class="control-label" Text="Pay Status"></asp:Label>
							<div class="controls">							
                                 <asp:DropDownList ID="ddlPayStatus" runat="server" Width="170px">
                                    <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                                    <asp:ListItem Value="1">Fully Paid</asp:ListItem>
                                    <asp:ListItem Value="0">Not Fully Paid</asp:ListItem>
                                </asp:DropDownList>   
							</div>
						</div>
                                                    
                        <div class="control-group">
							<div class="controls">		                                	
                                <div id="spError"></div> 
							</div>
						</div>                           
                                
                        <div class="form-actions">
							<asp:Button ID="btnSearch" runat="server" class="btn btn-primary" EnableTheming="False" Text="Search" OnClick="btnSearch_Click" />
                             <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Add Loan" 
                        onclick="btnAdd_Click"/>
						</div>                       
                                
                    </fieldset>
                        
                </div>

                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">							
							<div class="controls">  
                                <div id="divMessage" align="right"></div>
							</div>
						</div>
                    </fieldset>
                </div>
                
                <div class='gridViewOverflow'>
                    <asp:GridView ID="grdView" runat="server" Width="100%"  BorderColor="#dddddd" AllowPaging="True"
                        EmptyDataText="No records were found" 
                        DataKeyNames="id"
                        AutoGenerateColumns="False"
                        OnPageIndexChanging="grid_PageIndexChanging"  
                        OnRowDataBound="grid_RowDataBound"
                        PagerSettings-Mode="Numeric"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="20">
                        <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />
                        <Columns>    
                        
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField Visible="true" HeaderText="Loan ID" DataField="id">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlId" runat="server" 
                                    NavigateUrl='<%# string.Format("~/AddPayable.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("Id").ToString()))) %>' 
                                    Text='<%# Eval("id") %>'></asp:HyperLink>                                    
                            </ItemTemplate>
                        </asp:TemplateField> 
                        <%--<asp:BoundField Visible="true" HeaderText="Borrower" DataField="borrower">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlBorrower" runat="server" 
                                    NavigateUrl='<%# string.Format("~/AddBorrower.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                    Text='<%# Eval("borrower") %>'></asp:HyperLink>                                    
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField Visible="true" HeaderText="Co-maker" DataField="comaker">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Co-maker" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlComaker" runat="server" 
                                    NavigateUrl='<%# string.Format("~/AddBorrower.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("comaker_id").ToString()))) %>' 
                                    Text='<%# Eval("comaker") %>'></asp:HyperLink>                                    
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField Visible="true" HeaderText="Loan Date" DataField="date">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Amount Borrowed" DataField="amount">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Loan Term" DataField="term">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="No of months" DataField="period">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Interest" DataField="interest">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Payable Amount per Cut-off" DataField="payable_amount_cutoff">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Total Payable Amount" DataField="total_payable_amount">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>                        
                        <asp:BoundField Visible="true" HeaderText="Paid Amount" DataField="paid_amount">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Pay Status" DataField="status">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText = "Edit" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                            <asp:ImageButton ID="lbtnEdit" Width="20px" ImageUrl="img/edit-icon.png" runat="server" CommandName="Edit" 
                            CommandArgument='<%# Bind("id") %>' CausesValidation="False" OnClick= "editRecord"/>                                                                                                                                                
                            </ItemTemplate>
                        </asp:TemplateField>           
                    </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#4d90fe" Font-Bold="True" ForeColor="#ffffff" />                    
                        <RowStyle BackColor="White" ForeColor="#555555" />
                        <SelectedRowStyle BackColor="#cccccc" Font-Bold="True" ForeColor="#ffffff" />
                        <alternatingrowstyle BackColor="#f9f9f9" />
                        <PagerStyle HorizontalAlign="Left" CssClass="gridViewPagination" BorderColor="#dddddd" Height="40px"  />
                    </asp:GridView>
                    
                </div>
                            
                
            </div>
            
		</div>
    </div>
    
        
</asp:Content>
