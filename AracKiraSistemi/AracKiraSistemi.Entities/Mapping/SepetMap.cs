using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiraSistemi.Entities.Mapping
{
    class SepetMap : EntityTypeConfiguration<Sepet>
    {
        public SepetMap()
        {
            this.ToTable("tblSepet");
            this.Property(p => p.SepetId).HasColumnType("int");
            this.Property(p => p.SepetId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.PurchaseDate).HasColumnType("date");
            this.Property(p => p.DeliveryDate).HasColumnType("date");
            this.Property(p => p.TotalPrice).HasPrecision(15, 2);

            this.HasRequired(p => p.Musteri).WithMany(p => p.Sepets).HasForeignKey(p => p.CustomerId);
            this.HasRequired(p => p.Araba).WithMany(p => p.Sepets).HasForeignKey(p => p.CarId);
        }
    }
}
