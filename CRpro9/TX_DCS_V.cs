namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("REPORTUSER.TX_DCS_V")]
    public partial class TX_DCS_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string DCS_CODE { get; set; }

        public short? USE_QTY_DECIMALS { get; set; }

        public short? TAX_CODE { get; set; }

        public short? ACTIVE { get; set; }
    }
}
