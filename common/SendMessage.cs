using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace thesis.common
{
    public class SendMessage
    {

        //StringEncodeAndDecode sencode = new StringEncodeAndDecode();

        public string Message(string mobile, string contnet_type, string paras)
        {
            //bool success = false;

            string m_cid = "";
            if (contnet_type.Equals("1"))
            {
                // m_cid = "dUUPIV4QzjqM";
                m_cid = StringEncodeAndDecode.Decode(System.Configuration.ConfigurationSettings.AppSettings["model_type1"]);
            }
            else if (contnet_type.Equals("2"))
            {
                //m_cid = "fUrGMkHs4at2";
                m_cid = StringEncodeAndDecode.Decode(System.Configuration.ConfigurationSettings.AppSettings["model_type2"]);
            }

            //定义公共参数
            string cid = m_cid,
                    uid = StringEncodeAndDecode.Decode(System.Configuration.ConfigurationSettings.AppSettings["uid"]),
                    pas = StringEncodeAndDecode.Decode(System.Configuration.ConfigurationSettings.AppSettings["pas"]),
                    url = System.Configuration.ConfigurationSettings.AppSettings["url_address"];


            string temp_para = "mob=" + mobile + "&cid=" + cid + "&uid=" + uid + "&pas=" + pas + "&type=json";

            temp_para += "&" + paras;

            byte[] byteArray = Encoding.UTF8.GetBytes(temp_para);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length); newStream.Close();
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string message = php.ReadToEnd();
            return message;

            //if (message.Contains("0"))
            //{
            //    success = true;
            //}
            //return success;

        }

    }
}
