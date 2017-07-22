using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LP_Common
{
    public class DESEncrypt
    {
        public DESEncrypt()
        {

        }

        #region 全局变量

        /// <summary>
        /// 加密密匙
        /// </summary>
        private static string key = BaseConfig.CookieEncryptKey;

        #endregion
        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, key);
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            string EncryptKey = "";
            byte[] EncryptKeybyte = null;
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] inputByteArray1 = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(key));//md5加密,密钥
            EncryptKey = BitConverter.ToString(inputByteArray1).Replace("-", null).Substring(0, 8);
            EncryptKeybyte = ASCIIEncoding.ASCII.GetBytes(EncryptKey);
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = EncryptKeybyte;
            des.IV = EncryptKeybyte;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, key);
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                int len;
                len = Text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    string ee = Text.Substring(x * 2, 2);
                    i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                string EncryptKey = "";
                byte[] EncryptKeybyte = null;
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] inputByteArray1 = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(key));//md5加密,密钥
                EncryptKey = BitConverter.ToString(inputByteArray1).Replace("-", null).Substring(0, 8);
                EncryptKeybyte = ASCIIEncoding.ASCII.GetBytes(EncryptKey);
                des.Key = EncryptKeybyte;// ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                des.IV = EncryptKeybyte;// ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                throw new Exception("请确认传入的加密字符是正确的");
            }
        }
        #endregion
    }
}
