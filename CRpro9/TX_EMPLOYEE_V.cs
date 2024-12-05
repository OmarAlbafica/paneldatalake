namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TX_EMPLOYEE_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        public int EMPL_ID { get; set; }

        [StringLength(8)]
        public string EMPL_NAME { get; set; }

        [StringLength(3)]
        public string EMPL_CODE { get; set; }

        public decimal? MAX_DISC_PERC { get; set; }

        public long? CUST_SID { get; set; }

        public short? ACTIVE { get; set; }

        [StringLength(60)]
        public string RPRO_FULL_NAME { get; set; }

        public short HOME_SBS_NO { get; set; }

        public short? BASE_SBS_NO { get; set; }

        public short? BASE_STORE_NO { get; set; }

        public DateTime MODIFIED_DATE { get; set; }
    }
}
