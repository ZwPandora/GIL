using System;
using System.Data;
using thesis.model;
using System.Collections.Generic;


namespace thesis.idal
{
    public interface IIndexSystemDal
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
        void Add(IndexSystem model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(IndexSystem model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        IndexSystem GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<User> GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法

        List<IndexSystem> GetAllList();

        IndexSystem GetModel(string name);

        DataSet GetDataSet(string strWhere);
    }
}
