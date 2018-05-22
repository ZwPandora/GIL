using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.model
{
    /// <summary>
    /// 实体类SPECIES12 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable()]
    public class ExpertInfo
    {
        public ExpertInfo()
        { }
        #region Model
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _UUID;

        public string UUID
        {
            get { return _UUID; }
            set { _UUID = value; }
        }
        private string _Exp_name;

        public string Exp_name
        {
            get { return _Exp_name; }
            set { _Exp_name = value; }
        }
        private string _Exp_company;

        public string Exp_company
        {
            get { return _Exp_company; }
            set { _Exp_company = value; }
        }
        private string _Exp_tel;

        public string Exp_tel
        {
            get { return _Exp_tel; }
            set { _Exp_tel = value; }
        }
        private string _Exp_email;

        public string Exp_email
        {
            get { return _Exp_email; }
            set { _Exp_email = value; }
        }
        private string _Exp_major;

        public string Exp_major
        {
            get { return _Exp_major; }
            set { _Exp_major = value; }
        }
        private string _Exp_title;

        public string Exp_title
        {
            get { return _Exp_title; }
            set { _Exp_title = value; }
        }
        private string _Exp_sex;

        public string Exp_sex
        {
            get { return _Exp_sex; }
            set { _Exp_sex = value; }
        }
        private string _Exp_address;

        public string Exp_address
        {
            get { return _Exp_address; }
            set { _Exp_address = value; }
        }
        private string _Spare1;

        public string Spare1
        {
            get { return _Spare1; }
            set { _Spare1 = value; }
        }
        private string _Spare2;

        public string Spare2
        {
            get { return _Spare2; }
            set { _Spare2 = value; }
        }
        private string _Spare3;

        public string Spare3
        {
            get { return _Spare3; }
            set { _Spare3 = value; }
        }
        private string _Spare4;

        public string Spare4
        {
            get { return _Spare4; }
            set { _Spare4 = value; }
        }


        #endregion Model
    }
}
