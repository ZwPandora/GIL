using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;

namespace thesis.idal
{
    public interface IICS_OBQXDal
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
        void Add(ICS_Obqx model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ICS_Obqx model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ICS_Obqx GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<ObjectRange> GetList(int PageSize,int PageIndex,string strWhere);
        List<ICS_Obqx> GetAllList();
        List<ICS_Obqx> GetUserRanges(int UserID);
        List<ICS_Obqx> GetGroupRanges(int GroupID);
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
