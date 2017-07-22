using ILP_DAL;
using LocateProject.Controllers.Base;
using LP_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocateProject.Controllers.Method
{
    public class M_MainController : M_WechatBaseController
    {
        Ilp_userinfoDAL uudal=null;
        Ilp_targetlocationDAL tldal=null;
        Ilp_sourcelocationDAL sldal = null;
        public M_MainController(Ilp_userinfoDAL _uudal, Ilp_targetlocationDAL _tldal, Ilp_sourcelocationDAL _sldal)
        {
            this.uudal = _uudal;
            this.tldal = _tldal;
            this.sldal = _sldal;
        }
        //更新用户信息
        public ActionResult ADD_UserInfo()
        {
            lp_userinfo model = BindModel<lp_userinfo>();
            bool isexist = uudal.Exists("uphone=@0 ",model.uphone);
            if(isexist)
            {
                return Json(new { success = false, msg = "此号码已存在,请修改" });
            }
            else
            {
                model.openid = wc_model.openid;
                if(!string.IsNullOrWhiteSpace(LP_Common.BaseConfig.systemuserphonelist))
                {
                    string[] syslistphone = LP_Common.BaseConfig.systemuserphonelist.Split(',');
                    if(syslistphone.Contains(model.uphone))
                    {
                        model.issystem = 1;
                    }
                    else
                    {
                        model.issystem = 0;
                    }
                }
                else
                {
                    model.issystem = 0;
                }
                model.ustatus = 0;
                model.createtime = DateTime.Now;
                object obj = uudal.Add(model);
                WechatCookieModel cmodel = new WechatCookieModel();
                cmodel.uname = model.uname;
                cmodel.uphone = model.uphone;
                cmodel.ustatus = model.ustatus;
                cmodel.issystem = model.issystem;
                cmodel.openid = wc_model.openid;
                cmodel.cookietime = DateTime.Now;
                CommonMethod.CommonMethod.SetWLoginData(HttpContext, cmodel);//设置cookie                
                return Json(new { success = true, msg = "添加成功!" });
            }
            
        }
        //更新用户信息
        public ActionResult Update_UserInfo()
        {
            lp_userinfo model = new lp_userinfo();
            model.openid = wc_model.openid;
            model.uname = Request["uname"];
            model.uphone = Request["uphone"];
            int exec= uudal.Update(model, new string[] { "uname", "uphone" });
            if(exec>0)
            {
                wc_model.uname = model.uname;
                wc_model.uphone = model.uphone;
                CommonMethod.CommonMethod.SetWLoginData(HttpContext, wc_model);//设置cookie      
                return Json(new { success = true, msg = "更新成功!" });
            }
            else
            {
                return Json(new { success = false, msg = "更新失败!" });
            }
        }
        //只需要用户姓名和联系电话,从cookie中获取
        public ActionResult Get_UserInfoModel()
        {

            return Json(new { uname = wc_model.uname, uphone = wc_model.uphone }, JsonRequestBehavior.AllowGet);
        }
        //获取出发地点的目标坐标
        public ActionResult Get_SourceLactionList()
        {
            var slist = sldal.List("select * from lp_sourcelocation where openid=@0 and slstatus<>3 ", wc_model.openid);
            return Json(slist,JsonRequestBehavior.AllowGet);
        }
        //获取来源model
        public ActionResult Get_SModel()
        {
            object id = Request["id"];
            var model = sldal.SingleOrDefault(id);
            return Json(model);
        }
        //
        public ActionResult ADD_sourcelocation()
        {
            lp_sourcelocation model = BindModel<lp_sourcelocation>();
            model.createtime = DateTime.Now;
            model.openid = wc_model.openid;
            model.slid = System.Guid.NewGuid().ToString();
            object exec = sldal.Add(model);
            if (exec != null)
            {
                return Json(new { success = true, msg = "新增成功!" });
            }
            else
            {
                return Json(new { success = false, msg = "新增失败!" });
            }
        }
        //
        public ActionResult Update_sourcelocation()
        {
            lp_sourcelocation model = BindModel<lp_sourcelocation>();

            int exec = sldal.Update(model, new string[] { "tlid", "lat", "lng", "startouttime", "addressdes", "havecar", "starttype", "leftseat", "slstatus"});
            if (exec > 0)
            {
                return Json(new { success = true, msg = "更新成功!" });
            }
            else
            {
                return Json(new { success = false, msg = "更新失败!" });
            }
        }
        //获取目标分页
        public ActionResult GettargerList()
        {
            var slist = tldal.List("select tlid,tlname from lp_targetlocation where tlstatus=0");
            return Json(slist, JsonRequestBehavior.AllowGet);
        }
        //获取出发地点的目标坐标
        public ActionResult Get_TargerLactionList()
        {
            var slist = tldal.List("select * from lp_targetlocation where tlstatus<>3");
            return Json(slist, JsonRequestBehavior.AllowGet);
        }
        //新增目标地址
        public ActionResult ADD_targetlocation()
        {
            lp_targetlocation model = new lp_targetlocation();
            model.tlid = System.Guid.NewGuid().ToString();
            decimal lat;
            decimal.TryParse(Request["lat"], out lat);
            model.lat = lat;
            decimal lng;
            decimal.TryParse(Request["lat"], out lng);
            model.lng = lng;
            model.tlname = Request["tlname"];
            model.createtime = DateTime.Now;
            model.tlstatus = 0;
            bool isexits = tldal.Exists("tlstatus<>3 and tlname=@0 ", model.tlname);
            if (isexits)
            {
                return Json(new { success = false, msg = "存在同名的目标地址!" });
            }
            object exec = tldal.Add(model);
            if (exec!=null)
            {
                return Json(new { success = true, msg = "新增成功!" });
            }
            else
            {
                return Json(new { success = false, msg = "新增失败!" });
            }
        }
        //更新
        public ActionResult Update_targetlocation()
        {
            lp_targetlocation model = new lp_targetlocation();
            model.tlid = Request["id"];
            model.lat =decimal.Parse(Request["lat"]);
            model.lng =decimal.Parse(Request["lng"]);
            model.tlname = Request["tlname"];
            bool isexits = tldal.Exists("tlstatus<>3 and tlname=@0 and tlid<>@1", model.tlname, model.tlid);
            if(isexits)
            {
                return Json(new { success = false, msg = "存在同名的目标地址!" });
            }
            int exec = tldal.Update(model, new string[] { "lat", "lng", "tlname" });
            if (exec > 0)
            { 
                return Json(new { success = true, msg = "更新成功!" });
            }
            else
            {
                return Json(new { success = false, msg = "更新失败!" });
            }
        }
        //获取来源model
        public ActionResult Get_TModel()
        {
            object id = Request["id"];
            lp_targetlocation model = tldal.SingleOrDefault(id);
            return Json(model);
        }
        
    }
}
