using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;

namespace thesis.idal
{
    public interface ILoginRecord
    {
        int GetMaxID();
        void Add(LoginRecord model);
        List<LoginRecord> GetAllList();
        List<LoginRecord> GetList(string where);
    }
}
