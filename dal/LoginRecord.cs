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
    public class LoginRecordDal:ILoginRecord
    {
        public LoginRecordDal()
		{ }

        #region 成员方法
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("ID", "LOGINRECORD");
        }

        public void Add(thesis.model.LoginRecord model)
        {
            model.ID = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LOGINRECORD(");
            strSql.Append("ID,USERID,IPADDRESS,LOGINDATE,BY1,BY2");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ID + ",");
            strSql.Append("" + model.USERID + ",");
            strSql.Append("'" + model.IPADDRESS + "',");
            strSql.Append("'" + model.LOGINDATE + "',");
            strSql.Append("'" + model.BY1 + "',");
            strSql.Append("'" + model.BY2 + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public List<LoginRecord> GetAllList()
        {
            return GetList("");
        }

        public List<LoginRecord> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USERID,IPADDRESS,LOGINDATE,BY1,BY2");
            strSql.Append(" FROM LOGINRECORD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<LoginRecord> list = new List<LoginRecord>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                thesis.model.LoginRecord model = new thesis.model.LoginRecord();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                }
                model.USERID = int.Parse(ds.Tables[0].Rows[i]["USERID"].ToString());
                model.IPADDRESS = ds.Tables[0].Rows[i]["IPADDRESS"].ToString();
                model.LOGINDATE = ds.Tables[0].Rows[i]["LOGINDATE"].ToString();
                model.BY1 = ds.Tables[0].Rows[i]["BY1"].ToString();
                model.BY2 = ds.Tables[0].Rows[i]["BY2"].ToString();
                list.Add(model);
            }
            return list;
        }
        #endregion
    }
}
