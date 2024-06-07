﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class LogRecordManage : ILogRecordManage
    {
        ///表链接
        private const string LogRecordConnectionName = "LogBaseDb";
        ///表名称
        private const string LogRecordTableName = "LogRecord";
        ///表字段
        private const string LogRecordTableField = "Id,TypeId,LevelId,LogDetail,LogRemarks,LogUrl,LogCreatorId,LogCreatorIP,OperateTime,DateCode,CreateTime,UpdateTime";
        //添加用表字段
        private const string LogRecordTableFieldForAdd = "TypeId,LevelId,LogDetail,LogRemarks,LogUrl,LogCreatorId,LogCreatorIP,OperateTime,DateCode,CreateTime,UpdateTime";
        //添加用表字段value
        private const string LogRecordTableFieldAltForAdd = "@TypeId,@LevelId,@LogDetail,@LogRemarks,@LogUrl,@LogCreatorId,@LogCreatorIP,@OperateTime,@DateCode,@CreateTime,@UpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int LogRecord_Add(LogRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(LogRecordTableName);
			strSql.Append(" (");
            strSql.Append(LogRecordTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(LogRecordTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@TypeId", SqlDbType.Int,4),
 new SqlParameter("@LevelId", SqlDbType.Int,4),
 new SqlParameter("@LogDetail", SqlDbType.NText,2147483646),
 new SqlParameter("@LogRemarks", SqlDbType.NText,2147483646),
 new SqlParameter("@LogUrl", SqlDbType.NVarChar,510),
 new SqlParameter("@LogCreatorId", SqlDbType.Int,4),
 new SqlParameter("@LogCreatorIP", SqlDbType.VarChar,50),
 new SqlParameter("@OperateTime", SqlDbType.DateTime,16),
 new SqlParameter("@DateCode", SqlDbType.Int,4),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.TypeId;
 parameters[1].Value = model.LevelId;
 parameters[2].Value = model.LogDetail;
 parameters[3].Value = model.LogRemarks;
 parameters[4].Value = model.LogUrl;
 parameters[5].Value = model.LogCreatorId;
 parameters[6].Value = model.LogCreatorIP;
 parameters[7].Value = model.OperateTime;
 parameters[8].Value = model.DateCode;
 parameters[9].Value = model.CreateTime;
 parameters[10].Value = model.UpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(LogRecordConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogRecord_Update(LogRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" set ");
			strSql.Append("TypeId=@TypeId,");
strSql.Append("LevelId=@LevelId,");
strSql.Append("LogDetail=@LogDetail,");
strSql.Append("LogRemarks=@LogRemarks,");
strSql.Append("LogUrl=@LogUrl,");
strSql.Append("LogCreatorId=@LogCreatorId,");
strSql.Append("LogCreatorIP=@LogCreatorIP,");
strSql.Append("OperateTime=@OperateTime,");
strSql.Append("DateCode=@DateCode,");
strSql.Append("CreateTime=@CreateTime,");
strSql.Append("UpdateTime=@UpdateTime");

            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
				 new SqlParameter("@Id", SqlDbType.BigInt,8),
 new SqlParameter("@TypeId", SqlDbType.Int,4),
 new SqlParameter("@LevelId", SqlDbType.Int,4),
 new SqlParameter("@LogDetail", SqlDbType.NText,2147483646),
 new SqlParameter("@LogRemarks", SqlDbType.NText,2147483646),
 new SqlParameter("@LogUrl", SqlDbType.NVarChar,510),
 new SqlParameter("@LogCreatorId", SqlDbType.Int,4),
 new SqlParameter("@LogCreatorIP", SqlDbType.VarChar,50),
 new SqlParameter("@OperateTime", SqlDbType.DateTime,16),
 new SqlParameter("@DateCode", SqlDbType.Int,4),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.Id;
 parameters[1].Value = model.TypeId;
 parameters[2].Value = model.LevelId;
 parameters[3].Value = model.LogDetail;
 parameters[4].Value = model.LogRemarks;
 parameters[5].Value = model.LogUrl;
 parameters[6].Value = model.LogCreatorId;
 parameters[7].Value = model.LogCreatorIP;
 parameters[8].Value = model.OperateTime;
 parameters[9].Value = model.DateCode;
 parameters[10].Value = model.CreateTime;
 parameters[11].Value = model.UpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogRecord_Delete(Int64 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt, 8)
			};
            parameters[0].Value = id;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogRecordConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool LogRecord_DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" where Id in (" + idlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(LogRecordConnectionName), CommandType.Text,strSql.ToString());
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
        public LogRecord LogRecord_GetModel(Int64 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(LogRecordTableField);
            strSql.Append(" from ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt, 8)
			};
            parameters[0].Value = id;
            LogRecord model = new LogRecord();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return LogRecord_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LogRecord LogRecord_DataRowToModel(DataRow row)
        {
            LogRecord model = new LogRecord();
            if (row != null)
            {
				if (row["Id"] != null )
                {
					model.Id = long.Parse(row["Id"].ToString());
                }
				if (row["TypeId"] != null )
                {
                        model.TypeId = int.Parse(row["TypeId"].ToString());
                }
				if (row["LevelId"] != null )
                {
                        model.LevelId = int.Parse(row["LevelId"].ToString());
                }
				if (row["LogDetail"] != null )
                {
					model.LogDetail = row["LogDetail"].ToString();
                }
				if (row["LogRemarks"] != null )
                {
					model.LogRemarks = row["LogRemarks"].ToString();
                }
				if (row["LogUrl"] != null )
                {
					model.LogUrl = row["LogUrl"].ToString();
                }
				if (row["LogCreatorId"] != null )
                {
                        model.LogCreatorId = int.Parse(row["LogCreatorId"].ToString());
                }
				if (row["LogCreatorIP"] != null )
                {
					model.LogCreatorIP = row["LogCreatorIP"].ToString();
                }
				if (row["OperateTime"] != null )
                {
					model.OperateTime = DateTime.Parse(row["OperateTime"].ToString());
                }
				if (row["DateCode"] != null )
                {
                        model.DateCode = int.Parse(row["DateCode"].ToString());
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
        public DataSet LogRecord_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(LogRecordTableField);
            strSql.Append(" FROM ");
            strSql.Append(LogRecordTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet LogRecord_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(LogRecordTableField);
            strSql.Append(" FROM ");
            strSql.Append(LogRecordTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int LogRecord_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(LogRecordTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet LogRecord_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(LogRecordTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable LogRecord_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "Id")
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
            parameters[0].Value = "LogRecord";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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