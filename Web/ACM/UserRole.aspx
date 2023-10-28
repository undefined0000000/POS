<%@ Page Title="Roles" Language="C#" MasterPageFile="~/CRM/CRMMaster.Master" AutoEventWireup="true" CodeBehind ="UserRole.aspx.cs" Inherits="Web.ACM.UserRole" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <script src="../assets/js/JScript.js"></script>
    <style>
        table tr td {
            vertical-align: top !important;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            vertical-align: middle;
        }
        
/*--------------- tab control --------------*/

.ajax__tab_inner label {
    background-color: #18a689 !important;
    border: medium none;
    -webkit-border-top-left-radius: 10px;
    -webkit-border-top-right-radius: 10px;
    -moz-border-radius-topleft: 10px;
    -moz-border-radius-topright: 10px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    color: #616c76;
    cursor: pointer;
    font-size: 14px;
    font-weight: 400;
    margin-bottom: 10px;
    margin-right: 4px;
    padding: 7px 24px 8px;
    transition: border 0.25s linear 0s, color 0.25s linear 0s, background-color 0.25s linear 0s;
    vertical-align: middle;
    border: 1px solid #18a689;
    cursor: pointer;
}

    .ajax__tab_inner label a, label {
        cursor: pointer !important;
    }

.tab-button {
    background-color: #18a689;
    border: medium none;
    -webkit-border-top-left-radius: 10px;
    -webkit-border-top-right-radius: 10px;
    -moz-border-radius-topleft: 10px;
    -moz-border-radius-topright: 10px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    color: #616c76;
    cursor: pointer;
    font-size: 14px;
    font-weight: 400;
    margin-right: 4px;
    padding: 7px 24px 8px;
    transition: border 0.25s linear 0s, color 0.25s linear 0s, background-color 0.25s linear 0s;
    vertical-align: middle;
    border: 1px solid #18a689;
    cursor: pointer;
    margin-right: 0px !important;
    margin-left: 0px !important;
}

.ajax__tab_active .ajax__tab_inner label {
    background-color: #18a689 !important;
    border: medium none;
    border-radius: 0;
    color: #fff;
    cursor: pointer;
    font-size: 14px;
    font-weight: 400;
    margin-bottom: 10px;
    margin-right: 4px;
    padding: 7px 24px 8px;
    transition: border 0.25s linear 0s, color 0.25s linear 0s, background-color 0.25s linear 0s;
    vertical-align: middle;
    -webkit-border-top-left-radius: 10px;
    -webkit-border-top-right-radius: 10px;
    -moz-border-radius-topleft: 10px;
    -moz-border-radius-topright: 10px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    border: 1px solid #18a689;
    cursor: pointer;
}

.ajax__tab_hover .ajax__tab_inner label {
    background-color: #18a689 !important;
    border: medium none;
    border-radius: 0;
    color: #fff !important;
    cursor: pointer;
    font-size: 14px;
    font-weight: 400;
    margin-bottom: 10px;
    margin-right: 4px;
    padding: 7px 24px 8px;
    transition: border 0.25s linear 0s, color 0.25s linear 0s, background-color 0.25s linear 0s;
    vertical-align: middle;
    -webkit-border-top-left-radius: 10px;
    -webkit-border-top-right-radius: 10px;
    -moz-border-radius-topleft: 10px;
    -moz-border-radius-topright: 10px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    cursor: pointer;
    border: 1px solid #18a689;
}

