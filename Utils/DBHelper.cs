using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ZSN.CodeGenerator;

namespace ZNS.CodeGenerator.Utils
{
    public class DbHelper
    {
        public ServerInfo Server = null;

        /// <summary>
        /// 返回连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnectionStr()
        {
            string connStr = "";
            if (Server.IsSqlServer)
                connStr =
                    "Data Source=" + Server.ServerIp + ";User ID=" + Server.ServerUser + ";Password=" + Server.ServerPwd + ";Initial Catalog=" + Server.ServerDbName + ";Pooling=true;Max Pool Size=300;Min Pool Size=0;Connection Lifetime=300;Connect Timeout=1000;";
            else if (Server.IsMySql)
                connStr =
                    $"server={Server.ServerIp};userid={Server.ServerUser};password={Server.ServerPwd};database={Server.ServerDbName}";

            return connStr;
        }

        /// <summary>
        /// 返回所有数据库名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDbName()
        {
            try
            {
                List<string> dbNameList = new List<string>();
                DataTable dbNameTable = new DataTable();

                var strConnection = GetConnectionStr();

                if (Server.IsSqlServer)
                {
                    var conn = new SqlConnection(strConnection);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("select name from master..sysdatabases", conn);
                        lock (adapter)
                        {
                            adapter.Fill(dbNameTable);
                        }

                        foreach (DataRow row in dbNameTable.Rows)
                        {
                            dbNameList.Add(row["name"].ToString());
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
                else if (Server.IsMySql)
                {

                    var sql = "show databases";
                    //连接数据库
                    using (MySqlConnection msconnection = new MySqlConnection(strConnection))
                    {
                        msconnection.Open();
                        //查找数据库里面的表
                        MySqlCommand mscommand = new MySqlCommand(sql, msconnection);
                        using (MySqlDataReader reader = mscommand.ExecuteReader())
                        {
                            //读取数据
                            while (reader.Read())
                            {
                                dbNameList.Add(reader.GetString("Database"));
                            }
                        }
                    }
                }
                return dbNameList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 返回所有表名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllTable()
        {
            try
            {
                List<string> tableList = new List<string>();
                var strConnection = GetConnectionStr();

                if (Server.IsSqlServer)
                {
                    var conn = new SqlConnection(strConnection);
                    conn.Open();
                    try
                    {
                        SqlCommand sqlcmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", conn);
                        SqlDataReader dr = sqlcmd.ExecuteReader();
                        while (dr.Read())
                        {
                            tableList.Add(dr.GetString(0));
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
                else if (Server.IsMySql)
                {
                    var sql = $@"SELECT
                    table_name
                        FROM
                    information_schema.`TABLES`
                    WHERE
                        TABLE_SCHEMA = '{Server.ServerDbName}'; ";
                    //连接数据库
                    using (MySqlConnection msconnection = new MySqlConnection(strConnection))
                    {
                        msconnection.Open();
                        //查找数据库里面的表
                        MySqlCommand mscommand = new MySqlCommand(sql, msconnection);
                        using (MySqlDataReader reader = mscommand.ExecuteReader())
                        {
                            //读取数据
                            while (reader.Read())
                            {
                                tableList.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                return tableList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 返回单表所有字段信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetAllField(string tableName)
        {
            if (tableName.IndexOf("ACT_ID") == 0)
            {
                var a = 1;
            }
            DataTable dt = new DataTable();

            dt.Columns.Add("FieldName", typeof(System.String)); // 字段名称
            dt.Columns.Add("FieldCSName", typeof(System.String)); // 字段c#合格名称
            dt.Columns.Add("FieldType", typeof(System.String)); // 数据库字段类型
            dt.Columns.Add("CSharpType", typeof(System.String)); // 对应c#类型
            dt.Columns.Add("IsNull", typeof(System.String)); // 是否为空
            dt.Columns.Add("IsPKey", typeof(System.String)); // 是否主键
            dt.Columns.Add("IsIdentity", typeof(System.String)); // 是否自增
            dt.Columns.Add("FieldDEF", typeof(System.String)); // 默认值
            dt.Columns.Add("FieldLength", typeof(System.String)); // 长度
            dt.Columns.Add("DefaultValue", typeof(System.String)); // c# 默认值

            try
            {
                var strConnection = GetConnectionStr();

                if (Server.IsSqlServer)
                {
                    var conn = new SqlConnection(strConnection);
                    conn.Open();
                    try
                    {
                        DataSet ds = new DataSet();
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {

                            string sql = "exec sp_columns @table_Name='" + tableName + "';" +
                                          "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" + tableName + "';";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                sda.SelectCommand = cmd;
                                sda.Fill(ds);

                                var hasPk = false;

                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    var dr = dt.NewRow();
                                    dr["FieldName"] = row["COLUMN_NAME"].ToString();
                                    dr["FieldType"] = GetSqlType(row["TYPE_NAME"].ToString());
                                    dr["CSharpType"] = GetSqlServerCsType(row["TYPE_NAME"].ToString());
                                    dr["IsNull"] = row["NULLABLE"].ToString() == "1" ? "y" : "x";
                                    dr["FieldDEF"] = row["COLUMN_DEF"].ToString();
                                    dr["FieldLength"] = row["LENGTH"].ToString();
                                    dr["IsPKey"] = "x";
                                    dr["IsIdentity"] = row["TYPE_NAME"].ToString().Contains("identity") ? "y" : "x";
                                    dr["DefaultValue"] = "";
                                    dr["FieldCSName"] = dr["FieldName"].ToString().ToCSharpName();
                                    foreach (DataRow drr in ds.Tables[1].Rows)
                                    {
                                        if (drr["COLUMN_NAME"].ToString() == row["COLUMN_NAME"].ToString())
                                        {
                                            dr["IsPKey"] = "y";
                                            hasPk = true;
                                        }
                                    }

                                    SetSqlTypeDefaultAndNullable(dr);
                                    dt.Rows.Add(dr);
                                }

                                if (!hasPk)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        dt.Rows[0]["IsPKey"] = "y";
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (Server.IsMySql)
                {
                    var sql = $@"SELECT * FROM information_schema.`COLUMNS` where TABLE_SCHEMA = '{Server.ServerDbName}' and TABLE_NAME = '{tableName}';";
                    //连接数据库
                    using (var msconnection = new MySqlConnection(strConnection))
                    {
                        msconnection.Open();
                        //查找数据库里面的表
                        var command = new MySqlCommand(sql, msconnection);
                        var hasPK = false;
                        using (var reader = command.ExecuteReader())
                        {
                            //读取数据
                            while (reader.Read())
                            {
                                var dr = dt.NewRow();
                                dr["FieldName"] = reader["COLUMN_NAME"].ToString();
                                dr["FieldType"] = GetSqlType(reader["DATA_TYPE"].ToString());
                                dr["CSharpType"] = this.GetMySqlCsType(reader["DATA_TYPE"].ToString());
                                dr["IsNull"] = reader["IS_NULLABLE"].ToString().ToLower() == "yes" ? "y" : "x";
                                dr["FieldDEF"] = reader["COLUMN_DEFAULT"].ToString();
                                dr["FieldLength"] = string.IsNullOrWhiteSpace(reader["NUMERIC_PRECISION"].ToString()) ? reader["CHARACTER_MAXIMUM_LENGTH"].ToString() : reader["NUMERIC_PRECISION"].ToString();
                                dr["IsPKey"] = reader["COLUMN_KEY"].ToString() == "PRI" ? "y" : "x";
                                dr["IsIdentity"] = reader["EXTRA"].ToString().Contains("auto_increment") ? "y" : "x";
                                if (dr["IsPKey"].ToString() == "y")
                                {
                                    hasPK = true;
                                }
                                dr["DefaultValue"] = "";
                                dr["FieldCSName"] = dr["FieldName"].ToString().ToCSharpName();
                                SetSqlTypeDefaultAndNullable(dr);
                                if (dr["CSharpType"].ToString().ToLower() == "datetime" && dr["FieldLength"].ToString() == "")
                                {
                                    dr["FieldLength"] = "16";
                                }
                                dt.Rows.Add(dr);
                            }

                            if (!hasPK)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dt.Rows[0]["IsPKey"] = "y";
                                    break;
                                }
                            }
                        }
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 获得c#对应的类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public string GetSqlServerCsType(string dbType)
        {
            string csType;
            dbType = dbType.ToLower().Replace(" identity", "").Trim();
            switch (dbType)
            {
                case "varchar":
                case "varchar2":
                case "nvarchar":
                case "nvarchar2":
                case "char":
                case "nchar":
                case "text":
                case "longtext":
                case "string":
                case "ntext":
                    csType = "string";
                    break;

                case "date":
                case "time":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                case "datetimeoffset":
                case "timestamp":
                    csType = "DateTime";
                    break;

                case "int":
                case "number":
                case "smallint":
                case "integer":
                    csType = "Int32";
                    break;

                case "bigint":
                    csType = "Int64";
                    break;

                case "float":
                case "numeric":
                case "numeric()":
                case "decimal":
                case "money":
                case "smallmoney":
                case "real":
                case "double":
                    csType = "Decimal";
                    break;
                case "tinyint":
                    csType = "short";
                    break;
                case "bit":
                    csType = "bool";
                    break;

                case "binary":
                case "varbinary":
                case "image":
                case "raw":
                case "long":
                case "long raw":
                case "blob":
                case "bfile":
                    csType = "byte[]";
                    break;

                case "unique identifier":
                case "uniqueidentifier":
                    csType = "string";
                    break;

                case "xml":
                case "json":
                case "udt":
                    csType = "string";
                    break;
                case "variant":
                case "structured":
                    csType = "object";
                    break;
                default:
                    csType = "object";
                    break;
            }
            return csType;
        }

        public string GetMySqlCsType(string dbType)
        {
            string csType;
            dbType = dbType.ToLower().Replace(" identity", "").Trim();
            switch (dbType)
            {
                case "varchar":
                case "varchar2":
                case "nvarchar":
                case "nvarchar2":
                case "char":
                case "nchar":
                case "text":
                case "longtext":
                case "string":
                case "ntext":
                case "mediumtext":
                    csType = "string";
                    break;

                case "date":
                case "time":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                case "datetimeoffset":
                case "timestamp":
                    csType = "DateTime";
                    break;

                case "int":
                case "int32":
                case "number":
                case "smallint":
                case "integer":
                    csType = "Int32";
                    break;

                case "bigint":
                case "int64":
                    csType = "Int64";
                    break;

                case "float":
                case "numeric":
                case "decimal":
                case "money":
                case "smallmoney":
                case "real":
                case "double":
                    csType = "Decimal";
                    break;
                case "tinyint":
                case "byte":
                case "bit":
                    csType = "bool";
                    break;

                case "binary":
                case "varbinary":
                case "image":
                case "raw":
                case "long":
                case "long raw":
                case "blob":
                case "bfile":
                case "longblob":
                    csType = "byte[]";
                    break;

                case "unique identifier":
                    csType = "Guid";
                    break;

                case "xml":
                case "json":
                case "udt":
                    csType = "string";
                    break;
                case "variant":
                case "structured":
                    csType = "object";
                    break;
                default:
                    csType = "object";
                    break;
            }
            return csType;
        }
        /// <summary>
        /// 获得sql类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public string GetSqlType(string dbType)
        {
            dbType = dbType.ToLower().Replace(" identity", "").Trim();
            dbType = dbType.Replace("numeric()", "decimal");
            dbType = dbType.Replace("numeric", "decimal");
            if (Server.IsSqlServer)
            {
                var sqlDbTypeList = new List<string>
                {
                    "BigInt",
                    "Binary",
                    "Bit",
                    "Char",
                    "DateTime",
                    "Decimal",
                    "Float",
                    "Image",
                    "Int",
                    "Money",
                    "NChar",
                    "NText",
                    "NVarChar",
                    "Real",
                    "UniqueIdentifier",
                    "SmallDateTime",
                    "SmallInt",
                    "SmallMoney",
                    "Text",
                    "Timestamp",
                    "TinyInt",
                    "VarBinary",
                    "VarChar",
                    "Variant",
                    "Xml",
                    "Udt",
                    "Structured",
                    "Date ",
                    "Time",
                    "DateTime2",
                    "DateTimeOffset",
                };
                return sqlDbTypeList.FirstOrDefault(t => t.ToLower() == dbType) ?? dbType.ToFirstUpper();
            }
            else
            {
                switch (dbType.ToLower())
                {
                    case "tinyint":
                        dbType = "byte";
                        break;
                    case "int":
                        dbType = "int32";
                        break;
                    case "bigint":
                        dbType = "int64";
                        break;
                    case "char":
                        dbType = "varchar";
                        break;
                }
                var mySqlDbTypeList = new List<string>
                {
                    "Decimal",
                    "Byte",
                    "Int16",
                    "Int32",
                    "Float",
                    "Double",
                    "Timestamp",
                    "Int64",
                    "Int24",
                    "Date",
                    "Time",
                    "DateTime",
                    "Datetime",
                    "Year",
                    "Newdate",
                    "VarString",
                    "Bit",
                    "JSON",
                    "NewDecimal",
                    "Enum",
                    "Set",
                    "TinyBlob",
                    "MediumBlob",
                    "LongBlob",
                    "Blob",
                    "VarChar",
                    "String",
                    "Geometry",
                    "UByte",
                    "UInt16",
                    "UInt32",
                    "UInt64",
                    "UInt24",
                    "TinyText",
                    "MediumText",
                    "LongText",
                    "Text",
                    "VarBinary",
                    "Binary",
                    "Guid"
                };
                return mySqlDbTypeList.FirstOrDefault(t => t.ToLower() == dbType) ?? dbType.ToFirstUpper();
            }
        }

        /// <summary>
        /// 设置默认值和类型可空
        /// </summary>
        /// <param name="dr"></param>
        public void SetSqlTypeDefaultAndNullable(DataRow dr)
        {
            var ct = dr["CSharpType"].ToString().ToLower();
            var df = dr["FieldDEF"].ToString().Trim().ToLower();

            if (ct == "datetime")
            {
                if (df == "(getdate())" || df == "CURRENT_TIMESTAMP".ToLower())
                {
                    dr["DefaultValue"] = " = DateTime.Now; ";
                }
            }
            if (ct == "bool")
            {
                if (df == "((1))" || df == "1")
                {
                    dr["DefaultValue"] = " = true; ";
                }
                else if (df == "((0))" || df == "0")
                {
                    dr["DefaultValue"] = " = false; ";
                }
            }

            if (ct == "int64" || ct == "int32" || ct == "decimal")
            {
                if (df != "" && df != "('')")
                    dr["DefaultValue"] = $" = ({dr["CSharpType"]})({df}); ";
            }

            if (ct == "string")
            {
                if (df != "")
                {
                    var str = df.Replace("('", "").Replace("')", "");
                    dr["DefaultValue"] = $" = \"{str}\"; ";
                }
                else if (dr["IsNull"].ToString().ToLower() == "x")
                {
                    dr["DefaultValue"] = " = string.Empty; ";
                }
            }

            // 支持可空类型
            var objList = new List<string>
            {
                "byte[]", "Guid", "string"
            };

            if (dr["IsNull"].ToString().ToLower() == "y" && !objList.Contains(ct))
            {
                dr["CSharpType"] = dr["CSharpType"] + "?";
            }

        }
    }


    /// <summary>   
    /// SqlHelperParameterCache提供缓存存储过程参数,并能够在运行时从存储过程中探索参数.   
    /// </summary>   
    public sealed class SqlHelperParameterCache
    {
        #region 私有方法,字段,构造函数
        // 私有构造函数,妨止类被实例化.   
        private SqlHelperParameterCache() { }

        // 这个方法要注意   
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>   
        /// 探索运行时的存储过程,返回SqlParameter参数数组.   
        /// 初始化参数值为 DBNull.Value.   
        /// </summary>   
        /// <param name="connection">一个有效的数据库连接</param>   
        /// <param name="spName">存储过程名称</param>   
        /// <param name="includeReturnValueParameter">是否包含返回值参数</param>   
        /// <returns>返回SqlParameter参数数组</returns>   
        private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            SqlCommand cmd = new SqlCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            // 检索cmd指定的存储过程的参数信息,并填充到cmd的Parameters参数集中.   
            SqlCommandBuilder.DeriveParameters(cmd);
            connection.Close();
            // 如果不包含返回值参数,将参数集中的每一个参数删除.   
            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            // 创建参数数组   
            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
            // 将cmd的Parameters参数集复制到discoveredParameters数组.   
            cmd.Parameters.CopyTo(discoveredParameters, 0);

            // 初始化参数值为 DBNull.Value.   
            foreach (SqlParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        /// <summary>   
        /// SqlParameter参数数组的深层拷贝.   
        /// </summary>   
        /// <param name="originalParameters">原始参数数组</param>   
        /// <returns>返回一个同样的参数数组</returns>   
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion 私有方法,字段,构造函数结束

        #region 缓存方法

        /// <summary>   
        /// 追加参数数组到缓存.   
        /// </summary>   
        /// <param name="connectionString">一个有效的数据库连接字符串</param>   
        /// <param name="commandText">存储过程名或SQL语句</param>   
        /// <param name="commandParameters">要缓存的参数数组</param>   
        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>   
        /// 从缓存中获取参数数组.   
        /// </summary>   
        /// <param name="connectionString">一个有效的数据库连接字符</param>   
        /// <param name="commandText">存储过程名或SQL语句</param>   
        /// <returns>参数数组</returns>   
        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            SqlParameter[] cachedParameters = paramCache[hashKey] as SqlParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion 缓存方法结束

        #region 检索指定的存储过程的参数集

        /// <summary>   
        /// 返回指定的存储过程的参数集   
        /// </summary>   
        /// <remarks>   
        /// 这个方法将查询数据库,并将信息存储到缓存.   
        /// </remarks>   
        /// <param name="connectionString">一个有效的数据库连接字符</param>   
        /// <param name="spName">存储过程名</param>   
        /// <returns>返回SqlParameter参数数组</returns>   
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// <summary>   
        /// 返回指定的存储过程的参数集   
        /// </summary>   
        /// <remarks>   
        /// 这个方法将查询数据库,并将信息存储到缓存.   
        /// </remarks>   
        /// <param name="connectionString">一个有效的数据库连接字符.</param>   
        /// <param name="spName">存储过程名</param>   
        /// <param name="includeReturnValueParameter">是否包含返回值参数</param>   
        /// <returns>返回SqlParameter参数数组</returns>   
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>   
        /// [内部]返回指定的存储过程的参数集(使用连接对象).   
        /// </summary>   
        /// <remarks>   
        /// 这个方法将查询数据库,并将信息存储到缓存.   
        /// </remarks>   
        /// <param name="connection">一个有效的数据库连接字符</param>   
        /// <param name="spName">存储过程名</param>   
        /// <returns>返回SqlParameter参数数组</returns>   
        internal static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>   
        /// [内部]返回指定的存储过程的参数集(使用连接对象)   
        /// </summary>   
        /// <remarks>   
        /// 这个方法将查询数据库,并将信息存储到缓存.   
        /// </remarks>   
        /// <param name="connection">一个有效的数据库连接对象</param>   
        /// <param name="spName">存储过程名</param>   
        /// <param name="includeReturnValueParameter">   
        /// 是否包含返回值参数   
        /// </param>   
        /// <returns>返回SqlParameter参数数组</returns>   
        internal static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            using (SqlConnection clonedConnection = (SqlConnection)((ICloneable)connection).Clone())
            {
                return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>   
        /// [私有]返回指定的存储过程的参数集(使用连接对象)   
        /// </summary>   
        /// <param name="connection">一个有效的数据库连接对象</param>   
        /// <param name="spName">存储过程名</param>   
        /// <param name="includeReturnValueParameter">是否包含返回值参数</param>   
        /// <returns>返回SqlParameter参数数组</returns>   
        private static SqlParameter[] GetSpParameterSetInternal(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

            SqlParameter[] cachedParameters;

            cachedParameters = paramCache[hashKey] as SqlParameter[];
            if (cachedParameters == null)
            {
                SqlParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }

            return CloneParameters(cachedParameters);
        }

        #endregion 参数集检索结束
    }
}
