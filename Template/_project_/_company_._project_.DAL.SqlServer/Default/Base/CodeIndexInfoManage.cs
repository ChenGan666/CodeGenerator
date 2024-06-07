using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class CodeIndexInfoManage : ICodeIndexInfoManage
    {
        ///表链接
        private const string CodeIndexInfoConnectionName = "BaseDb";
        ///表名称
        private const string CodeIndexInfoTableName = "BaseCodeIndexInfo";
        ///表字段
        private const string CodeIndexInfoTableField = "CodeIndexID,SystemID,CodeType,CodeIndex,cUpdateTime";
        //添加用表字段
        private const string CodeIndexInfoTableFieldForAdd = "SystemID,CodeType,CodeIndex,cUpdateTime";
        //添加用表字段value
        private const string CodeIndexInfoTableFieldAltForAdd = "@SystemID,@CodeType,@CodeIndex,@cUpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int CodeIndexInfo_Add(CodeIndexInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(CodeIndexInfoTableName);
			strSql.Append(" (");
            strSql.Append(CodeIndexInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(CodeIndexInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@CodeType", SqlDbType.Int,4),
 new SqlParameter("@CodeIndex", SqlDbType.Int,4),
 new SqlParameter("@cUpdateTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.SystemID;
 parameters[1].Value = model.CodeType;
 parameters[2].Value = model.CodeIndex;
 parameters[3].Value = model.cUpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(CodeIndexInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool CodeIndexInfo_Update(CodeIndexInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(CodeIndexInfoTableName);
            strSql.Append(" set ");
			strSql.Append("SystemID=@SystemID,");
strSql.Append("CodeType=@CodeType,");
strSql.Append("CodeIndex=@CodeIndex,");
strSql.Append("cUpdateTime=@cUpdateTime");

            strSql.Append(" where CodeIndexID=@CodeIndexID");
            SqlParameter[] parameters = {
				 new SqlParameter("@CodeIndexID", SqlDbType.Int,4),
 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@CodeType", SqlDbType.Int,4),
 new SqlParameter("@CodeIndex", SqlDbType.Int,4),
 new SqlParameter("@cUpdateTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.CodeIndexID;
 parameters[1].Value = model.SystemID;
 parameters[2].Value = model.CodeType;
 parameters[3].Value = model.CodeIndex;
 parameters[4].Value = model.cUpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(CodeIndexInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool CodeIndexInfo_Delete(Int32 codeIndexID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(CodeIndexInfoTableName);
            strSql.Append(" where CodeIndexID=@CodeIndexID");
            SqlParameter[] parameters = {
					new SqlParameter("@CodeIndexID", SqlDbType.Int, 4)
			};
            parameters[0].Value = codeIndexID;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(CodeIndexInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool CodeIndexInfo_DeleteList(string codeIndexIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(CodeIndexInfoTableName);
            strSql.Append(" where CodeIndexID in (" + codeIndexIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(CodeIndexInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public CodeIndexInfo CodeIndexInfo_GetModel(Int32 codeIndexID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(CodeIndexInfoTableField);
            strSql.Append(" from ");
            strSql.Append(CodeIndexInfoTableName);
            strSql.Append(" where CodeIndexID=@CodeIndexID");
            SqlParameter[] parameters = {
					new SqlParameter("@CodeIndexID", SqlDbType.Int, 4)
			};
            parameters[0].Value = codeIndexID;
            CodeIndexInfo model = new CodeIndexInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(CodeIndexInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return CodeIndexInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CodeIndexInfo CodeIndexInfo_DataRowToModel(DataRow row)
        {
            CodeIndexInfo model = new CodeIndexInfo();
            if (row != null)
            {
				if (row["CodeIndexID"] != null )
                {
                        model.CodeIndexID = int.Parse(row["CodeIndexID"].ToString());
                }
				if (row["SystemID"] != null )
                {
                        model.SystemID = int.Parse(row["SystemID"].ToString());
                }
				if (row["CodeType"] != null )
                {
                        model.CodeType = int.Parse(row["CodeType"].ToString());
                }
				if (row["CodeIndex"] != null )
                {
                        model.CodeIndex = int.Parse(row["CodeIndex"].ToString());
                }
				if (row["cUpdateTime"] != null )
                {
					model.cUpdateTime = DateTime.Parse(row["cUpdateTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet CodeIndexInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(CodeIndexInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(CodeIndexInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(CodeIndexInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet CodeIndexInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(CodeIndexInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(CodeIndexInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(CodeIndexInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int CodeIndexInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(CodeIndexInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(CodeIndexInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet CodeIndexInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(CodeIndexInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(CodeIndexInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable CodeIndexInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "CodeIndexID")
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
            parameters[0].Value = "BaseCodeIndexInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(CodeIndexInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
