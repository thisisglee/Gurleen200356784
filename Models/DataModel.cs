namespace Gurleen200356784.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<crop> crops { get; set; }
        public virtual DbSet<farmer> farmers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<crop>()
                .Property(e => e.cropname)
                .IsUnicode(false);

            modelBuilder.Entity<crop>()
                .HasMany(e => e.farmers)
                .WithRequired(e => e.crop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<farmer>()
                .Property(e => e.farmername)
                .IsUnicode(false);
        }
    }
}
