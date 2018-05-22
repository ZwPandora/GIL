using System.Data;
using System.Text;
using thesis.common;
using thesis.model;
using System.Collections.Generic;
using thesis.idal;

namespace thesis.dal
{
    /// <summary>
    /// 数据访问类FailureMode。
    /// </summary>
    public class FailureModeDal : IFailureModeDal
    {
        public FailureModeDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FailureMode");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string FM_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FailureMode");
            strSql.Append(" where FM_name='" + FM_name + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.FailureMode model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FailureMode(");
            strSql.Append("ID,FM_name,Mal_name,FM_reason,FM_part,FM_PC,FM_RM,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FM_name + "',");
            strSql.Append("'" + model.Mal_name + "',");
            strSql.Append("'" + model.FM_reason + "',");
            strSql.Append("'" + model.FM_part + "',");
            strSql.Append("'" + model.FM_PC + "',");
            strSql.Append("'" + model.FM_RM + "',");
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
        public void Update(thesis.model.FailureMode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FailureMode set ");
            strSql.Append("FM_name='" + model.FM_name + "',");
            strSql.Append("Mal_name='" + model.Mal_name + "',");
            strSql.Append("FM_reason='" + model.FM_reason + "',");
            strSql.Append("FM_part='" + model.FM_part + "',");
            strSql.Append("FM_PC='" + model.FM_PC + "',");
            strSql.Append("FM_RM='" + model.FM_RM + "',");
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
            strSql.Append("delete FailureMode ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.FailureMode GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,FM_name,Mal_name,FM_reason,FM_part,FM_PC,FM_RM,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FailureMode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FailureMode model = new thesis.model.FailureMode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FM_name = ds.Tables[0].Rows[0]["FM_name"].ToString();
                model.Mal_name = ds.Tables[0].Rows[0]["Mal_name"].ToString();
                model.FM_reason = ds.Tables[0].Rows[0]["FM_reason"].ToString();
                model.FM_part = ds.Tables[0].Rows[0]["FM_part"].ToString();
                model.FM_RM = ds.Tables[0].Rows[0]["FM_RM"].ToString();
                model.FM_PC = ds.Tables[0].Rows[0]["FM_PC"].ToString();
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
        public thesis.model.FailureMode GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FailureMode> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FM_name,Mal_name,FM_reason,FM_part,FM_PC,FM_RM,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FailureMode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FailureMode> list = new List<FailureMode>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.FailureMode model = new thesis.model.FailureMode();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FM_name = ds.Tables[0].Rows[i]["FM_name"].ToString();
                model.Mal_name = ds.Tables[0].Rows[i]["Mal_name"].ToString();
                model.FM_reason = ds.Tables[0].Rows[i]["FM_reason"].ToString();
                model.FM_part = ds.Tables[0].Rows[i]["FM_part"].ToString();
                model.FM_RM = ds.Tables[0].Rows[i]["FM_RM"].ToString();
                model.FM_PC = ds.Tables[0].Rows[i]["FM_PC"].ToString();
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        public FailureMode GetModel(string name)
        {
            return GetModelByCondition("FM_name='" + name + "'");
        }
        public List<FailureMode> GetAllList()
        {
            return GetList("");
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FM_name,Mal_name,FM_reason,FM_part,FM_PC,FM_RM,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FailureMode ");
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

