using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable]
    public class FI_RF
    {
        public FI_RF()
        { }
        #region Model
        private int _id;
        private int _FI_ID;
        private string _RF_name;

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
        public int FI_ID
        {
            set { _FI_ID = value; }
            get { return _FI_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RF_name
        {
            set { _RF_name = value; }
            get { return _RF_name; }
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
