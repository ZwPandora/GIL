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
    public class CompanyDal : ICompanyDal
    {
        public CompanyDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "COMPANY");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from COMPANY");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.Company model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into COMPANY(");
            strSql.Append("ID,NAME,MASTER,WEBSITE,ADDRESS");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.NAME + "',");
            strSql.Append("'" + model.MASTER + "',");
            strSql.Append("'" + model.WEBSITE + "',");
            strSql.Append("'" + model.ADDRESS + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update COMPANY set ");
            strSql.Append("NAME='" + model.NAME + "',");
            strSql.Append("MASTER='" + model.MASTER+ "',");
            strSql.Append("WEBSITE='" + model.WEBSITE+ "',");
            strSql.Append("ADDRESS='" + model.ADDRESS+ "'");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete COMPANY ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.Company GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,NAME,MASTER,WEBSITE,ADDRESS ");
            strSql.Append(" from COMPANY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.Company model = new thesis.model.Company();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.MASTER = ds.Tables[0].Rows[0]["MASTER"].ToString();
                model.WEBSITE = ds.Tables[0].Rows[0]["WEBSITE"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
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
        public thesis.model.Company GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<Company> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,MASTER,WEBSITE,ADDRESS");
            strSql.Append(" FROM COMPANY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Company> list = new List<Company>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.Company model = new thesis.model.Company();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                model.MASTER = ds.Tables[0].Rows[i]["MASTER"].ToString();
                model.WEBSITE = ds.Tables[0].Rows[i]["WEBSITE"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[i]["ADDRESS"].ToString();
                list.Add(model);
            }
            return list;
        }

        public Company GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<Company> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        #endregion  成员方法
    }
}

