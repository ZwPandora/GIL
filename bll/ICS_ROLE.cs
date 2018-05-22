using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using thesis.dal;

namespace thesis.bll
{
    public class ICS_ROLEBll
    {
        ICS_RoleDal dal = new ICS_RoleDal();
        public ICS_ROLEBll()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ICS_Role model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_Role model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ICS_Role GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Role> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Role> GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<Role>  GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}
