namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_SUBSIDIARY_V
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short? SBS_NO { get; set; }

        [StringLength(15)]
        public string SBS_NAME { get; set; }

        [StringLength(32)]
        public string DISPLAY { get; set; }

        public short? ITEM_SID_SRC { get; set; }

        public short? STYLE_DEF { get; set; }

        public short? CURRENCY_ID { get; set; }

        public short? ACTIVE_PRICE_LVL { get; set; }
    }
}
