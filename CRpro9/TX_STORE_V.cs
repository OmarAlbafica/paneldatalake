namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_STORE_V
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short? SBS_NO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short? STORE_NO { get; set; }

        [StringLength(5)]
        public string STORE_CODE { get; set; }

        [StringLength(40)]
        public string STORE_NAME { get; set; }

        [StringLength(55)]
        public string DISPLAY { get; set;}

        public short? PRICE_LVL { get; set; }

        public short? TAX_AREA_ID { get; set; }

        public short? ACTIVE { get; set; }
    }
}
