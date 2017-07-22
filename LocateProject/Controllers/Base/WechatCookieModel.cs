using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocateProject.Controllers.Base
{
    public class WechatCookieModel
    {
        //openid
        public string openid { get; set; }
        //姓名
        public string uname { get; set; }
        //联系电话
        public string uphone { get; set; }
        //状态
        public int ustatus { get; set; }
        //是否为管理员,0为正常用户,1为管理员,2为不是用户
        public int issystem { get; set; }
        //设置的时间
        public DateTime cookietime { get; set; }
    }
}