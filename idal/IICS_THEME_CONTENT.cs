using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;

namespace thesis.idal
{
    public interface IICS_THEME_CONTENTDal
    {
        #region 成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxID();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int INDEX_);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ICS_THEME_CONENT model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ICS_THEME_CONENT model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int INDEX_);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ICS_THEME_CONENT GetModel(int INDEX_);
        List<ICS_THEME_CONENT> GetAllList();
        #endregion
    }
}
