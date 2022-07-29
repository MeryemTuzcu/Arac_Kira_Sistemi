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
    class ArabaMap : EntityTypeConfiguration<Araba>
    {
        public ArabaMap()
        {
            this.ToTable("tblAraba");
            this.Property(p => p.ArabaId).HasColumnType("int");
            this.Property(p => p.ArabaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(128);
            this.Property(p => p.Model).HasColumnType("varchar").HasMaxLength(128);
            this.Property(p => p.Branch).HasColumnType("varchar").HasMaxLength(128);
            this.Property(p => p.Year).HasColumnType("int");
            this.Property(p => p.Km).HasColumnType("int");


            this.HasRequired(p => p.KiraTuru).WithMany(p => p.Arabas).HasForeignKey(p => p.LeaseTypeId);
        }
    }
}
