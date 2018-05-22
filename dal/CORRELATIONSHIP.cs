using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Data;

namespace thesis.dal
{
    
    /// <summary>
    /// 数据访问类CORRELATIONSHIP
    /// </summary>
    public class CORRELATIONSHIPDal : ICORRELATIONSHIPDal
    {
        public CORRELATIONSHIPDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "CORRELATIONSHIP");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CORRELATIONSHIP");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.CORRELATIONSHIP model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CORRELATIONSHIP(");
            strSql.Append("ID,CS_FMID_1,CS_FMID_2,CS_IFCORRELATION,CS_DIRECTION,CS_STRENGTH");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.CS_FMID_1 + "',");
            strSql.Append("'" + model.CS_FMID_2 + "',");
            strSql.Append("'" + model.CS_IFCORRELATION + "',");
            strSql.Append("'" + model.CS_DIRECTION + "',");
            strSql.Append("" + model.CS_STRENGTH + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.CORRELATIONSHIP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CORRELATIONSHIP set ");
            strSql.Append("CS_FMID_1='" + model.CS_FMID_1 + "',");
            strSql.Append("CS_FMID_2='" + model.CS_FMID_2 + "',");
            strSql.Append("CS_IFCORRELATION='" + model.CS_IFCORRELATION + "',");
            strSql.Append("CS_DIRECTION='" + model.CS_DIRECTION + "',");
            strSql.Append("CS_STRENGTH=" + model.CS_STRENGTH + "");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CORRELATIONSHIP ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.CORRELATIONSHIP GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,CS_FMID_1,CS_FMID_2,CS_IFCORRELATION,CS_DIRECTION,CS_STRENGTH ");
            strSql.Append(" from CORRELATIONSHIP ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.CORRELATIONSHIP model = new thesis.model.CORRELATIONSHIP();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.CS_FMID_1 = int.Parse(ds.Tables[0].Rows[0]["CS_FMID_1"].ToString());
                model.CS_FMID_2 = int.Parse(ds.Tables[0].Rows[0]["CS_FMID_2"].ToString());
                model.CS_IFCORRELATION = int.Parse(ds.Tables[0].Rows[0]["CS_IFCORRELATION"].ToString());
                model.CS_DIRECTION = int.Parse(ds.Tables[0].Rows[0]["CS_DIRECTION"].ToString());
                model.CS_STRENGTH = ds.Tables[0].Rows[0]["CS_DIRECTION"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public thesis.model.CORRELATIONSHIP GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<CORRELATIONSHIP> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CS_FMID_1,CS_FMID_2,CS_IFCORRELATION,CS_DIRECTION,CS_STRENGTH");
            strSql.Append(" FROM CORRELATIONSHIP ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<CORRELATIONSHIP> list = new List<CORRELATIONSHIP>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.CORRELATIONSHIP model = new thesis.model.CORRELATIONSHIP();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.CS_FMID_1 = int.Parse(ds.Tables[0].Rows[0]["CS_FMID_1"].ToString());
                model.CS_FMID_2 = int.Parse(ds.Tables[0].Rows[0]["CS_FMID_2"].ToString());
                model.CS_IFCORRELATION = int.Parse(ds.Tables[0].Rows[0]["CS_IFCORRELATION"].ToString());
                model.CS_DIRECTION = int.Parse(ds.Tables[0].Rows[0]["CS_DIRECTION"].ToString());
                model.CS_STRENGTH = ds.Tables[0].Rows[0]["CS_DIRECTION"].ToString();
                list.Add(model);
            }
            return list;
        }

        public CORRELATIONSHIP GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<CORRELATIONSHIP> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        ///获取DataSet
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CS_FMID_1,CS_FMID_2,CS_IFCORRELATION,CS_DIRECTION,CS_STRENGTH");
            strSql.Append(" FROM CORRELATIONSHIP ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }




        #endregion  成员方法
    }
    
}
