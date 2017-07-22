using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Common.WechatModel
{
    public class AuthBaseModel : ErrorCode
    {
        //网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        public string access_token { get; set; }
        //access_token接口调用凭证超时时间，单位（秒）
        public string expires_in { get; set; }
        //	用户刷新access_token
        public string refresh_token { get; set; }
        //用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        public string openid { get; set; }
        //用户授权的作用域，使用逗号（,）分隔
        public string scope { get; set; }
        //只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字
        public string unionid { get; set; }
    }
}
