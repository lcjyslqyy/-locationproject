using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Common
{
    /// <summary>
    /// 枚举，授权类型
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// 静默授权
        /// </summary>
        snsapi_base,
        /// <summary>
        /// 弹出授权
        /// </summary>
        snsapi_userinfo
    }
}
