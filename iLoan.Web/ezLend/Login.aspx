<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ezLend.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="shortcut icon" href="images/favicon.png">

	<title>Money Loandering - Login</title>
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,400italic,700,800' rel='stylesheet' type='text/css'>
	<link href='http://fonts.googleapis.com/css?family=Raleway:300,200,100' rel='stylesheet' type='text/css'>

	<!-- Bootstrap core CSS -->
	<link href="js/bootstrap/dist/css/bootstrap.css" rel="stylesheet">

	<link rel="stylesheet" href="fonts/font-awesome-4/css/font-awesome.min.css">

	<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
	<!--[if lt IE 9]>
	  <script src="../../assets/js/html5shiv.js"></script>
	  <script src="../../assets/js/respond.min.js"></script>
	<![endif]-->

	<!-- Custom styles for this template -->
	<link href="css/style.css" rel="stylesheet" />	

</head>
<body>
   
    <div id="cl-wrapper" class="login-container">

	    <div class="middle-login">
		    <div class="block-flat">
			    <div class="header">							
				    <h3 class="text-center"><img class="logo-img" src="images/logo.png" alt="logo"/>MoneyLoandering</h3>
			    </div>
			    <div>
				    <form id="form1" runat="server" style="margin-bottom: 0px !important;" class="form-horizontal">
					    <div class="content">
						    <h4 class="title">Login Access</h4>
							    <div class="form-group">
								    <div class="col-sm-12">
									    <div class="input-group">
										    <span class="input-group-addon"><i class="fa fa-user"></i></span>
										    <asp:TextBox ID="iUsername" runat="server" required type="text" placeholder="Username" class="form-control"></asp:TextBox>
									    </div>
								    </div>
							    </div>
							    <div class="form-group">
								    <div class="col-sm-12">
									    <div class="input-group">
										    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
										    <asp:TextBox id="iPassword" runat="server" type="password" placeholder="Password" class="form-control"></asp:TextBox>
									    </div>
								    </div>
							    </div>
							
					    </div>
					    <div class="foot">						    
                            <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Log In" onclick="submit_Click" />
					    </div>
				    </form>
			    </div>
		    </div>
		    <div class="text-center out-links"><a href="#">Copyright &copy; 2014. All rights reserved.</a></div>
	    </div> 
	
    </div>

    <script src="js/jquery.js"></script>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.flot/jquery.flot.js"></script>
    <script type="text/javascript" src="js/jquery.flot/jquery.flot.pie.js"></script>
    <script type="text/javascript" src="js/jquery.flot/jquery.flot.resize.js"></script>
    <script type="text/javascript" src="js/jquery.flot/jquery.flot.labels.js"></script>

</body>
</html>
