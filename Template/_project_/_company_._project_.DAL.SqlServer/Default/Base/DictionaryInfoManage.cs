using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class DictionaryInfoManage : IDictionaryInfoManage
    {
        ///表链接
        private const string DictionaryInfoConnectionName = "BaseDb";
        ///表名称
        private const string DictionaryInfoTableName = "BaseDictionaryInfo";
        ///表字段
        private const string DictionaryInfoTableField = "DicId,DicName,DicTitle,DicValue,DicRemark,Status,Sort,Pid,Cid,CreateTime,UpdateTime";
        //添加用表字段
        private const string DictionaryInfoTableFieldForAdd = "DicName,DicTitle,DicValue,DicRemark,Status,Sort,Pid,Cid,CreateTime,UpdateTime";
        //添加用表字段value
        private const string DictionaryInfoTableFieldAltForAdd = "@DicName,@DicTitle,@DicValue,@DicRemark,@Status,@Sort,@Pid,@Cid,@CreateTime,@UpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int DictionaryInfo_Add(DictionaryInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(DictionaryInfoTableName);
			strSql.Append(" (");
            strSql.Append(DictionaryInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(DictionaryInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@DicName", SqlDbType.NVarChar,510),
 new SqlParameter("@DicTitle", SqlDbType.NVarChar,510),
 new SqlParameter("@DicValue", SqlDbType.NVarChar,510),
 new SqlParameter("@DicRemark", SqlDbType.NVarChar,510),
 new SqlParameter("@Status", SqlDbType.Bit,1),
 new SqlParameter("@Sort", SqlDbType.Int,4),
 new SqlParameter("@Pid", SqlDbType.Int,4),
 new SqlParameter("@Cid", SqlDbType.Int,4),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.DicName;
 parameters[1].Value = model.DicTitle;
 parameters[2].Value = model.DicValue;
 parameters[3].Value = model.DicRemark;
 parameters[4].Value = model.Status;
 parameters[5].Value = model.Sort;
 parameters[6].Value = model.Pid;
 parameters[7].Value = model.Cid;
 parameters[8].Value = model.CreateTime;
 parameters[9].Value = model.UpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(DictionaryInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool DictionaryInfo_Update(DictionaryInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(DictionaryInfoTableName);
            strSql.Append(" set ");
			strSql.Append("DicName=@DicName,");
strSql.Append("DicTitle=@DicTitle,");
strSql.Append("DicValue=@DicValue,");
strSql.Append("DicRemark=@DicRemark,");
strSql.Append("Status=@Status,");
strSql.Append("Sort=@Sort,");
strSql.Append("Pid=@Pid,");
strSql.Append("Cid=@Cid,");
strSql.Append("CreateTime=@CreateTime,");
strSql.Append("UpdateTime=@UpdateTime");

            strSql.Append(" where DicId=@DicId");
            SqlParameter[] parameters = {
				 new SqlParameter("@DicId", SqlDbType.Int,4),
 new SqlParameter("@DicName", SqlDbType.NVarChar,510),
 new SqlParameter("@DicTitle", SqlDbType.NVarChar,510),
 new SqlParameter("@DicValue", SqlDbType.NVarChar,510),
 new SqlParameter("@DicRemark", SqlDbType.NVarChar,510),
 new SqlParameter("@Status", SqlDbType.Bit,1),
 new SqlParameter("@Sort", SqlDbType.Int,4),
 new SqlParameter("@Pid", SqlDbType.Int,4),
 new SqlParameter("@Cid", SqlDbType.Int,4),
 new SqlParameter("@CreateTime", SqlDbType.DateTime,16),
 new SqlParameter("@UpdateTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.DicId;
 parameters[1].Value = model.DicName;
 parameters[2].Value = model.DicTitle;
 parameters[3].Value = model.DicValue;
 parameters[4].Value = model.DicRemark;
 parameters[5].Value = model.Status;
 parameters[6].Value = model.Sort;
 parameters[7].Value = model.Pid;
 parameters[8].Value = model.Cid;
 parameters[9].Value = model.CreateTime;
 parameters[10].Value = model.UpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(DictionaryInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool DictionaryInfo_Delete(Int32 dicId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(DictionaryInfoTableName);
            strSql.Append(" where DicId=@DicId");
            SqlParameter[] parameters = {
					new SqlParameter("@DicId", SqlDbType.Int, 4)
			};
            parameters[0].Value = dicId;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(DictionaryInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool DictionaryInfo_DeleteList(string dicIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(DictionaryInfoTableName);
            strSql.Append(" where DicId in (" + dicIdlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(DictionaryInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public DictionaryInfo DictionaryInfo_GetModel(Int32 dicId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(DictionaryInfoTableField);
            strSql.Append(" from ");
            strSql.Append(DictionaryInfoTableName);
            strSql.Append(" where DicId=@DicId");
            SqlParameter[] parameters = {
					new SqlParameter("@DicId", SqlDbType.Int, 4)
			};
            parameters[0].Value = dicId;
            DictionaryInfo model = new DictionaryInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DictionaryInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DictionaryInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DictionaryInfo DictionaryInfo_DataRowToModel(DataRow row)
        {
            DictionaryInfo model = new DictionaryInfo();
            if (row != null)
            {
				if (row["DicId"] != null )
                {
                        model.DicId = int.Parse(row["DicId"].ToString());
                }
				if (row["DicName"] != null )
                {
					model.DicName = row["DicName"].ToString();
                }
				if (row["DicTitle"] != null )
                {
					model.DicTitle = row["DicTitle"].ToString();
                }
				if (row["DicValue"] != null )
                {
					model.DicValue = row["DicValue"].ToString();
                }
				if (row["DicRemark"] != null )
                {
					model.DicRemark = row["DicRemark"].ToString();
                }
				if (row["Status"] != null )
                {
					model.Status = bool.Parse(row["Status"].ToString());
                }
				if (row["Sort"] != null )
                {
                        model.Sort = int.Parse(row["Sort"].ToString());
                }
				if (row["Pid"] != null )
                {
                        model.Pid = int.Parse(row["Pid"].ToString());
                }
				if (row["Cid"] != null )
                {
                        model.Cid = int.Parse(row["Cid"].ToString());
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
        public DataSet DictionaryInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(DictionaryInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(DictionaryInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DictionaryInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet DictionaryInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(DictionaryInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(DictionaryInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DictionaryInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int DictionaryInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(DictionaryInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(DictionaryInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet DictionaryInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(DictionaryInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DictionaryInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable DictionaryInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "DicId")
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
            parameters[0].Value = "BaseDictionaryInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DictionaryInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
