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
    class MusteriMap : EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            this.ToTable("tblMusteri");
            this.Property(p => p.MusteriId).HasColumnType("int");
            this.Property(p => p.MusteriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.FirstName).HasColumnType("varchar").HasMaxLength(128);
            this.Property(p => p.LastName).HasColumnType("varchar").HasMaxLength(128);
            this.Property(p => p.BornDate).HasColumnType("date");
            this.Property(p => p.Gender).HasColumnType("varchar").HasMaxLength(16);
            this.Property(p => p.MusteriEmail).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriKAdi).HasColumnType("varchar").HasMaxLength(30);
            this.Property(p => p.MusteriParola).HasColumnType("varchar").HasMaxLength(30);
        }
    }
}
