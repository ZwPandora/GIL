using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thesis.modal
{
    [Serializable()]
    public class ICS_Node
    {
        public ICS_Node()
        { }

        public const int SPECIES_ROOT_NODE = 0;
        public const int SPECIES_CHARA_FOLDER = 1;
        public const int SPECIES_CHARA_FILE = 2;
        public const int SPECIES_CHARA_VARIABLE = 3;
        public const int SPECIES_CHARA_ARRTIBUTE = 4;
        public const int SPECIES_TAG = 5;
        //以下为我们用到的类型
        //工作流名称
        public const int SPECIES_WFNAME = 6;
        //工作流状态
        public const int SPECIES_WFACTIVITY = 7;
        //web文件夹
        public const int SPECIES_WEB_FOLDER = 8;
        //web
        public const int SPECIES_WEB = 9;

        public const int SPECIES_STATION = 10;
        //角色
        public const int SPECIES_ROLE = 11;
        //用户
        public const int SPECIES_USER = 12;

        public const int SPECIES_DEVICE_FOLDER = 13;
        public const int SPECIES_DEVICE = 14;
        public const int SPECIES_SELECTED = 15;
        public const int SPECIES_DISSELECTED = 16;
        public const int SPECIES_QUERY_VARIABLE = 20;
        public const int SPECIES_QUERY_ATTRIBUTE = 21;
        public const int SPECIES_MAX = 30;//最大类型
        #region Model
        private string _name;
        private int _index_;
        private int _pindex;
        private int _species;
        private int _species_id;
        private int _cs;
        private string _bh;
        private DateTime _createtime;
        private DateTime _updatetime;
        private string _clicktimes;
        private string _lastclicktime;
        private string _bh2_;
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
        public int INDEX_
        {
            set { _index_ = value; }
            get { return _index_; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PINDEX
        {
            set { _pindex = value; }
            get { return _pindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SPECIES
        {
            set { _species = value; }
            get { return _species; }
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
        /// 
        /// </summary>
        public int CS
        {
            set { _cs = value; }
            get { return _cs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BH
        {
            set { _bh = value; }
            get { return _bh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATETIME
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UPDATETIME
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }

        public string CLICKTIMES
        {
            set { _clicktimes = value; }
            get { return _clicktimes; }
        }

        public string LASTCLICKTIME
        {
            set { _lastclicktime = value; }
            get { return _lastclicktime; }
        }

        public string BH2_
        {
            set { _bh2_ = value; }
            get { return _bh2_; }
        }
        #endregion Model


        #region IComparer<Node> 成员

        public static int Compare(ICS_Node x, ICS_Node y)
        {
            //按照层数比较
            int result = x.CS.CompareTo(y.CS);
            if (result != 0) return result;
            //按照类别比较
            result = x.SPECIES.CompareTo(y.SPECIES);
            if (result != 0) return result;
            //按照ID比较
            result = x.SPECIES_ID.CompareTo(y.SPECIES_ID);
            if (result != 0) return result;
            //按照名称比较
            result = x.NAME.CompareTo(y.NAME);
            return result;
        }

        #endregion
    }
}
