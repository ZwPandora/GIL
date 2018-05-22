using System;
namespace thesis.model
{
	/// <summary>
	/// 实体类CZRZ 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
		[Serializable()] public class OperationLog
	{
		public OperationLog()
		{}
		#region Model
		private int _id;
		private int _species12_id;
		private string _nr;
		private string _enr;
		private DateTime _rqsj;
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
		public int SPECIES12_ID
		{
			set{ _species12_id=value;}
			get{return _species12_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NR
		{
			set{ _nr=value;}
			get{return _nr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ENR
		{
			set{ _enr=value;}
			get{return _enr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RQSJ
		{
			set{ _rqsj=value;}
			get{return _rqsj;}
		}
		#endregion Model

	}
}

