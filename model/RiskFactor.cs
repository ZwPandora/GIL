using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace thesis.model
{
    /// <summary>
    /// 实体类RiskFactor(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class RiskFactor
    {
        public RiskFactor()
        { }
        #region Model
        private int _id;
        private string _RFcode;
        private string _RFname;
        private string _RFclass;
        private string _spare1;
        private string _spare2;
        private string _spare3;
        private string _spare4;



        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RF_code
        {
            set { _RFcode = value; }
            get { return _RFcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RF_name
        {
            set { _RFname = value; }
            get { return _RFname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RF_class
        {
            set { _RFclass = value; }
            get { return _RFclass; }
        }

        public string Spare1
        {
            set { _spare1 = value; }
            get { return _spare1; }
        }
        public string Spare2
        {
            set { _spare2 = value; }
            get { return _spare2; }
        }
        public string Spare3
        {
            set { _spare3 = value; }
            get { return _spare3; }
        }
        public string Spare4
        {
            set { _spare4 = value; }
            get { return _spare4; }
        }
        #endregion Model

    }

}
