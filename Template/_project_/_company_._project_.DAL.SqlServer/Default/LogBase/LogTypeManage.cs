using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class LogTypeManage : ILogTypeManage
    {
        ///表链接
        private const string LogTypeConnectionName = "LogBaseDb";
        ///表名称
        private const string LogTypeTableName = "LogType";
        ///表字段
        private const string LogTypeTableField = "Id,TypeName,TypeRemarks,ClassId,LevelId,Status,CreateTime,UpdateTime";
        //添加用表字段
        private const string LogTypeTableFieldForAdd = "TypeName,TypeRemarks,ClassId,LevelId,Status,CreateTime,UpdateTime";
        //添加用表字段value
        private const string LogTypeTableFieldAltForAdd = "@TypeName,@TypeRemarks,@ClassId,@LevelId,@Status,@CreateTime,@UpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int LogType_Add(LogType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(LogTypeTableName);
			strSql.Append(" (");
            strSql.Append(LogTypeTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(LogTypeTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@TypeName", SqlDbType.NVarChar,100),
 new SqlParameter("@TypeRemarks", SqlDbType.NVarChar,510),
 new SqlParameter("@ClassId", SqlDbType.Int,4),
 new SqlParameter("@LevelId", SqlDbType.Int,4),
 new SqlParameter("@Status", SqlDbType.Bit,1),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.TypeName;
 parameters[1].Value = model.TypeRemarks;
 parameters[2].Value = model.ClassId;
 parameters[3].Value = model.LevelId;
 parameters[4].Value = model.Status;
 parameters[5].Value = model.CreateTime;
 parameters[6].Value = model.UpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(LogTypeConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogType_Update(LogType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(LogTypeTableName);
            strSql.Append(" set ");
			strSql.Append("TypeName=@TypeName,");
strSql.Append("TypeRemarks=@TypeRemarks,");
strSql.Append("ClassId=@ClassId,");
strSql.Append("LevelId=@LevelId,");
strSql.Append("Status=@Status,");
strSql.Append("CreateTime=@CreateTime,");
strSql.Append("UpdateTime=@UpdateTime");

            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
				 new SqlParameter("@Id", SqlDbType.Int,4),
 new SqlParameter("@TypeName", SqlDbType.NVarChar,100),
 new SqlParameter("@TypeRemarks", SqlDbType.NVarChar,510),
 new SqlParameter("@ClassId", SqlDbType.Int,4),
 new SqlParameter("@LevelId", SqlDbType.Int,4),
 new SqlParameter("@Status", SqlDbType.Bit,1),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.Id;
 parameters[1].Value = model.TypeName;
 parameters[2].Value = model.TypeRemarks;
 parameters[3].Value = model.ClassId;
 parameters[4].Value = model.LevelId;
 parameters[5].Value = model.Status;
 parameters[6].Value = model.CreateTime;
 parameters[7].Value = model.UpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogTypeConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogType_Delete(Int32 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogTypeTableName);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int, 4)
			};
            parameters[0].Value = id;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogTypeConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogType_DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogTypeTableName);
            strSql.Append(" where Id in (" + idlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogTypeConnectionName), CommandType.Text,strSql.ToString());
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
        public LogType LogType_GetModel(Int32 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(LogTypeTableField);
            strSql.Append(" from ");
            strSql.Append(LogTypeTableName);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int, 4)
			};
            parameters[0].Value = id;
            LogType model = new LogType();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return LogType_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LogType LogType_DataRowToModel(DataRow row)
        {
            LogType model = new LogType();
            if (row != null)
            {
				if (row["Id"] != null )
                {
                        model.Id = int.Parse(row["Id"].ToString());
                }
				if (row["TypeName"] != null )
                {
					model.TypeName = row["TypeName"].ToString();
                }
				if (row["TypeRemarks"] != null )
                {
					model.TypeRemarks = row["TypeRemarks"].ToString();
                }
				if (row["ClassId"] != null )
                {
                        model.ClassId = int.Parse(row["ClassId"].ToString());
                }
				if (row["LevelId"] != null )
                {
                        model.LevelId = int.Parse(row["LevelId"].ToString());
                }
				if (row["Status"] != null )
                {
					model.Status = bool.Parse(row["Status"].ToString());
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
        public DataSet LogType_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(LogTypeTableField);
            strSql.Append(" FROM ");
            strSql.Append(LogTypeTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet LogType_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(LogTypeTableField);
            strSql.Append(" FROM ");
            strSql.Append(LogTypeTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int LogType_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(LogTypeTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(LogTypeConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet LogType_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(LogTypeTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable LogType_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "Id")
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
            parameters[0].Value = "LogType";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogTypeConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
