﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IFaultCaseBaseDal
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
        void Add(FaultCaseBase model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(FaultCaseBase model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        FaultCaseBase GetModel(int ID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<User> GetList(int PageSize,int PageIndex,string strWhere);
        List<FaultCaseBase> GetList(string strWhere);
        #endregion  成员方法

        List<FaultCaseBase> GetAllList();

        DataSet GetDataSet(string strWhere);

        //FaultCaseBase GetModel(int ID);
    }
}
