using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using thesis.factory;
using thesis.idal;
using System.Data;

namespace thesis.bll
{
    public class FI_FMBll : AbstractCacheManager<FI_FM>
    {
        private readonly IFI_FMDal dal = DataAccess.CreateFI_FMDal();
        public FI_FMBll() { }

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
        public void Add(thesis.model.FI_FM model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.FI_FM model)
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

        public void Delete(string strWhere)
        { 
           dal.Delete(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override FI_FM GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public FI_FM GetModel(string name)
        {
            return dal.GetModel(name);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FI_FM> GetAllList()
        {
            return dal.GetAllList();
        }

        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }

        public override void InitialCache()
        {
            List<FI_FM> list = GetAllList();
            foreach (FI_FM item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        #endregion
    }
}
