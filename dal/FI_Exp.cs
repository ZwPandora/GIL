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
    /// 数据访问类FailureMode。
    /// </summary>
    public class FI_ExpDal : IFI_ExpDal
    {
        public FI_ExpDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FI_Exp");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string FI_UUID, string Exp_UUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FI_Exp");
            strSql.Append(" where FI_UUID='" + FI_UUID + "' and Exp_UUID='" + Exp_UUID + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.FI_Exp model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FI_Exp(");
            strSql.Append("ID,FI_UUID,Exp_UUID,IsEvaluated,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FI_UUID + "',");
            strSql.Append("'" + model.EXP_UUID + "',");
            strSql.Append("'" + model.ISEVALUATED + "',");
           
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
        public void Update(thesis.model.FI_Exp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FI_Exp set ");
            strSql.Append("FI_UUID='" + model.FI_UUID + "',");
            strSql.Append("Exp_UUID='" + model.EXP_UUID + "',");
            strSql.Append("IsEvaluated='" + model.ISEVALUATED + "',");
           
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
            strSql.Append("delete FI_Exp ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FI_Exp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.FI_Exp GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,FI_UUID,EXP_UUID,IsEvaluated,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FI_Exp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FI_Exp model = new thesis.model.FI_Exp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FI_UUID = ds.Tables[0].Rows[0]["FI_UUID"].ToString();
                model.EXP_UUID = ds.Tables[0].Rows[0]["EXP_UUID"].ToString();
                model.ISEVALUATED = ds.Tables[0].Rows[0]["ISEVALUATED"].ToString();
               
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
        public thesis.model.FI_Exp GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FI_Exp> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_UUID,EXP_UUID,IsEvaluated,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FI_Exp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FI_Exp> list = new List<FI_Exp>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.FI_Exp model = new thesis.model.FI_Exp();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FI_UUID = ds.Tables[0].Rows[i]["FI_UUID"].ToString();
                model.EXP_UUID = ds.Tables[0].Rows[i]["EXP_UUID"].ToString();
                model.ISEVALUATED = ds.Tables[0].Rows[i]["ISEVALUATED"].ToString();
               
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public FI_Exp GetModel(string name)
        {
            return GetModelByCondition("FM_name='" + name + "'");
        }
        public List<FI_Exp> GetAllList()
        {
            return GetList("");
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FI_UUID,EXP_UUID,IsEvaluated,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FI_Exp ");
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