.btn-spance {
    margin-right: 0px !important;
    margin-left: 0px !important;
}



        .ajax__tab_default .ajax__tab_outer {
            height: 33px !important;
            padding: 20px !important;
           
        }
        .Heading {
	background-color: #18a689;
	color: #fff;
	font-size: 1em;
	height: 30px;
	line-height: 30px;
	margin-bottom: 10px;
	padding-left: 8px;
	padding-right: 8px;
}
        table {
	border-collapse: collapse;
	border-spacing: 0;
	font-size: 12px !important;
}

    </style>
    <div class="page-content">
        <div class="row">
      
            <cc1:tabcontainer ID="TC_Roles" runat="server" ActiveTabIndex="0" CssClass="" >
                <cc1:TabPanel ID="TP_Roles" HeaderText="Search Users" runat="server" TabIndex="0">
                    <ContentTemplate>
                        <div class="panel">
                            <div class="panel-header bg-primary">
                                <h3><i class="fa fa-gear"></i>Search User</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label class="control-label">User Name</label>
                                        <asp:TextBox runat="server" ID="txtsRoleName" placeholder="e.g Admin" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label">Top</label>
                                        <asp:TextBox runat="server" ID="txtTop" placeholder="e.g 10" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-footer">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary pull-right" />
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="panel">
                            <div class="panel-header bg-primary">
                                <h3><i class="fa fa-gear"></i>Users</h3>
                            </div>
                            <div class="panel-content">
                                <asp:GridView ID="gvRole" runat="server" AutoGenerateColumns="false" EmptyDataText="No Data Found" OnRowCommand="gvRole_RowCommand"
                                    CssClass="table table-responsive table-bordered  table-striped">
                                    <Columns>
                                        <asp:TemplateField HeaderText="User Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="LtrlRole" runat="server" Text='<%#Eval("FIRST_NAME")%>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="First Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="Ltrl_desc" runat="server" Text='<%#Eval("FIRST_NAME1") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Login ID">
                                            <ItemTemplate>
                                                <asp:Literal ID="Ltrl_lOGIN" runat="server" Text='<%#Eval("LOGIN_ID") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       


                                        <asp:TemplateField HeaderText='Action'>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Lbtn_change" runat="server" CommandName='change' Text="Edit" CommandArgument='<%#Eval("USER_ID")%>' class="btn btn-sm yellow filter-submit margin-bottom"></asp:LinkButton>
                                                <asp:LinkButton ID="Lbtn_Disable" runat="server" CommandName='remove' Text="delete" CommandArgument='<%#Eval("USER_ID")%>' class="btn btn-sm red filter-cancel"></asp:LinkButton>
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText='Do You Want To Remove?' TargetControlID="Lbtn_Disable" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel HeaderText="Roles" ID="TP_RoleDetail" runat="server" TabIndex='1'>
                    <ContentTemplate>
                        <div class="panel">
                            <div class="panel-header bg-primary">
                                <h3><i class="fa fa-gear"></i>User</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:HiddenField ID="hidRoleID" runat="server" Value="0" />
                                        <label class="control-label">User Name</label>
                                        <asp:TextBox runat="server" ID="txtRoleName" placeholder="NAME e.g Admin" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="txtRoleName" InitialValue="-1" ErrorMessage="Required" ValidationGroup="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                              

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="control-label">Arabic Name</label>
                                        <asp:TextBox runat="server" ID="txtDescription" placeholder="Description" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary pull-right" Text="Save" ID="btnSave" OnClick="btnSave_Click" ValidationGroup="0" />
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="panel">
                            <div class="panel-header bg-primary">
                                <h3><i class="fa fa-gear"></i>Roles</h3>
                            </div>
                            <div class="panel-content">
                                <asp:DataList ID="ddlMenus" runat="server" RepeatColumns='1' OnItemDataBound="ddlMenus_ItemDataBound" CssClass="table table-responsive"
                                    RepeatDirection='Horizontal'>
                                    <ItemTemplate>
                                        <div class='Heading'>
                                            <asp:CheckBox ID="CB_SelectAll" runat='server' />
                                            <asp:Literal ID='LtrlDeptName' runat='server'></asp:Literal>
                                            <asp:HiddenField ID='HF_DeptID' runat='server' />
                                            <div style="float: right; visibility:hidden">
                                                <asp:Literal ID='Ltrl_All' runat='server' Text="Print"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                               <asp:Literal ID='Ltrl_View' runat='server' Text="View"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Literal ID='Ltrl_Add' runat='server' Text="Add"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                               <asp:Literal ID='Ltrl_Update' runat='server' Text="Update"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                               <asp:Literal ID='Ltrl_Delete' runat='server' Text="Delete"></asp:Literal>
                                            </div>
                                        </div>
                                        <div id='div_activities' runat='server'>
                                            <asp:Repeater ID='Rep_Activities' runat='server' OnItemDataBound='Rep_Activities_ItemDataBound'>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID='CB_Activity' runat='server' Text='<%#Eval("PageTitle")%>' CausesValidation='false'
                                                        AutoPostBack='false' class="rolez" />
                                                    <asp:HiddenField ID='HF_ActivityID' runat='server' Value='<%#Eval("NodeID")%>' />
                                                    &nbsp;
                                                <div id="Div_Operations" runat="server" style="float: right;">
                                                    <asp:HiddenField ID="hd_msg" runat="server" />
                                                    <asp:CheckBox ID='CB_ActivityPrint' runat='server' CausesValidation='false' Text="Print"  AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityView' runat='server' CausesValidation='false'  Text="View"  AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityAdd' runat='server' CausesValidation='false'   Text="Add"    AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityUpdate' runat='server' CausesValidation='false' Text="Update" AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityDelete' runat='server' CausesValidation='false' Text="Delete" AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </div>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <div class='Heading'>
                                            <asp:CheckBox ID="CB_SelectAll" runat='server' />
                                            <asp:Literal ID='LtrlDeptName' runat='server'></asp:Literal>
                                            <asp:HiddenField ID='HF_DeptID' runat='server' />
                                            <div style="float: right; visibility:hidden ">
                                                <asp:Literal ID='Ltrl_All' runat='server' Text="Print"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Literal ID='Ltrl_View' runat='server' Text="View"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Literal ID='Ltrl_Add' runat='server' Text="Add"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Literal ID='Ltrl_Update' runat='server' Text="Update"></asp:Literal>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Literal ID='Ltrl_Delete' runat='server' Text="Delete"></asp:Literal>
                                            </div>
                                        </div>
                                        <div id='div_activities' runat='server'>
                                            <asp:Repeater ID='Rep_Activities' runat='server' OnItemDataBound='Rep_Activities_ItemDataBound'>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID='CB_Activity' runat='server' Text='<%#Eval("PageTitle")%>' CausesValidation='false'
                                                        AutoPostBack='false' class="rolez" />
                                                    <asp:HiddenField ID='HF_ActivityID' runat='server' Value='<%#Eval("NodeID")%>' />
                                                    &nbsp;
                                                <div id="Div_Operations" runat="server" style="float: right;">
                                                    <asp:HiddenField ID="hd_msg" runat="server" />
                                                    <asp:CheckBox ID='CB_ActivityPrint' runat='server' CausesValidation='false' Text="Print" AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityView' runat='server' CausesValidation='false'  Text="View"   AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityAdd' runat='server' CausesValidation='false'   Text="Add"   AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityUpdate' runat='server' CausesValidation='false' Text="Update" AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID='CB_ActivityDelete' runat='server' CausesValidation='false' Text="Delete" AutoPostBack='false' />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </div>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </AlternatingItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:tabcontainer>

        </div>
    </div>


t>




t>





</asp:Content>

