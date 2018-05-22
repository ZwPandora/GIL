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
    public class ExpertInfoDal : IExpertInfoDal
    {
        public ExpertInfoDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "ExpertInfo");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Exp_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExpertInfo");
            strSql.Append(" where Exp_name='" + Exp_name + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.ExpertInfo model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ExpertInfo(");
            strSql.Append("ID,UUID,Exp_name,Exp_company,Exp_tel,Exp_email,Exp_title,Exp_major,Exp_address,Exp_sex,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.UUID + "',");
            strSql.Append("'" + model.Exp_name + "',");
            strSql.Append("'" + model.Exp_company + "',");
            strSql.Append("'" + model.Exp_tel + "',");
            strSql.Append("'" + model.Exp_email + "',");
            strSql.Append("'" + model.Exp_title + "',");

            strSql.Append("'" + model.Exp_major + "',");
            strSql.Append("'" + model.Exp_address + "',");
            strSql.Append("'" + model.Exp_sex + "',");

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
        public void Update(thesis.model.ExpertInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExpertInfo set ");
            strSql.Append("UUID='" + model.UUID + "',");
            strSql.Append("Exp_name='" + model.Exp_name + "',");
            strSql.Append("Exp_company='" + model.Exp_company + "',");
            strSql.Append("Exp_tel='" + model.Exp_tel + "',");
            strSql.Append("Exp_email='" + model.Exp_email + "',");
            strSql.Append("Exp_title='" + model.Exp_title + "',");

            strSql.Append("Exp_major='" + model.Exp_major + "',");
            strSql.Append("Exp_address='" + model.Exp_address + "',");
            strSql.Append("Exp_sex='" + model.Exp_sex + "',");
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
            strSql.Append("delete ExpertInfo ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.ExpertInfo GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,UUID,Exp_name,Exp_company,Exp_tel,Exp_email,Exp_title,Exp_major,Exp_address,Exp_sex,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from ExpertInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.ExpertInfo model = new thesis.model.ExpertInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UUID = ds.Tables[0].Rows[0]["UUID"].ToString();
                model.Exp_name = ds.Tables[0].Rows[0]["Exp_name"].ToString();
                model.Exp_company = ds.Tables[0].Rows[0]["Exp_company"].ToString();
                model.Exp_tel = ds.Tables[0].Rows[0]["Exp_tel"].ToString();
                model.Exp_email = ds.Tables[0].Rows[0]["Exp_email"].ToString();
                model.Exp_title = ds.Tables[0].Rows[0]["Exp_title"].ToString();

                model.Exp_major = ds.Tables[0].Rows[0]["Exp_major"].ToString();
                model.Exp_address = ds.Tables[0].Rows[0]["Exp_address"].ToString();
                model.Exp_sex = ds.Tables[0].Rows[0]["Exp_sex"].ToString();
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
        public thesis.model.ExpertInfo GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ExpertInfo> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UUID,Exp_name,Exp_company,Exp_tel,Exp_email,Exp_title,Exp_major,Exp_address,Exp_sex,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM ExpertInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ExpertInfo> list = new List<ExpertInfo>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.ExpertInfo model = new thesis.model.ExpertInfo();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.UUID = ds.Tables[0].Rows[i]["UUID"].ToString();
                model.Exp_name = ds.Tables[0].Rows[i]["Exp_name"].ToString();
                model.Exp_company = ds.Tables[0].Rows[i]["Exp_company"].ToString();
                model.Exp_tel = ds.Tables[0].Rows[i]["Exp_tel"].ToString();
                model.Exp_email = ds.Tables[0].Rows[i]["Exp_email"].ToString();
                model.Exp_title = ds.Tables[0].Rows[i]["Exp_title"].ToString();

                model.Exp_major = ds.Tables[0].Rows[i]["Exp_major"].ToString();
                model.Exp_address = ds.Tables[0].Rows[i]["Exp_address"].ToString();
                model.Exp_sex = ds.Tables[0].Rows[i]["Exp_sex"].ToString();
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public ExpertInfo GetModel(string name)
        {
            return GetModelByCondition("UUID='" + name + "'");
        }
        public List<ExpertInfo> GetAllList()
        {
            return GetList("");
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UUID,Exp_name,Exp_company,Exp_tel,Exp_email,Exp_title,Exp_major,Exp_address,Exp_sex,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM ExpertInfo ");
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
