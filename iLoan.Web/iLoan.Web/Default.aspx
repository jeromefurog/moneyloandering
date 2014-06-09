<%@ Page Title="iLoan - Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="iLoan.Web._Default" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {


        });

    </script>

    
</asp:Content>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ScriptContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="PageContent">
    
    <div class="row-fluid">
		<div class="box span12">
			<div class="box-header well">
				<h2><i class="icon-info-sign"></i> Introduction</h2>
				<div class="box-icon">
					<%--<a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>--%>
					<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
					<%--<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>--%>
				</div>
			</div>
			<div class="box-content">
				<h1><small>Welcome to iLoan.</small></h1>
                <br />
				<p>Information about iLoan.</p>
					
				
				<div class="clearfix"></div>
			</div>
		</div>
	</div>   
        
</asp:Content>