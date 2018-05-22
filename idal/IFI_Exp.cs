using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IFI_ExpDal
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxID();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string FI_UUID, string Exp_UUID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(FI_Exp model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(FI_Exp model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        void Delete(string strWhere);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        FI_Exp GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<User> GetList(int PageSize,int PageIndex,string strWhere);
        List<FI_Exp> GetList(string strWhere);
        #endregion  成员方法

        List<FI_Exp> GetAllList();

        DataSet GetDataSet(string strWhere);

        FI_Exp GetModel(string name);
    }
}
