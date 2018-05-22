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
    public class Evaluation
    {
        public Evaluation() { }
        #region Model
        private int _id;
        private int _FI_ID;
        private string _FM_name;
        private string _RF_name;
        private string _ExpertName;
        private string _FM_score;     

        private string _spare1;
        private string _spare2;
        private string _spare3;
        private string _spare4;

        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        //FMEA项目名称
        public int FI_ID
        {
            set { _FI_ID = value; }
            get { return _FI_ID; }
        }
        public string FM_name
        {
            set { _FM_name = value; }
            get { return _FM_name; }
        }
        public string RF_name
        {
            set { _RF_name = value; }
            get { return _RF_name; }
        }
        public string ExpertName
        {
            set { _ExpertName = value; }
            get { return _ExpertName; }
        }
        public string FM_score
        {
            set { _FM_score = value; }
            get { return _FM_score; }
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
