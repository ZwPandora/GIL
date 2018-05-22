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
        void Add(RiskFactor model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(RiskFactor model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        

        RiskFactor GetModel(int ID);

        RiskFactor GetModel(string name);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<RiskFactor> GetList(string strWhere);

        DataSet GetDataSet(string strWhere);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法

        List<RiskFactor> GetAllList();

    }
}