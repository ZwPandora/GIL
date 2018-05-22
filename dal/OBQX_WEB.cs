using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.common;
using thesis.model;
using thesis.idal;
using System.Data;

namespace thesis.dal
{
    public class ObjectRangeDal_Web : IObjectRangeDal_Web
    {
        public ObjectRangeDal_Web()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "OBQX_WEB");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OBQX_WEB");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(thesis.model.ObjectRange_Web model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OBQX_WEB(");
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
        public void Update(thesis.model.ObjectRange_Web model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OBQX_WEB set ");
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
            strSql.Append("delete OBQX_WEB ");
            strSql.Append(" where ID=" + ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public thesis.model.ObjectRange_Web GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,LX,SPECIES_ID,YHLX,YHID ");
            strSql.Append(" from OBQX_WEB ");
            strSql.Append(" where ID=" + ID + " ");
            thesis.model.ObjectRange_Web model = new thesis.model.ObjectRange_Web();
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
        private List<ObjectRange_Web> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LX,SPECIES_ID,YHLX,YHID ");
            strSql.Append(" FROM OBQX_WEB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by LX");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ObjectRange_Web> list = new List<ObjectRange_Web>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.ObjectRange_Web model = new thesis.model.ObjectRange_Web();
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
        public List<ObjectRange_Web> GetAllList()
        {
            return GetList("");
        }
        public List<ObjectRange_Web> GetUserRanges(int UserID)
        {
            return GetList("YHLX=" + Web_Node.SPECIES_USER + " AND YHID=" + UserID);
        }
        public List<ObjectRange_Web> GetGroupRanges(int GroupID)
        {
            return GetList("YHLX=" + Web_Node.SPECIES_ROLE + " AND YHID=" + GroupID);
        }
        public bool CheckUserRange(int UserID, int SpeciesType, int SpeciesID)
        {
            List<ObjectRange_Web> list = GetUserRanges(UserID);
            Web_NodeDal dal = new Web_NodeDal();
            foreach (ObjectRange_Web r in list)
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
            strSql.Append("delete OBQX_WEB ");
            strSql.Append(" where LX=" + SpeciesType + " ");
            strSql.Append(" and SPECIES_ID=" + SpeciesID + " ");
            strSql.Append(" and YHLX=" + UserLX + " ");
            strSql.Append(" and YHID=" + UserID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion  成员方法
    }
}
