using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.modal;
using System.Data;
using thesis.idal;

namespace thesis.dal
{
    public class ICS_OBQXDal : IICS_OBQXDal
    {
        public ICS_OBQXDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "ICS_OBQX");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ICS_OBQX");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ICS_Obqx model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ICS_OBQX(");
            strSql.Append("ID,LX,SPECIES_ID,YHLX,YHID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("" + model.LX + ",");
            strSql.Append("" + model.SPECIES_ID + ",");
            strSql.Append("" + model.YHLX + ",");
            strSql.Append("" + model.YHID + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_Obqx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ICS_OBQX set ");
            strSql.Append("LX=" + model.LX + ",");
            strSql.Append("SPECIES_ID=" + model.SPECIES_ID + ",");
            strSql.Append("YHLX=" + model.YHLX + ",");
            strSql.Append("YHID=" + model.YHID + "");
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ICS_OBQX ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ICS_Obqx GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,LX,SPECIES_ID,YHLX,YHID ");
            strSql.Append(" from ICS_OBQX ");
            strSql.Append(" where ID=" + ID + " ");
            ICS_Obqx model = new ICS_Obqx();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LX"].ToString() != "")
                {
                    model.LX = int.Parse(ds.Tables[0].Rows[0]["LX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPECIES_ID"].ToString() != "")
                {
                    model.SPECIES_ID = int.Parse(ds.Tables[0].Rows[0]["SPECIES_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YHLX"].ToString() != "")
                {
                    model.YHLX = int.Parse(ds.Tables[0].Rows[0]["YHLX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YHID"].ToString() != "")
                {
                    model.YHID = int.Parse(ds.Tables[0].Rows[0]["YHID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<ICS_Obqx> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LX,SPECIES_ID,YHLX,YHID ");
            strSql.Append(" FROM ICS_OBQX ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by LX");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ICS_Obqx> list = new List<ICS_Obqx>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ICS_Obqx model = new ICS_Obqx();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["LX"].ToString() != "")
                {
                    model.LX = int.Parse(ds.Tables[0].Rows[i]["LX"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES_ID"].ToString() != "")
                {
                    model.SPECIES_ID = int.Parse(ds.Tables[0].Rows[i]["SPECIES_ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["YHLX"].ToString() != "")
                {
                    model.YHLX = int.Parse(ds.Tables[0].Rows[i]["YHLX"].ToString());
                }
                if (ds.Tables[0].Rows[i]["YHID"].ToString() != "")
                {
                    model.YHID = int.Parse(ds.Tables[0].Rows[i]["YHID"].ToString());
                }
                list.Add(model);
            }
            return list;

        }
        public List<ICS_Obqx> GetAllList()
        {
            return GetList("");
        }
        public List<ICS_Obqx> GetUserRanges(int UserID)
        {
            return GetList("YHLX=" + ICS_Node.SPECIES_USER + " AND YHID=" + UserID);
        }
        public List<ICS_Obqx> GetGroupRanges(int GroupID)
        {
            return GetList("YHLX=" + ICS_Node.SPECIES_ROLE + " AND YHID=" + GroupID);
        }
        public bool CheckUserRange(int UserID, int SpeciesType, int SpeciesID)
        {
            List<ICS_Obqx> list = GetUserRanges(UserID);
            ICS_TREEDal dal = new ICS_TREEDal();
            foreach (ICS_Obqx r in list)
            {
                if (dal.IsDescendant(r.LX, r.SPECIES_ID, SpeciesType, SpeciesID)) return true;
            }
            return false;
        }
        /*
        */
        /// <summary>
        /// 删除已有对象权限
        /// </summary>
        /// <param name="SpeciesType"></param>
        /// <param name="SpeciesID"></param>
        /// <param name="UserLX"></param>
        /// <param name="UserID"></param>
        public void DeleteUserRange(int SpeciesType, int SpeciesID, int UserLX, int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ICS_OBQX ");
            strSql.Append(" where LX=" + SpeciesType + " ");
            strSql.Append(" and SPECIES_ID=" + SpeciesID + " ");
            strSql.Append(" and YHLX=" + UserLX + " ");
            strSql.Append(" and YHID=" + UserID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion  成员方法
    }
}
