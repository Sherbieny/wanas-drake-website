<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin.master" AutoEventWireup="true" CodeFile="Ad_categories.aspx.cs" Inherits="Ad_categories" %>

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
                                <div class="col-md-3">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <asp:Button ID="addButton" runat="server" Text="Add" OnClientClick="return false;" CssClass="btn btn-info btn-lg" type="button" data-toggle="collapse" data-target="#collapsePanel" aria-expanded="false" aria-controls="collapseExample">                                                
                                            </asp:Button>
                                             <asp:Button ID="editButton" runat="server" Visible="false" Text="Update" OnClientClick="return false;" CssClass="btn btn-info btn-lg" type="button" data-toggle="collapse" data-target="#collapsePanel" aria-expanded="false" aria-controls="collapseExample">                                                
                                            </asp:Button>    
                                        </div>
                                        <p>Click above to open the information panel</p>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="collapse" id="collapsePanel">
                                        <div class="well">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:Panel ID="inputPanel" Visible="true" runat="server" GroupingText="Category Information">
                                                        <div class="col-md-7 input-group">
                                                            <span class="input-group-addon" id="basic-addon1">Name</span>
                                                            <asp:TextBox ID="txt_category_name_add" runat="server" CssClass="form-control"
                                                                placeholder="Please enter the name and press Submit" MaxLength="100" aria-describedby="basic-addon1"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3 input-group">
                                                            <span class="input-group-addon" id="basic-addon3">Picture (248x366)</span>
                                                            <asp:FileUpload runat="server" ID="pic_path" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" aria-describedby="basic-addon3"/>
                                                        </div>
                                                         <asp:RequiredFieldValidator ID="nameValidator" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_category_name_add"></asp:RequiredFieldValidator>
                                                            
                                                        <div class="col-md-2 col-md-offset-10 up-margin">
                                                            <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-primary margin-bottom" Text="Submit" OnClick="btn_Insert_Click" CausesValidation="true" ValidationGroup="inputCheck" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="editPanel" Visible="false" runat="server" GroupingText="Category Information">
                                                        <div class="row">
                                                            <div class="col-md-7 input-group">
                                                                <span class="input-group-addon" id="basic-addon2">Name</span>
                                                                <asp:TextBox ID="txt_category_name_edit" runat="server" CssClass="form-control"
                                                                    placeholder="Please try again and press Save or press cancel" MaxLength="100" aria-describedby="basic-addon2"></asp:TextBox>
                                                            </div>
                                                             <div class="col-md-5 input-group">
                                                                <span class="input-group-addon" id="basic-addon5">Picture (375x485)</span>
                                                                <asp:FileUpload runat="server" ID="edit_pic_path" MaxLength="400" CssClass="filestyle" data-input="false" data-icon="false" aria-describedby="basic-addon5" />
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="nameValidaor2" runat="server" ValidationGroup="inputCheck" CssClass="validators"
                                                                        ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_category_name_edit"></asp:RequiredFieldValidator>
                                                           
                                                        </div>
                                                        <div class="row up-margin">
                                                            <div class="col-md-4 col-md-offset-8">
                                                                <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary margin-bottom" Text="Save" OnClick="btn_Save_Click" ValidationGroup="inputCheck" CausesValidation="true" />
                                                                <asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-danger margin-left" Text="Cancel" OnClick="btn_Cancel_Click" />
                                                            </div>                                                            
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="gridTable" class="panel panel-primary">
                                <div class="panel-heading">Categories</div>

                                <asp:GridView ID="thegrid" CssClass="table table-bordered table-striped table-hover" Visible="true" AutoGenerateColumns="false"
                                    EnableModelValidation="true" OnSelectedIndexChanged="select_item" OnRowDeleting="delete_item" DataKeyNames="ID" runat="server" GridLines="None">
                                    <Columns>

                                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:ImageField DataImageUrlField="Pic_Path" HeaderText="Picture" ControlStyle-Width="150px" ControlStyle-Height="150px"></asp:ImageField>

                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="alignCenter" ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-primary" ID="DLinkButton" runat="server" CausesValidation="false"
                                                    CommandName="Select" Text="Update"></asp:LinkButton>

                                                <asp:LinkButton CssClass="btn btn-danger" ID="DLinkButton2" runat="server" CausesValidation="false"
                                                    OnClientClick="return confirm('Are you sure, Deleting a Category will delete all its projects !!!?');this.style.display = 'none'"
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

