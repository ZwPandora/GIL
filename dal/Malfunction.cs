using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using System.Data;
using thesis.model;
using thesis.idal;

namespace thesis.dal
{
    /// <summary>
    /// 数据访问类Malfunction。
    /// </summary>
    public class MalfunctionDal : IMalfunctionDal
    {
        public MalfunctionDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "Malfunction");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Mal_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Malfunction");
            strSql.Append(" where Mal_name='" + Mal_name + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.Malfunction model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Malfunction(");
            strSql.Append("ID,Mal_name,Mal_S,Mal_O,Mal_D,Mal_RPN,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.Mal_name + "',");
            strSql.Append("'" + model.Mal_S + "',");
            strSql.Append("'" + model.Mal_O + "',");
            strSql.Append("'" + model.Mal_D + "',");
            strSql.Append("'" + model.Mal_RPN + "',");
            strSql.Append("'" + model.Spare1 + "',");
            strSql.Append("'" + model.Spare2 + "',");
            strSql.Append("'" + model.Spare3 + "',");
            strSql.Append("'" + model.Spare4 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(thesis.model.Malfunction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Malfunction set ");
            strSql.Append("Mal_name='" + model.Mal_name + "',");
            strSql.Append("Mal_S='" + model.Mal_S + "',");
            strSql.Append("Mal_O='" + model.Mal_O + "',");
            strSql.Append("Mal_D='" + model.Mal_D + "',");
            strSql.Append("Mal_RPN='" + model.Mal_RPN + "',");
            strSql.Append("Spare1='" + model.Spare1 + "',");
            strSql.Append("Spare2='" + model.Spare2 + "',");
            strSql.Append("Spare3='" + model.Spare3 + "',");
            strSql.Append("Spare4='" + model.Spare4 + "'");

            strSql.Append(" where ID=" + model.ID + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Malfunction ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.Malfunction GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,Mal_name,Mal_S,Mal_O,Mal_D,Mal_RPN,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from Malfunction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.Malfunction model = new thesis.model.Malfunction();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Mal_name = ds.Tables[0].Rows[0]["Mal_name"].ToString();
                model.Mal_S = ds.Tables[0].Rows[0]["Mal_S"].ToString();
                model.Mal_O = ds.Tables[0].Rows[0]["Mal_O"].ToString();
                model.Mal_D = ds.Tables[0].Rows[0]["Mal_D"].ToString();
                model.Mal_RPN = ds.Tables[0].Rows[0]["Mal_RPN"].ToString();
                model.Spare1 = ds.Tables[0].Rows[0]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[0]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[0]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[0]["Spare4"].ToString();
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
        public thesis.model.Malfunction GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Malfunction> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Mal_name,Mal_S,Mal_O,Mal_D,Mal_RPN,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM Malfunction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Malfunction> list = new List<Malfunction>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.Malfunction model = new thesis.model.Malfunction();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.Mal_name = ds.Tables[0].Rows[i]["Mal_name"].ToString();
                model.Mal_S = ds.Tables[0].Rows[i]["Mal_S"].ToString();
                model.Mal_O = ds.Tables[0].Rows[i]["Mal_O"].ToString();
                model.Mal_D = ds.Tables[0].Rows[i]["Mal_D"].ToString();
                model.Mal_RPN = ds.Tables[0].Rows[i]["Mal_RPN"].ToString();
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public Malfunction GetModel(string name)
        {
            return GetModelByCondition("Mal_name='" + name + "'");
        }
        public List<Malfunction> GetAllList()
        {
            return GetList("");
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Mal_name,Mal_S,Mal_O,Mal_D,Mal_RPN,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM Malfunction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
        /*
        */

        #endregion  成员方法
    }
}

