<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin.master" AutoEventWireup="true" CodeFile="Ad_home.aspx.cs" Inherits="Ad_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- content 
			================================================== -->
    <div id="content">
        <div class="inner-content">
            <div class="single-post">
                <div class="container">
                    <div class="single-post-content">
                        <div class="post-title">
                            <div class="row">
                                <div class="col-md-6">
                                    <h1 style="margin-top: 2vh;">Welcome to WDI Administration Portal</h1>
                                    <!--<span>architecture / exterior</span>-->
                                </div>
                            </div>
                        </div>

                        <!-- Administration Navigation Options  -->
                        <div class="services-box">
                            <p>Please choose one of the following options</p>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <a class="link-tag" href="Ad_projects.aspx">
                                                <span><i class="fa fa-arrow-circle-o-right"></i></span>
                                            </a>
                                            <h2>Projects</h2>
                                        </div>
                                        <p>Add, Remove and Update<br />
                                            <b>Note:</b> Removing a project will remove the assosiated pictures !!!
                                        </p>
                                    </div>
                                </div>
                                <div class="col-md-3" id="employeesPage3" runat="server">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <a class="link-tag" href="Ad_categories.aspx">
                                                <span><i class="fa fa-arrow-circle-o-right"></i></span>
                                            </a>
                                            <h2>Categories</h2>
                                        </div>
                                        <p>Add, Remove and Update <br />
                                            <b>Note:</b> Removing a category will remove the assosiated projects !!!
                                        </p>
                                    </div>
                                </div>
                                <div class="col-md-3" id="employeesPage2" runat="server">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <a class="link-tag" href="Ad_personnel.aspx">
                                                <span><i class="fa fa-arrow-circle-o-right"></i></span>
                                            </a>
                                            <h2>Personnel and Partners</h2>
                                        </div>
                                        <p>Add, Remove and Update</p>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <a class="link-tag" href="Ad_pictures.aspx">
                                                <span><i class="fa fa-arrow-circle-o-right"></i></span>
                                            </a>
                                            <h2>Pictures</h2>
                                        </div>
                                        <p>Add, Remove and Update</p>
                                    </div>
                                </div>                               
                            </div>
                            <div class="row" id="employeesPage" runat="server">
                                 <div class="col-md-3">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <a class="link-tag" href="Ad_employees.aspx">
                                                <span><i class="fa fa-arrow-circle-o-right"></i></span>
                                            </a>
                                            <h2>Employees</h2>
                                        </div>
                                        <p>Remove and Update</p>
                                    </div>
                                </div>
                            </div>                            

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End content -->

</asp:Content>

