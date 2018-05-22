using System;
using System.Collections.Generic;

using System.Web;
using thesis.common;
using System.IO;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;


    public class ErrorUtil
    {
        public ErrorUtil()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static void WriteError(string errorMessage, string username, string url, string detailmessage, string statcktrace, string date)
        {
            try
            {
                #region 将错误日志写进数据库
                OracleConnection conn = null;

                string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

                conn = new OracleConnection(connstr);
                conn.Open();

                OracleDataAdapter oda = new OracleDataAdapter("select max(id) from ERRORRECORD", conn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                int id = 1;

                if (!ds.Tables[0].Rows[0][0].ToString().Equals(""))
                {
                    id = int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                }

                OracleCommand commad = new OracleCommand("insert into ERRORRECORD (ID,USERNAME,URL,DETAILMESSAGE,STACKTRACE,RECORDDATE) values(" + id + ",'" + username + "','" + url + "',:detailmessage,:strackrace,'" + date + "')", conn);
                //commad.Parameters.AddWithValue("@content",true);

                OracleParameter op1 = new OracleParameter("detailmessage", OracleType.Clob);
                OracleParameter op2 = new OracleParameter("strackrace", OracleType.Clob);

                op1.Value = detailmessage;
                op2.Value = statcktrace;
                commad.Parameters.Add(op1);
                commad.Parameters.Add(op2);

                commad.ExecuteNonQuery();
                conn.Close();
                #endregion

                #region 将错误日志写进文件以备查验
                string path = "~/Error/" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\n错误实例 : ");
                    w.WriteLine("日期：{0}", date);
                    //string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +". Error Message:" + errorMessage;
                    //w.WriteLine(url);
                    w.WriteLine(errorMessage);
                    w.WriteLine("_________________________________________________________________________________");
                    w.Flush();
                    w.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        public static void WriteError(string errorMessage)
        {
            try
            {
                string path = "~/Error/" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\n错误实例 : ");
                    w.WriteLine("日期：{0}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +". Error Message:" + errorMessage;
                    w.WriteLine(System.Web.HttpContext.Current.Request.Url.ToString());
                    w.WriteLine(errorMessage);
                    w.WriteLine("_________________________________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }
    }
