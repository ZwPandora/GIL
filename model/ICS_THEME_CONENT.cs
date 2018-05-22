using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.modal
{
    [Serializable()]
    public class ICS_THEME_CONENT
    {
        public ICS_THEME_CONENT()
        { }
        #region Model
        private int _id;
        private int _userid;
        private int _themeid;
        private string _display_name;
        private int _auto_refresh;
        private int _auto_refresh_interval;
        private int _contentid;
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
        public int THEMEID
        {
            set { _themeid = value; }
            get { return _themeid; }
        }
        /// <summary>
        /// 类别：用户组 Node.SPECIES_USER_GROUP,用户 Node.SPECIES_USER
        /// </summary>
        public string DISPLAY_NAME
        {
            set { _display_name = value; }
            get { return _display_name; }
        }
        public int AUTO_REFRESH
        {
            set { _auto_refresh = value; }
            get { return _auto_refresh; }
        }
        public int AUTO_REFRESH_INTERVAL
        {
            set { _auto_refresh_interval = value; }
            get { return _auto_refresh_interval; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CONTENTID
        {
            set { _contentid = value; }
            get { return _contentid; }
        }
        #endregion Model

    }
}
