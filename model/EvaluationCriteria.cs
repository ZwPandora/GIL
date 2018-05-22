using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class EvaluationCriteria
    {
        public EvaluationCriteria()
        { }
        #region Model
        private int _ID;
        private string _RF_name;
        private string _LingVar;
        private string _Criteria;
        private string _Number_;
        private string _RoughNumber;

        private string _Spare1;
        private string _Spare2;
        private string _Spare3;
        private string _Spare4;


        /// <summary>
        /// 
        /// </summary>
        public string RF_name
        {
            set { _RF_name = value; }
            get { return _RF_name; }
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
        public string LingVar
        {
            set { _LingVar = value; }
            get { return _LingVar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Criteria
        {
            set { _Criteria = value; }
            get { return _Criteria; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Number_
        {
            set { _Number_ = value; }
            get { return _Number_; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoughNumber
        {
            set { _RoughNumber = value; }
            get { return _RoughNumber; }
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
