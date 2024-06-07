using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class EmployeeInfoManage : IEmployeeInfoManage
    {
        public EmployeeInfo EmployeeInfo_GetModelExtend(int EmployeeID)
        {
            
       
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 eName,EmployeeID,(select JobLevel from BaseJobPositionInfo  as  jpi where jpi.JobPositionID=BaseEmployeeInfo.JobPositionID)  as JobLevel,SystemID,IsManager,BranchID,JobPositionID,IsCheckManager,JPName,eItemID,eSex,eMarry,eBirthday,DepartmentID,(select JPPermissions from BaseJobPositionInfo  as  jpi where jpi.JobPositionID=BaseEmployeeInfo.JobPositionID) as JPPermissions,IsSelf,eEntry,eEmail,eTel,eMob,eQQ,ePhotoImage,eState,eAppendTime,(select bName from BaseBranchInfo where BranchID=BaseEmployeeInfo.BranchID) as BranchName,(select dName from BaseDepartmentInfo where DepartmentID=BaseEmployeeInfo.DepartmentID) as DepartmentName,UserID,isnull((select uName from BaseUserInfo as ui where ui.UserID=BaseEmployeeInfo.UserID),'') as UserName from BaseEmployeeInfo ");
            strSql.Append(" where EmployeeID=@EmployeeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@EmployeeID", SqlDbType.Int,4)
            };
            parameters[0].Value = EmployeeID;
            EmployeeInfo model = new EmployeeInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(EmployeeInfoConnectionName), CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return EmployeeInfo_DataRowToModelExtend(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmployeeInfo EmployeeInfo_DataRowToModelExtend(DataRow row)
        {
            EmployeeInfo model = new EmployeeInfo();
            if (row != null)
            {
                if (row["EmployeeID"] != null && row["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                }
                if (row["SystemID"] != null && row["SystemID"].ToString() != "")
                {
                    model.SystemID = int.Parse(row["SystemID"].ToString());
                }
                if (row["IsManager"] != null && row["IsManager"].ToString() != "")
                {
                    if ((row["IsManager"].ToString() == "1") || (row["IsManager"].ToString().ToLower() == "true"))
                    {
                        model.IsManager = true;
                    }
                    else
                    {
                        model.IsManager = false;
                    }

                }
                if (row["IsCheckManager"] != null && row["IsCheckManager"].ToString() != "")
                {
                    if ((row["IsCheckManager"].ToString() == "1") || (row["IsCheckManager"].ToString().ToLower() == "true"))
                    {
                        model.IsCheckManager = true;
                    }
                    else
                    {
                        model.IsCheckManager = false;
                    }

                }
                if (row["JobLevel"] != null && row["JobLevel"].ToString() != "")
                {
                    model.JobLevel = int.Parse(row["JobLevel"].ToString());
                }

                if (row["BranchID"] != null && row["BranchID"].ToString() != "")
                {
                    model.BranchID = int.Parse(row["BranchID"].ToString());
                }
                if (row["BranchName"] != null)
                {
                    model.BranchName = row["BranchName"].ToString();
                }
                if (row["DepartmentName"] != null)
                {
                    model.DepartmentName = row["DepartmentName"].ToString();
                }
                if (row["eName"] != null)
                {
                    model.eName = row["eName"].ToString();
                }
                if (row["eItemID"] != null)
                {
                    model.eItemID = row["eItemID"].ToString();
                }
                if (row["eSex"] != null)
                {
                    model.eSex = row["eSex"].ToString();
                }
                if (row["eMarry"] != null)
                {
                    model.eMarry = row["eMarry"].ToString();
                }
                if (row["eBirthday"] != null)
                {
                    model.eBirthday = row["eBirthday"].ToString();
                }
                if (row["DepartmentID"] != null && row["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                if (row["JobPositionID"] != null && row["JobPositionID"].ToString() != "")
                {
                    model.JobPositionID = int.Parse(row["JobPositionID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }

                if (row["JPName"] != null)
                {
                    model.JPName = row["JPName"].ToString();
                }
                if (row["JPPermissions"] != null)
                {
                    model.JPPermissions = row["JPPermissions"].ToString();
                }

                if (row["IsSelf"] != null && row["IsSelf"].ToString() != "")
                {
                    if ((row["IsSelf"].ToString() == "1") || (row["IsSelf"].ToString().ToLower() == "true"))
                    {
                        model.IsSelf = true;
                    }
                    else
                    {
                        model.IsSelf = false;
                    }

                }
                if (row["eEntry"] != null)
                {
                    model.eEntry = row["eEntry"].ToString();
                }
                if (row["eEmail"] != null)
                {
                    model.eEmail = row["eEmail"].ToString();
                }
                if (row["eTel"] != null)
                {
                    model.eTel = row["eTel"].ToString();
                }
                if (row["eMob"] != null)
                {
                    model.eMob = row["eMob"].ToString();
                }
                if (row["eQQ"] != null)
                {
                    model.eQQ = row["eQQ"].ToString();
                }
                if (row["ePhotoImage"] != null && row["ePhotoImage"].ToString() != "")
                {
                    model.ePhotoImage = (byte[])row["ePhotoImage"];
                }
                if (row["eState"] != null && row["eState"].ToString() != "")
                {
                    if ((row["eState"].ToString() == "1") || (row["eState"].ToString().ToLower() == "true"))
                    {
                        model.eState = true;
                    }
                    else
                    {
                        model.eState = false;
                    }
                }
                if (row["eAppendTime"] != null && row["eAppendTime"].ToString() != "")
                {
                    model.eAppendTime = DateTime.Parse(row["eAppendTime"].ToString());
                }
            }
            return model;
        }
    }
}
