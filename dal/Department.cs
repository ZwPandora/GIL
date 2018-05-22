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
    public class DepartmentDal : IDepartmentDal
    {
        public DepartmentDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "DEPARTMENT");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DEPARTMENT");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.Department model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into department(");
            strSql.Append("ID,NAME,MASTER,ADDRESS,COMPANYID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.NAME + "',");
            strSql.Append("'" + model.MASTER + "',");
            strSql.Append("'" + model.ADDRESS + "',");
            strSql.Append("" + model.COMPANYID + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DEPARTMENT set ");
            strSql.Append("NAME='" + model.NAME + "',");
            strSql.Append("MASTER='" + model.MASTER + "',");
            strSql.Append("ADDRESS='" + model.ADDRESS + "',");
            strSql.Append("COMPANYID=" + model.COMPANYID + "");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Department ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.Department GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,NAME,MASTER,ADDRESS,COMPANYID ");
            strSql.Append(" from Department ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.Department model = new thesis.model.Department();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.MASTER = ds.Tables[0].Rows[0]["MASTER"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                model.COMPANYID = int.Parse(ds.Tables[0].Rows[0]["COMPANYID"].ToString());
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
        public thesis.model.Department GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<Department> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,MASTER,ADDRESS,COMPANYID");
            strSql.Append(" FROM Department ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Department> list = new List<Department>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.Department model = new thesis.model.Department();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                model.MASTER = ds.Tables[0].Rows[i]["MASTER"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[i]["ADDRESS"].ToString();
                model.COMPANYID = int.Parse(ds.Tables[0].Rows[i]["COMPANYID"].ToString());
                list.Add(model);
            }
            return list;
        }

        public Department GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<Department> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        #endregion  成员方法
    }
}

