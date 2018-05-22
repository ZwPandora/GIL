using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    [Serializable]
    public class Algorithm
    {
        public Algorithm()
        { }
        #region Model
        private int _id;
        private string _AL_name;

        public string AL_name
        {
            get { return _AL_name; }
            set { _AL_name = value; }
        }
        private string _AL_class;

        public string AL_class
        {
            get { return _AL_class; }
            set { _AL_class = value; }
        }
        private string _AL_describe;

        public string AL_describe
        {
            get { return _AL_describe; }
            set { _AL_describe = value; }
        }
        private string _AL_input;

        public string AL_input
        {
            get { return _AL_input; }
            set { _AL_input = value; }
        }
        private string _AL_output;

        public string AL_output
        {
            get { return _AL_output; }
            set { _AL_output = value; }
        }

        private string _spare1;

        public string Spare11
        {
            get { return _spare1; }
            set { _spare1 = value; }
        }
        private string _spare2;

        public string Spare2
        {
            get { return _spare2; }
            set { _spare2 = value; }
        }
        private string _spare3;

        public string Spare3
        {
            get { return _spare3; }
            set { _spare3 = value; }
        }
        private string _spare4;

        public string Spare4
        {
            get { return _spare4; }
            set { _spare4 = value; }
        }


        
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
     


       
        #endregion Model

    }
}
