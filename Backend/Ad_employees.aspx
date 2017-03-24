<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin.master" AutoEventWireup="true" CodeFile="Ad_employees.aspx.cs" Inherits="Backend_Ad_employees" %>

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
                            <p>Choose an Employee to edit or delete</p>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="services-post">
                                        <div class="services-post-head">
                                            <asp:Button ID="editButton" runat="server" Visible="false" Text="Update" OnClientClick="return false;" CssClass="btn btn-info btn-lg" type="button" data-toggle="collapse" data-target="#collapsePanel" aria-expanded="false" aria-controls="collapseExample"></asp:Button>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="collapse" id="collapsePanel">
                                        <div class="well">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:Panel ID="editPanel" Visible="false" runat="server" GroupingText="Category Information">
                                                        <div class="row">
                                                            <div class="col-md-6 input-group">
                                                                <span class="input-group-addon" id="basic-addon2">Name</span>
                                                                <asp:TextBox ID="txt_employee_name" runat="server" CssClass="form-control"
                                                                    placeholder="Please enter your name" MaxLength="100" aria-describedby="basic-addon2"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-6 input-group">
                                                                <span class="input-group-addon" id="basic-addon3">Email</span>
                                                                <asp:TextBox ID="txt_employee_email" runat="server" CssClass="form-control"
                                                                    placeholder="Please enter your Email" MaxLength="100" aria-describedby="basic-addon3"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6 input-group">
                                                                <asp:RequiredFieldValidator ID="nameValidator" runat="server" ValidationGroup="inputCheck"
                                                                    ErrorMessage="Name is required !" ForeColor="Red" ControlToValidate="txt_employee_name"></asp:RequiredFieldValidator>

                                                            </div>
                                                            <div class="col-md-6 input-group">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="inputCheck"
                                                                    ErrorMessage="Email is Required !" ForeColor="Red" ControlToValidate="txt_employee_email"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationGroup="inputCheck"
                                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_employee_email" ErrorMessage="Invalid Email Format!"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6 input-group">
                                                                <span class="input-group-addon" id="basic-addon4">Type</span>
                                                                <asp:DropDownList ID="list_access_type" runat="server" CssClass="form-control" aria-describedby="basic-addon4">                                                                    
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-6 input-group">
                                                                <span class="input-group-addon" id="basic-addon20">Password</span>
                                                                <asp:TextBox ID="txt_employee_pass" runat="server" CssClass="form-control" type="password"
                                                                    placeholder="" MaxLength="100" aria-describedby="basic-addon20"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validators" runat="server" ControlToValidate="list_access_type" ValidationGroup="inputCheck"
                                                                    ErrorMessage="Please Choose!" InitialValue="-1"></asp:RequiredFieldValidator>                                                                
                                                            </div>
                                                            <div class="col-md-6">
                                                                <span>Please enter your new password above or leave it to keep old password</span>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-8 input-group">
                                                            </div>
                                                            
                                                            <div class="col-md-4 input-group">
                                                                <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btn_Save_Click" CausesValidation="true" ValidationGroup="inputCheck" />
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
                        </div>

                        <div id="gridTable" class="panel panel-primary">
                            <div class="panel-heading">Employees</div>

                            <asp:GridView ID="thegrid" CssClass="table table-bordered table-striped table-hover" Visible="true" AutoGenerateColumns="false"
                                EnableModelValidation="true" OnSelectedIndexChanged="select_item" OnRowDeleting="delete_item" DataKeyNames="ID" runat="server" GridLines="None">
                                <Columns>

                                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Email" HeaderText="EMail" />
                                    <asp:BoundField DataField="Access" HeaderText="Access Type" />

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

