using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using thesis.dal;

namespace thesis.bll
{
    public class ICS_THEME_CONTENTBll
    {
        ICS_THEME_CONTENTDal dal = new ICS_THEME_CONTENTDal();
        public ICS_THEME_CONTENTBll()
        { }



        public int GetMaxId()
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
        public void Add(ICS_THEME_CONENT model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_THEME_CONENT model)
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
        public ICS_THEME_CONENT GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>


        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_THEME_CONENT> GetAllList()
        {
            return GetAllList();
        }
    }
}
