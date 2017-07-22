using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocateProject.Controllers.View
{
    public class V_MainController : V_WechatBaseController
    {
        //
        public ActionResult Index()
        {
            if (wc_model.issystem != 2)
            {
                return Redirect("/V_Main/UserCenter");
            }
            return View();
        }
        //用户中心
        public ActionResult UserCenter()
        {
            if (wc_model.issystem != 1)
            {
                ViewBag.issystem = "display:none";
            }
            return View();
        }
        //修改用户信息
        public ActionResult Modifyinfo()
        {
            return View();
        }
        //出发地点定位列表
        public ActionResult sourceList()
        {
            return View();
        }
        //出发地点定位编辑
        public ActionResult sourceEdit(string id)
        {
            ViewBag.id = id;
            return View();
        }
        //目标地点定位列表
        public ActionResult targerList()
        {
            return View();
        }
        //目标地点定位编辑
        public ActionResult targerEdit(string id)
        {
            ViewBag.id = id;
            return View();
        }
        
    }
}
