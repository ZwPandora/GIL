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
    public class ExpertInfoBll : AbstractCacheManager<ExpertInfo>
    {
        private readonly IExpertInfoDal dal = DataAccess.CreateExpertInfoDal();
        public ExpertInfoBll()
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
        public bool Exists(string Exp_name)
        {
            return dal.Exists(Exp_name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.ExpertInfo model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.ExpertInfo model)
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
        public override ExpertInfo GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ExpertInfo> GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 根据查询条件获得数据列表
        /// </summary>
        public List<ExpertInfo> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExpertInfo GetModel(string name)
        {
            return dal.GetModel(name);
        }
        /// <summary>
        /// 数据集获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }

        public override void InitialCache()
        {
            List<ExpertInfo> list = GetAllList();
            foreach (ExpertInfo item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        #endregion  成员方法

    }
}
