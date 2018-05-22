using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.model;
using thesis.idal;
using System.Data;

namespace thesis.dal
{
    /// <summary>
    /// 数据访问类RoleglDal。
    /// </summary>
    public class RoleglDal : IRoleglDal
    {
        public RoleglDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "ROLEGL");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ROLEGL");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Rolegl model)
        {
            model.ID = GetMaxId() + 1;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("ID,");
            strSql2.Append("" + model.ID + ",");
            strSql1.Append("ROLE_ID,");
            strSql2.Append("" + model.ROLE_ID + ",");
            if (model.ROLE_NAME != null)
            {
                strSql1.Append("ROLE_NAME,");
                strSql2.Append("'" + model.ROLE_NAME + "',");
            }
            strSql1.Append("YHID,");
            strSql2.Append("" + model.YHID + ",");
            if (model.YH_USERID != null)
            {
                strSql1.Append("YH_USERID,");
                strSql2.Append("'" + model.YH_USERID + "',");
            }
            strSql.Append("insert into ROLEGL(");
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
        public void Update(Rolegl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ROLEGL set ");
            strSql.Append("ROLE_ID=" + model.ROLE_ID + ",");
            if (model.ROLE_NAME != null)
            {
                strSql.Append("ROLE_NAME='" + model.ROLE_NAME + "',");
            }
            strSql.Append("YHID=" + model.YHID + ",");
            if (model.YH_USERID != null)
            {
                strSql.Append("YH_USERID='" + model.YH_USERID + "',");
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
            strSql.Append("delete from ROLEGL ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Rolegl GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" ID,ROLE_ID,ROLE_NAME,YHID,YH_USERID ");
            strSql.Append(" from ROLEGL ");
            strSql.Append(" where ID=" + ID + " ");
            Rolegl model = new Rolegl();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ROLE_ID"].ToString() != "")
                {
                    model.ROLE_ID = int.Parse(ds.Tables[0].Rows[0]["ROLE_ID"].ToString());
                }
                model.ROLE_NAME = ds.Tables[0].Rows[0]["ROLE_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["YHID"].ToString() != "")
                {
                    model.YHID = int.Parse(ds.Tables[0].Rows[0]["YHID"].ToString());
                }
                model.YH_USERID = ds.Tables[0].Rows[0]["YH_USERID"].ToString();
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
        public List<Rolegl> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ROLE_ID,ROLE_NAME,YHID,YH_USERID ");
            strSql.Append(" FROM ROLEGL ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Rolegl> modelList = new List<Rolegl>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Rolegl model = new Rolegl();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["ROLE_ID"].ToString() != "")
                {
                    model.ROLE_ID = int.Parse(ds.Tables[0].Rows[i]["ROLE_ID"].ToString());
                }
                model.ROLE_NAME = ds.Tables[0].Rows[i]["ROLE_NAME"].ToString();
                if (ds.Tables[0].Rows[i]["YHID"].ToString() != "")
                {
                    model.YHID = int.Parse(ds.Tables[0].Rows[i]["YHID"].ToString());
                }
                model.YH_USERID = ds.Tables[0].Rows[i]["YH_USERID"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Rolegl> GetList(string strWhere, string SS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ROLE_ID,ROLE_NAME ");
            strSql.Append(" FROM ROLEGL ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Rolegl> modelList = new List<Rolegl>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Rolegl model = new Rolegl();

                if (ds.Tables[0].Rows[i]["ROLE_ID"].ToString() != "")
                {
                    model.ROLE_ID = int.Parse(ds.Tables[0].Rows[i]["ROLE_ID"].ToString());
                }
                model.ROLE_NAME = ds.Tables[0].Rows[i]["ROLE_NAME"].ToString();

                modelList.Add(model);
            }
            return modelList;
        }

        public List<Rolegl> GetAllList()
        {
            return GetList("");
        }

        public List<Rolegl> GetRoleglByUser(int userid)
        {
            return GetList(" YHID= " + userid);
        }

        #endregion
    }
}
