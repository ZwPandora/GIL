using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.model;
using System.Data;
using thesis.idal;

namespace thesis.dal
{
    public class EvaluationDal : IEvaluationDal
    {
        public EvaluationDal() { }

        #region 成员方法

        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "Evaluation");
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Evaluation");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public void Add(model.Evaluation model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Evaluation(");
            strSql.Append("ID,FI_ID,FM_name,RF_name,ExpertName,FM_score,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FI_ID + "',");
            strSql.Append("'" + model.FM_name + "',");
            strSql.Append("'" + model.RF_name + "',");
            strSql.Append("'" + model.ExpertName + "',");
            strSql.Append("'" + model.FM_score + "',");
           
            strSql.Append("'" + model.Spare1 + "',");
            strSql.Append("'" + model.Spare2 + "',");
            strSql.Append("'" + model.Spare3 + "',");
            strSql.Append("'" + model.Spare4 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Update(model.Evaluation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Evaluation set ");
            strSql.Append("FI_ID='" + model.FI_ID + "',");
            strSql.Append("FM_name='" + model.FM_name + "',");
            strSql.Append("RF_name='" + model.RF_name + "',");
            strSql.Append("ExpertName='" + model.ExpertName + "',");
            strSql.Append("FM_score='" + model.FM_score + "',");
           
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
            strSql.Append("delete Evaluation ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        private Evaluation GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_ID,FM_name,RF_name,ExpertName,FM_score,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from Evaluation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.Evaluation model = new thesis.model.Evaluation();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FI_ID = int.Parse (ds.Tables[0].Rows[0]["FI_ID"].ToString());
                model.FM_name = ds.Tables[0].Rows[0]["FM_name"].ToString();
                model.RF_name = ds.Tables[0].Rows[0]["RF_name"].ToString();
                model.ExpertName = ds.Tables[0].Rows[0]["ExpertName"].ToString();
                model.FM_score = ds.Tables[0].Rows[0]["FM_score"].ToString();
               
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

        public model.Evaluation GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }

        public model.Evaluation GetModelwhere(int FI_ID)
        {
            return GetModelByCondition("FI_ID'" + FI_ID + "'");
        }

        public List<model.Evaluation> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_ID,FM_name,RF_name,ExpertName,FM_score,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from Evaluation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Evaluation> list = new List<Evaluation>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Evaluation model = new Evaluation();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FI_ID = int.Parse (ds.Tables[0].Rows[i]["FI_ID"].ToString());
                model.FM_name = ds.Tables[0].Rows[i]["FM_name"].ToString();
                model.RF_name = ds.Tables[0].Rows[i]["RF_name"].ToString();
                model.ExpertName = ds.Tables[0].Rows[i]["ExpertName"].ToString();
                model.FM_score =ds.Tables[i].Rows[i]["FM_score"].ToString();
              
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public List<model.Evaluation> GetAllList()
        {
            return GetList("");
        }

        public System.Data.DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_ID,FM_name,RF_name,ExpertName,FM_score,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from Evaluation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;

        }

        #endregion
    }
}
