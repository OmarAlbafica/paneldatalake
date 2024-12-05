namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_INVENTORY_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ITEM_SID { get; set; }

        public long? LOCAL_UPC { get; set; }

        [StringLength(20)]
        public string ALU { get; set; }

        [StringLength(6)]
        public string VEND_NAME { get; set; }

        [StringLength(30)]
        public string DESCRIPTION1 { get; set; }

        [StringLength(50)]
        public string GLOBAL_STORE_CODE { get; set; }
    }
}
