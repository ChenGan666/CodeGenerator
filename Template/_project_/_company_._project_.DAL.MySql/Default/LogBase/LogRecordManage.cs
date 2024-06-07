using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using _company_._project_.Entity;

namespace _company_._project_.DAL.MySql
{
    public partial class LogRecordManage : ILogRecordManage
    {
        ///������
        private const string LogRecordConnectionName = "LogBaseDb";
        ///������
        private const string LogRecordTableName = "log_record";
        ///���ֶ�
        private const string LogRecordTableField = "Id,MarkId,LevelId,LogDetail,LogRemarks,LogUrl,LogCreatorId,LogCreatorIP,OperateTime,DateCode,CreateTime,UpdateTime";
        ///����ñ��ֶ�
        private const string LogRecordTableFieldForAdd = "MarkId,LevelId,LogDetail,LogRemarks,LogUrl,LogCreatorId,LogCreatorIP,OperateTime,DateCode,CreateTime,UpdateTime";
        ///����ñ��ֶ�value
        private const string LogRecordTableFieldAltForAdd = "@MarkId,@LevelId,@LogDetail,@LogRemarks,@LogUrl,@LogCreatorId,@LogCreatorIP,@OperateTime,@DateCode,@CreateTime,@UpdateTime";
		/// <summary>
        /// ����һ������
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
            MySqlParameter[] parameters = {
			 new MySqlParameter("@MarkId", MySqlDbType.Int32,10),
 new MySqlParameter("@LevelId", MySqlDbType.Int32,10),
 new MySqlParameter("@LogDetail", MySqlDbType.LongText),
 new MySqlParameter("@LogRemarks", MySqlDbType.LongText),
 new MySqlParameter("@LogUrl", MySqlDbType.VarChar,255),
 new MySqlParameter("@LogCreatorId", MySqlDbType.VarChar,50),
 new MySqlParameter("@LogCreatorIP", MySqlDbType.VarChar,50),
 new MySqlParameter("@OperateTime", MySqlDbType.DateTime,16),
 new MySqlParameter("@DateCode", MySqlDbType.Int32,10),
 new MySqlParameter("@CreateTime", MySqlDbType.DateTime,16),
 new MySqlParameter("@UpdateTime", MySqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.MarkId;
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
        /// ����һ������
        /// </summary>
        public bool LogRecord_Update(LogRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" set ");
			strSql.Append("MarkId=@MarkId,");
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
            MySqlParameter[] parameters = {
				 new MySqlParameter("@Id", MySqlDbType.Int64,19),
 new MySqlParameter("@MarkId", MySqlDbType.Int32,10),
 new MySqlParameter("@LevelId", MySqlDbType.Int32,10),
 new MySqlParameter("@LogDetail", MySqlDbType.LongText),
 new MySqlParameter("@LogRemarks", MySqlDbType.LongText),
 new MySqlParameter("@LogUrl", MySqlDbType.VarChar,255),
 new MySqlParameter("@LogCreatorId", MySqlDbType.VarChar,50),
 new MySqlParameter("@LogCreatorIP", MySqlDbType.VarChar,50),
 new MySqlParameter("@OperateTime", MySqlDbType.DateTime,16),
 new MySqlParameter("@DateCode", MySqlDbType.Int32,10),
 new MySqlParameter("@CreateTime", MySqlDbType.DateTime,16),
 new MySqlParameter("@UpdateTime", MySqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.Id;
 parameters[1].Value = model.MarkId;
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
        /// ɾ��һ������
        /// </summary>
        public bool LogRecord_Delete(Int64 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int64, 19)
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
        /// ����ɾ������
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
        /// �õ�һ������ʵ��
        /// </summary>
        public LogRecord LogRecord_GetModel(Int64 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(LogRecordTableField);
            strSql.Append(" from ");
            strSql.Append(LogRecordTableName);
            strSql.Append(" where Id=@Id");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int64, 19)
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
        /// �õ�һ������ʵ��
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
				if (row["MarkId"] != null )
                {
                        model.MarkId = int.Parse(row["MarkId"].ToString());
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
					model.LogCreatorId = row["LogCreatorId"].ToString();
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
        /// ��������б�
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
        /// ���ǰ��������
        /// </summary>
        public DataSet LogRecord_GetList(int top, string strWhere, string filedOrder)
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
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            if (top > 0)
            {
                strSql.Append(" limit " + top.ToString() + " ");
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// ��ȡ��¼����
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
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet LogRecord_GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(" order by " + orderby);
            if (startIndex >= 0 && endIndex >= startIndex)
            {
                strSql.Append(" limit " + startIndex + ", " + (endIndex - startIndex));
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="pageSize">ÿҳ��С</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="pagetotal">��ҳ��</param>
        /// <param name="total">����</param>
        /// <param name="orderType">������� Ĭ�Ͻ���1����0����</param>
        /// <param name="showName">��ʾ�ֶΣ�Ĭ��ȫ��</param>
        /// <param name="orderKey">����key��Ĭ������</param>
        public DataTable LogRecord_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "Id")
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tableName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@showFName", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@selectWhere", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@selectOrder", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@pageNo", MySqlDbType.Int32),
                    new MySqlParameter("@pageSize", MySqlDbType.Int32)
            };
            parameters[0].Value = "log_record";
            parameters[1].Value = showName;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderKey + (orderType == 0 ? " ASC" : " DESC");
            parameters[4].Value = pageIndex;
            parameters[5].Value = pageSize;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(LogRecordConnectionName),CommandType.StoredProcedure, "CommonPagenation", parameters);
            total = 0;
            if (ds.Tables.Count > 1)
            {
                total = Convert.ToInt32((long)ds.Tables[1].Rows[0][0]);
                if (total % pageSize == 0)
                {
                    pagetotal = total / pageSize;
                }
                else
                {
                    pagetotal = total / pageSize + 1;
                }
                return ds.Tables[0];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
	}
}
