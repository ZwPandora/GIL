using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class FM_Indexs
    {
        public FM_Indexs()
        { }
        #region Model

        private int _id;
        private string _fm_name;
        private string _index_name;
        private string _index_value;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FM_NAME
        {
            get { return _fm_name; }
            set { _fm_name = value; }
        }
        public string INDEX_NAME
        {
            get { return _index_name; }
            set { _index_name = value; }
        }
        public string INDEX_VALUE
        {
            get { return _index_value; }
            set { _index_value = value; }
        }
        #endregion Model
    }
}
