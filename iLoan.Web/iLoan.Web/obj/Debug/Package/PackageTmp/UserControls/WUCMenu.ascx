<%@ Control Language="C#" AutoEventWireup="true" Inherits="iLoan.Web.UserControls.WUCMenu" Codebehind="WUCMenu.ascx.cs" %>


<div class='header-menu '>
    <ul class="menu-top" id='menucontrol' runat='server'>
        <li runat="server" id='liHome' visible='true'>
		    <a href="../Default.aspx" class="menu-button">
			    <span class="menu-label">Home</span>
		    </a>
	    </li>        
        <li runat="server" id='liAdmin' visible='true'>
		    <a href="javascript:void(0)" class="menu-button menu-drop">
			    <span class="menu-label">Admin</span>
		    </a>
		    <div class="menu-dropdown menu-dropdown6">
			    <ul class="menu-sub">
				    <li>
					    <a href="../ManageUser.aspx" class="menu-subbutton">
						    <span class="menu-label">Manage Users</span>
					    </a>
				    </li>				                   			    
			    </ul>                
		    </div>
	    </li>        
        <li runat="server" id='liHCPs' visible='true'>
		    <a href="../ManageBorrower.aspx" class="menu-button">
			    <span class="menu-label">Manage Borrower</span>
		    </a>
	    </li>        
        
        <li runat="server" id='liTrackingLog' visible='true'>
		    <a href="../ManageLoan.aspx" class="menu-button">
			    <span class="menu-label">Manage Loan</span>
		    </a>
	    </li>

        <li runat="server" id='li1' visible='true'>
		    <a href="../ManagePayables.aspx" class="menu-button">
			    <span class="menu-label">Manage Payables</span>
		    </a>
	    </li>

        <li runat="server" id='liTrackingSummary' visible='true'>
		    <a href="../ManageExpense.aspx" class="menu-button">
			    <span class="menu-label">Manage Expense</span>
		    </a>
	    </li>
        

        <!-- visible only in desktop -->
        <%--<li runat="server" id='liMenu3' visible='true' class='desktop'>
		    <a href="#" class="menu-button">
			    <span class="menu-label">Menu 3</span>
		    </a>
	    </li>--%>
        
    </ul>
    
</div>

