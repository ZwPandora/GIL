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
    public class FI_Exp
    {
        public FI_Exp()
        { }
        #region Model
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _FI_UUID;

        public string FI_UUID
        {
            get { return _FI_UUID; }
            set { _FI_UUID = value; }
        }
        private string _EXP_UUID;

        public string EXP_UUID
        {
            get { return _EXP_UUID; }
            set { _EXP_UUID = value; }
        }
        private string _ISEVALUATED;

        public string ISEVALUATED
        {
            get { return _ISEVALUATED; }
            set { _ISEVALUATED = value; }
        }

        private string _Spare1;

        public string Spare1
        {
            get { return _Spare1; }
            set { _Spare1 = value; }
        }
        private string _Spare2;

        public string Spare2
        {
            get { return _Spare2; }
            set { _Spare2 = value; }
        }
        private string _Spare3;

        public string Spare3
        {
            get { return _Spare3; }
            set { _Spare3 = value; }
        }
        private string _Spare4;

        public string Spare4
        {
            get { return _Spare4; }
            set { _Spare4 = value; }
        }

        #endregion Model
    }
}
