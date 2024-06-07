using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class BranchInfoManage : IBranchInfoManage
    {
        ///表链接
        private const string BranchInfoConnectionName = "BaseDb";
        ///表名称
        private const string BranchInfoTableName = "BaseBranchInfo";
        ///表字段
        private const string BranchInfoTableField = "BranchID,SystemID,bItemID,bCode,bName,bLinkMan,bTel,bFax,bEmail,bNote,bAppendTime,bState";
        //添加用表字段
        private const string BranchInfoTableFieldForAdd = "SystemID,bItemID,bCode,bName,bLinkMan,bTel,bFax,bEmail,bNote,bAppendTime,bState";
        //添加用表字段value
        private const string BranchInfoTableFieldAltForAdd = "@SystemID,@bItemID,@bCode,@bName,@bLinkMan,@bTel,@bFax,@bEmail,@bNote,@bAppendTime,@bState";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int BranchInfo_Add(BranchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(BranchInfoTableName);
			strSql.Append(" (");
            strSql.Append(BranchInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(BranchInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@bItemID", SqlDbType.VarChar,50),
 new SqlParameter("@bCode", SqlDbType.VarChar,50),
 new SqlParameter("@bName", SqlDbType.VarChar,250),
 new SqlParameter("@bLinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@bTel", SqlDbType.VarChar,50),
 new SqlParameter("@bFax", SqlDbType.VarChar,50),
 new SqlParameter("@bEmail", SqlDbType.VarChar,50),
 new SqlParameter("@bNote", SqlDbType.VarChar,128),
 new SqlParameter("@bAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@bState", SqlDbType.Bit,1)

					};
			 parameters[0].Value = model.SystemID;
 parameters[1].Value = model.bItemID;
 parameters[2].Value = model.bCode;
 parameters[3].Value = model.bName;
 parameters[4].Value = model.bLinkMan;
 parameters[5].Value = model.bTel;
 parameters[6].Value = model.bFax;
 parameters[7].Value = model.bEmail;
 parameters[8].Value = model.bNote;
 parameters[9].Value = model.bAppendTime;
 parameters[10].Value = model.bState;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(BranchInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool BranchInfo_Update(BranchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(BranchInfoTableName);
            strSql.Append(" set ");
			strSql.Append("SystemID=@SystemID,");
strSql.Append("bItemID=@bItemID,");
strSql.Append("bCode=@bCode,");
strSql.Append("bName=@bName,");
strSql.Append("bLinkMan=@bLinkMan,");
strSql.Append("bTel=@bTel,");
strSql.Append("bFax=@bFax,");
strSql.Append("bEmail=@bEmail,");
strSql.Append("bNote=@bNote,");
strSql.Append("bAppendTime=@bAppendTime,");
strSql.Append("bState=@bState");

            strSql.Append(" where BranchID=@BranchID");
            SqlParameter[] parameters = {
				 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@bItemID", SqlDbType.VarChar,50),
 new SqlParameter("@bCode", SqlDbType.VarChar,50),
 new SqlParameter("@bName", SqlDbType.VarChar,250),
 new SqlParameter("@bLinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@bTel", SqlDbType.VarChar,50),
 new SqlParameter("@bFax", SqlDbType.VarChar,50),
 new SqlParameter("@bEmail", SqlDbType.VarChar,50),
 new SqlParameter("@bNote", SqlDbType.VarChar,128),
 new SqlParameter("@bAppendTime", SqlDbType.DateTime,16),
 new SqlParameter("@bState", SqlDbType.Bit,1)

			};
			 parameters[0].Value = model.BranchID;
 parameters[1].Value = model.SystemID;
 parameters[2].Value = model.bItemID;
 parameters[3].Value = model.bCode;
 parameters[4].Value = model.bName;
 parameters[5].Value = model.bLinkMan;
 parameters[6].Value = model.bTel;
 parameters[7].Value = model.bFax;
 parameters[8].Value = model.bEmail;
 parameters[9].Value = model.bNote;
 parameters[10].Value = model.bAppendTime;
 parameters[11].Value = model.bState;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(BranchInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool BranchInfo_Delete(Int32 branchID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(BranchInfoTableName);
            strSql.Append(" where BranchID=@BranchID");
            SqlParameter[] parameters = {
					new SqlParameter("@BranchID", SqlDbType.Int, 4)
			};
            parameters[0].Value = branchID;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(BranchInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool BranchInfo_DeleteList(string branchIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(BranchInfoTableName);
            strSql.Append(" where BranchID in (" + branchIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(BranchInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public BranchInfo BranchInfo_GetModel(Int32 branchID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(BranchInfoTableField);
            strSql.Append(" from ");
            strSql.Append(BranchInfoTableName);
            strSql.Append(" where BranchID=@BranchID");
            SqlParameter[] parameters = {
					new SqlParameter("@BranchID", SqlDbType.Int, 4)
			};
            parameters[0].Value = branchID;
            BranchInfo model = new BranchInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(BranchInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return BranchInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BranchInfo BranchInfo_DataRowToModel(DataRow row)
        {
            BranchInfo model = new BranchInfo();
            if (row != null)
            {
				if (row["BranchID"] != null )
                {
                        model.BranchID = int.Parse(row["BranchID"].ToString());
                }
				if (row["SystemID"] != null )
                {
                        model.SystemID = int.Parse(row["SystemID"].ToString());
                }
				if (row["bItemID"] != null )
                {
					model.bItemID = row["bItemID"].ToString();
                }
				if (row["bCode"] != null )
                {
					model.bCode = row["bCode"].ToString();
                }
				if (row["bName"] != null )
                {
					model.bName = row["bName"].ToString();
                }
				if (row["bLinkMan"] != null )
                {
					model.bLinkMan = row["bLinkMan"].ToString();
                }
				if (row["bTel"] != null )
                {
					model.bTel = row["bTel"].ToString();
                }
				if (row["bFax"] != null )
                {
					model.bFax = row["bFax"].ToString();
                }
				if (row["bEmail"] != null )
                {
					model.bEmail = row["bEmail"].ToString();
                }
				if (row["bNote"] != null )
                {
					model.bNote = row["bNote"].ToString();
                }
				if (row["bAppendTime"] != null )
                {
					model.bAppendTime = DateTime.Parse(row["bAppendTime"].ToString());
                }
				if (row["bState"] != null )
                {
					model.bState = bool.Parse(row["bState"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet BranchInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(BranchInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(BranchInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(BranchInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet BranchInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(BranchInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(BranchInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(BranchInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int BranchInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(BranchInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(BranchInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet BranchInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(BranchInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(BranchInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable BranchInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "BranchID")
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
            parameters[0].Value = "BaseBranchInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(BranchInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
