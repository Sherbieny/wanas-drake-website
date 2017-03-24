<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personnel.aspx.cs" Inherits="Personnel" %>

<!DOCTYPE html>

<html lang="en" class="no-js">
<head runat="server">
    <title>WDI | Personnel</title>

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
                            <a class="active" href="history.html"><span>About us</span></a>
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
                        <li><a href="Contact.aspx"><span>Contact</span></a></li>
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
                <div class="inner-content">
                    <div class="about-page">
                        <div class="about-page-content">
                            <div class="container">
                                <div class="about-box">
                                    <h1>Personnel <span>&lt; back to home <a href="Home.aspx"><i class="fa fa-times"></i></a></span></h1>
                                    <p>The asset which WDI has invested in most extensively is its personnel the firm is highly selective when it comes to recruitment, bearing in mind that the staff are indeed the key to our success. Staff members are chosen according to WDI fundamentals. Personnel assigned to any particular development must possess the knowhow and relevant technical experience for each respective project. It therefore follows, that appropriate personnel are carefully selected for the task at hand. Personnel are capable of the highest standard of performance. The firm has unique and qualified staff with the knowledge and experience necessary for the field of architecture and engineering consultancy in general.</p>
                                    <p></p>
                                </div>
                                <div class="team-box">
                                    <h1>meet the creative minds of our company</h1>
                                <asp:PlaceHolder runat="server" ID="mainPersonContainer">
                                   
                                </asp:PlaceHolder>
                                    
                                    <h1>meet our partners</h1>

                                  <asp:PlaceHolder runat="server" ID="mainCompanyContainer">
                                   
                                </asp:PlaceHolder>
                                    
                                </div>
                            </div>
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
    <script type="text/javascript" src="js/jquery.appear.js"></script>
    <script type="text/javascript" src="js/raphael-min.js"></script>
    <script type="text/javascript" src="js/DevSolutionSkill.min.js"></script>
    <script type="text/javascript" src="js/jquery.quovolver.js"></script>
    <script type="text/javascript" src="js/plugins-scroll.js"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/jquery.imagesloaded.min.js"></script>
    <script type="text/javascript" src="js/retina-1.1.0.min.js"></script>
    <script type="text/javascript" src="js/script.js"></script>
</body>
</html>
