namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_VENDOR_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string VEND_CODE { get; set; }

        [StringLength(25)]
        public string VEND_NAME { get; set; }

        [StringLength(30)]
        public string FIRST_NAME { get; set; }

        [StringLength(30)]
        public string LAST_NAME { get; set; }

        [StringLength(40)]
        public string ADDRESS1 { get; set; }

        [StringLength(40)]
        public string ADDRESS2 { get; set; }

        [StringLength(40)]
        public string ADDRESS3 { get; set; }

        [StringLength(10)]
        public string ZIP { get; set; }

        [StringLength(30)]
        public string PHONE1 { get; set; }

        [StringLength(20)]
        public string INFO1 { get; set; }

        public short? ACTIVE { get; set; }

        public short? VEND_ID { get; set; }

        public short? CURRENCY_ID { get; set; }

        [StringLength(256)]
        public string NOTES { get; set; }
    }
}
