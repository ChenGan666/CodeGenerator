using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.MySql
{
    public partial class DictionaryInfoManage : IDictionaryInfoManage
    {
        ///表链接
        private const string DictionaryInfoConnectionName = "BaseDb";
        ///表名称
        private const string DictionaryInfoTableName = "base_dictionary_info";
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
            MySqlParameter[] parameters = {
			 new MySqlParameter("@DicName", MySqlDbType.VarChar,255),
 new MySqlParameter("@DicTitle", MySqlDbType.VarChar,255),
 new MySqlParameter("@DicValue", MySqlDbType.VarChar,255),
 new MySqlParameter("@DicRemark", MySqlDbType.VarChar,255),
 new MySqlParameter("@Status", MySqlDbType.Byte,3),
 new MySqlParameter("@Sort", MySqlDbType.Int32,10),
 new MySqlParameter("@Pid", MySqlDbType.Int32,10),
 new MySqlParameter("@Cid", MySqlDbType.Int32,10),
 new MySqlParameter("@CreateTime", MySqlDbType.DateTime),
 new MySqlParameter("@UpdateTime", MySqlDbType.DateTime)

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
            MySqlParameter[] parameters = {
				 new MySqlParameter("@DicId", MySqlDbType.Int32,10),
 new MySqlParameter("@DicName", MySqlDbType.VarChar,255),
 new MySqlParameter("@DicTitle", MySqlDbType.VarChar,255),
 new MySqlParameter("@DicValue", MySqlDbType.VarChar,255),
 new MySqlParameter("@DicRemark", MySqlDbType.VarChar,255),
 new MySqlParameter("@Status", MySqlDbType.Byte,3),
 new MySqlParameter("@Sort", MySqlDbType.Int32,10),
 new MySqlParameter("@Pid", MySqlDbType.Int32,10),
 new MySqlParameter("@Cid", MySqlDbType.Int32,10),
 new MySqlParameter("@CreateTime", MySqlDbType.DateTime),
 new MySqlParameter("@UpdateTime", MySqlDbType.DateTime)

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
            MySqlParameter[] parameters = {
					new MySqlParameter("@DicId", MySqlDbType.Int32, 10)
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
            strSql.Append("select ");
            strSql.Append(DictionaryInfoTableField);
            strSql.Append(" from ");
            strSql.Append(DictionaryInfoTableName);
            strSql.Append(" where DicId=@DicId");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DicId", MySqlDbType.Int32, 10)
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
            strSql.Append(DictionaryInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(DictionaryInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (top > 0)
            {
                strSql.Append(" limit " + top.ToString() + " ");
            }
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
        public DataSet DictionaryInfo_GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(" order by " + orderby);
            if (startIndex >= 0 && endIndex >= startIndex)
            {
                strSql.Append(" limit " + startIndex + ", " + (endIndex - startIndex));
            }
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
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tableName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@showFName", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@selectWhere", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@selectOrder", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@pageNo", MySqlDbType.Int32),
                    new MySqlParameter("@pageSize", MySqlDbType.Int32)
            };
            parameters[0].Value = "base_dictionary_info";
            parameters[1].Value = showName;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderKey + (orderType == 0 ? " ASC" : " DESC");
            parameters[4].Value = pageIndex;
            parameters[5].Value = pageSize;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(DictionaryInfoConnectionName),CommandType.StoredProcedure, "CommonPagenation", parameters);
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
