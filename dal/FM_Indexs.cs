using System;
using System.Data;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Collections.Generic;

namespace thesis.dal
{
    public class FM_IndexsDal:IFM_IndexsDal
    {
        public FM_IndexsDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FM_Indexs");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FM_Indexs");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.FM_Indexs model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FM_Indexs(");
            strSql.Append("ID,FM_NAME,INDEX_NAME,INDEX_VALUE");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FM_NAME + "',");
            strSql.Append("'" + model.INDEX_NAME + "',");
            strSql.Append("" + model.INDEX_VALUE + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.FM_Indexs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FM_Indexs set ");
            strSql.Append("FM_NAME='" + model.FM_NAME + "',");
            strSql.Append("INDEX_NAME='" + model.INDEX_NAME + "',");
            strSql.Append("INDEX_VALUE='" + model.INDEX_VALUE + "',");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FM_Indexs ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.FM_Indexs GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,FM_NAME,INDEX_NAME,INDEX_VALUE");
            strSql.Append(" from FM_Indexs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FM_Indexs model = new thesis.model.FM_Indexs();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FM_NAME = ds.Tables[0].Rows[0]["FM_NAME"].ToString();
                model.INDEX_NAME = ds.Tables[0].Rows[0]["INDEX_NAME"].ToString();
                model.INDEX_VALUE = ds.Tables[0].Rows[0]["INDEX_VALUE"].ToString();
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
        public thesis.model.FM_Indexs GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<FM_Indexs> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FM_NAME,INDEX_NAME,INDEX_VALUE");
            strSql.Append(" FROM FM_Indexs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FM_Indexs> list = new List<FM_Indexs>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.FM_Indexs model = new thesis.model.FM_Indexs();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FM_NAME = ds.Tables[0].Rows[0]["FM_NAME"].ToString();
                model.INDEX_NAME = ds.Tables[0].Rows[0]["INDEX_NAME"].ToString();
                model.INDEX_VALUE = ds.Tables[0].Rows[0]["INDEX_VALUE"].ToString();
                list.Add(model);
            }
            return list;
        }

        public FM_Indexs GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<FM_Indexs> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        ///获取DataSet
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FM_NAME,INDEX_NAME,INDEX_VALUE");
            strSql.Append(" FROM FM_Indexs ");
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
