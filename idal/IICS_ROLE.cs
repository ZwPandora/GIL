using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;

namespace thesis.idal
{
    public interface IICS_ROLEDal
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ICS_Role model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ICS_Role model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ICS_Role GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<ICS_Role> GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法

        List<ICS_Role> GetAllList();
    }
}
