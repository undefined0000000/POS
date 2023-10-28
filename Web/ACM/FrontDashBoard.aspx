<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="FrontDashBoard.aspx.cs" Inherits="Web.ACM.FrontDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/apps/css/todo-2.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="b" runat="server">
        <div class="col-md-12">
            <div class="tabbable-custom tabbable-noborder">
                <%-- <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <a href="index.aspx">CRM</a>
                        <i class="fa fa-circle"></i>
                    </li>
                    <li>
                        <a href="#">DashBoard</a>
                    </li>
                </ul>--%>
                <asp:Panel ID="pnlSuccessMsg" runat="server" Visible="false">
                    <div class="alert alert-success alert-dismissable">
                        <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </asp:Panel>

                <asp:UpdatePanel ID="updatedesk" runat="server">
                    <ContentTemplate>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-horizontal form-row-seperated">
                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>
                                                <asp:Label ID="Label20" runat="server" Text="Search CRM Activity"></asp:Label>
                                                <asp:TextBox Style="color: #333333" ID="txtHeader" runat="server" Visible="false"></asp:TextBox>
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <asp:LinkButton ID="btnPagereload" runat="server"><img src="/assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                            <div class="actions btn-set">
                                                <div id="navigation" runat="server" class="btn-group btn-group-circle btn-group-solid">
                                                    <asp:Button ID="btnFirst" class="btn red" runat="server" Text="First" />
                                                    <asp:Button ID="btnNext" class="btn green" runat="server" Text="Next" />
                                                    <asp:Button ID="btnPrev" class="btn purple" runat="server" Text="Prev" />
                                                    <asp:Button ID="btnLast" class="btn grey-cascade" runat="server" Text="Last" />

                                                </div>

                                                <asp:HiddenField ID="TabName" runat="server" />
                                                &nbsp;
                                        <asp:LinkButton ID="LanguageEnglish" Style="color: #fff; width: 60px; padding: 0px;" runat="server">E&nbsp;<img src="../assets/global/img/flags/us.png" /></asp:LinkButton>
                                                <asp:LinkButton ID="LanguageArabic" Style="color: #fff; width: 40px; padding: 0px;" runat="server">A&nbsp;<img src="../assets/global/img/flags/ae.png" /></asp:LinkButton>
                                                <asp:LinkButton ID="LanguageFrance" Style="color: #fff; width: 50px; padding: 0px;" runat="server">F&nbsp;<img src="../assets/global/img/flags/fr.png" /></asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="portlet-body form">

                                            <div class="form-wizard">
                                                <div class="tabbable">
                                                    <div class="tab-content no-space">
                                                        <div class="form-body">
                                                            <div class="form-group">
                                                                <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label30" runat="server" Text="Tenent ID"></asp:Label>
                                                                    <span class="required">* </span>
                                                                </label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="DrpTenent_ID" runat="server" class="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="DrpTenent_ID_SelectedIndexChanged">
                                                                    </asp:DropDownList>

                                                                    <%--  <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Tenent ID Is Required" ControlToValidate="DrpTenent_ID" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>--%>
                                                                </div>

                                                                <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label37" runat="server" Text="Location"></asp:Label>
                                                                    <span class="required">* </span>
                                                                </label>
                                                                <div class="col-md-4">

                                                                    <asp:DropDownList ID="Drp_Location" Enabled="false" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="Drp_Location_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Location Is Required" ControlToValidate="Drp_Location" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                </div>


                                                                <%-- <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label29" runat="server" Text="Module Name"></asp:Label>
                                                                    <span class="required">* </span>

                                                                </label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="DrpModuleName" runat="server" class="form-control select2" OnSelectedIndexChanged="DrpModuleName_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidatorCustomerName" runat="server" ErrorMessage="Module Name Is Required" ControlToValidate="DrpModuleName" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                                                </div>--%>
                                                            </div>
                                                            <div class="form-group">

                                                                <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label7" runat="server" Text="Activity Type"></asp:Label></label>
                                                                <div class="col-md-4">
                                                                    <%-- <asp:DropDownList ID="drpActivitytype" runat="server" CssClass="form-control select2"></asp:DropDownList>--%>
                                                                    <asp:DropDownList ID="drpReftype" Enabled="false" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="drpReftype_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>

                                                                <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label9" runat="server" Text="Ref Subtype"></asp:Label></label>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="drpRefsubtype" Enabled="false" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="drpRefsubtype_SelectedIndexChanged"></asp:DropDownList>

                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:Button ID="btnfind" class="btn green-haze btn-circle" runat="server" Text="Find" Enabled="false" ValidationGroup="Submit" OnClick="btnfind_Click" />
                                                                </div>
                                                                <%-- <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label38" runat="server" Text="CRM Main Activity" meta:resourcekey="Label38Resource1"></asp:Label>
                                                                    <span class="required">* </span>
                                                                </label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="DrpCRM_MainActivity" runat="server" class="form-control select2">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="CRM MainActivity Required" ControlToValidate="DrpCRM_MainActivity" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                </div>--%>
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
                                    <div class="portlet box yellow">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>
                                                <asp:Label ID="Label4" runat="server" Text="Search CRM Activity"></asp:Label>
                                                <asp:TextBox Style="color: #333333" ID="TextBox16" runat="server" Visible="false"></asp:TextBox>
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <asp:LinkButton ID="LinkButton12" runat="server"><img src="/assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                                <a href="javascript:;" class="remove"></a>
                                            </div>

                                            <div class="tools">


                                                <asp:Button ID="btnShowallActivity" class="btn green-haze btn-circle" runat="server" Text="Show All" ValidationGroup="Submit" OnClick="btnShowallActivity_Click" />

                                            </div>

                                        </div>

                                        <div class="portlet-body form">


                                            <div class="clearfix"></div>
                                            <h4 style="padding-left: 10px;">Main Activity List Of 
                                            <b>
                                                <asp:Label ID="Label3" runat="server"></asp:Label></b>
                                            </h4>
                                            <hr />
                                            <div class="tabbable" style="padding-left: 5px; padding-right: 5px;">
                                                <table class="table table-striped table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <%--<th>
                                                                <asp:Label ID="Label78" runat="server" Text="Activity Name"></asp:Label></th>--%>
                                                            <th>
                                                                <asp:Label ID="Label78" runat="server" Text="Company Name"></asp:Label></th>

                                                            <th>
                                                                <asp:Label ID="Label79" runat="server" Text="Description"></asp:Label></th>

                                                            <th>
                                                                <asp:Label ID="Label2" runat="server" Text="Last Update Date"></asp:Label></th>

                                                            <th style="width: 100px">
                                                                <asp:Label ID="Label1" runat="server" Text="Activity"></asp:Label></th>

                                                            <%--<th>
                                                                <asp:Label ID="Label81" runat="server" Text="Status"></asp:Label></th>--%>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:ListView ID="listserch" runat="server" OnItemCommand="listserch_ItemCommand1">
                                                            <LayoutTemplate>
                                                                <tr id="ItemPlaceholder" runat="server">
                                                                </tr>
                                                            </LayoutTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("DisplayFDName")%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblMOBPHONE" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                                                        <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("MyID")%>'></asp:Label>
                                                                        <asp:Label ID="lblCOMPID" runat="server" Visible="false" Text='<%# Eval("COMPID")%>'></asp:Label>


                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblEMAIL" runat="server" Text='<%# Convert.ToDateTime(Eval("UPDTTIME")).ToShortDateString()%>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:LinkButton ID="btnACTIVITYEdit" CommandName="btnEditACTIVITY" CommandArgument='<%# Eval("TenentID") + "," + Eval("MasterCODE")%>' runat="server" class="btn btn-sm yellow filter-submit margin-bottom">Activity</asp:LinkButton>
                                                                    </td>

                                                                </tr>

                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </tbody>
                                                </table>
                                            </div>
                                            <asp:Panel ID="Crmlist" runat="server" Visible="false">
                                                <div class="clearfix"></div>
                                                <h4 style="padding-left: 10px;">Activity List 
                                            <b>
                                                <asp:Label ID="lblactivityname" runat="server"></asp:Label></b>
                                                </h4>
                                                <hr />

                                                <div class="tabbable" style="padding-left: 5px; padding-right: 5px;">
                                                    <table class="table table-striped table-bordered table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="Label10" runat="server" Text="Activity"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label11" runat="server" Text="UP TTIME"></asp:Label></th>

                                                                <th>
                                                                    <asp:Label ID="Label12" runat="server" Text="GROUP CODE"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label13" runat="server" Text="Version"></asp:Label></th>


                                                                <th>
                                                                    <asp:Label ID="Label14" runat="server" Text="Activity Sequence"></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="Label15" runat="server" Text="Status"></asp:Label></th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" OnItemDataBound="ListView1_ItemDataBound">
                                                                <LayoutTemplate>
                                                                    <tr id="ItemPlaceholder" runat="server">
                                                                    </tr>
                                                                </LayoutTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("ACTIVITYTYPE")%>'></asp:Label></td>

                                                                        <td>
                                                                            <asp:Label ID="lblEMAIL" runat="server" Text='<%# Convert.ToDateTime(Eval("UPDTTIME")).ToShortDateString()%>'></asp:Label></td>


                                                                        <td>
                                                                            <asp:Label ID="lblMOBPHONE" runat="server" Text='<%# getgroupname(Convert.ToInt32(Eval("GROUPCODE")))%>'></asp:Label>
                                                                            <asp:Label ID="lblGroup" runat="server" Visible="false" Text='<%# Eval("GROUPCODE")%>'></asp:Label>
                                                                        </td>

                                                                        <td>
                                                                            <asp:Label ID="lblsquno" runat="server" Visible="false" Text='<%# Eval("ActivityID")%>'></asp:Label>
                                                                            <asp:Label ID="lblZIPCODE" runat="server" Text='<%# Eval("Version")%>'></asp:Label>
                                                                            <asp:Label ID="lblMylinenumber" runat="server" Visible="false" Text='<%# Eval("ActivityID")%>'></asp:Label>
                                                                            <asp:Label ID="lblMasterCODE" runat="server" Visible="false" Text='<%# Eval("MasterCODE") %>'></asp:Label>
                                                                            <asp:Label ID="lblType" runat="server" Visible="false" Text='<%# Eval("LinkMasterCODE") %>'></asp:Label>
                                                                            <asp:Label ID="lblusername" runat="server" Visible="false" Text='<%# Eval("USERNAME")%>'></asp:Label>
                                                                            <asp:Label ID="lblDocNO" runat="server" Visible="false" Text='<%# Eval("DocID")%>'></asp:Label>


                                                                        </td>
                                                                        <td style="padding-left: 60px;">
                                                                            <asp:LinkButton ID="btnACTIVITYEdit" runat="server" class="btn btn-sm yellow filter-submit margin-bottom"></asp:LinkButton>
                                                                        </td>
                                                                        <td style="width: 200px;">
                                                                            <asp:DropDownList ID="drpActivityStatus" runat="server" Style="width: 200px" CssClass="form-control select2">
                                                                            </asp:DropDownList>

                                                                            <asp:LinkButton ID="btnstaer" CommandName="BtnSatrt" Style="margin-left: 216px; margin-top: -55px;" runat="server" class="btn btn-sm yellow filter-submit margin-bottom">Start</asp:LinkButton>
                                                                            <asp:HiddenField ID="hiddenConfirm" runat="server" />
                                                                            <panel id="pnlresponsive" runat="server" cssclass="modalPopup" style="display: none; height: auto;">
                                                                           <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box yellow-crusta">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> Open Activity
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="portlet-body"> 
                                                                                        <div class="form-group">
                                                                                              <div class="col-md-12">
                                                                                                   <div class="col-md-2">
                                                                                              <asp:Label ID="Label16" runat="server" Text="Subject:" ></asp:Label></div> 
                                                                                              <div class="col-md-10">
                                                                                                   <asp:TextBox  ID="TextBox2" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                                                                                              </div>
                                                                                                   </div>   
                                                                                        </div>   
                                                                                     <div class="form-group">
                                                                                          <div class="col-md-12">
                                                                                              <div class="col-md-2">
                                                                                                    <asp:Label ID="Label18" runat="server" Text="Start Date:" ></asp:Label>
                                                                                              </div>  
                                                                                              <div class="col-md-2">
                                                                                                    <asp:TextBox  ID="TextBox3" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                                                                                              </div>
                                                                                              <div class="col-md-2">
                                                                                                    <asp:Label ID="Label19" runat="server" Text="Status:" ></asp:Label> 
                                                                                              </div> 
                                                                                              <div class="col-md-6">
                                                                                                    <asp:DropDownList ID="DropDownList1"  runat="server" CssClass="form-control"></asp:DropDownList>
                                                                                              </div>
                                                                                          </div>
                                                                                    </div>
                                                                                    <div class="form-group">
                                                                                            <div class="col-md-12">
                                                                                              <div class="col-md-2">
                                                                                                <asp:Label ID="Label21"   runat="server" Text="Due Date:" ></asp:Label>
                                                                                                   </div>   
                                                                                              <div class="col-md-2">
                                                                                                       <asp:TextBox  ID="TextBox4" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                                                                                                  </div>
                                                                                              <div class="col-md-2">
                                                                                                <asp:Label ID="Label22" runat="server" Text="Prority:" ></asp:Label>
                                                                                                                                                                            </div>   
                                                                                              <div class="col-md-2">
                                                                                                       <asp:DropDownList ID="DropDownList2"  runat="server" CssClass="form-control"></asp:DropDownList>
                                                                                                  </div>
                                                                                              <div class="col-md-2">
                                                                                                <asp:Label ID="Label23" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                                                                                            </div>
                                                                                              <div class="col-md-2">
                                                                                                       <asp:TextBox  ID="TextBox5" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                                                                                                       </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                                                                                              <div class="col-md-2">
                                                                                                      <asp:CheckBox ID="cbkremender" runat="server" />
                                                                                                <asp:Label ID="Label24"  runat="server" Text="Reminder:" ></asp:Label>

                                                                                              </div>
                                                                                           <div class="col-md-2">
                                                                                                       <asp:TextBox  ID="TextBox6" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                                                                                                  </div>
                                                                                          <div class="col-md-1">
                                                                                                <asp:Label ID="Label25" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                                                                                            </div>   
                                                                                                  <div class="col-md-3">
                                                                                                       <asp:TextBox  ID="TextBox7" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                                                                                                  </div>
                                                                                           <div class="col-md-1">
                                                                                                <asp:Label ID="Label26" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                                                                                            </div>
                                                                                                  <div class="col-md-3">
                                                                                                       <asp:TextBox  ID="TextBox8" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                                                                                                       </div>   
                                                                                        </div>

                                                                                        </div> 
                                                                                     </div>
                                                                                    
                                                                                     <div class="modal-footer">
                                                                                        <asp:LinkButton ID="btnaddrefresh" class="btn green-haze modalBackgroundbtn-circle" ValidationGroup="S" runat="server"> Save</asp:LinkButton>
                                                                                        <asp:Button ID="Button6" runat="server" class="btn green-haze btn-circle" Text="Cancel" />
                                                                                      </div>
                                                                                    </div> 
                                                                                </div>
                                                                            </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender7" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button6" Enabled="True" PopupControlID="pnlresponsive" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                            <panel id="Panel3" runat="server" cssclass="modalPopup" style="display: none; height: auto; overflow: auto">
       <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box blue-hoki">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> In Progress
                                                                                        </div>
                                                                                    </div>
         <div class="portlet-body"> 
                                                                                         <div class="form-group">
                  <div class="col-md-12">
                       <div class="col-md-2">
                    <asp:Label ID="Label27" runat="server" Text="Subject:" ></asp:Label></div> 
                      <div class="col-md-10">
                           <asp:TextBox  ID="TextBox9" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                           </div>   
            </div>   
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label28" runat="server" Text="Start Date:" ></asp:Label>
                       </div>  
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox10" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label29" runat="server" Text="Status:" ></asp:Label> 

                                                                                            </div> 
                  <div class="col-md-6">
                           <asp:DropDownList ID="DropDownList3"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                            </div>
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label32"   runat="server" Text="Due Date:" ></asp:Label>
                       </div>   
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox11" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label33" runat="server" Text="Prority:" ></asp:Label>
                                                                                                </div>   
                  <div class="col-md-2">
                           <asp:DropDownList ID="DropDownList4"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label34" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                </div>
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox12" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                          <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label35"  runat="server" Text="Reminder:" ></asp:Label>

                  </div>
               <div class="col-md-2">
                           <asp:TextBox  ID="TextBox13" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
              <div class="col-md-1">
                    <asp:Label ID="Label36" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                </div>   
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox14" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
               <div class="col-md-1">
                    <asp:Label ID="Label38" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                </div>
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox15" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div>   
            </div></div> 
                                                                                     </div>
        <div class="modal-footer">
           <asp:LinkButton ID="LinkButton6" class="btn green-haze modalBackgroundbtn-circle" ValidationGroup="S" runat="server"> Save</asp:LinkButton>
 <asp:Button ID="Button7" runat="server" class="btn green-haze btn-circle" Text="Cancel" />
        </div></div></div> 

       </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button7" Enabled="True" PopupControlID="Panel3" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                            <panel id="Panel4" runat="server" cssclass="modalPopup" style="display: none; height: auto; overflow: auto">
       <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box purple">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> Forward Activity
                                                                                        </div>
                                                                                        <div class="actions btn-set">
                                                                                           
                                                                                             <asp:DropDownList ID="drpuserlist"  runat="server" CssClass="form-control"></asp:DropDownList>
                                                                                            </div> 
                                                                                    </div>
                                                                                    <div class="portlet-body"> 
        <div class="form-group">
                  <div class="col-md-12">
                       <div class="col-md-2">
                    <asp:Label ID="Label39" runat="server" Text="Subject:" ></asp:Label></div> 
                      <div class="col-md-10">
                           <asp:TextBox  ID="txtsubject" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                           </div>   
            </div>   
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label40" runat="server" Text="Start Date:" ></asp:Label>
                       </div>  
                  <div class="col-md-2">
                           <asp:TextBox  ID="txtstartdate" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                       <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartdate" Format="MM-dd-yyyy" Enabled="True">
                                                                    </cc1:CalendarExtender>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label41" runat="server" Text="Status:" ></asp:Label> 

                                                                                            </div> 
                  <div class="col-md-6">
                           <asp:DropDownList ID="drpstatus"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                            </div>
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label42"   runat="server" Text="Due Date:" ></asp:Label>
                       </div>   
                  <div class="col-md-2">
                           <asp:TextBox  ID="txtduedate" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                       <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtduedate" Format="MM-dd-yyyy" Enabled="True">
                                                                    </cc1:CalendarExtender>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label43" runat="server" Text="Prority:" ></asp:Label>
                                                                                                </div>   
                  <div class="col-md-2">
                           <asp:DropDownList ID="drpprority"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label44" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                </div>
                  <div class="col-md-2">
                           <asp:TextBox  ID="txtcomplete" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                          <asp:CheckBox ID="cbreminder" runat="server" />
                    <asp:Label ID="Label45"  runat="server" Text="Reminder:" ></asp:Label>

                  </div>
               <div class="col-md-2">
                           <asp:TextBox  ID="txtnote" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
              <div class="col-md-1">
                    <asp:Label ID="Label46" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                </div>   
                      <div class="col-md-3">
                           <asp:TextBox  ID="txttime" runat="server"  Enabled="false" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
               <div class="col-md-1">
                    <asp:Label ID="Label47" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                </div>
                      <div class="col-md-3">
                           <asp:TextBox  ID="txtowner" runat="server" Enabled="false" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div>   
            </div></div> </div>
        <div class="modal-footer">
           <asp:LinkButton ID="LinkButton7" class="btn green-haze modalBackgroundbtn-circle" CommandName="btnforwordactivity"  CommandArgument='<%# Eval("TenentID")+"-"+ Eval("MasterCODE") +"-"+ Eval("ActivityID")+"-"+ Eval("LinkMasterCODE") %>' runat="server"> Save</asp:LinkButton>
 <asp:Button ID="Button8" runat="server" class="btn green-haze btn-circle" Text="Cancel" />

        </div>
                                                                                    </div></div> </div> </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button8" Enabled="True" PopupControlID="Panel4" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                            <panel id="Panel5" runat="server" cssclass="modalPopup" style="display: none; height: auto; overflow: auto">
       <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box purple">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> Reschedule Activity
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="portlet-body"> 
          <div class="form-group">
                  <div class="col-md-12">
                       <div class="col-md-2">
                    <asp:Label ID="Label48" runat="server" Text="Subject:" ></asp:Label></div> 
                      <div class="col-md-10">
                           <asp:TextBox  ID="TextBox23" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                           </div>   
            </div>   
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label49" runat="server" Text="Start Date:" ></asp:Label>
                       </div>  
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox24" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label50" runat="server" Text="Status:" ></asp:Label> 

                                                                                            </div> 
                  <div class="col-md-6">
                           <asp:DropDownList ID="DropDownList7"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                            </div>
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label51"   runat="server" Text="Due Date:" ></asp:Label>
                       </div>   
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox25" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label52" runat="server" Text="Prority:" ></asp:Label>
                                                                                                </div>   
                  <div class="col-md-2">
                           <asp:DropDownList ID="DropDownList8"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label53" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                </div>
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox26" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                          <asp:CheckBox ID="CheckBox3" runat="server" />
                    <asp:Label ID="Label54"  runat="server" Text="Reminder:" ></asp:Label>

                  </div>
               <div class="col-md-2">
                           <asp:TextBox  ID="TextBox27" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
              <div class="col-md-1">
                    <asp:Label ID="Label55" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                </div>   
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox28" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
               <div class="col-md-1">
                    <asp:Label ID="Label56" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                </div>
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox29" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div>   
            </div></div> 
                                                                                        </div>
        <div class="modal-footer">
           <asp:LinkButton ID="LinkButton8" class="btn green-haze modalBackgroundbtn-circle" ValidationGroup="S" runat="server"> Save</asp:LinkButton>
 <asp:Button ID="Button9" runat="server" class="btn green-haze btn-circle" Text="Cancel" />

        </div>
                                                                                    </div></div> </div> </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button8" Enabled="True" PopupControlID="Panel5" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                            <panel id="Panel6" runat="server" cssclass="modalPopup" style="display: none; height: auto; overflow: auto">
       <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box green-meadow">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> Close Activity
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="portlet-body"> 
         <div class="form-group">
                  <div class="col-md-12">
                       <div class="col-md-2">
                    <asp:Label ID="Label57" runat="server" Text="Subject:" ></asp:Label></div> 
                      <div class="col-md-10">
                           <asp:TextBox  ID="TextBox30" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                           </div>   
            </div>   
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label58" runat="server" Text="Start Date:" ></asp:Label>
                       </div>  
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox31" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label59" runat="server" Text="Status:" ></asp:Label> 

                                                                                            </div> 
                  <div class="col-md-6">
                           <asp:DropDownList ID="DropDownList9"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                            </div>
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label60"   runat="server" Text="Due Date:" ></asp:Label>
                       </div>   
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox32" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label61" runat="server" Text="Prority:" ></asp:Label>
                                                                                                </div>   
                  <div class="col-md-2">
                           <asp:DropDownList ID="DropDownList10"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label62" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                </div>
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox33" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                          <asp:CheckBox ID="CheckBox4" runat="server" />
                    <asp:Label ID="Label63"  runat="server" Text="Reminder:" ></asp:Label>

                  </div>
               <div class="col-md-2">
                           <asp:TextBox  ID="TextBox34" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
              <div class="col-md-1">
                    <asp:Label ID="Label64" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                </div>   
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox35" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
               <div class="col-md-1">
                    <asp:Label ID="Label65" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                </div>
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox36" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div>   
            </div></div> </div>
        <div class="modal-footer">
           <asp:LinkButton ID="LinkButton9" class="btn green-haze modalBackgroundbtn-circle" ValidationGroup="S" runat="server"> Save</asp:LinkButton>
 <asp:Button ID="Button10" runat="server" class="btn green-haze btn-circle" Text="Cancel" />

        </div>
                                                                                    </div></div> </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button8" Enabled="True" PopupControlID="Panel6" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                            <panel id="Panel7" runat="server" cssclass="modalPopup" style="display: none; height: auto; overflow: auto">
       <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box blue">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> Indefinite
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="portlet-body"> 
         <div class="form-group">
                  <div class="col-md-12">
                       <div class="col-md-2">
                    <asp:Label ID="Label66" runat="server" Text="Subject:" ></asp:Label></div> 
                      <div class="col-md-10">
                           <asp:TextBox  ID="TextBox37" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                           </div>   
            </div>   
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label67" runat="server" Text="Start Date:" ></asp:Label>
                       </div>  
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox38" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label68" runat="server" Text="Status:" ></asp:Label> 

                                                                                            </div> 
                  <div class="col-md-6">
                           <asp:DropDownList ID="DropDownList11"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                            </div>
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label69"   runat="server" Text="Due Date:" ></asp:Label>
                       </div>   
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox39" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label70" runat="server" Text="Prority:" ></asp:Label>
                                                                                                </div>   
                  <div class="col-md-2">
                           <asp:DropDownList ID="DropDownList12"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label71" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                </div>
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox40" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                          <asp:CheckBox ID="CheckBox5" runat="server" />
                    <asp:Label ID="Label72"  runat="server" Text="Reminder:" ></asp:Label>

                  </div>
               <div class="col-md-2">
                           <asp:TextBox  ID="TextBox41" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
              <div class="col-md-1">
                    <asp:Label ID="Label73" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                </div>   
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox42" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
               <div class="col-md-1">
                    <asp:Label ID="Label74" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                </div>
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox43" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div>   
            </div></div> </div>
        <div class="modal-footer">
           <asp:LinkButton ID="LinkButton10" class="btn green-haze modalBackgroundbtn-circle" ValidationGroup="S" runat="server"> Save</asp:LinkButton>
 <asp:Button ID="Button11" runat="server" class="btn green-haze btn-circle" Text="Cancel" />

        </div>
                                                                                    </div></div> </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender6" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button8" Enabled="True" PopupControlID="Panel7" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                            <panel id="Panel8" runat="server" cssclass="modalPopup" style="display: none; height: auto; overflow: auto">
       <div class="row">
                                                                            <div class="col-md-12"> 
                                                                                <div class="portlet box red-sunglo">
                                                                                    <div class="portlet-title">
                                                                                        <div class="caption">
                                                                                            <i class="fa fa-globe"></i> Unknown
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="portlet-body"> 
         <div class="form-group">
                  <div class="col-md-12">
                       <div class="col-md-2">
                    <asp:Label ID="Label75" runat="server" Text="Subject:" ></asp:Label></div> 
                      <div class="col-md-10">
                           <asp:TextBox  ID="TextBox44" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                           </div>   
            </div>   
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label76" runat="server" Text="Start Date:" ></asp:Label>
                       </div>  
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox45" runat="server"  class="form-control" maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label77" runat="server" Text="Status:" ></asp:Label> 

                                                                                            </div> 
                  <div class="col-md-6">
                           <asp:DropDownList ID="DropDownList13"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                            </div>
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                    <asp:Label ID="Label80"   runat="server" Text="Due Date:" ></asp:Label>
                       </div>   
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox46" runat="server" class="form-control"  maxlength="50"></asp:TextBox>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label81" runat="server" Text="Prority:" ></asp:Label>
                                                                                                </div>   
                  <div class="col-md-2">
                           <asp:DropDownList ID="DropDownList14"  runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                  <div class="col-md-2">
                    <asp:Label ID="Label82" class="col-md-1 control-label" style="width: 110px;"  runat="server" Text="% Complete:" ></asp:Label>
                                                                                                </div>
                  <div class="col-md-2">
                           <asp:TextBox  ID="TextBox47" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div> 

                                                                                            </div> 
            </div>
                                                                                        <div class="form-group">
                                                                                            <div class="col-md-12">
                  <div class="col-md-2">
                          <asp:CheckBox ID="CheckBox6" runat="server" />
                    <asp:Label ID="Label83"  runat="server" Text="Reminder:" ></asp:Label>

                  </div>
               <div class="col-md-2">
                           <asp:TextBox  ID="TextBox48" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
              <div class="col-md-1">
                    <asp:Label ID="Label84" class="col-md-1 control-label" runat="server" Text="Time:" ></asp:Label>
                                                                                                </div>   
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox49" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      </div>
               <div class="col-md-1">
                    <asp:Label ID="Label85" class="col-md-1 control-label" runat="server" Text="Owner:" ></asp:Label>
                                                                                                </div>
                      <div class="col-md-3">
                           <asp:TextBox  ID="TextBox50" runat="server" class="form-control" maxlength="50"></asp:TextBox>
                      
                           </div>   
            </div></div> </div>
        <div class="modal-footer">
           <asp:LinkButton ID="LinkButton11" class="btn green-haze modalBackgroundbtn-circle" ValidationGroup="S" runat="server"> Save</asp:LinkButton>
 <asp:Button ID="Button12" runat="server" class="btn green-haze btn-circle" Text="Cancel" />

        </div>
                                                                                    </div></div> </div> </div> 
                                                                                    </panel>
                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender8" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button8" Enabled="True" PopupControlID="Panel8" TargetControlID="hiddenConfirm">
                                                                            </cc1:ModalPopupExtender>
                                                                        </td>
                                                                    </tr>

                                                                </ItemTemplate>
                                                            </asp:ListView>

                                                        </tbody>
                                                    </table>

                                                </div>
                                            </asp:Panel>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>






                        <asp:Panel ID="PnlTimeSetp" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-horizontal form-row-seperated">
                                        <div class="portlet box blue">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-gift"></i>
                                                    <asp:Label ID="Label31" runat="server" Text="CRM Activity"></asp:Label>
                                                    <asp:TextBox Style="color: #333333" ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                                </div>
                                                <div class="tools">
                                                    <a href="javascript:;" class="collapse"></a>
                                                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                    <asp:LinkButton ID="LinkButton1" runat="server"><img src="/assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                                    <a href="javascript:;" class="remove"></a>
                                                </div>
                                                <div class="actions btn-set">
                                                    <div id="Div1" runat="server" class="btn-group btn-group-circle btn-group-solid">
                                                        <asp:Button ID="Button1" class="btn red" runat="server" Text="First" />
                                                        <asp:Button ID="Button2" class="btn green" runat="server" Text="Next" />
                                                        <asp:Button ID="Button3" class="btn purple" runat="server" Text="Prev" />
                                                        <asp:Button ID="Button4" class="btn grey-cascade" runat="server" Text="Last" />

                                                    </div>
                                                    <asp:Button ID="Button5" class="btn green-haze btn-circle" runat="server" Text="Find" ValidationGroup="Submit" OnClick="btnfind_Click" />
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                    &nbsp;
                                        <asp:LinkButton ID="LinkButton3" Style="color: #fff; width: 60px; padding: 0px;" runat="server">E&nbsp;<img src="/assets/global/img/flags/us.png" /></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton4" Style="color: #fff; width: 40px; padding: 0px;" runat="server">A&nbsp;<img src="/assets/global/img/flags/ae.png" /></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton5" Style="color: #fff; width: 50px; padding: 0px;" runat="server">F&nbsp;<img src="/assets/global/img/flags/fr.png" /></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="portlet-body form">

                                                <div class="form-wizard">
                                                    <div class="tabbable">
                                                        <div class="tab-content no-space">

                                                            <div class="form-body">
                                                                <div class="form-group">
                                                                    <label class="col-md-2 control-label">
                                                                        <asp:Label ID="Label5" runat="server" Text="Company"></asp:Label></label><div class="col-md-4">
                                                                            <asp:DropDownList ID="drpComid" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                                                        </div>

                                                                    <label class="col-md-2 control-label">
                                                                        <asp:Label ID="Label6" runat="server" Text="Activity Perform By"></asp:Label></label><div class="col-md-4">
                                                                            <asp:DropDownList ID="drpActivitycode" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                                                        </div>
                                                                </div>
                                                                <%--    <div class="form-group">


                                                                <label class="col-md-2 control-label">
                                                                    <asp:Label ID="Label8" runat="server" Text="Ref Type"></asp:Label></label>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="drpReftype" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="drpReftype_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>--%>
                                                                <%-- <div class="form-group">
                                                               
                                                            </div>--%>
                                                                <asp:Panel ID="ticketpanel" runat="server">
                                                                </asp:Panel>
                                                                <div class="form-group">
                                                                    <asp:Panel ID="panellineno" runat="server">
                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblmylineno" runat="server" Text="MyLineNo"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <div id="spinner1">
                                                                                <div class="input-group input-large">
                                                                                    <asp:TextBox ID="txtMylineno" runat="server" class="spinner-input form-control" MaxLength="3"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mylineno Required" ControlToValidate="txtMylineno" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                                    <div class="spinner-buttons input-group-btn btn-group-vertical">
                                                                                        <button class="btn spinner-up btn-xs blue" type="button">
                                                                                            <i class="fa fa-angle-up"></i>
                                                                                        </button>
                                                                                        <button class="btn spinner-down btn-xs blue" type="button">
                                                                                            <i class="fa fa-angle-down"></i>
                                                                                        </button>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:Panel ID="pnlUserCode" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblusercode" runat="server" Text="User Code"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtUSERCODE" runat="server" class="form-control" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorUSERCODE" runat="server" ErrorMessage="USERCODE Required" ControlToValidate="txtUSERCODE" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlReferenceNo" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblrefno" runat="server" Text="Reference No"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtReferenceNo" runat="server" class="form-control" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorReferenceNo" runat="server" ErrorMessage="ReferenceNo Required" ControlToValidate="txtReferenceNo" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">

                                                                    <asp:Panel ID="pnlEarlierRefNo" runat="server">
                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblearlierrefno" runat="server" Text="Earlier RefNo"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtEarlierRefNo" runat="server" class="form-control" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorEarlierRefNo" runat="server" ErrorMessage="EarlierRefNo Required" ControlToValidate="txtEarlierRefNo" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>


                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlNextUser" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblnesxtuser" runat="server" Text="NextUser"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtNextUser" runat="server" class="form-control" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorNextUser" runat="server" ErrorMessage="NextUser Required" ControlToValidate="txtNextUser" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">

                                                                    <asp:Panel ID="pnlDocumnetName" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lbldocname" runat="server" Text="Documnet Name"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtNextRefNo" runat="server" class="form-control" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorNextRefNo" runat="server" ErrorMessage="NextRefNo Required" ControlToValidate="txtNextRefNo" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlActivityPerform" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblActivityPerform" runat="server" Text="Activity Perform"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtActivityPerform" runat="server" class="form-control" MaxLength="1000"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorActivityPerform" runat="server" ErrorMessage="ActivityPerform Required" ControlToValidate="txtActivityPerform" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">




                                                                    <asp:Panel ID="pnlReminderNote" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblReminderNote" runat="server" Text="ReminderNote"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox ID="txtREMINDERNOTE" runat="server" class="form-control" MaxLength="1000"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorREMINDERNOTE" runat="server" ErrorMessage="REMINDERNOTE Required" ControlToValidate="txtREMINDERNOTE" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlEstCost" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblEstCost" runat="server" Text="EstCost"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtESTCOST" runat="server" class="form-control" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorESTCOST" runat="server" ErrorMessage="ESTCOST Required" ControlToValidate="txtESTCOST" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        </div>


                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">

                                                                    <asp:Panel ID="pnlGroupCode" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblGroupCode" runat="server" Text="GroupCode"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox ID="txtGROUPCODE" runat="server" class="form-control" MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorGROUPCODE" runat="server" ErrorMessage="GROUPCODE Required" ControlToValidate="txtGROUPCODE" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlUserCodeEntered" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblUserCodeEntered" runat="server" Text="UserCodeEntered"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox ID="txtUSERCODEENTERED" runat="server" class="form-control" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorUSERCODEENTERED" runat="server" ErrorMessage="USERCODEENTERED Required" ControlToValidate="txtUSERCODEENTERED" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">

                                                                    <asp:Panel ID="pnlUpDtTime" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblUpDtTime" runat="server" Text="Up Dt Time"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox Placeholder="MM/DD/YYYY" ID="txtUPDTTIME" runat="server" class="form-control" MaxLength="10"></asp:TextBox><cc1:CalendarExtender ID="TextBoxUPDTTIME_CalendarExtender" runat="server" Enabled="True" PopupButtonID="calender" TargetControlID="txtUPDTTIME"></cc1:CalendarExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUPDTTIME" runat="server" ControlToValidate="txtUPDTTIME" ErrorMessage="UPDTTIME Required." CssClass="Validation" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlUserName" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox ID="txtUSERNAME" runat="server" class="form-control" MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorUSERNAME" runat="server" ErrorMessage="USERNAME Required" ControlToValidate="txtUSERNAME" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">

                                                                    <asp:Panel ID="pnlInitialDate" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblInitialDate" runat="server" Text="Initial Date"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox Placeholder="MM/DD/YYYY" ID="txtInitialDate" runat="server" class="form-control" MaxLength="10"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="calender" TargetControlID="txtInitialDate"></cc1:CalendarExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorInitialDate" runat="server" ControlToValidate="txtInitialDate" ErrorMessage="UPDTTIME Required." CssClass="Validation" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlDeadLineDate" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblDeadLineDate" runat="server" Text="DeadLine Date"></asp:Label></label><div class="col-md-4">
                                                                                <asp:TextBox Placeholder="MM/DD/YYYY" ID="txtDeadLineDate" runat="server" class="form-control" MaxLength="10"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" PopupButtonID="calender" TargetControlID="txtDeadLineDate"></cc1:CalendarExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDeadLineDate" runat="server" ControlToValidate="txtDeadLineDate" ErrorMessage="UPDTTIME Required." CssClass="Validation" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">

                                                                    <asp:Panel ID="pnlAmiGlobal" runat="server">

                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblamiglobal" runat="server" Text="AmiGlobal"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:CheckBox ID="ckbAmiglobal" runat="server" />
                                                                        </div>


                                                                    </asp:Panel>
                                                                    <asp:Panel ID="pnlMyPersonnel" runat="server">
                                                                        <label class="col-md-2 control-label">
                                                                            <asp:Label ID="lblmypersonnel" runat="server" Text="MyPersonnel"></asp:Label></label>
                                                                        <div class="col-md-4">
                                                                            <asp:CheckBox ID="ckbMypersonnel" runat="server" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                            <div class="form-actions">
                                                                <asp:Button ID="btnSaveACTIVITY" runat="server" class="btn blue" OnClick="btnSaveACTIVITY_Click1" Text="Save" />
                                                                <asp:Button ID="btnCancelACTIVITY" runat="server" class="btn blue" OnClick="btnCancelACTIVITY_Click" Text="Cancel" />

                                                            </div>

                                                            <asp:Panel ID="ShowTicket" runat="server" Visible="false">
                                                                <div class="col-md-5 col-sm-4">
                                                                    <div class="todo-tasklist">
                                                                        <asp:UpdatePanel runat="server" ID="upnl" class="item">
                                                                            <ContentTemplate>
                                                                                <asp:ListView ID="ltsRemainderNotes" runat="server" OnItemCommand="ltsRemainderNotes_ItemCommand">

                                                                                    <ItemTemplate>
                                                                                        <div class="todo-tasklist-item todo-tasklist-item-border-green">

                                                                                            <div class="todo-tasklist-item-title">
                                                                                                </span><%#Eval("USERCODE")%>
                                                                                                <asp:LinkButton ID="btnclick123" class="btn blue" Style="margin-left: 50px;" CommandArgument="btnclick123" CommandName="btnclick123" runat="server"> &nbsp; Reply &nbsp; </asp:LinkButton>
                                                                                                <span class="todo-tasklist-badge badge badge-roundless"># <%#Eval("ACTIVITYCODE")%> </span>
                                                                                            </div>
                                                                                            <div class="todo-tasklist-item-text"><%#Eval("Remarks")%> </div>
                                                                                            <asp:Label ID="tikitID" Visible="false" runat="server" Text='<%#Eval("ESTCOST")%>'></asp:Label>
                                                                                            <div class="todo-tasklist-controls pull-left">

                                                                                                <span class="todo-tasklist-date">
                                                                                                    <i class="fa fa-calendar"></i><%# DateTime.Parse(Eval("UPDTTIME").ToString())%></span>
                                                                                                <span class="todo-tasklist-badge badge badge-roundless"><%#Eval("MyStatus")%> </span>
                                                                                                <span class="todo-tasklist-badge badge badge-roundless"><%#Eval("REFTYPE")%></span>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                </asp:ListView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>

                                                                    </div>
                                                                </div>
                                                                <div class="todo-tasklist-devider"></div>
                                                            </asp:Panel>
                                                            <asp:Panel ID="panChat" runat="server" Visible="false">
                                                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" class="item">
                                                                    <ContentTemplate>

                                                                        <div class="col-md-7 col-sm-8">
                                                                            <div class="tabbable-line">
                                                                                <ul class="nav nav-tabs ">
                                                                                    <li class="active">
                                                                                        <a href="#tab_1" data-toggle="tab">Comments </a>
                                                                                    </li>
                                                                                    <li>
                                                                                        <a href="#tab_2" data-toggle="tab">History </a>
                                                                                    </li>
                                                                                </ul>
                                                                                <div class="tab-content">
                                                                                    <div class="tab-pane active" id="tab_1">
                                                                                        <!-- TASK COMMENTS -->
                                                                                        <div class="form-body">
                                                                                            <div class="form-group">
                                                                                                <div class="col-md-12">
                                                                                                    <asp:ListView ID="listChet" runat="server">

                                                                                                        <ItemTemplate>
                                                                                                            <ul class="media-list">
                                                                                                                <li class="media">
                                                                                                                    <div class="media-body todo-comment">
                                                                                                                        <p class="todo-comment-head">
                                                                                                                            <span class="todo-comment-username"><%#Eval("Version")%></span> &nbsp;
                                                                                            <span class="todo-comment-date"><%# DateTime.Parse(Eval("UPDTTIME").ToString())%></span>
                                                                                                                        </p>
                                                                                                                        <p class="todo-text-color">
                                                                                                                            <%#Eval("ActivityPerform")%>
                                                                                                                        </p>

                                                                                                                    </div>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:ListView>



                                                                                                    <!-- END TASK COMMENTS -->
                                                                                                    <!-- TASK COMMENT FORM -->

                                                                                                    <div class="col-md4">
                                                                                                        <ul class="media-list">
                                                                                                            <li class="media">
                                                                                                                <div class="media-body">
                                                                                                                    <asp:TextBox ID="txtComent" runat="server" placeholder="Type comment..." Rows="4" class="form-control todo-taskbody-taskdesc" TextMode="MultiLine"></asp:TextBox>
                                                                                                                </div>
                                                                                                            </li>
                                                                                                        </ul>
                                                                                                        <div class="form">

                                                                                                            <asp:Button ID="btnSubmit" runat="server" class="pull-right btn btn-sm btn-circle green" OnClick="btnSubmit_Click" Text="Submit" />
                                                                                                            <%--   <asp:Button ID="btnTikitClose" runat="server" class="btn btn-circle btn-sm btn-default" OnClick="btnTikitClose_Click" Text="Close" Style="margin-right: 10px;" />--%>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <%--<div class="form-group">--%>
                                                                                                    <div class="col-md-8"></div>

                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <!-- END TASK COMMENT FORM -->
                                                                                    </div>

                                                                                    <div class="tab-pane" id="tab_2">
                                                                                        <asp:ListView ID="ListHistoy" runat="server">
                                                                                            <ItemTemplate>
                                                                                                <ul class="todo-task-history">
                                                                                                    <li>
                                                                                                        <div class="todo-task-history-date"><%# DateTime.Parse(Eval("UPDTTIME").ToString())%> </div>
                                                                                                        <div class="todo-task-history-desc"><%#Eval("Version")%> </div>
                                                                                                    </li>
                                                                                                </ul>
                                                                                            </ItemTemplate>
                                                                                        </asp:ListView>

                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clearfix"></div>
                        <asp:HiddenField ID="hiddenpanel" runat="server" />
                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Status</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-horizontal" role="form">
                                            <div class="row">
                                                <asp:Panel ID="Panel2" runat="server" Visible="false">
                                                    <div class="alert alert-danger">
                                                        <strong>Error!</strong>
                                                        Ticket Allready Exist..
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" ID="Label17" class="col-md-2 control-label">Status</asp:Label>
                                                        <div class="col-md-10" style="float: right">
                                                            <asp:DropDownList ID="drpStatus" runat="server" class="form-control todo-taskbody-tags">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="drpStatus" ErrorMessage="Status is Required." CssClass="Validation" InitialValue="0" ValidationGroup="btnsubmitStatus"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:LinkButton ID="LinkButton2" runat="server" class="btn default">Close</asp:LinkButton>

                                        <%--  <asp:LinkButton ID="LinkButtonStatusSave" runat="server" class="btn green" ValidationGroup="btnsubmitStatus" OnClick="LinkButtonStatusSave_Click">Save</asp:LinkButton>--%>
                                        <asp:Button ID="btnTicketSave" runat="server" class="btn green" Text="Save" OnClick="LinkButtonStatusSave_Click" ValidationGroup="btnsubmitStatus" />
                                    </div>
                                </div>
                            </div>

                        </asp:Panel>

                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" DynamicServicePath=""
                            BackgroundCssClass="modalBackground" CancelControlID="LinkButton2" Enabled="True"
                            PopupControlID="Panel1" TargetControlID="hiddenpanel">
                        </cc1:ModalPopupExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="scroll-to-top">
                <i class="icon-arrow-up"></i>
            </div>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

    <script src="../assets/apps/scripts/todo-2.min.js" type="text/javascript"></script>
</asp:Content>
