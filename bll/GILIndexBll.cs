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
    public class GILIndexBll : AbstractCacheManager<GILIndexModel>
    {
        private readonly IGILIndexDal dal = DataAccess.CreateGILIndexDal();
        public GILIndexBll()
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
        public void Add(GILIndexModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GILIndexModel model)
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
        public override GILIndexModel GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public List<GILIndexModel> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GILIndexModel> GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GILIndexModel GetModel(string name)
        {
            return dal.GetModel(name);
        }

        public override void InitialCache()
        {
            List<GILIndexModel> list = GetAllList();
            foreach (GILIndexModel item in list)
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
