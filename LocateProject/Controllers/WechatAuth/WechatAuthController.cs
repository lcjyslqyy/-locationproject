using ILP_DAL;
using LocateProject.Controllers.Base;
using LP_Common;
using LP_Common.WechatModel;
using LP_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocateProject.Controllers.WechatAuth
{
    public class WechatAuthController : Controller
    {
        Ilp_userinfoDAL uudal;
        public WechatAuthController(Ilp_userinfoDAL _uudal)
        {
            this.uudal = _uudal;
        }
        public ActionResult Auth()
        {
            try
            {
                string code = Request["code"];
                if (Request.Url.Host.Equals("localhost") )
                {
                    code = "sdfafasdf";
                }
                if (String.IsNullOrEmpty(code))
                {
                    var url = EncodeUrl(Request.Url.AbsoluteUri);
                    string redirect_uri = Server.UrlEncode(String.Format("{0}", new string[] { url}));
                    string authorize_url = Getauthorize(BaseConfig.Wechatappid, redirect_uri, Scope.snsapi_base, "state", BaseConfig.WechatAuth);
                    return Redirect(authorize_url);
                }
                else
                {
                    string oauthUrl = BaseConfig.WechatAuth_access_token.Replace("{appid}", BaseConfig.Wechatappid).Replace("{secret}", BaseConfig.Wechatappsecret).Replace("{code}", code);
                    AuthBaseModel MA = new AuthBaseModel();
                    if (Request.Url.Host.Equals("localhost") )//判断是否是本地调试连接
                    {
                        MA.openid = "oqjP8wOL-kUnc7VfIHLlfUyv0Nm5";
                    }
                    else
                    {

                        string returnString = LP_Common.HttpUtil.Get(oauthUrl);
                        MA = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthBaseModel>(returnString);
                    }
                    if (MA.errcode == null || MA.errcode == "0")
                    {
                        WechatCookieModel cmodel = new WechatCookieModel();
                        //验证paycode
                        lp_userinfo umodel = uudal.SingleOrDefault((object)MA.openid);
                        if(umodel==null)
                        {
                            cmodel.issystem = 2;
                            cmodel.openid = MA.openid;
                            cmodel.cookietime = DateTime.Now;
                        }
                        else
                        {
                            if(umodel.ustatus==1)
                            {
                                return Redirect("/Error/Index?errormsg=您的帐号已被管理员禁用.");
                            }
                            else
                            {
                                cmodel.uname = umodel.uname;
                                cmodel.uphone = umodel.uphone;
                                cmodel.ustatus = umodel.ustatus;
                                cmodel.issystem = umodel.issystem;
                                cmodel.openid = MA.openid;
                                cmodel.cookietime = DateTime.Now;
                            }
                        }
                        CommonMethod.CommonMethod.SetWLoginData(HttpContext, cmodel);//设置cookie
                        return Redirect("/V_Main/Index");
                    }
                    else
                    {
                        return Redirect("/Error/Index?errormsg=" + MA.errmsg.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return Redirect("/Error/Index?errormsg=" + ex.ToString());
            }
        }
        /// <summary>
        /// 用户同意授权，获取code
        /// </summary>
        /// <param name="appid">appid</param>
        /// <param name="redirect_uri">回调的URL</param>
        /// <param name="enumScope">授权的方</param>
        /// <param name="state">一个随机参数，任意配置</param>
        /// <param name="url">XML的URL</param>
        /// <returns>返回请求的URL</returns>
        public static string Getauthorize(string appid, string redirect_uri, Scope enumScope, string state, string url)
        {
            string _scope = string.Empty;
            switch (enumScope)
            {
                case Scope.snsapi_base:
                    _scope = "snsapi_base";
                    break;
                case Scope.snsapi_userinfo:
                    _scope = "snsapi_userinfo";
                    break;
            }
            return url.Replace("{appid}", appid).Replace("{redirect_uri}", redirect_uri).Replace("{scope}", _scope).Replace("{state}", state);
        }
        /// <summary>
        /// ENCODE URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string EncodeUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
                return string.Empty;

            var split = url.Split(new string[] { "ret_url=" }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length > 1)
            {
                split[1] = split[1].Replace('&', '@');
                url = split[0] + "ret_url=" + split[1];
            }
            return url;
        }

    }
}
