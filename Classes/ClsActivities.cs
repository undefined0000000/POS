using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    [Serializable]
    public class ClsActivities
    {
        #region [Private Members]
        private string _ActivityId;
        private string _ActivityName;
        private string _ActivityDescription;
        private string _CreatedId;
        private string _ActivityPage;
        private bool _ActivityAdd;
        private bool _ActivityUpdate;
        private bool _ActivityDelete;
        private bool _ActivityView;
        private bool _ActivityPrint;
        #endregion
        #region [Public Properties]
        public string CreatedID
        {
            get { return _CreatedId; }
            set { _CreatedId = value; }
        }
        public string ActivityDescription
        {
            get { return _ActivityDescription; }
            set { _ActivityDescription = value; }
        }
        public string ActivityName
        {
            get { return _ActivityName; }
            set { _ActivityName = value; }
        }
        public string ActivityId
        {
            get { return _ActivityId; }
            set { _ActivityId = value; }
        }
        public bool ActivityAdd
        {
            get { return _ActivityAdd; }
            set { _ActivityAdd = value; }
        }
        public bool ActivityUpdate
        {
            get { return _ActivityUpdate; }
            set { _ActivityUpdate = value; }
        }
        public bool ActivityDelete
        {
            get { return _ActivityDelete; }
            set { _ActivityDelete = value; }
        }
        public bool ActivityView
        {
            get { return _ActivityView; }
            set { _ActivityView = value; }
        }
        public bool ActivityPrint
        {
            get { return _ActivityPrint; }
            set { _ActivityPrint = value; }
        }
        public string ActivityPage
        {
            get { return _ActivityPage; }
            set { _ActivityPage = value; }
        }
        public int NodeID { get; set; }
        public string NodeValue { get; set; }
        public string NodeImageUrl { get; set; }
        public string NodeNavUrl { get; set; }
        public int IsParent { get; set; }
        public int ParentID { get; set; }
        public string PageTitle { get; set; }
        public string PagePath { get; set; }
        public bool IsVisibleInMenu { get; set; }
        public List<ClsActivities> Childs { get; set; }
        #endregion
        #region [Constructor]
        public ClsActivities()
        {
            ActivityId = "-1";
            ActivityName = "";
            ActivityDescription = "";
            ActivityAdd = false;
            ActivityPrint = false;
            ActivityDelete = false;
            ActivityUpdate = false;
            ActivityView = false;
            ActivityPage = "Dashboard.aspx";
        }
        #endregion
        #region [Public Static Methods]
        public static DataTable GetActivitiesTable(string DepartmentName, string DeptId)
        {
            DataTable ActivityTable = null;
            
            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    var ds = SqlHelper.ExecuteDataset(con,CommandType.Text, "select NodeID,PageTitle,MenuOrder from MemberShip.TreeNode where ParentID=" + DeptId + " and IsvisibleInMenu=1 Order by MenuOrder");
                    if (ds != null && ds.Tables.Count > 0)
                        ActivityTable = ds.Tables[0];
                }
            }
            catch (Exception exp)
            {
              
                throw exp;
            }
            return ActivityTable;
        }
        public static DataTable getAllRole(int TenentID)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {


                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@TenentID", TenentID),


                };

                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MemberShip.GetRoles", param).Tables[0];
                    con.Close();
                    return DT;
                    
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataTable GetMenuName(int MenuID)
        {
            DataTable ActivityTable = null;

            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    var ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select NodeID,PageTitle,MenuOrder from MemberShip.TreeNode where NodeID=" + MenuID);
                    if (ds != null && ds.Tables.Count > 0)
                        ActivityTable = ds.Tables[0];
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return ActivityTable;
        }

        public static DataTable GetActivitiesTableadmin(string DepartmentName, string DeptId)
        {
            DataTable ActivityTable = null;

            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    var ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select NodeID,PageTitle,MenuOrder from MemberShip.TreeNode where ParentID=" + DeptId + " Order by MenuOrder");
                    if (ds != null && ds.Tables.Count > 0)
                        ActivityTable = ds.Tables[0];
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return ActivityTable;
        }
        public static void SaveRoleActivities(ClsActivities activity, string RoleId, string AssignedById, bool isTransaction,int TenentID)
        {
            try
            {

          
            using (SqlConnection con = SqlHelper.createConnection())
            {
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@RoleId", RoleId),
                    new SqlParameter("@NodeId", activity.ActivityId),
                    new SqlParameter("@ActivityPrint", activity.ActivityPrint),
                    new SqlParameter("@ActivityView", activity.ActivityView),
                    new SqlParameter("@AssignedAdd", activity.ActivityAdd),
                    new SqlParameter("@ActivityUpdate", activity.ActivityUpdate),
                    new SqlParameter("@ActivityDelete", activity.ActivityDelete),
                    new SqlParameter("@CreatedBy", activity.CreatedID),
                    new SqlParameter("@TenentID", TenentID)
                        };
               
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MemberShip.InsertRoleActivities", param);

                }
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        public static List<ClsActivities> GetRoleActivities(string RoleId,int TenentID)
        {
            var activitieslist = new List<ClsActivities>();
           
            try
            {
              
                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter ( "@RoleID", RoleId),
                    new SqlParameter ( "@TenentID", TenentID)
                    };
                    var ds = SqlHelper.ExecuteDataset(con,CommandType.StoredProcedure, "MemberShip.GetActivitiesByRole",param);
              
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var activity = new ClsActivities();
                        activity.ActivityId = row["NodeID"].ToString();
                        activity.ActivityName = row["PageTitle"].ToString();
                        activity.ActivityPrint = Convert.ToBoolean(row["ActivityPrint"]);
                        activity.ActivityView = Convert.ToBoolean(row["ActivityView"]);
                        activity.ActivityAdd = Convert.ToBoolean(row["ActivityAdd"]);
                        activity.ActivityUpdate = Convert.ToBoolean(row["ActivityUpdate"]);
                        activity.ActivityDelete = Convert.ToBoolean(row["ActivityDelete"]);
                        activitieslist.Add(activity);
                    }
                }
                }
            
            }
            catch (Exception exp)
            {
             
                throw exp;
            }
            return activitieslist;
        }
        public static List<ClsActivities> GetMenusByRoleId(string roleId,int TenentID)
        {

            var activitieslist = new List<ClsActivities>();
           
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter ( "@RoleID", roleId),
                    new SqlParameter ( "@TenentID", TenentID),
                    };
                    var reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "MemberShip.usp_GetMenusByRole",param);


                    while (reader != null && reader.Read())
                    {
                        var activity = new ClsActivities();
                        activity.NodeID = Convert.ToInt32( reader["NodeID"]);
                        activity.NodeValue = reader["NodeValue"].ToString();
                        activity.NodeImageUrl = reader["NodeImageUrl"].ToString();
                        activity.NodeNavUrl = reader["NodeNavUrl"].ToString();
                        activity.IsParent = Convert.ToInt32(reader["IsParent"]);
                        activity.ParentID = Convert.ToInt32(reader["ParentID"]);
                        activity.PageTitle = reader["PageTitle"].ToString();
                        activity.DashBoardImage = reader["DashBoardImage"].ToString();
                        activity.IsVisibleInMenu = Convert.ToBoolean(reader["IsVisibleInMenu"]);
                        activitieslist.Add(activity);
                    }
                }
               
               
            }
            catch (Exception  )
            {
              
            }
            return activitieslist;
        }

        public static List<ClsActivities> GetMasterID(int MenuID,int TenentID,int RoleID)
        {
            var activitieslist = new List<ClsActivities>();

            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter ( "@NodeID", MenuID),
                    new SqlParameter ( "@TenentID", TenentID),
                    new SqlParameter ( "@RoleID", RoleID)
                    };
                    var reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "MemberShip.GetPageByMaster", param);


                    while (reader != null && reader.Read())
                    {
                        var activity = new ClsActivities();
                        activity.NodeID = Convert.ToInt32(reader["NodeID"]);
                        activity.NodeValue = reader["NodeValue"].ToString();
                        activity.NodeImageUrl = reader["NodeImageUrl"].ToString();
                        activity.NodeNavUrl = reader["NodeNavUrl"].ToString();
                        activity.IsParent = Convert.ToInt32(reader["IsParent"]);
                        activity.ParentID = Convert.ToInt32(reader["ParentID"]);
                        activity.PageTitle = reader["PageTitle"].ToString();
                        activity.DashBoardImage = reader["DashBoardImage"].ToString();
                        activity.IsVisibleInMenu = Convert.ToBoolean(reader["IsVisibleInMenu"]);
                        activitieslist.Add(activity);
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return activitieslist;
        }
        public static DataTable GetMenusForDashBoard(int roleId)
        {
            DataTable activitieslist;
          
            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter ( "@RoleID", roleId),
                    };
                    activitieslist = SqlHelper.ExecuteDataset(con,CommandType.StoredProcedure,"[Membership].[usp_GetMenusForDashBoardByRoleID]",param).Tables[0];
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
               
            }
            return activitieslist;
        }

        public static DataTable GetParentByNode(int NodeID, int TenentID)
        {
            DataTable activitieslist;

            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter ( "@NodeID", NodeID),
                    new SqlParameter ( "@TenentID", TenentID)
                    };
                    activitieslist = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[Membership].[GetPageByNode]",param).Tables[0];
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }
            return activitieslist;
        }

        public static DataTable GetParentBymaster(int NodeID,int TenentID)
        {
            DataTable activitieslist;

            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter ( "@NodeID", NodeID),
                     new SqlParameter ( "@TenentID", TenentID)
                    };
                    activitieslist = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[Membership].[GetPageByMaster]", param).Tables[0];
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }
            return activitieslist;
        }

        public static DataTable GetParentCmb( int TenentID)
        {
            DataTable activitieslist;

            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                   
                     new SqlParameter ( "@TenentID", TenentID)
                    };
                    activitieslist = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[Membership].[GetParentCmb]", param).Tables[0];
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }
            return activitieslist;
        }

        public static DataTable GetNode(int NodeID,int TenentID)
        {
            DataTable activitieslist;

            try
            {

                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter ( "@NodeID", NodeID),

                     new SqlParameter ( "@TenentID", TenentID)
                    };
                    activitieslist = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[Membership].[GetNode]", param).Tables[0];
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }
            return activitieslist;
        }

        public static void SaveNode(string NodeNavUrl,bool IsParent,int ParentID,string PagePath,string PageTitle,string PageTitle1,string PageTitle2,bool IsVisibleInMenu,int TenentID)
        {

            using (SqlConnection con = SqlHelper.createConnection())
            {
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@NodeNavUrl", NodeNavUrl),
                    new SqlParameter("@IsParent", IsParent),
                    new SqlParameter("@ParentID", ParentID),
                    new SqlParameter("@PagePath", PagePath),
                    new SqlParameter("@PageTitle",PageTitle),
                    new SqlParameter("@PageTitle1", PageTitle1),
                    new SqlParameter("@PageTitle2", PageTitle2),
                    new SqlParameter("@IsVisibleInMenu", IsVisibleInMenu),
                    new SqlParameter("@TenentID", TenentID)
                        };

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MemberShip.Insert_Node", param);

            }

        }
        public static void EditNode(int NodeID,string NodeNavUrl, bool IsParent, int ParentID, string PagePath, string PageTitle, string PageTitle1, string PageTitle2, bool IsVisibleInMenu)
        {
            try
            {

          
            using (SqlConnection con = SqlHelper.createConnection())
            {
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@NodeNavUrl", NodeNavUrl),
                    new SqlParameter("@IsParent", IsParent),
                    new SqlParameter("@ParentID", ParentID),
                    new SqlParameter("@PagePath", PagePath),
                    new SqlParameter("@PageTitle",PageTitle),
                    new SqlParameter("@PageTitle1", PageTitle1),
                    new SqlParameter("@PageTitle2", PageTitle2),
                    new SqlParameter("@IsVisibleInMenu", IsVisibleInMenu),
                    new SqlParameter("@NodeID", NodeID)
                        };

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MemberShip.Edit_Node", param);

            }
            }
            catch (Exception ex)
            {

               
            }

        }
        #endregion
        public string PageIcon { get; set; }
        public string DashBoardImage { get; private set; }
    }
}