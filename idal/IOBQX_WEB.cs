using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;

namespace thesis.idal
{
    public interface IObjectRangeDal_Web
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxID();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ObjectRange_Web model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ObjectRange_Web model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ObjectRange_Web GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<ObjectRange> GetList(int PageSize,int PageIndex,string strWhere);
        List<ObjectRange_Web> GetAllList();
        List<ObjectRange_Web> GetUserRanges(int UserID);
        List<ObjectRange_Web> GetGroupRanges(int GroupID);
        bool CheckUserRange(int UserID, int SpeciesType, int SpeciesID);
        #endregion  成员方法
        /// <summary>
        /// 删除已有对象权限
        /// </summary>
        /// <param name="SpeciesType"></param>
        /// <param name="SpeciesID"></param>
        /// <param name="UserLX"></param>
        /// <param name="UserID"></param>
        void DeleteUserRange(int SpeciesType, int SpeciesID, int UserLX, int UserID);
    }
}
