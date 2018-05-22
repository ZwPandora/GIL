using System;
using System.Data;
using thesis.common;
using thesis.model;
using thesis.factory;
using thesis.idal;
using System.Collections.Generic;
namespace thesis.bll
{
	/// <summary>
	/// 业务逻辑类CZRZ 的摘要说明。
	/// </summary>
	public class OperationLogBll
	{
        private readonly IOperationLogDal dal = DataAccess.CreateOperationLogDal();
		public OperationLogBll()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID()
		{
			return dal.GetMaxID();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(thesis.model.OperationLog model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(thesis.model.OperationLog model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public thesis.model.OperationLog GetModel(int ID)
		{
			return dal.GetModel(ID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< OperationLog> GetAllList()
		{
            return dal.GetAllList();
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public List< OperationLog> GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 获得用户的操作日志
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<OperationLog> GetListByUser(int UserID)
        {
            return dal.GetListByUser(UserID);
        }
        /// <summary>
        /// 获得用户在某个时间段的操作日志,UserID小于等于0则取所有用户在这个时间段的日志。
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<OperationLog> GetList(int UserID, DateTime from, DateTime to)
        {
            return dal.GetList(UserID,from,to);
        }
        public void DeleteList(int userID, DateTime fromtime, DateTime totime)
        {
            dal.DeleteList(userID, fromtime, totime);
        }
		#endregion  成员方法
	}
}

