namespace CRpro9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HAPP_CARGA_ARTICULOS")]
    public partial class HAPP_CARGA_ARTICULOS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SBS_NO { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20)]
        public string STORE_CODE { get; set; }
        [StringLength(30)]
        public string SKU_PADRE { get; set; }
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20)]
        public string SKU { get; set; }
        [StringLength(1000)]
        public string NAME { get; set; }
        [StringLength(2000)]
        public string DESCRIPTION { get; set; }
        public decimal? PRICE { get; set; }
        [StringLength(20)]
        public string ESTADO { get; set; }
        [StringLength(50)]
        public string TAXONOMY { get; set; }
        [StringLength(20)]
        public string COLOR { get; set; }
        [StringLength(20)]
        public string TALLA { get; set; }
        public decimal? BANDERA { get; set; }
        public decimal? QTY { get; set; }
        [StringLength(20)]
        public string TIENDA { get; set; }
        [StringLength(30)]
        public string SKU_PP { get; set; }

        [StringLength(30)]
        public string COMERCIO { get; set; }
    }
}
