using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using thesis.dal;

namespace thesis.bll
{
    public class ICS_OBAXBll
    {
        ICS_OBQXDal dal = new ICS_OBQXDal();
        public ICS_OBAXBll()
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
        public void Add(ICS_Obqx model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_Obqx model)
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
        public ICS_Obqx GetModel(int ID)
        {
            return dal.GetModel(ID);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Obqx> GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<ObjectRange> GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 获得用户所具有的操作范围
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Obqx> GetUserRanges(int UserID)
        {
            return dal.GetUserRanges(UserID);
        }
        /// <summary>
        /// 获得用户组所具有的操作范围
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public List<ICS_Obqx> GetGroupRanges(int GroupID)
        {
            return dal.GetGroupRanges(GroupID);
        }
        /// <summary>
        /// 判断用户可否操作该范围
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="SpeciesType"></param>
        /// <param name="SpeciesID"></param>
        /// <returns></returns>
        public bool CheckUserRange(int UserID, int SpeciesType, int SpeciesID)
        {
            return dal.CheckUserRange(UserID, SpeciesType, SpeciesID);
        }
        /// <summary>
        /// 删除已有对象权限
        /// </summary>
        /// <param name="SpeciesType"></param>
        /// <param name="SpeciesID"></param>
        /// <param name="UserLX"></param>
        /// <param name="UserID"></param>
        public void DeleteUserRange(int SpeciesType, int SpeciesID, int UserLX, int UserID)
        {
            dal.DeleteUserRange(SpeciesType, SpeciesID, UserLX, UserID);
        }
        #endregion  成员方法
    }
}
