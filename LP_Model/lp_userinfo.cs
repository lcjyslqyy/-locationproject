using Base_Helper.PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Model
{
    [TableName("lp_userinfo")]

    [PrimaryKey("openid", autoIncrement = false)]

    [ExplicitColumns]
    public partial class lp_userinfo
    {
        [Column]

        public string openid { get; set; }

        [Column]

        public string uname { get; set; }

        [Column]

        public string uphone { get; set; }

        [Column]

        public int ustatus { get; set; }

        [Column]

        public int issystem { get; set; }

        [Column]

        public DateTime createtime { get; set; }


    }

}
