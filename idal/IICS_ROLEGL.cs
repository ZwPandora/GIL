using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;

namespace thesis.idal
{
    public interface IICS_ROLEGLDal
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ICS_Rolegl model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ICS_Rolegl model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ICS_Rolegl GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<ICS_Rolegl> GetList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<ICS_Rolegl> GetList(string strWhere, string ss);

        List<ICS_Rolegl> GetAllList();
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);


        List<ICS_Rolegl> GetRoleglByUser(string userid);

        #endregion  成员方法
    }
}
