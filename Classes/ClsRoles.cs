using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClsRoles
/// </summary>
namespace Repository
{
    public class ClsRoles
    {
        #region [Private Members]
        public int TotalRecords;
        private string _RoleId;
        private string _RoleName;
        private string _RoleDescr;
        private string _CreatedBy;
        private string _LastUpdatedBy;
        private int _Status;
        #endregion

        #region [Public Properties]
        // public int OrganizationID { get; set; }
        public string LastUpdatedBy
        {
            get { return _LastUpdatedBy; }
            set { _LastUpdatedBy = value; }
        }

        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public string RoleDescr
        {
            get { return _RoleDescr; }
            set { _RoleDescr = value; }
        }

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        public string RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public bool IsAdmin { get; set; }

        #endregion

        #region [Constructor]
        public ClsRoles()
        {
            RoleId = "-1";
            RoleName = "";
            RoleDescr = "";
            CreatedBy = "0";
            LastUpdatedBy = "0";
            IsAdmin = false;
        }
        #endregion

        #region [Public Class Functions
        public static void SaveRole(ClsRoles newRole, List<ClsActivities> roleActivities,int TenentID)
        {



            if (newRole.RoleId == "0")
            {
                try
                {
                    using (SqlConnection con = SqlHelper.createConnection())
                    {
                        SqlParameter roleID = new SqlParameter();
                        roleID.Direction = ParameterDirection.Output;
                        roleID.ParameterName = "RoleID";
                        roleID.SqlDbType = SqlDbType.Int;

                        SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@RoleName", newRole.RoleName),
                         new SqlParameter("@RoleDescr", newRole.RoleDescr),
                         new SqlParameter("@CreatedBy", newRole.CreatedBy),
                         new SqlParameter("@IsAdmin", newRole.IsAdmin) ,
                        new SqlParameter("@TenentID", TenentID),roleID};
                        try
                        {
                          
                       
                        //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MemberShip.InsertNewRole", param);
                      
                        foreach (ClsActivities activity in roleActivities)
                        {
                            ClsActivities.SaveRoleActivities(activity,  roleID.Value.ToString(), newRole.LastUpdatedBy, true,TenentID);
                        }
                        
                        }
                        catch (Exception)
                        {

                          
                        }

                    }
                }



                catch (Exception exp)
                {

                    throw exp;
                }
            }
            else
            {
                try
                {
                    using (SqlConnection con = SqlHelper.createConnection())
                    {


                                              SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@RoleName", newRole.RoleName),
                         new SqlParameter("@RoleDescr", newRole.RoleDescr),
                      
                         new SqlParameter("@LastUpdatedBy", newRole.LastUpdatedBy),
                         new SqlParameter("@IsAdmin", newRole.IsAdmin),
                         new SqlParameter("@Roleid",newRole.RoleId)

                };
                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MemberShip.UpdateRole", param);
                        foreach (ClsActivities activity in roleActivities)
                        {
                            ClsActivities.SaveRoleActivities(activity, newRole.RoleId, newRole.LastUpdatedBy, true,TenentID);
                        }


                    }
                }



                catch (Exception exp)
                {

                    throw exp;
                }
            }

        }
        public DataTable getAllRolesTop(int Top, string Name,int Isadmin,int TenentID)
        {
          
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {


                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@Top", Top),
                         new SqlParameter("@RoleName", Name),
                         new SqlParameter("@Isadmin", Isadmin),
                         new SqlParameter("@TenentID", TenentID)

                };
          
                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MemberShip.GetSystemRolesTop",param).Tables[0];
                    return DT;
                }
          
            }
            catch (Exception ex)
            {
             
                throw ex;
            }
        }


        public DataTable getUserTenent(int TenentID)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {


                    SqlParameter[] param = new SqlParameter[]{
                        
                         new SqlParameter("@TenentID", TenentID)

                };

                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetUserTenent", param).Tables[0];
                    return DT;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static DataTable GetRolesForDDL(int TenentID)
        {
           
            DataTable dt = new DataTable();
            try
            {

             
                    using (SqlConnection con = SqlHelper.createConnection())
                    {

                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter( "@TenentID", TenentID),


                };

                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MemberShip.GetRolesForCmb",param).Tables[0];
                        return DT;
                    }


                }
                catch (Exception exp)
                {
                    throw exp;
                }
            
          

        }

        public static DataTable GetRolesbyID(int TenentID,int RoleID)
        {

            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection con = SqlHelper.createConnection())
                {

                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter( "@TenentID", TenentID),
                         new SqlParameter( "@RoleID", RoleID)


                };

                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MemberShip.GetRolesbyID", param).Tables[0];
                    return DT;
                }


            }
            catch (Exception exp)
            {
                throw exp;
            }



        }
        public static DataTable GETTenent(int TenentID)
        {

            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection con = SqlHelper.createConnection())
                {

                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter( "@TenentID", TenentID),


                };

                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MemberShip.GetTenentID", param).Tables[0];
                    return DT;
                }


            }
            catch (Exception exp)
            {
                throw exp;
            }

           

        }

        public static List<ClsRoles> GetAllRoles(int PageIndex, int PageSize,
            string SortExpression, string SortDirection)
        {
           


                DataTable DT = new DataTable();
                using (SqlConnection con = SqlHelper.createConnection())
                {


                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@pageIndex", PageIndex),
                         new SqlParameter("@pageSize", PageSize),
                         new SqlParameter("@sortBy", SortExpression),
                         new SqlParameter("@sortDirection", SortDirection),

                };

                    DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MemberShip.GetSystemRoles").Tables[0];

                }
                List<ClsRoles> rolesList = new List<ClsRoles>();
                if (DT != null && DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        ClsRoles role = new ClsRoles();
                        role.RoleId = row["RoleId"].ToString();
                        role.RoleName = row["RoleName"].ToString();
                        role.RoleDescr = row["RoleDescription"].ToString();
                        role.CreatedBy = row["CId"].ToString();
                        role.Status = Convert.ToInt32(row["Status"]);
                        role.TotalRecords = int.Parse(row["TotalRecords"].ToString());
                        rolesList.Add(role);


                    }
                }
                return rolesList;
            }


        public static ClsRoles GetRoleByRoleId(string RoleId)
        {
            ClsRoles role = null;

          
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection con = SqlHelper.createConnection())
                    {


                        IDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, "SELECT * FROM USER_MST WHERE USER_ID=" + RoleId );
                        if (reader != null && reader.Read())
                        {
                            role = new ClsRoles();
                            role.RoleId = reader["USER_ID"].ToString();
                            role.RoleName = reader["FIRST_NAME"].ToString();
                            role.RoleDescr = reader["FIRST_NAME1"].ToString();
                            //role.CreatedBy = reader["CId"].ToString();
                        role.IsAdmin = false;
                           // role.LastUpdatedBy = reader["UId"].ToString();
                        }
                        reader.Dispose();
                    }
                }
                catch (Exception exp)
                {

                    throw exp;
                }
                return role;
            }
            
        public static bool RemoveRole(string RoleId)
        {
           
            bool result = false;
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {


                

                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter( "@RoleId", RoleId),
                     

                };
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MemberShip.RemoveRole", param);



                }
            
               
            }
            catch (Exception exp)
            {
              
                throw exp;
            }
            return result;
        }
        #endregion

    }
}