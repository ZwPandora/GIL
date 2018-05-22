using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable()]
    public class CORRELATIONSHIP
    {
        public CORRELATIONSHIP()
        {}
        #region Model
        private int _id;
        private int _cs_fmid_1;
        private int _cs_fmid_2;
        private int _cs_ifcorrelation;
        private int _cs_direction;
        private string _cs_strength;


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int CS_FMID_1
        {
            get { return _cs_fmid_1; }
            set { _cs_fmid_1 = value; }
        }

        public int CS_FMID_2
        {
            get { return _cs_fmid_1; }
            set { _cs_fmid_1 = value; }
        }

        public int CS_IFCORRELATION
        {
            get { return _cs_ifcorrelation; }
            set { _cs_ifcorrelation = value; }
        }

        public int CS_DIRECTION
        {
            get { return _cs_direction; }
            set { _cs_direction = value; }
        }

        public string CS_STRENGTH
        {
            get { return _cs_strength; }
            set { _cs_strength = value; }
        }

        #endregion

    }
}
