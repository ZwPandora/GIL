using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.idal;
using thesis.factory;
using System.Data;
using thesis.model;
using thesis.idal;

namespace thesis.bll
{
    public class GISINFOBll
    {
        private readonly IGISINFO dal = DataAccess.CreateGISINFODal();
        public GISINFOBll()
        { }

        public List<GISINFO> GetAllList()
        {
            return dal.GetAllList();
        }
        public List<GISINFO> GetList(string where)
        {
            return dal.GetList(where);
        }
        public DataSet getArea(string cityname)
        {
            return dal.getArea(cityname);
        }
        public DataSet getDistinctCity(string provincename)
        {
            return dal.getDistinctCity(provincename);
        }
        public DataSet getDistinctProvince()
        {
            return dal.getDistinctProvince();
        }
    }
}
