﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IFI_RFDal
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
        void Add(FI_RF model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(FI_RF model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        void Delete(string strWhere);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>


        FI_RF GetModel(int ID);

        FI_RF GetModel(string name);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<FI_RF> GetList(string strWhere);

        DataSet GetDataSet(string strWhere);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法

        List<FI_RF> GetAllList();

    }
}
