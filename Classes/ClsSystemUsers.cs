using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace Repository
{
    public class ClsSystemUsers
    {
        #region [Private Members]
        public string NewPassword { get; set; }
        public int TotalRecords;
        private int _UserId;
        private string _UserName;
        private string _UserRoleId;
        private string _UserRoleName;
        private int _UserStatus;
        private string _UserLogin;
        private string _UserPassword;
        private string _CreatedByUserId;
        private string _LastUpdateById;
        private string _UserDesignation;
        private string _DepartmentID;
        private string _DepartmentName;
        #endregion
        #region [Public Properties]
        public bool IsAdmin { get; set; }
        public int OrganizationID { get; set; }
        public string UserPhoto { get; set; }

        public bool IsComplaintUser { get; set; }
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string UserRoleId
        {
            get { return _UserRoleId; }
            set { _UserRoleId = value; }
        }
        public string UserRoleName
        {
            get { return _UserRoleName; }
            set { _UserRoleName = value; }
        }
        public int UserStatus
        {
            get { return _UserStatus; }
            set { _UserStatus = value; }
        }
        public string UserLogin
        {
            get { return _UserLogin; }
            set { _UserLogin = value; }
        }
        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }
        public string CreatedByUserId
        {
            get { return _CreatedByUserId; }
            set { _CreatedByUserId = value; }
        }
        public string UserDesignation
        {
            get { return _UserDesignation; }
            set { _UserDesignation = value; }
        }
        public string LastUpdateById
        {
            get { return _LastUpdateById; }
            set { _LastUpdateById = value; }
        }
        public int DistrictID { get; set; }
        public string DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }
        public bool IsActive { get; set; }
        public string UserSession { get; private set; }
        public string OldPassword { get; set; }
        public int CurrentFinanicalYear { get; set; }
        #endregion
        #region [Constructor]
        public ClsSystemUsers()
        {
            UserDesignation = UserLogin = UserName = UserPassword = UserRoleName = string.Empty;
            UserId = -1;
            UserRoleId = "-1";
            UserStatus = 0;
            CreatedByUserId = "-1";
            LastUpdateById = "0";
            DepartmentID = "0";
            DepartmentName = string.Empty;
        }
        public ClsSystemUsers(string UserId)
        {
        }
        #endregion
        #region[Public Static Methods]
        //public static void SaveUser(ClsSystemUsers newUser)
        //{
        //    if (newUser.UserId == 0)
        //    {
        //        var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //        dbManager.CreateParameters(8);
        //        dbManager.AddParameters(0, "@UserName", newUser.UserName);
        //        dbManager.AddParameters(1, "@UserLogin", newUser.UserLogin);
        //        dbManager.AddParameters(2, "@UserPassword", newUser.UserPassword);
        //        dbManager.AddParameters(3, "@CreatedBy", newUser.CreatedByUserId);
        //        dbManager.AddParameters(4, "@RoleId", newUser.UserRoleId);
        //        dbManager.AddParameters(5, "@OrganizationID", newUser.OrganizationID);
        //        dbManager.AddParameters(6, "@IsActive", newUser.IsActive);
        //        dbManager.AddParameters(7, "@IsComplaintUser", newUser.IsComplaintUser);
        //        try
        //        {
        //            dbManager.Open();
        //            dbManager.BeginTransaction();
        //            dbManager.ExecuteNonQuery("[MemberShip].[InsertSystemUsers]");
        //            dbManager.CommitTransaction();
        //            dbManager.Dispose();
        //        }
        //        catch (Exception exp)
        //        {
        //            dbManager.RollbackTransaction();
        //            dbManager.Dispose();
        //            throw exp;
        //        }
        //    }
        //    else
        //    {
        //        var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //        dbManager.CreateParameters(8);
        //        dbManager.AddParameters(0, "@UserName", newUser.UserName);
        //        dbManager.AddParameters(1, "@UserLogin", newUser.UserLogin);
        //        dbManager.AddParameters(2, "@UserPassword", newUser.UserPassword);
        //        dbManager.AddParameters(3, "@UPdatedById", newUser.LastUpdateById);
        //        dbManager.AddParameters(4, "@RoleId", newUser.UserRoleId);
        //        dbManager.AddParameters(5, "@UserID", newUser.UserId);
        //        dbManager.AddParameters(6, "@OrganizationID", newUser.OrganizationID);
        //        dbManager.AddParameters(7, "@IsComplaintUser", newUser.IsComplaintUser);
        //        try
        //        {
        //            dbManager.Open();
        //            dbManager.BeginTransaction();
        //            dbManager.ExecuteNonQuery("[MemberShip].[UpdateSystemUsers]");
        //            dbManager.CommitTransaction();
        //            dbManager.Dispose();
        //        }
        //        catch (Exception exp)
        //        {
        //            dbManager.RollbackTransaction();
        //            dbManager.Dispose();
        //            throw exp;
        //        }
        //    }
        //}
        //public DataTable getAllUsersTop(int Top, string Name, int Organ, bool IsAdmin)
        //{
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    DataTable dt;
        //    try
        //    {
        //        dbManager.CreateParameters(4);
        //        dbManager.AddParameters(0, "@Top", Top);
        //        dbManager.AddParameters(1, "@userName", Name);
        //        dbManager.AddParameters(2, "@OrganId", Organ);
        //        dbManager.AddParameters(3, "@IsAdmin", IsAdmin);
        //        dbManager.Open();
        //        dt = dbManager.ExecuteDataTable("Membership.getAllUsers");
        //        dbManager.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbManager.Dispose();
        //        throw ex;
        //    }
        //    return dt;
        //}
        //public DataTable getAllUsersByOrgID(int Organization_ID, bool IsAdmin)
        //{
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    DataTable dt;
        //    try
        //    {
        //        dbManager.CreateParameters(2);
        //        dbManager.AddParameters(0, "@OrganId", Organization_ID);
        //        dbManager.AddParameters(1, "@IsAdmin", IsAdmin);
        //        dbManager.Open();
        //        dt = dbManager.ExecuteDataTable("[Membership].[getAllUsersByOrgID]");
        //        dbManager.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbManager.Dispose();
        //        throw ex;
        //    }
        //    return dt;
        //}
        //public static bool VerifyLoginName(string email)
        //{
        //    bool result;
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    dbManager.CreateParameters(1);
        //    dbManager.AddParameters(0, "@UserName", email);
        //    dbManager.Open();
        //    try
        //    {
        //        result = dbManager.ExecuteScalar("[Membership].[VerifyUserName]").ToBool();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbManager.Close();
        //        dbManager.Dispose();
        //    }
        //    return result;
        //}
        //public static List<ClsSystemUsers> GetAllUsers(string UserName, string RoleName, int Status, int PageIndex, int PageSize, string SortExpression, string SortDirection)
        //{
        //    var UsersList = new List<ClsSystemUsers>();
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    try
        //    {
        //        dbManager.CreateParameters(6);
        //        dbManager.AddParameters(0, "@UserName", UserName);
        //        dbManager.AddParameters(0, "@RoleName", RoleName);
        //        dbManager.AddParameters(1, "@Status", Status);
        //        dbManager.AddParameters(2, "@pageIndex", PageIndex);
        //        dbManager.AddParameters(3, "@pageSize", PageSize);
        //        dbManager.AddParameters(4, "@sortBy", SortExpression);
        //        dbManager.AddParameters(5, "@sortDirection", SortDirection);
        //        dbManager.Open();
        //        var ds = dbManager.ExecuteDataSet("[MemberShip].[GetAllSystemUsers]");
        //        dbManager.Dispose();
        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            foreach (DataRow row in ds.Tables[0].Rows)
        //            {
        //                var user = new ClsSystemUsers();
        //                user.UserId = row["UserID"].ToInt32();
        //                user.UserName = row["UserName"].ToString();
        //                user.UserLogin = row["UserLogin"].ToString();
        //                user.UserPassword = row["UserPassword"].ToString();
        //                user.UserStatus = Convert.ToInt32(row["Status"]);
        //                user.UserRoleName = row["RoleName"].ToString();
        //                user.TotalRecords = int.Parse(row["TotalRecords"].ToString());
        //                UsersList.Add(user);
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        dbManager.Dispose();
        //        throw exp;
        //    }
        //    return UsersList;
        //}
        //public static ClsSystemUsers AuthenticateUser(string UserLogin, string UserPassword)
        //{
        //    ClsSystemUsers LoginUser = null;
        //    UserPassword = Repository.SharedUtility.Encrypt(UserPassword);
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    dbManager.CreateParameters(2);
        //    dbManager.AddParameters(0, "@Login", UserLogin);
        //    dbManager.AddParameters(1, "@Password", UserPassword);
        //    var UserSessionID = HttpContext.Current.Session.SessionID;
        //    try
        //    {
        //        dbManager.Open();
        //        var reader = dbManager.ExecuteReader("[MemberShip].[GetUsersByLoginPassword]");
        //        if (reader != null && reader.Read())
        //        {
        //            LoginUser = new ClsSystemUsers();
        //            LoginUser.UserId = reader["UserId"].ToInt32();
        //            LoginUser.UserSession = UserSessionID;
        //            LoginUser.UserName = reader["Name"].ToString();
        //            LoginUser.UserLogin = reader["UserName"].ToString();
        //            LoginUser.UserPassword = reader["Password"].ToString();
        //            LoginUser.IsActive = Convert.ToBoolean(reader["IsActive"]);
        //            LoginUser.UserRoleId = reader["Role_ID"].ToString();
        //            LoginUser.UserRoleName = reader["RoleName"].ToString();
        //            LoginUser.OrganizationID = reader["OrganizationID"].ToInt32();
        //            LoginUser.UserPhoto = reader["UserPhoto"].ToString();
        //            LoginUser.IsAdmin = reader["IsAdmin"].ToBool();
        //            LoginUser.DistrictID = reader["District_ID"].ToInt32();
        //            LoginUser.CurrentFinanicalYear = reader["YearID"].ToInt32();
        //        }
        //        if (reader != null) reader.Close();
        //        if (LoginUser != null && LoginUser.IsActive)
        //        {
        //            dbManager.CreateParameters(1);
        //            dbManager.AddParameters(0, "@UserName", LoginUser.UserName);
        //            dbManager.ExecuteNonQuery("[Membership].[UpdateUserLogin]");
        //        }
        //        //
        //        var SessionByUser = (Hashtable)HttpContext.Current.Application["SessionByUser"];
        //        var UserObjectBySession = (Hashtable)HttpContext.Current.Application["UserObjectBySession"];
        //        //Remove duplicate Sessions / Users
        //        if (SessionByUser.Count > 0)
        //        {
        //            var OnlineSession = "";
        //            if (LoginUser != null && SessionByUser.ContainsKey(LoginUser.UserLogin))
        //            {
        //                OnlineSession = SessionByUser[LoginUser.UserLogin].ToString();
        //            }
        //            if (LoginUser != null) SessionByUser.Remove(LoginUser.UserLogin);
        //            UserObjectBySession.Remove(OnlineSession);
        //            UserObjectBySession.Remove(UserSessionID);
        //        }
        //        if (LoginUser != null)
        //        {
        //            //Add new user
        //            SessionByUser.Add(LoginUser.UserLogin, UserSessionID);
        //            UserObjectBySession.Add(UserSessionID, LoginUser);
        //            //add hash tables in application
        //            HttpContext.Current.Application.Lock();
        //            HttpContext.Current.Application["SessionByUser"] = SessionByUser;
        //            HttpContext.Current.Application["UserObjectBySession"] = UserObjectBySession;
        //            HttpContext.Current.Application.UnLock();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbManager.Dispose();
        //    }
        //    return LoginUser;
        //}
        //public static DataTable getUserbyID(int ID)
        //{
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    DataTable dt;
        //    try
        //    {
        //        dbManager.CreateParameters(1);
        //        dbManager.AddParameters(0, "@UserID", ID);
        //        dbManager.Open();
        //        dt = dbManager.ExecuteDataTable("Membership.GetUserByUserId");
        //        dbManager.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbManager.Dispose();
        //        throw ex;
        //    }
        //    return dt;
        //}
        //public static string GetUserName( string UID)
        //{
        //    string UserName;
        //    try
        //    {
        //        using (SqlConnection con = SqlHelper.createConnection())
        //        {


        //            SqlParameter[] param = new SqlParameter[]{
        //                   new SqlParameter ("@UserID", UID),
        //            };
        //            UserName = SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "SPR_Setup_GetUserName").ToString();
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        return "-";
        //    }
        //    return UserName;
        //}
        //public static void ChangeUserStatus(string UserId)
        //{
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    try
        //    {
        //        var Query = @"Update MemberShip.SystemUsers Set IsActive = case when IsActive=1 then 0 else 1 end  WHERE UserID='" + UserId + "'";
        //        dbManager.Open();
        //        dbManager.ExecuteNonQuery(Query, CommandType.Text);
        //        var UserName = dbManager.ExecuteScalar("SELECT UserName FROM MemberShip.Systemusers WHERE UserID=" + UserId, CommandType.Text).ToString();
        //        HttpContext.Current.Application.Lock();
        //        var SessionByUser = (Hashtable)HttpContext.Current.Application["SessionByUser"];
        //        var UserObjectBySession = (Hashtable)HttpContext.Current.Application["UserObjectBySession"];
        //        //if user is online destroy his session.
        //        if (SessionByUser.ContainsKey(UserName))
        //        {
        //            var SessionNumber = SessionByUser[UserName].ToString();
        //            //remove the user from Hash tables
        //            SessionByUser.Remove(UserName);
        //            UserObjectBySession.Remove(SessionNumber);
        //            //Update hash tables in application
        //            HttpContext.Current.Application["SessionByUser"] = SessionByUser;
        //            HttpContext.Current.Application["UserObjectBySession"] = UserObjectBySession;
        //            HttpContext.Current.Application.UnLock();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbManager.Close();
        //        dbManager.Dispose();
        //    }
        //}
        //public DataTable getUsers()
        //{
        //    var dt = new DataTable();
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    try
        //    {
        //        dbManager.Open();
        //        dt = dbManager.ExecuteDataTable("[Accounts].[GetSystemUser]");
        //        dbManager.Dispose();
        //    }
        //    catch (Exception exception)
        //    {
        //        dbManager.Dispose();
        //        throw exception;
        //    }
        //    return dt;
        //}
        //public static bool AddPhoto(int UserID, string Photo)
        //{
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    bool result;
        //    try
        //    {
        //        var Query = @"Update MemberShip.SystemUsers Set UserPhoto = '" + Photo + "'  WHERE UserID='" + UserID + "'";
        //        dbManager.Open();
        //        result = dbManager.ExecuteNonQuery(Query, CommandType.Text).ToBool();
        //        dbManager.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbManager.Dispose();
        //        throw ex;
        //    }
        //    return result;
        //}
        //public bool ChangePassword(ClsSystemUsers User)
        //{
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    bool result;
        //    try
        //    {
        //        dbManager.CreateParameters(3);
        //        dbManager.AddParameters(0, "@UserName", User.UserLogin);
        //        dbManager.AddParameters(1, "@Password", Repository.SharedUtility.Encrypt(User.UserPassword));
        //        dbManager.AddParameters(2, "@NewPassword", Repository.SharedUtility.Encrypt(User.NewPassword));
        //        dbManager.Open();
        //        result = dbManager.ExecuteNonQuery("Membership.ChangePassword").ToBool();
        //        dbManager.Dispose();
        //    }
        //    catch (Exception exp)
        //    {
        //        dbManager.Dispose();
        //        throw exp;
        //    }
        //    return result;
        //}
        //public DataTable getAllUsersByOrganizationID(int Organization_ID, bool IsAdmin)
        //{
        //    DataTable dt;
        //    var dbManager = ClsDatabaseManager.InitializeDbManager(Constants.Databases.MunicipalCorporationMemberShip);
        //    try
        //    {
        //        dbManager.Open();
        //        dbManager.CreateParameters(2);
        //        dbManager.AddParameters(0, "@Organization_ID", Organization_ID);
        //        dbManager.AddParameters(1, "@IsAdmin", IsAdmin);
        //        dt = dbManager.ExecuteDataTable("[Membership].[getAllUsersByOrgID]");
        //        dbManager.Dispose();
        //    }
        //    catch (Exception exception)
        //    {
        //        dbManager.Dispose();
        //        throw exception;
        //    }
        //    return dt;
        //}
        #endregion
    }
}