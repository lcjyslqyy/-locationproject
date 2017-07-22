using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Common
{
    public class BaseConfig
    {
        /// <summary>
        /// 数据库链接名称
        /// </summary>
        public static string DBConName
        {
            get { return ConfigurationManager.AppSettings["DBConName"].Trim(); }
        }
        /// <summary>
        /// 系统管理员电话列表,多个使用,分割
        /// </summary>
        public static string systemuserphonelist
        {
            get { return ConfigurationManager.AppSettings["systemuserphonelist"].Trim(); }
        }
        /// <summary>
        /// 微信公众号的appid
        /// </summary>
        public static string Wechatappid
        {
            get { return ConfigurationManager.AppSettings["Wechatappid"].Trim(); }
        }
        /// <summary>
        /// 微信公众号的appsecret
        /// </summary>
        public static string Wechatappsecret
        {
            get { return ConfigurationManager.AppSettings["Wechatappsecret"].Trim(); }
        }
        /// <summary>
        /// 微信授权url
        /// </summary>
        public static string WechatAuth
        {
            get { return ConfigurationManager.AppSettings["WechatAuth"].Trim(); }
        }
        /// <summary>
        /// 通过code换取网页授权openid
        /// </summary>
        public static string WechatAuth_access_token
        {
            get { return ConfigurationManager.AppSettings["WechatAuth_access_token"].Trim(); }
        }
        /// <summary>
        /// 通过code换取网页授权openid
        /// </summary>
        public static string CookieEncryptKey
        {
            get { return ConfigurationManager.AppSettings["CookieEncryptKey"].Trim(); }
        }
        
        
    }
}
