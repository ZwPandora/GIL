using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class ObjectRange_Web
    {
        public ObjectRange_Web()
        { }
        #region Model
        private int _id;
        private int _lx;
        private int _species_id;
        private int _yhlx;
        private int _yhid;
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
        public int LX
        {
            set { _lx = value; }
            get { return _lx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SPECIES_ID
        {
            set { _species_id = value; }
            get { return _species_id; }
        }
        /// <summary>
        /// 类别：用户组 Node.SPECIES_USER_GROUP,用户 Node.SPECIES_USER
        /// </summary>
        public int YHLX
        {
            set { _yhlx = value; }
            get { return _yhlx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int YHID
        {
            set { _yhid = value; }
            get { return _yhid; }
        }
        #endregion Model

    }
}
