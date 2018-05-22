using System;
using System.Collections.Generic;

using System.Text;
using System.Data.Common;
using System.Data;
namespace thesis.common
{
    public class CommonParameter
    {
        private string m_ParameterName;
        private object m_Value;
        private ParameterDirection m_Direction = ParameterDirection.Input;
        private DbType m_DbType;
        private int m_Size = 0;
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName
        {
            get
            {
                return m_ParameterName;
            }
            set
            {
                m_ParameterName = value;
            }
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;

            }
        }
        /// <summary>
        /// 参数方向
        /// </summary>
        public ParameterDirection Direction
        {
            get
            {
                return m_Direction;
            }
            set
            {
                m_Direction = value;
            }
        }
        /// <summary>
        /// 参数的数据库类型
        /// </summary>
        public DbType DbType
        {
            get
            {
                return m_DbType;
            }
            set
            {
                m_DbType = value;
            }
        }
        /// <summary>
        /// 参数的最大大小
        /// </summary>
        public int Size
        {
            get
            {
                return m_Size;
            }
            set
            {
                m_Size = value;
            }
        }
        /// <summary>
        /// 构造输入参数
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="DbType"></param>
        /// <param name="Size"></param>
        public CommonParameter(string ParameterName, DbType DbType, int Size)
        {
            this.m_ParameterName = ParameterName;
            this.m_DbType = DbType;
            this.m_Size = Size;
        }
        /// <summary>
        /// 构造带方向的参数
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="DbType"></param>
        /// <param name="Size"></param>
        /// <param name="Direction"></param>
        public CommonParameter(string ParameterName, DbType DbType, int Size, ParameterDirection Direction)
        {
            this.m_ParameterName = ParameterName;
            this.m_DbType = DbType;
            this.m_Size = Size;
            this.m_Direction = Direction;
        }
        /// <summary>
        /// 构造输入参数
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="DbType"></param>
        /// <param name="Size"></param>
        public CommonParameter(string ParameterName, DbType DbType, int Size, object value)
        {
            this.m_ParameterName = ParameterName;
            this.m_DbType = DbType;
            this.m_Size = Size;
            this.m_Value = value;
        }
        /// <summary>
        /// 构造带方向的参数
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="DbType"></param>
        /// <param name="Size"></param>
        /// <param name="Direction"></param>
        public CommonParameter(string ParameterName, DbType DbType, int Size, ParameterDirection Direction, object value)
        {
            this.m_ParameterName = ParameterName;
            this.m_DbType = DbType;
            this.m_Size = Size;
            this.m_Direction = Direction;
            this.m_Value = value;
        }
        /// <summary>
        /// 转换为DbParameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DbParameter ConvertToDbParameter(DbCommand cmd)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = this.m_ParameterName;
            parameter.Direction = this.m_Direction;
            parameter.DbType = this.m_DbType;
            parameter.Value = this.m_Value;
            parameter.Size = this.m_Size;
            return parameter;
        }
    }
}
