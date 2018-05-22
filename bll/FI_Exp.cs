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
    public class FI_ExpBll : AbstractCacheManager<FI_Exp>
    {
        private readonly IFI_ExpDal dal = DataAccess.CreateFI_ExpDal();
        public FI_ExpBll()
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
        public bool Exists(string FI_UUID, string Exp_UUID)
        {
            return dal.Exists(FI_UUID,Exp_UUID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.FI_Exp model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.FI_Exp model)
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
        public override FI_Exp GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FI_Exp> GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 根据查询条件获得数据列表
        /// </summary>
        public List<FI_Exp> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FI_Exp GetModel(string name)
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
            List<FI_Exp> list = GetAllList();
            foreach (FI_Exp item in list)
            {
                this.UpadteCacheObject(item);
            }
        }

        #endregion  成员方法

    }
}
