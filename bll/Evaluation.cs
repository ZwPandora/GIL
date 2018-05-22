using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.idal;
using thesis.factory;
using thesis.model;
using System.Data;

namespace thesis.bll
{
    public class EvaluationBll : AbstractCacheManager<Evaluation>
    {
        private readonly IEvaluationDal dal = DataAccess.CreateEvaluationDal();
        public EvaluationBll() { }

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
        public void Add(thesis.model.Evaluation model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Evaluation model)
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
        public override Evaluation GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public Evaluation GetModelwhere(int FIID )
        {
            return dal.GetModelwhere(FIID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Evaluation> GetAllList()
        {
            return dal.GetAllList();
        }

        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }

        public override void InitialCache()
        {
            List<Evaluation> list = GetAllList();
            foreach (Evaluation item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        #endregion
    }
}
