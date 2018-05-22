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
    /// 业务逻辑类SPECIES12 的摘要说明。
    /// </summary>
    public class ComapnyBll : AbstractCacheManager<Company>
    {
        private readonly ICompanyDal dal = DataAccess.CreateCompanyDal();
        public ComapnyBll()
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
        public void Add(thesis.model.Company model)
        {
            dal.Add(model);
        }

        public override void InitialCache()
        {
            List<Company> list = GetAllList();
            foreach (Company item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Company model)
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
        public override Company GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Company> GetAllList()
        {
            return dal.GetAllList();
        }
        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Company GetModel(string name)
        {
            return dal.GetModel(name);
        }

        #endregion  成员方法


    }
}

