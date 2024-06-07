using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class PermissionInfoManage : IPermissionInfoManage
    {
        public PermissionInfo PermissionInfo_GetModelByPermissionValue(string permissionValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select  top 1 {PermissionInfoTableField} from {PermissionInfoTableName}");
            strSql.Append(" where PermissionValue=@PermissionValue");
            SqlParameter[] parameters = {
                new SqlParameter("@PermissionValue", SqlDbType.VarChar,4000)
            };
            parameters[0].Value = permissionValue;

            PermissionInfo model = new PermissionInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(PermissionInfoConnectionName), CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return PermissionInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public PermissionInfo[] PermissionInfo_GetModelByPermissionIdStr(string permissionIdStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select {PermissionInfoTableField} from {PermissionInfoTableName}");
            strSql.Append(" where PermissionID in ( " + permissionIdStr + ");");

            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(PermissionInfoConnectionName), CommandType.Text, strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                PermissionInfo[] model = new PermissionInfo[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model[i] = new PermissionInfo();
                    model[i] = PermissionInfo_DataRowToModel(ds.Tables[0].Rows[i]);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
