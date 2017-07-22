using Base_Helper.PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Model
{
    [TableName("lp_targetlocation")]

    [PrimaryKey("tlid", autoIncrement = false)]

    [ExplicitColumns]
    public partial class lp_targetlocation
    {
        [Column]

        public string tlid { get; set; }

        [Column]

        public decimal lat { get; set; }

        [Column]

        public decimal lng { get; set; }

        [Column]

        public string tlname { get; set; }

        [Column]

        public DateTime createtime { get; set; }

        [Column]

        public int tlstatus { get; set; }


    }

}
