<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="description" content="">
<meta name="author" content="">
<link rel="icon" type="image/png" sizes="16x16" href=" plugins/images/favicon.png">
<title>Register - Bahria Airways</title>
<!-- Bootstrap Core CSS -->
<link href="bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
<!-- animation CSS -->
<link href="css/animate.css" rel="stylesheet">
<!-- Custom CSS -->
<link href="css/style.css" rel="stylesheet">
<!-- color CSS -->
<link href="css/colors/blue.css" id="theme"  rel="stylesheet">
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
</head>
<body>
<!-- Preloader -->
<div class="preloader">
  <div class="cssload-speeding-wheel"></div>
</div>
<section id="wrapper" class="login-register">
  <div class="login-box login-sidebar">
    <div class="white-box">
      <form class="form-horizontal form-material" id="loginform" runat="server">
         <a href="javascript:void(0)" class="text-center db"><b style="margin-top:5px; color:#2b2b2b"><span  class="fa fa-5x fa-anchor"></span></b><br><div style="color:#2b2b2b ; margin-top:6px; font-size:larger"><b >BAHRIA </b>Airways</div></a>
        <h3 class="box-title m-t-40 m-b-0">Register Now</h3><small>Create your account and enjoy</small> 
        <div class="form-group m-t-20">
          <div class="col-xs-12">
            <input class="form-control" type="text" required="" placeholder="Name" id="name" runat="server">
          </div>
        </div>
        <div class="form-group ">
          <div class="col-xs-12">
            <input class="form-control" type="text" required="" placeholder="Email" id="email" runat="server" pattern="[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[a-z]{2,3}$" title="Email Should Be Like e.g. name@yahoo.com">
          </div>
        </div>
        <div class="form-group ">
          <div class="col-xs-12">
            <input class="form-control" type="password" required="" placeholder="Password" id="password" runat="server">
          </div>
        </div>
        <div class="form-group">
          <div class="col-xs-12">
            <input class="form-control" type="password" required="" placeholder="Confirm Password" id="confirm_password" runat="server">
          </div>
        </div>
        <div class="form-group">
          <div class="col-md-12">
            <small id="error" runat="server" style="color:red;"></small>
             
          </div>
        </div>
        <div class="form-group text-center m-t-20">
          <div class="col-xs-12">
              <asp:Button ID="Button1" style="font-style:normal ; height:50px; padding:0;" class="btn btn-info btn-lg btn-block text-uppercase waves-effect waves-light" runat="server" Text="SIGN UP" OnClick="Button1_Click"/>
            </div>
        </div>
        <div class="form-group m-b-0">
          <div class="col-sm-12 text-center">
            <p>Already have an account? <a href="Default.aspx" class="text-primary m-l-5"><b>Sign In</b></a></p>
          </div>
        </div>
      </form>
    </div>
  </div>
</section>
<!-- jQuery -->
<script src=" plugins/bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap Core JavaScript -->
<script src="bootstrap/dist/js/bootstrap.min.js"></script>
<!-- Menu Plugin JavaScript -->
<script src=" plugins/bower_components/sidebar-nav/dist/sidebar-nav.min.js"></script>

<!--slimscroll JavaScript -->
<script src="js/jquery.slimscroll.js"></script>
<!--Wave Effects -->
<script src="js/waves.js"></script>
<!-- Custom Theme JavaScript -->
<script src="js/custom.min.js"></script>
<!--Style Switcher -->
<script src=" plugins/bower_components/styleswitcher/jQuery.style.switcher.js"></script>
</body>
</html>
<script>
    var password = document.getElementById("password")
  , confirm_password = document.getElementById("confirm_password");

    function validatePassword() {
        if (password.value != confirm_password.value) {
            confirm_password.setCustomValidity("Password Not Matched!");
        } else {
            confirm_password.setCustomValidity('');
        }
    }

    password.onchange = validatePassword;
    confirm_password.onkeyup = validatePassword;
</script>