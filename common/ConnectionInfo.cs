using System;
using System.Collections.Generic;

using System.Text;

namespace thesis.common
{
    public class ConnectionInfo
    {

        private int m_DbType;
        private string m_ProviderName;
        private string m_Server;
        private string m_DbName;
        private string m_DbUser;
        private string m_DbPass;

        public const int PRVIDER_ORACLE_CLIENT = 1;
        public const int PRVIDER_SQL_CLIENT = 2;
        public const int PRVIDER_OLEDB = 3;
        public const int PRVIDER_ODBC = 4;

        public const int DB_ORA = 1;
        public const int DB_DB2 = 2;
        public const int DB_SQL = 3;
        public const int DB_SYB = 4;
        public const int DB_ACS = 5;
        /// <summary>
        /// 连接提供者名称
        /// </summary>
        public string ProviderName
        {
            get { return m_ProviderName; }
            set { m_ProviderName = value; }
        }
        /// <summary>
        /// 数据库类型
        /// </summary>
        /// <value>
        /// 1:Oracle
        /// 2:DB2
        /// 3:SqlServer
        /// 4:Sybase
        /// 5:Access
        /// </value>
        public int DatabaseType
        {
            get { return m_DbType; }
            set { m_DbType = value; }
        }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public String Server
        {
            get { return m_Server; }
            set { m_Server = value; }
        }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName
        {
            get
            {
                return m_DbName;
            }
            set
            {
                m_DbName = value;
            }
        }

        /// <summary>
        /// 数据库用户
        /// </summary>
        public string DbUser
        {
            get
            {
                return m_DbUser;
            }
            set
            {
                m_DbUser = value;
            }
        }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string DbPass
        {
            get
            {
                return m_DbPass;
            }
            set
            {
                m_DbPass = value;
            }
        }


        /// <summary>
        /// 获得连接提供者名称
        /// </summary>
        public string GetDefaultProviderName()
        {
            string ProviderName = "";
            switch (DatabaseType)
            {
                case DB_ORA: ProviderName = "System.Data.OleDb"; break;
                case DB_SQL: ProviderName = "System.Data.SqlClient"; break;
                default: ProviderName = "System.Data.OleDb"; break;
            }
            return ProviderName;
        }
        /// <summary>
        /// 获取oledb提供者名称
        /// </summary>
        /// <returns></returns>
        public string GetOleProviderName()
        {
            string ProviderName = "";
            switch (DatabaseType)
            {
                case DB_ORA: ProviderName = "OraOLEDB.Oracle.1"; break;
                case DB_SQL: ProviderName = "SQLOLEDB.1"; break;
                default: ProviderName = "System.Data.OleDb"; break;
            }
            return ProviderName;
        }

        /// <summary>
        /// 获得数据库连接串
        /// </summary>
        public string GetConnectionString()
        {
            string ConnectionString = "";
            switch (DatabaseType)
            {
                case DB_ORA: ConnectionString = "Provider=MSDAORA.1;User ID=" + m_DbUser + ";Password=" + m_DbPass + ";Data Source=" + m_Server + ";Persist Security Info=False"; break;
                //case DB_SQL: ConnectionString = "Provider=SQLOLEDB.1;User ID=" + m_DbUser + ";Password=" + m_DbPass + ";Initial Catalog=" + m_DbName + ";Data Source=" + m_Server + " Persist Security Info=False;"; break;
                case DB_SQL: ConnectionString = "Server=" + m_Server + ";User ID=" + m_DbUser + ";Password=" + m_DbPass + ";Database=" + m_DbName; break;
            }
            return ConnectionString;
        }
        /// <summary>
        ///  获得ole方式数据库连接串
        /// </summary>
        /// <returns></returns>
        public string GetOleConnectionString()
        {
            string ConnectionString = "Provider=" + this.GetOleProviderName();
            ConnectionString = ConnectionString + ";User ID=" + m_DbUser + ";Password=" + m_DbPass + ";Data Source=" + m_Server + ";Persist Security Info=False";
            return ConnectionString;
        }
    }
}
