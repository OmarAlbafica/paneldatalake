
namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class TXT_PRICE_LIST
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }
               

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PRICE_LVL { get; set; }

        public string PRICE_LVL_NAME { get; set; }

       
        public string DISPLAY { get; set; }
    }
}
