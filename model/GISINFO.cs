using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class GISINFO
    {
        public GISINFO()
        {
        }

        private string _ID;
        private string _PROVINCE;
        private string _CITY;
        private string _AREA;
        private string _LONGITUDE;
        private string _LATITUDE;
        private string _ISCAPITAL;
        private string _P_ORDER;
        private string _C_ORDER;

        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string PROVINCE
        {
            set { _PROVINCE = value; }
            get { return _PROVINCE; }
        }
        public string CITY
        {
            set { _CITY = value; }
            get { return _CITY; }
        }
        public string AREA
        {
            set { _AREA = value; }
            get { return _AREA; }
        }
        public string LONGITUDE
        {
            set { _LONGITUDE = value; }
            get { return _LONGITUDE; }
        }
        public string LATITUDE
        {
            set { _LATITUDE = value; }
            get { return _LATITUDE; }
        }
        public string ISCAPITAL
        {
            set { _ISCAPITAL = value; }
            get { return _ISCAPITAL; }
        }
        public string P_ORDER
        {
            set { _P_ORDER = value; }
            get { return _P_ORDER; }
        }
        public string C_ORDER
        {
            set { _C_ORDER = value; }
            get { return _C_ORDER; }
        }
    }
}
