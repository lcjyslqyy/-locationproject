using LocateProject.Controllers.Base;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocateProject.Controllers
{
    public class V_WechatBaseController : Controller
    {
        protected WechatCookieModel wc_model = null;
        /// <summary>
        /// 设置JSON时间格式
        /// </summary>
        public IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();//这里使用自定义日期格式，默认是ISO8601格式
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";//设置时间格式
            string cookiestr = CommonMethod.CommonMethod.GetWechatLoginModel(HttpContext);
            if (String.IsNullOrWhiteSpace(cookiestr))
            {
                filterContext.Result = Redirect("/WechatAuth/Auth"); 
                return;
            }
            wc_model = Newtonsoft.Json.JsonConvert.DeserializeObject<WechatCookieModel>(cookiestr);//
            if(wc_model==null)
            {
                filterContext.Result = Redirect("/WechatAuth/Auth");
                return;
            }
            else
            {
                if (wc_model.issystem == 2 && filterContext.ActionDescriptor.ActionName != "Index" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "V_Main")//此状态为2时不是用户
                {
                    filterContext.Result = Redirect("/V_Main/Index");
                    return;
                }              
            }
        }
        //全局异常处理
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LP_Common.Log4Net.LogHelper exlog = LP_Common.Log4Net.LogFactory.GetLogger("systemerror");//记录异常
            exlog.Fatal(filterContext.Exception.Message.ToString());
            filterContext.ExceptionHandled = true;
            filterContext.Result = Json(new { success = false, msg = "系统异常." },JsonRequestBehavior.AllowGet);
        }

    }
    //方法的
    public class M_WechatBaseController : Controller
    {
        protected WechatCookieModel wc_model = null;
        /// <summary>
        /// 设置JSON时间格式
        /// </summary>
        public IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();//这里使用自定义日期格式，默认是ISO8601格式
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";//设置时间格式
            string cookiestr = CommonMethod.CommonMethod.GetWechatLoginModel(HttpContext);
            if (String.IsNullOrWhiteSpace(cookiestr))
            {
                filterContext.Result = Json(new { success = false, msg = "用户未授权." }, JsonRequestBehavior.AllowGet);
                return;
            }
            wc_model = Newtonsoft.Json.JsonConvert.DeserializeObject<WechatCookieModel>(cookiestr);//
            if (wc_model == null)
            {
                filterContext.Result = Json(new { success = false, msg = "用户未授权." }, JsonRequestBehavior.AllowGet);
                return;
            }
            
        }
        //全局异常处理
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LP_Common.Log4Net.LogHelper exlog = LP_Common.Log4Net.LogFactory.GetLogger("systemerror");//记录异常
            exlog.Fatal(filterContext.Exception.Message.ToString());
            filterContext.ExceptionHandled = true;
            filterContext.Result = Json(new { success = false, msg = "系统异常." }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 绑定数据模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T BindModel<T>()
            where T : new()
        {
            var Obj = new T();
            var properites = typeof(T).GetProperties();
            foreach (var p in properites)
            {
                var _value = Request[p.Name];

                if (_value != null)
                {
                    var name = p.PropertyType.IsGenericType ? "System.Nullable" : p.PropertyType.FullName;
                    if (name != "System.String")
                    {
                        if (_value != string.Empty)
                        {
                            switch (name)
                            {
                                case "System.Int64":
                                    long long_result;
                                    if (long.TryParse(_value, out long_result))
                                    {
                                        p.SetValue(Obj, long_result, null);
                                    }
                                    break;

                                case "System.Boolean":
                                    bool bool_result;
                                    if (bool.TryParse(_value, out bool_result))
                                    {
                                        p.SetValue(Obj, bool_result, null);
                                    }
                                    break;

                                case "System.Int32":
                                    int int_result;
                                    if (int.TryParse(_value, out int_result))
                                    {
                                        p.SetValue(Obj, int_result, null);
                                    }
                                    break;

                                case "System.DateTime":
                                    DateTime DateTime_result;
                                    if (DateTime.TryParse(_value, out DateTime_result))
                                    {
                                        p.SetValue(Obj, DateTime_result, null);
                                    }
                                    break;
                                case "System.Decimal":
                                    decimal decimal_result;
                                    if (decimal.TryParse(_value, out decimal_result))
                                    {
                                        p.SetValue(Obj, decimal_result, null);
                                    }
                                    break;

                                case "System.Double":
                                    double double_result;
                                    if (double.TryParse(_value, out double_result))
                                    {
                                        p.SetValue(Obj, double_result, null);
                                    }
                                    break;
                                case "System.Guid":
                                    Guid guid;
                                    if (Guid.TryParse(_value, out guid))
                                    {
                                        p.SetValue(Obj, guid, null);
                                    }
                                    break;
                                case "System.Nullable":
                                    p.SetValue(Obj, Convert.ChangeType(_value, Nullable.GetUnderlyingType(p.PropertyType)), null);

                                    break;
                            }
                        }
                    }
                    else
                    {
                        p.SetValue(Obj, _value, null);
                    }
                }
            }
            return Obj;
        }
    }
}
