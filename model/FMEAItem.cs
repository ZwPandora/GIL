using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    /// <summary>
    /// FMEA分析类实体
    /// </summary>
    [Serializable]
    public class FMEAItem
    {
        public FMEAItem() { }
        #region Model
        private int _id;
        private string _FI_name;
        private string _FI_describe;
        private string _FI_startTime;
        private string _FI_endTime;
        private string _IsSubmit;
        private string _IsComplete;
        private int _ExpertNumber;
        private int _EvaluatedNumber;

        private string _spare1;
        private string _spare2;
        private string _spare3;
        private string _spare4;
        private string _UUID;

        public string UUID
        {
            get { return _UUID; }
            set { _UUID = value; }
        }

        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        //FMEA项目名称
        public string FI_name
        {
            set { _FI_name = value; }
            get { return _FI_name; }
        }
        public string FI_describe
        {
            set { _FI_describe = value; }
            get { return _FI_describe; }
        }
        public string FI_startTime
        {
            set { _FI_startTime = value; }
            get { return _FI_startTime; }
        }
        public string FI_endTime
        {
            set { _FI_endTime = value; }
            get { return _FI_endTime; }
        }
        public string IsSubmit
        {
            set { _IsSubmit = value; }
            get { return _IsSubmit; }
        }
        public string IsComplete
        {
            set { _IsComplete = value; }
            get { return _IsComplete; }
        }
        //专家数目
        public int ExpertNumber
        {
            set { _ExpertNumber = value; }
            get { return _ExpertNumber; }
        }
        //评价个数
        public int EvaluatedNumber
        {
            set { _EvaluatedNumber = value; }
            get { return _EvaluatedNumber; }
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
        #endregion
    }
}
