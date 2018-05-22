using System;
using System.Data;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Collections.Generic;
namespace thesis.dal
{
    /// <summary>
    /// 数据访问类Company。
    /// </summary>
    public class OfficeDal : IOfficeDal
    {
        public OfficeDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "OFFICE");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OFFICE");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.Office model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into office(");
            strSql.Append("ID,NAME,MASTER,COMPANYID,DEPARTMENTID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.NAME + "',");
            strSql.Append("'" + model.MASTER + "',");
            strSql.Append("" + model.COMPANYID + ",");
            strSql.Append("" + model.DEPARTMENTID + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Office model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OFFICE set ");
            strSql.Append("NAME='" + model.NAME + "',");
            strSql.Append("MASTER='" + model.MASTER + "',");
            strSql.Append("COMPANYID=" + model.COMPANYID + ",");
            strSql.Append("DEPARTMENTID=" + model.DEPARTMENTID + "");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete OFFICE ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.Office GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,NAME,MASTER,COMPANYID, DEPARTMENTID");
            strSql.Append(" from OFFICE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.Office model = new thesis.model.Office();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.MASTER = ds.Tables[0].Rows[0]["MASTER"].ToString();
               
                model.COMPANYID = int.Parse(ds.Tables[0].Rows[0]["COMPANYID"].ToString());
                model.DEPARTMENTID = int.Parse(ds.Tables[0].Rows[0]["DEPARTMENTID"].ToString());
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
        public thesis.model.Office GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<Office> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,MASTER,COMPANYID,DEPARTMENTID");
            strSql.Append(" FROM office ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Office> list = new List<Office>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.Office model = new thesis.model.Office();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                model.MASTER = ds.Tables[0].Rows[i]["MASTER"].ToString();
                model.COMPANYID = int.Parse(ds.Tables[0].Rows[i]["COMPANYID"].ToString());
                model.DEPARTMENTID = int.Parse(ds.Tables[0].Rows[i]["DEPARTMENTID"].ToString());
                list.Add(model);
            }
            return list;
        }

        public Office GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<Office> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        #endregion  成员方法
    }
}

