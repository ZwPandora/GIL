using System;

namespace thesis.model
{
    [Serializable()]
    public class Company
    {
        public Company()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _master;
        private string _website;
        private string _address;

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
        public string WEBSITE
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS 
        {
            set { _address = value; }
            get { return _address; }
        }
        #endregion Model



    }
}
