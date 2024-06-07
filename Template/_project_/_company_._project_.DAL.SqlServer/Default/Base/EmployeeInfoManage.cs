using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using _company_._project_.Entity;
using _company_._project_.DAL;
namespace _company_._project_.DAL.SqlServer
{
    public partial class EmployeeInfoManage : IEmployeeInfoManage
    {
        ///表链接
        private const string EmployeeInfoConnectionName = "BaseDb";
        ///表名称
        private const string EmployeeInfoTableName = "BaseEmployeeInfo";
        ///表字段
        private const string EmployeeInfoTableField = "EmployeeID,SystemID,BranchID,UserID,eItemID,eName,eSex,eMarry,eBirthday,DepartmentID,JobPositionID,JPName,IsManager,IsCheckManager,IsSelf,eEntry,eEmail,eTel,eQQ,eMob,ePhotoImage,eState,eAppendTime";
        //添加用表字段
        private const string EmployeeInfoTableFieldForAdd = "SystemID,BranchID,UserID,eItemID,eName,eSex,eMarry,eBirthday,DepartmentID,JobPositionID,JPName,IsManager,IsCheckManager,IsSelf,eEntry,eEmail,eTel,eQQ,eMob,ePhotoImage,eState,eAppendTime";
        //添加用表字段value
        private const string EmployeeInfoTableFieldAltForAdd = "@SystemID,@BranchID,@UserID,@eItemID,@eName,@eSex,@eMarry,@eBirthday,@DepartmentID,@JobPositionID,@JPName,@IsManager,@IsCheckManager,@IsSelf,@eEntry,@eEmail,@eTel,@eQQ,@eMob,@ePhotoImage,@eState,@eAppendTime";
		/// <summary>
        /// 增加一条数据
        /// </summary>
        public int EmployeeInfo_Add(EmployeeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ");
            strSql.Append(EmployeeInfoTableName);
			strSql.Append(" (");
            strSql.Append(EmployeeInfoTableFieldForAdd);
            strSql.Append(") values (");
            strSql.Append(EmployeeInfoTableFieldAltForAdd);
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@UserID", SqlDbType.Int,4),
 new SqlParameter("@eItemID", SqlDbType.VarChar,50),
 new SqlParameter("@eName", SqlDbType.VarChar,50),
 new SqlParameter("@eSex", SqlDbType.VarChar,50),
 new SqlParameter("@eMarry", SqlDbType.VarChar,50),
 new SqlParameter("@eBirthday", SqlDbType.VarChar,50),
 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@JobPositionID", SqlDbType.Int,4),
 new SqlParameter("@JPName", SqlDbType.VarChar,50),
 new SqlParameter("@IsManager", SqlDbType.Bit,1),
 new SqlParameter("@IsCheckManager", SqlDbType.Bit,1),
 new SqlParameter("@IsSelf", SqlDbType.Bit,1),
 new SqlParameter("@eEntry", SqlDbType.VarChar,50),
 new SqlParameter("@eEmail", SqlDbType.VarChar,50),
 new SqlParameter("@eTel", SqlDbType.VarChar,50),
 new SqlParameter("@eQQ", SqlDbType.VarChar,50),
 new SqlParameter("@eMob", SqlDbType.VarChar,50),
 new SqlParameter("@ePhotoImage", SqlDbType.Image,2147483647),
 new SqlParameter("@eState", SqlDbType.Bit,1),
 new SqlParameter("@eAppendTime", SqlDbType.DateTime,16)

					};
			 parameters[0].Value = model.SystemID;
 parameters[1].Value = model.BranchID;
 parameters[2].Value = model.UserID;
 parameters[3].Value = model.eItemID;
 parameters[4].Value = model.eName;
 parameters[5].Value = model.eSex;
 parameters[6].Value = model.eMarry;
 parameters[7].Value = model.eBirthday;
 parameters[8].Value = model.DepartmentID;
 parameters[9].Value = model.JobPositionID;
 parameters[10].Value = model.JPName;
 parameters[11].Value = model.IsManager;
 parameters[12].Value = model.IsCheckManager;
 parameters[13].Value = model.IsSelf;
 parameters[14].Value = model.eEntry;
 parameters[15].Value = model.eEmail;
 parameters[16].Value = model.eTel;
 parameters[17].Value = model.eQQ;
 parameters[18].Value = model.eMob;
 parameters[19].Value = model.ePhotoImage;
 parameters[20].Value = model.eState;
 parameters[21].Value = model.eAppendTime;

            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(EmployeeInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool EmployeeInfo_Update(EmployeeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ");
            strSql.Append(EmployeeInfoTableName);
            strSql.Append(" set ");
			strSql.Append("SystemID=@SystemID,");
strSql.Append("BranchID=@BranchID,");
strSql.Append("UserID=@UserID,");
strSql.Append("eItemID=@eItemID,");
strSql.Append("eName=@eName,");
strSql.Append("eSex=@eSex,");
strSql.Append("eMarry=@eMarry,");
strSql.Append("eBirthday=@eBirthday,");
strSql.Append("DepartmentID=@DepartmentID,");
strSql.Append("JobPositionID=@JobPositionID,");
strSql.Append("JPName=@JPName,");
strSql.Append("IsManager=@IsManager,");
strSql.Append("IsCheckManager=@IsCheckManager,");
strSql.Append("IsSelf=@IsSelf,");
strSql.Append("eEntry=@eEntry,");
strSql.Append("eEmail=@eEmail,");
strSql.Append("eTel=@eTel,");
strSql.Append("eQQ=@eQQ,");
strSql.Append("eMob=@eMob,");
strSql.Append("ePhotoImage=@ePhotoImage,");
strSql.Append("eState=@eState,");
strSql.Append("eAppendTime=@eAppendTime");

            strSql.Append(" where EmployeeID=@EmployeeID");
            SqlParameter[] parameters = {
				 new SqlParameter("@EmployeeID", SqlDbType.Int,4),
 new SqlParameter("@SystemID", SqlDbType.Int,4),
 new SqlParameter("@BranchID", SqlDbType.Int,4),
 new SqlParameter("@UserID", SqlDbType.Int,4),
 new SqlParameter("@eItemID", SqlDbType.VarChar,50),
 new SqlParameter("@eName", SqlDbType.VarChar,50),
 new SqlParameter("@eSex", SqlDbType.VarChar,50),
 new SqlParameter("@eMarry", SqlDbType.VarChar,50),
 new SqlParameter("@eBirthday", SqlDbType.VarChar,50),
 new SqlParameter("@DepartmentID", SqlDbType.Int,4),
 new SqlParameter("@JobPositionID", SqlDbType.Int,4),
 new SqlParameter("@JPName", SqlDbType.VarChar,50),
 new SqlParameter("@IsManager", SqlDbType.Bit,1),
 new SqlParameter("@IsCheckManager", SqlDbType.Bit,1),
 new SqlParameter("@IsSelf", SqlDbType.Bit,1),
 new SqlParameter("@eEntry", SqlDbType.VarChar,50),
 new SqlParameter("@eEmail", SqlDbType.VarChar,50),
 new SqlParameter("@eTel", SqlDbType.VarChar,50),
 new SqlParameter("@eQQ", SqlDbType.VarChar,50),
 new SqlParameter("@eMob", SqlDbType.VarChar,50),
 new SqlParameter("@ePhotoImage", SqlDbType.Image,2147483647),
 new SqlParameter("@eState", SqlDbType.Bit,1),
 new SqlParameter("@eAppendTime", SqlDbType.DateTime,16)

			};
			 parameters[0].Value = model.EmployeeID;
 parameters[1].Value = model.SystemID;
 parameters[2].Value = model.BranchID;
 parameters[3].Value = model.UserID;
 parameters[4].Value = model.eItemID;
 parameters[5].Value = model.eName;
 parameters[6].Value = model.eSex;
 parameters[7].Value = model.eMarry;
 parameters[8].Value = model.eBirthday;
 parameters[9].Value = model.DepartmentID;
 parameters[10].Value = model.JobPositionID;
 parameters[11].Value = model.JPName;
 parameters[12].Value = model.IsManager;
 parameters[13].Value = model.IsCheckManager;
 parameters[14].Value = model.IsSelf;
 parameters[15].Value = model.eEntry;
 parameters[16].Value = model.eEmail;
 parameters[17].Value = model.eTel;
 parameters[18].Value = model.eQQ;
 parameters[19].Value = model.eMob;
 parameters[20].Value = model.ePhotoImage;
 parameters[21].Value = model.eState;
 parameters[22].Value = model.eAppendTime;

            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(EmployeeInfoConnectionName),CommandType.Text,strSql.ToString(), parameters);
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
        public bool EmployeeInfo_Delete(Int32 employeeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(EmployeeInfoTableName);
            strSql.Append(" where EmployeeID=@EmployeeID");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.Int, 4)
			};
            parameters[0].Value = employeeID;
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(EmployeeInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
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
        public bool EmployeeInfo_DeleteList(string employeeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ");
            strSql.Append(EmployeeInfoTableName);
            strSql.Append(" where EmployeeID in (" + employeeIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(DbConfig.GetDbInfo(EmployeeInfoConnectionName), CommandType.Text,strSql.ToString());
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
        public EmployeeInfo EmployeeInfo_GetModel(Int32 employeeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(EmployeeInfoTableField);
            strSql.Append(" from ");
            strSql.Append(EmployeeInfoTableName);
            strSql.Append(" where EmployeeID=@EmployeeID");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.Int, 4)
			};
            parameters[0].Value = employeeID;
            EmployeeInfo model = new EmployeeInfo();
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(EmployeeInfoConnectionName), CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return EmployeeInfo_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmployeeInfo EmployeeInfo_DataRowToModel(DataRow row)
        {
            EmployeeInfo model = new EmployeeInfo();
            if (row != null)
            {
				if (row["EmployeeID"] != null )
                {
                        model.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                }
				if (row["SystemID"] != null )
                {
                        model.SystemID = int.Parse(row["SystemID"].ToString());
                }
				if (row["BranchID"] != null )
                {
                        model.BranchID = int.Parse(row["BranchID"].ToString());
                }
				if (row["UserID"] != null )
                {
                        model.UserID = int.Parse(row["UserID"].ToString());
                }
				if (row["eItemID"] != null )
                {
					model.eItemID = row["eItemID"].ToString();
                }
				if (row["eName"] != null )
                {
					model.eName = row["eName"].ToString();
                }
				if (row["eSex"] != null )
                {
					model.eSex = row["eSex"].ToString();
                }
				if (row["eMarry"] != null )
                {
					model.eMarry = row["eMarry"].ToString();
                }
				if (row["eBirthday"] != null )
                {
					model.eBirthday = row["eBirthday"].ToString();
                }
				if (row["DepartmentID"] != null )
                {
                        model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
				if (row["JobPositionID"] != null )
                {
                        model.JobPositionID = int.Parse(row["JobPositionID"].ToString());
                }
				if (row["JPName"] != null )
                {
					model.JPName = row["JPName"].ToString();
                }
				if (row["IsManager"] != null )
                {
					model.IsManager = bool.Parse(row["IsManager"].ToString());
                }
				if (row["IsCheckManager"] != null )
                {
					model.IsCheckManager = bool.Parse(row["IsCheckManager"].ToString());
                }
				if (row["IsSelf"] != null )
                {
					model.IsSelf = bool.Parse(row["IsSelf"].ToString());
                }
				if (row["eEntry"] != null )
                {
					model.eEntry = row["eEntry"].ToString();
                }
				if (row["eEmail"] != null )
                {
					model.eEmail = row["eEmail"].ToString();
                }
				if (row["eTel"] != null )
                {
					model.eTel = row["eTel"].ToString();
                }
				if (row["eQQ"] != null )
                {
					model.eQQ = row["eQQ"].ToString();
                }
				if (row["eMob"] != null )
                {
					model.eMob = row["eMob"].ToString();
                }
				if (row["ePhotoImage"] != null )
                {
					model.ePhotoImage = row["ePhotoImage"].ToString() != "" ?  (byte[])row["ePhotoImage"] : null;
                }
				if (row["eState"] != null )
                {
					model.eState = bool.Parse(row["eState"].ToString());
                }
				if (row["eAppendTime"] != null )
                {
					model.eAppendTime = DateTime.Parse(row["eAppendTime"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet EmployeeInfo_GetList(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(EmployeeInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(EmployeeInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(EmployeeInfoConnectionName), CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet EmployeeInfo_GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString() + " ");
            }
            strSql.Append(EmployeeInfoTableField);
            strSql.Append(" FROM ");
            strSql.Append(EmployeeInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(EmployeeInfoConnectionName),CommandType.Text,strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int EmployeeInfo_GetRecordCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ");
            strSql.Append(EmployeeInfoTableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(DbConfig.GetDbInfo(EmployeeInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataSet EmployeeInfo_GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
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
            strSql.Append(EmployeeInfoTableName);
            strSql.Append(" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between " + startIndex + " and " + endIndex);
            return DbHelper.ExecuteDataset(DbConfig.GetDbInfo(EmployeeInfoConnectionName),CommandType.Text,strSql.ToString());
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
        public DataTable EmployeeInfo_GetListByPage(int pageSize, int pageIndex, string strWhere, out int pagetotal, out int total, int orderType = 1, string showName = "*", string orderKey = "EmployeeID")
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
            parameters[0].Value = "BaseEmployeeInfo";
            parameters[1].Value = orderKey;
            parameters[2].Value = pageSize;
            parameters[3].Value = pageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = orderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showName;
            DataSet ds = DbHelper.ExecuteDataset(DbConfig.GetDbInfo(EmployeeInfoConnectionName),CommandType.StoredProcedure, "UP_GetRecordByPage", parameters);
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
