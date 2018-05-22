using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface ICORRELATIONSHIPDal
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
        void Add(CORRELATIONSHIP model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(CORRELATIONSHIP model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CORRELATIONSHIP GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<User> GetList(int PageSize,int PageIndex,string strWhere);

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <returns></returns>
        DataSet GetDataSet(string strWhere);



        #endregion  成员方法

        List<CORRELATIONSHIP> GetAllList();

        CORRELATIONSHIP GetModel(string name);
    }
}
