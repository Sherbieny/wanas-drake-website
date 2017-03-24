<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin.master" AutoEventWireup="true" CodeFile="Ad_projects.aspx.cs" Inherits="Ad_projects" %>

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
                            <div class="row">
                                <asp:Panel runat="server" ID="categoryChoicePanel" Visible="true">
                                    <div class="col-md-4">
                                        <p>Please Choose a Category to view the related projects</p>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="initial_category_list" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="getTable">
                                            <asp:ListItem Value="-1">Open to Choose</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="mainPanel" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="services-post">
                                            <div class="services-post-head">
                                                <asp:Button ID="addButton" runat="server" Text="Add" OnClientClick="return false;" CssClass="btn btn-info btn-lg" type="button" data-toggle="collapse" data-target="#collapsePanel" aria-expanded="false" aria-controls="collapseExample"></asp:Button>
                                                <asp:Button ID="editButton" runat="server" Visible="false" Text="Update" OnClientClick="return false;" CssClass="btn btn-info btn-lg" type="button" data-toggle="collapse" data-target="#collapsePanel" aria-expanded="false" aria-controls="collapseExample"></asp:Button>
                                            </div>
                                            <p>Click above to open the information panel</p>
                                        </div>
                                    </div>
                                    <div class="col-md-9">
                                        <div class="collapse" id="collapsePanel">
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Panel ID="inputPanel" Visible="true" runat="server" GroupingText="Project Information">


                                                            <!-- ******************PROJECT ATTRIBUTES****************************************************************** -->


                                                            <!-- *********Project Name and Category DropDown List Field************************* -->
                                                            <div class="row">
                                                                <div class="col-md-6 input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Name</span>
                                                                    <asp:TextBox ID="txt_project_name_add" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter the name" MaxLength="100" aria-describedby="basic-addon1"></asp:TextBox>                                                                    
                                                                </div>

                                                                <div class="col-md-6 input-group">
                                                                    <span class="input-group-addon" id="basic-addon2">Category</span>
                                                                    <asp:DropDownList ID="list_project_category" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="-1">Open to Choose</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:RequiredFieldValidator ID="nameValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_project_name_add"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="validators" runat="server" ControlToValidate="list_project_category" ValidationGroup="inputCheck"
                                                                    ErrorMessage="Please Choose!" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>    
                                                                    </div>
                                                                </div>                                                                
                                                            </div>



                                                            <!-- *********Project Description Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon3">Description</span>
                                                                    <asp:TextBox ID="txt_project_description" TextMode="MultiLine" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter project description here" aria-describedby="basic-addon3"></asp:TextBox>                                                                    
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Description is required !" ForeColor="Red" ControlToValidate="txt_project_description"></asp:RequiredFieldValidator>
                                                            </div>

                                                            
                                                            <!-- *********Project Small Description Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon19">Small Description</span>
                                                                    <asp:TextBox ID="txt_project_small_description" TextMode="MultiLine" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter a small project description here" aria-describedby="basic-addon19"></asp:TextBox>                                                                    
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Description is required !" ForeColor="Red" ControlToValidate="txt_project_small_description"></asp:RequiredFieldValidator>
                                                            </div>



                                                            <!-- *********Project Location Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon4">Location</span>
                                                                    <asp:TextBox ID="txt_project_location" MaxLength="100" runat="server" CssClass="form-control"
                                                                        placeholder="ex: Heliopolis, Cairo, Egypt" aria-describedby="basic-addon4"></asp:TextBox>                                                                     
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="locationValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Location is required !" ForeColor="Red" ControlToValidate="txt_project_location"></asp:RequiredFieldValidator>
                                                            </div>

                                                            <!-- *********Project Total Area Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon5">Total Area</span>
                                                                    <asp:TextBox ID="txt_total_area" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter the total area in meter squared" MaxLength="100" aria-describedby="basic-addon5"></asp:TextBox>                                                                    
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="totalAreaValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                    ErrorMessage="Total Area is Required!" ForeColor="Red" ControlToValidate="txt_total_area" ></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="inputCheck"
                                                                        ValidationExpression="^(\d+|(\d*\.{1}\d{1,2}){1})$" ControlToValidate="txt_total_area" ErrorMessage="Numbers Only!"></asp:RegularExpressionValidator>
                                                                             
                                                            </div>

                                                            <!-- *********Project BuiltUp Area Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon6">Built-Up Area</span>
                                                                    <asp:TextBox ID="txt_builtup_area" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter the Built-up area in meter squared" MaxLength="100" aria-describedby="basic-addon6"></asp:TextBox>                                                                    
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="builtupAreaValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                    ErrorMessage="Builtup Area is Required!" ForeColor="Red" ControlToValidate="txt_builtup_area" ></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationGroup="inputCheck"
                                                                        ValidationExpression="^(\d+|(\d*\.{1}\d{1,2}){1})$" ControlToValidate="txt_builtup_area" ErrorMessage="Numbers Only!"></asp:RegularExpressionValidator>
                                                            </div>

                                                            <!-- *********Project Main Picture Upload Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-9 input-group">
                                                                    <span class="input-group-addon" id="basic-addon7">Main Picture</span>
                                                                    <asp:FileUpload ID="main_project_pic_path" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" runat="server" aria-describedby="basic-addon7"></asp:FileUpload>
                                                                    <span> Please refer to the image sizes reference to specify the correct dimension </span>
                                                                </div>                                                            

                                                                <!-- *********Buttons Field************************* -->
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-primary margin-bottom" Text="Submit" OnClick="btn_Insert_Click" CausesValidation="true" ValidationGroup="inputCheck" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btn_save" Visible="false" runat="server" CssClass="btn btn-primary margin-bottom" Text="Save" OnClick="btn_Save_Click" CausesValidation="true" ValidationGroup="inputCheck" />
                                                                    <asp:Button ID="btn_cancel" Visible="false" runat="server" CssClass="btn btn-danger margin-bottom" Text="Cancel" OnClientClick="changeButtonsBack()" OnClick="btn_Cancel_Click" />
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
                            <div id="gridTable" class="panel panel-primary">
                                <div class="panel-heading">Projects</div>

                                <asp:GridView ID="thegrid" CssClass="table table-bordered table-striped table-hover table-responsive" Visible="true" AutoGenerateColumns="false"
                                    EnableModelValidation="true" OnSelectedIndexChanged="select_item" OnRowDeleting="delete_item" DataKeyNames="ID" runat="server" GridLines="None">
                                    <Columns>

                                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Category" HeaderText="Category" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Main_Pic_Path" HeaderText="Main Picture" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Location" HeaderText="Location" />
                                        <asp:BoundField DataField="Total_Area" HeaderText="Total Area &#109;&#178;" />
                                        <asp:BoundField DataField="BuiltUp_Area" HeaderText="Built-up Area &#109;&#178;" />
                                        <asp:BoundField DataField="Small_Description" HeaderText="Small Descritpion" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />

                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="alignCenter" ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-primary" ID="DLinkButton" runat="server" CausesValidation="false"
                                                    CommandName="Select" Text="Update"></asp:LinkButton>
                                               
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="alignCenter" ShowHeader="false">
                                            <ItemTemplate>
                                                 <asp:LinkButton CssClass="btn btn-danger" ID="DLinkButton2" runat="server" CausesValidation="false"
                                                    OnClientClick="return confirm('Are you sure?');this.style.display = 'none'"
                                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle Font-Size="Medium" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="Black" />

                                </asp:GridView>

                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End content -->

</asp:Content>
