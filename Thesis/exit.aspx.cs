using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using thesis.common;
using thesis.bll;
using thesis.model;
using System.Collections.Generic;

namespace Thesis
{
    public partial class exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName = "";
            if (Session["UserName2"] != null && Session["UserID"] != null)
            {
                UserName = Session["UserName2"].ToString();
                //正常退出时应该改写活跃用户记录
                string sql = "delete from activeuser where username='" + Session["UserName2"].ToString() + "'";
                DbHelperSQL.ExecuteSql(sql);

                string userid = Session["UserID"].ToString();

                LoginRecordBLL bll = new LoginRecordBLL();
                List<LoginRecord> list = bll.GetList(" userid=" + userid + " order by id desc");
                string sql2 = "update loginrecord set BY1='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id=" + list[0].ID;
                DbHelperSQL.ExecuteSql(sql2);
            }
            Session["UserID"] = 0;
            Session["UserName"] = "";
            Session["UserName2"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Index.aspx");
        }
    }
}