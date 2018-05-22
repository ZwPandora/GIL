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
	/// 数据访问类CZRZ。
	/// </summary>
	public class OperationLogDal:IOperationLogDal
	{
		public OperationLogDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID()
		{
		return DbHelperSQL.GetMaxID("ID", "CZRZ"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CZRZ");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(thesis.model.OperationLog model)
		{
			model.ID= GetMaxID() + 1;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CZRZ(");
			strSql.Append("ID,SPECIES12_ID,NR,ENR,RQSJ");
			strSql.Append(")");
			strSql.Append(" values (");
            strSql.Append("" +model.ID + ",");
			strSql.Append(""+model.SPECIES12_ID+","); 
			strSql.Append("'"+model.NR+"',");
			strSql.Append("'"+model.ENR+"',");
			strSql.Append(""+DbHelperSQL.GetDateTimeSQL(model.RQSJ)+"");
			strSql.Append(")");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(thesis.model.OperationLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CZRZ set ");
			strSql.Append("SPECIES12_ID="+model.SPECIES12_ID+",");
			strSql.Append("NR='"+model.NR+"',");
			strSql.Append("ENR='"+model.ENR+"',");
            strSql.Append("RQSJ=" + DbHelperSQL.GetDateTimeSQL(model.RQSJ) + "");
			strSql.Append(" where ID="+ model.ID+" ");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete CZRZ ");
			strSql.Append(" where ID="+ID+" " );
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public thesis.model.OperationLog GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select   ");
			strSql.Append(" ID,SPECIES12_ID,NR,ENR,RQSJ ");
			strSql.Append(" from CZRZ ");
			strSql.Append(" where ID="+ID+" " );
			thesis.model.OperationLog model=new thesis.model.OperationLog();
			DataSet  ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SPECIES12_ID"].ToString()!="")
				{
					model.SPECIES12_ID=int.Parse(ds.Tables[0].Rows[0]["SPECIES12_ID"].ToString());
				}
				model.NR=ds.Tables[0].Rows[0]["NR"].ToString();
				model.ENR=ds.Tables[0].Rows[0]["ENR"].ToString();
				if(ds.Tables[0].Rows[0]["RQSJ"].ToString()!="")
				{
					model.RQSJ=DateTime.Parse(ds.Tables[0].Rows[0]["RQSJ"].ToString());
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
		private List< OperationLog> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SPECIES12_ID,NR,ENR,RQSJ ");
			strSql.Append(" FROM CZRZ ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by RQSJ ");
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<OperationLog> list = new List<OperationLog>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.OperationLog model = new thesis.model.OperationLog();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES12_ID"].ToString() != "")
                {
                    model.SPECIES12_ID = int.Parse(ds.Tables[0].Rows[i]["SPECIES12_ID"].ToString());
                }
                model.NR = ds.Tables[0].Rows[i]["NR"].ToString();
                model.ENR = ds.Tables[0].Rows[i]["ENR"].ToString();
                if (ds.Tables[0].Rows[i]["RQSJ"].ToString() != "")
                {
                    model.RQSJ = DateTime.Parse(ds.Tables[0].Rows[i]["RQSJ"].ToString());
                }
                list.Add(model);
            }
            return list;
		}
        public List<OperationLog> GetAllList()
        {
            return GetList("");
        }
        public List<OperationLog> GetListByUser(int UserID)
        {
            return GetList("SPECIES12_ID=" + UserID);
        }
        public List<OperationLog> GetList(int UserID, DateTime from, DateTime to)
        {
            string strWhere="RQSJ BETWEEN " + DbHelperSQL.GetDateTimeSQL(from) + " AND " + DbHelperSQL.GetDateTimeSQL(to);
            if (UserID > 0)
            {
                strWhere = strWhere + " AND SPECIES12_ID=" + UserID;
            }
            return GetList(strWhere);
        }
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void DeleteList(int userID,DateTime fromtime,DateTime totime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CZRZ ");
            strSql.Append(" where ");
            strSql.Append(" RQSJ BETWEEN " + DbHelperSQL.GetDateTimeSQL(fromtime) + " AND " + DbHelperSQL.GetDateTimeSQL(totime));
            if (userID > 0)
            {
                strSql.Append(" AND SPECIES12_ID=" + userID + " ");
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


		/*
		*/

		#endregion  成员方法
	}
}

