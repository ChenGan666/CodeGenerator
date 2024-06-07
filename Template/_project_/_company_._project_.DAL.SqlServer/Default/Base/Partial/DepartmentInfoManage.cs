using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class DepartmentInfoManage : IDepartmentInfoManage
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DepartmentInfo DepartmentInfo_DataRowToModelExtend(DataRow row)
        {
            DepartmentInfo model = new DepartmentInfo();
            if (row != null)
            {
                if (row["DepartmentID"] != null)
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                
                if (row["SystemID"] != null)
                {
                    model.SystemID = int.Parse(row["SystemID"].ToString());
                }
                if (row["BranchID"] != null)
                {
                    model.BranchID = int.Parse(row["BranchID"].ToString());
                }
                if (row["BranchName"] != null)
                {
                    model.BranchName =  row["BranchName"].ToString();
                }
                if (row["dItemID"] != null)
                {
                    model.dItemID = row["dItemID"].ToString();
                }
                if (row["dName"] != null)
                {
                    model.dName = row["dName"].ToString();
                }
                if (row["dDirector"] != null)
                {
                    model.dDirector = row["dDirector"].ToString();
                }
                if (row["dNote"] != null)
                {
                    model.dNote = row["dNote"].ToString();
                }
                if (row["dState"] != null)
                {
                    model.dState = bool.Parse(row["dState"].ToString());
                }
                if (row["dAppendTime"] != null)
                {
                    model.dAppendTime = DateTime.Parse(row["dAppendTime"].ToString());
                }
            }
            return model;
        }
    }
}
