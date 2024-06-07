using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;

namespace FJData.YxInsuranceSystem.DAL.MySql
{
    public partial class UploadFileInfoManage : IUploadFileInfoManage
    {
        ///表链接
        private const string UploadFileInfoConnectionName = "BaseDb";
        ///表名称
        private const string UploadFileInfoTableName = "base_upload_file_info";
        ///表字段
        private const string UploadFileInfoTableField = "Id,FilePath,FileName,FileOriginName,FileSize,FileType,FileMd5,FileIntro,CreateTime,UpdateTime";
        ///添加用表字段
        private const string UploadFileInfoTableFieldForAdd = "FilePath,FileName,FileOriginName,FileSize,FileType,FileMd5,FileIntro,CreateTime,UpdateTime";
        ///添加用表字段value
        private const string UploadFileInfoTableFieldAltForAdd = "@FilePath,@FileName,@FileOriginName,@FileSize,@FileType,@FileMd5,@FileIntro,@CreateTime,@UpdateTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int UploadFileInfo_Add(UploadFileInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(UploadFileInfoTableName);
			strSql.Append(" (");
            strSql.Append(UploadFileInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(UploadFileInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
			 new MySqlParameter("@FilePath", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileName", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileOriginName", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileSize", MySqlDbType.VarChar,50),
 new MySqlParameter("@FileType", MySqlDbType.VarChar,50),
 new MySqlParameter("@FileMd5", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileIntro", MySqlDbType.VarChar,550),
 new MySqlParameter("@CreateTime", MySqlDbType.DateTime,16),
 new MySqlParameter("@UpdateTime", MySqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.FilePath;
 parameters[1].Value = model.FileName;
 parameters[2].Value = model.FileOriginName;
 parameters[3].Value = model.FileSize;
 parameters[4].Value = model.FileType;
 parameters[5].Value = model.FileMd5;
 parameters[6].Value = model.FileIntro;
 parameters[7].Value = model.CreateTime;
 parameters[8].Value = model.UpdateTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(UploadFileInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool UploadFileInfo_Update(UploadFileInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(UploadFileInfoTableName);
            strSql.Append(" set ");
			strSql.Append("FilePath=@FilePath,");
strSql.Append("FileName=@FileName,");
strSql.Append("FileOriginName=@FileOriginName,");
strSql.Append("FileSize=@FileSize,");
strSql.Append("FileType=@FileType,");
strSql.Append("FileMd5=@FileMd5,");
strSql.Append("FileIntro=@FileIntro,");
strSql.Append("CreateTime=@CreateTime,");
strSql.Append("UpdateTime=@UpdateTime");

            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
				 new MySqlParameter("@Id", MySqlDbType.Int32,10),
 new MySqlParameter("@FilePath", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileName", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileOriginName", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileSize", MySqlDbType.VarChar,50),
 new MySqlParameter("@FileType", MySqlDbType.VarChar,50),
 new MySqlParameter("@FileMd5", MySqlDbType.VarChar,255),
 new MySqlParameter("@FileIntro", MySqlDbType.VarChar,550),
 new MySqlParameter("@CreateTime", MySqlDbType.DateTime,16),
 new MySqlParameter("@UpdateTime", MySqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.Id;
 parameters[1].Value = model.FilePath;
 parameters[2].Value = model.FileName;
 parameters[3].Value = model.FileOriginName;
 parameters[4].Value = model.FileSize;
 parameters[5].Value = model.FileType;
 parameters[6].Value = model.FileMd5;
 parameters[7].Value = model.FileIntro;
 parameters[8].Value = model.CreateTime;
 parameters[9].Value = model.UpdateTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(UploadFileInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool UploadFileInfo_Delete(Int32 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(UploadFileInfoTableName);
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int32, 10)
			};
            parameters[0].Value = id;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(UploadFileInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool UploadFileInfo_DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(UploadFileInfoTableName);
            strSql.Append(" where Id in (" + idlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(UploadFileInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public UploadFileInfo UploadFileInfo_GetModel(Int32 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(UploadFileInfoTableField);
            strSql.Append(" from ");
            strSql.Append(UploadFileInfoTableName);
            strSql.Append(" where Id=@Id");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int32, 10)
			};
            parameters[0].Value = id;
            UploadFileInfo model = new UploadFileInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UploadFileInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return UploadFileInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UploadFileInfo UploadFileInfo_DataRowToModel(DataRow row)
        {
            UploadFileInfo model = new UploadFileInfo();
            if (row != null)
            {
				if (row["Id"] != null )
                {
                        model.Id = int.Parse(row["Id"].ToString());
                }
				if (row["FilePath"] != null )
                {
					model.FilePath = row["FilePath"].ToString();
                }
				if (row["FileName"] != null )
                {
					model.FileName = row["FileName"].ToString();
                }
				if (row["FileOriginName"] != null )
                {
					model.FileOriginName = row["FileOriginName"].ToString();
                }
				if (row["FileSize"] != null )
                {
					model.FileSize = row["FileSize"].ToString();
                }
				if (row["FileType"] != null )
                {
					model.FileType = row["FileType"].ToString();
                }
				if (row["FileMd5"] != null )
                {
					model.FileMd5 = row["FileMd5"].ToString();
                }
				if (row["FileIntro"] != null )
                {
					model.FileIntro = row["FileIntro"].ToString();
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
        public DataSet UploadFileInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(UploadFileInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(UploadFileInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UploadFileInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet UploadFileInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(UploadFileInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(UploadFileInfoTableName);
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
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UploadFileInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int UploadFileInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(UploadFileInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(UploadFileInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet UploadFileInfo_GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(UploadFileInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(UploadFileInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + orderby);
            if (startIndex >= 0 && endIndex >= startIndex)
            {
                strSql.Append(" limit " + startIndex + ", " + (endIndex - startIndex));
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UploadFileInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable UploadFileInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "Id")
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tableName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@showFName", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@selectWhere", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@selectOrder", MySqlDbType.VarChar, 500),
                    new MySqlParameter("@pageNo", MySqlDbType.Int32),
                    new MySqlParameter("@pageSize", MySqlDbType.Int32)
            };
            parameters[0].Value = "base_upload_file_info";
            parameters[1].Value = showName;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderKey + (orderType == 0 ? " ASC" : " DESC");
            parameters[4].Value = pageIndex;
            parameters[5].Value = pageSize;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(UploadFileInfoConnectionName),CommandType.StoredProcedure, "CommonPagenation", parameters);
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
