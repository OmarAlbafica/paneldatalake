namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("REPORTUSER.IE_ITEM_INSERT_UPDATE")]
    public partial class TX_INVN_QTY_V
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short STORE_NO { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ITEM_SID { get; set; }

        [StringLength(20)]
        public string ALU { get; set; }
        public long? LOCAL_UPC { get; set; }

        [StringLength(50)]
        public string GLOBAL_STORE_CODE { get; set; }
        public decimal CANT_DISPONIBLE { get; set; }

        public short? ISRT { get; set; }
        public short? UPDT { get; set; }

        public DateTime? FECHA_CREACION { get; set; }
        public DateTime? FECHA_MODIFICACION { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        [StringLength(50)]
        public string LOCATION_CODE { get; set; }
    }
}
