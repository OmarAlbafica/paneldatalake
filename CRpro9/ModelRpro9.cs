namespace CRpro9
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelRpro9 : DbContext
    {

        public ModelRpro9(string ConexionOracle)
            : base(ConexionOracle)
            //: base("name=ModelRpro9")
        {
        }

        public virtual DbSet<INVN_QTY_BYSTORE> INVN_QTY_BYSTORE { get; set; }
        public virtual DbSet<DLK_CONTROL> DLK_CONTROL { get; set; }
        //public virtual DbSet<TX_DCS_V> TX_DCS_V { get; set; }
        //public virtual DbSet<TX_INVENTORY_V> TX_INVENTORY_V { get; set; }
        //public virtual DbSet<TX_PRICE_LVL_V> TX_PRICE_LVL_V { get; set; }
        //public virtual DbSet<TX_STORE_V> TX_STORE_V { get; set; }
        //public virtual DbSet<TX_SUBSIDIARY_V> TX_SUBSIDIARY_V { get; set; }
        //public virtual DbSet<TX_TAX_V> TX_TAX_V { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("REPORTUSER");

            //modelBuilder.Entity<TX_SUBSIDIARY_V>()
            //    .Property(e => e.SBS_NAME)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TX_SUBSIDIARY_V>()
            //    .Property(e => e.DISPLAY)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TX_INVENTORY_V>()
            //    .Property(e => e.COST)
            //    .HasPrecision(16, 4);

            //modelBuilder.Entity<TX_INVENTORY_V>()
            //    .Property(e => e.FC_COST)
            //    .HasPrecision(16, 4);

            //modelBuilder.Entity<TX_INVENTORY_V>()
            //    .Property(e => e.MAX_DISC_PERC1)
            //    .HasPrecision(16, 4);

            //modelBuilder.Entity<TX_INVENTORY_V>()
            //    .Property(e => e.MAX_DISC_PERC2)
            //    .HasPrecision(16, 4);

            //modelBuilder.Entity<TX_PRICE_LVL_V>()
            //    .Property(e => e.PRICE)
            //    .HasPrecision(16, 4);
        }
    }
}
