using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class MACROOBJECT
    {
        public MACROOBJECT()
        { }

        #region Model
        private int _MACROOBJECT_ID;
        private int _PROVINCE_ID;
        private int _CITY_ID;
        private int _AREA_ID;
        private string _COMPANY_NAME;
        private string _COMPANY_TEL;
        private string _COMPANY_USER;
        private string _COMPANY_ADDRESS;
        private string _COMPANY_TYPE;
        private string _COMPANY_DETAIL;
        private string _BZ1;
        private string _BZ2;
        private string _BZ3;
        private string _Vol_level;

        public string Vol_level
        {
            get { return _Vol_level; }
            set { _Vol_level = value; }
        }
        private string _Pip_length;

        public string Pip_length
        {
            get { return _Pip_length; }
            set { _Pip_length = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MACROOBJECT_ID
        {
            set { _MACROOBJECT_ID = value; }
            get { return _MACROOBJECT_ID; }
        }
        public int PROVINCE_ID
        {
            set { _PROVINCE_ID = value; }
            get { return _PROVINCE_ID; }
        }
        public int CITY_ID
        {
            set { _CITY_ID = value; }
            get { return _CITY_ID; }
        }
        public int AREA_ID
        {
            set { _AREA_ID = value; }
            get { return _AREA_ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_NAME
        {
            set { _COMPANY_NAME = value; }
            get { return _COMPANY_NAME; }
        }
        public string COMPANY_TEL
        {
            set { _COMPANY_TEL = value; }
            get { return _COMPANY_TEL; }
        }
        public string COMPANY_USER
        {
            set { _COMPANY_USER = value; }
            get { return _COMPANY_USER; }
        }
        public string COMPANY_ADDRESS
        {
            set { COMPANY_ADDRESS = value; }
            get { return COMPANY_ADDRESS; }
        }
        public string COMPANY_TYPE
        {
            set { _COMPANY_TYPE = value; }
            get { return _COMPANY_TYPE; }
        }
        public string COMPANY_DETAIL
        {
            set { _COMPANY_DETAIL = value; }
            get { return _COMPANY_DETAIL; }
        }
        public string BZ1
        {
            set { _BZ1 = value; }
            get { return _BZ1; }
        }
        public string BZ2
        {
            set { _BZ2 = value; }
            get { return _BZ2; }
        }
        public string BZ3
        {
            set { _BZ3 = value; }
            get { return _BZ3; }
        }
        #endregion Model
    }
}
