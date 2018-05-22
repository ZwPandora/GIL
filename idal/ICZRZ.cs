using System;
using System.Data;
using thesis.model;
using System.Collections.Generic;
namespace thesis.idal
{
	/// <summary>
	/// 接口层ICZRZ 的摘要说明。
	/// </summary>
    public interface IOperationLogDal
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxID();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(OperationLog model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(OperationLog model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		OperationLog GetModel(int ID);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		List<OperationLog> GetList(int PageSize,int PageIndex,string strWhere);
        List<OperationLog> GetAllList();
        List<OperationLog> GetListByUser(int UserID);
        List<OperationLog> GetList(int UserID, DateTime from, DateTime to);
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="fromtime"></param>
        /// <param name="totime"></param>
        void DeleteList(int userID, DateTime fromtime, DateTime totime);
		#endregion  成员方法
	}
}
