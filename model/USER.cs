using System;
namespace thesis.model
{
	/// <summary>
	/// 实体类SPECIES12 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
		[Serializable()] public class User
	{
		public User()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _mm;
		private int _zx;
		private int _jibie;
		private string _rephome;
		private string _email;
		private string _hp;
		private string _tel;
		private int _flag;
		private string _hold1;
		private string _hold2;
        private int _companyid;
        private int _departmentid;
        private int _officeid;

		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MM
		{
			set{ _mm=value;}
			get{return _mm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ZX
		{
			set{ _zx=value;}
			get{return _zx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int JIBIE
		{
			set{ _jibie=value;}
			get{return _jibie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPHOME
		{
			set{ _rephome=value;}
			get{return _rephome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HP
		{
			set{ _hp=value;}
			get{return _hp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEL
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// spc用户标记　取0
		/// </summary>
		public int FLAG
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HOLD1
		{
			set{ _hold1=value;}
			get{return _hold1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HOLD2
		{
			set{ _hold2=value;}
			get{return _hold2;}
		}

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

        public int OFFICEID
        {
            set { _officeid = value; }
            get { return _officeid; }
        }
		#endregion Model



	}
}

