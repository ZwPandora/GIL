﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace thesis.common
{
    public static class StringEncodeAndDecode
    {
        public const string KEY_64 = "W.RongXi";//加密解密密钥,是64位加密，所以是8个字符

        public const string IV_64 = "W.RongXi";

        public static string Encode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

        public static string Decode(string data)
        {
            if (data.Equals(""))
            {
                return "";
            }
            else
            {
                byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
                byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

                byte[] byEnc;
                try
                {
                    data = ConvertSpecialCharacter(data);
                    byEnc = Convert.FromBase64String(data);
                }
                catch
                {
                    return null;
                }
                try
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream(byEnc);
                    CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cst);
                    return sr.ReadToEnd();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static string Encode(string data, string Keycode)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(Keycode);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(Keycode);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

        public static string Decode(string data, string Keycode)
        {
            if (data.Equals(""))
            {
                return "";
            }
            else
            {
                byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(Keycode);
                byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(Keycode);

                byte[] byEnc;
                try
                {
                    data = ConvertSpecialCharacter(data);
                    byEnc = Convert.FromBase64String(data);
                }
                catch
                {
                    return null;
                }
                try
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream(byEnc);
                    CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cst);
                    return sr.ReadToEnd();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static string ConvertSpecialCharacter(string inputstring)
        {
            if (inputstring.Contains(" "))
            {
                inputstring = inputstring.Replace(' ', '+');
            }
            if (inputstring.Contains("%"))
            {
                inputstring = HttpUtility.UrlDecode(inputstring);
            }
            return inputstring;
        }
    }
}
