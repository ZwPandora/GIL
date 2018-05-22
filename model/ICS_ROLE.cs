using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.modal
{
    [Serializable]
    public class ICS_Role
    {
        public ICS_Role()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _roleinfo;
        private string _cjr;
        private DateTime? _createtime;
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
        public string ROLEINFO
        {
            set { _roleinfo = value; }
            get { return _roleinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CJR
        {
            set { _cjr = value; }
            get { return _cjr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATETIME
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}
