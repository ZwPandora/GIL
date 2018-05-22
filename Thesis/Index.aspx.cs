using System;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using thesis.bll;
using thesis.model;
using System.Net.Mail;
using System.Text;
using thesis.common;
using System.Management;
namespace Thesis
{
    public partial class Index : System.Web.UI.Page
    {
        public string CompanyWebSite = "";
        public string OASite = "";
        public string ServiceSite = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyWebSite = ConfigurationManager.AppSettings["CompanyWebSite"];
            OASite = ConfigurationManager.AppSettings["OASite"];
            ServiceSite = ConfigurationManager.AppSettings["ServiceSite"];
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    Response.Clear();
                }
            }
            //Response.Redirect(ConfigurationManager.AppSettings["MasterSite"]);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(tbUserName.Value.Trim()))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "noUser", "alert('用户名不能为空！');", true);
                return;
            }

            #region 查看当前用户是否已经被锁定(根据系统设定的最大密码错误次数和启用该功能的开关)
            string PassWordErrorRecord = StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["PassWordErrorRecord"].ToString()).ToUpper();
            if (PassWordErrorRecord.Equals("QIYONG") && !CheckErrorRecord())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "noUser", "alert('您今天的密码错误次数已经达到上限，系统拒绝您今天登陆！');", true);
                return;
            }
            #endregion

            FormsAuthentication.Initialize();
            UserBll userBll = new UserBll();
            thesis.model.User spcUser = userBll.GetModel(tbUserName.Value.Trim().ToLower());
            if (spcUser != null && spcUser.MM.Equals(StringEncodeAndDecode.Encode(tbPassword.Value.Trim())))
            {
                //写入日志
                OperationLogBll olBll = new OperationLogBll();
                OperationLog oLog = new OperationLog();
                oLog.SPECIES12_ID = spcUser.ID;
                string ipaddress = ClientIPAddress.getIPAddress();
                oLog.RQSJ = DateTime.Now;
                oLog.NR = spcUser.NAME + "成功登录本系统【" + ipaddress + "】!";
                oLog.ENR = spcUser.NAME + "load successfully[" + ipaddress + "]!";
                olBll.Add(oLog);

                //修改用户的登录信息，添加用户登陆日志

                /*修改用户的最新登陆日期和访问量*/
                string logindate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                spcUser.HOLD1 = logindate;
                spcUser.HOLD2 = spcUser.HOLD2.Trim().Equals("") ? "1" : (int.Parse(spcUser.HOLD2) + 1).ToString();

                userBll.Update(spcUser);

                /*写入登陆日志*/

                LoginRecordBLL loginbll = new LoginRecordBLL();
                LoginRecord record = new LoginRecord();
                record.USERID = spcUser.ID;
                record.IPADDRESS = ipaddress;
                record.LOGINDATE = logindate;
                record.BY2 = "";
                record.BY1 = "";

                loginbll.Add(record);


                // 为了实现认证，创建一个新的票据
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, // 票据版本号
                    tbUserName.Value.Trim(), // 票据持有者
                    DateTime.Now, //分配票据的时间
                    DateTime.Now.AddMinutes(30), // 失效时间
                    true, // 需要用户的 cookie 
                    "spcuser", // 用户数据，可以作为用户的角色
                    FormsAuthentication.FormsCookiePath);//cookie有效路径
                //使用机器码machine key加密cookie，为了安全传送
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName, // 认证cookie的名称
                    hash); //加密之后的cookie

                //将cookie的失效时间设置为和票据tikets的失效时间一致 
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                //添加cookie到页面请求响应中
                Response.Cookies.Add(cookie);

                // 将用户转向到之前请求的页面，
                // 如果之前没有请求任何页面，就转向到首页 
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null) returnUrl = "Default.aspx";

                // 不要调用 FormsAuthentication.RedirectFromLoginPage 方法，
                // 因为它会把刚才添加的票据（cookie）替换掉
                #region 清除密码错误记录
                if (PassWordErrorRecord.Equals("QIYONG"))
                {
                    string del = "delete from ERRORPASSWORDRECORD where username='" + this.tbUserName.Value + "' and ERRORDATE='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    DbHelperSQL.ExecuteSql(del);
                }
                #endregion

                #region 清除超时用户，同时清除自己以前的登录记录(目的是防止因为Session过期而导致的重新登陆拒绝问题)
                string LimitOnline = StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["LimitOnline"]);
                if (!LimitOnline.ToUpper().Equals("XJTUCIMSSPC"))
                {
                    if (DelTimeOut(this.tbUserName.Value.ToString()))
                    {
                        WriteActiveUser(this.tbUserName.Value.ToString());
                        Session["userwrx"] = spcUser;

                        Session["UserName2"] = tbUserName.Value.ToString();
                        Session["UserID"] = spcUser.ID;
                        Response.Redirect(returnUrl);
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "noUser", "alert('当前用户已经登录，不能重复登录！');", true);
                    }
                }
                else
                {
                    Session["userwrx"] = spcUser;

                    Session["UserName2"] = tbUserName.Value.ToString();
                    Session["UserID"] = spcUser.ID;
                    Response.Redirect(returnUrl);
                }

                #endregion
            }
            else
            {
                if (PassWordErrorRecord.Equals("QIYONG"))
                {
                    string sql_sel = "select * from ERRORPASSWORDRECORD where username='" + this.tbUserName.Value + "' and ERRORDATE='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    DataSet ds = DbHelperSQL.Query(sql_sel);
                    int max_error = 5;
                    int remain_error = 4;

                    if (!StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["ErrorRecordNum"].ToString()).Equals(""))
                    {
                        max_error = int.Parse(StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["ErrorRecordNum"].ToString()));
                    }
                    if (ds.Tables[0].Rows.Count == 0)//还没有错误过
                    {
                        string sql_ins = "insert into ERRORPASSWORDRECORD(username,IPADDRESS,ERRORNUM,ERRORDATE)values('" + this.tbUserName.Value + "','" + ClientIPAddress.getIPAddress() + "',1,'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        DbHelperSQL.ExecuteSql(sql_ins);
                    }
                    else
                    {
                        string sql_update = "update ERRORPASSWORDRECORD set ERRORNUM=ERRORNUM+1 where username='" + this.tbUserName.Value + "' and ERRORDATE='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        DbHelperSQL.ExecuteSql(sql_update);
                        remain_error = max_error - int.Parse(ds.Tables[0].Rows[0]["ERRORNUM"].ToString()) - 1;
                    }
                    this.ClientScript.RegisterStartupScript(this.GetType(), "noUser", "alert('错误的用户名/密码,您还有【" + remain_error + "】次尝试机会！');", true);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "noUser", "alert('错误的用户名/密码！');", true);
                }

            }
        }

        public bool CheckErrorRecord()
        {
            bool success = true;
            int max_error = 5;
            if (!StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["ErrorRecordNum"].ToString()).Equals(""))
            {
                max_error = int.Parse(StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["ErrorRecordNum"].ToString()));
            }

            string sql_sel = "select * from ERRORPASSWORDRECORD where username='" + this.tbUserName.Value + "' and ERRORDATE='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
            DataSet ds = DbHelperSQL.Query(sql_sel);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ERRORNUM"].ToString().Equals(max_error.ToString()))
                {
                    success = false;
                }

            }
            return success;
        }

        public bool DelTimeOut(string currentuser)
        {
            bool success = true;
            //基本思想是首先清除所有已经超时的用户（包括自己），判断方法是看最后的活跃时间是否在10秒钟以内，如果在十秒钟内，则说明该用户还是活跃的不能删除，否则删除
            #region 删除所有已经超时的用户
            string sql_del = "delete from ActiveUser where to_date(LASTUPDATETIME,'yyyy-MM-dd HH24:mi:ss')<to_date('" + System.DateTime.Now.AddSeconds(-10).ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss')";
            DbHelperSQL.ExecuteSql(sql_del);
            #endregion

            #region 判断自己是否可以进入系统
            //看自己当前的账户，是否还在活跃列表中
            string sql_sel = "select * from ActiveUser where username='" + currentuser + "'";

            DataSet ds = DbHelperSQL.Query(sql_sel);
            if (ds.Tables[0].Rows.Count > 0)//还在活跃
            {
                success = false;
            }
            #endregion
            return success;
        }

        public void WriteActiveUser(string currentuser)
        {
            string sql_ins = "insert into activeuser(username,LASTUPDATETIME,ipaddress)values('" + currentuser + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + ClientIPAddress.getIPAddress() + "')";
            DbHelperSQL.ExecuteSql(sql_ins);
        }

        public void resetcontent(object sender, EventArgs e)
        {
            this.tbUserName.Value = "";
            this.tbPassword.Value = "";
        }

        public void PassWordRecovery(object sender, EventArgs e)
        {
            if (!this.tbUserName.Value.Trim().Equals(""))
            {
                DataSet ds = DbHelperSQL.Query("select * from species12 where name='" + this.tbUserName.Value.Trim() + "'");

                if (ds.Tables[0].Rows.Count > 0)
                {

                    MailAddress MessageFrom = new MailAddress(ConfigurationManager.AppSettings["EmailForPassword"]); //发件人邮箱地址 
                    string MessageTo = ds.Tables[0].Rows[0]["email"].ToString(); //收件人邮箱地址 
                    string MessageSubject = "企业多态多工位质量数据分析平台密码找回服务"; //邮件主题 

                    string date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    StringBuilder sb = new StringBuilder();

                    sb.Append(@"尊敬的用户：
您好，您【");
                    sb.Append("企业多态多工位质量数据分析平台");
                    sb.Append(@"】的用户信息如下：
用户名：");
                    sb.Append(ds.Tables[0].Rows[0]["name"].ToString());
                    sb.Append(@"
密码：");
                    sb.Append(StringEncodeAndDecode.Decode(ds.Tables[0].Rows[0]["mm"].ToString()));
                    sb.Append(@"
请求IP：");
                    sb.Append(ClientIPAddress.getIPAddress());

                    sb.Append(@"

感谢您的使用，如果您有什么问题，请及时与我们联系，我们会在第一时间做出处理。

祝您工作顺利！
                                                    " + date + "");

                    string MessageBody = sb.ToString(); //邮件内容 

                    if (Send(MessageFrom, MessageTo, MessageSubject, MessageBody))
                    {

                        //Response.Write("<script>alert('密码已经发送到您注册的邮箱，请您查收邮件!');</script>");
                        ScriptManager.RegisterStartupScript(this.LinkButton1, this.GetType(), "0", "alert('密码已经发送到您注册的邮箱【" + MessageTo + "】，请您查收邮件!');", true);
                    }
                    else
                    {
                        //Response.Write("<script>alert('邮件发送过程中出错，请稍后重试!');</script>");
                        ScriptManager.RegisterStartupScript(this.LinkButton1, this.GetType(), "0", "alert('邮件发送过程中出错，请稍后重试!');", true);
                    }
                }
                else
                {
                    //Response.Write("<script>alert('请重新确认您的用户名！');</script>");
                    ScriptManager.RegisterStartupScript(this.LinkButton1, this.GetType(), "0", "alert('数据库中没有检索到该用户，请重新确认您的用户名！');", true);
                }
            }
            else
            {
                //Response.Write("<script>alert('请输入要密码找回的用户名！');</script>");
                ScriptManager.RegisterStartupScript(this.LinkButton1, this.GetType(), "0", "alert('请输入要密码找回的用户名！');", true);
            }

        }

        public bool Send(MailAddress AddressFrom, string AddressTo, string MessageSubject, string MessageContent)
        {
            bool success = false;
            MailMessage message = new MailMessage();
            message.From = AddressFrom;
            message.To.Add(AddressTo);
            message.Subject = MessageSubject;
            message.Body = MessageContent;
            message.IsBodyHtml = false;
            message.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Host = ConfigurationManager.AppSettings["popserver"];
            client.Port = int.Parse(ConfigurationManager.AppSettings["popserverport"]);
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["emailuser"], ConfigurationManager.AppSettings["emailpass"]);
            try
            {
                client.Send(message);
                success = true;
            }
            catch
            {


            }
            return success;
        }
    }
}