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
	/// ҵ���߼���SPECIES12 ��ժҪ˵����
	/// </summary>
	public class UserBll:AbstractCacheManager<User>
	{
		private readonly IUserDal dal=DataAccess.CreateUserDal();
		public UserBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxID()
		{
			return dal.GetMaxID();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(thesis.model.User model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(thesis.model.User model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
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
		/// ��������б�
		/// </summary>
		public List<User> GetAllList()
		{
			return dal.GetAllList();
		}
        /// <summary>
        /// �������ƻ�ȡ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetModel(string name)
        {
            return dal.GetModel(name);
        }      

        /// <summary>
        /// ���SPC�û��б�
        /// </summary>
        /// <returns></returns>
        public List<User> GetSpcUsers()
        {
            return dal.GetSpcUsers();   
        }
        /// <summary>
        /// ��ü�ؼƻ��ı���������
        /// </summary>
        /// <param name="PlanID"></param>
        /// <returns></returns>
        public List<User> GetPlanAlarmReceiptors(int PlanID)  
        {
            return dal.GetPlanAlarmReceiptors(PlanID);
 
        }
        /// <summary>
        /// ͳ��SPC�û�����
        /// </summary>
        /// <returns></returns>
        public int GetSpcUsersCount()
        {
            return dal.GetSpcUsersCount();
        }      

		/// <summary>
		/// ��������б�
		/// </summary>
		//public List<User> GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����

        
    }
}

