using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class LogTypeClassManage : ILogTypeClassManage
    {
        ///表链接
        private const string LogTypeClassConnectionName = "LogBaseDb";
        ///表名称
        private const string LogTypeClassTableName = "LogTypeClass";
        ///表字段
        private const string LogTypeClassTableField = "Id,ClassName,ClassRemarks,ParentId,RootId,CreateTime,UpdateTime";
        //添加用表字段
        private const string LogTypeClassTableFieldForAdd = "ClassName,ClassRemarks,ParentId,RootId,CreateTime,UpdateTime";
        //添加用表字段value
        private const string LogTypeClassTableFieldAltForAdd = "@ClassName,@ClassRemarks,@ParentId,@RootId,@CreateTime,@UpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int LogTypeClass_Add(LogTypeClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(LogTypeClassTableName);
			strSql.Append(" (");
            strSql.Append(LogTypeClassTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(LogTypeClassTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@ClassName", SqlDbType.NVarChar,100),
 new SqlParameter("@ClassRemarks", SqlDbType.NVarChar,510),
 new SqlParameter("@ParentId", SqlDbType.Int,4),
 new SqlParameter("@RootId", SqlDbType.Int,4),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.ClassName;
 parameters[1].Value = model.ClassRemarks;
 parameters[2].Value = model.ParentId;
 parameters[3].Value = model.RootId;
 parameters[4].Value = model.CreateTime;
 parameters[5].Value = model.UpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(LogTypeClassConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogTypeClass_Update(LogTypeClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(LogTypeClassTableName);
            strSql.Append(" set ");
			strSql.Append("ClassName=@ClassName,");
strSql.Append("ClassRemarks=@ClassRemarks,");
strSql.Append("ParentId=@ParentId,");
strSql.Append("RootId=@RootId,");
strSql.Append("CreateTime=@CreateTime,");
strSql.Append("UpdateTime=@UpdateTime");

            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
				 new SqlParameter("@Id", SqlDbType.Int,4),
 new SqlParameter("@ClassName", SqlDbType.NVarChar,100),
 new SqlParameter("@ClassRemarks", SqlDbType.NVarChar,510),
 new SqlParameter("@ParentId", SqlDbType.Int,4),
 new SqlParameter("@RootId", SqlDbType.Int,4),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.Id;
 parameters[1].Value = model.ClassName;
 parameters[2].Value = model.ClassRemarks;
 parameters[3].Value = model.ParentId;
 parameters[4].Value = model.RootId;
 parameters[5].Value = model.CreateTime;
 parameters[6].Value = model.UpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogTypeClassConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogTypeClass_Delete(Int32 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogTypeClassTableName);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int, 4)
			};
            parameters[0].Value = id;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogTypeClassConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogTypeClass_DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogTypeClassTableName);
            strSql.Append(" where Id in (" + idlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogTypeClassConnectionName), CommandType.Text,strSql.ToString());
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
        public LogTypeClass LogTypeClass_GetModel(Int32 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(LogTypeClassTableField);
            strSql.Append(" from ");
            strSql.Append(LogTypeClassTableName);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int, 4)
			};
            parameters[0].Value = id;
            LogTypeClass model = new LogTypeClass();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeClassConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return LogTypeClass_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LogTypeClass LogTypeClass_DataRowToModel(DataRow row)
        {
            LogTypeClass model = new LogTypeClass();
            if (row != null)
            {
				if (row["Id"] != null )
                {
                        model.Id = int.Parse(row["Id"].ToString());
                }
				if (row["ClassName"] != null )
                {
					model.ClassName = row["ClassName"].ToString();
                }
				if (row["ClassRemarks"] != null )
                {
					model.ClassRemarks = row["ClassRemarks"].ToString();
                }
				if (row["ParentId"] != null )
                {
                        model.ParentId = int.Parse(row["ParentId"].ToString());
                }
				if (row["RootId"] != null )
                {
                        model.RootId = int.Parse(row["RootId"].ToString());
                }
				if (row["CreateTime"] != null )
                {
					model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
				if (row["UpdateTime"] != null )
                {
					model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet LogTypeClass_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(LogTypeClassTableField);
            strSql.Append(" FROM ");
            strSql.Append(LogTypeClassTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeClassConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet LogTypeClass_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(LogTypeClassTableField);
            strSql.Append(" FROM ");
            strSql.Append(LogTypeClassTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeClassConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int LogTypeClass_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(LogTypeClassTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(LogTypeClassConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet LogTypeClass_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(LogTypeClassTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeClassConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable LogTypeClass_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "Id")
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
            parameters[0].Value = "LogTypeClass";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeClassConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
