using System;
using System.Data;
using thesis.common;
using thesis.model;
using thesis.factory;
using thesis.idal;
using thesis.dal;
using System.Collections.Generic;

namespace thesis.bll
{
    public class ComponentBll : AbstractCacheManager<Component>
    {
        private readonly IComponentDal dal = DataAccess.CreateComponentDal();
        public ComponentBll()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return dal.GetMaxID();
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
        public void Add(thesis.model.Component model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Component model)
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
        public override Component GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Component> GetAllList()
        {
            return dal.GetAllList();
        }
        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Component GetModel(string name)
        {
            return dal.GetModel(name);
        }

        public override void InitialCache()
        {
            List<Component> list = GetAllList();
            foreach (Component item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }

        #endregion  成员方法
    }
}
