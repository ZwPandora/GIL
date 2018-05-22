using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.modal
{
    [Serializable]
    public class ICS_Rolegl
    {
        public ICS_Rolegl()
        { }
        #region Model
        private int _id;
        private int _role_id;
        private string _role_name;
        private int _yhid;
        private string _yh_userid;
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
        public int ROLE_ID
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ROLE_NAME
        {
            set { _role_name = value; }
            get { return _role_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int YHID
        {
            set { _yhid = value; }
            get { return _yhid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YH_USERID
        {
            set { _yh_userid = value; }
            get { return _yh_userid; }
        }
        #endregion Model

    }
}
