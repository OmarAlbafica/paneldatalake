namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_TAX_AREA_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }

        [Column(Order = 1)]
        public short STORE_NO { get; set; }

        [Key]
        [Column(Order = 2)]
        public short TAX_AREA_ID { get; set; }

        [StringLength(11)]
        public string TAX_AREA_NAME { get; set; }

        public short? ACTIVE { get; set; }
    }
}
