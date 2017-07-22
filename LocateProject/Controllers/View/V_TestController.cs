using LP_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocateProject.Controllers.View
{
    public class V_TestController : Controller
    {

        //
        // GET: /V_Test/

        public ActionResult Index()
        {
            return Json(new { tt="555"},JsonRequestBehavior.AllowGet);
        }

    }
}
