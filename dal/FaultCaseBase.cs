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
    /// 数据访问类FaultCaseBase。
    /// </summary>
    public class FaultCaseBaseDal: IFaultCaseBaseDal
    {
        public FaultCaseBaseDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "FaultCaseBase");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FaultCaseBase");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.FaultCaseBase model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FaultCaseBase(");
            strSql.Append("ID,FM_name,Mal_name,FC_time,FC_place,FC_describe,FC_lost,FC_repair,FC_RT,FC_part,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("'" + model.FM_name + "',");
            strSql.Append("'" + model.Mal_name + "',");
            strSql.Append("'" + model.FC_time  + "',");
            strSql.Append("'" + model.FC_place + "',");
            strSql.Append("'" + model.FC_describe + "',");
            strSql.Append("'" + model.FC_lost + "',");
            strSql.Append("'" + model.FC_repair + "',");
            strSql.Append("'" + model.FC_RT + "',");
            strSql.Append("'" + model.FC_part + "',");
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
        public void Update(thesis.model.FaultCaseBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FaultCaseBase set ");
            strSql.Append("FM_name='" + model.FM_name + "',");
            strSql.Append("Mal_name='" + model.Mal_name + "',");
            strSql.Append("FC_time='" + model.FC_time + "',");
            strSql.Append("FC_place='" + model.FC_place + "',");
            strSql.Append("FC_describe='" + model.FC_describe + "',");
            strSql.Append("FC_lost='" + model.FC_lost + "',");
            strSql.Append("FC_repair='" + model.FC_repair + "',");
            strSql.Append("FC_RT='" + model.FC_RT + "',");
            strSql.Append("FC_part='" + model.FC_part + "',");
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
            strSql.Append("delete FaultCaseBase ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.FaultCaseBase GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,FM_name,Mal_name,FC_time,FC_place,FC_describe,FC_lost,FC_repair,FC_RT,FC_part,Spare1,Spare2,Spare3,Spare4 ");
            strSql.Append(" from FaultCaseBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.FaultCaseBase model = new thesis.model.FaultCaseBase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FM_name = ds.Tables[0].Rows[0]["FM_name"].ToString();
                model.Mal_name = ds.Tables[0].Rows[0]["Mal_name"].ToString();
                model.FC_time = ds.Tables[0].Rows[0]["FC_time"].ToString();
                model.FC_place = ds.Tables[0].Rows[0]["FC_place"].ToString();
                model.FC_describe = ds.Tables[0].Rows[0]["FC_describe"].ToString();
                model.FC_lost = ds.Tables[0].Rows[0]["FC_lost"].ToString();
                model.FC_repair = ds.Tables[0].Rows[0]["FC_repair"].ToString();
                model.FC_RT = ds.Tables[0].Rows[0]["FC_RT"].ToString();
                model.FC_part = ds.Tables[0].Rows[0]["FC_part"].ToString();
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
        public thesis.model.FaultCaseBase GetModel(int ID)
        {
            return GetModelByCondition("ID=" + ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<FaultCaseBase> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FM_name,Mal_name,FC_time,FC_place,FC_describe,FC_lost,FC_repair,FC_RT,FC_part,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FaultCaseBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<FaultCaseBase> list = new List<FaultCaseBase>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.FaultCaseBase model = new thesis.model.FaultCaseBase();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.FM_name = ds.Tables[0].Rows[i]["FM_name"].ToString();
                model.Mal_name = ds.Tables[0].Rows[i]["Mal_name"].ToString();
                model.FC_time = ds.Tables[0].Rows[i]["FC_time"].ToString();
                model.FC_place = ds.Tables[0].Rows[i]["FC_place"].ToString();
                model.FC_describe = ds.Tables[0].Rows[i]["FC_describe"].ToString();
                model.FC_lost = ds.Tables[0].Rows[i]["FC_lost"].ToString();
                model.FC_repair = ds.Tables[0].Rows[i]["FC_repair"].ToString();
                model.FC_RT = ds.Tables[0].Rows[i]["FC_RT"].ToString();
                model.FC_part = ds.Tables[0].Rows[i]["FC_part"].ToString();
                model.Spare1 = ds.Tables[0].Rows[i]["Spare1"].ToString();
                model.Spare2 = ds.Tables[0].Rows[i]["Spare2"].ToString();
                model.Spare3 = ds.Tables[0].Rows[i]["Spare3"].ToString();
                model.Spare4 = ds.Tables[0].Rows[i]["Spare4"].ToString();
                list.Add(model);
            }
            return list;
        }

        //public FaultCaseBase GetModel(int ID)
        //{
        //    return GetModelByCondition("ID='" + ID + "'");
        //}
        public List<FaultCaseBase> GetAllList()
        {
            return GetList("");
        }
        /*
        */

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FM_name,Mal_name,FC_time,FC_place,FC_describe,FC_lost,FC_repair,FC_RT,FC_part,Spare1,Spare2,Spare3,Spare4");
            strSql.Append(" FROM FaultCaseBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }

        #endregion  成员方法

        #region IFaultCaseBaseDal 成员


        List<FaultCaseBase> IFaultCaseBaseDal.GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

