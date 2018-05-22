using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Data;

namespace thesis.dal
{
    public class FMEAItemDal:IFMEAItemDal
    {
        public FMEAItemDal(){}

        #region 成员方法

        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FMEAITEM");
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FMEAITEM");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public void Add(model.FMEAItem model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FMEAITEM(");
            strSql.Append("ID,UUID,FI_name,FI_describe,FI_startTime,FI_endTime,ExpertNumber,EvaluatedNumber,IsSubmit,IsComplete,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.UUID + "',");
            strSql.Append("'" + model.FI_name + "',");
            strSql.Append("'" + model.FI_describe + "',");
            strSql.Append("'" + model.FI_startTime + "',");
            strSql.Append("'" + model.FI_endTime + "',");
            strSql.Append("'" + model.ExpertNumber + "',");
            strSql.Append("'" + model.EvaluatedNumber + "',");
            strSql.Append("'" + model.IsSubmit + "',");
            strSql.Append("'" + model.IsComplete + "',");
            strSql.Append("'" + model.Spare1 + "',");
            strSql.Append("'" + model.Spare2 + "',");
            strSql.Append("'" + model.Spare3 + "',");
            strSql.Append("'" + model.Spare4 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Update(model.FMEAItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FMEAITEM set ");
            strSql.Append("FI_name='" + model.FI_name + "',");
            strSql.Append("UUID='" + model.UUID + "',");
            strSql.Append("FI_describe='" + model.FI_describe + "',");
            strSql.Append("FI_startTime='" + model.FI_startTime + "',");
            strSql.Append("FI_endTime='" + model.FI_endTime + "',");
            strSql.Append("ExpertNumber='" + model.ExpertNumber + "',");
            strSql.Append("EvaluatedNumber='" + model.EvaluatedNumber + "',");
            strSql.Append("IsSubmit='" + model.IsSubmit + "',");
            strSql.Append("IsComplete='" + model.IsComplete + "',");
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
            strSql.Append("delete FMEAITEM ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
       

        private FMEAItem GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UUID,FI_name,FI_describe,FI_startTime,FI_endTime,ExpertNumber,EvaluatedNumber,IsSubmit,IsComplete,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FMEAITEM ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FMEAItem model = new thesis.model.FMEAItem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UUID = ds.Tables[0].Rows[0]["UUID"].ToString();
                model.FI_name = ds.Tables[0].Rows[0]["FI_name"].ToString();
                model.FI_describe = ds.Tables[0].Rows[0]["FI_describe"].ToString();
                model.FI_startTime = ds.Tables[0].Rows[0]["FI_startTime"].ToString();
                model.FI_endTime = ds.Tables[0].Rows[0]["FI_endTime"].ToString();
                model.ExpertNumber = int.Parse(ds.Tables[0].Rows[0]["ExpertNumber"].ToString());
                model.EvaluatedNumber = int.Parse(ds.Tables[0].Rows[0]["EvaluatedNumber"].ToString());
                model.IsSubmit = ds.Tables[0].Rows[0]["IsSubmit"].ToString();
                model.IsComplete = ds.Tables[0].Rows[0]["IsComplete"].ToString();
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

        public model.FMEAItem GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }

        public model.FMEAItem GetModel(string name)
        {
            return GetModelByCondition("FI_name'" + name + "'");
        }

        public List<model.FMEAItem> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UUID,FI_name,FI_describe,FI_startTime,FI_endTime,ExpertNumber,EvaluatedNumber,IsSubmit,IsComplete,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FMEAITEM ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FMEAItem> list = new List<FMEAItem>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                FMEAItem model = new FMEAItem();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.UUID = ds.Tables[0].Rows[i]["UUID"].ToString();
                model.FI_name = ds.Tables[0].Rows[i]["FI_name"].ToString();
                model.FI_describe = ds.Tables[0].Rows[i]["FI_describe"].ToString();
                model.FI_startTime = ds.Tables[0].Rows[i]["FI_startTime"].ToString();
                model.FI_endTime = ds.Tables[0].Rows[i]["FI_endTime"].ToString();
                model.ExpertNumber = int.Parse(ds.Tables[i].Rows[i]["ExpertNumber"].ToString());
                model.EvaluatedNumber = int.Parse(ds.Tables[0].Rows[i]["EvaluatedNumber"].ToString());
                model.IsSubmit = ds.Tables[0].Rows[i]["IsSubmit"].ToString();
                model.IsComplete = ds.Tables[0].Rows[i]["IsComplete"].ToString();
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public List<model.FMEAItem> GetAllList()
        {
            return GetList("");
        }

        public System.Data.DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UUID,FI_name,FI_describe,FI_startTime,FI_endTime,ExpertNumber,EvaluatedNumber,IsSubmit,IsComplete,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FMEAITEM ");
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
