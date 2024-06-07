using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class JobPositionInfoManage : IJobPositionInfoManage
    {
        ///表链接
        private const string JobPositionInfoConnectionName = "BaseDb";
        ///表名称
        private const string JobPositionInfoTableName = "BaseJobPositionInfo";
        ///表字段
        private const string JobPositionInfoTableField = "JobPositionID,SystemID,BranchID,BranchName,DepartmentID,DepartmentName,JPItemID,JPName,JPPermissions,JobLevel,JPRemark,JState,JPAppendTime,JPUpdateTime";
        //添加用表字段
        private const string JobPositionInfoTableFieldForAdd = "SystemID,BranchID,BranchName,DepartmentID,DepartmentName,JPItemID,JPName,JPPermissions,JobLevel,JPRemark,JState,JPAppendTime,JPUpdateTime";
        //添加用表字段value
        private const string JobPositionInfoTableFieldAltForAdd = "@SystemID,@BranchID,@BranchName,@DepartmentID,@DepartmentName,@JPItemID,@JPName,@JPPermissions,@JobLevel,@JPRemark,@JState,@JPAppendTime,@JPUpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int JobPositionInfo_Add(JobPositionInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(JobPositionInfoTableName);
			strSql.Append(" (");
            strSql.Append(JobPositionInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(JobPositionInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@BranchName", SqlDbType.VarChar,50),
 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@DepartmentName", SqlDbType.VarChar,50),
 new SqlParameter("@JPItemID", SqlDbType.VarChar,50),
 new SqlParameter("@JPName", SqlDbType.VarChar,50),
 new SqlParameter("@JPPermissions", SqlDbType.NText,2147483646),
 new SqlParameter("@JobLevel", SqlDbType.Int,4),
 new SqlParameter("@JPRemark", SqlDbType.VarChar,256),
 new SqlParameter("@JState", SqlDbType.Bit,1),
 new SqlParameter("@JPAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@JPUpdateTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.SystemID;
 parameters[1].Value = model.BranchID;
 parameters[2].Value = model.BranchName;
 parameters[3].Value = model.DepartmentID;
 parameters[4].Value = model.DepartmentName;
 parameters[5].Value = model.JPItemID;
 parameters[6].Value = model.JPName;
 parameters[7].Value = model.JPPermissions;
 parameters[8].Value = model.JobLevel;
 parameters[9].Value = model.JPRemark;
 parameters[10].Value = model.JState;
 parameters[11].Value = model.JPAppendTime;
 parameters[12].Value = model.JPUpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(JobPositionInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool JobPositionInfo_Update(JobPositionInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(JobPositionInfoTableName);
            strSql.Append(" set ");
			strSql.Append("SystemID=@SystemID,");
strSql.Append("BranchID=@BranchID,");
strSql.Append("BranchName=@BranchName,");
strSql.Append("DepartmentID=@DepartmentID,");
strSql.Append("DepartmentName=@DepartmentName,");
strSql.Append("JPItemID=@JPItemID,");
strSql.Append("JPName=@JPName,");
strSql.Append("JPPermissions=@JPPermissions,");
strSql.Append("JobLevel=@JobLevel,");
strSql.Append("JPRemark=@JPRemark,");
strSql.Append("JState=@JState,");
strSql.Append("JPAppendTime=@JPAppendTime,");
strSql.Append("JPUpdateTime=@JPUpdateTime");

            strSql.Append(" where JobPositionID=@JobPositionID");
            SqlParameter[] parameters = {
				 new SqlParameter("@JobPositionID", SqlDbType.Int,4),
 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@BranchName", SqlDbType.VarChar,50),
 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@DepartmentName", SqlDbType.VarChar,50),
 new SqlParameter("@JPItemID", SqlDbType.VarChar,50),
 new SqlParameter("@JPName", SqlDbType.VarChar,50),
 new SqlParameter("@JPPermissions", SqlDbType.NText,2147483646),
 new SqlParameter("@JobLevel", SqlDbType.Int,4),
 new SqlParameter("@JPRemark", SqlDbType.VarChar,256),
 new SqlParameter("@JState", SqlDbType.Bit,1),
 new SqlParameter("@JPAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@JPUpdateTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.JobPositionID;
 parameters[1].Value = model.SystemID;
 parameters[2].Value = model.BranchID;
 parameters[3].Value = model.BranchName;
 parameters[4].Value = model.DepartmentID;
 parameters[5].Value = model.DepartmentName;
 parameters[6].Value = model.JPItemID;
 parameters[7].Value = model.JPName;
 parameters[8].Value = model.JPPermissions;
 parameters[9].Value = model.JobLevel;
 parameters[10].Value = model.JPRemark;
 parameters[11].Value = model.JState;
 parameters[12].Value = model.JPAppendTime;
 parameters[13].Value = model.JPUpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(JobPositionInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool JobPositionInfo_Delete(Int32 jobPositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(JobPositionInfoTableName);
            strSql.Append(" where JobPositionID=@JobPositionID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int, 4)
			};
            parameters[0].Value = jobPositionID;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(JobPositionInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool JobPositionInfo_DeleteList(string jobPositionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(JobPositionInfoTableName);
            strSql.Append(" where JobPositionID in (" + jobPositionIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(JobPositionInfoConnectionName), CommandType.Text,strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JobPositionInfo JobPositionInfo_GetModel(Int32 jobPositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(JobPositionInfoTableField);
            strSql.Append(" from ");
            strSql.Append(JobPositionInfoTableName);
            strSql.Append(" where JobPositionID=@JobPositionID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int, 4)
			};
            parameters[0].Value = jobPositionID;
            JobPositionInfo model = new JobPositionInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(JobPositionInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return JobPositionInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JobPositionInfo JobPositionInfo_DataRowToModel(DataRow row)
        {
            JobPositionInfo model = new JobPositionInfo();
            if (row != null)
            {
				if (row["JobPositionID"] != null )
                {
                        model.JobPositionID = int.Parse(row["JobPositionID"].ToString());
                }
				if (row["SystemID"] != null )
                {
                        model.SystemID = int.Parse(row["SystemID"].ToString());
                }
				if (row["BranchID"] != null )
                {
                        model.BranchID = int.Parse(row["BranchID"].ToString());
                }
				if (row["BranchName"] != null )
                {
					model.BranchName = row["BranchName"].ToString();
                }
				if (row["DepartmentID"] != null )
                {
                        model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
				if (row["DepartmentName"] != null )
                {
					model.DepartmentName = row["DepartmentName"].ToString();
                }
				if (row["JPItemID"] != null )
                {
					model.JPItemID = row["JPItemID"].ToString();
                }
				if (row["JPName"] != null )
                {
					model.JPName = row["JPName"].ToString();
                }
				if (row["JPPermissions"] != null )
                {
					model.JPPermissions = row["JPPermissions"].ToString();
                }
				if (row["JobLevel"] != null )
                {
                        model.JobLevel = int.Parse(row["JobLevel"].ToString());
                }
				if (row["JPRemark"] != null )
                {
					model.JPRemark = row["JPRemark"].ToString();
                }
				if (row["JState"] != null )
                {
					model.JState = bool.Parse(row["JState"].ToString());
                }
				if (row["JPAppendTime"] != null )
                {
					model.JPAppendTime = DateTime.Parse(row["JPAppendTime"].ToString());
                }
				if (row["JPUpdateTime"] != null )
                {
					model.JPUpdateTime = DateTime.Parse(row["JPUpdateTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet JobPositionInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(JobPositionInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(JobPositionInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(JobPositionInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet JobPositionInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(JobPositionInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(JobPositionInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(JobPositionInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int JobPositionInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(JobPositionInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(JobPositionInfoConnectionName),CommandType.Text,strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet JobPositionInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                strSql.Append("order by T." + orderBy);
            }
            else
            {
                strSql.Append("order by T.DicID desc");
            }
            strSql.Append(")AS Row, T.*  from ");
            strSql.Append(JobPositionInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(JobPositionInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">页标</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pagetotal">总页数</param>
        /// <param name="total">总数</param>
        /// <param name="orderType">排序规则， 默认降序，1降序，0升序</param>
        /// <param name="showName">显示字段，默认全部</param>
        /// <param name="orderKey">排序key，默认主键</param>
        public DataTable JobPositionInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "JobPositionID")
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "BaseJobPositionInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(JobPositionInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
            total = 0;
            if (ds.Tables.Count > 1)
            {
                total = (int)ds.Tables[0].Rows[0][0];
                if (total % pageSize == 0)
                {
                    pagetotal = total / pageSize;
                }
                else
                {
                    pagetotal = total / pageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
	}
}
