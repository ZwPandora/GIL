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
    public class EvaluationCriteriaDal : IEvaluationCriteriaDal
    {
        public EvaluationCriteriaDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "EvaluationCriteria");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RF_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from EvaluationCriteria");
            strSql.Append(" where RF_name='" + RF_name + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.EvaluationCriteria model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EvaluationCriteria(");
            strSql.Append("ID,RF_name,LingVar,Criteria,Number_,RoughNumber,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.RF_name + "',");
            strSql.Append("'" + model.LingVar + "',");
            strSql.Append("'" + model.Criteria + "',");
            strSql.Append("'" + model.Number_ + "',");
            strSql.Append("'" + model.RoughNumber + "',");

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
        public void Update(thesis.model.EvaluationCriteria model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EvaluationCriteria set ");
            strSql.Append("RF_name='" + model.RF_name + "',");
            strSql.Append("LingVar='" + model.LingVar + "',");
            strSql.Append("Criteria='" + model.Criteria + "',");
            strSql.Append("Number_='" + model.Number_ + "',");
            strSql.Append("RoughNumber='" + model.RoughNumber + "',");
            
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
            strSql.Append("delete EvaluationCriteria ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.EvaluationCriteria GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,RF_name,LingVar,Criteria,Number_,RoughNumber,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from EvaluationCriteria ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.EvaluationCriteria model = new thesis.model.EvaluationCriteria();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.RF_name = ds.Tables[0].Rows[0]["RF_name"].ToString();
                model.LingVar = ds.Tables[0].Rows[0]["LingVar"].ToString();
                model.Criteria = ds.Tables[0].Rows[0]["Criteria"].ToString();
                model.Number_ = ds.Tables[0].Rows[0]["Number_"].ToString();
                model.RoughNumber = ds.Tables[0].Rows[0]["RoughNumber"].ToString();

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
        public thesis.model.EvaluationCriteria GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EvaluationCriteria> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RF_name,LingVar,Criteria,Number_,RoughNumber,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM EvaluationCriteria ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<EvaluationCriteria> list = new List<EvaluationCriteria>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.EvaluationCriteria model = new thesis.model.EvaluationCriteria();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.RF_name = ds.Tables[0].Rows[i]["RF_name"].ToString();
                model.LingVar = ds.Tables[0].Rows[i]["LingVar"].ToString();
                model.Criteria = ds.Tables[0].Rows[i]["Criteria"].ToString();
                model.Number_ = ds.Tables[0].Rows[i]["Number_"].ToString();
                model.RoughNumber = ds.Tables[0].Rows[i]["RoughNumber"].ToString();
               
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public EvaluationCriteria GetModel(string name)
        {
            return GetModelByCondition("RF_name='" + name + "'");
        }
        public List<EvaluationCriteria> GetAllList()
        {
            return GetList("");
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RF_name,LingVar,Criteria,Number_,RoughNumber,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM EvaluationCriteria ");
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
