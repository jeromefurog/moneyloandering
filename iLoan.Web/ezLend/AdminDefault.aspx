<%@ Page Title="Money Loandering - Admin Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="ezLend.AdminDefault" %>
<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {

            /*Pie Chart*/
            var data = JSON.parse($('#<%=hdInvestmentChart.ClientID%>').val());           

            
            $.plot('#piec1', data, {
                series: {
                    pie: {
                        show: true,
                        innerRadius: 0.27,
                        shadow: {
                            top: 5,
                            left: 15,
                            alpha: 0.3
                        },
                        stroke: {
                            width: 0
                        },
                        label: {
                            show: true,
                            formatter: function (label, series) {
                                return '<div style="font-size:12px;text-align:center;padding:2px;color:#333;">' + label + '</div>';

                            }
                        },
                        highlight: {
                            opacity: 0.08
                        }
                    }
                },
                grid: {
                    hoverable: true,
                    clickable: true
                },
                colors: ["#5793f3", "#dd4d79", "#bd3b47", "#dd4444", "#fd9c35", "#fec42c", "#d4df5a", "#5578c2"],
                legend: {
                    show: false
                }
            });

        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-head">
	    <h2>Dashboard</h2>
		<ol class="breadcrumb">
			<li><a href="Default.aspx">Home</a></li>			
			<li class="active">Dashboard</li>
		</ol>
	</div>
    <div class="cl-mcont">       

        <div class="row">
            <div class="col-md-4">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<%--<i class="fa fa-random fa-4x pull-left color-primary"></i>--%> 
							<h3 class="no-margin">INVESTMENTS</h3>
							<p class="color-primary">Total invested amount</p>
						</div>
						<h1 class="no-margin ">P<asp:Label ID="lblTotalInvestments" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>
			<div class="col-md-4">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<%--<i class="fa fa-random fa-4x pull-left color-primary"></i> --%>
							<h3 class="no-margin">EARNINGS</h3>
							<p class="color-primary">Total amount to date (exclusive of withdrawals)</p>
						</div>
						<h1 class="no-margin"><asp:Label ID="lblEarnings" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>
			<div class="col-md-4">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<%--<i class="fa fa-money fa-4x pull-left color-success"></i> --%>
							<h3 class="no-margin">CASH ON HAND</h3>
							<p class="color-success">Total loanable/withdrawable amount</p>
						</div>
						<h1 class="no-margin"><asp:Label ID="lblCashOnHand" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>

            
					
		</div>

        <div class="row">

			
			<div class="col-md-4">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<%--<i class="fa fa-money fa-4x pull-left color-success"></i> --%>
							<h3 class="no-margin">WITHDRAWALS/EXPENSES</h3>
							<p class="color-success">Total withdrawal/expense amount to date</p>
						</div>
						<h1 class="no-margin">P<asp:Label ID="lblTotalWithdrawals" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>

            <div class="col-md-4">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<%--<i class="fa fa-random fa-4x pull-left color-primary"></i> --%>
							<h3 class="no-margin">LOANED</h3>
							<p class="color-primary">Total loaned amount</p>
						</div>
						<h1 class="no-margin ">P<asp:Label ID="lblTotalLoan" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>
			<div class="col-md-4">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<%--<i class="fa fa-money fa-4x pull-left color-success"></i> --%>
							<h3 class="no-margin">COLLECTIBLES</h3>
							<p class="color-success">Overall amount to be collected (interest included)</p>
						</div>
						<h1 class="no-margin">P<asp:Label ID="lblTotalCollectable" runat='server'></asp:Label></h1>							
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
                        
                        <div class="table-responsive">
                            <asp:GridView ID="grdView1" runat="server" AllowPaging="True" OnPageIndexChanging="grid1_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="No records found" Width="100%" PageSize="10">                        
                                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="Red" />                               
                                <Columns>       
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLoanId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>          
                                    <asp:TemplateField HeaderText="Loan Id" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlId" runat="server" 
                                                NavigateUrl='<%# string.Format("~/ApplyLoan.aspx?id={0}&loanid={1}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode("-1")),LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>' 
                                                Text='<%# Eval("id") %>'></asp:HyperLink>                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="Borrower" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlBorrower" runat="server" 
                                                NavigateUrl='<%# string.Format("~/Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>' 
                                                Text='<%# Eval("borrower") %>'></asp:HyperLink>                                    
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
                                    <asp:TemplateField HeaderText = "" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Button ID="btnApprove" OnClick= "Approve" runat="server" Text="Approve" class="btn btn-success"/>                                                                                                              
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

        <%--<div class="row dash-cols">
			<div class="col-sm-6 col-md-6">
				<div class="tab-container">
				    <ul class="nav nav-tabs">
					    <li class="active"><a href="#investments" data-toggle="tab">Investments</a></li>
					    <li><a href="#loans" data-toggle="tab">Loans</a></li>
					    <li><a href="#withdrawals" data-toggle="tab">Withdrawals</a></li>
				    </ul>
				    <div class="tab-content" style='padding: 0px;border-bottom:0;'>
					    <div class="tab-pane active" id="investments">
						    <div class="block">
					            <div class="header">
						            <h2>Investments </h2>
						            <h3>Amount Invested</h3>
					            </div>
					            <div class="content no-padding ">
                                    <asp:ListView ID="lstInvestments" runat="server">
                                        <LayoutTemplate>
                                            <ul class="items">
                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />   
                                                <li style='padding: 3px 0px;'>
                                                    <div style='text-align:center;'>
                                                        <a href="ManageInvestors.aspx">more...</a>
                                                    </div>
                                        
                                                </li> 
                                            </ul>                
                                        </LayoutTemplate>
                                        <ItemTemplate>                                
                                            <li>
								                <i class="fa fa-file-text"></i><a href="<%# string.Format("Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("user_id").ToString()))) %>"><%#Eval("name")%></a> <span class="pull-right value">Php <%#Eval("amount")%></span>
								                <small>ID - <a href="<%# string.Format("NewInvestor.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>"><%#Eval("id")%></a></small>
                                    
							                </li>
                                
                                        </ItemTemplate>
                            
                                        <EmptyDataTemplate>
                                            
                                        </EmptyDataTemplate>
                                    </asp:ListView>	                        				
					            </div>
                    
					            <div class="total-data bg-blue" >
						            <h2>Total <span class="pull-right">Php <asp:Label runat='server' ID='lblTotalInvestments'></asp:Label></span></h2>							
					            </div>
				            </div>                           

					    </div>
                        <div class="tab-pane" id="loans">
                            <div class="block">
					            <div class="header">
						            <h2>Loans </h2>
						            <h3>List of loans on investments</h3>
					            </div>
					            <div class="content no-padding ">
                                    <asp:ListView ID="lstLoaned" runat="server">
                                        <LayoutTemplate>
                                            <ul class="items">
                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
                                                <li style='padding: 3px 0px;'>
                                                    <div style='text-align:center;'>
                                                        <a href="ManageLoans.aspx">more...</a>
                                                    </div>                                        
                                                </li>
                                            </ul>                
                                        </LayoutTemplate>
                                        <ItemTemplate>                                
                                            <li>
								                <i class="fa fa-file-text"></i><a href="<%# string.Format("Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("borrower_id").ToString()))) %>"><%#Eval("borrower")%></a> <span class="pull-right value">Php <%#Eval("amount")%></span>
								                <small>ID - <a href="<%# string.Format("ViewLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>"><%#Eval("id")%></a></small>
                                                <div class="progress"><div class="progress-bar progress-bar-success" style="width: <%#Eval("percentage")%>%"><%#Eval("paid_count")%> of <%#Eval("payables_count")%></div></div>
							                </li>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            
                                        </EmptyDataTemplate>
                                    </asp:ListView>						
					            </div>
						            <div class="total-data bg-blue" >
							            <h2>Total <span class="pull-right">Php <asp:Label runat='server' ID='lblTotalLoan'></asp:Label></span></h2>							
						            </div>
				            </div>
                        </div>
					    <div class="tab-pane " id="withdrawals">
						    <div class="block">
					            <div class="header">
						            <h2>Withdrawals </h2>
						            <h3>Amount Withdrawn</h3>
					            </div>
					            <div class="content no-padding ">
						            <asp:ListView ID="lstWithdrawals" runat="server">
                                        <LayoutTemplate>
                                            <ul class="items">
                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
                                                <li style='padding: 3px 0px;'>
                                                    <div style='text-align:center;'>
                                                        <a href="ManageWithdrawals.aspx">more...</a>
                                                    </div>                                        
                                                </li>
                                            </ul>                
                                        </LayoutTemplate>
                                        <ItemTemplate>                                
                                            <li>
								                <i class="fa fa-file-text"></i><a href="<%# string.Format("Profile.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("user_id").ToString()))) %>"><%#Eval("name")%></a> <span class="pull-right value">Php <%#Eval("amount")%></span>
								                <small>ID - <a href="<%# string.Format("NewWithdrawal.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>"><%#Eval("id")%></a></small>
                                    
							                </li>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            
                                        </EmptyDataTemplate>
                                    </asp:ListView>	
					            </div>
						        <div class="total-data bg-blue" >
							        <h2>Total <span class="pull-right">Php <asp:Label runat='server' ID='lblTotalWithdrawals'></asp:Label></span></h2>
							
						        </div>
				            </div>
					    </div>
					    
				    </div>
			    </div>
			</div>	
			
            <div class="col-sm-6 col-sm-6">
                <div class="block-flat">
					<div class="header">
						<h3>Investment Chart</h3>
					</div>
					<div class="content overflow-hidden">
						<div id="piec1" style="height: 300px; padding: 0px; position: relative;">
						</div>
					</div>
				</div>
            </div>
            	
		</div>--%>            

        
        

                
        <asp:HiddenField ID="hdInvestmentChart" runat="server" />
    
    </div>
</asp:Content>
