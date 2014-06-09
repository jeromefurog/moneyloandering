<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPayable.aspx.cs" Inherits="iLoan.Web.AddPayable" %>

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
				<h2><i class="icon-th"></i> <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
				<div class="box-icon">					
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>					
				</div>
			</div>
			
            <div class="box-content"> 
                <div class="span6">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="control-group">		
                                <asp:Label ID="Label4" class="control-label" runat="server" Text="Loan Id"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtLoanId" runat="server" class="input-xlarge focused" ></asp:TextBox>
                                
							    </div>
						    </div>   
                            <div class="control-group">		
                                <asp:Label ID="lblNm" class="control-label" runat="server" Text="Borrower"></asp:Label>
							    <div class="controls">							
                                    <asp:DropDownList ID="ddlBorrower" AutoPostBack="true" OnSelectedIndexChanged="ddlBorrower_SelectedIndexChanged"  runat="server" Width="300px">                                    
                                    </asp:DropDownList>
                                
							    </div>
						    </div>                           
                            <div class="control-group">		
                                <asp:Label ID="Label5" class="control-label" runat="server" Text="Co-maker"></asp:Label>
							    <div class="controls">							
                                    <asp:DropDownList ID="ddlComaker" runat="server" Width="300px">                                    
                                    </asp:DropDownList>

							    </div>
						    </div>
                            <div class="control-group">		
                                <asp:Label ID="Label6" class="control-label" runat="server" Text="Loan Term"></asp:Label>
							    <div class="controls">							
                                    <asp:DropDownList ID="ddlLoanTerm" runat="server" Width="300px">                                    
                                    </asp:DropDownList>
                                
							    </div>
						    </div>
                            <div class="control-group">		
                                <asp:Label ID="Label2" class="control-label" runat="server" Text="Period"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtPeriod" runat="server" class="input-xlarge focused" ></asp:TextBox>
                               
                                    <p class="help-block">Number of months</p>                            
							    </div>
						    </div>
                            <div class="control-group">		
                                <asp:Label ID="Label7" class="control-label" runat="server" Text="Amount"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtAmount" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                                          
							    </div>
						    </div>
                            <div class="control-group">		
                                <asp:Label ID="lblLastName" class="control-label" runat="server" Text="Interest"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtInterest" runat="server" class="input-xlarge focused"></asp:TextBox>
                                    
                                    <p class="help-block">In percentage (%)</p>                         
							    </div>
						    </div>
                            
                        </fieldset>
                    </div>
                </div>
                <div class="span6">
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="control-group">		
                                <asp:Label ID="Label3" class="control-label" runat="server" Text="Collateral"></asp:Label>
							    <div class="controls">							
                                    <asp:DropDownList ID="ddlCollateral" runat="server" Width="300px">                                    
                                    </asp:DropDownList>
                                     
							    </div>
						    </div> 
                            <div class="control-group">		
                                <asp:Label ID="lblFirstName" class="control-label" runat="server" Text="Collateral Details"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtCollateralDetails" runat="server" TextMode="MultiLine" Width="400px" Height="80px" class="input-xlarge focused" ></asp:TextBox>                                                       
							    </div>
						    </div>
                            
                            <div class="control-group">		
                                <asp:Label ID="lblEmail" class="control-label" runat="server" Text="Loan Date"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtDate" runat="server" class="input-xlarge focused"></asp:TextBox>
                                               
							    </div>
						    </div>
                            <div class="control-group">		
                                <asp:Label ID="Label1" class="control-label" runat="server" Text="Notes"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="400px" Height="80px" class="input-xlarge focused"></asp:TextBox>
                                                  
							    </div>
						    </div>
                            <div class="control-group">		
                                <asp:Label ID="Label8" class="control-label" runat="server" Text="Total Payable Amount"></asp:Label>
							    <div class="controls">							
                                    <asp:TextBox ID="txtTotalPayableAmount" runat="server" class="input-xlarge focused"></asp:TextBox>
                                                  
							    </div>
						    </div>
                        </fieldset>
                    </div>
                </div>
                <div class="form-horizontal">
                    <fieldset>                       
                        <div class="control-group">
                            <%--<div class="controls">
                                <div id='dvError' class="alert alert-error" runat='server' visible='true'>Test      
						        </div> 
                            </div>	--%>						
						</div>  
                        
                    </fieldset> 
                    <div class="form-actions" >
							                            
                            <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" 
                                EnableTheming="False" Text="Cancel" onclick="btnCancel_Click"/>

                                                         

						</div>                       
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
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField Visible="true" HeaderText="Payable Date" DataField="date">
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
                                <asp:Button ID="btnPay" Width='80px' OnClick= "Pay" runat="server" Text="" class=""/>
                                                                                                              
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