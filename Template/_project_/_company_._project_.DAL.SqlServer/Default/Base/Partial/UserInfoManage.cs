using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class UserInfoManage : IUserInfoManage
    {
       public  UserInfo UserInfo_DataRowToModelExtend(DataRow row)
        {
            UserInfo model = new UserInfo();
            if (row != null)
            {
                if (row["UserID"] != null)
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
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
                    model.BranchName = row["BranchName"].ToString();
                }
                if (row["DepartmentID"] != null)
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                if (row["DepartmentName"] != null)
                {
                    model.DepartmentName = row["DepartmentName"].ToString();
                }
                if (row["EmployeeID"] != null)
                {
                    model.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                }
                if (row["uName"] != null)
                {
                    model.uName = row["uName"].ToString();
                }
                if (row["uPWD"] != null)
                {
                    model.uPWD = row["uPWD"].ToString();
                }
                if (row["uCode"] != null)
                {
                    model.uCode = row["uCode"].ToString();
                }
                if (row["uAppendTime"] != null)
                {
                    model.uAppendTime = DateTime.Parse(row["uAppendTime"].ToString());
                }
                if (row["uUpAppendTime"] != null)
                {
                    model.uUpAppendTime = DateTime.Parse(row["uUpAppendTime"].ToString());
                }
                if (row["uLastIP"] != null)
                {
                    model.uLastIP = row["uLastIP"].ToString();
                }
                if (row["uType"] != null)
                {
                    model.uType = int.Parse(row["uType"].ToString());
                }
                if (row["uState"] != null)
                {
                    model.uState = bool.Parse(row["uState"].ToString());
                }
                if (row["olTime"] != null)
                {
                    model.olTime = int.Parse(row["olTime"].ToString());
                }
            }
            return model;
        }
        
    }
}
