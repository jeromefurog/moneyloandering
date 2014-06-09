<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCHeader.ascx.cs" Inherits="iLoan.Web.UserControls.WUCHeader" %>

<script language="javascript" type="text/javascript">
</script>

<div class='header-content'>
    <div class='header-content-logo'>        
        <div class='left-logo' style="">
            <%--<img src= "../../Images/iib_logo.png" alt="PAS Logo" />--%>
            <asp:Label id="lblLogoHeader" runat='server'></asp:Label>
        </div>
        <div class='right-logo'>
            <%--<img src= "../../Images/lilly_logo.png" alt="Lilly Logo" />--%>
        </div>
        
    </div>
    <div class='header-content-name'>
        <div class='header-content-name-text'>
            <asp:Label ID="Label1" runat='server' Font-Size="8pt" ForeColor="#ffffff" Font-Bold='false'>Welcome</asp:Label>&nbsp;
            <asp:HyperLink ID="hlUsrName" runat="server" Font-Size="8pt" ForeColor="#ffffff" Font-Bold='true'>HyperLink</asp:HyperLink>&nbsp;
            <%--<asp:Label ID="lblUsrName" runat='server' Font-Size="8pt" ForeColor="#ffffff" Font-Bold='true'></asp:Label>&nbsp;--%>
            <asp:Label ID="lblL" runat="server"  Font-Size="8pt" ForeColor="#ffffff" 
                Text="|"></asp:Label>&nbsp;
            <asp:LinkButton ID="lbtnLogOut" ForeColor="#ffffff" Font-Underline="true" Font-Size="8pt" runat="server" onclick="lbtnLogOut_Click">Log Out</asp:LinkButton>&nbsp;
        </div>
        
    </div>
</div>