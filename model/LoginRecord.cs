using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class LoginRecord
    {
        public LoginRecord()
		{}
        #region Model
        private int _id;
        private int _userid;
        private string _ipaddress;
        private string _logindate;
        private string _by1;
        private string _by2;

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
        public int USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IPADDRESS
        {
            set { _ipaddress = value; }
            get { return _ipaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGINDATE
        {
            set { _logindate = value; }
            get { return _logindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BY1
        {
            set { _by1 = value; }
            get { return _by1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BY2
        {
            set { _by2 = value; }
            get { return _by2; }
        }
        #endregion Model
    }
}
