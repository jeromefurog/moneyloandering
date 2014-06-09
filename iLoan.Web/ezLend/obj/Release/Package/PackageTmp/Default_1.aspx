<%@ Page Title="Money Loandering - Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default_1.aspx.cs" Inherits="ezLend.Default_1" %>
<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            

        });

    </script>

    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id='dvHead' runat='server' class="page-head">
      <asp:DropDownList ID="drpUser" runat="server" style='width:50%;' class="select2" AutoPostBack="true" OnSelectedIndexChanged="drpUser_SelectedIndexChanged">
        </asp:DropDownList>
        
    </div>
    <div class="cl-mcont">

       <div class="stats_bar">
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
			

		</div>

        <%--<div class="row">

			<div class="col-md-6">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<i class="fa fa-random fa-4x pull-left color-primary"></i> 
							<h3 class="no-margin">EARNINGS</h3>
							<p class="color-primary">Projected amount exclusive of withdrawals</p>
						</div>
						<h1 class="no-margin big-text">Php <asp:Label ID="lblEarnings" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>
			<div class="col-md-6">
				<div class="block-flat">
					<div class="content no-padding">
						<div class="overflow-hidden">
							<i class="fa fa-money fa-4x pull-left color-success"></i> 
							<h3 class="no-margin">CASH ON HAND</h3>
							<p class="color-success">Total withdrawable amount</p>
						</div>
						<h1 class="big-text no-margin">Php <asp:Label ID="lblCashOnHand" runat='server'></asp:Label></h1>							
					</div>
				</div>	
			</div>
					
		</div>--%>

        <div class="row dash-cols">
			<div class="col-sm-6 col-md-6">
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
                                </ul>                
                            </LayoutTemplate>
                            <ItemTemplate>                                
                                <li>
								    <i class="fa fa-file-text"></i><%#Eval("date")%> <span class="pull-right value">Php <%#Eval("amount")%></span>
								    <small>ID - <%#Eval("id")%></small>
                                    
							    </li>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <%--<p>Nothing here.</p>--%>
                            </EmptyDataTemplate>
                        </asp:ListView>						
					</div>
					<div class="total-data bg-blue" >
						<h2>Total <span class="pull-right">Php <asp:Label runat='server' ID='lblTotalInvestments'></asp:Label></span></h2>							
					</div>
				</div>
			</div>	
			
            <div class="col-sm-6 col-md-6">
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
                                </ul>                
                            </LayoutTemplate>
                            <ItemTemplate>                                
                                <li>
								    <i class="fa fa-file-text"></i><%#Eval("date")%> <span class="pull-right value">Php <%#Eval("amount")%></span>
								    <small>ID - <%#Eval("id")%></small>
                                    <%--<div class="progress"><div class="progress-bar progress-bar-success" style="width: 30%">30%</div></div>--%>
							    </li>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <%--<p>Nothing here.</p>--%>
                            </EmptyDataTemplate>
                        </asp:ListView>	
					</div>
						<div class="total-data bg-blue" >
							<h2>Total <span class="pull-right">Php <asp:Label runat='server' ID='lblTotalWithdrawals'></asp:Label></span></h2>
							
						</div>
				</div>
			</div>		
		</div>

        <div class="row dash-cols">
			<div class="col-sm-6 col-sm-6">
				<div class="block">
					<div class="header">
						<h2>Loaned Investment </h2>
						<h3>List of loans on your investments</h3>
					</div>
					<div class="content no-padding ">
                        <asp:ListView ID="lstLoaned" runat="server">
                            <LayoutTemplate>
                                <ul class="items">
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
                                </ul>                
                            </LayoutTemplate>
                            <ItemTemplate>                                
                                <li>
								    <i class="fa fa-file-text"></i><%#Eval("borrower")%> <span class="pull-right value">Php <%#Eval("amount")%></span>
								    <small>ID - <a href="<%# string.Format("ViewLoan.aspx?id={0}", LoanMac.Core.Utility.EncryptQueryString(HttpUtility.UrlEncode(Eval("id").ToString()))) %>"><%#Eval("id")%></a></small>
                                    <div class="progress"><div class="progress-bar progress-bar-success" style="width: <%#Eval("percentage")%>%"><%#Eval("paid_count")%> of <%#Eval("payables_count")%></div></div>
							    </li>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <%--<p>Nothing here.</p>--%>
                            </EmptyDataTemplate>
                        </asp:ListView>						
					</div>
						<div class="total-data bg-blue" >
							<h2>Total <span class="pull-right">Php <asp:Label runat='server' ID='lblTotalLoan'></asp:Label></span></h2>							
						</div>
				</div>
			</div>	
			
            		
		</div>

        

                
    
    </div>
</asp:Content>
