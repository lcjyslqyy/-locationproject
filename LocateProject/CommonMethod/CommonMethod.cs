using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocateProject.CommonMethod
{
    public class CommonMethod
    {
        private static string WechatCookieName = "token";
        /// <summary>
        /// 设置登录Cookies,不带过期时间
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="data"></param>
        public static void SetWLoginData(HttpContextBase Context, object data)
        {
            if (data == null)
                throw new Exception("login data is null");
            string loginStr = LP_Common.DESEncrypt.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            HttpCookie cookie = new HttpCookie(WechatCookieName, loginStr);
            Context.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 获取智能停车登录数据
        /// </summary>
        /// <returns></returns>
        public static string GetWechatLoginModel(HttpContextBase Context)
        {
            string loginData = null;
            var loginCookie = GetWLoginCookie(Context);
            if (loginCookie != null)
            {
                loginData = LP_Common.DESEncrypt.Decrypt(loginCookie.Value);
            }
            return loginData;
        }
        public static HttpCookie GetWLoginCookie(HttpContextBase Context)
        {
            return Context.Request.Cookies[WechatCookieName];
        }
    }
}