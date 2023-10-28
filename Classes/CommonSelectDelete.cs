using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlHelpers;

namespace SaasBAL
{
    public class CommonSelectDelete
    {
        public DataTable CommonFill(string sp, string fieldname, string tablename, string orderbyFieldName, string mode)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@orderbyFieldName", orderbyFieldName);
            i++;
            param[i] = new SqlParameter("@mode", mode);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public int CommonDelete(string sp, string tablename, string setfieldname, string setvaluefieldname, string wherefieldname, int wherevaluesfieldname)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@TableName", tablename);
            i++;
            param[i] = new SqlParameter("@SetFieldName", setfieldname);
            i++;
            param[i] = new SqlParameter("@SetFieldValue", setvaluefieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldName", wherefieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldValue", wherevaluesfieldname);

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sp, param);
        }
        public DataTable CommonGridFill(string sp, string fieldname, string tablename, string orderbyfield)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@orderbyfieldname", orderbyfield);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataTable CommonFillCondition(string storeproc, string CFlag, string fieldname, string tablename, string columnname, string columnnameV)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@selecttype", CFlag);
            i++;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@columnname", columnname);
            i++;
            param[i] = new SqlParameter("@columnnameV", columnnameV);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, storeproc, param);
        }
        public DataTable CommonFillConditionGridPQ(string storeproc, string CFlag, string fieldname, string tablename, string columnname, string columnnameV, string orderby)
        {
            SqlParameter[] param = new SqlParameter[6];
            Int16 i = 0;
            param[i] = new SqlParameter("@selecttype", CFlag);
            i++;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@columnname", columnname);
            i++;
            param[i] = new SqlParameter("@columnnameV", columnnameV);
            i++;
            param[i] = new SqlParameter("@orderbyfieldname", orderby);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, storeproc, param);
        }
        public DataTable PriComMapping(string sp)
        {
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp);
        }
        public DataTable UserSearchResult(string SFirstName, string SLoginId, string SEmail)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;
            param[i] = new SqlParameter("@FirstName", SFirstName);
            i++;
            param[i] = new SqlParameter("@LoginId", SLoginId);
            i++;
            param[i] = new SqlParameter("@Email", SEmail);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "[dbo].[prc_acm_user_search]", param);
        }
        public DataTable ProductSearch(string proName, string ShortProName, string UOM, string Des)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@proName", proName);
            i++;
            param[i] = new SqlParameter("@ShortProName", ShortProName);
            i++;
            param[i] = new SqlParameter("@UOM", UOM);
            i++;
            param[i] = new SqlParameter("@Des", Des);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "[dbo].[prc_proSearch_Purchase]", param);
        }
        public DataTable Get_QUESTION_Master(string sp)
        {
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp);
        }
        public DataSet Get_Opin_Master(string sp)
        {
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp);
        }
        public DataTable Get_Common_Pro_Master(string sp)
        {
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp);
        }
        public DataTable Get_CatId(string sp, string mode, string cat_name)
        {
            SqlParameter[] param = new SqlParameter[2];
            Int16 i = 0;
            param[i] = new SqlParameter("@cat_name", cat_name);
            i++;
            param[i] = new SqlParameter("@mode", mode);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataTable GetQUESTION_Fill(string sp, int qid)
        {
            SqlParameter[] param = new SqlParameter[1];
            Int16 i = 0;
            param[i] = new SqlParameter("@QId", qid);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataTable Get_Suppier_Customer(string sup_cust)
        {
            SqlParameter[] param = new SqlParameter[2];
            Int16 i = 0;
            param[i] = new SqlParameter("@Sup_Cust", sup_cust);
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "prc_Supplier_Customer_Display_Common", param);
        }
        public DataTable Get_Suppier_Customer_Grid(string sp, string sup_cust)
        {
            SqlParameter[] param = new SqlParameter[2];
            Int16 i = 0;
            param[i] = new SqlParameter("@Sup_Cust", sup_cust);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataSet icTRGetAllTableValue(string sp, string paramName, int fieldname, string tenantPar, int tenantValue)
        {
            SqlParameter[] param = new SqlParameter[2];
            Int16 i = 0;
            param[i] = new SqlParameter(paramName,fieldname);
            i++;
            param[i] = new SqlParameter(tenantPar, tenantValue);

            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp, param);
        }
        public DataTable Get_categories()
        {
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "prc_Sales_Lead_Categories");
        }
        public DataTable Get_salespersons()
        {
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "prc_Sales_Lead_Salesperson");
        }
        public DataSet GetPQDetail(string sp, int pqid)
        {
            SqlParameter[] param = new SqlParameter[1];
            Int16 i = 0;
            param[i] = new SqlParameter("@PQ_Id", pqid);

            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp, param);
        }
        public int Upate_ICTR_HD(string sp, int MyTranType,int TenantID)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@MyTransId", MyTranType);
            i++;
            param[i] = new SqlParameter("@TenantId", TenantID);
            i++;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sp, param);
        }
        public DataTable RefTblSearchResult(string RefId, string RefType, string RefSubType, string ShortName, string RefName)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@RefId", RefId);
            i++;
            param[i] = new SqlParameter("@RefType", RefType);
            i++;
            param[i] = new SqlParameter("@RefSubType", RefSubType);
            i++;
            param[i] = new SqlParameter("@ShortName", ShortName);
            i++;
            param[i] = new SqlParameter("@RefName", RefName);
            i++;

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "[dbo].[prc_Reftbl_search]", param);
        }
        public int CommonDelete1(string sp, string tablename, string setfieldname, string setvaluefieldname, string wherefieldname, int wherevaluesfieldname, string wherefieldname1, string wherevaluesfieldname1, string wherefieldname2, int wherevaluesfieldname2, string wherefieldname3, int wherevaluesfieldname3)
        {
            SqlParameter[] param = new SqlParameter[11];
            Int16 i = 0;
            param[i] = new SqlParameter("@TableName", tablename);
            i++;
            param[i] = new SqlParameter("@SetFieldName", setfieldname);
            i++;
            param[i] = new SqlParameter("@SetFieldValue", setvaluefieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldName", wherefieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldValue", wherevaluesfieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldName1", wherefieldname1);
            i++;
            param[i] = new SqlParameter("@WhereFieldValue1", wherevaluesfieldname1);
            i++;
            param[i] = new SqlParameter("@WhereFieldName2", wherefieldname2);
            i++;
            param[i] = new SqlParameter("@WhereFieldValue2", wherevaluesfieldname2);
            i++;
            param[i] = new SqlParameter("@WhereFieldName3", wherefieldname3);
            i++;
            param[i] = new SqlParameter("@WhereFieldValue3", wherevaluesfieldname3);

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sp, param);
        }
        public DataTable CommonFillCondition1(string storeproc, string CFlag, string fieldname, string tablename, string columnname, string columnnameV, string columnname1, string columnnameV1, string columnname2, string columnnameV2, string columnname3, string columnnameV3)
        {
            SqlParameter[] param = new SqlParameter[11];
            Int16 i = 0;
            param[i] = new SqlParameter("@selecttype", CFlag);
            i++;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@columnname", columnname);
            i++;
            param[i] = new SqlParameter("@columnnameV", columnnameV);
            i++;
            param[i] = new SqlParameter("@columnname1", columnname1);
            i++;
            param[i] = new SqlParameter("@columnnameV1", columnnameV1);
            i++;
            param[i] = new SqlParameter("@columnname2", columnname2);
            i++;
            param[i] = new SqlParameter("@columnnameV2", columnnameV2);
            i++;
            param[i] = new SqlParameter("@columnname3", columnname3);
            i++;
            param[i] = new SqlParameter("@columnnameV3", columnnameV3);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, storeproc, param);
        }
        public int CommonDeletemode(string sp, string mode, int TENANT_ID, int MYPRODID)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;

            param[i] = new SqlParameter("@mode", mode);
            i++;
            param[i] = new SqlParameter("@TENANT_ID", TENANT_ID);
            i++;
            param[i] = new SqlParameter("@MYPRODID", MYPRODID);
            i++;
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sp, param);

        }
        public DataSet GetPrivilegeFill(string sp, int Tenantid, string logid, string pass, string sqlQuery, string mode)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@TENANT_ID", Tenantid);
            i++;
            param[i] = new SqlParameter("@LId", logid);
            i++;
            param[i] = new SqlParameter("@Password", pass);
            i++;
            param[i] = new SqlParameter("@sqlquery", sqlQuery);
            i++;
            param[i] = new SqlParameter("@mode", mode);


            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp, param);
        }
        public DataSet getOffWebBusPro(string sp, string mode, int TENANT_ID, int MYPRODID)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;

            param[i] = new SqlParameter("@mode", mode);
            i++;
            param[i] = new SqlParameter("@TENANT_ID", TENANT_ID);
            i++;
            param[i] = new SqlParameter("@MYPRODID", MYPRODID);
            i++;
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp, param);

        }
        public DataTable Get_Common_Pro_Master1(string CAT_TYPE, string mode, string sp)
        {
            SqlParameter[] param = new SqlParameter[2];
            Int16 i = 0;
            param[i] = new SqlParameter("@CAT_TYPE", CAT_TYPE);
            i++;
            param[i] = new SqlParameter("@mode", mode);
            i++;
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataTable CommonFillConditionGridInventry(string storeproc, string CFlag, string fieldname, string tablename, string columnname, string columnnameV, string orderby, string columnname2, string columnnameV2)
        {
            SqlParameter[] param = new SqlParameter[8];
            Int16 i = 0;
            param[i] = new SqlParameter("@selecttype", CFlag);
            i++;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@columnname", columnname);
            i++;
            param[i] = new SqlParameter("@columnnameV", columnnameV);
            i++;
            param[i] = new SqlParameter("@orderbyfieldname", orderby);
            i++;
            param[i] = new SqlParameter("@columnname2", columnname2);
            i++;
            param[i] = new SqlParameter("@columnnameV2", columnnameV2);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, storeproc, param);
        }
        public DataTable spCommonWithActiveTenantId(string sp, int qid)
        {
            SqlParameter[] param = new SqlParameter[1];
            Int16 i = 0;
            param[i] = new SqlParameter("@TenantID", qid);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public int CommonDeleteWithTenant(string sp, string TenantId, string tablename, string setfieldname, string setvaluefieldname, string wherefieldname, int wherevaluesfieldname, string mode)
        {
            SqlParameter[] param = new SqlParameter[7];
            Int16 i = 0;
            param[i] = new SqlParameter("@TenantId", TenantId);
            i++;
            param[i] = new SqlParameter("@TableName", tablename);
            i++;
            param[i] = new SqlParameter("@SetFieldName", setfieldname);
            i++;
            param[i] = new SqlParameter("@SetFieldValue", setvaluefieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldName", wherefieldname);
            i++;
            param[i] = new SqlParameter("@WhereFieldValue", wherevaluesfieldname);
            i++;
            param[i] = new SqlParameter("@mode", mode);

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sp, param);
        }
        public DataTable CommonMethodOderFnmTnmObTenant(string sp, string fieldname, string tablename, string orderbyfield, int TenantId)
        {
            SqlParameter[] param = new SqlParameter[4];
            Int16 i = 0;
            param[i] = new SqlParameter("@TenantId", TenantId);
            i++;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@orderbyfieldname", orderbyfield);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataTable CommonMethodOderFnmTnmObTenantMode(string sp, string fieldname, string tablename, string orderbyfield, int TenantId,string mode)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@TenantId", TenantId);
            i++;
            param[i] = new SqlParameter("@fieldname", fieldname);
            i++;
            param[i] = new SqlParameter("@tablename", tablename);
            i++;
            param[i] = new SqlParameter("@orderbyfieldname", orderbyfield);
            i++;
            param[i] = new SqlParameter("@mode", mode);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataSet icTRGetAllTableValueMode(string sp, string paramName, int fieldname, string tenantPar, int tenantValue, string mode)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;
            param[i] = new SqlParameter("@mode", mode);
            i++;
            param[i] = new SqlParameter(paramName, fieldname);
            i++;
            param[i] = new SqlParameter(tenantPar, tenantValue);

            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp, param);
        }
        public DataSet icTRGetAllTableValueModewithTransNo(string sp, string paramName, int fieldname, string tenantPar, int tenantValue, int transNo, string mode)
        {
            SqlParameter[] param = new SqlParameter[5];
            Int16 i = 0;
            param[i] = new SqlParameter("@mode", mode);
            i++;
            param[i] = new SqlParameter(paramName, fieldname);
            i++;
            param[i] = new SqlParameter(tenantPar, tenantValue);
            i++;
            param[i] = new SqlParameter("@TransNo", transNo);

            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, sp, param);
        }
        
       

        public static DataTable checkQty(string sp, string Query1, string mode)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;
            param[i] = new SqlParameter("@selecttype", mode);
            i++;
            param[i] = new SqlParameter("@Sqlqty", Query1);

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp, param);
        }
        public DataTable Get_Suppier_Customer_Grid1(string sp)
        {
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, sp);
        }
        public DataTable GetMenuByPriMod(int Privilege, int Module)
        {
            SqlParameter[] param = new SqlParameter[3];
            Int16 i = 0;
            param[i] = new SqlParameter("@privilege", Privilege);
            i++;
            param[i] = new SqlParameter("@module", Module);
            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "prc_GetMenuPriMod", param);
        }
    }
}
