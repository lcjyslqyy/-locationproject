using Base_Helper.PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Model
{
    [TableName("lp_sourcelocation")]

    [PrimaryKey("slid", autoIncrement = false)]

    [ExplicitColumns]
    public partial class lp_sourcelocation
    {
        [Column]

        public string slid { get; set; }

        [Column]

        public string tlid { get; set; }

        [Column]

        public string openid { get; set; }

        [Column]
        public int slstatus { get; set; }

        [Column]
        public string addressdes { get; set; }

        [Column]

        public string startouttime { get; set; }

        [Column]

        public int havecar { get; set; }

        [Column]

        public int starttype { get; set; }

        [Column]

        public decimal lat { get; set; }

        [Column]

        public decimal lng { get; set; }

        [Column]

        public int leftseat { get; set; }

        [Column]

        public DateTime createtime { get; set; }


    }

}
