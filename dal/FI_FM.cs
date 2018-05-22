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
    public class FI_FMDal : IFI_FMDal
    {
        public FI_FMDal() { }
        #region 成员方法

        #endregion

        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FI_FM");
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FI_FM");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        public void Add(model.FI_FM model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FI_FM(");
            strSql.Append("ID,FI_ID,FM_name,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FI_ID + "',");
            strSql.Append("'" + model.FM_name + "',");
          
            strSql.Append("'" + model.Spare1 + "',");
            strSql.Append("'" + model.Spare2 + "',");
            strSql.Append("'" + model.Spare3 + "',");
            strSql.Append("'" + model.Spare4 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Update(model.FI_FM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FI_FM set ");
            strSql.Append("FI_ID='" + model.FI_ID + "',");
            strSql.Append("FM_name='" + model.FM_name + "',");
           
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
            strSql.Append("delete FI_FM ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Delete(string  strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FI_FM ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private FI_FM GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,FI_ID,FM_name,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FI_FM ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FI_FM model = new thesis.model.FI_FM();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FI_ID = int .Parse (ds.Tables[0].Rows[0]["FI_ID"].ToString());
                model.FM_name = ds.Tables[0].Rows[0]["FM_name"].ToString();
              
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
        public FI_FM GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 使用名称查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FI_FM GetModel(string name)
        {
            return GetModelByCondition("FM_name'" + name + "'");
        }

        /// <summary>
        /// 获取结果集合
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<model.FI_FM> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_ID,FM_name,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FI_FM ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FI_FM> list = new List<FI_FM>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                FI_FM model = new FI_FM();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FI_ID = int .Parse (ds.Tables[0].Rows[i]["FI_ID"].ToString());
                model.FM_name = ds.Tables[0].Rows[i]["FM_name"].ToString();
              
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
            strSql.Append("select ID,FI_ID,FM_name,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FI_FM ");
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
        public List<model.FI_FM> GetAllList()
        {
            return GetList("");
        }
    }
}
