using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class ClsDepartments
    {
        #region[Private Members]
        private string _DepartmentId;
        private string _DepartmentName;
        #endregion
        #region[Public Properties]
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }
        public string DepartmentId
        {
            get { return _DepartmentId; }
            set { _DepartmentId = value; }
        }
        #endregion
        #region[Constructor]
        public ClsDepartments()
        {
            //
            // TODO: Add constructor logic here
            //
            DepartmentId = "-1";
            DepartmentName = "";
        }
        #endregion
        #region[Public Static Methods]
        public static List<ClsDepartments> GetAllDepartments()
        {
            List<ClsDepartments> DeptList = new List<ClsDepartments>();
            
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {

                    DataSet ds = SqlHelper.ExecuteDataset(con,CommandType.Text,"select NodeID,PageTitle,MenuOrder from  MemberShip.TreeNode where IsParent=1 AND MenuType=0 and IsvisibleInMenu=1 Order by MenuOrder");
                    if (ds != null && ds.Tables.Count > 0)
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            ClsDepartments dept = new ClsDepartments();
                            dept.DepartmentId = r["NodeID"].ToString();
                            dept.DepartmentName = r["PageTitle"].ToString();
                            DeptList.Add(dept);
                        }
                }
              
            }
            catch (Exception exp)
            {
                
                throw exp;
            }
            return DeptList;
        }

        public static List<ClsDepartments> GetAllDepartmentsadmin()
        {
            List<ClsDepartments> DeptList = new List<ClsDepartments>();

            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {

                    DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select NodeID,PageTitle,MenuOrder from  MemberShip.TreeNode where IsParent=1 AND MenuType=0  Order by MenuOrder");
                    if (ds != null && ds.Tables.Count > 0)
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            ClsDepartments dept = new ClsDepartments();
                            dept.DepartmentId = r["NodeID"].ToString();
                            dept.DepartmentName = r["PageTitle"].ToString();
                            DeptList.Add(dept);
                        }
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }
            return DeptList;
        }
        #endregion
    }
}