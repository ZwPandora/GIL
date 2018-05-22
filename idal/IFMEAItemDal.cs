using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IFMEAItemDal
    {
        #region  成员方法

        int GetMaxID();

        bool Exists(int ID);

        void Add(FMEAItem model);

        void Update(FMEAItem model);

        void Delete(int ID);

        FMEAItem GetModel(int ID);

        FMEAItem GetModel(string name);

        List<FMEAItem> GetList(string strWhere);

        List<FMEAItem> GetAllList();

        DataSet GetDataSet(string strWhere);

        #endregion  成员方法

        
    }
}
