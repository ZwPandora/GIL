using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using thesis.dal;

namespace thesis.bll
{
    public class ICS_RoleglBll
    {
        ICS_ROLEGLDal dal = new ICS_ROLEGLDal();
        public ICS_RoleglBll()
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
        public void Add(ICS_Rolegl model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_Rolegl model)
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
        public ICS_Rolegl GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Rolegl> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Rolegl> GetList(string strWhere, string ss)
        {
            return dal.GetList(strWhere, ss);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Rolegl> GetAllList()
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

        public List<ICS_Rolegl> GetRoleglByUser(string userid)
        {
            return dal.GetRoleglByUser(userid);
        }
    }
}
