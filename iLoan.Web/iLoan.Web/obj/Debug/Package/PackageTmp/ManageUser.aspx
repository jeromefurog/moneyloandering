<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ManageUser.aspx.cs" Inherits="iLoan.Web.ManageUser" %>

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
				<h2><i class="icon-th"></i> Manage Users</h2>
				<div class="box-icon">					
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>					
				</div>
			</div>
			
            <div class="box-content"> 
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">							
							<div class="controls">  
                                <div id="divMessage" align="right"></div>
							</div>
						</div>
                    </fieldset>
                </div>
                <div class="form-actions" id="dvFormActions" runat="server" >
				    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Add User" 
                        onclick="btnAdd_Click"/>
				    
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
                        
                        <asp:BoundField Visible="true" HeaderText="User Name" DataField="user_name">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>  
                        <asp:BoundField Visible="true" HeaderText="First Name" DataField="first_name">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField> 
                        <asp:BoundField Visible="true" HeaderText="Last Name" DataField="last_name">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Email" DataField="email">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Phone No" DataField="phone_no">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField Visible="true" HeaderText="Role" DataField="role">
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