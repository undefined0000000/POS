<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="TempUser.aspx.cs" Inherits="Web.ACM.TempUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <div id="b" runat="server" class="col-md-12">
            <div class="tabbable-custom tabbable-noborder">
                <div class="page-head">
                    <ol class="breadcrumb">
                        <li><a href="#"></a></li>
                        <li><a href="#">
                            <asp:Label ID="lblproductbyctegory" runat="server" Text="Temp User"></asp:Label></a></li>
                    </ol>

                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="form1" class="form-horizontal form-row-seperated">
                            <div class="portlet box yellow-crusta">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Temp User
                                    </div>
                                    <%--<div class="actions btn-set">
                                        <asp:LinkButton ID="lbApproveIss" class="btn blue" runat="server" OnClick="lbApproveIss_Click">Search</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" class="btn blue" runat="server" OnClick="LinkButton2_Click">Cancel</asp:LinkButton>
                                    </div>--%>
                                </div>
                                <div class="portlet-body form">
                                    <div class="form-horizontal">
                                        <div class="tabbable">
                                            <div class="tab-content no-space">
                                                <div class="tab-pane active" id="tab_general1">
                                                    <div class="form-body">

                                                        <div class="form-group" style="margin-right: 0px; margin-left: 0px;">
                                                            <div class="col-md-3">
                                                                <asp:Label runat="server" Style="color: #333333" ID="Label1" Text="Tenet ID"></asp:Label>
                                                                <asp:DropDownList ID="drpTenetID" runat="server" OnSelectedIndexChanged="drpTenetID_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium">
                                                                    <asp:ListItem Value="0"> 0 </asp:ListItem>
                                                                    <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                                    <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                                    <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                                    <asp:ListItem Value="360"> 360</asp:ListItem>
                                                                    <asp:ListItem Value="361"> 361</asp:ListItem>
                                                                    <asp:ListItem Value="362"> 362</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <asp:Label runat="server" Style="color: #333333" ID="Label2" Text="Location Name"></asp:Label>
                                                                <asp:DropDownList ID="drpLocationid" runat="server" OnSelectedIndexChanged="drpLocationid_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>

                                                            </div>
                                                            <div class="col-md-3">

                                                                <asp:Label runat="server" Style="color: #333333" ID="lblsignbyperson" Text="User Name"></asp:Label>

                                                                <asp:DropDownList ID="drpUserName" runat="server" OnSelectedIndexChanged="drpUserName_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-3 ">
                                                                <asp:Label runat="server" Style="color: #333333" ID="Label3" Text="Menu Name"></asp:Label>

                                                                <asp:DropDownList ID="drpMenuID" runat="server" OnSelectedIndexChanged="drpMenuID_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
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

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-horizontal form-row-seperated">
                                    <div class="portlet box blue-hoki">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Privilege Menu
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <a href="javascript:;" class="reload"></a>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                            <div class="actions btn-set">
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="padding-left: 25px;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>

                                                    <table class="table table-striped table-bordered table-hover" id="sample_1">
                                                        <thead class="repHeader">
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="lblSN" Style="color: #333333" runat="server" Text="#"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="lblGrCI" Style="color: #333333" runat="server" Text="Menu Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="lblGrCN" Style="color: #333333" runat="server" Text="Privilege Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="lblGrCD" Style="color: #333333" runat="server" Text="IS Visible"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="lblGrPC" Style="color: #333333" runat="server" Text="All Flag"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label10" Style="color: #333333" runat="server" Text="Edit"></asp:Label></th>
                                                                <%-- <th >
                                                                    <asp:Label ID="lblGrCT" Style="color: #333333" runat="server" Text="Brand"></asp:Label></th>
                                                                <th >
                                                                    <asp:Label ID="lblGrAC" Style="color: #333333" runat="server" Text="Select"></asp:Label></th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listprivilege123" runat="server" OnItemEditing="listprivilege123_ItemEditing" OnItemDataBound="listprivilege123_ItemDataBound" OnItemCanceling="listprivilege123_ItemCanceling" OnItemUpdating="listprivilege123_ItemUpdating" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                                                                <LayoutTemplate>

                                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                </LayoutTemplate>
                                                                <GroupTemplate>
                                                                    <tr>
                                                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                                                    </tr>
                                                                </GroupTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="gradeA">
                                                                        <td>
                                                                            <asp:Label ID="lblSRNO" Style="color: #333333" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblmuprodid" Style="color: #333333" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICN" Style="color: #333333" runat="server" Text='<%#getpriveleg(Convert .ToInt32 ( Eval("PRIVILEGE_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICD" Style="color: #333333" runat="server" Text='<%# Eval("IS_VISIBLE") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrIPC" Style="color: #333333" runat="server" Text='<%# Eval("ALL_FLAG") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Edit' CommandName="Edit" />
                                                                        </td>
                                                                        <%-- <td>
                                                                            <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("Brand")%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="btnselect" class="btn blue" CommandName="btnselect" CommandArgument='<%# Eval("MYPRODID")%>' runat="server">Seclect</asp:LinkButton>
                                                                        </td>--%>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <td>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label9" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drpprivilegeid" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>

                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>

                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Update' CommandName="Update" />
                                                                        <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle" Text='Cancel' CommandName="Cancel" />
                                                                    </td>
                                                                </EditItemTemplate>
                                                            </asp:ListView>

                                                        </tbody>
                                                    </table>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-horizontal form-row-seperated">
                                    <div class="portlet box purple">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Module Map
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <a href="javascript:;" class="reload"></a>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                            <div class="actions btn-set">
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="padding-left: 25px;">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <table class="table table-striped table-bordered table-hover" id="sample_3">
                                                        <thead class="repHeader">
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="Label4" Style="color: #333333" runat="server" Text="#"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label5" Style="color: #333333" runat="server" Text="Menu Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label6" Style="color: #333333" runat="server" Text="Module Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label7" Style="color: #333333" runat="server" Text="User Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label8" Style="color: #333333" runat="server" Text="All Flag"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label17" Style="color: #333333" runat="server" Text="Edit"></asp:Label></th>
                                                                <%-- <th >
                                                                    <asp:Label ID="Label9" Style="color: #333333" runat="server" Text="Brand"></asp:Label></th>
                                                                <th >
                                                                    <asp:Label ID="Label10" Style="color: #333333" runat="server" Text="Select"></asp:Label></th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listmodule123" runat="server" OnItemEditing="listmodule123_ItemEditing" OnItemDataBound="listmodule123_ItemDataBound" OnItemCanceling="listmodule123_ItemCanceling" OnItemUpdating="listmodule123_ItemUpdating" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnItemCommand ="listmodule123_ItemCommand">
                                                                <LayoutTemplate>

                                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                </LayoutTemplate>
                                                                <GroupTemplate>
                                                                    <tr>
                                                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                                                    </tr>
                                                                </GroupTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="gradeA">
                                                                        <td>
                                                                            <asp:Label ID="lblSRNO" Style="color: #333333" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblmuprodid" Style="color: #333333" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICN" Style="color: #333333" runat="server" Text='<%#getModulName(Convert .ToInt32 ( Eval("MODULE_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICD" Style="color: #333333" runat="server" Text='<%#getUserName(Convert .ToInt32 ( Eval("UserID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrIPC" Style="color: #333333" runat="server" Text='<%# Eval("ADD_FLAG") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Edit' CommandName="Edit" />
                                                                             <asp:Button ID="Button2" runat="server" class="btn green-haze btn-circle" Text='Delet' CommandName="delet" />
                                                                        </td>
                                                                        <%-- <td>
                                                                            <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("Brand")%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="btnselect" class="btn blue" CommandName="btnselect" CommandArgument='<%# Eval("MYPRODID")%>' runat="server">Seclect</asp:LinkButton>
                                                                        </td>--%>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <td>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label9" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drpmodul" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drpuser" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>

                                                                       <asp:Label ID="lblActviFlag" Style="color: #333333" runat="server" Text='<%# Eval("ADD_FLAG") %>'></asp:Label>
                                                                    </td>

                                                                    <td>
                                                                        <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Update' CommandArgument ='<%# Eval("MENU_ID") + "," + Eval("MODULE_ID")+","+ Eval("UserID") %>' CommandName="Update" />
                                                                        <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle" Text='Cancel' CommandName="Cancel" />
                                                                    </td>
                                                                </EditItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-horizontal form-row-seperated">
                                    <div class="portlet box green-meadow">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>User Role
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <a href="javascript:;" class="reload"></a>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                            <div class="actions btn-set">
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="padding-left: 25px;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>

                                                    <table class="table table-striped table-bordered table-hover" id="sample_6">
                                                        <thead class="repHeader">
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="Label11" Style="color: #333333" runat="server" Text="#"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label12" Style="color: #333333" runat="server" Text="Menu Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label13" Style="color: #333333" runat="server" Text="Role Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label14" Style="color: #333333" runat="server" Text=" User Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label15" Style="color: #333333" runat="server" Text="Active Date"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label16" Style="color: #333333" runat="server" Text="DisActive Date"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label24" Style="color: #333333" runat="server" Text="Edit/Delet"></asp:Label></th>
                                                                <%-- <th >
                                                                    <asp:Label ID="Label17" Style="color: #333333" runat="server" Text="Select"></asp:Label></th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listuserrolr123" runat="server" OnItemEditing="listuserrolr123_ItemEditing" OnItemDataBound="listuserrolr123_ItemDataBound" OnItemCanceling="listuserrolr123_ItemCanceling" OnItemUpdating="listuserrolr123_ItemUpdating" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">

                                                                <LayoutTemplate>

                                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                </LayoutTemplate>
                                                                <GroupTemplate>
                                                                    <tr>
                                                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                                                    </tr>
                                                                </GroupTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="gradeA">
                                                                        <td>
                                                                            <asp:Label ID="lblSRNO" Style="color: #333333" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblmuprodid" Style="color: #333333" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICN" Style="color: #333333" runat="server" Text='<%#getRolrName(Convert .ToInt32 ( Eval("ROLE_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICD" Style="color: #333333" runat="server" Text='<%#getUserName(Convert .ToInt32 ( Eval("USER_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrIPC" Style="color: #333333" runat="server" Text='<%# Eval("PRIVILAGEFOR") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("ACTIVE_TO_DT")%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Edit' CommandName="Edit" />
                                                                             <asp:Button ID="Button2" runat="server" class="btn green-haze btn-circle" Text='Delet' CommandName="delet" />
                                                                        </td>
                                                                        <%-- <td>
                                                                            <asp:LinkButton ID="btnselect" class="btn blue" CommandName="btnselect" CommandArgument='<%# Eval("MYPRODID")%>' runat="server">Seclect</asp:LinkButton>
                                                                        </td>--%>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <td>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label9" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drprole" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drpuser" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    <td>

                                                                       <asp:Label ID="lblGrIPC" Style="color: #333333" runat="server" Text='<%# Eval("PRIVILAGEFOR") %>'></asp:Label>
                                                                    </td>
                                                                    <td>

                                                                         <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("ACTIVE_TO_DT")%>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Update' CommandName="Update" />
                                                                        <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle" Text='Cancel' CommandName="Cancel" />
                                                                    </td>
                                                                </EditItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-horizontal form-row-seperated">
                                    <div class="portlet box red-sunglo">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>User Rights
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <a href="javascript:;" class="reload"></a>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                            <div class="actions btn-set">
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="padding-left: 25px;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>

                                                    <table class="table table-striped table-bordered table-hover" id="sample_2">
                                                        <thead class="repHeader">
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="Label18" Style="color: #333333" runat="server" Text="#"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label19" Style="color: #333333" runat="server" Text="Menu Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label20" Style="color: #333333" runat="server" Text="Privilege Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label21" Style="color: #333333" runat="server" Text="Add Flag"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label22" Style="color: #333333" runat="server" Text="Modify Flag"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label23" Style="color: #333333" runat="server" Text="All Flag"></asp:Label></th>
                                                               <th>
                                                                    <asp:Label ID="Label32" Style="color: #333333" runat="server" Text="Edit"></asp:Label></th>
                                                               
                                                                 <%-- <th >
                                                                    <asp:Label ID="Label24" Style="color: #333333" runat="server" Text="Select"></asp:Label></th>--%>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listuserrights123" runat="server" OnItemEditing="listuserrights123_ItemEditing" OnItemDataBound="listuserrights123_ItemDataBound" OnItemCanceling="listuserrights123_ItemCanceling" OnItemUpdating="listuserrights123_ItemUpdating"  GroupPlaceholderID="groupPlaceHolder4" ItemPlaceholderID="itemPlaceHolder4">

                                                                <LayoutTemplate>

                                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder4"></asp:PlaceHolder>

                                                                </LayoutTemplate>
                                                                <GroupTemplate>
                                                                    <tr>
                                                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder4"></asp:PlaceHolder>
                                                                    </tr>
                                                                </GroupTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="gradeA">
                                                                        <td>
                                                                            <asp:Label ID="lblSRNO" Style="color: #333333" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblmuprodid" Style="color: #333333" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICN" Style="color: #333333" runat="server" Text='<%#getpriveleg(Convert .ToInt32 (  Eval("PRIVILEGE_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICD" Style="color: #333333" runat="server" Text='<%# Eval("ADD_FLAG") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrIPC" Style="color: #333333" runat="server" Text='<%#getUserName(Convert .ToInt32 (  Eval("USER_ID"))) %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("ALL_FLAG")%>'></asp:Label>
                                                                        </td>
                                                                         <td>
                                                                            <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Edit' CommandName="Edit" />
                                                                              <asp:Button ID="Button3" runat="server" class="btn green-haze btn-circle" Text='Delet' CommandName="Delet" />
                                                                        </td>
                                                                        <%-- <td>
                                                                            <asp:LinkButton ID="btnselect" class="btn blue" CommandName="btnselect" CommandArgument='<%# Eval("MYPRODID")%>' runat="server">Seclect</asp:LinkButton>
                                                                        </td>--%>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                 <EditItemTemplate>
                                                                    <td>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label9" runat="server" Text='<%#getMenuName(Convert .ToInt32 ( Eval("MENU_ID"))) %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drppriveleg" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                     <td>

                                                                        <asp:Label ID="lblGrICD" Style="color: #333333" runat="server" Text='<%# Eval("ADD_FLAG") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="drpuser" CssClass="table-group-action-input form-control input-medium" runat="server">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' Visible="false"></asp:Label>--%>
                                                                    </td>
                                                                    
                                                                   <td>

                                                                        <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("ALL_FLAG")%>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnEdit" runat="server" class="btn green-haze btn-circle" Text='Update' CommandName="Update" />
                                                                        <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle" Text='Cancel' CommandName="Cancel" />
                                                                    </td>
                                                                </EditItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-horizontal form-row-seperated">
                                    <div class="portlet box green">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Am I Globle
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <a href="javascript:;" class="reload"></a>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                            <div class="actions btn-set">
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="padding-left: 25px;">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>

                                                    <table class="table table-striped table-bordered table-hover" id="sample_2">
                                                        <thead class="repHeader">
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="Label25" Style="color: #333333" runat="server" Text="#"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label26" Style="color: #333333" runat="server" Text="Menu Name"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label27" Style="color: #333333" runat="server" Text="BarCode"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label28" Style="color: #333333" runat="server" Text="ShortName"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label29" Style="color: #333333" runat="server" Text="ProdName"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label30" Style="color: #333333" runat="server" Text="Brand"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label31" Style="color: #333333" runat="server" Text="Select"></asp:Label></th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:Repeater ID="Repeater4" runat="server">
                                                                <ItemTemplate>
                                                                    <tr class="gradeA">
                                                                        <td>
                                                                            <asp:Label ID="lblSRNO" Style="color: #333333" runat="server" Text='<%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblmuprodid" Style="color: #333333" runat="server" Text='<%# Eval("MYPRODID") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICN" Style="color: #333333" runat="server" Text='<%# Eval("BarCode") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICD" Style="color: #333333" runat="server" Text='<%# Eval("ShortName") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrIPC" Style="color: #333333" runat="server" Text='<%# Eval("ProdName1") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrICT" Style="color: #333333" runat="server" Text='<%#  Eval("Brand")%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="btnselect" class="btn blue" CommandName="btnselect" CommandArgument='<%# Eval("MYPRODID")%>' runat="server">Seclect</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tbody>
                                                    </table>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
