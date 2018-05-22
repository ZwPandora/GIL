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
    public class Malfunction
    {
        public Malfunction()
        { }
        #region Model
        private int _ID;
        private string _Mal_name;
        private string _Mal_S;
        private string _Mal_O;
        private string _Mal_D;
        private string _Mal_RPN;
        private string _Spare1;
        private string _Spare2;
        private string _Spare3;
        private string _Spare4;


        /// <summary>
        /// 
        /// </summary>
        public int  ID
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
        public string Mal_S
        {
            set { _Mal_S = value; }
            get { return _Mal_S; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mal_O
        {
            set { _Mal_O = value; }
            get { return _Mal_O; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mal_D
        {
            set { _Mal_D = value; }
            get { return _Mal_D; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mal_RPN
        {
            set { _Mal_RPN = value; }
            get { return _Mal_RPN; }
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