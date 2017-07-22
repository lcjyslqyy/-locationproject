using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Common
{
    public class PageModel
    {
        /// <summary>
        /// 表示要查询的列名
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// 要查询的表
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int current { get; set; }
        /// <summary>
        /// 每页多少行
        /// </summary>
        public int rowCount { get; set; }
        /// <summary>
        /// 查询条件不包含where字段,请尽量让查询参数化
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// 不包含order by字段..但需要包含desc或asc..如 createtime desc
        /// </summary>
        public string OrderBy { get; set; }
    }
}
