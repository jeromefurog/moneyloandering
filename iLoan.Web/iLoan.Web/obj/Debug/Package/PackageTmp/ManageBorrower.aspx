<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ManageBorrower.aspx.cs" Inherits="iLoan.Web.ManageBorrower" %>

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
				<h2><i class="icon-th"></i> Manage Borrowers</h2>
				<div class="box-icon">					
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>					
				</div>
			</div>
			
            <div class="box-content"> 

                <div class="form-horizontal">
                    <fieldset>
                          
                        <div class="control-group">		
                            <asp:Label ID="Label7" class="control-label" runat="server" Text="First Name"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtFirstName" runat="server" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="Label5" class="control-label" runat="server" Text="Last Name"></asp:Label>
							<div class="controls">							
                                <asp:TextBox ID="txtLastName" runat="server" class="input-xlarge focused" Width="300px" MaxLength="300"></asp:TextBox>                            
							</div>
						</div>
                        <div class="control-group">		
                            <asp:Label ID="lblStatus" runat="server" class="control-label" Text="Status"></asp:Label>
							<div class="controls">							
                                 <asp:DropDownList ID="ddlStatus" runat="server" Width="170px">
                                    <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">In Active</asp:ListItem>
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
                             <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Add Borrower" 
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
                        <asp:BoundField Visible="true" HeaderText="First Name" DataField="first_name">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField> 
                        <asp:BoundField Visible="true" HeaderText="Last Name" DataField="last_name">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Birth Day" DataField="birth_day">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Address" DataField="home_address">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Phone No" DataField="Home_no">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Company" DataField="company">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>                        
                        <asp:BoundField Visible="true" HeaderText="Status" DataField="status">
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
