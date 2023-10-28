using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using Repository;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

namespace Web.ACM
{
    public partial class UserRole : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
                btnSearch_Click(sender, e);

            }
        }
        private void LoadDepartments()
        {
            //TP_Details.Enabled = true;
            //TP_Details.Visible = true;
            //TC_Roles.ActiveTabIndex = 1;
            int UTID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
            if(UTID == 1)
            {
                List<ClsDepartments> deptList = ClsDepartments.GetAllDepartmentsadmin();
                ddlMenus.DataSource = deptList;
                ddlMenus.DataBind();
            }
            else
            {
                List<ClsDepartments> deptList = ClsDepartments.GetAllDepartments();
                ddlMenus.DataSource = deptList;
                ddlMenus.DataBind();
            }
      

        }
        protected void Rep_Activities_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox CB_Activity = (CheckBox)e.Item.FindControl("CB_Activity");
                    HtmlContainerControl Div_Operations = (HtmlContainerControl)e.Item.FindControl("Div_Operations");
                    CB_Activity.Attributes.Add("onclick", "SelectOperation('" + CB_Activity.ClientID + "', '"
                                                                        + Div_Operations.ClientID + "',true)");
                    CheckBox CB_ActivityPrint = (CheckBox)Div_Operations.FindControl("CB_ActivityPrint");
                    CheckBox CB_ActivityView = (CheckBox)Div_Operations.FindControl("CB_ActivityView");
                    CheckBox CB_ActivityAdd = (CheckBox)Div_Operations.FindControl("CB_ActivityAdd");
                    CheckBox CB_ActivityUpdate = (CheckBox)Div_Operations.FindControl("CB_ActivityUpdate");
                    CheckBox CB_ActivityDelete = (CheckBox)Div_Operations.FindControl("CB_ActivityDelete");

                    CB_ActivityPrint.Enabled = CB_Activity.Checked = false;
                    CB_ActivityView.Enabled = CB_ActivityView.Checked = false;
                    CB_ActivityAdd.Enabled = CB_ActivityAdd.Checked = false;
                    CB_ActivityUpdate.Enabled = CB_ActivityUpdate.Checked = false;
                    CB_ActivityDelete.Enabled = CB_ActivityDelete.Checked = false;

                }

            }
            catch (Exception ex)
            {
                //ShowMessage(ex.Message);
            }
        }

        protected void ddlMenus_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    /*SelectAll*/
                    Literal LtrlDeptName = (Literal)e.Item.FindControl("LtrlDeptName");
                    HiddenField HF_DeptID = (HiddenField)e.Item.FindControl("HF_DeptID");
                    Repeater Rep_Activities = (Repeater)e.Item.FindControl("Rep_Activities");
                    Rep_Activities.ItemDataBound += Rep_Activities_ItemDataBound;
                    CheckBox CB_SelectAll = (CheckBox)e.Item.FindControl("CB_SelectAll");
                    HtmlContainerControl div_activities = (HtmlContainerControl)e.Item.FindControl("div_activities");
                    CB_SelectAll.Attributes.Add("onclick", "SelectAll('" + CB_SelectAll.ClientID + "', '"
                                                                        + div_activities.ClientID + "')");

                    LtrlDeptName.Text = DataBinder.Eval(e.Item.DataItem, "DepartmentName").ToString();
                    HF_DeptID.Value = DataBinder.Eval(e.Item.DataItem, "DepartmentID").ToString();
                    int UTID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                    DataTable DT_Activities;
                    if (UTID  == 1)
                    {
                        DT_Activities = ClsActivities.GetActivitiesTableadmin("", HF_DeptID.Value);
                    }
                    else
                    {
                        DT_Activities = ClsActivities.GetActivitiesTable("", HF_DeptID.Value);
                    }
                  
                    Rep_Activities.DataSource = DT_Activities.DefaultView;
                    Rep_Activities.DataBind();
                }
            }
            catch (Exception ex)
            {
                // ShowMessage(ex.Message);
            }



        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentActitity.ActivityAdd)
            {
                List<ClsActivities> activitiesList = new List<ClsActivities>();
                foreach (DataListItem item in ddlMenus.Items)
                {
                    CheckBox CB_SelectAll = (CheckBox)item.FindControl("CB_SelectAll");
                    HiddenField HF_DeptID = (HiddenField)item.FindControl("HF_DeptID");
                    Repeater Rep_Activities = (Repeater)item.FindControl("Rep_Activities");
                    Rep_Activities.ItemDataBound += Rep_Activities_ItemDataBound;

                    foreach (RepeaterItem repItem in Rep_Activities.Items)
                    {
                        CheckBox CB_Activity = (CheckBox)repItem.FindControl("CB_Activity");
                        CheckBox CB_ActivityPrint = (CheckBox)repItem.FindControl("CB_ActivityPrint");
                        CheckBox CB_ActivityView = (CheckBox)repItem.FindControl("CB_ActivityView");
                        CheckBox CB_ActivityAdd = (CheckBox)repItem.FindControl("CB_ActivityAdd");
                        CheckBox CB_ActivityUpdate = (CheckBox)repItem.FindControl("CB_ActivityUpdate");
                        CheckBox CB_ActivityDelete = (CheckBox)repItem.FindControl("CB_ActivityDelete");
                        HiddenField HF_ActivityID = (HiddenField)repItem.FindControl("HF_ActivityID");

                        ClsActivities activity = new ClsActivities();
                        activity.ActivityName = CB_Activity.Text;
                        activity.ActivityId = HF_ActivityID.Value;
                        activity.CreatedID = "1";
                        //HF_DeptID.Value;
                        if (CB_SelectAll.Checked)
                        {
                            activity.ActivityPrint = true;
                            activity.ActivityView = true;
                            activity.ActivityAdd = true;
                            activity.ActivityUpdate = true;
                            activity.ActivityDelete = true;
                            activitiesList.Add(activity);
                        }
                        else
                        {
                            if (CB_Activity.Checked)
                            {
                                activity.ActivityPrint = CB_ActivityPrint.Checked;
                                activity.ActivityView = CB_ActivityView.Checked;
                                activity.ActivityAdd = CB_ActivityAdd.Checked;
                                activity.ActivityUpdate = CB_ActivityUpdate.Checked;
                                activity.ActivityDelete = CB_ActivityDelete.Checked;
                                activitiesList.Add(activity);
                            }
                        }
                    }
                }
                ClsRoles newRole = new ClsRoles();
                newRole.RoleId = hidRoleID.Value;
                newRole.RoleName = txtRoleName.Text.Trim();

                //newRole.IsAdmin = chkIsadmin.Checked;
                newRole.CreatedBy = LoginUserID.ToString();
                newRole.LastUpdatedBy = LoginUserID.ToString();
                try
                {
                    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                    ClsRoles.SaveRole(newRole, activitiesList, TID);
                   // ShowMessage("Role Saved Successfully", 4);
                    LoadDepartments();
                    //TC_Roles.ActiveTabIndex = 0;
                    btnSearch_Click(sender, e);


                }
                catch (Exception exp)
                {
                    //  ShowMessage(exp.Message);
                }
            }
            else
            {
                // ShowMessage("Save Permission Is Not Assigned");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentActitity.ActivityView)
                {
                    string Name = txtsRoleName.Text;
                    int Top = 10;
                    ClsRoles Role = new ClsRoles();
                    if (txtsRoleName.Text == string.Empty)
                    {
                        Name = "-";
                    }
                    if (txtTop.Text != string.Empty)
                    {
                        Top = Convert.ToInt32(txtTop.Text);
                    }
                    int UTID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                    gvRole.DataSource = Role.getAllRolesTop(Top, Name, UTID,TID);
                    gvRole.DataBind();
                }
                else
                {
                    ShowMessage("View Permission Is Not Assigned");
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        protected void gvRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                switch (e.CommandName.ToLower())
                {
                    case "change":
                        if (CurrentActitity.ActivityUpdate)
                        {
                            hidRoleID.Value = e.CommandArgument.ToString();
                            LoadRoleDetails();
                             TC_Roles.ActiveTabIndex = 1;
                        }
                        else
                        {
                            ShowMessage("Update Permission Is Not Assigned");


                        }
                        break;
                    case "remove":
                        if (CurrentActitity.ActivityDelete)
                        {
                            RemoveRole(e.CommandArgument.ToString());
                            btnSearch_Click(sender, e);
                        }
                        else
                        {
                            ShowMessage("Delete Permission Is Not Assigned");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        private void LoadRoleDetails()
        {

            try
            {
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                ClsRoles role = ClsRoles.GetRoleByRoleId(hidRoleID.Value);
                if (role != null)
                {
                    LoadDepartments();
                    txtRoleName.Text = role.RoleName;
                    txtDescription.Text = role.RoleDescr;
                    //chkIsadmin.Checked = role.IsAdmin;


                    List<ClsActivities> roleActivities = ClsActivities.GetRoleActivities(hidRoleID.Value, TID);
                    foreach (DataListItem item in ddlMenus.Items)
                    {
                        bool AllDeptActivities = true;
                        HiddenField HF_DeptID = (HiddenField)item.FindControl("HF_DeptID");
                        Repeater Rep_Activities = (Repeater)item.FindControl("Rep_Activities");

                        foreach (RepeaterItem repItem in Rep_Activities.Items)
                        {
                            CheckBox CB_Activity = (CheckBox)repItem.FindControl("CB_Activity");
                            CheckBox CB_ActivityPrint = (CheckBox)repItem.FindControl("CB_ActivityPrint");
                            CheckBox CB_ActivityView = (CheckBox)repItem.FindControl("CB_ActivityView");
                            CheckBox CB_ActivityAdd = (CheckBox)repItem.FindControl("CB_ActivityAdd");
                            CheckBox CB_ActivityUpdate = (CheckBox)repItem.FindControl("CB_ActivityUpdate");
                            CheckBox CB_ActivityDelete = (CheckBox)repItem.FindControl("CB_ActivityDelete");
                            HiddenField HF_ActivityID = (HiddenField)repItem.FindControl("HF_ActivityID");

                            ClsActivities activity = new ClsActivities();
                            activity.ActivityName = CB_Activity.Text;
                            activity.ActivityId = HF_ActivityID.Value;
                            activity.CreatedID = "1";
                            //= HF_DeptID.Value;
                            var match = from a in roleActivities
                                        where a.ActivityId == activity.ActivityId
                                        select a;
                            if (match.GetEnumerator().MoveNext())
                            {
                                CB_Activity.Checked = true;
                                CB_ActivityPrint.Checked = match.ElementAt(0).ActivityPrint;
                                CB_ActivityView.Checked = match.ElementAt(0).ActivityView;
                                CB_ActivityAdd.Checked = match.ElementAt(0).ActivityAdd;
                                CB_ActivityUpdate.Checked = match.ElementAt(0).ActivityUpdate;
                                CB_ActivityDelete.Checked = match.ElementAt(0).ActivityDelete;
                                if (AllDeptActivities && CB_ActivityAdd.Checked &&
                                    CB_ActivityDelete.Checked && CB_ActivityPrint.Checked &&
                                    CB_ActivityUpdate.Checked && CB_ActivityView.Checked)
                                    AllDeptActivities = true;
                                else
                                    AllDeptActivities = false;
                                CB_ActivityPrint.Enabled = true;
                                CB_ActivityView.Enabled = true;
                                CB_ActivityAdd.Enabled = true;
                                CB_ActivityUpdate.Enabled = true;
                                CB_ActivityDelete.Enabled = true;

                            }
                            else
                            {
                                CB_Activity.Checked = false;
                                AllDeptActivities = false;
                                CB_ActivityPrint.Checked = CB_ActivityPrint.Enabled = false;
                                CB_ActivityView.Checked = CB_ActivityView.Enabled = false;
                                CB_ActivityAdd.Checked = CB_ActivityAdd.Enabled = false;
                                CB_ActivityUpdate.Checked = CB_ActivityUpdate.Enabled = false;
                                CB_ActivityDelete.Checked = CB_ActivityDelete.Enabled = false;
                            }
                        }
                        if (AllDeptActivities)
                        {
                            CheckBox CB_SelectAll = (CheckBox)item.FindControl("CB_SelectAll");
                            HtmlContainerControl div_activities = (HtmlContainerControl)item.FindControl("div_activities");
                            //div_activities.Style.Add("display", "none");
                            CB_SelectAll.Checked = true;
                        }
                    }
                    //FocusIt(TxBx_RoleName.ClientID);
                }
                else
                {
                    ShowMessage("Sorry! But user information was not found");

                }
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
            }
        }

        public static bool RemoveRole(string RoleId)
        {
            //   ClsDatabaseManager dbManager = ClsDatabaseManager.InitializeDbManager(Databases.MunicipalCorporationMemberShip);
            bool result = false;
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]
                    {

                    new SqlParameter("@RoleId", RoleId),


                    };

                    result = Convert.ToBoolean(SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "[MemberShip].RemoveRole",param));
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return result;
        }

    }
}
