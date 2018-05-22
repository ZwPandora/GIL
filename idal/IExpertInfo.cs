using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IExpertInfoDal
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxID();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string Exp_name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ExpertInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ExpertInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ExpertInfo GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<User> GetList(int PageSize,int PageIndex,string strWhere);
        List<ExpertInfo> GetList(string strWhere);
        #endregion  成员方法

        List<ExpertInfo> GetAllList();

        DataSet GetDataSet(string strWhere);

        ExpertInfo GetModel(string name);
    }
}
