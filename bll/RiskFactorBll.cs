using System.Collections.Generic;
using thesis.model;
using thesis.factory;
using thesis.idal;
using System.Data;

namespace thesis.bll
{
    public class RiskFactorBll : AbstractCacheManager<RiskFactor>
    {
        private readonly IRiskFactor dal = DataAccess.CreateRiskFactorDal();
        public RiskFactorBll() { }

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
        public void Add(thesis.model.RiskFactor model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.RiskFactor model)
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
        public override RiskFactor GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public RiskFactor GetModel(string RF_name)
        {
            return dal.GetModel( RF_name);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RiskFactor> GetAllList()
        {
            return dal.GetAllList();
        }

        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }

        public override void InitialCache()
        {
            List<RiskFactor> list = GetAllList();
            foreach (RiskFactor item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        #endregion
    }
}
