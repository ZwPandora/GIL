using System;

namespace thesis.model
{
    [Serializable()]
    public class Office
    {
        public Office()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _master;
        private int _companyid;
        private int _departmentid;

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
        public string MASTER
        {
            set { _master = value; }
            get { return _master; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int COMPANYID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }

        public int DEPARTMENTID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        #endregion Model
    }
}
