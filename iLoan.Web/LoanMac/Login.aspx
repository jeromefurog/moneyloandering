<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoanMac.Web.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link href="css/pure-min.css" rel="stylesheet" type="text/css" />
    <link href="css/baby-blue.css" rel="stylesheet" type="text/css" />
    <link href="css/notifIt.css" rel="stylesheet" type="text/css" />
     
    <link rel="stylesheet" href="http://use.typekit.net/c/ed00b8/omnes-pro:n2:n3,proxima-nova:n1:n4:n7.X33:N:2,X35:N:2,Vmv:N:2,W0V:N:2,W0Y:N:2/d?3bb2a6e53c9684ffdc9a9efe1f5b2a62303f0a107c078b501a601d28c8e2edd714516b20f389cdf4d0f7806baf3d9cd5421f23f55150b514ac21ce5fcd0563dc217ff19c42386f81e4224b0e3df2135a11b1bba381da80f34ebb20386ca61589cfed552d3c7749aeae2c1affb17809efad64fcb69c8eb638d84326d8b274d56f758c9b7c2cc3147bd2a2a5dbb0b0385f467e1cc22a2f1e980e3763337ce881a382a20f9cd831158b7c2371eb6804583041eaac24a8b3c2d87c0f9f7f62193f1954a7cdda607c6643b0e4d2c62652877fcca3957f4ef2ac9114b789230ddb9ac67b4fc6add483528473803699c3999bbc62ae0ca8caa9c19a71f5aa525e4e70c4523fb12c52ccf7f224f0d1d4a1044c2af4c233f492d60ef8d4e18f05c0695685be6045eed0dd50856f145f9a39eacb4f3dd87138e6502a0116e09d25cc40bafb8198072a98f14d0cf6dc2fa51efe9b82ad3c49a7866df2a6e8a496c0af569d2c50dc2abc85915961a02412ac0ac48b36202d908d7e2909a8872093c52485ab2d4e48ae168cd79a095100781fa77e0b1f530af644f5793aee5fd4ea719ccce62e8ac46c693125aaa4e35624ca6b7db736c380894025f0c3b8eabe3e34e44d8af11c76b62cd48dfd13179e364b0ea12d8e811b8b4f56dccc394967415737e54b75211bd8fb0e">
    <script>
        try { Typekit.load(); } catch (e) { }
    </script>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.0.2.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <!-- show loader when loading page -->
    
    <script type="text/javascript">


        $(document).ready(function () {

            if ($('#hdError').length) 
            {
                if ($('#hdError').val() != '') {

                    notif({
                        msg: $('#hdError').val(),
                        type: "error",
                        position: "right",
                        opacity: 0.8
                    });
                
                }                 

            }
                      


        });
    </script>

    <title>LoanMac - Login</title>
</head>
<body>
    
    <div id="container">
        <form class="pure-form pure-form-stacked" runat="server">
            <fieldset>
                <legend>Welcome to LoanMac</legend>

                <label for="email">Username</label>
                <asp:TextBox ID="iUsername" style="width: 300px" runat="server" required placeholder="Username"></asp:TextBox>

                <label for="password">Password</label>
                <asp:TextBox id="iPassword" style="width: 300px" runat="server" required type="password" placeholder="Password"></asp:TextBox>
                               
                <label for="remember" class="pure-checkbox">
                    <asp:CheckBox ID="chkRememberMe" runat="server" /> Remember me
                    
                </label>

                <asp:Button ID="btnSubmit" class="pure-button pure-button-primary" runat="server" Text="Sign in" onclick="submit_Click" />
							
                
            </fieldset>
            
            <asp:HiddenField ID="hdError" runat="server" />
        </form>
    </div>

    
</body>
</html>
