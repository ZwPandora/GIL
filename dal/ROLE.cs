﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.idal;
using thesis.model;
using System.Data;

namespace thesis.dal
{
    /// <summary>
    /// 数据访问类RoleDal。
    /// </summary>
    public class RoleDal : IRoleDal
    {
        public RoleDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "ROLE");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ROLE");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Role model)
        {
            model.ID = GetMaxId() + 1;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("ID,");
            strSql2.Append("" + model.ID + ",");
            if (model.NAME != null)
            {
                strSql1.Append("NAME,");
                strSql2.Append("'" + model.NAME + "',");
            }
            if (model.ROLEINFO != null)
            {
                strSql1.Append("ROLEINFO,");
                strSql2.Append("'" + model.ROLEINFO + "',");
            }
            if (model.CJR != null)
            {
                strSql1.Append("CJR,");
                strSql2.Append("'" + model.CJR + "',");
            }
            if (model.CREATETIME != null)
            {
                strSql1.Append("CREATETIME,");
                strSql2.Append("to_date('" + model.CREATETIME.ToString() + "','YYYY-MM-DD HH24:MI:SS'),");
            }
            strSql.Append("insert into ROLE(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ROLE set ");
            if (model.NAME != null)
            {
                strSql.Append("NAME='" + model.NAME + "',");
            }
            if (model.ROLEINFO != null)
            {
                strSql.Append("ROLEINFO='" + model.ROLEINFO + "',");
            }
            if (model.CJR != null)
            {
                strSql.Append("CJR='" + model.CJR + "',");
            }
            if (model.CREATETIME != null)
            {
                strSql.Append("CREATETIME=to_date('" + model.CREATETIME.ToString() + "','YYYY-MM-DD HH24:MI:SS'),");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ROLE ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Role GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" ID,NAME,ROLEINFO,CJR,CREATETIME ");
            strSql.Append(" from ROLE ");
            strSql.Append(" where ID=" + ID + " ");
            Role model = new Role();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.ROLEINFO = ds.Tables[0].Rows[0]["ROLEINFO"].ToString();
                model.CJR = ds.Tables[0].Rows[0]["CJR"].ToString();
                if (ds.Tables[0].Rows[0]["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATETIME"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Role> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,ROLEINFO,CJR,CREATETIME ");
            strSql.Append(" FROM ROLE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Role> modelList = new List<Role>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Role model = new Role();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                model.ROLEINFO = ds.Tables[0].Rows[i]["ROLEINFO"].ToString();
                model.CJR = ds.Tables[0].Rows[i]["CJR"].ToString();
                if (ds.Tables[0].Rows[i]["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["CREATETIME"].ToString());
                }
                modelList.Add(model);
            }
            return modelList;
        }

        public List<Role> GetAllList()
        {
            return GetList("");
        }

        #endregion
    }
}
