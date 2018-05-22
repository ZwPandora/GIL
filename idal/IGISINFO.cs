using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using System.Data;

namespace thesis.idal
{
    public interface IGISINFO
    {
        List<GISINFO> GetAllList();
        List<GISINFO> GetList(string where);
        DataSet getArea(string cityname);
        DataSet getDistinctCity(string provincename);
        DataSet getDistinctProvince();
    }
}
