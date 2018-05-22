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
	/// 业务逻辑类SPECIES12 的摘要说明。
	/// </summary>
	public class UserBll:AbstractCacheManager<User>
	{
		private readonly IUserDal dal=DataAccess.CreateUserDal();
		public UserBll()
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
		public void Add(thesis.model.User model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(thesis.model.User model)
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
		public override User GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

        public override void InitialCache()
        {
            List<User> list = GetAllList();
            foreach (User item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<User> GetAllList()
		{
			return dal.GetAllList();
		}
        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetModel(string name)
        {
            return dal.GetModel(name);
        }      

        /// <summary>
        /// 获得SPC用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSpcUsers()
        {
            return dal.GetSpcUsers();   
        }
        /// <summary>
        /// 获得监控计划的报警接收者
        /// </summary>
        /// <param name="PlanID"></param>
        /// <returns></returns>
        public List<User> GetPlanAlarmReceiptors(int PlanID)  
        {
            return dal.GetPlanAlarmReceiptors(PlanID);
 
        }
        /// <summary>
        /// 统计SPC用户个数
        /// </summary>
        /// <returns></returns>
        public int GetSpcUsersCount()
        {
            return dal.GetSpcUsersCount();
        }      

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public List<User> GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法

        
    }
}

