<%@ Page Title="iLoan - Login" Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="iLoan.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <meta charset="utf-8">
	<title>iLoan - Login</title>
	
	<meta name="description" content="">
	<meta name="author" content="">

    <!-- remidiation styles -->
    <link href="css/bootstrap-cerulean.css" rel="stylesheet"/>    
    <link href="css/bootstrap-responsive.css" rel="stylesheet"/>
    <link href="css/charisma-app.css" rel="stylesheet"/>
    <link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet"/>
    <link href='css/fullcalendar.css' rel='stylesheet'/>
    <link href='css/fullcalendar.print.css' rel='stylesheet'  media='print'/>
    <link href='css/chosen.css' rel='stylesheet'/>
    <link href='css/uniform.default.css' rel='stylesheet'/>
    <link href='css/colorbox.css' rel='stylesheet'/>
    <link href='css/jquery.cleditor.css' rel='stylesheet'/>
    <link href='css/jquery.noty.css' rel='stylesheet'/>
    <link href='css/noty_theme_default.css' rel='stylesheet'/>
    <link href='css/elfinder.min.css' rel='stylesheet'/>
    <link href='css/elfinder.theme.css' rel='stylesheet'/>
    <link href='css/jquery.iphone.toggle.css' rel='stylesheet'/>
    <link href='css/opa-icons.css' rel='stylesheet'/>
    <link href='css/uploadify.css' rel='stylesheet'/>
    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	    <script src="js/html5.js"></script>
    <![endif]-->


    <!-- remidiation javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- jQuery -->
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <!-- jQuery UI -->
    <script type="text/javascript" src="js/jquery-ui-1.8.21.custom.min.js"></script>
    <!-- transition / effect library -->
    <script type="text/javascript" src="js/bootstrap-transition.js"></script>
    <!-- alert enhancer library -->
    <script type="text/javascript" src="js/bootstrap-alert.js"></script>
    <!-- modal / dialog library -->
    <script type="text/javascript" src="js/bootstrap-modal.js"></script>
    <!-- custom dropdown library -->
    <script type="text/javascript" src="js/bootstrap-dropdown.js"></script>
    <!-- scrolspy library -->
    <script type="text/javascript" src="js/bootstrap-scrollspy.js"></script>
    <!-- library for creating tabs -->
    <script type="text/javascript" src="js/bootstrap-tab.js"></script>
    <!-- library for advanced tooltip -->
    <script type="text/javascript" src="js/bootstrap-tooltip.js"></script>
    <!-- popover effect library -->
    <script type="text/javascript" src="js/bootstrap-popover.js"></script>
    <!-- button enhancer library -->
    <script type="text/javascript" src="js/bootstrap-button.js"></script>
    <!-- accordion library (optional, not used in demo) -->
    <script type="text/javascript" src="js/bootstrap-collapse.js"></script>
    <!-- carousel slideshow library (optional, not used in demo) -->
    <script type="text/javascript" src="js/bootstrap-carousel.js"></script>
    <!-- autocomplete library -->
    <script type="text/javascript" src="js/bootstrap-typeahead.js"></script>
    <!-- tour library -->
    <script type="text/javascript" src="js/bootstrap-tour.js"></script>
    <!-- library for cookie management -->
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <!-- calander plugin -->
    <script type="text/javascript" src='js/fullcalendar.min.js'></script>
    <!-- data table plugin -->
    <script type="text/javascript" src='js/jquery.dataTables.min.js'></script>

    <!-- chart libraries start -->
    <script type="text/javascript" src="js/excanvas.js"></script>
    <script type="text/javascript" src="js/jquery.flot.min.js"></script>
    <script type="text/javascript" src="js/jquery.flot.pie.min.js"></script>
    <script type="text/javascript" src="js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="js/jquery.flot.resize.min.js"></script>
    <!-- chart libraries end -->



    <!-- select or dropdown enhancer -->
    <script type="text/javascript" src="js/jquery.chosen.min.js"></script>
    <!-- checkbox, radio, and file input styler -->
    <script type="text/javascript" src="js/jquery.uniform.min.js"></script>
    <!-- plugin for gallery image view -->
    <script type="text/javascript" src="js/jquery.colorbox.min.js"></script>
    <!-- rich text editor library -->
    <script type="text/javascript" src="js/jquery.cleditor.min.js"></script>
    <!-- notification plugin -->
    <script type="text/javascript" src="js/jquery.noty.js"></script>
    <!-- file manager library -->
    <script type="text/javascript" src="js/jquery.elfinder.min.js"></script>
    <!-- star rating plugin -->
    <script type="text/javascript" src="js/jquery.raty.min.js"></script>
    <!-- for iOS style toggle switch -->
    <script type="text/javascript" src="js/jquery.iphone.toggle.js"></script>
    <!-- autogrowing textarea plugin -->
    <script type="text/javascript" src="js/jquery.autogrow-textarea.js"></script>
    <!-- multiple file upload plugin -->
    <script type="text/javascript" src="js/jquery.uploadify-3.1.min.js"></script>
    <!-- history.js for cross-browser state change on ajax -->
    <script type="text/javascript" src="js/jquery.history.js"></script>
    <!-- application script for Charisma demo -->
    <script type="text/javascript" src="js/charisma.js"></script>

    <!-- script for Detecting movile devices -->
    <script type="text/javascript" src="js/mobile-detector.js"></script>
</head>
<body>
    <div class="container-fluid">
		<div class="row-fluid">
		
			<div class="row-fluid">
				<div class="span12 center login-header">
					<h2>Welcome to iLoan</h2>
				</div><!--/span-->
			</div><!--/row-->
			
			<div class="row-fluid">                
				<div class="well span5 center login-box">
                    

                    <div class="alert alert-info ">							
						<%--<p>Unauthorized access and account sharing is not allowed. For help with using this system please contact your local service desk.</p>--%>
						<h6 class="alert-heading">To begin, please login with your Username and Password</h6>
			        </div>
                    
					<form id="Form1" class="form-horizontal" method="post" runat="server">
						<fieldset>
							<div class="input-prepend" title="System ID" data-rel="tooltip">
								<span class="add-on"><i class="icon-user"></i></span><%--<input autofocus class="input-large span10" name="username" id="username" type="text" runat='server' />--%>
                                <asp:TextBox id="txtLoginId" runat="server" class="input-large span10" ></asp:TextBox>
							</div>
							<div class="clearfix"></div>

							<div class="input-prepend" title="Password" data-rel="tooltip">
								<span class="add-on"><i class="icon-lock"></i></span><%--<input class="input-large span10" name="password" id="password" type="password" runat='server' />--%>
                                <asp:TextBox id="txtUserPass" runat="server" TextMode="Password" class="input-large span10 "></asp:TextBox>
							</div>
							<div class="clearfix"></div>

							
							<p class="center span5">
                            <asp:Button ID="btnSubmit" width='120px' EnableTheming="False" class="btn btn-primary" runat="server" Text="Login" onclick="btnLogin_Click" />
							
							</p>
						</fieldset>
					</form>

                    <div id='dvError' class="alert alert-error " runat="server" visible='false'>							
						<asp:Label ID="lblError" runat="server"  ></asp:Label>
			        </div>
                                                          
					
                    <div style='position: absolute; bottom: 5px;right:10px;'>
                        <%--<img alt="Lilly Logo" src="Images/lly_atm_logo_web.png" style='' />--%>
                    </div>
				</div><!--/span-->
			</div><!--/row-->
		</div><!--/fluid-row-->        
		
	</div><!--/.fluid-container-->
    
</body>
</html>
