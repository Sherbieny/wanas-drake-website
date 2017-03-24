﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<!DOCTYPE html>

<html lang="en" class="no-js">
<head runat="server">
    <title>WDI | Contacts</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

    <link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,300,100,700' rel='stylesheet' type='text/css'>

    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/magnific-popup.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/font-awesome.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/flexslider.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/style.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/responsive.css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
        <!-- Container -->
        <div id="container">
            <!-- Header
		    ================================================== -->
            <header class="fixit">

                <div style="color: #606060; text-transform: uppercase;" class="panel-heading">
                    <h4>Wanas Drake International</h4>
                    <h5>Architects</h5>
                </div>

                <div class="logo-box">
                    <a class="logo" href="Home.aspx">
                        <img alt="" src="images/logo.jpg"></a>
                </div>

                <a class="elemadded responsive-link" href="#">Menu</a>

                <div class="menu-box">
                    <ul class="menu">
                        <li>
                            <a href="Home.aspx"><span>Home</span></a>
                            <!--<ul class="dropdown">
                        <li><a href="index.html">Home 1</a></li>
                        <li><a href="home2.html">Home 2</a></li>
                        <li><a href="home3.html">Home 3</a></li>
                        <li><a href="home4.html">Home 4</a></li>
                        <li><a href="home5.html">Home 5</a></li>
                        <li><a href="Home.aspx">Home 6</a></li>
                    </ul>-->
                        </li>
                        <li class="drop">
                            <a href="history.html"><span>About us</span></a>
                            <ul class="dropdown">
                                <li><a href="history.html">History</a></li>
                                <li><a href="mission.html">Mission</a></li>
                                <li><a href="Personnel.aspx">Personnel</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="services.html"><span>Services</span></a>
                            <!--<ul class="dropdown">
                        <li><a href="services.html">Services</a></li>
                        <li><a href="error-404.html">Error 404</a></li>
                    </ul>-->
                        </li>
                        <%--<li>
                            <a href="Categories.aspx"><span>Projects</span></a>
                        </li>--%>
                        <li><a class="active" href="Contact.aspx"><span>Contact</span></a></li>
                    </ul>
                </div>
                <div class="header-foot">
                    <div class="social-box">
                        <ul class="social-icons">
                            <li><a href="#" class="facebook"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#" class="twitter"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="#" class="google"><i class="fa fa-google-plus"></i></a></li>
                            <li><a href="#" class="linkedin"><i class="fa fa-linkedin"></i></a></li>
                            
                            <li><a href="Backend/Ad_register.aspx" target="_blank"><i class="fa fa-cogs"></i></a></li>
                        </ul>
                    </div>

                    <div class="copyright-box">
                        <p>WDI 2015. All rights reserved</p>
                        <p>Powered by <a href="http://www.csharkstudio.com" target="_blank">CSHARK</a></p>
                    </div>
                </div>

            </header>
            <!-- End Header -->

            <!-- content 
			================================================== -->
            <div id="content">
                <div class="contact-page">
                    <div class="map"></div>
                    <div class="contact-box">
                        <div class="top-contact-part" style="margin-bottom: 11px;">
                            <span>&lt; back to home <a href="Home.aspx"><i class="fa fa-times"></i></a></span>
                        </div>
                        <h2>Contact</h2>
                        <p class="contact-info">
                            <span>28 El-Nasr St., Maadi</span>
                            <span>Cairo, Egypt 11435</span>
                            <span><i class="fa fa-phone"></i>+2 02 2517 0155</span>
                            <span>Fax: +2 02 2517 0155</span>
                            <span>info@wdi-architects.com</span>
                        </p>
                        <div id="contact-form" class="container">
                            <h4>Write us a Message</h4>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" name="name" ID="name" type="text" placeholder="Your name"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="inputCheck"
                                        ErrorMessage="Name is Required !" ForeColor="Red" ControlToValidate="name"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" name="mail" ID="mail" type="text" placeholder="Your e-mail"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="inputCheck"
                                        ErrorMessage="Email is Required !" ForeColor="Red" ControlToValidate="mail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationGroup="inputCheck"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="mail" ErrorMessage="Invalid Email Format!"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" TextMode="MultiLine" name="comment" ID="comment" placeholder="Your Message"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="inputCheck"
                                        ErrorMessage="Message is Required !" ForeColor="Red" ControlToValidate="comment"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-0"></div>
                                <div class="col-md-12 input-group">
                                    <span class="input-group-addon" id="basic-addon7">Attachment</span>
                                    <asp:FileUpload ID="email_attachment" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" runat="server" aria-describedby="basic-addon7"></asp:FileUpload>
                                </div>
                            </div>
                            <asp:Button type="submit" runat="server" name="login-submit" ID="passRecover_submit" CssClass="main-button up-margin" Text="Send Now" OnClick="send_Mail" CausesValidation="true" ValidationGroup="inputCheck" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- End content -->

        </div>
        <!-- End Container -->
    </form>

    <div class="preloader">
        <img alt="" src="images/preloader.GIF">
    </div>

    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.migrate.js"></script>
    <script type="text/javascript" src="js/plugins-scroll.js"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/jquery.imagesloaded.min.js"></script>
    <script type="text/javascript" src="js/retina-1.1.0.min.js"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="js/gmap3.min.js"></script>
    <script type="text/javascript" src="js/script.js"></script>
    <script src="js/bootstrap-filestyle.min.js"></script>
</body>
</html>
