using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using thesis.common;
using thesis.model;
using thesis.factory;
using thesis.idal;

namespace thesis.bll
{
    public class LoginRecordBLL
    {
        private readonly ILoginRecord dal=DataAccess.CreateLoginRecordDal();
        public LoginRecordBLL()
		{}
        public int GetMaxID()
        {
            return dal.GetMaxID();
        }
        public void Add(thesis.model.LoginRecord model)
        {
            dal.Add(model);
        }
        public List<LoginRecord> GetAllList()
        {
            return dal.GetAllList();
        }

        public List<LoginRecord> GetList(string strWhere) 
        {
            return dal.GetList(strWhere); ;
        }

    }
}
