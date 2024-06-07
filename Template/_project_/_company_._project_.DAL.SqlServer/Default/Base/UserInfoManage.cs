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
        ///表链接
        private const string UserInfoConnectionName = "BaseDb";
        ///表名称
        private const string UserInfoTableName = "BaseUserInfo";
        ///表字段
        private const string UserInfoTableField = "UserID,SystemID,BranchID,DepartmentID,EmployeeID,uName,uPWD,uCode,uAppendTime,uUpAppendTime,uLastIP,uType,uState,olTime";
        //添加用表字段
        private const string UserInfoTableFieldForAdd = "SystemID,BranchID,DepartmentID,EmployeeID,uName,uPWD,uCode,uAppendTime,uUpAppendTime,uLastIP,uType,uState,olTime";
        //添加用表字段value
        private const string UserInfoTableFieldAltForAdd = "@SystemID,@BranchID,@DepartmentID,@EmployeeID,@uName,@uPWD,@uCode,@uAppendTime,@uUpAppendTime,@uLastIP,@uType,@uState,@olTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int UserInfo_Add(UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(UserInfoTableName);
			strSql.Append(" (");
            strSql.Append(UserInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(UserInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@EmployeeID", SqlDbType.Int,4),
 new SqlParameter("@uName", SqlDbType.VarChar,50),
 new SqlParameter("@uPWD", SqlDbType.Char,32),
 new SqlParameter("@uCode", SqlDbType.Char,32),
 new SqlParameter("@uAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@uUpAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@uLastIP", SqlDbType.VarChar,50),
 new SqlParameter("@uType", SqlDbType.Int,4),
 new SqlParameter("@uState", SqlDbType.Bit,1),
 new SqlParameter("@olTime", SqlDbType.Int,4)

					};
			 parameters[0].Value = model.SystemID;
 parameters[1].Value = model.BranchID;
 parameters[2].Value = model.DepartmentID;
 parameters[3].Value = model.EmployeeID;
 parameters[4].Value = model.uName;
 parameters[5].Value = model.uPWD;
 parameters[6].Value = model.uCode;
 parameters[7].Value = model.uAppendTime;
 parameters[8].Value = model.uUpAppendTime;
 parameters[9].Value = model.uLastIP;
 parameters[10].Value = model.uType;
 parameters[11].Value = model.uState;
 parameters[12].Value = model.olTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(UserInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool UserInfo_Update(UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(UserInfoTableName);
            strSql.Append(" set ");
			strSql.Append("SystemID=@SystemID,");
strSql.Append("BranchID=@BranchID,");
strSql.Append("DepartmentID=@DepartmentID,");
strSql.Append("EmployeeID=@EmployeeID,");
strSql.Append("uName=@uName,");
strSql.Append("uPWD=@uPWD,");
strSql.Append("uCode=@uCode,");
strSql.Append("uAppendTime=@uAppendTime,");
strSql.Append("uUpAppendTime=@uUpAppendTime,");
strSql.Append("uLastIP=@uLastIP,");
strSql.Append("uType=@uType,");
strSql.Append("uState=@uState,");
strSql.Append("olTime=@olTime");

            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
				 new SqlParameter("@UserID", SqlDbType.Int,4),
 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@EmployeeID", SqlDbType.Int,4),
 new SqlParameter("@uName", SqlDbType.VarChar,50),
 new SqlParameter("@uPWD", SqlDbType.Char,32),
 new SqlParameter("@uCode", SqlDbType.Char,32),
 new SqlParameter("@uAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@uUpAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@uLastIP", SqlDbType.VarChar,50),
 new SqlParameter("@uType", SqlDbType.Int,4),
 new SqlParameter("@uState", SqlDbType.Bit,1),
 new SqlParameter("@olTime", SqlDbType.Int,4)

			};
			 parameters[0].Value = model.UserID;
 parameters[1].Value = model.SystemID;
 parameters[2].Value = model.BranchID;
 parameters[3].Value = model.DepartmentID;
 parameters[4].Value = model.EmployeeID;
 parameters[5].Value = model.uName;
 parameters[6].Value = model.uPWD;
 parameters[7].Value = model.uCode;
 parameters[8].Value = model.uAppendTime;
 parameters[9].Value = model.uUpAppendTime;
 parameters[10].Value = model.uLastIP;
 parameters[11].Value = model.uType;
 parameters[12].Value = model.uState;
 parameters[13].Value = model.olTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(UserInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool UserInfo_Delete(Int32 userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(UserInfoTableName);
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int, 4)
			};
            parameters[0].Value = userID;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(UserInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool UserInfo_DeleteList(string userIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(UserInfoTableName);
            strSql.Append(" where UserID in (" + userIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(UserInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public UserInfo UserInfo_GetModel(Int32 userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(UserInfoTableField);
            strSql.Append(" from ");
            strSql.Append(UserInfoTableName);
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int, 4)
			};
            parameters[0].Value = userID;
            UserInfo model = new UserInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UserInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return UserInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfo UserInfo_DataRowToModel(DataRow row)
        {
            UserInfo model = new UserInfo();
            if (row != null)
            {
				if (row["UserID"] != null )
                {
                        model.UserID = int.Parse(row["UserID"].ToString());
                }
				if (row["SystemID"] != null )
                {
                        model.SystemID = int.Parse(row["SystemID"].ToString());
                }
				if (row["BranchID"] != null )
                {
                        model.BranchID = int.Parse(row["BranchID"].ToString());
                }
				if (row["DepartmentID"] != null )
                {
                        model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
				if (row["EmployeeID"] != null )
                {
                        model.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                }
				if (row["uName"] != null )
                {
					model.uName = row["uName"].ToString();
                }
				if (row["uPWD"] != null )
                {
					model.uPWD = row["uPWD"].ToString();
                }
				if (row["uCode"] != null )
                {
					model.uCode = row["uCode"].ToString();
                }
				if (row["uAppendTime"] != null )
                {
					model.uAppendTime = DateTime.Parse(row["uAppendTime"].ToString());
                }
				if (row["uUpAppendTime"] != null )
                {
					model.uUpAppendTime = DateTime.Parse(row["uUpAppendTime"].ToString());
                }
				if (row["uLastIP"] != null )
                {
					model.uLastIP = row["uLastIP"].ToString();
                }
				if (row["uType"] != null )
                {
                        model.uType = int.Parse(row["uType"].ToString());
                }
				if (row["uState"] != null )
                {
					model.uState = bool.Parse(row["uState"].ToString());
                }
				if (row["olTime"] != null )
                {
                        model.olTime = int.Parse(row["olTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet UserInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(UserInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(UserInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UserInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet UserInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(UserInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(UserInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UserInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int UserInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(UserInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(UserInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet UserInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(UserInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UserInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable UserInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "UserID")
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
            parameters[0].Value = "BaseUserInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UserInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
