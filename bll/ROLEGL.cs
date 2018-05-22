using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.factory;
using thesis.model;
using thesis.idal;

namespace thesis.bll
{
    /// <summary>
    /// 业务逻辑类RoleglBll 的摘要说明。
    /// </summary>
    public class RoleglBll
    {
        private readonly IRoleglDal dal = DataAccess.CreateRoleglDal();
        public RoleglBll()
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
        public void Add(Rolegl model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Rolegl model)
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
        public Rolegl GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Rolegl GetModelByCache(int ID)
        {

            string CacheKey = "RoleglModel-" + ID;
            object objModel = thesis.common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = thesis.common.ConfigHelper.GetConfigInt("ModelCache");
                        thesis.common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Rolegl)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Rolegl> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Rolegl> GetList(string strWhere, string ss)
        {
            return dal.GetList(strWhere, ss);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Rolegl> GetAllList()
        {
            return GetAllList();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<Rolegl>  GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法

        public List<Rolegl> GetRoleglByUser(int userid)
        {
            return dal.GetRoleglByUser(userid);
        }
    }
}
