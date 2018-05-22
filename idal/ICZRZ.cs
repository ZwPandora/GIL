using System;
using System.Data;
using thesis.model;
using System.Collections.Generic;
namespace thesis.idal
{
	/// <summary>
	/// �ӿڲ�ICZRZ ��ժҪ˵����
	/// </summary>
    public interface IOperationLogDal
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
		void Add(OperationLog model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(OperationLog model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		OperationLog GetModel(int ID);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		List<OperationLog> GetList(int PageSize,int PageIndex,string strWhere);
        List<OperationLog> GetAllList();
        List<OperationLog> GetListByUser(int UserID);
        List<OperationLog> GetList(int UserID, DateTime from, DateTime to);
        /// <summary>
        /// ɾ�������б�
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="fromtime"></param>
        /// <param name="totime"></param>
        void DeleteList(int userID, DateTime fromtime, DateTime totime);
		#endregion  ��Ա����
	}
}
