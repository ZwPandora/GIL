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
    public class FaultCaseBase
    {
        public FaultCaseBase()
        { }
        #region Model
        private int _ID;
        private string _FC_time;
        private string _FC_place;
        private string _FC_describe;
        private string _FM_name;
        private string _Mal_name;
        private string _FC_lost;
        private string _FC_RT;
        private string _FC_repair;
        private string _FC_part;
        private string _Spare1;
        private string _Spare2;
        private string _Spare3;
        private string _Spare4;


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
        public string FM_name
        {
            set { _FM_name = value; }
            get { return _FM_name; }
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
        public string FC_time
        {
            set { _FC_time = value; }
            get { return _FC_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FC_place
        {
            set { _FC_place = value; }
            get { return _FC_place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FC_describe
        {
            set { _FC_describe = value; }
            get { return _FC_describe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FC_lost
        {
            set { _FC_lost = value; }
            get { return _FC_lost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FC_repair
        {
            set { _FC_repair = value; }
            get { return _FC_repair; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FC_RT
        {
            set { _FC_RT = value; }
            get { return _FC_RT; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 

        public string FC_part
        {
            set { _FC_part = value; }
            get { return _FC_part; }
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