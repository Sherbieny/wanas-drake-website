<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin.master" AutoEventWireup="true" CodeFile="Ad_pictures.aspx.cs" Inherits="Backend_Ad_pictures" %>

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
                            
                            <div class="row push-down">
                                <asp:Panel runat="server" ID="categoryChoicePanel" Visible="true">
                                    <div class="col-md-5">
                                        <p>Please Choose a Category to view the related projects</p>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="initial_category_list" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="getTable">
                                            <asp:ListItem Value="-1">Open to Choose</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        
                                    </div>
                                    
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="mainPanel" runat="server" Visible="false">
                                <div class="row">
                                    <span style="padding-left:35em;">&lt; back to Project View <a href="Ad_pictures.aspx"><i class="fa fa-times"></i></a></span>
                                    <div class="col-md-3">
                                        <div class="services-post">
                                            <div class="services-post-head">
                                                <asp:Button ID="addButton" runat="server" Text="Add" OnClientClick="return false;" CssClass="btn btn-info btn-lg" type="button" data-toggle="collapse" data-target="#collapsePanel" aria-expanded="false" aria-controls="collapseExample"></asp:Button>                                                
                                            </div>
                                            <p>Click above to open the information panel</p>
                                        </div>
                                    </div>
                                    <div class="col-md-9">
                                        <div class="collapse" id="collapsePanel">
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Panel ID="inputPanel" Visible="false" runat="server" GroupingText="Project Information">

                                                                  <!-- ******************Pictures Uploads****************************************************************** -->

                                                            <div class="row up-margin">
                                                                <div class="col-md-6 input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Picture (830x550)</span>
                                                                    <asp:FileUpload ID="FileUpload0" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" runat="server" aria-describedby="basic-addon1"></asp:FileUpload>
                                                                </div>  
                                                                
                                                                  <!-- *********Buttons Field************************* -->                                                               
                                                                <div class="col-md-6">
                                                                    <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary margin-bottom" Text="Save" OnClick="btn_Save_Click" />
                                                                    <asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-danger margin-bottom" Text="Cancel" OnClientClick="changeButtonsBack()" OnClick="btn_Cancel_Click" />
                                                                </div>                                                              
                                                            </div>
                                                                                                                                       
                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </asp:Panel>
                            <asp:Panel ID="gridTable" runat="server" CssClass="panel panel-primary">
                                <div class="panel-heading">Projects</div>

                                <asp:GridView ID="thegrid" CssClass="table table-bordered table-striped table-hover table-responsive" Visible="true" AutoGenerateColumns="false"
                                    EnableModelValidation="true" OnSelectedIndexChanged="select_item" OnRowDeleting="delete_item" DataKeyNames="ID" runat="server" GridLines="None">
                                    <Columns>

                                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Name" HeaderText="Project Name" />
                                        <asp:BoundField DataField="Pic_Count" HeaderText="Picture Count" />


                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="alignCenter" ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-primary" ID="DLinkButton" runat="server" CausesValidation="false"
                                                    CommandName="Select" Text="View"></asp:LinkButton>

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle Font-Size="Medium" />                                    

                                </asp:GridView>

                            </asp:Panel>

                            <asp:Panel ID="pictureTable" runat="server" Visible="false" CssClass="panel panel-primary">
                                <div class="panel-heading">Pictures</div>

                                <asp:GridView ID="picgrid" CssClass="table table-bordered table-striped table-hover table-responsive" Visible="true" AutoGenerateColumns="false"
                                    EnableModelValidation="true" OnRowDeleting="delete_item" DataKeyNames="ID" runat="server" GridLines="None">
                                    <Columns>

                                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Name" HeaderText="Project Name" />
                                        <asp:ImageField DataImageUrlField="PictureUrl" HeaderText="Picture" ControlStyle-Width="150px" ControlStyle-Height="150px"></asp:ImageField>


                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="alignCenter" ShowHeader="false">
                                            <ItemTemplate>

                                                <asp:LinkButton CssClass="btn btn-danger" ID="DLinkButton2" runat="server" CausesValidation="false"
                                                    OnClientClick="return confirm('Are you sure?');this.style.display = 'none'"
                                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle Font-Size="Medium" />                                    

                                </asp:GridView>

                            </asp:Panel>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End content -->

</asp:Content>

