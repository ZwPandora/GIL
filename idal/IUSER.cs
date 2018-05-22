using System;
using System.Data;
using thesis.model;
using System.Collections.Generic;
namespace thesis.idal
{
	/// <summary>
	/// �ӿڲ�ISPECIES12 ��ժҪ˵����
	/// </summary>
    public interface IUserDal
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxID();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Add(User model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(User model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		User GetModel(int ID);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		List<User> GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����

        List<User> GetAllList();

        List<User> GetSpcUsers();

        User GetModel(string name);

        List<User> GetUsersOfGroup(int GroupID);

        List<User> GetPlanAlarmReceiptors(int PlanID);

        int GetSpcUsersCount();
    }
}
