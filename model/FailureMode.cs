using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    /// <summary>
    /// 实体类SPECIES12 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable()]
    public class FailureMode
    {
        public FailureMode()
        { }
        #region Model
        private int _ID;
        private string _FM_name;
        private string _Mal_name;
        private string _FM_part;
        private string _FM_reason;
        private string _FM_PC;
        private string _FM_RM;
        private string _Spare1;
        private string _Spare2;
        private string _Spare3;
        private string _Spare4;


        /// <summary>
        /// 
        /// </summary>
        public string FM_name
        {
            set { _FM_name = value; }
            get { return _FM_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mal_name
        {
            set { _Mal_name = value; }
            get { return _Mal_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FM_part
        {
            set { _FM_part = value; }
            get { return _FM_part; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FM_reason
        {
            set { _FM_reason = value; }
            get { return _FM_reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FM_PC
        {
            set { _FM_PC = value; }
            get { return _FM_PC; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FM_RM
        {
            set { _FM_RM = value; }
            get { return _FM_RM; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spare1
        {
            set { _Spare1 = value; }
            get { return _Spare1; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Spare2
        {
            set { _Spare2 = value; }
            get { return _Spare2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spare3
        {
            set { _Spare3 = value; }
            get { return _Spare3; }
        }
        public string Spare4
        {
            set { _Spare4 = value; }
            get { return _Spare4; }
        }

        #endregion Model



    }
}