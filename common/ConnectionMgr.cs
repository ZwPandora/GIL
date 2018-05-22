using System;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;

namespace thesis.common
{
    public class ConnectionMgr
    {
        public static ConnectionInfo ConnInfo
        {
            get
            {
                ConnectionInfo info = new ConnectionInfo();
                string DatabaseType = ConfigurationManager.AppSettings["DatabaseType"];
                switch (DatabaseType.ToLower())
                {
                    case "oracle": info.DatabaseType = ConnectionInfo.DB_ORA; break;
                    case "sqlserver": info.DatabaseType = ConnectionInfo.DB_SQL; break;
                    case "db2": info.DatabaseType = ConnectionInfo.DB_DB2; break;
                    case "sybase": info.DatabaseType = ConnectionInfo.DB_SYB; break;
                    case "access": info.DatabaseType = ConnectionInfo.DB_ACS; break;
                }
                if (ConfigurationManager.AppSettings["ProviderName"] != null)
                {
                    info.ProviderName = ConfigurationManager.AppSettings["ProviderName"];
                }
                info.Server = ConfigurationManager.AppSettings["DatabaseServer"];
                info.DbName = ConfigurationManager.AppSettings["DatabaseName"];
                info.DbUser = ConfigurationManager.AppSettings["DatabaseUser"];
                info.DbPass = ConfigurationManager.AppSettings["DatabasePass"];
                string EncryptPass = ConfigurationManager.AppSettings["EncryptPass"];
                if (EncryptPass == "true")
                {
                    info.DbPass = DesEncrypt.Decrypt(info.DbPass);
                }
                if (info.DbPass.Trim() == String.Empty) info.DbPass = String.Empty;
                return info;
            }
        }
        /// <summary>
        /// 获得数据库连接对象
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetConnection()
        {
            string ProviderName = ConnInfo.GetDefaultProviderName();
            string ConnectionString = ConnInfo.GetConnectionString();
            DbProviderFactory db = DbProviderFactories.GetFactory(ProviderName);
            DbConnection connection = db.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }
        /// <summary>
        /// 获得oledb的连接
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection GetOleDbConnection()
        {
            OleDbConnection conn = new OleDbConnection(ConnInfo.GetOleConnectionString());
            return conn;
        }
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            if (ConnInfo.DatabaseType <= 0) return false;
            DbConnection connection = GetConnection();
            bool ret = true;
            try
            {
                connection.Open();
            }
            catch
            {
                ret = false;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return ret;
        }
        /// <summary>
        /// 获得DataAdapter
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DbDataAdapter CreateDbDataAdapter(DbCommand cmd)
        {
            DbProviderFactory db = DbProviderFactories.GetFactory(ConnInfo.GetDefaultProviderName());
            DbDataAdapter adapter = db.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter;
        }
    }
}
