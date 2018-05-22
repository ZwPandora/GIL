using System;
using System.Data;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Collections.Generic;

namespace thesis.dal
{
    public class GILIndexDal : IGILIndexDal
    {
        public GILIndexDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "IndexSystem");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from IndexSystem");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(GILIndexModel model)
        {
            model.ID = GetMaxID() + 1;
            model.INDEX_ = model.ID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into INDEXSYSTEM(");
            strSql.Append("ID,NAME,INDEX_,PINDEX,THRESHOLD,CS");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.NAME + "',");
            strSql.Append("'" + model.INDEX_ + "',");
            strSql.Append("'" + model.PINDEX + "',");
            strSql.Append("'" + model.THRESHOLD + "',");
            strSql.Append("'" + model.CS + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GILIndexModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IndexSystem set ");
            strSql.Append("NAME='" + model.NAME + "',");
            strSql.Append("INDEX_='" + model.INDEX_ + "',");
            strSql.Append("PINDEX='" + model.PINDEX + "',");
            strSql.Append("THRESHOLD='" + model.THRESHOLD + "',");
            strSql.Append("CS='" + model.CS + "'");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete IndexSystem ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private GILIndexModel GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,NAME,INDEX_,PINDEX,THRESHOLD,CS ");
            strSql.Append(" from IndexSystem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            GILIndexModel model = new GILIndexModel();
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
                model.THRESHOLD =ds.Tables[0].Rows[0]["THRESHOLD"].ToString();
                model.CS = ds.Tables[0].Rows[0]["CS"].ToString();
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
        public GILIndexModel GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GILIndexModel> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,INDEX_,PINDEX,THRESHOLD,CS");
            strSql.Append(" FROM IndexSystem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<GILIndexModel> list = new List<GILIndexModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                GILIndexModel model = new GILIndexModel();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                model.INDEX_ = ds.Tables[0].Rows[i]["INDEX_"].ToString();
                model.PINDEX = ds.Tables[0].Rows[i]["PINDEX"].ToString();
                model.THRESHOLD = ds.Tables[0].Rows[i]["THRESHOLD"].ToString();
                model.CS = ds.Tables[0].Rows[i]["CS"].ToString();
                list.Add(model);
            }
            return list;
        }

        public GILIndexModel GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name + "'");
        }
        public List<GILIndexModel> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        ///获取DataSet
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,INDEX_,PINDEX,THRESHOLD,CS");
            strSql.Append(" FROM IndexSystem ");
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
