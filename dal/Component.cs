using System;
using System.Data;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Collections.Generic;

namespace thesis.dal
{
    public class ComponentDal:IComponentDal
    {
        public ComponentDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "Component");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Component");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.Component model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Component(");
            strSql.Append("ID,NAME,INDEX_,PINDEX,DIAGRAM");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.NAME + "',");
            strSql.Append("'" + model.INDEX_ + "',");
            strSql.Append("'" + model.PINDEX + "',");
            strSql.Append("" + model.DIAGRAM + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Component set ");
            strSql.Append("NAME='" + model.NAME+ "',");
            strSql.Append("INDEX_='" + model.INDEX_ + "',");
            strSql.Append("PINDEX='" + model.PINDEX + "',");
            strSql.Append("DIAGRAM='" + model.DIAGRAM + "',");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Component ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.Component GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,NAME,INDEX_,PINDEX,DIAGRAM ");
            strSql.Append(" from Component ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.Component model = new thesis.model.Component();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.INDEX_ = ds.Tables[0].Rows[0]["INDEX_"].ToString();
                model.PINDEX = ds.Tables[0].Rows[0]["PINDEX"].ToString();
                model.DIAGRAM = int.Parse(ds.Tables[0].Rows[0]["DIAGRAM"].ToString());
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
        public thesis.model.Component GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<Component> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,INDEX_,PINDEX,DIAGRAM");
            strSql.Append(" FROM Component ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Component> list = new List<Component>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.Component model = new thesis.model.Component();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.INDEX_ = ds.Tables[0].Rows[0]["INDEX_"].ToString();
                model.PINDEX = ds.Tables[0].Rows[0]["PINDEX"].ToString();
                model.DIAGRAM = int.Parse(ds.Tables[0].Rows[0]["DIAGRAM"].ToString());
                list.Add(model);
            }
            return list;
        }

        public Component GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<Component> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        ///获取DataSet
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,INDEX_,PINDEX,DIAGRAM");
            strSql.Append(" FROM Component ");
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
