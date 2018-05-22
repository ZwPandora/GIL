using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using thesis.idal;
using thesis.factory;
using System.Data;

namespace thesis.bll
{
    public class FMEAItemBll:AbstractCacheManager<FMEAItem>
    {
        private readonly IFMEAItemDal dal = DataAccess.CreateFMEAItemDal();
        public FMEAItemBll() { }
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
        public void Add(thesis.model.FMEAItem model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.FMEAItem model)
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
        public override FMEAItem GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FMEAItem> GetAllList()
        {
            return dal.GetAllList();
        }
        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FMEAItem GetModel(string name)
        {
            return dal.GetModel(name);
        }

        public override void InitialCache()
        {
            List<FMEAItem> list = GetAllList();
            foreach (FMEAItem item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }
        #endregion  成员方法
    }
}
