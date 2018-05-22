using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.OleDb;

namespace thesis.common
{
    public abstract class DbHelperSQL
    {

        public DbHelperSQL()
        {
        }
        /// <summary>
        /// 获得数据库所有表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDatabaseSchema()
        {
            DbConnection connection = ConnectionMgr.GetConnection();
            try
            {
                connection.Open();
                DataTable dt = connection.GetSchema("Tables", new string[] { null, null, null, "Table" });
                return dt;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw e;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

        }
        /// <summary>
        /// 获得表的所有字段信息
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataTable GetTableSchema(String table)
        {
            DbConnection connection = ConnectionMgr.GetConnection();
            try
            {
                connection.Open();
                DataTable dt = connection.GetSchema("Columns", new string[] { null, null, table });
                return dt;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw e;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

        }
        #region 公用方法
        /// <summary>
        /// 将时间转化为相应的sql表示形式
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetDateTimeSQL(DateTime t)
        {
            string ret = "";
            switch (ConnectionMgr.ConnInfo.DatabaseType)
            {
                case ConnectionInfo.DB_SQL:
                    ret = "'" + t.ToString("yyyy-MM-dd HH:mm:ss") + "'"; break;
                case ConnectionInfo.DB_ORA:
                    ret = "to_date('" + t.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')"; break;
                case ConnectionInfo.DB_SYB:
                    ret = "'" + t.ToString("yyyy-MM-dd HH:mm:ss") + "'"; break;
                case ConnectionInfo.DB_DB2:
                    ret = "'" + t.ToString("yyyy-MM-dd-HH.mm.ss") + "'";
                    break;
                case ConnectionInfo.DB_ACS:
                    ret = "#" + t.ToString("yyyy-MM-dd HH.mm.ss") + "#";
                    break;
                default: ret = "'" + t.ToString("yyyy-MM-dd HH:mm:ss") + "'"; break;

            }
            return ret;
        }
        /// <summary>
        /// 获得服务器端时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            int DatabaseType = ConnectionMgr.ConnInfo.DatabaseType;
            if (DatabaseType == ConnectionInfo.DB_ACS) return DateTime.Now;
            string sql = "";
            switch (ConnectionMgr.ConnInfo.DatabaseType)
            {

                case ConnectionInfo.DB_SQL: sql = "select GETDATE() as dates "; break;
                case ConnectionInfo.DB_ORA: sql = "select SYSDATE as dates from dual "; break;
                case ConnectionInfo.DB_SYB: sql = "select GETDATE() as dates from SPECIES10 "; break;
                case ConnectionInfo.DB_DB2: sql = "select CURRENT TIMESTAMP as dates from SPECIES10 "; break;

            }
            return (DateTime)GetSingle(sql);
        }
        /// <summary>
        /// 获得取服务器端当前时间的sql函数名
        /// </summary>
        /// <returns></returns>
        public static string GetDbTimeFunctionName()
        {
            string func = "";
            switch (ConnectionMgr.ConnInfo.DatabaseType)
            {
                case ConnectionInfo.DB_SQL: func = "GETDATE()"; break;
                case ConnectionInfo.DB_ORA: func = "SYSDATE"; break;
                case ConnectionInfo.DB_SYB: func = "GETDATE()"; break;
                case ConnectionInfo.DB_DB2: func = "CURRENT TIMESTAMP"; break;
                case ConnectionInfo.DB_ACS: func = "NOW()"; break;
            }
            return func;
        }
        /// <summary>
        /// 取字段的最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static int GetMaxID()
        {
            string strsql = "SELECT SEQ_TREE_INDEX.NEXTVAL FROM DUAL";
            object obj = GetSingle(strsql);
            return int.Parse(obj.ToString());
        }

        #region zjl 获得tree的id
        public static int GetMaxID_Tree(string p)
        {
            string sql = "select max(species_id) from tree_web where species='" + p + "'";
            object obj = GetSingle(sql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static int GetMaxID_Tree2(string p)
        {
            string sql = "select max(species_id) from tree where species='" + p + "'";
            object obj = GetSingle(sql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        #endregion

        /// <summary>
        /// 判断是否存在记录
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                try
                {
                    connection.Open();
                    DbCommand cmd = BuildSQLCommand(connection, SQLString, null);
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (DbException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {

            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                connection.Open();
                DbTransaction trans = connection.BeginTransaction();
                try
                {
                    //执行语句
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            DbCommand cmd = BuildSQLCommand(connection, strsql, null);
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 带有超时设置的sql语句执行
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                using (DbCommand cmd = BuildSQLCommand(connection, SQLString, null))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (DbException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="Lists">需执行的多条SQL语句</param>
        /// <param name="Times">时限</param>
        /// <returns></returns>
        public static string ExecuteSqlByTran(List<string> Lists, int Times)
        {
            string message = "执行成功！";
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                connection.Open();
                DbCommand cmd = connection.CreateCommand();
                cmd.CommandTimeout = Times;
                DbTransaction tx = connection.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < Lists.Count; n++)
                    {
                        string strsql = Lists[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    message = e.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return message;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                connection.Open();
                DbCommand cmd = connection.CreateCommand();
                DbTransaction tx = connection.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #region 执行一个 特殊字段带参数的语句
        /// <summary>
        /// 执行带一个参数的的SQL语句。
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string strSql, string content)
        {
            using (DbConnection conn = ConnectionMgr.GetConnection())
            {
                int ret = 0;
                conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = strSql;
                DbParameter para = cmd.CreateParameter();
                para.Direction = ParameterDirection.Input;
                para.ParameterName = "@content";
                para.DbType = DbType.String;
                para.Value = content;
                try
                {
                    ret = cmd.ExecuteNonQuery();
                }
                catch (DbException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return ret;
            }
        }


        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSql, byte[] data)
        {
            using (OleDbConnection conn = ConnectionMgr.GetOleDbConnection())
            {
                int ret = 0;
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = strSql;
                OleDbParameter para = cmd.CreateParameter();
                para.Direction = ParameterDirection.Input;
                para.DbType = DbType.Binary;
                para.Value = data;
                cmd.Parameters.Add(para);
                try
                {
                    ret = cmd.ExecuteNonQuery();
                }
                catch (DbException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return ret;
            }
        }
        #endregion

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                using (DbCommand cmd = BuildSQLCommand(connection, SQLString, null))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (DbException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 获得一个结果值的查询
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static object GetSingle(string SQLString, int Times)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                using (DbCommand cmd = BuildSQLCommand(connection, SQLString, null))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (DbException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回DbDataReader ( 注意：使用后一定要对DbDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static DbDataReader ExecuteReader(string strSQL)
        {
            DbConnection connection = ConnectionMgr.GetConnection();
            DbCommand cmd = BuildSQLCommand(connection, strSQL, null);
            try
            {
                connection.Open();
                DbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (DbException e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    DbCommand cmd = BuildSQLCommand(connection, SQLString, null);
                    DbDataAdapter myReader = ConnectionMgr.CreateDbDataAdapter(cmd);
                    myReader.Fill(ds, "ds");
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        /// <summary>
        /// 带超时设置的数据查询
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    DbCommand cmd = BuildSQLCommand(connection, SQLString, null);
                    cmd.CommandTimeout = Times;
                    DbDataAdapter myReader = ConnectionMgr.CreateDbDataAdapter(cmd);
                    myReader.Fill(ds, "ds");
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        /// <summary>
        /// 带有图片数据的查询
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static DataSet QueryWithImageData(string SQLString)
        {
            using (OleDbConnection conn = ConnectionMgr.GetOleDbConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(SQLString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds, "ds");
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return ds;
            }
        }
        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string strSql, params CommonParameter[] cmdParms)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                int ret = 0;
                try
                {
                    connection.Open();
                    DbCommand cmd = BuildSQLCommand(connection, strSql, cmdParms);
                    ret = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return ret;
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {

            using (DbConnection dbconn = ConnectionMgr.GetConnection())
            {
                dbconn.Open();
                DbTransaction dbtran = dbconn.BeginTransaction();
                try
                {
                    //执行语句
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string strsql = myDE.Key.ToString();
                        CommonParameter[] cmdParms = (CommonParameter[])myDE.Value;
                        if (strsql.Trim().Length > 1)
                        {
                            DbCommand dbCommand = BuildSQLCommand(dbconn, strsql, cmdParms);
                            dbCommand.ExecuteNonQuery();
                        }
                    }
                    dbtran.Commit();
                }
                catch
                {
                    dbtran.Rollback();
                }
                finally
                {
                    dbconn.Close();
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="strSql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string strSql, params CommonParameter[] cmdParms)
        {
            using (DbConnection dbconn = ConnectionMgr.GetConnection())
            {
                DbCommand dbCommand = BuildSQLCommand(dbconn, strSql, cmdParms);
                try
                {
                    object obj = dbCommand.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (DbException ex)
                {
                    throw ex;
                }
                finally
                {
                    dbconn.Close();
                }

            }

        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：使用后一定要对DbDataReader进行Close )
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static DbDataReader ExecuteReader(string strSql, params CommonParameter[] cmdParms)
        {
            DbConnection connection = ConnectionMgr.GetConnection();
            DbCommand cmd = BuildSQLCommand(connection, strSql, cmdParms);
            try
            {
                connection.Open();
                DbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (DbException e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string strSql, params CommonParameter[] cmdParms)
        {

            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    DbCommand cmd = BuildSQLCommand(connection, strSql, cmdParms);
                    DbDataAdapter myReader = ConnectionMgr.CreateDbDataAdapter(cmd);
                    myReader.Fill(ds, "ds");
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        private static DbCommand BuildSQLCommand(DbConnection connection, string strSql, CommonParameter[] cmdParms)
        {
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            if (cmdParms != null)
            {
                foreach (CommonParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    DbParameter param = parameter.ConvertToDbParameter(cmd);
                    cmd.Parameters.Add(param);
                }
            }
            return cmd;
        }
        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>       
        public static int RunProcedure(string storedProcName)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                connection.Open();
                DbCommand command = BuildProcedureCommand(connection, storedProcName, null);
                int result = command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程，返回输出参数的值和影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="OutParameter">输出参数名称</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static object RunProcedure(string storedProcName, CommonParameter[] parameters, string OutParameterName, out int rowsAffected)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                DbCommand cmd = BuildProcedureCommand(connection, storedProcName, parameters);
                rowsAffected = cmd.ExecuteNonQuery();
                foreach (DbParameter param in cmd.Parameters)
                {
                    if (param.ParameterName == OutParameterName)
                    {
                        return param.Value;//得到输出参数的值
                    }
                }
                return null;
            }


        }

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DbDataReader</returns>
        public static DbDataReader RunProcedureReader(string storedProcName, CommonParameter[] parameters)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                DbCommand cmd = BuildProcedureCommand(connection, storedProcName, parameters);
                DbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }

        }

        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, CommonParameter[] parameters)
        {
            using (DbConnection connection = ConnectionMgr.GetConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    DbCommand cmd = BuildProcedureCommand(connection, storedProcName, parameters);
                    DbDataAdapter myReader = ConnectionMgr.CreateDbDataAdapter(cmd);
                    myReader.Fill(ds, "ds");
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }


        /// <summary>
        /// 构建 DbCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static DbCommand BuildProcedureCommand(DbConnection connection, string storedProcName, CommonParameter[] parameters)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcName;
            foreach (CommonParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    DbParameter param = parameter.ConvertToDbParameter(command);
                    command.Parameters.Add(param);
                }
            }
            return command;
        }
        #endregion
    }
}
