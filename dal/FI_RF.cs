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
    public class FI_RFDal : IFI_RFDal
    {
        public FI_RFDal() { }
        #region 成员方法

        #endregion

        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FI_RF");
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FI_RF");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public void Add(model.FI_RF model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FI_RF(");
            strSql.Append("ID,FI_ID,RF_name,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FI_ID + "',");
            strSql.Append("'" + model.RF_name + "',");

            strSql.Append("'" + model.Spare1 + "',");
            strSql.Append("'" + model.Spare2 + "',");
            strSql.Append("'" + model.Spare3 + "',");
            strSql.Append("'" + model.Spare4 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Update(model.FI_RF model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FI_RF set ");
            strSql.Append("FI_ID='" + model.FI_ID + "',");
            strSql.Append("FM_name='" + model.RF_name + "',");

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
            strSql.Append("delete FI_RF ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FI_RF ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private FI_RF GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,FI_ID,RF_name,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FI_RF ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FI_RF model = new thesis.model.FI_RF();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FI_ID = int .Parse (ds.Tables[0].Rows[0]["FI_ID"].ToString());
                model.RF_name = ds.Tables[0].Rows[0]["RF_name"].ToString();

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
        public FI_RF GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 使用名称查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FI_RF GetModel(string name)
        {
            return GetModelByCondition("RF_name'" + name + "'");
        }

        /// <summary>
        /// 获取结果集合
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<model.FI_RF> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_ID,RF_name,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FI_RF ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FI_RF> list = new List<FI_RF>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                FI_RF model = new FI_RF();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FI_ID = int .Parse (ds.Tables[0].Rows[i]["FI_ID"].ToString());
                model.RF_name = ds.Tables[0].Rows[i]["RF_name"].ToString();

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
            strSql.Append("select ID,FI_ID,RF_name,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FI_RF ");
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
        public List<model.FI_RF> GetAllList()
        {
            return GetList("");
        }
    }
}
