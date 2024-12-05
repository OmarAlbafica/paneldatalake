namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_CURRENCY_V
    {
        public short? SBS_NO { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CURRENCY_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string CURRENCY_NAME { get; set; }

        public byte? DECIMALS { get; set; }

        public short? ACTIVE { get; set; }

        public short? ACTIVE_PRICE_LVL { get; set; }
    }
}
