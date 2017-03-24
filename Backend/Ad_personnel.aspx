<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin.master" AutoEventWireup="true" CodeFile="Ad_personnel.aspx.cs" Inherits="Backend_Ad_personnel" %>

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
                            <asp:Panel ID="mainPanel" runat="server" Visible="true">
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
                                                        <asp:Panel ID="inputPanel" Visible="true" runat="server" GroupingText="Personnel Information">


                                                            <!-- ******************PERSONNEL ATTRIBUTES*********************************************** -->


                                                            <!-- *********Personnel Name************************* -->
                                                            <div class="row">
                                                                <div class="col-md-12 input-group">


                                                                    <span class="input-group-addon" id="basic-addon1">Name</span>
                                                                    <asp:TextBox ID="txt_person_name" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter the name" MaxLength="100" aria-describedby="basic-addon1"></asp:TextBox>
                                                                </div>
                                                                 <asp:RequiredFieldValidator ID="nameValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_person_name"></asp:RequiredFieldValidator>
                                                            
                                                            </div>



                                                            <!-- *********person Title Field************************* -->
                                                           
                                                             <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon4">Title</span>
                                                                    <asp:TextBox ID="txt_person_title" MaxLength="100" runat="server" CssClass="form-control"
                                                                        placeholder="ex: Heliopolis, Cairo, Egypt" aria-describedby="basic-addon4"></asp:TextBox>
                                                                </div>
                                                                  <asp:RequiredFieldValidator ID="titleValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_person_title"></asp:RequiredFieldValidator>
                                                            
                                                            </div>

                                                            <!-- *********person Description Field************************* -->
                                                           
                                                             <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon3">Description</span>
                                                                    <asp:TextBox ID="txt_person_description" TextMode="MultiLine" runat="server" CssClass="form-control"
                                                                        placeholder="Please enter personnel description here" aria-describedby="basic-addon3"></asp:TextBox>
                                                                </div>
                                                                  <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_person_description"></asp:RequiredFieldValidator>
                                                            
                                                            </div>


                                                            <!-- *********personnel Type Area Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-12 input-group">
                                                                    <span class="input-group-addon" id="basic-addon2">Type</span>
                                                                    <asp:DropDownList ID="list_person_type" runat="server" CssClass="form-control">                                                                                                                                 
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validators" runat="server" ControlToValidate="list_person_type" ValidationGroup="inputCheck"
                                                                    ErrorMessage="Please Choose!" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator> 
                                                            </div>
                                                           
                                                            <!-- *********person Main Picture Upload Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-6 input-group">
                                                                    <span class="input-group-addon" id="basic-addon7">Main Picture (248x366)</span>
                                                                    <asp:FileUpload ID="person_pic_path" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" runat="server" aria-describedby="basic-addon7"></asp:FileUpload>
                                                                </div>
                                                                <div class="col-md-6 input-group">
                                                                    <span class="input-group-addon" id="basic-addon20">Small Picture (166x163)</span>
                                                                    <asp:FileUpload ID="person_picSmall_path" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" runat="server" aria-describedby="basic-addon20"></asp:FileUpload>
                                                                </div>
                                                            </div>

                                                                <!-- *********Buttons Field************************* -->
                                                            <div class="row up-margin">
                                                                <div class="col-md-6"></div>
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-primary margin-bottom" Text="Submit" OnClick="btn_Insert_Click" CausesValidation="true" ValidationGroup="inputCheck" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btn_save" Visible="false" runat="server" CssClass="btn btn-primary margin-bottom" Text="Save" OnClick="btn_Save_Click" CausesValidation="true" ValidationGroup="inputCheck"  />
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
                                <div class="panel-heading">Personnel</div>

                                <asp:GridView ID="thegrid" CssClass="table table-bordered table-striped table-hover table-responsive" Visible="true" AutoGenerateColumns="false"
                                    EnableModelValidation="true" OnSelectedIndexChanged="select_item" OnRowDeleting="delete_item" DataKeyNames="ID" runat="server" GridLines="None">
                                    <Columns>

                                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />                                       
                                        <asp:BoundField DataField="title" HeaderText="Title" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />                                        
                                        <asp:BoundField DataField="type" HeaderText="Type;"/>
                                        <asp:BoundField DataField="Pic_Path" HeaderText="Main Picture" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />                                                                                
                                        <asp:BoundField DataField="PicSmall_Path" HeaderText="Small Picture" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />                                                                                

                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="alignCenter" ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-primary" ID="DLinkButton" runat="server" CausesValidation="false"
                                                    CommandName="Select" Text="Update"></asp:LinkButton>

                                                <asp:LinkButton CssClass="btn btn-danger" ID="DLinkButton2" runat="server" CausesValidation="false"
                                                    OnClientClick="return confirm('Are you sure?');this.style.display = 'none'"
                                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                    </Columns>
                                     <SelectedRowStyle Font-Bold="True" ForeColor="Black" />                                    
                                    <HeaderStyle Font-Size="Medium" />

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

