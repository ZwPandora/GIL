using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.idal;
using thesis.model;
using System.Data;

namespace thesis.dal
{
    public class RiskFactorDal:IRiskFactor
    {
        public RiskFactorDal() { }
        #region 成员方法

        #endregion

        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "RISKFACTOR");
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RISKFACTOR");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public void Add(model.RiskFactor model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RiskFactor(");
            strSql.Append("ID,RF_code,RF_name,RF_class,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.RF_code + "',");
            strSql.Append("'" + model.RF_name + "',");
            strSql.Append("'" + model.RF_class + "',");
            strSql.Append("'" + model.Spare1 + "',");
            strSql.Append("'" + model.Spare2 + "',");
            strSql.Append("'" + model.Spare3 + "',");
            strSql.Append("'" + model.Spare4 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Update(model.RiskFactor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RiskFactor set ");
            strSql.Append("RF_code='" + model.RF_code + "',");
            strSql.Append("RF_name='" + model.RF_name + "',");
            strSql.Append("RF_class='" + model.RF_class + "',");
            strSql.Append("Spare1='" + model.Spare1 + "',");
            strSql.Append("Spare2='" + model.Spare2 + "',");
            strSql.Append("Spare3='" + model.Spare3 + "',");
            strSql.Append("Spare4='" + model.Spare4 + "'");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete RiskFactor ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private RiskFactor GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,RF_code,RF_name,RF_class,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from RiskFactor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.RiskFactor model = new thesis.model.RiskFactor();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.RF_name = ds.Tables[0].Rows[0]["RF_name"].ToString();
                model.RF_code = ds.Tables[0].Rows[0]["RF_code"].ToString();
                model.RF_class = ds.Tables[0].Rows[0]["RF_class"].ToString();
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
        /// 使用ID查找结果
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public RiskFactor GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 使用名称查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RiskFactor GetModel(string name)
        {
            return GetModelByCondition("RF_name'" + name + "'");
        }

        /// <summary>
        /// 获取结果集合
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<model.RiskFactor> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RF_code,RF_name,RF_class,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM RiskFactor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<RiskFactor> list = new List<RiskFactor>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                RiskFactor model = new RiskFactor();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.RF_name = ds.Tables[0].Rows[i]["RF_name"].ToString();
                model.RF_code = ds.Tables[0].Rows[i]["RF_code"].ToString();
                model.RF_class = ds.Tables[0].Rows[i]["RF_class"].ToString();
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RF_name,RF_code,RF_class,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM RISKFACTOR ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;

        }

        /// <summary>
        /// 获取所有结果
        /// </summary>
        /// <returns></returns>
        public List<model.RiskFactor> GetAllList()
        {
            return GetList("");
        }
    }
}
