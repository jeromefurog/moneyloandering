<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ManagePayables.aspx.cs" Inherits="iLoan.Web.ManagePayables" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {


        });

    </script>

    
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ScriptContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="PageContent">
         
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
			<div class="box-header well">
				<h2><i class="icon-th"></i> Manage Payables</h2>
				<div class="box-icon">					
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>					
				</div>
			</div>
			
            <div class="box-content"> 

                <div class="row-fluid sortable">	
				    <div class="box span12">
					    <div class="box-header well" data-original-title>
						    <h2>Current Payables</h2>
						    <div class="box-icon">
							    <%--<a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>--%>
							    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
							    <%--<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>--%>
						    </div>
					    </div>
					    <div class="box-content">
						        <div class='gridViewOverflow'>
                                    <asp:GridView ID="grdViewCurrent" runat="server" Width="100%"  BorderColor="#dddddd" AllowPaging="True"
                                        EmptyDataText="No records were found" 
                                        DataKeyNames="id"
                                        AutoGenerateColumns="False"
                                        OnPageIndexChanging="grdViewCurrent_PageIndexChanging"  
                                        OnRowDataBound="grdViewCurrent_RowDataBound"
                                        PagerSettings-Mode="Numeric"
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="20">
                                        <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />
                                        <Columns>    
                        
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlId" runat="server" 
                                                    NavigateUrl='<%# string.Format("~/AddPayable.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("loan_id").ToString()))) %>' 
                                                    Text='<%# Eval("loan_id") %>'></asp:HyperLink>                                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <%--<asp:BoundField Visible="true" HeaderText="Borrower" DataField="name">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlBorrower1" runat="server" 
                                                    NavigateUrl='<%# string.Format("~/AddBorrower.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                    Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField Visible="true" HeaderText="Cut-off Date" DataField="date">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Button ID="btnPay" Width='80px' OnClick= "CurrentPay" runat="server" Text="Pay Amount" class="btn btn-small btn-danger"/>                                                                                                              
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
				    </div><!--/span-->
			    </div><!--/row-->
                           
                <div class="row-fluid sortable">	
				    <div class="box span12">
					    <div class="box-header well" data-original-title>
						    <h2>Pending Payables</h2>
						    <div class="box-icon">
							    <%--<a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>--%>
							    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
							    <%--<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>--%>
						    </div>
					    </div>
					    <div class="box-content">
						       <div class='gridViewOverflow'>
                                    <asp:GridView ID="grdViewPrevious" runat="server" Width="100%"  BorderColor="#dddddd" AllowPaging="True"
                                        EmptyDataText="No records were found" 
                                        DataKeyNames="id"
                                        AutoGenerateColumns="False"
                                        OnPageIndexChanging="grdViewPrevious_PageIndexChanging"  
                                        OnRowDataBound="grdViewPrevious_RowDataBound"
                                        PagerSettings-Mode="Numeric"
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="20">
                                        <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />
                                        <Columns>    
                        
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                
                                                <asp:HyperLink ID="hlId" runat="server" 
                                                    NavigateUrl='<%# string.Format("~/AddPayable.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("loan_id").ToString()))) %>' 
                                                    Text='<%# Eval("loan_id") %>'></asp:HyperLink>                                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <%--<asp:BoundField Visible="true" HeaderText="Borrower" DataField="name">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlBorrower2" runat="server" 
                                                    NavigateUrl='<%# string.Format("~/AddBorrower.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                    Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField Visible="true" HeaderText="Cut-off Date" DataField="date">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Button ID="btnPay" Width='80px' OnClick= "PreviousPay" runat="server" Text="Pay Amount" class="btn btn-small btn-danger"/>                                                                                                              
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
				    </div><!--/span-->
				
				    
			
			    </div>

                <div class="row-fluid sortable">	
                
                    <div class="box span12">
					    <div class="box-header well" data-original-title>
						    <h2>Next Cut-off Payables</h2>
						    <div class="box-icon">
							    <%--<a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>--%>
							    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
							    <%--<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>--%>
						    </div>
					    </div>
					    <div class="box-content">
                            <div class='gridViewOverflow'>
                                    <asp:GridView ID="grdViewNext" runat="server" Width="100%"  BorderColor="#dddddd" AllowPaging="True"
                                        EmptyDataText="No records were found" 
                                        DataKeyNames="id"
                                        AutoGenerateColumns="False"
                                        OnPageIndexChanging="grdViewNext_PageIndexChanging"  
                                        OnRowDataBound="grdViewNext_RowDataBound"
                                        PagerSettings-Mode="Numeric"
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="20">
                                        <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />
                                        <Columns>    
                        
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loan ID" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlId" runat="server" 
                                                    NavigateUrl='<%# string.Format("~/AddPayable.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("loan_id").ToString()))) %>' 
                                                    Text='<%# Eval("loan_id") %>'></asp:HyperLink>                                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <%--<asp:BoundField Visible="true" HeaderText="Borrower" DataField="name">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlBorrower3" runat="server" 
                                                    NavigateUrl='<%# string.Format("~/AddBorrower.aspx?id={0}", iLoan.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                    Text='<%# Eval("name") %>'></asp:HyperLink>                                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField Visible="true" HeaderText="Amount" DataField="amount">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField Visible="true" HeaderText="Notes" DataField="notes">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField Visible="true" HeaderText="Cut-off Date" DataField="date">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Button ID="btnPay" Width='80px' OnClick= "NextPay" runat="server" Text="Pay Amount" class="btn btn-small btn-danger"/>                                                                                                              
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
				    </div><!--/span-->
                
                </div>
                            
                
            </div>
            
		</div>
    </div>
    
        
</asp:Content>
