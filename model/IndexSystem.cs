using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class IndexSystem
    {
        public IndexSystem()
        { }
        #region Model

        private int _id;
        private string _name;
        private string _index_;
        private string _pindex;
        private int _threshold;

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
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>

        public string INDEX_
        {
            get { return _index_; }
            set { _index_ = value; }
        }

        public string PINDEX
        {
            get { return _pindex; }
            set { _pindex = value; }
        }

        public int THRESHOLD
        {
            get { return _threshold; }
            set { _threshold = value; }
        }
        #endregion Model
    }
}
