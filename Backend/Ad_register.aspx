<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Ad_register.aspx.cs" Inherits="Backend_Ad_register" %>

<!doctype html>


<html lang="en" class="no-js">
<head runat="server">
    <title>WDI</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

    <link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,300,100,700' rel='stylesheet' type='text/css' />

    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../css/magnific-popup.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../css/font-awesome.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../css/flexslider.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../css/responsive.css" media="screen" />
    <link type="text/css" href="../css/registerStyle.css" rel="stylesheet" media="screen" />

</head>
<body style="background-color: #ffffff !important;">
    <form id="form1" runat="server">
        <!-- Container -->
        <div id="container" style="background-color: #ffffff;">
            <!-- Header
		    ================================================== -->
            <header style="border-right-color: grey; border-right-width: 0.2vw; border-right-style: solid">

                <div class="logo-box">
                    <a class="logo" href="../Home.aspx" target="_blank">
                        <img alt="" src="../images/logo.jpg" /></a>
                </div>

                <a class="elemadded responsive-link" href="#">Menu</a>

                <div class="menu-box">
                    <ul class="menu">
                        <li>
                            <a href="Ad_home.aspx"><span>Home</span></a>
                        </li>
                        <li>
                            <a href="Ad_projects.aspx"><span>Projects</span></a>
                        </li>
                        <li>
                            <a href="Ad_categories.aspx"><span>Categories</span></a>
                        </li>
                        <li>
                            <a href="Ad_personnel.aspx"><span>Personnel</span></a>
                        </li>
                        <li>
                            <a href="Ad_pictures.aspx"><span>Pictures</span></a>
                        </li>
                    </ul>
                </div>
                <div class="header-foot">
                    <div class="copyright-box">
                        <p>WDI 2015. All rights reserved</p>
                        <p>Powered by <a href="http://www.csharkstudio.com" target="_blank">CSHARK</a></p>
                    </div>
                </div>

            </header>

            <div class="container">
                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <div class="panel panel-login">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-6">
                                        <a href="#" class="active" id="login-form-link">Login</a>
                                    </div>
                                    <div class="col-xs-6">
                                        <a href="#" id="register-form-link">Register</a>
                                    </div>
                                </div>
                                <hr>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">

                                        <!--/////////////////// Login Form \\\\\\\\\\\\\\\\\\\\\\\\\ -->
                                        <div id="login-form" style="display: block;">
                                            <div class="form-group">
                                                <asp:TextBox type="text" runat="server" name="username" ID="log_username" TabIndex="1" CssClass="form-control" placeholder="Username" value=""></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox type="password" runat="server" name="password" ID="log_password" TabIndex="2" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-sm-6 col-sm-offset-3">
                                                        <asp:Button type="submit" runat="server" name="login-submit" ID="log_submit"
                                                            TabIndex="4" CssClass="form-control btn btn-login" Text="Log In" OnClick="btn_Login_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="text-center">
                                                            <a href="#" tabindex="5" id="forgot-password" class="forgot-password">Forgot Password?</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <!--/////////////////// Forgot Password Form \\\\\\\\\\\\\\\\\\\\\\\\\ -->
                                        <div id="forgot-password-form" style="display: none;">
                                            <h5>Enter your Email and a new password will be sent to you</h5>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txt_recover_mail" TabIndex="2" CssClass="form-control" placeholder="Email" value=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="inputRecoverCheck"
                                                    ErrorMessage="Email is Required !" ForeColor="Red" ControlToValidate="txt_recover_mail"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="inputRecoverCheck"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_recover_mail" ErrorMessage="Invalid Email Format!"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <asp:Button type="submit" runat="server" name="login-submit" ID="passRecover_submit" CausesValidation="true" ValidationGroup="inputRecoverCheck"
                                                            TabIndex="4" CssClass="form-control btn btn-success" Text="Recover Password" OnClick="btn_Recover_Click" />
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:Button type="submit" runat="server" name="login-submit" ID="passRecover_cancel"
                                                            TabIndex="4" CssClass="form-control btn btn-danger" Text="Cancel" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <!--/////////////////// Register Form \\\\\\\\\\\\\\\\\\\\\\\\\ -->
                                        <div id="register-form" style="display: none;">
                                            <div class="form-group">
                                                <asp:TextBox type="text" runat="server" name="username" ID="reg_username" TabIndex="1" CssClass="form-control" placeholder="Username" value=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="inputCheck"
                                                    ErrorMessage="Name is Required !" ForeColor="Red" ControlToValidate="reg_password"></asp:RequiredFieldValidator>                                            
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="reg_email" TabIndex="1" CssClass="form-control" placeholder="Email Address" value=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="inputCheck"
                                                    ErrorMessage="Email is Required !" ForeColor="Red" ControlToValidate="reg_email"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationGroup="inputCheck"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="reg_email" ErrorMessage="Invalid Email Format!"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox type="password" runat="server" name="password" ID="reg_password" TabIndex="2" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="inputCheck"
                                                    ErrorMessage="Password is Required !" ForeColor="Red" ControlToValidate="reg_password"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox type="password" runat="server" name="confirm-password" ID="reg_confirm_password" TabIndex="2" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-sm-6 col-sm-offset-3">
                                                        <asp:Button type="submit" runat="server" name="register-submit" ID="reg_register_submit" CausesValidation="true" ValidationGroup="inputCheck"
                                                            TabIndex="4" CssClass="form-control btn btn-register" Text="Register Now" OnClick="btn_Register_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="preloader">
            <img alt="" src="../images/preloader.GIF" />
        </div>

        <script type="text/javascript" src="../js/jquery.min.js"></script>
        <script type="text/javascript" src="../js/jquery.migrate.js"></script>
        <script type="text/javascript" src="../js/jquery.appear.js"></script>
        <script type="text/javascript" src="../js/raphael-min.js"></script>
        <script type="text/javascript" src="../js/DevSolutionSkill.min.js"></script>
        <script type="text/javascript" src="../js/jquery.quovolver.js"></script>
        <script type="text/javascript" src="../js/plugins-scroll.js"></script>
        <script type="text/javascript" src="../js/bootstrap.js"></script>
        <script type="text/javascript" src="../js/jquery.imagesloaded.min.js"></script>
        <script type="text/javascript" src="../js/retina-1.1.0.min.js"></script>
        <script type="text/javascript" src="../js/script.js"></script>
        <script src="../js/bootstrap-filestyle.min.js"></script>


    </form>
</body>
</html>
