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
    class KiraTuruMap : EntityTypeConfiguration<KiraTuru>
    {
        public KiraTuruMap()
        {
            this.ToTable("tblKiraTuru");
            this.Property(p => p.KiraTuruId).HasColumnType("int");
            this.Property(p => p.KiraTuruId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.DailyPrice).HasColumnType("int");
            this.Property(p => p.WeeklyPrice).HasColumnType("int");
            this.Property(p => p.MonthlyPrice).HasColumnType("int");
        
        }
    }
}
