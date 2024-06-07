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
        ///表链接
        private const string DepartmentInfoConnectionName = "BaseDb";
        ///表名称
        private const string DepartmentInfoTableName = "BaseDepartmentInfo";
        ///表字段
        private const string DepartmentInfoTableField = "DepartmentID,SystemID,BranchID,dItemID,dName,dDirector,dNote,dState,dAppendTime";
        //添加用表字段
        private const string DepartmentInfoTableFieldForAdd = "SystemID,BranchID,dItemID,dName,dDirector,dNote,dState,dAppendTime";
        //添加用表字段value
        private const string DepartmentInfoTableFieldAltForAdd = "@SystemID,@BranchID,@dItemID,@dName,@dDirector,@dNote,@dState,@dAppendTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int DepartmentInfo_Add(DepartmentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(DepartmentInfoTableName);
			strSql.Append(" (");
            strSql.Append(DepartmentInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(DepartmentInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@dItemID", SqlDbType.VarChar,50),
 new SqlParameter("@dName", SqlDbType.VarChar,50),
 new SqlParameter("@dDirector", SqlDbType.VarChar,50),
 new SqlParameter("@dNote", SqlDbType.VarChar,128),
 new SqlParameter("@dState", SqlDbType.Bit,1),
 new SqlParameter("@dAppendTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.SystemID;
 parameters[1].Value = model.BranchID;
 parameters[2].Value = model.dItemID;
 parameters[3].Value = model.dName;
 parameters[4].Value = model.dDirector;
 parameters[5].Value = model.dNote;
 parameters[6].Value = model.dState;
 parameters[7].Value = model.dAppendTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(DepartmentInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool DepartmentInfo_Update(DepartmentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(DepartmentInfoTableName);
            strSql.Append(" set ");
			strSql.Append("SystemID=@SystemID,");
strSql.Append("BranchID=@BranchID,");
strSql.Append("dItemID=@dItemID,");
strSql.Append("dName=@dName,");
strSql.Append("dDirector=@dDirector,");
strSql.Append("dNote=@dNote,");
strSql.Append("dState=@dState,");
strSql.Append("dAppendTime=@dAppendTime");

            strSql.Append(" where DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
				 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@dItemID", SqlDbType.VarChar,50),
 new SqlParameter("@dName", SqlDbType.VarChar,50),
 new SqlParameter("@dDirector", SqlDbType.VarChar,50),
 new SqlParameter("@dNote", SqlDbType.VarChar,128),
 new SqlParameter("@dState", SqlDbType.Bit,1),
 new SqlParameter("@dAppendTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.DepartmentID;
 parameters[1].Value = model.SystemID;
 parameters[2].Value = model.BranchID;
 parameters[3].Value = model.dItemID;
 parameters[4].Value = model.dName;
 parameters[5].Value = model.dDirector;
 parameters[6].Value = model.dNote;
 parameters[7].Value = model.dState;
 parameters[8].Value = model.dAppendTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(DepartmentInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool DepartmentInfo_Delete(Int32 departmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(DepartmentInfoTableName);
            strSql.Append(" where DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int, 4)
			};
            parameters[0].Value = departmentID;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(DepartmentInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool DepartmentInfo_DeleteList(string departmentIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(DepartmentInfoTableName);
            strSql.Append(" where DepartmentID in (" + departmentIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(DepartmentInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public DepartmentInfo DepartmentInfo_GetModel(Int32 departmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(DepartmentInfoTableField);
            strSql.Append(" from ");
            strSql.Append(DepartmentInfoTableName);
            strSql.Append(" where DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int, 4)
			};
            parameters[0].Value = departmentID;
            DepartmentInfo model = new DepartmentInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DepartmentInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DepartmentInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DepartmentInfo DepartmentInfo_DataRowToModel(DataRow row)
        {
            DepartmentInfo model = new DepartmentInfo();
            if (row != null)
            {
				if (row["DepartmentID"] != null )
                {
                        model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
				if (row["SystemID"] != null )
                {
                        model.SystemID = int.Parse(row["SystemID"].ToString());
                }
				if (row["BranchID"] != null )
                {
                        model.BranchID = int.Parse(row["BranchID"].ToString());
                }
				if (row["dItemID"] != null )
                {
					model.dItemID = row["dItemID"].ToString();
                }
				if (row["dName"] != null )
                {
					model.dName = row["dName"].ToString();
                }
				if (row["dDirector"] != null )
                {
					model.dDirector = row["dDirector"].ToString();
                }
				if (row["dNote"] != null )
                {
					model.dNote = row["dNote"].ToString();
                }
				if (row["dState"] != null )
                {
					model.dState = bool.Parse(row["dState"].ToString());
                }
				if (row["dAppendTime"] != null )
                {
					model.dAppendTime = DateTime.Parse(row["dAppendTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet DepartmentInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(DepartmentInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(DepartmentInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DepartmentInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet DepartmentInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(DepartmentInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(DepartmentInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DepartmentInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int DepartmentInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(DepartmentInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(DepartmentInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet DepartmentInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(DepartmentInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DepartmentInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable DepartmentInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "DepartmentID")
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
            parameters[0].Value = "BaseDepartmentInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DepartmentInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
