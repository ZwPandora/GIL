using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IRiskFactor
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
        void Add(RiskFactor model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(RiskFactor model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        

        RiskFactor GetModel(int ID);

        RiskFactor GetModel(string name);
        /// <summary>
        /// ��������б�
        /// </summary>
        List<RiskFactor> GetList(string strWhere);

        DataSet GetDataSet(string strWhere);

        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����

        List<RiskFactor> GetAllList();

    }
}