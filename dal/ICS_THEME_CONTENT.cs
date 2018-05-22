using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using System.Data;
using thesis.common;
using thesis.idal;

namespace thesis.dal
{
    public class ICS_THEME_CONTENTDal : IICS_THEME_CONTENTDal
    {
        public ICS_THEME_CONTENTDal()
        { }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "ICS_THEME_CONTENT");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int INDEX_)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ICS_THEME_CONTENT");
            strSql.Append(" where ID=" + INDEX_ + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ICS_THEME_CONENT model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ICS_THEME_CONTENT(");
            strSql.Append("ID,USERID,THEMEID,DISPLAY_NAME,AUTO_REFRESH,AUTO_REFRESH_INTERVAL,CONTENTID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(model.ID + ",");
            strSql.Append(model.USERID + ",");
            strSql.Append(model.THEMEID + ",");
            strSql.Append("'" + model.DISPLAY_NAME + "',");
            strSql.Append(model.AUTO_REFRESH + ",");
            strSql.Append(model.AUTO_REFRESH_INTERVAL + ",");
            strSql.Append(model.CONTENTID);
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_THEME_CONENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ICS_THEME_CONTENT set ");
            strSql.Append("USERID=" + model.USERID + ",");
            strSql.Append("THEMEID=" + model.THEMEID + ",");
            strSql.Append("DISPLAY_NAME='" + model.DISPLAY_NAME + "',");
            strSql.Append("AUTO_REFRESH=" + model.AUTO_REFRESH + ",");
            strSql.Append("AUTO_REFRESH_INTERVAL=" + model.AUTO_REFRESH_INTERVAL + ",");
            strSql.Append("CONTENTID=" + model.CONTENTID + "");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int INDEX_)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ICS_THEME_CONTENT ");
            strSql.Append(" where id=" + INDEX_ + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private ICS_THEME_CONENT GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,USERID,THEMEID,DISPLAY_NAME,AUTO_REFRESH,AUTO_REFRESH_INTERVAL,CONTENTID");
            strSql.Append(" FROM ICS_THEME_CONTENT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            ICS_THEME_CONENT model = new ICS_THEME_CONENT();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.DISPLAY_NAME = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["USERID"].ToString() != "")
                {
                    model.USERID = int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["THEMEID"].ToString() != "")
                {
                    model.THEMEID = int.Parse(ds.Tables[0].Rows[0]["THEMEID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AUTO_REFRESH"].ToString() != "")
                {
                    model.AUTO_REFRESH = int.Parse(ds.Tables[0].Rows[0]["AUTO_REFRESH"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AUTO_REFRESH_INTERVAL"].ToString() != "")
                {
                    model.AUTO_REFRESH_INTERVAL = int.Parse(ds.Tables[0].Rows[0]["AUTO_REFRESH_INTERVAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CONTENTID"].ToString() != "")
                {
                    model.CONTENTID = int.Parse(ds.Tables[0].Rows[0]["CONTENTID"].ToString());
                }
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
        public ICS_THEME_CONENT GetModel(int INDEX_)
        {
            string strWhere = " ID=" + INDEX_ + " ";
            return GetModel(strWhere);
        }

        public List<ICS_THEME_CONENT> GetAllList()
        {
            return GetList("");
        }

        private List<ICS_THEME_CONENT> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERID,THEMEID,DISPLAY_NAME,AUTO_REFRESH,AUTO_REFRESH_INTERVAL,CONTENTID");
            strSql.Append(" FROM ICS_THEME_CONTENT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ICS_THEME_CONENT> list = new List<ICS_THEME_CONENT>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ICS_THEME_CONENT model = new ICS_THEME_CONENT();
                model.DISPLAY_NAME = ds.Tables[0].Rows[i]["DISPLAY_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["USERID"].ToString() != "")
                {
                    model.USERID = int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["THEMEID"].ToString() != "")
                {
                    model.THEMEID = int.Parse(ds.Tables[0].Rows[0]["THEMEID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AUTO_REFRESH"].ToString() != "")
                {
                    model.AUTO_REFRESH = int.Parse(ds.Tables[0].Rows[0]["AUTO_REFRESH"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AUTO_REFRESH_INTERVAL"].ToString() != "")
                {
                    model.AUTO_REFRESH_INTERVAL = int.Parse(ds.Tables[0].Rows[0]["AUTO_REFRESH_INTERVAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CONTENTID"].ToString() != "")
                {
                    model.CONTENTID = int.Parse(ds.Tables[0].Rows[0]["CONTENTID"].ToString());
                }
                list.Add(model);
            }
            return list;
        }
    }
}
