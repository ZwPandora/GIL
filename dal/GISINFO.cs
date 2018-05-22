using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.model;
using thesis.idal;
using thesis.common;
using System.Data;

namespace thesis.dal
{
    public class GISINFODal : IGISINFO
    {
        public GISINFODal()
        { }

        #region 成员方法


        public List<GISINFO> GetAllList()
        {
            return GetList("");
        }

        public List<GISINFO> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PROVINCE,CITY,AREA,LONGITUDE,LATITUDE,ISCAPITAL,P_ORDER,C_ORDER");
            strSql.Append(" FROM GISINFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<GISINFO> list = new List<GISINFO>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.GISINFO model = new thesis.model.GISINFO();

                model.ID = ds.Tables[0].Rows[i]["ID"].ToString();

                model.PROVINCE = ds.Tables[0].Rows[i]["PROVINCE"].ToString();
                model.CITY = ds.Tables[0].Rows[i]["CITY"].ToString();
                model.AREA = ds.Tables[0].Rows[i]["AREA"].ToString();
                model.LONGITUDE = ds.Tables[0].Rows[i]["LONGITUDE"].ToString();
                model.LATITUDE = ds.Tables[0].Rows[i]["LATITUDE"].ToString();
                model.ISCAPITAL = ds.Tables[0].Rows[i]["ISCAPITAL"].ToString();
                model.P_ORDER = ds.Tables[0].Rows[i]["P_ORDER"].ToString();
                model.C_ORDER = ds.Tables[0].Rows[i]["C_ORDER"].ToString();
                list.Add(model);
            }
            return list;
        }

        public DataSet getDistinctProvince()
        {
            DataSet ds = new DataSet();
            string sql = "select distinct province,p_order from gisinfo order by to_number(p_order)";

            ds = DbHelperSQL.Query(sql);
            return ds;
        }

        public DataSet getDistinctCity(string provincename)
        {
            DataSet ds = new DataSet();
            string sql = "select distinct city,c_order from gisinfo where province='" + provincename + "' order by to_number(c_order)";

            ds = DbHelperSQL.Query(sql);

            return ds;
        }

        public DataSet getArea(string cityname)
        {
            DataSet ds = new DataSet();
            string sql = "select distinct area,id from gisinfo where city='" + cityname + "' order by to_number(id)";
            ds = DbHelperSQL.Query(sql);
            return ds;
        }
        #endregion
    }
}
