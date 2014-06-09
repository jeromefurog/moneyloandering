<%@ Page Title="Money Loandering - Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ezLend.Default" %>
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

        <%--<div class="stats_bar">
            <div class="butpro butstyle">
				<div class="sub"><h2>Total Asset</h2><span><asp:Label ID="Label1" runat='server'>P--,---</asp:Label></span></div>
				
			</div>
            <div class="butpro butstyle">
				<div class="sub"><h2>Total Collectible</h2><span><asp:Label ID="Label2" runat='server'>P--,---</asp:Label></span></div>				
			</div>
			<div class="butpro butstyle">
				<div class="sub"><h2>Earnings</h2><span id="total_clientes"><asp:Label ID="lblEarnings" runat='server'></asp:Label></span></div>
				
			</div>
			<div class="butpro butstyle">
				<div class="sub"><h2>Cash On-Hand</h2><span><asp:Label ID="lblCashOnHand" runat='server'></asp:Label></span></div>
				
			</div>
            <div class="butpro butstyle">
				<div class="sub"><h2>Loans Payable</h2><span><asp:Label ID="Label3" runat='server'>P--,---</asp:Label></span></div>				
			</div>

            <div class="butpro butstyle">
				<div class="sub"><h2>Penalties</h2><span><asp:Label ID="Label4" runat='server'>P--,---</asp:Label></span></div>				
			</div>
			

		</div>--%>

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
							<h3 class="no-margin">COLLECTABLES</h3>
							<p class="color-success">Overall amount to be collected (interest included)</p>
						</div>
						<h1 class="no-margin">P<asp:Label ID="lblTotalCollectable" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>
					
		</div>

        <div class="row">

			
					
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
