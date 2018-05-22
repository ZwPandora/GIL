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
	/// ҵ���߼���CZRZ ��ժҪ˵����
	/// </summary>
	public class OperationLogBll
	{
        private readonly IOperationLogDal dal = DataAccess.CreateOperationLogDal();
		public OperationLogBll()
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
		public void Add(thesis.model.OperationLog model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(thesis.model.OperationLog model)
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
		public thesis.model.OperationLog GetModel(int ID)
		{
			return dal.GetModel(ID);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public List< OperationLog> GetAllList()
		{
            return dal.GetAllList();
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public List< OperationLog> GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// ����û��Ĳ�����־
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<OperationLog> GetListByUser(int UserID)
        {
            return dal.GetListByUser(UserID);
        }
        /// <summary>
        /// ����û���ĳ��ʱ��εĲ�����־,UserIDС�ڵ���0��ȡ�����û������ʱ��ε���־��
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
		#endregion  ��Ա����
	}
}

