using System;
using System.Data;
using thesis.model;
using System.Collections.Generic;
namespace thesis.idal
{
	/// <summary>
	/// 接口层ISPECIES12 的摘要说明。
	/// </summary>
    public interface IUserDal
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
		void Add(User model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(User model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		User GetModel(int ID);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		List<User> GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法

        List<User> GetAllList();

        List<User> GetSpcUsers();

        User GetModel(string name);

        List<User> GetUsersOfGroup(int GroupID);

        List<User> GetPlanAlarmReceiptors(int PlanID);

        int GetSpcUsersCount();
    }
}
