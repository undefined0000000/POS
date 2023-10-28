using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Configuration;
using System.Data.SqlClient;
namespace Classes
{

    public static class ACMDelete
    {
        public static void DeleteData(string TableName, string FieldName, string AssignValue, string WhereUpdateField1, int WhValue1)
        {

            string Query = "UPDATE" + TableName + "SET" + FieldName + "=" + AssignValue + "WHERE" + WhereUpdateField1 + "=" + WhValue1;
            SqlExecute(Query);
        }
        public static void DeleteData(string TableName, string FieldName, string AssignValue, string WhereUpdateField1, int WhValue1, string WhereUpdateField2, int WhValue2)
        {

            string Query = "UPDATE" + TableName + "SET" + FieldName + "=" + AssignValue + "WHERE" + WhereUpdateField1 + "=" + WhValue1 + "AND" + WhereUpdateField2 + "=" + WhValue2;
            SqlExecute(Query);
        }
        public static void DeleteData(string TableName, string FieldName, string AssignValue, string WhereUpdateField1, int WhValue1, string WhereUpdateField2, int WhValue2, string WhereUpdateField3, int WhValue3)
        {

            string Query = "UPDATE" + TableName + "SET" + FieldName + "=" + AssignValue + "WHERE" + WhereUpdateField1 + "=" + WhValue1 + "AND" + WhereUpdateField2 + "=" + WhValue2 + "AND" + WhereUpdateField3 + "=" + WhValue3;
            SqlExecute(Query);
        }
        public static void DeleteData(string TableName, string FieldName, string AssignValue, string WhereUpdateField1, int WhValue1, string WhereUpdateField2, int WhValue2, string WhereUpdateField3, int WhValue3, string WhereUpdateField4, int WhValue4)
        {

            string Query = "UPDATE" + TableName + "SET" + FieldName + "=" + AssignValue + "WHERE" + WhereUpdateField1 + "=" + WhValue1 + "AND" + WhereUpdateField2 + "=" + WhValue2 + "AND" + WhereUpdateField3 + "=" + WhValue3 + "AND" + WhereUpdateField4 + "=" + WhValue4;
            SqlExecute(Query);
        }
        public static void SqlExecute(string sql)
        {
            string cs = ConfigurationManager.ConnectionStrings["CallEntities"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
