using System;
using System.Data;
using System.Text;
using thesis.idal;
using thesis.common;
using thesis.model;
using System.Collections.Generic;
namespace thesis.dal
{
	/// <summary>
	/// 数据访问类SPECIES12。
	/// </summary>
    public class UserDal : IUserDal
	{
		public UserDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID()
		{
		return DbHelperSQL.GetMaxID("ID", "SPECIES12"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SPECIES12");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(thesis.model.User model)
		{
			model.ID= GetMaxID() + 1;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SPECIES12(");
			strSql.Append("ID,NAME,MM,ZX,JIBIE,REPHOME,EMAIL,HP,TEL,FLAG,HOLD1,HOLD2,COMPANYID,DEPARTMENTID,OFFICEID");
			strSql.Append(")");
			strSql.Append(" values (");
            strSql.Append("" +model.ID + ",");
			strSql.Append("'"+model.NAME+"',");
			strSql.Append("'"+model.MM+"',");
			strSql.Append(""+model.ZX+",");
			strSql.Append(""+model.JIBIE+",");
			strSql.Append("'"+model.REPHOME+"',");
			strSql.Append("'"+model.EMAIL+"',");
			strSql.Append("'"+model.HP+"',");
			strSql.Append("'"+model.TEL+"',");
			strSql.Append(""+model.FLAG+",");
			strSql.Append("'"+model.HOLD1+"',");
			strSql.Append("'"+model.HOLD2+"',");
            strSql.Append("" + model.COMPANYID + ",");
            strSql.Append("" + model.DEPARTMENTID + ",");
            strSql.Append("" + model.OFFICEID + "");
			strSql.Append(")");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(thesis.model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SPECIES12 set ");
			strSql.Append("NAME='"+model.NAME+"',");
			strSql.Append("MM='"+model.MM+"',");
			strSql.Append("ZX="+model.ZX+",");
			strSql.Append("JIBIE="+model.JIBIE+",");
			strSql.Append("REPHOME='"+model.REPHOME+"',");
			strSql.Append("EMAIL='"+model.EMAIL+"',");
			strSql.Append("HP='"+model.HP+"',");
			strSql.Append("TEL='"+model.TEL+"',");
			strSql.Append("FLAG="+model.FLAG+",");
			strSql.Append("HOLD1='"+model.HOLD1+"',");
			strSql.Append("HOLD2='"+model.HOLD2+"',");
            strSql.Append("COMPANYID=" + model.COMPANYID + ",");
            strSql.Append("DEPARTMENTID=" + model.DEPARTMENTID + ",");
            strSql.Append("OFFICEID=" + model.OFFICEID + "");
			strSql.Append(" where ID="+ model.ID+" ");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete SPECIES12 ");
			strSql.Append(" where ID="+ID+" " );
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private thesis.model.User GetModelByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" ID,NAME,MM,ZX,JIBIE,REPHOME,EMAIL,HP,TEL,FLAG,HOLD1,HOLD2,COMPANYID,DEPARTMENTID,OFFICEID ");
            strSql.Append(" from SPECIES12 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            thesis.model.User model = new thesis.model.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.MM = ds.Tables[0].Rows[0]["MM"].ToString();
                if (ds.Tables[0].Rows[0]["ZX"].ToString() != "")
                {
                    model.ZX = int.Parse(ds.Tables[0].Rows[0]["ZX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JIBIE"].ToString() != "")
                {
                    model.JIBIE = int.Parse(ds.Tables[0].Rows[0]["JIBIE"].ToString());
                }
                model.REPHOME = ds.Tables[0].Rows[0]["REPHOME"].ToString();
                model.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                model.HP = ds.Tables[0].Rows[0]["HP"].ToString();
                model.TEL = ds.Tables[0].Rows[0]["TEL"].ToString();
                if (ds.Tables[0].Rows[0]["FLAG"].ToString() != "")
                {
                    model.FLAG = int.Parse(ds.Tables[0].Rows[0]["FLAG"].ToString());
                }
                model.HOLD1 = ds.Tables[0].Rows[0]["HOLD1"].ToString();
                model.HOLD2 = ds.Tables[0].Rows[0]["HOLD2"].ToString();
                if (!ds.Tables[0].Rows[0]["COMPANYID"].ToString().Equals(""))
                {
                    model.COMPANYID = int.Parse(ds.Tables[0].Rows[0]["COMPANYID"].ToString());
                }

                if (!ds.Tables[0].Rows[0]["DEPARTMENTID"].ToString().Equals(""))
                {
                    model.DEPARTMENTID = int.Parse(ds.Tables[0].Rows[0]["DEPARTMENTID"].ToString());
                }

                if (!ds.Tables[0].Rows[0]["OFFICEID"].ToString().Equals(""))
                {
                    model.OFFICEID = int.Parse(ds.Tables[0].Rows[0]["OFFICEID"].ToString());
                }
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
		public thesis.model.User GetModel(int ID)
		{
            return GetModelByCondition("ID=" + ID);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		private List<User> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,NAME,MM,ZX,JIBIE,REPHOME,EMAIL,HP,TEL,FLAG,HOLD1,HOLD2 ,COMPANYID,DEPARTMENTID,OFFICEID ");
			strSql.Append(" FROM SPECIES12 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DataSet ds= DbHelperSQL.Query(strSql.ToString());
            List<User> list = new List<User>();
			for(int i=0;i<ds.Tables[0].Rows.Count;i++)
			{
                thesis.model.User model = new thesis.model.User();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                model.MM = ds.Tables[0].Rows[i]["MM"].ToString();
                if (ds.Tables[0].Rows[i]["ZX"].ToString() != "")
                {
                    model.ZX = int.Parse(ds.Tables[0].Rows[i]["ZX"].ToString());
                }
                if (ds.Tables[0].Rows[i]["JIBIE"].ToString() != "")
                {
                    model.JIBIE = int.Parse(ds.Tables[0].Rows[i]["JIBIE"].ToString());
                }
                model.REPHOME = ds.Tables[0].Rows[i]["REPHOME"].ToString();
                model.EMAIL = ds.Tables[0].Rows[i]["EMAIL"].ToString();
                model.HP = ds.Tables[0].Rows[i]["HP"].ToString();
                model.TEL = ds.Tables[0].Rows[i]["TEL"].ToString();
                if (ds.Tables[0].Rows[i]["FLAG"].ToString() != "")
                {
                    model.FLAG = int.Parse(ds.Tables[0].Rows[i]["FLAG"].ToString());
                }
                model.HOLD1 = ds.Tables[0].Rows[i]["HOLD1"].ToString();
                model.HOLD2 = ds.Tables[0].Rows[i]["HOLD2"].ToString();
                if (!ds.Tables[0].Rows[i]["COMPANYID"].ToString().Equals(""))
                {
                    model.COMPANYID = int.Parse(ds.Tables[0].Rows[i]["COMPANYID"].ToString());
                }

                if (!ds.Tables[0].Rows[i]["DEPARTMENTID"].ToString().Equals(""))
                {
                    model.DEPARTMENTID = int.Parse(ds.Tables[0].Rows[i]["DEPARTMENTID"].ToString());
                }

                if (!ds.Tables[0].Rows[i]["OFFICEID"].ToString().Equals(""))
                {
                    model.OFFICEID = int.Parse(ds.Tables[0].Rows[i]["OFFICEID"].ToString());
                }
				list.Add(model);
			}
			return list;
		}

        public User GetModel(string name)
        {
            return GetModelByCondition("NAME='" + name+"'");
        }


        public List<User> GetSpcUsers()
        {
            return GetList("");
        }

        public List<User> GetPlanAlarmReceiptors(int PlanID)//获得监控计划的报警接收者  
        {
           string strSql = "ID in (select CHARGER from SPECIES7 where ID="+PlanID+")";
           return GetList(strSql);
        }
        public int GetSpcUsersCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            strSql.Append(" count(*)");
            strSql.Append(" from SPECIES12 where FLAG=0");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        public List<User> GetAllList()
        {
            return GetList("");
        }
		/*
		*/

		#endregion  成员方法

        #region IUserDal 成员


        public List<User> GetUsersOfGroup(int GroupID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region  MethodEx
        /// <summary>
        /// 将给定的表单转换为相对应的实体集合返回
        /// </summary>
        /// <param name="dt">需要转换的数据表</param>
        /// <returns>实体集</returns>
        public List<User> TableToModel(DataTable dt)
        {
            List<User> modellists = new List<User>();
            User model;
            foreach (DataRow dr in dt.Rows)
            {
                model = new User();
                if (dr["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                }
                model.NAME = dr["NAME"].ToString();
                model.MM = dr["MM"].ToString();
                if (dr["ZX"].ToString() != "")
                {
                    model.ZX = int.Parse(dr["ZX"].ToString());
                }
                if (dr["JIBIE"].ToString() != "")
                {
                    model.JIBIE = int.Parse(dr["JIBIE"].ToString());
                }
                model.REPHOME = dr["REPHOME"].ToString();
                model.EMAIL = dr["EMAIL"].ToString();
                model.HP = dr["HP"].ToString();
                model.TEL = dr["TEL"].ToString();
                if (dr["FLAG"].ToString() != "")
                {
                    model.FLAG = int.Parse(dr["FLAG"].ToString());
                }
                model.HOLD1 = dr["HOLD1"].ToString();
                model.HOLD2 = dr["HOLD2"].ToString();
                if (!dr["COMPANYID"].ToString().Equals(""))
                {
                    model.COMPANYID = int.Parse(dr["COMPANYID"].ToString());
                }

                if (!dr["DEPARTMENTID"].ToString().Equals(""))
                {
                    model.DEPARTMENTID = int.Parse(dr["DEPARTMENTID"].ToString());
                }

                if (!dr["OFFICEID"].ToString().Equals(""))
                {
                    model.OFFICEID = int.Parse(dr["OFFICEID"].ToString());
                }
                modellists.Add(model);
            }

            return modellists;
        }
        /// <summary>
        /// 在指定的时间内添加所有的实体集
        /// </summary>
        /// <param name="causelists">需添加实体集</param>
        /// <param name="times">指定的时间</param>
        /// <returns>返回执行状态</returns>
        public string AddByTran(List<User> lists, int times)
        {
            List<string> modellists = new List<string>();
            StringBuilder strSql;
            int num = 1;
            foreach (User model in lists)
            {
                strSql = new StringBuilder();
                //model.ID = GetMaxID() + num;
                strSql.Append("insert into SPECIES12(");
                strSql.Append("ID,NAME,MM,ZX,JIBIE,REPHOME,EMAIL,HP,TEL,FLAG,HOLD1,HOLD2,COMPANYID,DEPARTMENTID,OFFICEID");
                strSql.Append(")");
                strSql.Append(" values (");
                strSql.Append("" + model.ID + ",");
                strSql.Append("'" + model.NAME + "',");
                strSql.Append("'" + model.MM + "',");
                strSql.Append("" + model.ZX + ",");
                strSql.Append("" + model.JIBIE + ",");
                strSql.Append("'" + model.REPHOME + "',");
                strSql.Append("'" + model.EMAIL + "',");
                strSql.Append("'" + model.HP + "',");
                strSql.Append("'" + model.TEL + "',");
                strSql.Append("" + model.FLAG + ",");
                strSql.Append("'" + model.HOLD1 + "',");
                strSql.Append("'" + model.HOLD2 + "',");
                strSql.Append("" + model.COMPANYID + ",");
                strSql.Append("" + model.DEPARTMENTID + ",");
                strSql.Append("" + model.OFFICEID + "");
                strSql.Append(")");
                modellists.Add(strSql.ToString());
                num++;
            }

            return DbHelperSQL.ExecuteSqlByTran(modellists, times);
        }
        #endregion
    }
}

